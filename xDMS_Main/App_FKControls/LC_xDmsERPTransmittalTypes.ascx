<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_xDmsERPTransmittalTypes.ascx.vb" Inherits="LC_xDmsERPTransmittalTypes" %>
<asp:DropDownList 
  ID = "DDLxDmsERPTransmittalTypes"
  DataSourceID = "OdsDdlxDmsERPTransmittalTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorxDmsERPTransmittalTypes"
  Runat = "server" 
  ControlToValidate = "DDLxDmsERPTransmittalTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlxDmsERPTransmittalTypes"
  TypeName = "SIS.xDMS.xDmsERPTransmittalTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "xDmsERPTransmittalTypesSelectList"
  Runat="server" />
