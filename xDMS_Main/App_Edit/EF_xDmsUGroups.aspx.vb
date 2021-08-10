Imports System.Web.Script.Serialization
Partial Class EF_xDmsUGroups
  Inherits SIS.SYS.UpdateBase
  Public Property Editable() As Boolean
    Get
      If ViewState("Editable") IsNot Nothing Then
        Return CType(ViewState("Editable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Editable", value)
    End Set
  End Property
  Public Property Deleteable() As Boolean
    Get
      If ViewState("Deleteable") IsNot Nothing Then
        Return CType(ViewState("Deleteable"), Boolean)
      End If
      Return True
    End Get
    Set(ByVal value As Boolean)
      ViewState.Add("Deleteable", value)
    End Set
  End Property
  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSxDmsUGroups_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsUGroups.Selected
    Dim tmp As SIS.xDMS.xDmsUGroups = CType(e.ReturnValue, SIS.xDMS.xDmsUGroups)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVxDmsUGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUGroups.Init
    DataClassName = "ExDmsUGroups"
    SetFormView = FVxDmsUGroups
  End Sub
  Protected Sub TBLxDmsUGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsUGroups.Init
    SetToolBar = TBLxDmsUGroups
  End Sub
  Protected Sub FVxDmsUGroups_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUGroups.PreRender
    TBLxDmsUGroups.EnableSave = Editable
    TBLxDmsUGroups.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Edit") & "/EF_xDmsUGroups.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsUGroups") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsUGroups", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvxDmsUGroupUsersCC As New gvBase
  Protected Sub GVxDmsUGroupUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsUGroupUsers.Init
    gvxDmsUGroupUsersCC.DataClassName = "GxDmsUGroupUsers"
    gvxDmsUGroupUsersCC.SetGridView = GVxDmsUGroupUsers
  End Sub
  Protected Sub TBLxDmsUGroupUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsUGroupUsers.Init
    gvxDmsUGroupUsersCC.SetToolBar = TBLxDmsUGroupUsers
  End Sub
  Protected Sub GVxDmsUGroupUsers_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsUGroupUsers.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim UserID As String = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("UserID")  
        Dim RedirectUrl As String = TBLxDmsUGroupUsers.EditUrl & "?GroupID=" & GroupID & "&UserID=" & UserID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim UserID As String = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("UserID")  
        SIS.xDMS.xDmsUGroupUsers.DeleteWF(GroupID, UserID)
        GVxDmsUGroupUsers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Applywf".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim UserID As String = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("UserID")  
        SIS.xDMS.xDmsUGroupUsers.ApplyWF(GroupID, UserID)
        GVxDmsUGroupUsers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim UserID As String = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("UserID")  
        SIS.xDMS.xDmsUGroupUsers.InitiateWF(GroupID, UserID)
        GVxDmsUGroupUsers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLxDmsUGroupUsers_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLxDmsUGroupUsers.AddClicked
    Dim GroupID As Int32 = CType(FVxDmsUGroups.FindControl("F_GroupID"),TextBox).Text
    TBLxDmsUGroupUsers.AddUrl &= "?GroupID=" & GroupID
  End Sub

End Class
