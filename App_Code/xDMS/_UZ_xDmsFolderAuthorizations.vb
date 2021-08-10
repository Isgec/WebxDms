Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  Partial Public Class xDmsFolderAuthorizations
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
    Public Shared Function UZ_xDmsFolderAuthorizationsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal FolderID As Int32, ByVal CreatedBy As String) As List(Of SIS.xDMS.xDmsFolderAuthorizations)
      Dim Results As List(Of SIS.xDMS.xDmsFolderAuthorizations) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "UserID"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxdms_LG_FolderAuthorizationsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxdms_LG_FolderAuthorizationsSelectListFilteres"

            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserID",SqlDbType.NVarChar,8, IIf(UserID Is Nothing, String.Empty,UserID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FolderID",SqlDbType.Int,10, IIf(FolderID = Nothing, 0,FolderID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy",SqlDbType.NVarChar,8, IIf(CreatedBy Is Nothing, String.Empty,CreatedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFolderAuthorizations)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFolderAuthorizations(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_xDmsFolderAuthorizationsInsert(ByVal Record As SIS.xDMS.xDmsFolderAuthorizations) As SIS.xDMS.xDmsFolderAuthorizations
      Dim _Result As SIS.xDMS.xDmsFolderAuthorizations = xDmsFolderAuthorizationsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFolderAuthorizationsUpdate(ByVal Record As SIS.xDMS.xDmsFolderAuthorizations) As SIS.xDMS.xDmsFolderAuthorizations
      Dim _Result As SIS.xDMS.xDmsFolderAuthorizations = xDmsFolderAuthorizationsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFolderAuthorizationsDelete(ByVal Record As SIS.xDMS.xDmsFolderAuthorizations) As Integer
      Dim _Result as Integer = xDmsFolderAuthorizationsDelete(Record)
      Return _Result
    End Function
    Public Shared Function DeleteAuthorizationsForFolderID(FolderID As Integer) As Integer
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "Delete xDMS_FolderAuthorizations Where FolderID=" & FolderID
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return _Result

    End Function

    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_UserID"), TextBox).Text = ""
          CType(.FindControl("F_UserID_Display"), Label).Text = ""
          CType(.FindControl("F_FolderID"), TextBox).Text = ""
          CType(.FindControl("F_FolderID_Display"), Label).Text = ""
          CType(.FindControl("F_CreateFolder"), CheckBox).Checked = False
          CType(.FindControl("F_UpdateFolder"), CheckBox).Checked = False
          CType(.FindControl("F_DeleteFolder"), CheckBox).Checked = False
          CType(.FindControl("F_UploadFile"), CheckBox).Checked = False
          CType(.FindControl("F_DownloadFile"), CheckBox).Checked = False
          CType(.FindControl("F_DeleteFile"), CheckBox).Checked = False
          CType(.FindControl("F_CanAuthorizeFolder"), CheckBox).Checked = False
          CType(.FindControl("F_CanPassAuthorization"), CheckBox).Checked = False
          CType(.FindControl("F_RequireExplicitAuthorization"), CheckBox).Checked = False
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
          CType(.FindControl("F_ShowAtRoot"), CheckBox).Checked = False
          CType(.FindControl("F_IsAdmin"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetAuthorizedUsers(FolderID As Integer) As List(Of String)
      Dim mRet As New List(Of String)
      Dim Sql As String = ""
      Sql &= "  WITH cte (folderid,parentfolderid,RequireExplicitWorkflow) AS ( "
      Sql &= "    SELECT folderid,parentfolderid,RequireExplicitWorkflow FROM xdms_folders WHERE  folderid=" & FolderID
      Sql &= "    UNION ALL "
      Sql &= "  SELECT c.folderid,c.parentfolderid,c.RequireExplicitWorkflow FROM xdms_folders c INNER JOIN cte ON cte.parentfolderid = c.folderid )"
      Sql &= "  Select distinct UserID from xdms_folderauthorizations where FolderID in (SELECT FolderID FROM cte) "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While rd.Read
            mRet.Add(rd("UserID"))
          End While
        End Using
      End Using
      Return mRet
    End Function

    Public Shared Function GetApplicableFA(FolderID As Integer, UserID As String) As SIS.xDMS.xDmsFolderAuthorizations
      'copy all data from parent to child folder->Authorization record
      Dim mRet As SIS.xDMS.xDmsFolderAuthorizations = Nothing
      Dim Sql As String = ""
      Sql &= "  WITH cte (folderid,parentfolderid,RequireExplicitWorkflow) AS ( "
      Sql &= "    SELECT folderid,parentfolderid,RequireExplicitWorkflow FROM xdms_folders WHERE  folderid=" & FolderID
      Sql &= "    UNION ALL "
      Sql &= "  SELECT c.folderid,c.parentfolderid,c.RequireExplicitWorkflow FROM xdms_folders c INNER JOIN cte ON cte.parentfolderid = c.folderid )"
      Sql &= "  SELECT top 1 * FROM cte		where folderid in (select folderid from xdms_folderauthorizations where userid='" & UserID & "')"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While rd.Read
            mRet = SIS.xDMS.xDmsFolderAuthorizations.xDmsFolderAuthorizationsGetByID(UserID, rd("FolderID"))
          End While
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function DeleteAllFA(FolderID As Integer) As Integer
      Dim mRet As Integer = 0
      Dim Sql As String = ""
      Sql &= " delete xdms_folderauthorizations where FolderID=" & FolderID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function UpdateAllFA(FolderID As Integer) As Integer
      Dim mRet As Integer = 0
      Dim Sql As String = ""
      Sql &= " update xdms_folderauthorizations set "
      Sql &= " xdms_folderauthorizations.RequireExplicitAuthorization = a.RequireExplicitAuthorization, "
      Sql &= " xdms_folderauthorizations.RequireExplicitWorkflow = a.RequireExplicitWorkflow, "
      Sql &= " xdms_folderauthorizations.ReleaseWorkflowID = a.ReleaseWorkflowID, "
      Sql &= " xdms_folderauthorizations.ReviseWorkflowID = a.ReviseWorkflowID, "
      Sql &= " xdms_folderauthorizations.UseFileTypeWorkflow = a.UseFileTypeWorkflow, "
      Sql &= " xdms_folderauthorizations.DuplicateFileNameAllowed = a.DuplicateFileNameAllowed, "
      Sql &= " xdms_folderauthorizations.UploadedStatusID = a.UploadedStatusID, "
      Sql &= " xdms_folderauthorizations.InitialWorkflowID = a.InitialWorkflowID  "
      Sql &= " from xdms_folderauthorizations "
      Sql &= " inner join xdms_folders as a on xdms_folderauthorizations.folderid = a.folderid "
      Sql &= " where xdms_folderauthorizations.FolderID=" & FolderID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return mRet
    End Function
  End Class
End Namespace
