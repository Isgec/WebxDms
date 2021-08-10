<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_xDmsStates.aspx.vb" Inherits="GF_xDmsStates" title="Maintain List: States" %>
<asp:Content ID="CPHxDmsStates" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelxDmsStates" runat="server" Text="&nbsp;List: States"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsStates" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLxDmsStates"
      ToolType = "lgNMGrid"
      EditUrl = "~/xDMS_Main/App_Edit/EF_xDmsStates.aspx"
      AddUrl = "~/xDMS_Main/App_Create/AF_xDmsStates.aspx"
      ValidationGroup = "xDmsStates"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSxDmsStates" runat="server" AssociatedUpdatePanelID="UPNLxDmsStates" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVxDmsStates" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsStates" DataKeyNames="StatusID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="[xDMS_States].[StatusID]">
          <ItemTemplate>
            <asp:Label ID="LabelStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StatusID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status Name" SortExpression="[xDMS_States].[StatusName]">
          <ItemTemplate>
            <asp:Label ID="LabelStatusName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StatusName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Base Status" SortExpression="[xDMS_States].[BaseStatusID]">
          <ItemTemplate>
            <asp:Label ID="LabelBaseStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BaseStatusID") %>'></asp:Label>
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
      ID = "ODSxDmsStates"
      runat = "server"
      DataObjectTypeName = "SIS.xDMS.xDmsStates"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_xDmsStatesSelectList"
      TypeName = "SIS.xDMS.xDmsStates"
      SelectCountMethod = "xDmsStatesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVxDmsStates" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
