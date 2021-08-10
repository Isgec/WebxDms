<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_xDmsHFiles.aspx.vb" Inherits="GF_xDmsHFiles" title="Maintain List: Files History" %>
<asp:Content ID="CPHxDmsHFiles" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelxDmsHFiles" runat="server" Text="&nbsp;List: Files History"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsHFiles" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLxDmsHFiles"
      ToolType = "lgNMGrid"
      EditUrl = "~/xDMS_Main/App_Edit/EF_xDmsHFiles.aspx"
      AddUrl = "~/xDMS_Main/App_Create/AF_xDmsHFiles.aspx"
      ValidationGroup = "xDmsHFiles"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSxDmsHFiles" runat="server" AssociatedUpdatePanelID="UPNLxDmsHFiles" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
      <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
        <div style="float: left;">Filter Records </div>
        <div style="float: left; margin-left: 20px;">
          <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
        </div>
        <div style="float: right; vertical-align: middle;">
          <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
        </div>
      </div>
    </asp:Panel>
    <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
    <table>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FileID" runat="server" Text="FileID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_FileID"
            Text=""
            Width="88px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEFileID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FileID" />
          <AJX:MaskedEditValidator 
            ID = "MEVFileID"
            runat = "server"
            ControlToValidate = "F_FileID"
            ControlExtender = "MEEFileID"
            InvalidValueMessage = "*"
            EmptyValueMessage = ""
            EmptyValueBlurredText = ""
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVxDmsHFiles" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsHFiles" DataKeyNames="FileID,HFileID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FileID" SortExpression="[xDMS_HFiles].[FileID]">
          <ItemTemplate>
            <asp:Label ID="LabelFileID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="HFileID" SortExpression="[xDMS_HFiles].[HFileID]">
          <ItemTemplate>
            <asp:Label ID="LabelHFileID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("HFileID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FileName" SortExpression="[xDMS_HFiles].[FileName]">
          <ItemTemplate>
            <asp:Label ID="LabelFileName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FileRev" SortExpression="[xDMS_HFiles].[FileRev]">
          <ItemTemplate>
            <asp:Label ID="LabelFileRev" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileRev") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ItemTypeID" SortExpression="[xDMS_ItemTypes6].[ItemName]">
          <ItemTemplate>
             <asp:Label ID="L_ItemTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemTypeID") %>' Text='<%# Eval("xDMS_ItemTypes6_ItemName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FolderID" SortExpression="[xDMS_Folders4].[FolderName]">
          <ItemTemplate>
             <asp:Label ID="L_FolderID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("FolderID") %>' Text='<%# Eval("xDMS_Folders4_FolderName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="StatusID" SortExpression="[xDMS_States7].[StatusName]">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("xDMS_States7_StatusName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="StatusBy" SortExpression="[aspnet_users2].[UserFullName]">
          <ItemTemplate>
             <asp:Label ID="L_StatusBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusBy") %>' Text='<%# Eval("aspnet_users2_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="StatusOn" SortExpression="[xDMS_HFiles].[StatusOn]">
          <ItemTemplate>
            <asp:Label ID="LabelStatusOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StatusOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="StatusRemarks" SortExpression="[xDMS_HFiles].[StatusRemarks]">
          <ItemTemplate>
            <asp:Label ID="LabelStatusRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StatusRemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="VaultDRID" SortExpression="[xDMS_HFiles].[VaultDRID]">
          <ItemTemplate>
            <asp:Label ID="LabelVaultDRID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VaultDRID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FileExtn" SortExpression="[xDMS_HFiles].[FileExtn]">
          <ItemTemplate>
            <asp:Label ID="LabelFileExtn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileExtn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FileSize" SortExpression="[xDMS_HFiles].[FileSize]">
          <ItemTemplate>
            <asp:Label ID="LabelFileSize" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileSize") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="KeyWords" SortExpression="[xDMS_HFiles].[KeyWords]">
          <ItemTemplate>
            <asp:Label ID="LabelKeyWords" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("KeyWords") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Active" SortExpression="[xDMS_HFiles].[Active]">
          <ItemTemplate>
            <asp:Label ID="LabelActive" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Active") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ParentIFileID" SortExpression="[xDMS_HFiles].[ParentIFileID]">
          <ItemTemplate>
            <asp:Label ID="LabelParentIFileID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("ParentIFileID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="NodeLevel" SortExpression="[xDMS_HFiles].[NodeLevel]">
          <ItemTemplate>
            <asp:Label ID="LabelNodeLevel" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("NodeLevel") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Hseq" SortExpression="[xDMS_HFiles].[Hseq]">
          <ItemTemplate>
            <asp:Label ID="LabelHseq" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Hseq") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="FileTypeID" SortExpression="[xDMS_FileTypes3].[FileTypeName]">
          <ItemTemplate>
             <asp:Label ID="L_FileTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("FileTypeID") %>' Text='<%# Eval("xDMS_FileTypes3_FileTypeName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="WorkflowID" SortExpression="[xDMS_Workflows8].[WorkflowName]">
          <ItemTemplate>
             <asp:Label ID="L_WorkflowID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("WorkflowID") %>' Text='<%# Eval("xDMS_Workflows8_WorkflowName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="WorkflowStepID" SortExpression="[xDMS_Workflows10].[WorkflowName]">
          <ItemTemplate>
             <asp:Label ID="L_WorkflowStepID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("WorkflowStepID") %>' Text='<%# Eval("xDMS_Workflows10_WorkflowName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="WorkflowNextStepID" SortExpression="[xDMS_Workflows9].[WorkflowName]">
          <ItemTemplate>
             <asp:Label ID="L_WorkflowNextStepID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("WorkflowNextStepID") %>' Text='<%# Eval("xDMS_Workflows9_WorkflowName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UserID" SortExpression="[aspnet_users1].[UserFullName]">
          <ItemTemplate>
             <asp:Label ID="L_UserID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UserID") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GroupID" SortExpression="[xDMS_Groups5].[Description]">
          <ItemTemplate>
             <asp:Label ID="L_GroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("GroupID") %>' Text='<%# Eval("xDMS_Groups5_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="SystemRemarks" SortExpression="[xDMS_HFiles].[SystemRemarks]">
          <ItemTemplate>
            <asp:Label ID="LabelSystemRemarks" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("SystemRemarks") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Purgable" SortExpression="[xDMS_HFiles].[Purgable]">
          <ItemTemplate>
            <asp:Label ID="LabelPurgable" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("Purgable") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="CreatedOn" SortExpression="[xDMS_HFiles].[CreatedOn]">
          <ItemTemplate>
            <asp:Label ID="LabelCreatedOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreatedOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSxDmsHFiles"
      runat = "server"
      DataObjectTypeName = "SIS.xDMS.xDmsHFiles"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_xDmsHFilesSelectList"
      TypeName = "SIS.xDMS.xDmsHFiles"
      SelectCountMethod = "xDmsHFilesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_FileID" PropertyName="Text" Name="FileID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVxDmsHFiles" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_FileID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
