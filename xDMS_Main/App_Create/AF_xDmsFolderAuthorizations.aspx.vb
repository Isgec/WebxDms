Partial Class AF_xDmsFolderAuthorizations
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsFolderAuthorizations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFolderAuthorizations.Init
    DataClassName = "AxDmsFolderAuthorizations"
    SetFormView = FVxDmsFolderAuthorizations
  End Sub
  Protected Sub TBLxDmsFolderAuthorizations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFolderAuthorizations.Init
    SetToolBar = TBLxDmsFolderAuthorizations
  End Sub
  Protected Sub FVxDmsFolderAuthorizations_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFolderAuthorizations.DataBound
    SIS.xDMS.xDmsFolderAuthorizations.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsFolderAuthorizations_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFolderAuthorizations.PreRender
    Dim oF_UserID_Display As Label  = FVxDmsFolderAuthorizations.FindControl("F_UserID_Display")
    oF_UserID_Display.Text = String.Empty
    If Not Session("F_UserID_Display") Is Nothing Then
      If Session("F_UserID_Display") <> String.Empty Then
        oF_UserID_Display.Text = Session("F_UserID_Display")
      End If
    End If
    Dim oF_UserID As TextBox  = FVxDmsFolderAuthorizations.FindControl("F_UserID")
    oF_UserID.Enabled = True
    oF_UserID.Text = String.Empty
    If Not Session("F_UserID") Is Nothing Then
      If Session("F_UserID") <> String.Empty Then
        oF_UserID.Text = Session("F_UserID")
      End If
    End If
    Dim oF_FolderID_Display As Label  = FVxDmsFolderAuthorizations.FindControl("F_FolderID_Display")
    oF_FolderID_Display.Text = String.Empty
    If Not Session("F_FolderID_Display") Is Nothing Then
      If Session("F_FolderID_Display") <> String.Empty Then
        oF_FolderID_Display.Text = Session("F_FolderID_Display")
      End If
    End If
    Dim oF_FolderID As TextBox  = FVxDmsFolderAuthorizations.FindControl("F_FolderID")
    oF_FolderID.Enabled = True
    oF_FolderID.Text = String.Empty
    If Not Session("F_FolderID") Is Nothing Then
      If Session("F_FolderID") <> String.Empty Then
        oF_FolderID.Text = Session("F_FolderID")
      End If
    End If
    Dim oF_ReleaseWorkflowID_Display As Label  = FVxDmsFolderAuthorizations.FindControl("F_ReleaseWorkflowID_Display")
    Dim oF_ReleaseWorkflowID As TextBox  = FVxDmsFolderAuthorizations.FindControl("F_ReleaseWorkflowID")
    Dim oF_ReviseWorkflowID_Display As Label  = FVxDmsFolderAuthorizations.FindControl("F_ReviseWorkflowID_Display")
    Dim oF_ReviseWorkflowID As TextBox  = FVxDmsFolderAuthorizations.FindControl("F_ReviseWorkflowID")
    Dim oF_InitialWorkflowID_Display As Label  = FVxDmsFolderAuthorizations.FindControl("F_InitialWorkflowID_Display")
    Dim oF_InitialWorkflowID As TextBox  = FVxDmsFolderAuthorizations.FindControl("F_InitialWorkflowID")
    Dim oF_UploadedStatusID_Display As Label  = FVxDmsFolderAuthorizations.FindControl("F_UploadedStatusID_Display")
    Dim oF_UploadedStatusID As TextBox  = FVxDmsFolderAuthorizations.FindControl("F_UploadedStatusID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsFolderAuthorizations.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsFolderAuthorizations") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsFolderAuthorizations", mStr)
    End If
    If Request.QueryString("UserID") IsNot Nothing Then
      CType(FVxDmsFolderAuthorizations.FindControl("F_UserID"), TextBox).Text = Request.QueryString("UserID")
      CType(FVxDmsFolderAuthorizations.FindControl("F_UserID"), TextBox).Enabled = False
    End If
    If Request.QueryString("FolderID") IsNot Nothing Then
      CType(FVxDmsFolderAuthorizations.FindControl("F_FolderID"), TextBox).Text = Request.QueryString("FolderID")
      CType(FVxDmsFolderAuthorizations.FindControl("F_FolderID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function FolderIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFolders.SelectxDmsFoldersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ReleaseWorkflowIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ReviseWorkflowIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function InitialWorkflowIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UploadedStatusIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsStates.SelectxDmsStatesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_FolderAuthorizations_UserID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim UserID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(UserID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_FolderAuthorizations_FolderID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim FolderID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(FolderID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_FolderAuthorizations_ReleaseWorkflowID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ReleaseWorkflowID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(ReleaseWorkflowID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_FolderAuthorizations_ReviseWorkflowID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ReviseWorkflowID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(ReviseWorkflowID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_FolderAuthorizations_UploadedStatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim UploadedStatusID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsStates = SIS.xDMS.xDmsStates.xDmsStatesGetByID(UploadedStatusID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_FolderAuthorizations_InitialWorkflowID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim InitialWorkflowID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(InitialWorkflowID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
