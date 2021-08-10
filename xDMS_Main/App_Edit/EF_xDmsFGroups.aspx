<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_xDmsFGroups.aspx.vb" Inherits="EF_xDmsFGroups" title="Edit: Folder Groups" %>
<asp:Content ID="CPHxDmsFGroups" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsFGroups" runat="server" Text="&nbsp;Edit: Folder Groups"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFGroups" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsFGroups"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "xDmsFGroups"
    runat = "server" />
<asp:FormView ID="FVxDmsFGroups"
  runat = "server"
  DataKeyNames = "FGroupID"
  DataSourceID = "ODSxDmsFGroups"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FGroupID" runat="server" ForeColor="#CC6633" Text="Folder Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FGroupID"
            Text='<%# Bind("FGroupID") %>'
            ToolTip="Value of Folder Group ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FGroupName" runat="server" Text="Folder Group Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FGroupName"
            Text='<%# Bind("FGroupName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsFGroups"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Folder Group Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFGroupName"
            runat = "server"
            ControlToValidate = "F_FGroupName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsFGroups"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RequireExplicitAuthorization" runat="server" Text="Require Explicit Authorization :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_RequireExplicitAuthorization"
            Checked='<%# Bind("RequireExplicitAuthorization") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RequireExplicitWorkflow" runat="server" Text="Require Explicit Workflow :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_RequireExplicitWorkflow"
            Checked='<%# Bind("RequireExplicitWorkflow") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReleaseWorkflowID" runat="server" Text="Release Workflow :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ReleaseWorkflowID"
            CssClass = "myfktxt"
            Text='<%# Bind("ReleaseWorkflowID") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Release Workflow."
            onblur= "script_xDmsFGroups.validate_ReleaseWorkflowID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ReleaseWorkflowID_Display"
            Text='<%# Eval("xDMS_Workflows1_WorkflowName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEReleaseWorkflowID"
            BehaviorID="B_ACEReleaseWorkflowID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ReleaseWorkflowIDCompletionList"
            TargetControlID="F_ReleaseWorkflowID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsFGroups.ACEReleaseWorkflowID_Selected"
            OnClientPopulating="script_xDmsFGroups.ACEReleaseWorkflowID_Populating"
            OnClientPopulated="script_xDmsFGroups.ACEReleaseWorkflowID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReviseWorkflowID" runat="server" Text="Revise Workflow :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ReviseWorkflowID"
            CssClass = "myfktxt"
            Text='<%# Bind("ReviseWorkflowID") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Revise Workflow."
            onblur= "script_xDmsFGroups.validate_ReviseWorkflowID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ReviseWorkflowID_Display"
            Text='<%# Eval("xDMS_Workflows2_WorkflowName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEReviseWorkflowID"
            BehaviorID="B_ACEReviseWorkflowID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ReviseWorkflowIDCompletionList"
            TargetControlID="F_ReviseWorkflowID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsFGroups.ACEReviseWorkflowID_Selected"
            OnClientPopulating="script_xDmsFGroups.ACEReviseWorkflowID_Populating"
            OnClientPopulated="script_xDmsFGroups.ACEReviseWorkflowID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UseFileTypeWorkflow" runat="server" Text="Use File Type Workflow :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_UseFileTypeWorkflow"
            Checked='<%# Bind("UseFileTypeWorkflow") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DuplicateFileNameAllowed" runat="server" Text="Duplicate File Name Allowed :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_DuplicateFileNameAllowed"
            Checked='<%# Bind("DuplicateFileNameAllowed") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelxDmsFGroupFolders" runat="server" Text="&nbsp;List: Folders"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFGroupFolders" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLxDmsFGroupFolders"
      ToolType = "lgNMGrid"
      EditUrl = "~/xDMS_Main/App_Edit/EF_xDmsFGroupFolders.aspx"
      AddUrl = "~/xDMS_Main/App_Create/AF_xDmsFGroupFolders.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "xDmsFGroupFolders"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSxDmsFGroupFolders" runat="server" AssociatedUpdatePanelID="UPNLxDmsFGroupFolders" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVxDmsFGroupFolders" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsFGroupFolders" DataKeyNames="FGroupID,FolderID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Folder Group ID" SortExpression="[xDMS_FGroups1].[FGroupName]">
          <ItemTemplate>
             <asp:Label ID="L_FGroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("FGroupID") %>' Text='<%# Eval("xDMS_FGroups1_FGroupName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Folder ID" SortExpression="[xDMS_Folders2].[FolderName]">
          <ItemTemplate>
             <asp:Label ID="L_FolderID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("FolderID") %>' Text='<%# Eval("xDMS_Folders2_FolderName") %>'></asp:Label>
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
      ID = "ODSxDmsFGroupFolders"
      runat = "server"
      DataObjectTypeName = "SIS.xDMS.xDmsFGroupFolders"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "UZ_xDmsFGroupFoldersSelectList"
      TypeName = "SIS.xDMS.xDmsFGroupFolders"
      SelectCountMethod = "xDmsFGroupFoldersSelectCount"
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
    <asp:AsyncPostBackTrigger ControlID="GVxDmsFGroupFolders" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSxDmsFGroups"
  DataObjectTypeName = "SIS.xDMS.xDmsFGroups"
  SelectMethod = "xDmsFGroupsGetByID"
  UpdateMethod="UZ_xDmsFGroupsUpdate"
  DeleteMethod="UZ_xDmsFGroupsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsFGroups"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FGroupID" Name="FGroupID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
