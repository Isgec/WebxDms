Imports System.Web.Script.Serialization
Partial Class GF_xDmsFGroupFolders
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/xDMS_Main/App_Display/DF_xDmsFGroupFolders.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?FGroupID=" & aVal(0) & "&FolderID=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVxDmsFGroupFolders_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsFGroupFolders.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FGroupID As Int32 = GVxDmsFGroupFolders.DataKeys(e.CommandArgument).Values("FGroupID")  
        Dim FolderID As Int32 = GVxDmsFGroupFolders.DataKeys(e.CommandArgument).Values("FolderID")  
        Dim RedirectUrl As String = TBLxDmsFGroupFolders.EditUrl & "?FGroupID=" & FGroupID & "&FolderID=" & FolderID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim FGroupID As Int32 = GVxDmsFGroupFolders.DataKeys(e.CommandArgument).Values("FGroupID")  
        Dim FolderID As Int32 = GVxDmsFGroupFolders.DataKeys(e.CommandArgument).Values("FolderID")  
        SIS.xDMS.xDmsFGroupFolders.InitiateWF(FGroupID, FolderID)
        GVxDmsFGroupFolders.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVxDmsFGroupFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsFGroupFolders.Init
    DataClassName = "GxDmsFGroupFolders"
    SetGridView = GVxDmsFGroupFolders
  End Sub
  Protected Sub TBLxDmsFGroupFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFGroupFolders.Init
    SetToolBar = TBLxDmsFGroupFolders
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
