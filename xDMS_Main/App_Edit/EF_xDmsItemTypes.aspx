<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_xDmsItemTypes.aspx.vb" Inherits="EF_xDmsItemTypes" title="Edit: Item Types" %>
<asp:Content ID="CPHxDmsItemTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsItemTypes" runat="server" Text="&nbsp;Edit: Item Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsItemTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsItemTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "xDmsItemTypes"
    runat = "server" />
<asp:FormView ID="FVxDmsItemTypes"
  runat = "server"
  DataKeyNames = "ItemTypeID"
  DataSourceID = "ODSxDmsItemTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemTypeID" runat="server" ForeColor="#CC6633" Text="Item Type :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ItemTypeID"
            Text='<%# Bind("ItemTypeID") %>'
            ToolTip="Value of Item Type."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemName" runat="server" Text="Item Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ItemName"
            Text='<%# Bind("ItemName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsItemTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Item Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemName"
            runat = "server"
            ControlToValidate = "F_ItemName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsItemTypes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BaseTypeID" runat="server" Text="Base Type :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BaseTypeID"
            Text='<%# Bind("BaseTypeID") %>'
            Width="88px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsItemTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Base Type."
            MaxLength="10"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVBaseTypeID"
            runat = "server"
            ControlToValidate = "F_BaseTypeID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsItemTypes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSxDmsItemTypes"
  DataObjectTypeName = "SIS.xDMS.xDmsItemTypes"
  SelectMethod = "xDmsItemTypesGetByID"
  UpdateMethod="UZ_xDmsItemTypesUpdate"
  DeleteMethod="UZ_xDmsItemTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsItemTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="ItemTypeID" Name="ItemTypeID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
