Imports System.Web.Script.Serialization
Partial Class AF_CFoldersAdmin
  Inherits SIS.SYS.ctlInsertBase
  Public Property Key As String
    Get
      If ViewState("key") IsNot Nothing Then
        Return ViewState("key")
      End If
      Return "c_-1"
    End Get
    Set(value As String)
      ViewState.Add("key", value)
    End Set
  End Property
  Public Property cmd As String
    Get
      If ViewState("cmd") IsNot Nothing Then
        Return ViewState("cmd")
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("cmd", value)
    End Set
  End Property
  Private Sub FVxDmsFolders_Load(sender As Object, e As EventArgs) Handles FVxDmsFolders.Load
    If Request.QueryString("key") IsNot Nothing Then
      Key = Request.QueryString("key")
    End If
    If Request.QueryString("cmd") IsNot Nothing Then
      cmd = Request.QueryString("cmd")
    End If
  End Sub
  Private Sub ODSxDmsFolders_Inserting(sender As Object, e As ObjectDataSourceMethodEventArgs) Handles ODSxDmsFolders.Inserting
    If HttpContext.Current.Session("LoginID") Is Nothing Then
      Dim re As String = New JavaScriptSerializer().Serialize(New With {
         .err = True,
         .msg = "Session Expired, Login again."
     })
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "parent.closeIframe('" & re & "');", True)
      e.Cancel = True
      Exit Sub
    End If
    Dim ParentFolderID As String = CType(Key.Split("_".ToCharArray)(1), String)
    If ParentFolderID = "-1" Then
      Dim re As String = New JavaScriptSerializer().Serialize(New With {
         .err = True,
         .msg = "Invalid Parent Folder ID, refresh page or Login again."
     })
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "parent.closeIframe('" & re & "');", True)
      e.Cancel = True
      Exit Sub
    End If
    If ParentFolderID = "0" Then ParentFolderID = ""
    Try
      Dim x As SIS.xDMS.xDmsFolders = CType(e.InputParameters.Values(0), SIS.xDMS.xDmsFolders)
      x.StatusID = enumStatus.Free
      x.ParentFolderID = ParentFolderID
      x.StatusOn = Now.ToString("dd/MM/yyyy")
      x.StatusBy = HttpContext.Current.Session("LoginID")
      x.StatusRemarks = "Created By Admin"
      x.Active = True
      x.Hseq = 0
      x.NodeLevel = 1
      If ParentFolderID <> "" Then
        Dim oJ As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.UZ_xDmsFoldersGetByID(ParentFolderID)
        If oJ IsNot Nothing Then
          x.NodeLevel = oJ.NodeLevel + 1
        End If
      End If
      x = SIS.xDMS.xDmsFolders.InsertData(x)
      If ParentFolderID = "" Then
        'Root folder authorization
        Dim xUser As SIS.xDMS.xDmsUsers = SIS.xDMS.xDmsUsers.xDmsUsersGetByID(HttpContext.Current.Session("LoginID"))
        Dim usrFld As New SIS.xDMS.xDmsFolderAuthorizations
        With usrFld
          .UserID = xUser.UserID
          .FolderID = x.FolderID
          .CreateFolder = True
          .UpdateFolder = True
          .DeleteFolder = True
          .UploadFile = True
          .DownloadFile = True
          .DeleteFile = True
          .CanAuthorizeFolder = xUser.CanAuthorizeFolder
          .CanPassAuthorization = xUser.CanPassAuthorization
          .CanViewAllRevisions = xUser.CanViewAllRevisions
          .IsAdmin = xUser.IsAdmin
          .CreatedBy = xUser.UserID
          .CreatedOn = Now
          .UploadedStatusID = x.UploadedStatusID
          .InitialWorkflowID = x.InitialWorkflowID
          .ReleaseWorkflowID = x.ReleaseWorkflowID
          .ReviseWorkflowID = x.ReviseWorkflowID
          .UseFileTypeWorkflow = x.UseFileTypeWorkflow
          .DuplicateFileNameAllowed = x.DuplicateFileNameAllowed
          .RequireExplicitAuthorization = x.RequireExplicitAuthorization
          .RequireExplicitWorkflow = x.RequireExplicitWorkflow
        End With
        usrFld = SIS.xDMS.xDmsFolderAuthorizations.InsertData(usrFld)
      End If
      Dim re As New resp
      re.key = Key
      re.cmd = cmd
      re.ifrm = False
      re.load = True
      re.wrn = True
      re.wmsg = "Folder Created"
      Dim str As String = New JavaScriptSerializer().Serialize(re)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "parent.closeIframe('" & str & "');", True)
    Catch ex As Exception
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
    End Try
    e.Cancel = True
  End Sub
  Protected Sub FVxDmsFolders_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFolders.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsFolders.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsFolders") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsFolders", mStr)
    End If
    CType(FVxDmsFolders.FindControl("F_FolderName"), TextBox).Attributes.Add("onblur", "script_xDmsFolders.validate_FolderName(this,'" & Key & "');")
    Dim ParentFolderID As String = CType(Key.Split("_".ToCharArray)(1), String)
    Dim oJ As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.UZ_xDmsFoldersGetByID(ParentFolderID)
    If oJ IsNot Nothing Then
      CType(FVxDmsFolders.FindControl("F_KeyWords"), TextBox).Text = oJ.KeyWords
      CType(FVxDmsFolders.FindControl("F_ReleaseWorkflowID"), TextBox).Text = oJ.ReleaseWorkflowID
      CType(FVxDmsFolders.FindControl("F_ReleaseWorkflowID_Display"), Label).Text = oJ.xDMS_Workflows5_WorkflowName
      CType(FVxDmsFolders.FindControl("F_ReviseWorkflowID"), TextBox).Text = oJ.ReviseWorkflowID
      CType(FVxDmsFolders.FindControl("F_ReviseWorkflowID_Display"), Label).Text = oJ.xDMS_Workflows6_WorkflowName
      CType(FVxDmsFolders.FindControl("F_InitialWorkflowID"), TextBox).Text = oJ.InitialWorkflowID
      CType(FVxDmsFolders.FindControl("F_InitialWorkflowID_Display"), Label).Text = oJ.xDMS_Workflows8_WorkflowName
      CType(FVxDmsFolders.FindControl("F_UploadedStatusID"), TextBox).Text = oJ.UploadedStatusID
      CType(FVxDmsFolders.FindControl("F_UploadedStatusID_Display"), Label).Text = oJ.xDMS_States7_StatusName
      CType(FVxDmsFolders.FindControl("F_UseFileTypeWorkflow"), CheckBox).Checked = oJ.UseFileTypeWorkflow
      CType(FVxDmsFolders.FindControl("F_RequireExplicitAuthorization"), CheckBox).Checked = False 'Not From Parent oJ.RequireExplicitAuthorization
      CType(FVxDmsFolders.FindControl("F_RequireExplicitWorkflow"), CheckBox).Checked = False 'Not From Parent oJ.RequireExplicitWorkflow
      CType(FVxDmsFolders.FindControl("F_DuplicateFileNameAllowed"), CheckBox).Checked = oJ.DuplicateFileNameAllowed
    End If

  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ReleaseWorkflowIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ReviseWorkflowIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function InitialWorkflowIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function UploadedStatusIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsStates.SelectxDmsStatesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Public Shared Function validate_FK_xDMS_Folders_ParentFolderID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ParentFolderID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(ParentFolderID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_xDMS_Folders_StatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim StatusID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.xDMS.xDmsStates = SIS.xDMS.xDmsStates.xDmsStatesGetByID(StatusID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_xDMS_Folders_ReleaseWorkflowID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ReleaseWorkflowID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(ReleaseWorkflowID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_xDMS_Folders_ReviseWorkflowID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ReviseWorkflowID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(ReviseWorkflowID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_xDMS_Folders_UploadedStatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim UploadedStatusID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.xDMS.xDmsStates = SIS.xDMS.xDmsStates.xDmsStatesGetByID(UploadedStatusID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_xDMS_Folders_InitialWorkflowID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim InitialWorkflowID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(InitialWorkflowID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FolderName(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim FolderName As String = CType(aVal(1), String)
    Dim ParentFolderID As String = CType(aVal(2).Split("_".ToCharArray)(1), String)
    If SIS.xDMS.xDmsFolders.IsFolderExist(ParentFolderID, FolderName) Then
      mRet = "1|" & aVal(0) & "|Folder with this name already exists."
    Else
      'Dim oVar As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.UZ_xDmsFoldersGetByID(ParentFolderID)
      mRet = "0|" & aVal(0) '& "|" & New JavaScriptSerializer().Serialize(oVar)
    End If
    Return mRet
  End Function

End Class
