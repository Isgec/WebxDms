<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_xDmsItemTypes.aspx.vb" Inherits="GF_xDmsItemTypes" title="Maintain List: Item Types" %>
<asp:Content ID="CPHxDmsItemTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelxDmsItemTypes" runat="server" Text="&nbsp;List: Item Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsItemTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLxDmsItemTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/xDMS_Main/App_Edit/EF_xDmsItemTypes.aspx"
      AddUrl = "~/xDMS_Main/App_Create/AF_xDmsItemTypes.aspx"
      ValidationGroup = "xDmsItemTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSxDmsItemTypes" runat="server" AssociatedUpdatePanelID="UPNLxDmsItemTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVxDmsItemTypes" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsItemTypes" DataKeyNames="ItemTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Type" SortExpression="[xDMS_ItemTypes].[ItemTypeID]">
          <ItemTemplate>
            <asp:Label ID="LabelItemTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Name" SortExpression="[xDMS_ItemTypes].[ItemName]">
          <ItemTemplate>
            <asp:Label ID="LabelItemName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ItemName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Base Type" SortExpression="[xDMS_ItemTypes].[BaseTypeID]">
          <ItemTemplate>
            <asp:Label ID="LabelBaseTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BaseTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSxDmsItemTypes"
      runat = "server"
      DataObjectTypeName = "SIS.xDMS.xDmsItemTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_xDmsItemTypesSelectList"
      TypeName = "SIS.xDMS.xDmsItemTypes"
      SelectCountMethod = "xDmsItemTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVxDmsItemTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
