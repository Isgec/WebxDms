Imports System.Web.Script.Serialization
Partial Class EF_xDmsGroups
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
  Protected Sub ODSxDmsGroups_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsGroups.Selected
    Dim tmp As SIS.xDMS.xDmsGroups = CType(e.ReturnValue, SIS.xDMS.xDmsGroups)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVxDmsGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsGroups.Init
    DataClassName = "ExDmsGroups"
    SetFormView = FVxDmsGroups
  End Sub
  Protected Sub TBLxDmsGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsGroups.Init
    SetToolBar = TBLxDmsGroups
  End Sub
  Protected Sub FVxDmsGroups_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsGroups.PreRender
    TBLxDmsGroups.EnableSave = Editable
    TBLxDmsGroups.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Edit") & "/EF_xDmsGroups.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsGroups") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsGroups", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvxDmsGroupUsersCC As New gvBase
  Protected Sub GVxDmsGroupUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsGroupUsers.Init
    gvxDmsGroupUsersCC.DataClassName = "GxDmsGroupUsers"
    gvxDmsGroupUsersCC.SetGridView = GVxDmsGroupUsers
  End Sub
  Protected Sub TBLxDmsGroupUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsGroupUsers.Init
    gvxDmsGroupUsersCC.SetToolBar = TBLxDmsGroupUsers
  End Sub
  Protected Sub GVxDmsGroupUsers_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsGroupUsers.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsGroupUsers.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim UserID As String = GVxDmsGroupUsers.DataKeys(e.CommandArgument).Values("UserID")  
        Dim RedirectUrl As String = TBLxDmsGroupUsers.EditUrl & "?GroupID=" & GroupID & "&UserID=" & UserID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsGroupUsers.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim UserID As String = GVxDmsGroupUsers.DataKeys(e.CommandArgument).Values("UserID")  
        SIS.xDMS.xDmsGroupUsers.DeleteWF(GroupID, UserID)
        GVxDmsGroupUsers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Applywf".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsGroupUsers.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim UserID As String = GVxDmsGroupUsers.DataKeys(e.CommandArgument).Values("UserID")  
        SIS.xDMS.xDmsGroupUsers.ApplyWF(GroupID, UserID)
        GVxDmsGroupUsers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsGroupUsers.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim UserID As String = GVxDmsGroupUsers.DataKeys(e.CommandArgument).Values("UserID")  
        SIS.xDMS.xDmsGroupUsers.InitiateWF(GroupID, UserID)
        GVxDmsGroupUsers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLxDmsGroupUsers_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLxDmsGroupUsers.AddClicked
    Dim GroupID As Int32 = CType(FVxDmsGroups.FindControl("F_GroupID"),TextBox).Text
    TBLxDmsGroupUsers.AddUrl &= "?GroupID=" & GroupID
  End Sub
  Private WithEvents gvxDmsGroupFoldersCC As New gvBase
  Protected Sub GVxDmsGroupFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsGroupFolders.Init
    gvxDmsGroupFoldersCC.DataClassName = "GxDmsGroupFolders"
    gvxDmsGroupFoldersCC.SetGridView = GVxDmsGroupFolders
  End Sub
  Protected Sub TBLxDmsGroupFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsGroupFolders.Init
    gvxDmsGroupFoldersCC.SetToolBar = TBLxDmsGroupFolders
  End Sub
  Protected Sub GVxDmsGroupFolders_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsGroupFolders.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsGroupFolders.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim FolderID As Int32 = GVxDmsGroupFolders.DataKeys(e.CommandArgument).Values("FolderID")  
        Dim RedirectUrl As String = TBLxDmsGroupFolders.EditUrl & "?GroupID=" & GroupID & "&FolderID=" & FolderID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsGroupFolders.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim FolderID As Int32 = GVxDmsGroupFolders.DataKeys(e.CommandArgument).Values("FolderID")  
        SIS.xDMS.xDmsGroupFolders.DeleteWF(GroupID, FolderID)
        GVxDmsGroupFolders.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsGroupFolders.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim FolderID As Int32 = GVxDmsGroupFolders.DataKeys(e.CommandArgument).Values("FolderID")  
        SIS.xDMS.xDmsGroupFolders.InitiateWF(GroupID, FolderID)
        GVxDmsGroupFolders.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLxDmsGroupFolders_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLxDmsGroupFolders.AddClicked
    Dim GroupID As Int32 = CType(FVxDmsGroups.FindControl("F_GroupID"),TextBox).Text
    TBLxDmsGroupFolders.AddUrl &= "?GroupID=" & GroupID
  End Sub
  Private WithEvents gvxDmsFldAuthByGrpCC As New gvBase
  Protected Sub GVxDmsFldAuthByGrp_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsFldAuthByGrp.Init
    gvxDmsFldAuthByGrpCC.DataClassName = "GxDmsFldAuthByGrp"
    gvxDmsFldAuthByGrpCC.SetGridView = GVxDmsFldAuthByGrp
  End Sub
  Protected Sub TBLxDmsFldAuthByGrp_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFldAuthByGrp.Init
    gvxDmsFldAuthByGrpCC.SetToolBar = TBLxDmsFldAuthByGrp
  End Sub
  Protected Sub GVxDmsFldAuthByGrp_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsFldAuthByGrp.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsFldAuthByGrp.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim UserID As String = GVxDmsFldAuthByGrp.DataKeys(e.CommandArgument).Values("UserID")  
        Dim FolderID As Int32 = GVxDmsFldAuthByGrp.DataKeys(e.CommandArgument).Values("FolderID")  
        Dim RedirectUrl As String = TBLxDmsFldAuthByGrp.EditUrl & "?GroupID=" & GroupID & "&UserID=" & UserID & "&FolderID=" & FolderID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub

End Class
