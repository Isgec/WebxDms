Imports System.Web.Script.Serialization
Partial Class GF_xDmsFileTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/xDMS_Main/App_Display/DF_xDmsFileTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?FileTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVxDmsFileTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsFileTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FileTypeID As Int32 = GVxDmsFileTypes.DataKeys(e.CommandArgument).Values("FileTypeID")  
        Dim RedirectUrl As String = TBLxDmsFileTypes.EditUrl & "?FileTypeID=" & FileTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVxDmsFileTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsFileTypes.Init
    DataClassName = "GxDmsFileTypes"
    SetGridView = GVxDmsFileTypes
  End Sub
  Protected Sub TBLxDmsFileTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFileTypes.Init
    SetToolBar = TBLxDmsFileTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
