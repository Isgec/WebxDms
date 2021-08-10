<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LC_xDmsUGroups.ascx.vb" Inherits="LC_xDmsUGroups" %>
<asp:DropDownList 
  ID = "DDLxDmsUGroups"
  DataSourceID = "OdsDdlxDmsUGroups"
  AppendDataBoundItems = "true"
  SkinID = "DropDownSkin"
  Width="200px"
  CssClass = "myddl"
  Runat="server" />
<asp:RequiredFieldValidator 
  ID = "RequiredFieldValidatorxDmsUGroups"
  Runat = "server" 
  ControlToValidate = "DDLxDmsUGroups"
  ErrorMessage = "<div class='errorLG'>Required!</div>"
  Display = "Dynamic"
  EnableClientScript = "true"
  ValidationGroup = "none"
  SetFocusOnError = "true" />
<asp:ObjectDataSource 
  ID = "OdsDdlxDmsUGroups"
  TypeName = "SIS.xDMS.xDmsUGroups"
  SortParameterName = "OrderBy"
  SelectMethod = "xDmsUGroupsSelectList"
  Runat="server" />
