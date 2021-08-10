<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_xDmsWorkflows.aspx.vb" Inherits="GF_xDmsWorkflows" title="Maintain List: Workflows" %>
<asp:Content ID="CPHxDmsWorkflows" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelxDmsWorkflows" runat="server" Text="&nbsp;List: Workflows"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsWorkflows" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLxDmsWorkflows"
      ToolType = "lgNMGrid"
      EditUrl = "~/xDMS_Main/App_Edit/EF_xDmsWorkflows.aspx"
      AddUrl = "~/xDMS_Main/App_Create/AF_xDmsWorkflows.aspx"
      ValidationGroup = "xDmsWorkflows"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSxDmsWorkflows" runat="server" AssociatedUpdatePanelID="UPNLxDmsWorkflows" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVxDmsWorkflows" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsWorkflows" DataKeyNames="WorkflowID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Workflow ID" SortExpression="[xDMS_Workflows].[WorkflowID]">
          <ItemTemplate>
            <asp:Label ID="LabelWorkflowID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WorkflowID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Workflow Name" SortExpression="[xDMS_Workflows].[WorkflowName]">
          <ItemTemplate>
            <asp:Label ID="LabelWorkflowName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("WorkflowName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Parent Workflow" SortExpression="[xDMS_Workflows5].[WorkflowName]">
          <ItemTemplate>
             <asp:Label ID="L_ParentWorkflowID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ParentWorkflowID") %>' Text='<%# Eval("xDMS_Workflows5_WorkflowName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Initial Status" SortExpression="[xDMS_States3].[StatusName]">
          <ItemTemplate>
             <asp:Label ID="L_InitialStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("InitialStatusID") %>' Text='<%# Eval("xDMS_States3_StatusName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Final Status" SortExpression="[xDMS_States4].[StatusName]">
          <ItemTemplate>
             <asp:Label ID="L_FinalStatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("FinalStatusID") %>' Text='<%# Eval("xDMS_States4_StatusName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Executed by User" SortExpression="[aspnet_users1].[UserFullName]">
          <ItemTemplate>
             <asp:Label ID="L_UserID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UserID") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Executed by User Group" SortExpression="[xDMS_Groups2].[Description]">
          <ItemTemplate>
             <asp:Label ID="L_GroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("GroupID") %>' Text='<%# Eval("xDMS_Groups2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSxDmsWorkflows"
      runat = "server"
      DataObjectTypeName = "SIS.xDMS.xDmsWorkflows"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_xDmsWorkflowsSelectList"
      TypeName = "SIS.xDMS.xDmsWorkflows"
      SelectCountMethod = "xDmsWorkflowsSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVxDmsWorkflows" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
