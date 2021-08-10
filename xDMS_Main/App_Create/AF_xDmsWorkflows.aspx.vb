Partial Class AF_xDmsWorkflows
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsWorkflows_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsWorkflows.Init
    DataClassName = "AxDmsWorkflows"
    SetFormView = FVxDmsWorkflows
  End Sub
  Protected Sub TBLxDmsWorkflows_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsWorkflows.Init
    SetToolBar = TBLxDmsWorkflows
  End Sub
  Protected Sub FVxDmsWorkflows_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsWorkflows.DataBound
    SIS.xDMS.xDmsWorkflows.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsWorkflows_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsWorkflows.PreRender
    Dim oF_ParentWorkflowID_Display As Label  = FVxDmsWorkflows.FindControl("F_ParentWorkflowID_Display")
    Dim oF_ParentWorkflowID As TextBox  = FVxDmsWorkflows.FindControl("F_ParentWorkflowID")
    Dim oF_UserID_Display As Label  = FVxDmsWorkflows.FindControl("F_UserID_Display")
    Dim oF_UserID As TextBox  = FVxDmsWorkflows.FindControl("F_UserID")
    Dim oF_GroupID_Display As Label  = FVxDmsWorkflows.FindControl("F_GroupID_Display")
    Dim oF_GroupID As TextBox  = FVxDmsWorkflows.FindControl("F_GroupID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsWorkflows.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsWorkflows") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsWorkflows", mStr)
    End If
    If Request.QueryString("WorkflowID") IsNot Nothing Then
      CType(FVxDmsWorkflows.FindControl("F_WorkflowID"), TextBox).Text = Request.QueryString("WorkflowID")
      CType(FVxDmsWorkflows.FindControl("F_WorkflowID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ParentWorkflowIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function GroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsUGroups.SelectxDmsUGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_Workflows_UserID(ByVal value As String) As String
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
  Public Shared Function validate_FK_xDMS_Workflows_GroupID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim GroupID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsUGroups = SIS.xDMS.xDmsUGroups.xDmsUGroupsGetByID(GroupID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_Workflows_ParentWorkflowID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ParentWorkflowID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(ParentWorkflowID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
