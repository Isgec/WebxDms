Imports System.Web.Script.Serialization
Partial Class EF_xDmsERPTransmittalTypes
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
  Protected Sub ODSxDmsERPTransmittalTypes_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsERPTransmittalTypes.Selected
    Dim tmp As SIS.xDMS.xDmsERPTransmittalTypes = CType(e.ReturnValue, SIS.xDMS.xDmsERPTransmittalTypes)
    Editable = True
    Deleteable = True
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVxDmsERPTransmittalTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsERPTransmittalTypes.Init
    DataClassName = "ExDmsERPTransmittalTypes"
    SetFormView = FVxDmsERPTransmittalTypes
  End Sub
  Protected Sub TBLxDmsERPTransmittalTypes_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsERPTransmittalTypes.Init
    SetToolBar = TBLxDmsERPTransmittalTypes
  End Sub
  Protected Sub FVxDmsERPTransmittalTypes_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsERPTransmittalTypes.PreRender
    TBLxDmsERPTransmittalTypes.EnableSave = Editable
    TBLxDmsERPTransmittalTypes.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Edit") & "/EF_xDmsERPTransmittalTypes.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsERPTransmittalTypes") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsERPTransmittalTypes", mStr)
    End If
  End Sub

End Class
