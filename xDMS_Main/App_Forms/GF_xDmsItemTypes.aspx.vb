Imports System.Web.Script.Serialization
Partial Class GF_xDmsItemTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/xDMS_Main/App_Display/DF_xDmsItemTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?ItemTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVxDmsItemTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsItemTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim ItemTypeID As String = GVxDmsItemTypes.DataKeys(e.CommandArgument).Values("ItemTypeID")  
        Dim RedirectUrl As String = TBLxDmsItemTypes.EditUrl & "?ItemTypeID=" & ItemTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVxDmsItemTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsItemTypes.Init
    DataClassName = "GxDmsItemTypes"
    SetGridView = GVxDmsItemTypes
  End Sub
  Protected Sub TBLxDmsItemTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsItemTypes.Init
    SetToolBar = TBLxDmsItemTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
