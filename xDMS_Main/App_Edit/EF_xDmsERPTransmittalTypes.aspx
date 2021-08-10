<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_xDmsERPTransmittalTypes.aspx.vb" Inherits="EF_xDmsERPTransmittalTypes" title="Edit: ERP Transmittal Types" %>
<asp:Content ID="CPHxDmsERPTransmittalTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsERPTransmittalTypes" runat="server" Text="&nbsp;Edit: ERP Transmittal Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsERPTransmittalTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsERPTransmittalTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "xDmsERPTransmittalTypes"
    runat = "server" />
<asp:FormView ID="FVxDmsERPTransmittalTypes"
  runat = "server"
  DataKeyNames = "TransmittalTypeID"
  DataSourceID = "ODSxDmsERPTransmittalTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TransmittalTypeID" runat="server" ForeColor="#CC6633" Text="Transmitta lType :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TransmittalTypeID"
            Text='<%# Bind("TransmittalTypeID") %>'
            ToolTip="Value of Transmitta lType."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TransmittalTypeName" runat="server" Text="Transmittal Type Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TransmittalTypeName"
            Text='<%# Bind("TransmittalTypeName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsERPTransmittalTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Transmittal Type Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVTransmittalTypeName"
            runat = "server"
            ControlToValidate = "F_TransmittalTypeName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsERPTransmittalTypes"
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
  ID = "ODSxDmsERPTransmittalTypes"
  DataObjectTypeName = "SIS.xDMS.xDmsERPTransmittalTypes"
  SelectMethod = "xDmsERPTransmittalTypesGetByID"
  UpdateMethod="xDmsERPTransmittalTypesUpdate"
  DeleteMethod="xDmsERPTransmittalTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsERPTransmittalTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="TransmittalTypeID" Name="TransmittalTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
