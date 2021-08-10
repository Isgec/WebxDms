Imports System.Web.Script.Serialization
Partial Class GF_xDmsERPTransmittalTypes
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/xDMS_Main/App_Display/DF_xDmsERPTransmittalTypes.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?TransmittalTypeID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVxDmsERPTransmittalTypes_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsERPTransmittalTypes.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim TransmittalTypeID As Int32 = GVxDmsERPTransmittalTypes.DataKeys(e.CommandArgument).Values("TransmittalTypeID")  
        Dim RedirectUrl As String = TBLxDmsERPTransmittalTypes.EditUrl & "?TransmittalTypeID=" & TransmittalTypeID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVxDmsERPTransmittalTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsERPTransmittalTypes.Init
    DataClassName = "GxDmsERPTransmittalTypes"
    SetGridView = GVxDmsERPTransmittalTypes
  End Sub
  Protected Sub TBLxDmsERPTransmittalTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsERPTransmittalTypes.Init
    SetToolBar = TBLxDmsERPTransmittalTypes
  End Sub
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
  End Sub
End Class
