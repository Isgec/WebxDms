<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_xDmsERPTransmittalTypes.aspx.vb" Inherits="GF_xDmsERPTransmittalTypes" title="Maintain List: ERP Transmittal Types" %>
<asp:Content ID="CPHxDmsERPTransmittalTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelxDmsERPTransmittalTypes" runat="server" Text="&nbsp;List: ERP Transmittal Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsERPTransmittalTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLxDmsERPTransmittalTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/xDMS_Main/App_Edit/EF_xDmsERPTransmittalTypes.aspx"
      AddUrl = "~/xDMS_Main/App_Create/AF_xDmsERPTransmittalTypes.aspx"
      ValidationGroup = "xDmsERPTransmittalTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSxDmsERPTransmittalTypes" runat="server" AssociatedUpdatePanelID="UPNLxDmsERPTransmittalTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVxDmsERPTransmittalTypes" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsERPTransmittalTypes" DataKeyNames="TransmittalTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Transmitta lType" SortExpression="[xDMS_ERPTransmittalTypes].[TransmittalTypeID]">
          <ItemTemplate>
            <asp:Label ID="LabelTransmittalTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TransmittalTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Transmittal Type Name" SortExpression="[xDMS_ERPTransmittalTypes].[TransmittalTypeName]">
          <ItemTemplate>
            <asp:Label ID="LabelTransmittalTypeName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("TransmittalTypeName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSxDmsERPTransmittalTypes"
      runat = "server"
      DataObjectTypeName = "SIS.xDMS.xDmsERPTransmittalTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "xDmsERPTransmittalTypesSelectList"
      TypeName = "SIS.xDMS.xDmsERPTransmittalTypes"
      SelectCountMethod = "xDmsERPTransmittalTypesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVxDmsERPTransmittalTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
