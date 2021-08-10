Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  Partial Public Class xDmsHFiles
    Public Property IsAdmin As Boolean = False
    Public Property IsSAdmin As Boolean = False
    Public ReadOnly Property strFileSize() As String
      Get
        Dim y As Integer = FileSize
        If (y > 1073741824) Then Return (y / 1073741824).ToString("n") & " GB"
        If (y > 1048576) Then Return (y / 1048576).ToString("n") & " MB"
        If (y > 1024) Then Return (y / 1024).ToString("n") & " KB"
        Return y & " Bytes"
      End Get
    End Property
    Public ReadOnly Property BaseStatus As enumBaseStatus
      Get
        Return FK_xDMS_HFiles_StatusID.BaseStatusID
      End Get
    End Property
    Public ReadOnly Property RefForeColor As System.Drawing.Color
      Get
        Return System.Drawing.Color.Gray
      End Get
    End Property
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Select Case BaseStatus
        Case enumBaseStatus.Closed
          mRet = Drawing.Color.DarkGoldenrod
        Case enumBaseStatus.Free
          mRet = Drawing.Color.Black
        Case enumBaseStatus.WIP
          mRet = Drawing.Color.DarkMagenta
        Case enumBaseStatus.WIPOut
          mRet = Drawing.Color.Crimson
        Case enumBaseStatus.UIWF
          mRet = Drawing.Color.DarkGreen
        Case enumBaseStatus.UREWF
          mRet = Drawing.Color.DarkRed
        Case enumBaseStatus.URVWF
          mRet = Drawing.Color.DarkSlateBlue
        Case enumBaseStatus.Released
          mRet = Drawing.Color.DarkSlateGray
        Case enumBaseStatus.Superseded
          mRet = Drawing.Color.Tan
        Case enumBaseStatus.SysLock
          mRet = Drawing.Color.Gold
      End Select
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
    Public Shared Function UZ_xDmsHFilesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FileID As Int32) As List(Of SIS.xDMS.xDmsHFiles)
      Dim Results As New List(Of SIS.xDMS.xDmsHFiles)
      Dim usr As SIS.xDMS.xDmsUsers = SIS.xDMS.xDmsUsers.xDmsUsersGetByID(HttpContext.Current.Session("LoginID"))
      If usr IsNot Nothing Then
        If Not usr.CanViewAllRevisions Then
          Return Results
        Else
          'Check for current folder
        End If
      End If
      If OrderBy = "" Then OrderBy = "HFileID DESC"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxdms_LG_HFilesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxdms_LG_HFilesSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FileID", SqlDbType.Int, 10, IIf(FileID = Nothing, 0, FileID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsHFiles)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsHFiles(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_FileID"), TextBox).Text = 0
          CType(.FindControl("F_HFileID"), TextBox).Text = ""
          CType(.FindControl("F_FileName"), TextBox).Text = ""
          CType(.FindControl("F_FileRev"), TextBox).Text = ""
          CType(.FindControl("F_ItemTypeID"), TextBox).Text = ""
          CType(.FindControl("F_ItemTypeID_Display"), Label).Text = ""
          CType(.FindControl("F_FolderID"), TextBox).Text = ""
          CType(.FindControl("F_FolderID_Display"), Label).Text = ""
          CType(.FindControl("F_StatusID"), TextBox).Text = ""
          CType(.FindControl("F_StatusID_Display"), Label).Text = ""
          CType(.FindControl("F_StatusBy"), TextBox).Text = ""
          CType(.FindControl("F_StatusBy_Display"), Label).Text = ""
          CType(.FindControl("F_StatusOn"), TextBox).Text = ""
          CType(.FindControl("F_StatusRemarks"), TextBox).Text = ""
          CType(.FindControl("F_VaultDRID"), TextBox).Text = ""
          CType(.FindControl("F_FileExtn"), TextBox).Text = ""
          CType(.FindControl("F_FileSize"), TextBox).Text = 0
          CType(.FindControl("F_KeyWords"), TextBox).Text = ""
          CType(.FindControl("F_Active"), CheckBox).Checked = False
          CType(.FindControl("F_ParentIFileID"), TextBox).Text = 0
          CType(.FindControl("F_NodeLevel"), TextBox).Text = 0
          CType(.FindControl("F_Hseq"), TextBox).Text = 0
          CType(.FindControl("F_FileTypeID"), TextBox).Text = ""
          CType(.FindControl("F_FileTypeID_Display"), Label).Text = ""
          CType(.FindControl("F_WorkflowID"), TextBox).Text = ""
          CType(.FindControl("F_WorkflowID_Display"), Label).Text = ""
          CType(.FindControl("F_WorkflowStepID"), TextBox).Text = ""
          CType(.FindControl("F_WorkflowStepID_Display"), Label).Text = ""
          CType(.FindControl("F_WorkflowNextStepID"), TextBox).Text = ""
          CType(.FindControl("F_WorkflowNextStepID_Display"), Label).Text = ""
          CType(.FindControl("F_UserID"), TextBox).Text = ""
          CType(.FindControl("F_UserID_Display"), Label).Text = ""
          CType(.FindControl("F_GroupID"), TextBox).Text = ""
          CType(.FindControl("F_GroupID_Display"), Label).Text = ""
          CType(.FindControl("F_SystemRemarks"), TextBox).Text = ""
          CType(.FindControl("F_Purgable"), CheckBox).Checked = False
          CType(.FindControl("F_CreatedOn"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public ReadOnly Property DownloadLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/xDMS_Main/App_Downloads/downloadHistory.aspx?id=" & FileID & "&hid=" & HFileID & "', 'win" & FileID & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public Shared Function CreateHistory(FileID As Integer, Optional sRem As String = "", Optional purge As Boolean = False) As SIS.xDMS.xDmsHFiles
      Dim MainFile As SIS.xDMS.xDmsHFiles = SIS.xDMS.xDmsFiles.GetFileForHistory(FileID)
      Dim Results As List(Of SIS.xDMS.xDmsHFiles) = SIS.xDMS.xDmsFiles.GetChildFilesForHistory(FileID)
      With MainFile
        .SystemRemarks = sRem
        .Purgable = purge
        .CreatedOn = Now
      End With
      MainFile = SIS.xDMS.xDmsHFiles.InsertData(MainFile)
      For Each fl As SIS.xDMS.xDmsHFiles In Results
        With fl
          .HFileID = MainFile.HFileID
          .SystemRemarks = sRem
          .Purgable = purge
          .CreatedOn = Now
        End With
        fl = SIS.xDMS.xDmsHFiles.InsertData(fl)
      Next
      Return MainFile
    End Function
    Public Shared Function CreateChildHistory(FileID As Integer, Optional sRem As String = "", Optional purge As Boolean = False) As SIS.xDMS.xDmsHFiles
      Dim MainFile As SIS.xDMS.xDmsHFiles = SIS.xDMS.xDmsFiles.GetFileForHistory(FileID)
      With MainFile
        .HFileID = GetLatestHFileID(MainFile.ParentIFileID)
        .SystemRemarks = sRem
        .Purgable = purge
        .CreatedOn = Now
      End With
      MainFile = SIS.xDMS.xDmsHFiles.InsertData(MainFile)
      Return MainFile
    End Function
    Public Shared Function GetLatestHFileID(FileID As Integer) As Integer
      Dim Tmp As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = " select isnull(max(HFileID),0) from xDms_HFiles where FileID=" & FileID
          Tmp = Cmd.ExecuteScalar
        End Using
      End Using
      Return Tmp
    End Function
    Public Shared Function GetMatchingHFileID(uFil As SIS.xDMS.xDmsHFiles) As Integer
      'This function is used for migration only
      Dim Tmp As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = " select isnull(max(HFileID),0) from xDms_HFiles where FileID=" & uFil.FileID & " and StatusBy='" & uFil.StatusBy & "' and StatusOn=convert(datetime,'" & uFil.StatusOn & "',103) and StatusRemarks='" & uFil.StatusRemarks & "'"
          Tmp = Cmd.ExecuteScalar
        End Using
      End Using
      Return Tmp
    End Function

    Public Shared Function DeleteChildHistory(FileID As Integer) As SIS.xDMS.xDmsHFiles
      Dim MainFile As SIS.xDMS.xDmsHFiles = SIS.xDMS.xDmsFiles.GetFileForHistory(FileID)
      MainFile.HFileID = GetLatestHFileID(MainFile.ParentIFileID)
      SIS.xDMS.xDmsHFiles.xDmsHFilesDelete(MainFile)
      Return MainFile
    End Function

    Public Shared Function UZ_xDmsRefHFilesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal ParentIFileID As Int32, HFileID As Integer) As List(Of SIS.xDMS.xDmsHFiles)
      If ParentIFileID = 0 Then Return Nothing
      Dim xUser As SIS.xDMS.xDmsUsers = SIS.xDMS.xDmsUsers.xDmsUsersGetByID(HttpContext.Current.Session("LoginID"))
      Dim Results As List(Of SIS.xDMS.xDmsHFiles) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FileID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDms_LG_RefHFilesSelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentIFileID", SqlDbType.Int, 10, IIf(ParentIFileID = Nothing, 0, ParentIFileID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HFileID", SqlDbType.Int, 10, IIf(HFileID = Nothing, 0, HFileID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsHFiles)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim x As New SIS.xDMS.xDmsHFiles(Reader)
            If xUser IsNot Nothing Then
              x.IsAdmin = xUser.IsAdmin
              x.IsSAdmin = xUser.IsSAdmin
            End If
            Results.Add(x)
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsRefHFilesSelectCount(ByVal ParentIFileID As Int32, HFileID As Integer) As Integer
      Return _RecordCount
    End Function
    Public Shared Function RefHDeleteWF(ByVal FileID As Int32, HFileID As Integer) As SIS.xDMS.xDmsHFiles
      Dim Results As SIS.xDMS.xDmsHFiles = xDmsHFilesGetByID(FileID, HFileID)
      SIS.xDMS.xDmsHFiles.xDmsHFilesDelete(Results)
      If Results.VaultDRID <> "" Then
        ejiVault.EJI.ediAFile.FileDelete(Results.VaultDRID)
      End If
      Return Results
    End Function

  End Class
End Namespace
