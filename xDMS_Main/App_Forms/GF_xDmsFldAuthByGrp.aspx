<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_xDmsFldAuthByGrp.aspx.vb" Inherits="GF_xDmsFldAuthByGrp" title="Maintain List: DMS Folder Authorizations By Group" %>
<asp:Content ID="CPHxDmsFldAuthByGrp" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelxDmsFldAuthByGrp" runat="server" Text="&nbsp;List: DMS Folder Authorizations By Group"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFldAuthByGrp" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLxDmsFldAuthByGrp"
      ToolType = "lgNMGrid"
      EditUrl = "~/xDMS_Main/App_Edit/EF_xDmsFldAuthByGrp.aspx"
      EnableAdd = "False"
      ValidationGroup = "xDmsFldAuthByGrp"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSxDmsFldAuthByGrp" runat="server" AssociatedUpdatePanelID="UPNLxDmsFldAuthByGrp" DisplayAfter="100">
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
          <b><asp:Label ID="L_GroupID" runat="server" Text="GroupID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_GroupID"
            Text=""
            Width="88px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEGroupID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_GroupID" />
          <AJX:MaskedEditValidator 
            ID = "MEVGroupID"
            runat = "server"
            ControlToValidate = "F_GroupID"
            ControlExtender = "MEEGroupID"
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
    <asp:GridView ID="GVxDmsFldAuthByGrp" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsFldAuthByGrp" DataKeyNames="GroupID,UserID,FolderID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="User ID" SortExpression="[aspnet_users2].[UserFullName]">
          <ItemTemplate>
             <asp:Label ID="L_UserID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UserID") %>' Text='<%# Eval("aspnet_users2_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Folder ID" SortExpression="[xDMS_Folders3].[FolderName]">
          <ItemTemplate>
             <asp:Label ID="L_FolderID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("FolderID") %>' Text='<%# Eval("xDMS_Folders3_FolderName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Create Folder" SortExpression="[xDMS_FolderAuthorizations].[CreateFolder]">
          <ItemTemplate>
            <asp:Label ID="LabelCreateFolder" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreateFolder") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Update Folder" SortExpression="[xDMS_FolderAuthorizations].[UpdateFolder]">
          <ItemTemplate>
            <asp:Label ID="LabelUpdateFolder" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UpdateFolder") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete Folder" SortExpression="[xDMS_FolderAuthorizations].[DeleteFolder]">
          <ItemTemplate>
            <asp:Label ID="LabelDeleteFolder" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DeleteFolder") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Upload File" SortExpression="[xDMS_FolderAuthorizations].[UploadFile]">
          <ItemTemplate>
            <asp:Label ID="LabelUploadFile" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UploadFile") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Download File" SortExpression="[xDMS_FolderAuthorizations].[DownloadFile]">
          <ItemTemplate>
            <asp:Label ID="LabelDownloadFile" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DownloadFile") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete File" SortExpression="[xDMS_FolderAuthorizations].[DeleteFile]">
          <ItemTemplate>
            <asp:Label ID="LabelDeleteFile" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DeleteFile") %>'></asp:Label>
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
      ID = "ODSxDmsFldAuthByGrp"
      runat = "server"
      DataObjectTypeName = "SIS.xDMS.xDmsFldAuthByGrp"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_xDmsFldAuthByGrpSelectList"
      TypeName = "SIS.xDMS.xDmsFldAuthByGrp"
      SelectCountMethod = "xDmsFldAuthByGrpSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_GroupID" PropertyName="Text" Name="GroupID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVxDmsFldAuthByGrp" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_GroupID" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
