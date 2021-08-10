Imports System.Web.Script.Serialization
Partial Class EF_xDmsStates
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
  Protected Sub ODSxDmsStates_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsStates.Selected
    Dim tmp As SIS.xDMS.xDmsStates = CType(e.ReturnValue, SIS.xDMS.xDmsStates)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVxDmsStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsStates.Init
    DataClassName = "ExDmsStates"
    SetFormView = FVxDmsStates
  End Sub
  Protected Sub TBLxDmsStates_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsStates.Init
    SetToolBar = TBLxDmsStates
  End Sub
  Protected Sub FVxDmsStates_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsStates.PreRender
    TBLxDmsStates.EnableSave = Editable
    TBLxDmsStates.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Edit") & "/EF_xDmsStates.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsStates") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsStates", mStr)
    End If
  End Sub

End Class
