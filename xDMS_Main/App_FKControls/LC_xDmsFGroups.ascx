<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_xDmsFGroups.ascx.vb" Inherits="LC_xDmsFGroups" %>
<asp:DropDownList 
  ID = "DDLxDmsFGroups"
  DataSourceID = "OdsDdlxDmsFGroups"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorxDmsFGroups"
  Runat = "server" 
  ControlToValidate = "DDLxDmsFGroups"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlxDmsFGroups"
  TypeName = "SIS.xDMS.xDmsFGroups"
  SortParameterName = "OrderBy"
  SelectMethod = "xDmsFGroupsSelectList"
  Runat="server" />
