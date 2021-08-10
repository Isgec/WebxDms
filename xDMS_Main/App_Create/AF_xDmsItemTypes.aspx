<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_xDmsItemTypes.aspx.vb" Inherits="AF_xDmsItemTypes" title="Add: Item Types" %>
<asp:Content ID="CPHxDmsItemTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsItemTypes" runat="server" Text="&nbsp;Add: Item Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsItemTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsItemTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "xDmsItemTypes"
    runat = "server" />
<asp:FormView ID="FVxDmsItemTypes"
  runat = "server"
  DataKeyNames = "ItemTypeID"
  DataSourceID = "ODSxDmsItemTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgxDmsItemTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ItemTypeID" ForeColor="#CC6633" runat="server" Text="Item Type :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ItemTypeID"
            Text='<%# Bind("ItemTypeID") %>'
            CssClass = "mypktxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsItemTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Item Type."
            MaxLength="10"
            Width="88px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemTypeID"
            runat = "server"
            ControlToValidate = "F_ItemTypeID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsItemTypes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemName" runat="server" Text="Item Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ItemName"
            Text='<%# Bind("ItemName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsItemTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Item Name."
            MaxLength="50"
            Width="408px"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BaseTypeID" runat="server" Text="Base Type :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_BaseTypeID"
            Text='<%# Bind("BaseTypeID") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsItemTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Base Type."
            MaxLength="10"
            Width="88px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSxDmsItemTypes"
  DataObjectTypeName = "SIS.xDMS.xDmsItemTypes"
  InsertMethod="UZ_xDmsItemTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsItemTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
