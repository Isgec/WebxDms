<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_xDmsERPTransmittalTypes.aspx.vb" Inherits="AF_xDmsERPTransmittalTypes" title="Add: ERP Transmittal Types" %>
<asp:Content ID="CPHxDmsERPTransmittalTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsERPTransmittalTypes" runat="server" Text="&nbsp;Add: ERP Transmittal Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsERPTransmittalTypes" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsERPTransmittalTypes"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "xDmsERPTransmittalTypes"
    runat = "server" />
<asp:FormView ID="FVxDmsERPTransmittalTypes"
  runat = "server"
  DataKeyNames = "TransmittalTypeID"
  DataSourceID = "ODSxDmsERPTransmittalTypes"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgxDmsERPTransmittalTypes" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_TransmittalTypeID" ForeColor="#CC6633" runat="server" Text="Transmitta lType :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TransmittalTypeID"
            Text='<%# Bind("TransmittalTypeID") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mypktxt"
            ValidationGroup="xDmsERPTransmittalTypes"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEETransmittalTypeID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_TransmittalTypeID" />
          <AJX:MaskedEditValidator 
            ID = "MEVTransmittalTypeID"
            runat = "server"
            ControlToValidate = "F_TransmittalTypeID"
            ControlExtender = "MEETransmittalTypeID"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsERPTransmittalTypes"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_TransmittalTypeName" runat="server" Text="Transmittal Type Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_TransmittalTypeName"
            Text='<%# Bind("TransmittalTypeName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsERPTransmittalTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Transmittal Type Name."
            MaxLength="50"
            Width="408px"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSxDmsERPTransmittalTypes"
  DataObjectTypeName = "SIS.xDMS.xDmsERPTransmittalTypes"
  InsertMethod="xDmsERPTransmittalTypesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsERPTransmittalTypes"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
