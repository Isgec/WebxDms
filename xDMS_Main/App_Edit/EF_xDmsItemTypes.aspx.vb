Imports System.Web.Script.Serialization
Partial Class EF_xDmsItemTypes
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
  Protected Sub ODSxDmsItemTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsItemTypes.Selected
    Dim tmp As SIS.xDMS.xDmsItemTypes = CType(e.ReturnValue, SIS.xDMS.xDmsItemTypes)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVxDmsItemTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsItemTypes.Init
    DataClassName = "ExDmsItemTypes"
    SetFormView = FVxDmsItemTypes
  End Sub
  Protected Sub TBLxDmsItemTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsItemTypes.Init
    SetToolBar = TBLxDmsItemTypes
  End Sub
  Protected Sub FVxDmsItemTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsItemTypes.PreRender
    TBLxDmsItemTypes.EnableSave = Editable
    TBLxDmsItemTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Edit") & "/EF_xDmsItemTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsItemTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsItemTypes", mStr)
    End If
  End Sub

End Class
