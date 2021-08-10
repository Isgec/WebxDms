<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_xDmsGroups.ascx.vb" Inherits="LC_xDmsGroups" %>
<asp:DropDownList 
  ID = "DDLxDmsGroups"
  DataSourceID = "OdsDdlxDmsGroups"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorxDmsGroups"
  Runat = "server" 
  ControlToValidate = "DDLxDmsGroups"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlxDmsGroups"
  TypeName = "SIS.xDMS.xDmsGroups"
  SortParameterName = "OrderBy"
  SelectMethod = "xDmsGroupsSelectList"
  Runat="server" />
