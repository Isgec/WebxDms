Imports System.Web.Script.Serialization
Partial Class GF_xDmsWorkflows
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/xDMS_Main/App_Display/DF_xDmsWorkflows.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?WorkflowID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVxDmsWorkflows_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsWorkflows.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim WorkflowID As Int32 = GVxDmsWorkflows.DataKeys(e.CommandArgument).Values("WorkflowID")  
        Dim RedirectUrl As String = TBLxDmsWorkflows.EditUrl & "?WorkflowID=" & WorkflowID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVxDmsWorkflows_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsWorkflows.Init
    DataClassName = "GxDmsWorkflows"
    SetGridView = GVxDmsWorkflows
  End Sub
  Protected Sub TBLxDmsWorkflows_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsWorkflows.Init
    SetToolBar = TBLxDmsWorkflows
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
