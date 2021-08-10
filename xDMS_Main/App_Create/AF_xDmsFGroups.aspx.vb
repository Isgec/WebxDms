Partial Class AF_xDmsFGroups
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsFGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFGroups.Init
    DataClassName = "AxDmsFGroups"
    SetFormView = FVxDmsFGroups
  End Sub
  Protected Sub TBLxDmsFGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFGroups.Init
    SetToolBar = TBLxDmsFGroups
  End Sub
  Protected Sub ODSxDmsFGroups_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsFGroups.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.xDMS.xDmsFGroups = CType(e.ReturnValue,SIS.xDMS.xDmsFGroups)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&FGroupID=" & oDC.FGroupID
      TBLxDmsFGroups.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVxDmsFGroups_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFGroups.DataBound
    SIS.xDMS.xDmsFGroups.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsFGroups_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFGroups.PreRender
    Dim oF_ReleaseWorkflowID_Display As Label  = FVxDmsFGroups.FindControl("F_ReleaseWorkflowID_Display")
    Dim oF_ReleaseWorkflowID As TextBox  = FVxDmsFGroups.FindControl("F_ReleaseWorkflowID")
    Dim oF_ReviseWorkflowID_Display As Label  = FVxDmsFGroups.FindControl("F_ReviseWorkflowID_Display")
    Dim oF_ReviseWorkflowID As TextBox  = FVxDmsFGroups.FindControl("F_ReviseWorkflowID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsFGroups.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsFGroups") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsFGroups", mStr)
    End If
    If Request.QueryString("FGroupID") IsNot Nothing Then
      CType(FVxDmsFGroups.FindControl("F_FGroupID"), TextBox).Text = Request.QueryString("FGroupID")
      CType(FVxDmsFGroups.FindControl("F_FGroupID"), TextBox).Enabled = False
    End If
  End Sub
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
  Public Shared Function validate_FK_xDMS_FGroups_ReleaseWorkflowID(ByVal value As String) As String
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
  Public Shared Function validate_FK_xDMS_FGroups_ReviseWorkflowID(ByVal value As String) As String
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
