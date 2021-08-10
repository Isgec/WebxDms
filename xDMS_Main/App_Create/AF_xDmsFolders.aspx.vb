Partial Class AF_xDmsFolders
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFolders.Init
    DataClassName = "AxDmsFolders"
    SetFormView = FVxDmsFolders
  End Sub
  Protected Sub TBLxDmsFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFolders.Init
    SetToolBar = TBLxDmsFolders
  End Sub
  Protected Sub FVxDmsFolders_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFolders.DataBound
    SIS.xDMS.xDmsFolders.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsFolders_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFolders.PreRender
    Dim oF_ParentFolderID_Display As Label  = FVxDmsFolders.FindControl("F_ParentFolderID_Display")
    oF_ParentFolderID_Display.Text = String.Empty
    If Not Session("F_ParentFolderID_Display") Is Nothing Then
      If Session("F_ParentFolderID_Display") <> String.Empty Then
        oF_ParentFolderID_Display.Text = Session("F_ParentFolderID_Display")
      End If
    End If
    Dim oF_ParentFolderID As TextBox  = FVxDmsFolders.FindControl("F_ParentFolderID")
    oF_ParentFolderID.Enabled = True
    oF_ParentFolderID.Text = String.Empty
    If Not Session("F_ParentFolderID") Is Nothing Then
      If Session("F_ParentFolderID") <> String.Empty Then
        oF_ParentFolderID.Text = Session("F_ParentFolderID")
      End If
    End If
    Dim oF_StatusBy_Display As Label  = FVxDmsFolders.FindControl("F_StatusBy_Display")
    oF_StatusBy_Display.Text = String.Empty
    If Not Session("F_StatusBy_Display") Is Nothing Then
      If Session("F_StatusBy_Display") <> String.Empty Then
        oF_StatusBy_Display.Text = Session("F_StatusBy_Display")
      End If
    End If
    Dim oF_StatusBy As TextBox  = FVxDmsFolders.FindControl("F_StatusBy")
    oF_StatusBy.Enabled = True
    oF_StatusBy.Text = String.Empty
    If Not Session("F_StatusBy") Is Nothing Then
      If Session("F_StatusBy") <> String.Empty Then
        oF_StatusBy.Text = Session("F_StatusBy")
      End If
    End If
    Dim oF_StatusID_Display As Label  = FVxDmsFolders.FindControl("F_StatusID_Display")
    Dim oF_StatusID As TextBox  = FVxDmsFolders.FindControl("F_StatusID")
    Dim oF_ReleaseWorkflowID_Display As Label  = FVxDmsFolders.FindControl("F_ReleaseWorkflowID_Display")
    Dim oF_ReleaseWorkflowID As TextBox  = FVxDmsFolders.FindControl("F_ReleaseWorkflowID")
    Dim oF_ReviseWorkflowID_Display As Label  = FVxDmsFolders.FindControl("F_ReviseWorkflowID_Display")
    Dim oF_ReviseWorkflowID As TextBox  = FVxDmsFolders.FindControl("F_ReviseWorkflowID")
    Dim oF_InitialWorkflowID_Display As Label  = FVxDmsFolders.FindControl("F_InitialWorkflowID_Display")
    Dim oF_InitialWorkflowID As TextBox  = FVxDmsFolders.FindControl("F_InitialWorkflowID")
    Dim oF_UploadedStatusID_Display As Label  = FVxDmsFolders.FindControl("F_UploadedStatusID_Display")
    Dim oF_UploadedStatusID As TextBox  = FVxDmsFolders.FindControl("F_UploadedStatusID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsFolders.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsFolders") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsFolders", mStr)
    End If
    If Request.QueryString("FolderID") IsNot Nothing Then
      CType(FVxDmsFolders.FindControl("F_FolderID"), TextBox).Text = Request.QueryString("FolderID")
      CType(FVxDmsFolders.FindControl("F_FolderID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ParentFolderIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFolders.SelectxDmsFoldersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function StatusByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function StatusIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsStates.SelectxDmsStatesAutoCompleteList(prefixText, count, contextKey)
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
  Public Shared Function validate_FK_xDMS_Folders_StatusBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim StatusBy As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(StatusBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_Folders_ParentFolderID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ParentFolderID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(ParentFolderID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_Folders_StatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim StatusID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsStates = SIS.xDMS.xDmsStates.xDmsStatesGetByID(StatusID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_Folders_ReleaseWorkflowID(ByVal value As String) As String
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
  Public Shared Function validate_FK_xDMS_Folders_ReviseWorkflowID(ByVal value As String) As String
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
  Public Shared Function validate_FK_xDMS_Folders_UploadedStatusID(ByVal value As String) As String
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
  Public Shared Function validate_FK_xDMS_Folders_InitialWorkflowID(ByVal value As String) As String
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
