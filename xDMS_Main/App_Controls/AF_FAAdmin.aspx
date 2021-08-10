<%@ Page Language="VB" MasterPageFile="~/PlaneMaster.master" AutoEventWireup="false" ClientIDMode="Static" CodeFile="AF_FAAdmin.aspx.vb" Inherits="AF_FAAdmin" %>
<asp:Content ID="CPHxDmsFolderAuthorizations" ContentPlaceHolderID="cph1" Runat="Server">
<asp:UpdatePanel ID="UPNLxDmsFolderAuthorizations" runat="server" >
  <ContentTemplate>
<asp:FormView ID="FVxDmsFolderAuthorizations"
  runat = "server"
  DataKeyNames = "UserID,FolderID"
  DataSourceID = "ODSxDmsFolderAuthorizations"
  DefaultMode = "Insert" 
  CssClass="sis_formview">
  <InsertItemTemplate>
    <div class="nt-col" style="width:450px;">
    <asp:Label ID="L_ErrMsgxDmsFolderAuthorizations" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey;font-size: 12px;">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FolderID" ForeColor="#CC6633" runat="server" Text="Folder ID :" /></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FolderID"
            CssClass = "dmypktxt"
            Width="88px"
            Text='<%# Bind("FolderID") %>'
            AutoCompleteType = "None"
            Enabled="false"
            Runat="Server" />
          <asp:Label
            ID = "F_FolderID_Display"
            Text='<%# Eval("xDMS_Folders3_FolderName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UserID" ForeColor="#CC6633" runat="server" Text="User ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_UserID"
            CssClass = "mypktxt"
            Width="72px"
            Text='<%# Bind("UserID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for User ID."
            ValidationGroup = "xDmsFolderAuthorizations"
            onblur= "script_xDmsFolderAuthorizations.validate_UserID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVUserID"
            runat = "server"
            ControlToValidate = "F_UserID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsFolderAuthorizations"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_UserID_Display"
            Text='<%# Eval("aspnet_users2_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUserID"
            BehaviorID="B_ACEUserID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UserIDCompletionList"
            TargetControlID="F_UserID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsFolderAuthorizations.ACEUserID_Selected"
            OnClientPopulating="script_xDmsFolderAuthorizations.ACEUserID_Populating"
            OnClientPopulated="script_xDmsFolderAuthorizations.ACEUserID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreateFolder" runat="server" Text="Create Folder :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_CreateFolder"
           Checked='<%# Bind("CreateFolder") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UpdateFolder" runat="server" Text="Update Folder :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_UpdateFolder"
           Checked='<%# Bind("UpdateFolder") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DeleteFolder" runat="server" Text="Delete Folder :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DeleteFolder"
           Checked='<%# Bind("DeleteFolder") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UploadFile" runat="server" Text="Upload File :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_UploadFile"
           Checked='<%# Bind("UploadFile") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DownloadFile" runat="server" Text="Download File :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DownloadFile"
           Checked='<%# Bind("DownloadFile") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DeleteFile" runat="server" Text="Delete File :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DeleteFile"
           Checked='<%# Bind("DeleteFile") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CanAuthorizeFolder" runat="server" Text="Can Authorize Folder :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_CanAuthorizeFolder"
           Checked='<%# Bind("CanAuthorizeFolder") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CanPassAuthorization" runat="server" Text="Can Pass Authorization :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_CanPassAuthorization"
           Checked='<%# Bind("CanPassAuthorization") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CanViewAllRevisions" runat="server" Text="Can View All Revisions :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_CanViewAllRevisions"
           Checked='<%# Bind("CanViewAllRevisions") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RequireExplicitAuthorization" runat="server" Text="Require Explicit Authorization :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_RequireExplicitAuthorization"
           Checked='<%# Bind("RequireExplicitAuthorization") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_RequireExplicitWorkflow" runat="server" Text="Require Explicit Workflow :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_RequireExplicitWorkflow"
           Checked='<%# Bind("RequireExplicitWorkflow") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReleaseWorkflowID" runat="server" Text="Release Workflow :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ReleaseWorkflowID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("ReleaseWorkflowID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Release Workflow."
            onblur= "script_xDmsFolderAuthorizations.validate_ReleaseWorkflowID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ReleaseWorkflowID_Display"
            Text='<%# Eval("xDMS_Workflows6_WorkflowName") %>'
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
            OnClientItemSelected="script_xDmsFolderAuthorizations.ACEReleaseWorkflowID_Selected"
            OnClientPopulating="script_xDmsFolderAuthorizations.ACEReleaseWorkflowID_Populating"
            OnClientPopulated="script_xDmsFolderAuthorizations.ACEReleaseWorkflowID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReviseWorkflowID" runat="server" Text="Revise Workflow :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_ReviseWorkflowID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("ReviseWorkflowID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Revise Workflow."
            onblur= "script_xDmsFolderAuthorizations.validate_ReviseWorkflowID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ReviseWorkflowID_Display"
            Text='<%# Eval("xDMS_Workflows7_WorkflowName") %>'
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
            OnClientItemSelected="script_xDmsFolderAuthorizations.ACEReviseWorkflowID_Selected"
            OnClientPopulating="script_xDmsFolderAuthorizations.ACEReviseWorkflowID_Populating"
            OnClientPopulated="script_xDmsFolderAuthorizations.ACEReviseWorkflowID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_InitialWorkflowID" runat="server" Text="Initial Workflow :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_InitialWorkflowID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("InitialWorkflowID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Initial Workflow."
            onblur= "script_xDmsFolderAuthorizations.validate_InitialWorkflowID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_InitialWorkflowID_Display"
            Text='<%# Eval("xDMS_Workflows9_WorkflowName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEInitialWorkflowID"
            BehaviorID="B_ACEInitialWorkflowID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="InitialWorkflowIDCompletionList"
            TargetControlID="F_InitialWorkflowID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsFolderAuthorizations.ACEInitialWorkflowID_Selected"
            OnClientPopulating="script_xDmsFolderAuthorizations.ACEInitialWorkflowID_Populating"
            OnClientPopulated="script_xDmsFolderAuthorizations.ACEInitialWorkflowID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UploadedStatusID" runat="server" Text="Uploaded Status :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_UploadedStatusID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("UploadedStatusID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Uploaded Status."
            onblur= "script_xDmsFolderAuthorizations.validate_UploadedStatusID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_UploadedStatusID_Display"
            Text='<%# Eval("xDMS_States8_StatusName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEUploadedStatusID"
            BehaviorID="B_ACEUploadedStatusID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="UploadedStatusIDCompletionList"
            TargetControlID="F_UploadedStatusID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsFolderAuthorizations.ACEUploadedStatusID_Selected"
            OnClientPopulating="script_xDmsFolderAuthorizations.ACEUploadedStatusID_Populating"
            OnClientPopulated="script_xDmsFolderAuthorizations.ACEUploadedStatusID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UseFileTypeWorkflow" runat="server" Text="Use File Type Workflow :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_UseFileTypeWorkflow"
           Checked='<%# Bind("UseFileTypeWorkflow") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DuplicateFileNameAllowed" runat="server" Text="Duplicate File Name Allowed :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_DuplicateFileNameAllowed"
           Checked='<%# Bind("DuplicateFileNameAllowed") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ShowAtRoot" runat="server" Text="Show At Root :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_ShowAtRoot"
           Checked='<%# Bind("ShowAtRoot") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_IsAdmin" runat="server" Text="Is Admin :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_IsAdmin"
           Checked='<%# Bind("IsAdmin") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td colspan="2" style="text-align:right;padding:8px;">
          <asp:Button ID="cmdSave" runat="server" CommandName="Insert" Font-Size="14px" Text="Submit" CssClass="nt-but-primary" ValidationGroup="xDmsFolderAuthorizations" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSxDmsFolderAuthorizations"
  DataObjectTypeName = "SIS.xDMS.xDmsFolderAuthorizations"
  InsertMethod="UZ_xDmsFolderAuthorizationsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsFolderAuthorizations"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
  <script>
    parent.lgMessageBox.resizeFrame(440,510);
  </script>
</asp:Content>
