<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_cDmsERPMapping.aspx.vb" Inherits="GF_cDmsERPMapping" title="Maintain List: ERP Mapping" %>
<asp:Content ID="CPHcDmsERPMapping" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelcDmsERPMapping" runat="server" Text="&nbsp;List: ERP Mapping"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLcDmsERPMapping" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLcDmsERPMapping"
      ToolType = "lgNMGrid"
      EditUrl = "~/xDMS_Main/App_Edit/EF_cDmsERPMapping.aspx"
      AddUrl = "~/xDMS_Main/App_Create/AF_cDmsERPMapping.aspx"
      ValidationGroup = "cDmsERPMapping"
      runat = "server" />
    <asp:UpdateProgress ID="UPGScDmsERPMapping" runat="server" AssociatedUpdatePanelID="UPNLcDmsERPMapping" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVcDmsERPMapping" SkinID="gv_silver" runat="server" DataSourceID="ODScDmsERPMapping" DataKeyNames="SerialNo">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Seria lNo" SortExpression="[xDMS_ERPMapping].[SerialNo]">
          <ItemTemplate>
            <asp:Label ID="LabelSerialNo" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SerialNo") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Transmittal Type" SortExpression="[xDMS_ERPTransmittalTypes1].[TransmittalTypeName]">
          <ItemTemplate>
             <asp:Label ID="L_TransmittalTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("TransmittalTypeID") %>' Text='<%# Eval("xDMS_ERPTransmittalTypes1_TransmittalTypeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Folder Name" SortExpression="[xDMS_ERPMapping].[FolderName]">
          <ItemTemplate>
            <asp:Label ID="LabelFolderName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FolderName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Parent Folder" SortExpression="[xDMS_Folders2].[FolderName]">
          <ItemTemplate>
             <asp:Label ID="L_ParentFolderID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ParentFolderID") %>' Text='<%# Eval("xDMS_Folders2_FolderName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Initial Workflow" SortExpression="[xDMS_Workflows3].[WorkflowName]">
          <ItemTemplate>
             <asp:Label ID="L_InitialWorkflowID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("InitialWorkflowID") %>' Text='<%# Eval("xDMS_Workflows3_WorkflowName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Release Workflow" SortExpression="[xDMS_Workflows4].[WorkflowName]">
          <ItemTemplate>
             <asp:Label ID="L_ReleaseWorkflowID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ReleaseWorkflowID") %>' Text='<%# Eval("xDMS_Workflows4_WorkflowName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Revise Workflow" SortExpression="[xDMS_Workflows5].[WorkflowName]">
          <ItemTemplate>
             <asp:Label ID="L_ReviseWorkflowID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ReviseWorkflowID") %>' Text='<%# Eval("xDMS_Workflows5_WorkflowName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Active" SortExpression="[xDMS_ERPMapping].[Active]">
          <ItemTemplate>
            <asp:Label ID="LabelActive" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Active") %>'></asp:Label>
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
      ID = "ODScDmsERPMapping"
      runat = "server"
      DataObjectTypeName = "SIS.xDMS.cDmsERPMapping"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "cDmsERPMappingSelectList"
      TypeName = "SIS.xDMS.cDmsERPMapping"
      SelectCountMethod = "cDmsERPMappingSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVcDmsERPMapping" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
