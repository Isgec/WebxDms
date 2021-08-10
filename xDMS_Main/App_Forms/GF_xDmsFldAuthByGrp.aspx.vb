Imports System.Web.Script.Serialization
Partial Class GF_xDmsFldAuthByGrp
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/xDMS_Main/App_Display/DF_xDmsFldAuthByGrp.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?GroupID=" & aVal(0) & "&UserID=" & aVal(1) & "&FolderID=" & aVal(2)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVxDmsFldAuthByGrp_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsFldAuthByGrp.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsFldAuthByGrp.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim UserID As String = GVxDmsFldAuthByGrp.DataKeys(e.CommandArgument).Values("UserID")  
        Dim FolderID As Int32 = GVxDmsFldAuthByGrp.DataKeys(e.CommandArgument).Values("FolderID")  
        Dim RedirectUrl As String = TBLxDmsFldAuthByGrp.EditUrl & "?GroupID=" & GroupID & "&UserID=" & UserID & "&FolderID=" & FolderID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVxDmsFldAuthByGrp_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsFldAuthByGrp.Init
    DataClassName = "GxDmsFldAuthByGrp"
    SetGridView = GVxDmsFldAuthByGrp
  End Sub
  Protected Sub TBLxDmsFldAuthByGrp_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFldAuthByGrp.Init
    SetToolBar = TBLxDmsFldAuthByGrp
  End Sub
  Protected Sub F_GroupID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_GroupID.TextChanged
    Session("F_GroupID") = F_GroupID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
