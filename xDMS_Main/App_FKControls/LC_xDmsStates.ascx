<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_xDmsStates.ascx.vb" Inherits="LC_xDmsStates" %>
<asp:DropDownList 
  ID = "DDLxDmsStates"
  DataSourceID = "OdsDdlxDmsStates"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorxDmsStates"
  Runat = "server" 
  ControlToValidate = "DDLxDmsStates"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlxDmsStates"
  TypeName = "SIS.xDMS.xDmsStates"
  SortParameterName = "OrderBy"
  SelectMethod = "xDmsStatesSelectList"
  Runat="server" />
