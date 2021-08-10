<%@ Page Language="VB" MasterPageFile="~/PlaneMaster.master" AutoEventWireup="False" CodeFile="GF_xDmsFiles.aspx.vb" Inherits="GF_xDmsFiles" title="Maintain List: DMS Files" %>
<asp:Content ID="CPHxDmsFiles" ContentPlaceHolderID="cph1" Runat="Server">
<div class="ui-widget-content page">
<div class="caption">
    <asp:Label ID="LabelxDmsFiles" runat="server" Text="&nbsp;List: DMS Files"></asp:Label>
</div>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFiles" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLxDmsFiles"
      ToolType = "lgNMGrid"
      EditUrl = "~/xDMS_Main/App_Edit/EF_xDmsFiles.aspx"
      AddUrl = "~/xDMS_Main/App_Create/AF_xDmsFiles.aspx"
      ValidationGroup = "xDmsFiles"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSxDmsFiles" runat="server" AssociatedUpdatePanelID="UPNLxDmsFiles" DisplayAfter="100">
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
          <b><asp:Label ID="L_FileID" runat="server" Text="File ID :" /></b>
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
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FolderID" runat="server" Text="Folder :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FolderID"
            CssClass = "myfktxt"
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
          <b><asp:Label ID="L_StatusID" runat="server" Text="Status :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_StatusID"
            CssClass = "myfktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_StatusID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEStatusID"
            BehaviorID="B_ACEStatusID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="StatusIDCompletionList"
            TargetControlID="F_StatusID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEStatusID_Selected"
            OnClientPopulating="ACEStatusID_Populating"
            OnClientPopulated="ACEStatusID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_ParentIFileID" runat="server" Text="ParentI File ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ParentIFileID"
            CssClass = "myfktxt"
            Width="88px"
            Text=""
            onfocus = "return this.select();"
            AutoCompleteType = "None"
            onblur= "validate_ParentIFileID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ParentIFileID_Display"
            Text=""
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEParentIFileID"
            BehaviorID="B_ACEParentIFileID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ParentIFileIDCompletionList"
            TargetControlID="F_ParentIFileID"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="ACEParentIFileID_Selected"
            OnClientPopulating="ACEParentIFileID_Populating"
            OnClientPopulated="ACEParentIFileID_Populated"
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
    <asp:GridView ID="GVxDmsFiles" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsFiles" DataKeyNames="FileID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="File ID" SortExpression="[xDMS_Files].[FileID]">
          <ItemTemplate>
            <asp:Label ID="LabelFileID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="40px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="File Name" SortExpression="[xDMS_Files].[FileName]">
          <ItemTemplate>
            <asp:Label ID="LabelFileName" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileName") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="File Rev" SortExpression="[xDMS_Files].[FileRev]">
          <ItemTemplate>
            <asp:Label ID="LabelFileRev" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileRev") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="50px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Type" SortExpression="[xDMS_ItemTypes4].[ItemName]">
          <ItemTemplate>
             <asp:Label ID="L_ItemTypeID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("ItemTypeID") %>' Text='<%# Eval("xDMS_ItemTypes4_ItemName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Folder" SortExpression="[xDMS_Folders3].[FolderName]">
          <ItemTemplate>
             <asp:Label ID="L_FolderID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("FolderID") %>' Text='<%# Eval("xDMS_Folders3_FolderName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vault DRID" SortExpression="[xDMS_Files].[VaultDRID]">
          <ItemTemplate>
            <asp:Label ID="LabelVaultDRID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("VaultDRID") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="File Extn" SortExpression="[xDMS_Files].[FileExtn]">
          <ItemTemplate>
            <asp:Label ID="LabelFileExtn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileExtn") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
        <HeaderStyle CssClass="alignCenter" Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="File Size" SortExpression="[xDMS_Files].[FileSize]">
          <ItemTemplate>
            <asp:Label ID="LabelFileSize" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileSize") %>'></asp:Label>
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="80px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Status" SortExpression="[xDMS_States5].[StatusName]">
          <ItemTemplate>
             <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("xDMS_States5_StatusName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
                    <asp:TemplateField>
                      <HeaderTemplate>
                        <asp:Button ID="ToggalSelection" runat="server" CssClass="nt-but-warning" Text="&nbsp;&nbsp;&nbsp;" ToolTip="Change Selection" CommandName="ToggleSelect" />
                      </HeaderTemplate>
                      <ItemTemplate>
                        <asp:CheckBox ID="chkSelect" runat="server" Visible='<%# Eval("SelectWFVisible") %>' ToolTip="Select" Checked='<%# Bind("Selected") %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <HeaderTemplate>
                        <asp:Button ID="DeleteSelected" CommandName="DeleteSelected" runat="server" CssClass="nt-but-danger" Text="Delete" ToolTip="Delete Selected" OnClientClick="return confirm('Selected Records will be deleted, Do you want to continue ?');" />
                      </HeaderTemplate>
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <HeaderTemplate>
                        <asp:Button ID="ForwardSelected" CommandName="ForwardSelected" runat="server" CssClass="nt-but-success" Text="Publish" ToolTip="Forward Selected" OnClientClick="return confirm('Selected Records will be Forwarded, Do you want to continue ?');" />
                      </HeaderTemplate>
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSxDmsFiles"
      runat = "server"
      DataObjectTypeName = "SIS.xDMS.xDmsFiles"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "xDmsFilesSelectList"
      TypeName = "SIS.xDMS.xDmsFiles"
      SelectCountMethod = "xDmsFilesSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_FileID" PropertyName="Text" Name="FileID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_FolderID" PropertyName="Text" Name="FolderID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_StatusID" PropertyName="Text" Name="StatusID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_ParentIFileID" PropertyName="Text" Name="ParentIFileID" Type="Int32" Size="10" />
        <asp:ControlParameter ControlID="F_StatusBy" PropertyName="Text" Name="StatusBy" Type="String" Size="8" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVxDmsFiles" EventName="PageIndexChanged" />
    <asp:AsyncPostBackTrigger ControlID="F_FileID" />
    <asp:AsyncPostBackTrigger ControlID="F_FolderID" />
    <asp:AsyncPostBackTrigger ControlID="F_StatusID" />
    <asp:AsyncPostBackTrigger ControlID="F_ParentIFileID" />
    <asp:AsyncPostBackTrigger ControlID="F_StatusBy" />
  </Triggers>
</asp:UpdatePanel>
</div>
</div>
</asp:Content>
