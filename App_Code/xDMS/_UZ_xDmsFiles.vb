Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports ejiVault
Namespace SIS.xDMS
  Partial Public Class xDmsFiles
    Public ReadOnly Property WorkflowName As String
      Get
        Dim mRet As String = ""
        If WorkflowID <> "" Then
          mRet = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(WorkflowID).WorkflowName
        End If
        Return mRet
      End Get
    End Property
    Public Property IsAdmin As Boolean = False
    Public Property IsSAdmin As Boolean = False
    Public Property Selected As Boolean = False
    Public Property AthHandle As String
      Get
        If StatusRemarks = "Migrated" Then
          Return "J_DMSFILES"
        End If
        Return "J_xDMSFILES"
      End Get
      Set(value As String)

      End Set
    End Property
    Public ReadOnly Property AthIndex As String
      Get
        Return FileID & "_" & Me.FileRev
      End Get
    End Property
    Public ReadOnly Property DownloadLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/xDMS_Main/App_Downloads/download.aspx?id=" & PrimaryKey & "', 'win" & FileID & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return false;"
      End Get
    End Property
    Public ReadOnly Property CheckoutLink() As String
      Get
        Return "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/xDMS_Main/App_Downloads/download.aspx?id=" & PrimaryKey & "&checkout=1" & "', 'win" & FileID & "', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1'); return true;"
      End Get
    End Property
    Public ReadOnly Property BaseStatus As enumBaseStatus
      Get
        Return FK_xDMS_Files_StatusID.BaseStatusID
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
    Public ReadOnly Property UploadRefVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BaseStatus
            Case enumBaseStatus.Free, enumBaseStatus.WIP
              mRet = True
            Case enumBaseStatus.WIPOut
              If StatusBy = HttpContext.Current.Session("LoginID") Then
                mRet = True
              End If
            Case Else
              If IsAdmin Or IsSAdmin Then
                mRet = True
              End If
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property

    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BaseStatus
            Case enumBaseStatus.Free, enumBaseStatus.WIP
              mRet = True
            Case enumBaseStatus.WIPOut
              If StatusBy = HttpContext.Current.Session("LoginID") Then
                mRet = True
              End If
            Case Else
              If IsAdmin Or IsSAdmin Then
                mRet = True
              End If
          End Select
          If mRet = False Then
            'Initial Status = Upload Status
            If FK_xDMS_Files_FolderID.UploadedStatusID = StatusID Then
              mRet = True
            End If
          End If
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RefDeleteVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BaseStatus
            Case enumBaseStatus.Free, enumBaseStatus.WIP
              mRet = True
            Case enumBaseStatus.WIPOut
              If StatusBy = HttpContext.Current.Session("LoginID") Then
                mRet = True
              End If
            Case Else
              If IsAdmin Or IsSAdmin Then
                mRet = True
              End If
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property

    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BaseStatus
            Case enumBaseStatus.Free, enumBaseStatus.WIP, enumBaseStatus.Released
              mRet = True
            Case Else
              If StatusID = FK_xDMS_Files_FolderID.UploadedStatusID Then
                mRet = True
              End If
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property RevertWFVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BaseStatus
            Case enumBaseStatus.Closed
              If IsAdmin Or IsSAdmin Then
                mRet = True
              End If
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property UndoCheckOutVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BaseStatus
            Case enumBaseStatus.WIPOut
              If StatusBy = HttpContext.Current.Session("LoginID") Then
                mRet = True
              End If
              If IsAdmin Or IsSAdmin Then
                mRet = True
              End If
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CheckInVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BaseStatus
            Case enumBaseStatus.WIPOut
              If StatusBy = HttpContext.Current.Session("LoginID") Then
                mRet = True
              End If
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property CheckOutVisible() As Boolean
      Get
        Dim mRet As Boolean = False
        Try
          Select Case BaseStatus
            Case enumBaseStatus.WIP
              mRet = True
          End Select
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property strFileSize() As String
      Get
        Dim y As Integer = FileSize
        If (y > 1073741824) Then Return (y / 1073741824).ToString("n") & " GB"
        If (y > 1048576) Then Return (y / 1048576).ToString("n") & " MB"
        If (y > 1024) Then Return (y / 1024).ToString("n") & " KB"
        Return y & " Bytes"
      End Get
    End Property

    Public Shared Function RevertWF(ByVal FileID As Int32) As SIS.xDMS.xDmsFiles
      '=====================
      Return ReturnWF(FileID)
      '=====================
      Dim Results As SIS.xDMS.xDmsFiles = xDmsFilesGetByID(FileID)
      Select Case Results.StatusID
        Case enumStatus.Free
        Case Else
          With Results
            .StatusOn = Now
            .StatusID = enumStatus.Free
            .Selected = False
          End With
          SIS.xDMS.xDmsFiles.UpdateData(Results)
      End Select
      Return Results
    End Function
    Public Shared Function UndoCheckedOut(ByVal FileID As Int32) As SIS.xDMS.xDmsFiles
      Dim uUsr As String = HttpContext.Current.Session("LoginID")
      Dim uFil As SIS.xDMS.xDmsFiles = xDmsFilesGetByID(FileID)
      Dim uUsrFA As SIS.xDMS.xDmsFolderAuthorizations = SIS.xDMS.xDmsFolderAuthorizations.GetApplicableFA(uFil.FolderID, uUsr)
      With uFil
        .StatusBy = HttpContext.Current.Session("LoginID")
        .StatusOn = Now
        If uUsrFA.UploadedStatusID = "" Then
          .StatusID = enumStatus.Free
        Else
          .StatusID = uUsrFA.UploadedStatusID
        End If
        .Selected = False
        .StatusRemarks = "Undo Checkout"
      End With
      uFil = SIS.xDMS.xDmsFiles.UpdateData(uFil)
      'Fetch all child files and update
      Dim Results As List(Of SIS.xDMS.xDmsFiles) = SIS.xDMS.xDmsFiles.UZ_xDmsRefFilesSelectList(0, 9999, "", FileID)
      For Each xF As SIS.xDMS.xDmsFiles In Results
        With xF
          .StatusBy = uFil.StatusBy
          .StatusOn = uFil.StatusOn
          .StatusID = uFil.StatusID
          .Selected = False
          .StatusRemarks = uFil.StatusRemarks
        End With
        SIS.xDMS.xDmsFiles.UpdateData(xF)
      Next
      'Insert in History on every update
      '========================
      SIS.xDMS.xDmsHFiles.CreateHistory(uFil.FileID, "Undo Checkout", True)
      '==========================
      Return uFil
    End Function

    Public Shared Function CheckedOut(ByVal FileID As Int32) As SIS.xDMS.xDmsFiles
      Dim uFil As SIS.xDMS.xDmsFiles = xDmsFilesGetByID(FileID)
      With uFil
        .StatusBy = HttpContext.Current.Session("LoginID")
        .StatusOn = Now
        .StatusID = enumStatus.CheckedOut
        .Selected = False
        .StatusRemarks = "Checked Out"
      End With
      uFil = SIS.xDMS.xDmsFiles.UpdateData(uFil)
      'Fetch all child files and update
      Dim Results As List(Of SIS.xDMS.xDmsFiles) = SIS.xDMS.xDmsFiles.UZ_xDmsRefFilesSelectList(0, 9999, "", FileID)
      For Each xF As SIS.xDMS.xDmsFiles In Results
        With xF
          .StatusBy = uFil.StatusBy
          .StatusOn = uFil.StatusOn
          .StatusID = uFil.StatusID
          .Selected = False
          .StatusRemarks = uFil.StatusRemarks
        End With
        SIS.xDMS.xDmsFiles.UpdateData(xF)
      Next
      'Insert in History on every update
      '========================
      SIS.xDMS.xDmsHFiles.CreateHistory(uFil.FileID, "Checked Out", True)
      '==========================
      Return uFil
    End Function
    Public Shared Function ReturnWF(ByVal FileID As Int32, Optional FromApproval As Boolean = False, Optional UserRemarks As String = "") As SIS.xDMS.xDmsFiles
      Dim uUsr As String = HttpContext.Current.Session("LoginID")
      Dim uFil As SIS.xDMS.xDmsFiles = xDmsFilesGetByID(FileID)
      If uFil.WorkflowNextStepID <> "" Then
        Dim wf As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(uFil.WorkflowNextStepID)
        uFil.StatusID = wf.ReturnStatusID
      Else
        If uFil.WorkflowID <> "" Then
          Dim wf As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(uFil.WorkflowID)
          If wf.ReturnStatusID <> "" Then
            uFil.StatusID = wf.ReturnStatusID
          Else
            uFil.StatusID = wf.InitialStatusID
          End If
        Else
          uFil.StatusID = enumStatus.Free
          If uFil.FK_xDMS_Files_FolderID.UploadedStatusID <> "" Then
            uFil.StatusID = uFil.FK_xDMS_Files_FolderID.UploadedStatusID
          End If
        End If
      End If
      uFil.WorkflowID = ""
      uFil.WorkflowNextStepID = ""
      uFil.WorkflowStepID = ""
      With uFil
        .StatusBy = HttpContext.Current.Session("LoginID")
        .StatusOn = Now
        .Selected = False
        .UserID = ""
        .GroupID = ""
        .StatusRemarks = "Returned"
        .UserRemarks = UserRemarks
      End With
      uFil = SIS.xDMS.xDmsFiles.UpdateData(uFil)
      'Fetch all child files and update
      Dim Results As List(Of SIS.xDMS.xDmsFiles) = SIS.xDMS.xDmsFiles.UZ_xDmsRefFilesSelectList(0, 9999, "", FileID)
      For Each xF As SIS.xDMS.xDmsFiles In Results
        With xF
          .StatusBy = uFil.StatusBy
          .StatusOn = uFil.StatusOn
          .StatusID = uFil.StatusID
          .Selected = False
          .StatusRemarks = uFil.StatusRemarks
          .UserID = uFil.UserID
          .GroupID = uFil.GroupID
          .WorkflowID = uFil.WorkflowID
          .WorkflowNextStepID = uFil.WorkflowNextStepID
          .WorkflowStepID = uFil.WorkflowStepID
          .UserRemarks = uFil.UserRemarks
        End With
        SIS.xDMS.xDmsFiles.UpdateData(xF)
      Next
      'Insert in History on every update
      '========================
      SIS.xDMS.xDmsHFiles.CreateHistory(uFil.FileID, "Returned", True)
      '==========================
      'Email alert stopped for Migration
      'SIS.xDMS.Alerts.AlertWithoutWF(uFil.FileID)
      Return uFil
    End Function

    Public Shared Function InitiateWF(ByVal FileID As Int32, Optional FromApproval As Boolean = False, Optional UserRemarks As String = "") As SIS.xDMS.xDmsFiles
      Dim uUsr As String = HttpContext.Current.Session("LoginID")
      Dim uFil As SIS.xDMS.xDmsFiles = xDmsFilesGetByID(FileID)
      If Not FromApproval Then
        If Not uFil.InitiateWFVisible Then
          Throw New Exception("File status does not allow to start WF.")
        End If
      End If
      uFil.UserRemarks = UserRemarks
      'Dim uUsrFA As SIS.xDMS.xDmsFolderAuthorizations = SIS.xDMS.xDmsFolderAuthorizations.GetApplicableFA(uFil.FolderID, uUsr)
      Dim uUsrFA As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(uFil.FolderID)
      Select Case uFil.BaseStatus
        Case enumBaseStatus.Free, enumBaseStatus.UIWF 'Execute Initial WF
          '==============================================================
          If uUsrFA.InitialWorkflowID <> "" Then
            Dim tmpWF As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.GetMatchingWFStep(uUsrFA.InitialWorkflowID, uFil.StatusID)
            If tmpWF Is Nothing Then Throw New Exception("Initial Workflow: " & uUsrFA.InitialWorkflowID & " does not have matching file status with start step.")
            uFil = SIS.xDMS.xDmsFiles.UpdateFileStatus(uFil, tmpWF.FinalStatusID, uUsrFA.InitialWorkflowID, tmpWF.WorkflowID, tmpWF.FK_xDMS_Workflows_FinalStatusID.StatusName)
            SIS.xDMS.Alerts.AlertonWFStep(uFil.FileID)
          Else
            'Default Initial
            uFil = SIS.xDMS.xDmsFiles.UpdateFileStatus(uFil, enumStatus.Published, "", "", "Published")
            'SIS.xDMS.Alerts.AlertWithoutWF(uFil.FileID)
          End If
        Case enumBaseStatus.WIP, enumBaseStatus.UREWF 'Execute Release WF
          '==============================================================
          If uUsrFA.UseFileTypeWorkflow Then
            If uFil.FileTypeID <> "" Then
              Dim uFTyp As SIS.xDMS.xDmsFileTypes = uFil.FK_xDMS_Files_FileTypeID
              If uFTyp.BasedOnFileExtension Then
                'New Table, Class, Form has to write
                'Get WF from Extension table
              Else
                If uFTyp.ReleaseWorkflowID <> "" Then
                  Dim tmpWF As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.GetMatchingWFStep(uFTyp.ReleaseWorkflowID, uFil.StatusID)
                  If tmpWF Is Nothing Then Throw New Exception("File Type Release Workflow: " & uUsrFA.ReleaseWorkflowID & " does not have matching file status with start step.")
                  uFil = SIS.xDMS.xDmsFiles.UpdateFileStatus(uFil, tmpWF.FinalStatusID, uUsrFA.InitialWorkflowID, tmpWF.WorkflowID, tmpWF.FK_xDMS_Workflows_FinalStatusID.StatusName)
                  SIS.xDMS.Alerts.AlertonWFStep(uFil.FileID)
                Else
                  'Default Released
                  uFil = SIS.xDMS.xDmsFiles.UpdateFileStatus(uFil, enumStatus.Released, "", "", "Released")
                  'SIS.xDMS.Alerts.AlertWithoutWF(uFil.FileID)
                End If
              End If
            Else
              'Default Released
              uFil = SIS.xDMS.xDmsFiles.UpdateFileStatus(uFil, enumStatus.Released, "", "", "Released")
              'SIS.xDMS.Alerts.AlertWithoutWF(uFil.FileID)
            End If
          Else
            If uUsrFA.ReleaseWorkflowID <> "" Then
              Dim tmpWF As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.GetMatchingWFStep(uUsrFA.ReleaseWorkflowID, uFil.StatusID)
              If tmpWF Is Nothing Then Throw New Exception("Release Workflow: " & uUsrFA.ReleaseWorkflowID & " does not have matching file status with start step.")
              uFil = SIS.xDMS.xDmsFiles.UpdateFileStatus(uFil, tmpWF.FinalStatusID, uUsrFA.ReleaseWorkflowID, tmpWF.WorkflowID, tmpWF.FK_xDMS_Workflows_FinalStatusID.StatusName)
              SIS.xDMS.Alerts.AlertonWFStep(uFil.FileID)
            Else
              'Default Released
              uFil = SIS.xDMS.xDmsFiles.UpdateFileStatus(uFil, enumStatus.Released, "", "", "Released")
              'SIS.xDMS.Alerts.AlertWithoutWF(uFil.FileID)
            End If
          End If
        Case enumBaseStatus.Released, enumBaseStatus.URVWF 'Execute Revise WF
          'in revise create new revision files
          'With Initial Folder Status
          'Default System Remarks will be REVISED and Superseded
      End Select
      Return uFil
    End Function
    Public Shared Function UpdateFileStatus(uFil As SIS.xDMS.xDmsFiles, sts As enumStatus, WorkflowID As String, WorkflowStepID As String, Remarks As String) As SIS.xDMS.xDmsFiles
      Dim tmpWF As SIS.xDMS.xDmsWorkflows = Nothing
      If WorkflowID <> "" Then
        tmpWF = SIS.xDMS.xDmsWorkflows.GetMatchingWFStep(WorkflowID, sts)
      End If
      With uFil
        .StatusBy = HttpContext.Current.Session("LoginID")
        .StatusOn = Now
        .StatusID = sts
        .Selected = False
        .WorkflowID = WorkflowID
        .WorkflowStepID = WorkflowStepID
        If tmpWF IsNot Nothing Then
          .WorkflowNextStepID = tmpWF.WorkflowID
          .UserID = tmpWF.UserID
          .GroupID = tmpWF.GroupID
        End If
      End With
      uFil = SIS.xDMS.xDmsFiles.UpdateData(uFil)
      'Fetch all child files and update
      Dim Results As List(Of SIS.xDMS.xDmsFiles) = SIS.xDMS.xDmsFiles.UZ_xDmsRefFilesSelectList(0, 9999, "", uFil.FileID)
      For Each xF As SIS.xDMS.xDmsFiles In Results
        With xF
          .StatusBy = uFil.StatusBy
          .StatusOn = uFil.StatusOn
          .StatusID = uFil.StatusID
          .Selected = False
          .StatusRemarks = uFil.StatusRemarks
          .UserID = uFil.UserID
          .GroupID = uFil.GroupID
          .WorkflowID = uFil.WorkflowID
          .WorkflowNextStepID = uFil.WorkflowNextStepID
          .WorkflowStepID = uFil.WorkflowStepID
          .UserRemarks = uFil.UserRemarks
        End With
        SIS.xDMS.xDmsFiles.UpdateData(xF)
      Next
      'Insert in History on every update
      '========================
      SIS.xDMS.xDmsHFiles.CreateHistory(uFil.FileID, Remarks, True)
      '==========================
      Return uFil
    End Function
    Public Shared Function DeleteWF(ByVal FileID As Int32) As SIS.xDMS.xDmsFiles
      Dim xUser As SIS.xDMS.xDmsUsers = SIS.xDMS.xDmsUsers.xDmsUsersGetByID(HttpContext.Current.Session("LoginID"))
      Dim uFil As SIS.xDMS.xDmsFiles = xDmsFilesGetByID(FileID)
      If uFil.DeleteWFVisible Then
        Dim cuFils As List(Of SIS.xDMS.xDmsFiles) = SIS.xDMS.xDmsFiles.UZ_xDmsRefFilesSelectList(0, 9999, "", uFil.FileID)
        For Each cuf As SIS.xDMS.xDmsFiles In cuFils
          SIS.xDMS.xDmsFiles.xDmsFilesDelete(cuf)
          If Not VaultDRIDExists(cuf.VaultDRID) Then ejiVault.EJI.ediAFile.FileDelete(cuf.VaultDRID)
        Next
        SIS.xDMS.xDmsFiles.xDmsFilesDelete(uFil)
        If Not VaultDRIDExists(uFil.VaultDRID) Then ejiVault.EJI.ediAFile.FileDelete(uFil.VaultDRID)
      End If
      Return uFil
    End Function
    Public Shared Function GetVaultDRIDs(FileIDs As String) As List(Of SIS.DMS.vaultFile)
      If FileIDs.StartsWith(",") Then FileIDs = FileIDs.Substring(1)
      Dim mRet As New List(Of SIS.DMS.vaultFile)
      Dim Sql As String = ""
      Sql &= "  Select FileID, VaultDRID From xDMS_Files "
      Sql &= "  Where  FileID in (" & FileIDs & ") and VaultDRID is not NULL"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While rd.Read
            Dim x As New SIS.DMS.vaultFile
            x.FileID = rd("FileID")
            x.DRID = rd("VaultDRID")
            mRet.Add(x)
          End While
          rd.Close()
        End Using
      End Using
      Return mRet
    End Function

    Public Shared Function UZ_xDmsFilesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FolderID As Int32) As List(Of SIS.xDMS.xDmsFiles)
      Dim xUser As SIS.xDMS.xDmsUsers = SIS.xDMS.xDmsUsers.xDmsUsersGetByID(HttpContext.Current.Session("LoginID"))
      Dim Results As List(Of SIS.xDMS.xDmsFiles) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FileID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxdms_LG_FilesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxdms_LG_FilesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FolderID", SqlDbType.Int, 10, IIf(FolderID = Nothing, 0, FolderID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFiles)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim x As New SIS.xDMS.xDmsFiles(Reader)
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
    Public Shared Function xDmsFilesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FolderID As Int32) As Integer
      Return _RecordCount
    End Function
    Public Shared Function UZ_xDmsFilesInsert(ByVal Record As SIS.xDMS.xDmsFiles) As SIS.xDMS.xDmsFiles
      Dim _Result As SIS.xDMS.xDmsFiles = xDmsFilesInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFilesUpdate(ByVal Record As SIS.xDMS.xDmsFiles) As SIS.xDMS.xDmsFiles
      Dim _Result As SIS.xDMS.xDmsFiles = xDmsFilesUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFilesDelete(ByVal Record As SIS.xDMS.xDmsFiles) As Integer
      Dim _Result As Integer = xDmsFilesDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_FileID"), TextBox).Text = ""
          CType(.FindControl("F_FileName"), TextBox).Text = ""
          CType(.FindControl("F_FileRev"), TextBox).Text = ""
          CType(.FindControl("F_ItemTypeID"), Object).SelectedValue = ""
          CType(.FindControl("F_FolderID"), TextBox).Text = ""
          CType(.FindControl("F_FolderID_Display"), Label).Text = ""
          CType(.FindControl("F_VaultDRID"), TextBox).Text = ""
          CType(.FindControl("F_FileExtn"), TextBox).Text = ""
          CType(.FindControl("F_FileSize"), TextBox).Text = 0
          CType(.FindControl("F_StatusID"), TextBox).Text = ""
          CType(.FindControl("F_StatusID_Display"), Label).Text = ""
          CType(.FindControl("F_Active"), CheckBox).Checked = False
          CType(.FindControl("F_Hseq"), TextBox).Text = 0
          CType(.FindControl("F_NodeLevel"), TextBox).Text = 0
          CType(.FindControl("F_ParentIFileID"), TextBox).Text = ""
          CType(.FindControl("F_ParentIFileID_Display"), Label).Text = ""
          CType(.FindControl("F_StatusOn"), TextBox).Text = ""
          CType(.FindControl("F_StatusBy"), TextBox).Text = ""
          CType(.FindControl("F_StatusBy_Display"), Label).Text = ""
          CType(.FindControl("F_KeyWords"), TextBox).Text = ""
          CType(.FindControl("F_StatusRemarks"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function UnderApprovalSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FileID As Int32, ByVal FolderID As Int32, ByVal StatusID As Int32, ByVal ParentIFileID As Int32, ByVal StatusBy As String) As List(Of SIS.xDMS.xDmsFiles)
      Dim Results As List(Of SIS.xDMS.xDmsFiles) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FileID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDms_LG_UnderApprovalSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDms_LG_UnderApprovalFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FileID", SqlDbType.Int, 10, IIf(FileID = Nothing, 0, FileID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FolderID", SqlDbType.Int, 10, IIf(FolderID = Nothing, 0, FolderID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID", SqlDbType.Int, 10, IIf(StatusID = Nothing, 0, StatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ParentIFileID", SqlDbType.Int, 10, IIf(ParentIFileID = Nothing, 0, ParentIFileID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusBy", SqlDbType.NVarChar, 8, IIf(StatusBy Is Nothing, String.Empty, StatusBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFiles)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFiles(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_xDmsRefFilesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal ParentIFileID As Int32) As List(Of SIS.xDMS.xDmsFiles)
      If ParentIFileID = 0 Then Return Nothing
      Dim xUser As SIS.xDMS.xDmsUsers = SIS.xDMS.xDmsUsers.xDmsUsersGetByID(HttpContext.Current.Session("LoginID"))
      Dim Results As List(Of SIS.xDMS.xDmsFiles) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FileID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxdms_LG_RefFilesSelectListFilteres"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ParentIFileID", SqlDbType.Int, 10, IIf(ParentIFileID = Nothing, 0, ParentIFileID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFiles)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Dim x As New SIS.xDMS.xDmsFiles(Reader)
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
    Public Shared Function xDmsRefFilesSelectCount(ByVal ParentIFileID As Int32) As Integer
      Return _RecordCount
    End Function
    Public Shared Function RefDeleteWF(ByVal FileID As Int32) As SIS.xDMS.xDmsFiles
      Dim uFil As SIS.xDMS.xDmsFiles = xDmsFilesGetByID(FileID)
      'History must be deleted first
      SIS.xDMS.xDmsHFiles.DeleteChildHistory(FileID)
      SIS.xDMS.xDmsFiles.xDmsFilesDelete(uFil)
      If Not VaultDRIDExists(uFil.VaultDRID) Then ejiVault.EJI.ediAFile.FileDelete(uFil.VaultDRID)
      Return uFil
    End Function
    Public Shared Function VaultDRIDExists(VaultDRID As String) As Boolean
      Dim mCnt As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = " select isnull(count(VaultDRID),0) from xDms_Files where VaultDRID='" & VaultDRID & "'"
          mCnt += Cmd.ExecuteScalar
        End Using
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = " select isnull(count(VaultDRID),0) from xDms_HFiles where VaultDRID='" & VaultDRID & "'"
          mCnt += Cmd.ExecuteScalar
        End Using
      End Using
      Return (mCnt > 0)
    End Function
    Public Shared Function GetFileForHistory(FileID As Integer) As SIS.xDMS.xDmsHFiles
      Dim Results As New SIS.xDMS.xDmsHFiles
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = " select * from xDms_Files where FileID=" & FileID
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsHFiles(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetChildFilesForHistory(FileID As Integer) As List(Of SIS.xDMS.xDmsHFiles)
      Dim Results As New List(Of SIS.xDMS.xDmsHFiles)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Con.Open()
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = " select * from xDms_Files where ParentIFileID=" & FileID
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While Reader.Read()
            Results.Add(New SIS.xDMS.xDmsHFiles(Reader))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetByFilename(FileName As String) As SIS.xDMS.xDmsFiles
      Dim Results As SIS.xDMS.xDmsFiles = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select top 1 * from xdms_files where lower(filename)='" & FileName.ToLower & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results = New SIS.xDMS.xDmsFiles(Reader)
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function GetByFilename(FileName As String, ParentFileID As Integer) As SIS.xDMS.xDmsFiles
      Dim Results As SIS.xDMS.xDmsFiles = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select top 1 * from xdms_files where lower(filename)='" & FileName.ToLower & "' and ParentIFileID=" & ParentFileID
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results = New SIS.xDMS.xDmsFiles(Reader)
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Shared Function GetVaultFile(FileName As String, dcid As String, indx As String) As EJI.ediAFile
      'For Migration
      Dim Results As EJI.ediAFile = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = "select top 1 * from ttcisg132200 where t_hndl='TRANSMITTALLINES_200' and lower(t_fnam)='" & FileName.ToLower & "' and t_indx='" & indx & "' and t_dcid='" & dcid & "'"
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results = New EJI.ediAFile(Reader)
          End While
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
  End Class
  Public Class FileDetails
    Public Property FileID As String = ""
    Public Property FileName As String = ""
    Public Property FileSize As String = ""
    Public Property BaseStatus As enumBaseStatus

    Public Property cFiles As New List(Of SIS.xDMS.cFileDetails)
    Public Shared Function GetFileDetails(FileID As Integer) As SIS.xDMS.FileDetails
      Dim mRet As New FileDetails
      Dim f As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(FileID)
      With mRet
        .FileID = f.FileID
        .FileName = f.FileName
        .FileSize = f.FileSize
        .BaseStatus = f.BaseStatus
      End With
      Dim cfs As List(Of SIS.xDMS.xDmsFiles) = SIS.xDMS.xDmsFiles.UZ_xDmsRefFilesSelectList(0, 9999, "", FileID)
      For Each cf As SIS.xDMS.xDmsFiles In cfs
        Dim x As New cFileDetails
        With x
          .FileID = cf.FileID
          .FileName = cf.FileName
          .FileSize = cf.FileSize
        End With
        mRet.cFiles.Add(x)
      Next
      Return mRet
    End Function
  End Class
  Public Class cFileDetails
    Public Property FileID As String = ""
    Public Property FileName As String = ""
    Public Property FileSize As String = ""

  End Class
End Namespace
