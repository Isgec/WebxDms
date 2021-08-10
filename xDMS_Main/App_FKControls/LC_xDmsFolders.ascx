<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_xDmsFolders.ascx.vb" Inherits="LC_xDmsFolders" %>
<asp:DropDownList 
  ID = "DDLxDmsFolders"
  DataSourceID = "OdsDdlxDmsFolders"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorxDmsFolders"
  Runat = "server" 
  ControlToValidate = "DDLxDmsFolders"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlxDmsFolders"
  TypeName = "SIS.xDMS.xDmsFolders"
  SortParameterName = "OrderBy"
  SelectMethod = "xDmsFoldersSelectList"
  Runat="server" />
