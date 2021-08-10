Imports System.Web.Script.Serialization
Partial Class EF_xDmsGroupUsers
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
  Protected Sub ODSxDmsGroupUsers_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsGroupUsers.Selected
    Dim tmp As SIS.xDMS.xDmsGroupUsers = CType(e.ReturnValue, SIS.xDMS.xDmsGroupUsers)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVxDmsGroupUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsGroupUsers.Init
    DataClassName = "ExDmsGroupUsers"
    SetFormView = FVxDmsGroupUsers
  End Sub
  Protected Sub TBLxDmsGroupUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsGroupUsers.Init
    SetToolBar = TBLxDmsGroupUsers
  End Sub
  Protected Sub FVxDmsGroupUsers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsGroupUsers.PreRender
    TBLxDmsGroupUsers.EnableSave = Editable
    TBLxDmsGroupUsers.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Edit") & "/EF_xDmsGroupUsers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsGroupUsers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsGroupUsers", mStr)
    End If
  End Sub

End Class
