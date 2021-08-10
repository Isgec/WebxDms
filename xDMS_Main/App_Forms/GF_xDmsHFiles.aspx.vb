Imports System.Web.Script.Serialization
Partial Class GF_xDmsHFiles
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/xDMS_Main/App_Display/DF_xDmsHFiles.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?FileID=" & aVal(0) & "&HFileID=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVxDmsHFiles_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsHFiles.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FileID As Int32 = GVxDmsHFiles.DataKeys(e.CommandArgument).Values("FileID")  
        Dim HFileID As Int32 = GVxDmsHFiles.DataKeys(e.CommandArgument).Values("HFileID")  
        Dim RedirectUrl As String = TBLxDmsHFiles.EditUrl & "?FileID=" & FileID & "&HFileID=" & HFileID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVxDmsHFiles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsHFiles.Init
    DataClassName = "GxDmsHFiles"
    SetGridView = GVxDmsHFiles
  End Sub
  Protected Sub TBLxDmsHFiles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsHFiles.Init
    SetToolBar = TBLxDmsHFiles
  End Sub
  Protected Sub F_FileID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_FileID.TextChanged
    Session("F_FileID") = F_FileID.Text
    InitGridPage()
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
