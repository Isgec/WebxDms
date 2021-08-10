Imports System.Web.Script.Serialization
Partial Class EF_xDmsFGroupFolders
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
  Protected Sub ODSxDmsFGroupFolders_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsFGroupFolders.Selected
    Dim tmp As SIS.xDMS.xDmsFGroupFolders = CType(e.ReturnValue, SIS.xDMS.xDmsFGroupFolders)
    Editable = tmp.Editable
    Deleteable = tmp.Deleteable
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVxDmsFGroupFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFGroupFolders.Init
    DataClassName = "ExDmsFGroupFolders"
    SetFormView = FVxDmsFGroupFolders
  End Sub
  Protected Sub TBLxDmsFGroupFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFGroupFolders.Init
    SetToolBar = TBLxDmsFGroupFolders
  End Sub
  Protected Sub FVxDmsFGroupFolders_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFGroupFolders.PreRender
    TBLxDmsFGroupFolders.EnableSave = Editable
    TBLxDmsFGroupFolders.EnableDelete = Deleteable
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Edit") & "/EF_xDmsFGroupFolders.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsFGroupFolders") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsFGroupFolders", mStr)
    End If
  End Sub

End Class
