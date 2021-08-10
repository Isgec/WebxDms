Imports System.Web.Script.Serialization
Partial Class GF_cDmsERPMapping
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/xDMS_Main/App_Display/DF_cDmsERPMapping.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?SerialNo=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVcDmsERPMapping_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVcDmsERPMapping.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim SerialNo As Int32 = GVcDmsERPMapping.DataKeys(e.CommandArgument).Values("SerialNo")  
        Dim RedirectUrl As String = TBLcDmsERPMapping.EditUrl & "?SerialNo=" & SerialNo
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVcDmsERPMapping_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVcDmsERPMapping.Init
    DataClassName = "GcDmsERPMapping"
    SetGridView = GVcDmsERPMapping
  End Sub
  Protected Sub TBLcDmsERPMapping_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLcDmsERPMapping.Init
    SetToolBar = TBLcDmsERPMapping
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
