<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_xDmsItemTypes.ascx.vb" Inherits="LC_xDmsItemTypes" %>
<asp:DropDownList 
  ID = "DDLxDmsItemTypes"
  DataSourceID = "OdsDdlxDmsItemTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorxDmsItemTypes"
  Runat = "server" 
  ControlToValidate = "DDLxDmsItemTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlxDmsItemTypes"
  TypeName = "SIS.xDMS.xDmsItemTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "xDmsItemTypesSelectList"
  Runat="server" />
