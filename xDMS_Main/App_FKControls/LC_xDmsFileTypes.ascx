<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_xDmsFileTypes.ascx.vb" Inherits="LC_xDmsFileTypes" %>
<asp:DropDownList 
  ID = "DDLxDmsFileTypes"
  DataSourceID = "OdsDdlxDmsFileTypes"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorxDmsFileTypes"
  Runat = "server" 
  ControlToValidate = "DDLxDmsFileTypes"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlxDmsFileTypes"
  TypeName = "SIS.xDMS.xDmsFileTypes"
  SortParameterName = "OrderBy"
  SelectMethod = "xDmsFileTypesSelectList"
  Runat="server" />
