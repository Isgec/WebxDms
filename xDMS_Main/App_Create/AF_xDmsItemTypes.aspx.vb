Partial Class AF_xDmsItemTypes
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsItemTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsItemTypes.Init
    DataClassName = "AxDmsItemTypes"
    SetFormView = FVxDmsItemTypes
  End Sub
  Protected Sub TBLxDmsItemTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsItemTypes.Init
    SetToolBar = TBLxDmsItemTypes
  End Sub
  Protected Sub FVxDmsItemTypes_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsItemTypes.DataBound
    SIS.xDMS.xDmsItemTypes.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsItemTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsItemTypes.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsItemTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsItemTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsItemTypes", mStr)
    End If
    If Request.QueryString("ItemTypeID") IsNot Nothing Then
      CType(FVxDmsItemTypes.FindControl("F_ItemTypeID"), TextBox).Text = Request.QueryString("ItemTypeID")
      CType(FVxDmsItemTypes.FindControl("F_ItemTypeID"), TextBox).Enabled = False
    End If
  End Sub

End Class
