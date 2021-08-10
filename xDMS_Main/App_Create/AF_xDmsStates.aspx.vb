Partial Class AF_xDmsStates
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsStates.Init
    DataClassName = "AxDmsStates"
    SetFormView = FVxDmsStates
  End Sub
  Protected Sub TBLxDmsStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsStates.Init
    SetToolBar = TBLxDmsStates
  End Sub
  Protected Sub FVxDmsStates_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsStates.DataBound
    SIS.xDMS.xDmsStates.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsStates.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsStates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsStates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsStates", mStr)
    End If
    If Request.QueryString("StatusID") IsNot Nothing Then
      CType(FVxDmsStates.FindControl("F_StatusID"), TextBox).Text = Request.QueryString("StatusID")
      CType(FVxDmsStates.FindControl("F_StatusID"), TextBox).Enabled = False
    End If
  End Sub

End Class
