Imports System.Web.Script.Serialization
Partial Class GF_xDmsFGroups
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/xDMS_Main/App_Display/DF_xDmsFGroups.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?FGroupID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVxDmsFGroups_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsFGroups.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FGroupID As Int32 = GVxDmsFGroups.DataKeys(e.CommandArgument).Values("FGroupID")  
        Dim RedirectUrl As String = TBLxDmsFGroups.EditUrl & "?FGroupID=" & FGroupID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim FGroupID As Int32 = GVxDmsFGroups.DataKeys(e.CommandArgument).Values("FGroupID")  
        SIS.xDMS.xDmsFGroups.InitiateWF(FGroupID)
        GVxDmsFGroups.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVxDmsFGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsFGroups.Init
    DataClassName = "GxDmsFGroups"
    SetGridView = GVxDmsFGroups
  End Sub
  Protected Sub TBLxDmsFGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFGroups.Init
    SetToolBar = TBLxDmsFGroups
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
