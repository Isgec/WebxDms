<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="False" CodeFile="GF_xDmsFolderAuthorizations.aspx.vb" Inherits="GF_xDmsFolderAuthorizations" title="Maintain List: DMS Folder Authorizations" %>
<asp:Content ID="CPHxDmsFolderAuthorizations" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelxDmsFolderAuthorizations" runat="server" Text="&nbsp;List: DMS Folder Authorizations"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFolderAuthorizations" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLxDmsFolderAuthorizations"
      ToolType = "lgNMGrid"
      EditUrl = "~/xDMS_Main/App_Edit/EF_xDmsFolderAuthorizations.aspx"
      AddUrl = "~/xDMS_Main/App_Create/AF_xDmsFolderAuthorizations.aspx"
      ValidationGroup = "xDmsFolderAuthorizations"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSxDmsFolderAuthorizations" runat="server" AssociatedUpdatePanelID="UPNLxDmsFolderAuthorizations" DisplayAfter="100">
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
          <b><asp:Label ID="L_UserID" runat="server" Text="User ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_UserID"
            CssClass = "mypktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_UserID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_UserID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUserID"
            BehaviorID="B_ACEUserID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UserIDCompletionList"
            TargetControlID="F_UserID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEUserID_Selected"
            OnClientPopulating="ACEUserID_Populating"
            OnClientPopulated="ACEUserID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FolderID" runat="server" Text="Folder ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FolderID"
            CssClass = "mypktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_FolderID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_FolderID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFolderID"
            BehaviorID="B_ACEFolderID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FolderIDCompletionList"
            TargetControlID="F_FolderID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEFolderID_Selected"
            OnClientPopulating="ACEFolderID_Populating"
            OnClientPopulated="ACEFolderID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            CssClass = "myfktxt"
            Width="72px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_CreatedBy(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECreatedBy"
            BehaviorID="B_ACECreatedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CreatedByCompletionList"
            TargetControlID="F_CreatedBy"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACECreatedBy_Selected"
            OnClientPopulating="ACECreatedBy_Populating"
            OnClientPopulated="ACECreatedBy_Populated"
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
    <asp:GridView ID="GVxDmsFolderAuthorizations" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsFolderAuthorizations" DataKeyNames="UserID,FolderID">
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
      ID = "ODSxDmsFolderAuthorizations"
      runat = "server"
      DataObjectTypeName = "SIS.xDMS.xDmsFolderAuthorizations"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_xDmsFolderAuthorizationsSelectList"
      TypeName = "SIS.xDMS.xDmsFolderAuthorizations"
      SelectCountMethod = "xDmsFolderAuthorizationsSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_UserID" PropertyName="Text" Name="UserID" Type="String" Size="8" />
        <asp:ControlParameter ControlID="F_FolderID" PropertyName="Text" Name="FolderID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_CreatedBy" PropertyName="Text" Name="CreatedBy" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVxDmsFolderAuthorizations" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_UserID" />
    <asp:AsyncPostBackTrigger ControlID="F_FolderID" />
    <asp:AsyncPostBackTrigger ControlID="F_CreatedBy" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
