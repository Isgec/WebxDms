Partial Class AF_xDmsGroups
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsGroups.Init
    DataClassName = "AxDmsGroups"
    SetFormView = FVxDmsGroups
  End Sub
  Protected Sub TBLxDmsGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsGroups.Init
    SetToolBar = TBLxDmsGroups
  End Sub
  Protected Sub ODSxDmsGroups_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsGroups.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.xDMS.xDmsGroups = CType(e.ReturnValue,SIS.xDMS.xDmsGroups)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&GroupID=" & oDC.GroupID
      TBLxDmsGroups.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVxDmsGroups_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsGroups.DataBound
    SIS.xDMS.xDmsGroups.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsGroups_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsGroups.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsGroups.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsGroups") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsGroups", mStr)
    End If
    If Request.QueryString("GroupID") IsNot Nothing Then
      CType(FVxDmsGroups.FindControl("F_GroupID"), TextBox).Text = Request.QueryString("GroupID")
      CType(FVxDmsGroups.FindControl("F_GroupID"), TextBox).Enabled = False
    End If
  End Sub

End Class
