Imports System.Web.Script.Serialization
Partial Class EF_xDmsGroupFolders
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
  Protected Sub ODSxDmsGroupFolders_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsGroupFolders.Selected
    Dim tmp As SIS.xDMS.xDmsGroupFolders = CType(e.ReturnValue, SIS.xDMS.xDmsGroupFolders)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVxDmsGroupFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsGroupFolders.Init
    DataClassName = "ExDmsGroupFolders"
    SetFormView = FVxDmsGroupFolders
  End Sub
  Protected Sub TBLxDmsGroupFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsGroupFolders.Init
    SetToolBar = TBLxDmsGroupFolders
  End Sub
  Protected Sub FVxDmsGroupFolders_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsGroupFolders.PreRender
    TBLxDmsGroupFolders.EnableSave = Editable
    TBLxDmsGroupFolders.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Edit") & "/EF_xDmsGroupFolders.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsGroupFolders") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsGroupFolders", mStr)
    End If
  End Sub

End Class
