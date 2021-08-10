<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_xDmsFiles.ascx.vb" Inherits="LC_xDmsFiles" %>
<asp:DropDownList 
  ID = "DDLxDmsFiles"
  DataSourceID = "OdsDdlxDmsFiles"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorxDmsFiles"
  Runat = "server" 
  ControlToValidate = "DDLxDmsFiles"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlxDmsFiles"
  TypeName = "SIS.xDMS.xDmsFiles"
  SortParameterName = "OrderBy"
  SelectMethod = "xDmsFilesSelectList"
  Runat="server" />
