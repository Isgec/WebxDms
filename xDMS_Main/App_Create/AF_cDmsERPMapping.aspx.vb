Partial Class AF_cDmsERPMapping
  Inherits SIS.SYS.InsertBase
  Protected Sub FVcDmsERPMapping_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcDmsERPMapping.Init
    DataClassName = "AcDmsERPMapping"
    SetFormView = FVcDmsERPMapping
  End Sub
  Protected Sub TBLcDmsERPMapping_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcDmsERPMapping.Init
    SetToolBar = TBLcDmsERPMapping
  End Sub
  Protected Sub FVcDmsERPMapping_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVcDmsERPMapping.PreRender
    Dim oF_ParentFolderID_Display As Label = FVcDmsERPMapping.FindControl("F_ParentFolderID_Display")
    Dim oF_ParentFolderID As TextBox = FVcDmsERPMapping.FindControl("F_ParentFolderID")
    Dim oF_InitialWorkflowID_Display As Label = FVcDmsERPMapping.FindControl("F_InitialWorkflowID_Display")
    Dim oF_InitialWorkflowID As TextBox = FVcDmsERPMapping.FindControl("F_InitialWorkflowID")
    Dim oF_ReleaseWorkflowID_Display As Label = FVcDmsERPMapping.FindControl("F_ReleaseWorkflowID_Display")
    Dim oF_ReleaseWorkflowID As TextBox = FVcDmsERPMapping.FindControl("F_ReleaseWorkflowID")
    Dim oF_ReviseWorkflowID_Display As Label = FVcDmsERPMapping.FindControl("F_ReviseWorkflowID_Display")
    Dim oF_ReviseWorkflowID As TextBox = FVcDmsERPMapping.FindControl("F_ReviseWorkflowID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_cDmsERPMapping.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptcDmsERPMapping") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptcDmsERPMapping", mStr)
    End If
    If Request.QueryString("SerialNo") IsNot Nothing Then
      CType(FVcDmsERPMapping.FindControl("F_SerialNo"), TextBox).Text = Request.QueryString("SerialNo")
      CType(FVcDmsERPMapping.FindControl("F_SerialNo"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ParentFolderIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFolders.SelectxDmsFoldersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function InitialWorkflowIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
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
  Public Shared Function validate_FK_xDMS_ERPMapping_ParentFolderID(ByVal value As String) As String
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
  Public Shared Function validate_FK_xDMS_ERPMapping_InitialWorkflowID(ByVal value As String) As String
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_ERPMapping_ReleaseWorkflowID(ByVal value As String) As String
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
  Public Shared Function validate_FK_xDMS_ERPMapping_ReviseWorkflowID(ByVal value As String) As String
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

End Class
