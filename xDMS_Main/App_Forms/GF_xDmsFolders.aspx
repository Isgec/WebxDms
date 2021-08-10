<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_xDmsFolders.aspx.vb" Inherits="GF_xDmsFolders" title="Maintain List: DMS Folders" %>
<asp:Content ID="CPHxDmsFolders" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelxDmsFolders" runat="server" Text="&nbsp;List: DMS Folders"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFolders" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLxDmsFolders"
      ToolType = "lgNMGrid"
      EditUrl = "~/xDMS_Main/App_Edit/EF_xDmsFolders.aspx"
      AddUrl = "~/xDMS_Main/App_Create/AF_xDmsFolders.aspx"
      ValidationGroup = "xDmsFolders"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSxDmsFolders" runat="server" AssociatedUpdatePanelID="UPNLxDmsFolders" DisplayAfter="100">
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
          <b><asp:Label ID="L_FolderID" runat="server" Text="Folder ID :" /></b>
        </td>
        <td>
          <asp:TextBox ID="F_FolderID"
            Text=""
            Width="88px"
            style="text-align: right"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEFolderID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FolderID" />
          <AJX:MaskedEditValidator 
            ID = "MEVFolderID"
            runat = "server"
            ControlToValidate = "F_FolderID"
            ControlExtender = "MEEFolderID"
            InvalidValueMessage = "*"
            EmptyValueMessage = ""
            EmptyValueBlurredText = ""
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ParentFolderID" runat="server" Text="Parent Folder :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ParentFolderID"
            CssClass = "myfktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ParentFolderID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ParentFolderID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEParentFolderID"
            BehaviorID="B_ACEParentFolderID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ParentFolderIDCompletionList"
            TargetControlID="F_ParentFolderID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEParentFolderID_Selected"
            OnClientPopulating="ACEParentFolderID_Populating"
            OnClientPopulated="ACEParentFolderID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_StatusBy" runat="server" Text="Status By :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_StatusBy"
            CssClass = "myfktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_StatusBy(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusBy_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEStatusBy"
            BehaviorID="B_ACEStatusBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="StatusByCompletionList"
            TargetControlID="F_StatusBy"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEStatusBy_Selected"
            OnClientPopulating="ACEStatusBy_Populating"
            OnClientPopulated="ACEStatusBy_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </asp:Panel>
    <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
    <asp:GridView ID="GVxDmsFolders" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsFolders" DataKeyNames="FolderID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Folder ID" SortExpression="[xDMS_Folders].[FolderID]">
          <ItemTemplate>
            <asp:Label ID="LabelFolderID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FolderID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Folder Name" SortExpression="[xDMS_Folders].[FolderName]">
          <ItemTemplate>
            <asp:Label ID="LabelFolderName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FolderName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Type " SortExpression="[xDMS_ItemTypes3].[ItemName]">
          <ItemTemplate>
             <asp:Label ID="L_ItemTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemTypeID") %>' Text='<%# Eval("xDMS_ItemTypes3_ItemName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Parent Folder" SortExpression="[xDMS_Folders2].[FolderName]">
          <ItemTemplate>
             <asp:Label ID="L_ParentFolderID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ParentFolderID") %>' Text='<%# Eval("xDMS_Folders2_FolderName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status By" SortExpression="[aspnet_users1].[UserFullName]">
          <ItemTemplate>
             <asp:Label ID="L_StatusBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status On" SortExpression="[xDMS_Folders].[StatusOn]">
          <ItemTemplate>
            <asp:Label ID="LabelStatusOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StatusOn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="90px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="[xDMS_States4].[StatusName]">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("xDMS_States4_StatusName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
      </Columns>
      <EmptyDataTemplate>
        <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
      </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource 
      ID = "ODSxDmsFolders"
      runat = "server"
      DataObjectTypeName = "SIS.xDMS.xDmsFolders"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_xDmsFoldersSelectList"
      TypeName = "SIS.xDMS.xDmsFolders"
      SelectCountMethod = "xDmsFoldersSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_FolderID" PropertyName="Text" Name="FolderID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ParentFolderID" PropertyName="Text" Name="ParentFolderID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_StatusBy" PropertyName="Text" Name="StatusBy" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVxDmsFolders" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_FolderID" />
    <asp:AsyncPostBackTrigger ControlID="F_ParentFolderID" />
    <asp:AsyncPostBackTrigger ControlID="F_StatusBy" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
