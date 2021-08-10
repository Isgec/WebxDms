Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  Partial Public Class xDmsFolders
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function GetAuthRootFolder(ByVal FolderID As Int32, UserID As String) As SIS.xDMS.xDmsFolders
      Dim fld As SIS.xDMS.xDmsFolders = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Dim fldID As Integer = FolderID
        Do While True
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "select * from xDMS_Folders where FolderID=" & fldID
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            If Reader.Read() Then
              fld = New SIS.xDMS.xDmsFolders(Reader)
            End If
            Reader.Close()
          End Using
          If fld.RequireExplicitAuthorization Then Exit Do
          Dim AthFound As Boolean = False
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "select isnull(count(*),0) from xDMS_FolderAuthorizations where FolderID=" & fldID & " and UserID='" & UserID & "'"
            Dim tmp As Integer = Cmd.ExecuteScalar()
            If tmp > 0 Then
              AthFound = True
            End If
          End Using
          If AthFound Then Exit Do
          If fld.ParentFolderID = "" Then Exit Do
          fldID = fld.ParentFolderID
        Loop
      End Using
      Return fld
    End Function
    Public Shared Function UZ_xDmsFoldersGetByID(ByVal FolderID As Int32) As SIS.xDMS.xDmsFolders
      Dim Results As SIS.xDMS.xDmsFolders = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDms_LG_FoldersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID", SqlDbType.Int, FolderID.ToString.Length, FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsFolders(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_xDmsChildFoldersGetByID(ByVal FolderID As Int32) As List(Of SIS.xDMS.xDmsFolders)
      Dim Results As New List(Of SIS.xDMS.xDmsFolders)
      Dim UserID As String = HttpContext.Current.Session("LoginID")
      Dim xUser As SIS.xDMS.xDmsUsers = SIS.xDMS.xDmsUsers.xDmsUsersGetByID(UserID)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If xUser.IsSAdmin Then
            Cmd.CommandText = "spxDms_LG_ChildFoldersForSAdmin"
          Else
            Cmd.CommandText = "spxDms_LG_ChildFoldersForUsers"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID", SqlDbType.Int, FolderID.ToString.Length, FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, UserID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While Reader.Read()
            Results.Add(New SIS.xDMS.xDmsFolders(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_xDmsFoldersGetByFolderName(ByVal FolderName As String, Optional ParentFolderID As Integer = 0) As SIS.xDMS.xDmsFolders
      Dim Results As SIS.xDMS.xDmsFolders = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDms_LG_FoldersSelectByFolderName"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderName", SqlDbType.NVarChar, 251, FolderName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentFolderID", SqlDbType.Int, 11, ParentFolderID)
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsFolders(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_xDmsFoldersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FolderID As Int32, ByVal ParentFolderID As Int32, ByVal StatusBy As String) As List(Of SIS.xDMS.xDmsFolders)
      Dim Results As List(Of SIS.xDMS.xDmsFolders) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FolderID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxdms_LG_xDmsFoldersSelectListSearch"
            Cmd.CommandText = "spxdmsFoldersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxdms_LG_xDmsFoldersSelectListFilteres"
            Cmd.CommandText = "spxdmsFoldersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FolderID", SqlDbType.Int, 10, IIf(FolderID = Nothing, 0, FolderID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ParentFolderID", SqlDbType.Int, 10, IIf(ParentFolderID = Nothing, 0, ParentFolderID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusBy", SqlDbType.NVarChar, 8, IIf(StatusBy Is Nothing, String.Empty, StatusBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFolders)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFolders(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_xDmsFoldersInsert(ByVal Record As SIS.xDMS.xDmsFolders) As SIS.xDMS.xDmsFolders
      Dim _Result As SIS.xDMS.xDmsFolders = xDmsFoldersInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFoldersUpdate(ByVal Record As SIS.xDMS.xDmsFolders) As SIS.xDMS.xDmsFolders
      Dim _Result As SIS.xDMS.xDmsFolders = xDmsFoldersUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFoldersDelete(ByVal Record As SIS.xDMS.xDmsFolders) As Integer
      Dim _Result as Integer = xDmsFoldersDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_FolderID"), TextBox).Text = ""
        CType(.FindControl("F_FolderName"), TextBox).Text = ""
        CType(.FindControl("F_ItemTypeID"),Object).SelectedValue = ""
        CType(.FindControl("F_ParentFolderID"), TextBox).Text = ""
        CType(.FindControl("F_ParentFolderID_Display"), Label).Text = ""
        CType(.FindControl("F_StatusBy"), TextBox).Text = ""
        CType(.FindControl("F_StatusBy_Display"), Label).Text = ""
        CType(.FindControl("F_StatusOn"), TextBox).Text = ""
        CType(.FindControl("F_StatusID"), TextBox).Text = ""
        CType(.FindControl("F_StatusID_Display"), Label).Text = ""
        CType(.FindControl("F_NodeLevel"), TextBox).Text = 0
        CType(.FindControl("F_Hseq"), TextBox).Text = 0
        CType(.FindControl("F_RequireExplicitAuthorization"), CheckBox).Checked = False
        CType(.FindControl("F_StatusRemarks"), TextBox).Text = ""
        CType(.FindControl("F_KeyWords"), TextBox).Text = ""
        CType(.FindControl("F_Active"), CheckBox).Checked = False
        CType(.FindControl("F_RequireExplicitWorkflow"), CheckBox).Checked = False
        CType(.FindControl("F_ReleaseWorkflowID"), TextBox).Text = ""
        CType(.FindControl("F_ReleaseWorkflowID_Display"), Label).Text = ""
        CType(.FindControl("F_ReviseWorkflowID"), TextBox).Text = ""
        CType(.FindControl("F_ReviseWorkflowID_Display"), Label).Text = ""
        CType(.FindControl("F_InitialWorkflowID"), TextBox).Text = ""
        CType(.FindControl("F_InitialWorkflowID_Display"), Label).Text = ""
        CType(.FindControl("F_UploadedStatusID"), TextBox).Text = ""
        CType(.FindControl("F_UploadedStatusID_Display"), Label).Text = ""
        CType(.FindControl("F_UseFileTypeWorkflow"), CheckBox).Checked = False
        CType(.FindControl("F_DuplicateFileNameAllowed"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function IsFolderExist(ParentFolderID As String, FolderName As String) As Boolean
      Dim mRet As Boolean = False
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          If ParentFolderID <> "" Then
            Cmd.CommandText = "select isnull(count(FolderID),0) as cnt from xDMS_Folders where ParentFolderID=" & ParentFolderID & " and Lower(FolderName)='" & FolderName.ToLower & "'"
          Else
            Cmd.CommandText = "select isnull(count(FolderID),0) as cnt from xDMS_Folders where ParentFolderID is NULL and Lower(FolderName)='" & FolderName.ToLower & "'"
          End If
          Con.Open()
          Dim cnt As Integer = Cmd.ExecuteScalar
          If cnt > 0 Then
            mRet = True
          End If
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function IsDuplicateFolder(FolderID As Integer, FolderName As String) As Boolean
      Dim mRet As Boolean = False
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Dim Sql As String = ""
          Sql &= " declare @pf int "
          Sql &= " select @pf=isnull(parentfolderid,0) from xdms_folders where folderid=" & FolderID
          Sql &= " if(@pf=0) "
          Sql &= "   select isnull(count(FolderID),0) as cnt from xDMS_Folders where FolderID<>" & FolderID & " and Lower(FolderName)='" & FolderName.ToLower & "' and ParentFolderID is NULL "
          Sql &= " else "
          Sql &= "   select isnull(count(FolderID),0) as cnt from xDMS_Folders where FolderID<>" & FolderID & " and Lower(FolderName)='" & FolderName.ToLower & "' and ParentFolderID=@pf "
          Cmd.CommandText = Sql
          'Cmd.CommandText = "select isnull(count(FolderID),0) as cnt from xDMS_Folders where FolderID<>" & FolderID & " and Lower(FolderName)='" & FolderName.ToLower & "' and ParentFolderID=(select parentfolderid from xdms_folders where folderid=" & FolderID & ")"
          Con.Open()
          Dim cnt As Integer = Cmd.ExecuteScalar
          If cnt > 0 Then
            mRet = True
          End If
        End Using
      End Using
      Return mRet
    End Function
  End Class
End Namespace
