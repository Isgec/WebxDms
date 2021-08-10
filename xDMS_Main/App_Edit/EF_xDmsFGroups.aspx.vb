Imports System.Web.Script.Serialization
Partial Class EF_xDmsFGroups
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
  Protected Sub ODSxDmsFGroups_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsFGroups.Selected
    Dim tmp As SIS.xDMS.xDmsFGroups = CType(e.ReturnValue, SIS.xDMS.xDmsFGroups)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVxDmsFGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFGroups.Init
    DataClassName = "ExDmsFGroups"
    SetFormView = FVxDmsFGroups
  End Sub
  Protected Sub TBLxDmsFGroups_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFGroups.Init
    SetToolBar = TBLxDmsFGroups
  End Sub
  Protected Sub FVxDmsFGroups_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFGroups.PreRender
    TBLxDmsFGroups.EnableSave = Editable
    TBLxDmsFGroups.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Edit") & "/EF_xDmsFGroups.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsFGroups") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsFGroups", mStr)
    End If
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.GridBase
  End Class
  Private WithEvents gvxDmsFGroupFoldersCC As New gvBase
  Protected Sub GVxDmsFGroupFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsFGroupFolders.Init
    gvxDmsFGroupFoldersCC.DataClassName = "GxDmsFGroupFolders"
    gvxDmsFGroupFoldersCC.SetGridView = GVxDmsFGroupFolders
  End Sub
  Protected Sub TBLxDmsFGroupFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFGroupFolders.Init
    gvxDmsFGroupFoldersCC.SetToolBar = TBLxDmsFGroupFolders
  End Sub
  Protected Sub GVxDmsFGroupFolders_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsFGroupFolders.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FGroupID As Int32 = GVxDmsFGroupFolders.DataKeys(e.CommandArgument).Values("FGroupID")  
        Dim FolderID As Int32 = GVxDmsFGroupFolders.DataKeys(e.CommandArgument).Values("FolderID")  
        Dim RedirectUrl As String = TBLxDmsFGroupFolders.EditUrl & "?FGroupID=" & FGroupID & "&FolderID=" & FolderID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim FGroupID As Int32 = GVxDmsFGroupFolders.DataKeys(e.CommandArgument).Values("FGroupID")  
        Dim FolderID As Int32 = GVxDmsFGroupFolders.DataKeys(e.CommandArgument).Values("FolderID")  
        SIS.xDMS.xDmsFGroupFolders.InitiateWF(FGroupID, FolderID)
        GVxDmsFGroupFolders.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub TBLxDmsFGroupFolders_AddClicked(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles TBLxDmsFGroupFolders.AddClicked
    Dim FGroupID As Int32 = CType(FVxDmsFGroups.FindControl("F_FGroupID"),TextBox).Text
    TBLxDmsFGroupFolders.AddUrl &= "?FGroupID=" & FGroupID
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ReleaseWorkflowIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ReviseWorkflowIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_FGroups_ReleaseWorkflowID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ReleaseWorkflowID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(ReleaseWorkflowID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_FGroups_ReviseWorkflowID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ReviseWorkflowID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(ReviseWorkflowID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
