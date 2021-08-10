Partial Class AF_xDmsERPTransmittalTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsERPTransmittalTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsERPTransmittalTypes.Init
    DataClassName = "AxDmsERPTransmittalTypes"
    SetFormView = FVxDmsERPTransmittalTypes
  End Sub
  Protected Sub TBLxDmsERPTransmittalTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsERPTransmittalTypes.Init
    SetToolBar = TBLxDmsERPTransmittalTypes
  End Sub
  Protected Sub FVxDmsERPTransmittalTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsERPTransmittalTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsERPTransmittalTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsERPTransmittalTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsERPTransmittalTypes", mStr)
    End If
    If Request.QueryString("TransmittalTypeID") IsNot Nothing Then
      CType(FVxDmsERPTransmittalTypes.FindControl("F_TransmittalTypeID"), TextBox).Text = Request.QueryString("TransmittalTypeID")
      CType(FVxDmsERPTransmittalTypes.FindControl("F_TransmittalTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
