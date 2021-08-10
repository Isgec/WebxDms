<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_xDmsFileTypes.aspx.vb" Inherits="GF_xDmsFileTypes" title="Maintain List: File Types" %>
<asp:Content ID="CPHxDmsFileTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelxDmsFileTypes" runat="server" Text="&nbsp;List: File Types"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFileTypes" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLxDmsFileTypes"
      ToolType = "lgNMGrid"
      EditUrl = "~/xDMS_Main/App_Edit/EF_xDmsFileTypes.aspx"
      AddUrl = "~/xDMS_Main/App_Create/AF_xDmsFileTypes.aspx"
      ValidationGroup = "xDmsFileTypes"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSxDmsFileTypes" runat="server" AssociatedUpdatePanelID="UPNLxDmsFileTypes" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVxDmsFileTypes" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsFileTypes" DataKeyNames="FileTypeID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="File Type ID" SortExpression="[xDMS_FileTypes].[FileTypeID]">
          <ItemTemplate>
            <asp:Label ID="LabelFileTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileTypeID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="File Type Name" SortExpression="[xDMS_FileTypes].[FileTypeName]">
          <ItemTemplate>
            <asp:Label ID="LabelFileTypeName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileTypeName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Based On File Extension" SortExpression="[xDMS_FileTypes].[BasedOnFileExtension]">
          <ItemTemplate>
            <asp:Label ID="LabelBasedOnFileExtension" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("BasedOnFileExtension") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="File Extention List" SortExpression="[xDMS_FileTypes].[FileExtentionList]">
          <ItemTemplate>
            <asp:Label ID="LabelFileExtentionList" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileExtentionList") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
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
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSxDmsFileTypes"
      runat = "server"
      DataObjectTypeName = "SIS.xDMS.xDmsFileTypes"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_xDmsFileTypesSelectList"
      TypeName = "SIS.xDMS.xDmsFileTypes"
      SelectCountMethod = "xDmsFileTypesSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVxDmsFileTypes" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
