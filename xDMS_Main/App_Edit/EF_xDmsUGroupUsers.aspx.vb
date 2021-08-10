Imports System.Web.Script.Serialization
Partial Class EF_xDmsUGroupUsers
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
  Protected Sub ODSxDmsUGroupUsers_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsUGroupUsers.Selected
    Dim tmp As SIS.xDMS.xDmsUGroupUsers = CType(e.ReturnValue, SIS.xDMS.xDmsUGroupUsers)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVxDmsUGroupUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUGroupUsers.Init
    DataClassName = "ExDmsUGroupUsers"
    SetFormView = FVxDmsUGroupUsers
  End Sub
  Protected Sub TBLxDmsUGroupUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsUGroupUsers.Init
    SetToolBar = TBLxDmsUGroupUsers
  End Sub
  Protected Sub FVxDmsUGroupUsers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUGroupUsers.PreRender
    TBLxDmsUGroupUsers.EnableSave = Editable
    TBLxDmsUGroupUsers.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Edit") & "/EF_xDmsUGroupUsers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsUGroupUsers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsUGroupUsers", mStr)
    End If
  End Sub

End Class
