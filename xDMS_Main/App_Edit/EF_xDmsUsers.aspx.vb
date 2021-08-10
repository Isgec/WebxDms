Imports System.Web.Script.Serialization
Partial Class EF_xDmsUsers
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
  Protected Sub ODSxDmsUsers_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsUsers.Selected
    Dim tmp As SIS.xDMS.xDmsUsers = CType(e.ReturnValue, SIS.xDMS.xDmsUsers)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVxDmsUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUsers.Init
    DataClassName = "ExDmsUsers"
    SetFormView = FVxDmsUsers
  End Sub
  Protected Sub TBLxDmsUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsUsers.Init
    SetToolBar = TBLxDmsUsers
  End Sub
  Protected Sub FVxDmsUsers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUsers.PreRender
    TBLxDmsUsers.EnableSave = Editable
    TBLxDmsUsers.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Edit") & "/EF_xDmsUsers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsUsers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsUsers", mStr)
    End If
  End Sub

End Class
