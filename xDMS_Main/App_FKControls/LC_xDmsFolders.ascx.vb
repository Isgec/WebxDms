Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

<ValidationProperty("SelectedValue")> _
Partial Class LC_xDmsFolders
  Inherits System.Web.UI.UserControl
  Private _OrderBy As String = String.Empty
  Private _IncludeDefault As Boolean = True
  Private _DefaultText As String = "-- Select --"
  Private _DefaultValue As String = String.Empty
  Public Event SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
  Public ReadOnly Property LCClientID() As String
    Get
      Return DDLxDmsFolders.ClientID
    End Get
  End Property
  Public Property AddAttributes() As String
    Get
      Return DDLxDmsFolders.Attributes.ToString
    End Get
    Set(ByVal value As String)
      Try
        Dim aVal() As String = value.Split(",".ToCharArray)
        DDLxDmsFolders.Attributes.Add(aVal(0), aVal(1))
      Catch ex As Exception
      End Try
    End Set
  End Property
  Public Property CssClass() As String
    Get
      Return DDLxDmsFolders.CssClass
    End Get
    Set(ByVal value As String)
      DDLxDmsFolders.CssClass = value
    End Set
  End Property
  Public Property Width() As System.Web.UI.WebControls.Unit
    Get
      Return DDLxDmsFolders.Width
    End Get
    Set(ByVal value As System.Web.UI.WebControls.Unit)
      DDLxDmsFolders.Width = value
    End Set
  End Property
  Public Property RequiredFieldErrorMessage() As String
    Get
      Return RequiredFieldValidatorxDmsFolders.Text
    End Get
    Set(ByVal value As String)
      If value = String.Empty Then
        RequiredFieldValidatorxDmsFolders.Enabled = False
      Else
        RequiredFieldValidatorxDmsFolders.Text = value
      End If
    End Set
  End Property
  Public Property ValidationGroup() As String
    Get
      Return RequiredFieldValidatorxDmsFolders.ValidationGroup
    End Get
    Set(ByVal value As String)
      RequiredFieldValidatorxDmsFolders.ValidationGroup = value
    End Set
  End Property
  Public Property Enabled() As Boolean
    Get
      Return DDLxDmsFolders.Enabled
    End Get
    Set(ByVal value As Boolean)
      DDLxDmsFolders.Enabled = value
      RequiredFieldValidatorxDmsFolders.Enabled = value
    End Set
  End Property
  Public Property AutoPostBack() As Boolean
    Get
      Return DDLxDmsFolders.AutoPostBack
    End Get
    Set(ByVal value As Boolean)
      DDLxDmsFolders.AutoPostBack = value
    End Set
  End Property
  Public Property DataTextField() As String
    Get
      Return DDLxDmsFolders.DataTextField
    End Get
    Set(ByVal value As String)
      DDLxDmsFolders.DataTextField = value
    End Set
  End Property
  Public Property DataValueField() As String
    Get
      Return DDLxDmsFolders.DataValueField
    End Get
    Set(ByVal value As String)
      DDLxDmsFolders.DataValueField = value
    End Set
  End Property
  Public Property SelectedValue() As String
    Get
      Return DDLxDmsFolders.SelectedValue
    End Get
    Set(ByVal value As String)
      If Convert.IsDBNull(value) Then
        DDLxDmsFolders.SelectedValue = String.Empty
      Else
        DDLxDmsFolders.SelectedValue = value
      End If
    End Set
  End Property
  Public Property OrderBy() As String
    Get
      Return _OrderBy
    End Get
    Set(ByVal value As String)
      _OrderBy = value
    End Set
  End Property
  Public Property IncludeDefault() As Boolean
    Get
      Return _IncludeDefault
    End Get
    Set(ByVal value As Boolean)
      _IncludeDefault = value
    End Set
  End Property
  Public Property DefaultText() As String
    Get
      Return _DefaultText
    End Get
    Set(ByVal value As String)
      _DefaultText = value
    End Set
  End Property
  Public Property DefaultValue() As String
    Get
      Return _DefaultValue
    End Get
    Set(ByVal value As String)
      _DefaultValue = value
    End Set
  End Property
  Protected Sub OdsDdlxDmsFolders_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceSelectingEventArgs) Handles OdsDdlxDmsFolders.Selecting
    e.Arguments.SortExpression = _OrderBy
  End Sub
  Protected Sub DDLxDmsFolders_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLxDmsFolders.DataBinding
    If _IncludeDefault Then
      DDLxDmsFolders.Items.Add(new ListItem(_DefaultText, _DefaultValue))
    End If
  End Sub
  Protected Sub DDLxDmsFolders_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLxDmsFolders.SelectedIndexChanged
    RaiseEvent SelectedIndexChanged(sender, e)
  End Sub
End Class
