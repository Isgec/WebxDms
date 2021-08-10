<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_xDmsWorkflows.ascx.vb" Inherits="LC_xDmsWorkflows" %>
<asp:DropDownList 
  ID = "DDLxDmsWorkflows"
  DataSourceID = "OdsDdlxDmsWorkflows"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorxDmsWorkflows"
  Runat = "server" 
  ControlToValidate = "DDLxDmsWorkflows"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlxDmsWorkflows"
  TypeName = "SIS.xDMS.xDmsWorkflows"
  SortParameterName = "OrderBy"
  SelectMethod = "xDmsWorkflowsSelectList"
  Runat="server" />
