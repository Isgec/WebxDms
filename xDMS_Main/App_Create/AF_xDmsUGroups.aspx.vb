Partial Class AF_xDmsUGroups
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsUGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUGroups.Init
    DataClassName = "AxDmsUGroups"
    SetFormView = FVxDmsUGroups
  End Sub
  Protected Sub TBLxDmsUGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsUGroups.Init
    SetToolBar = TBLxDmsUGroups
  End Sub
  Protected Sub ODSxDmsUGroups_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsUGroups.Inserted
    If e.Exception Is Nothing Then
      Dim oDC As SIS.xDMS.xDmsUGroups = CType(e.ReturnValue,SIS.xDMS.xDmsUGroups)
      Dim tmpURL As String = "?tmp=1"
      tmpURL &= "&GroupID=" & oDC.GroupID
      TBLxDmsUGroups.AfterInsertURL &= tmpURL 
    End If
  End Sub
  Protected Sub FVxDmsUGroups_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUGroups.DataBound
    SIS.xDMS.xDmsUGroups.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsUGroups_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUGroups.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsUGroups.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsUGroups") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsUGroups", mStr)
    End If
    If Request.QueryString("GroupID") IsNot Nothing Then
      CType(FVxDmsUGroups.FindControl("F_GroupID"), TextBox).Text = Request.QueryString("GroupID")
      CType(FVxDmsUGroups.FindControl("F_GroupID"), TextBox).Enabled = False
    End If
  End Sub

End Class
