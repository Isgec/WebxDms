<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_xDmsFGroups.aspx.vb" Inherits="GF_xDmsFGroups" title="Maintain List: Folder Groups" %>
<asp:Content ID="CPHxDmsFGroups" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelxDmsFGroups" runat="server" Text="&nbsp;List: Folder Groups"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFGroups" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLxDmsFGroups"
      ToolType = "lgNMGrid"
      EditUrl = "~/xDMS_Main/App_Edit/EF_xDmsFGroups.aspx"
      AddUrl = "~/xDMS_Main/App_Create/AF_xDmsFGroups.aspx?skip=1"
      ValidationGroup = "xDmsFGroups"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSxDmsFGroups" runat="server" AssociatedUpdatePanelID="UPNLxDmsFGroups" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVxDmsFGroups" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsFGroups" DataKeyNames="FGroupID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Folder Group ID" SortExpression="[xDMS_FGroups].[FGroupID]">
          <ItemTemplate>
            <asp:Label ID="LabelFGroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FGroupID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Folder Group Name" SortExpression="[xDMS_FGroups].[FGroupName]">
          <ItemTemplate>
            <asp:Label ID="LabelFGroupName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FGroupName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Require Explicit Authorization" SortExpression="[xDMS_FGroups].[RequireExplicitAuthorization]">
          <ItemTemplate>
            <asp:Label ID="LabelRequireExplicitAuthorization" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequireExplicitAuthorization") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Require Explicit Workflow" SortExpression="[xDMS_FGroups].[RequireExplicitWorkflow]">
          <ItemTemplate>
            <asp:Label ID="LabelRequireExplicitWorkflow" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("RequireExplicitWorkflow") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Release Workflow" SortExpression="[xDMS_Workflows1].[WorkflowName]">
          <ItemTemplate>
             <asp:Label ID="L_ReleaseWorkflowID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ReleaseWorkflowID") %>' Text='<%# Eval("xDMS_Workflows1_WorkflowName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Revise Workflow" SortExpression="[xDMS_Workflows2].[WorkflowName]">
          <ItemTemplate>
             <asp:Label ID="L_ReviseWorkflowID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ReviseWorkflowID") %>' Text='<%# Eval("xDMS_Workflows2_WorkflowName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSxDmsFGroups"
      runat = "server"
      DataObjectTypeName = "SIS.xDMS.xDmsFGroups"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_xDmsFGroupsSelectList"
      TypeName = "SIS.xDMS.xDmsFGroups"
      SelectCountMethod = "xDmsFGroupsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVxDmsFGroups" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
