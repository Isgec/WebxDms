<%@ Page Language="VB" MasterPageFile="~/PlaneMaster.master" AutoEventWireup="false" ClientIDMode="Static" CodeFile="EF_FoldersAdmin.aspx.vb" Inherits="EF_FoldersAdmin" %>
<asp:Content ID="CPHxDmsFolders" ContentPlaceHolderID="cph1" runat="Server">
  <asp:UpdatePanel ID="UPNLxDmsFolders" runat="server">
    <ContentTemplate>
      <asp:FormView ID="FVxDmsFolders"
        runat="server"
        DataKeyNames="FolderID"
        DataSourceID="ODSxDmsFolders"
        DefaultMode="Edit"
        CssClass="sis_formview">
        <EditItemTemplate>
          <div class="nt-col" style="width:550px;">
            <table style="margin: auto; border: solid 1pt lightgrey; font-size: 12px;">
              <tr>
                <td class="alignright">
                  <b>
                    <asp:Label ID="L_FolderID" runat="server" ForeColor="#CC6633" Text="Folder ID :" /><span style="color: red">*</span></b>
                </td>
                <td colspan="3">
                  <asp:TextBox ID="F_FolderID"
                    Text='<%# Bind("FolderID") %>'
                    Enabled="False"
                    CssClass="mypktxt"
                    Width="88px"
                    Style="text-align: right"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_FolderName" runat="server" Text="Folder Name :" /><span style="color: red">*</span>
                </td>
                <td>
                  <asp:TextBox ID="F_FolderName"
                    Text='<%# Bind("FolderName") %>'
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup="xDmsFolders"
                    ToolTip="Enter value for Folder Name."
                    MaxLength="250"
                    Width="350px"
                    runat="server" />
                  <br />
                  <asp:Label ID="L_ErrMsgxDmsFolders" runat="server" ForeColor="Red" Text=""></asp:Label>
                  <asp:RequiredFieldValidator
                    ID="RFVFolderName"
                    runat="server"
                    ControlToValidate="F_FolderName"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup="xDmsFolders"
                    SetFocusOnError="true" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_KeyWords" runat="server" Text="Key Words :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_KeyWords"
                    Text='<%# Bind("KeyWords") %>'
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter value for Key Words."
                    MaxLength="500"
                    Width="350px"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_ParentFolderID" runat="server" Text="Parent Folder :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox
                    ID = "F_ParentFolderID"
                    CssClass = "myfktxt"
                    Width="88px"
                    Text='<%# Bind("ParentFolderID") %>'
                    AutoCompleteType = "None"
                    onfocus = "return this.select();"
                    ToolTip="Enter value for Parent Folder."
                    onblur= "script_xDmsFolders.validate_ParentFolderID(this);"
                    Runat="Server" />
                  <asp:Label
                    ID = "F_ParentFolderID_Display"
                    Text='<%# Eval("xDMS_Folders2_FolderName") %>'
                    CssClass="myLbl"
                    Runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACEParentFolderID"
                    BehaviorID="B_ACEParentFolderID"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="ParentFolderIDCompletionList"
                    TargetControlID="F_ParentFolderID"
                    EnableCaching="false"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="script_xDmsFolders.ACEParentFolderID_Selected"
                    OnClientPopulating="script_xDmsFolders.ACEParentFolderID_Populating"
                    OnClientPopulated="script_xDmsFolders.ACEParentFolderID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass = "autocomplete_completionListElement"
                    CompletionListItemCssClass = "autocomplete_listItem"
                    CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
                    Runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_ReleaseWorkflowID" runat="server" Text="Release Workflow :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox
                    ID="F_ReleaseWorkflowID"
                    CssClass="myfktxt"
                    Width="88px"
                    Text='<%# Bind("ReleaseWorkflowID") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for Release Workflow."
                    onblur="script_xDmsFolders.validate_ReleaseWorkflowID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_ReleaseWorkflowID_Display"
                    Text='<%# Eval("xDMS_Workflows5_WorkflowName") %>'
                    CssClass="myLbl"
                    runat="Server" />
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
                    OnClientItemSelected="script_xDmsFolders.ACEReleaseWorkflowID_Selected"
                    OnClientPopulating="script_xDmsFolders.ACEReleaseWorkflowID_Populating"
                    OnClientPopulated="script_xDmsFolders.ACEReleaseWorkflowID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_ReviseWorkflowID" runat="server" Text="Revise Workflow :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox
                    ID="F_ReviseWorkflowID"
                    CssClass="myfktxt"
                    Width="88px"
                    Text='<%# Bind("ReviseWorkflowID") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for Revise Workflow."
                    onblur="script_xDmsFolders.validate_ReviseWorkflowID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_ReviseWorkflowID_Display"
                    Text='<%# Eval("xDMS_Workflows6_WorkflowName") %>'
                    CssClass="myLbl"
                    runat="Server" />
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
                    OnClientItemSelected="script_xDmsFolders.ACEReviseWorkflowID_Selected"
                    OnClientPopulating="script_xDmsFolders.ACEReviseWorkflowID_Populating"
                    OnClientPopulated="script_xDmsFolders.ACEReviseWorkflowID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_InitialWorkflowID" runat="server" Text="Initial Workflow :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox
                    ID="F_InitialWorkflowID"
                    CssClass="myfktxt"
                    Width="88px"
                    Text='<%# Bind("InitialWorkflowID") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for Initial Workflow."
                    onblur="script_xDmsFolders.validate_InitialWorkflowID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_InitialWorkflowID_Display"
                    Text='<%# Eval("xDMS_Workflows8_WorkflowName") %>'
                    CssClass="myLbl"
                    runat="Server" />
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
                    OnClientItemSelected="script_xDmsFolders.ACEInitialWorkflowID_Selected"
                    OnClientPopulating="script_xDmsFolders.ACEInitialWorkflowID_Populating"
                    OnClientPopulated="script_xDmsFolders.ACEInitialWorkflowID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_UploadedStatusID" runat="server" Text="Uploaded Status :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox
                    ID="F_UploadedStatusID"
                    CssClass="myfktxt"
                    Width="88px"
                    Text='<%# Bind("UploadedStatusID") %>'
                    AutoCompleteType="None"
                    onfocus="return this.select();"
                    ToolTip="Enter value for Uploaded Status."
                    onblur="script_xDmsFolders.validate_UploadedStatusID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_UploadedStatusID_Display"
                    Text='<%# Eval("xDMS_States7_StatusName") %>'
                    CssClass="myLbl"
                    runat="Server" />
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
                    OnClientItemSelected="script_xDmsFolders.ACEUploadedStatusID_Selected"
                    OnClientPopulating="script_xDmsFolders.ACEUploadedStatusID_Populating"
                    OnClientPopulated="script_xDmsFolders.ACEUploadedStatusID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_UseFileTypeWorkflow" runat="server" Text="Use File Type Workflow :" />&nbsp;
                </td>
                <td>
                  <asp:CheckBox ID="F_UseFileTypeWorkflow"
                    Checked='<%# Bind("UseFileTypeWorkflow") %>'
                    CssClass="mychk"
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
                    CssClass="mychk"
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
                  <asp:Label ID="L_DuplicateFileNameAllowed" runat="server" Text="Duplicate File Name Allowed :" />&nbsp;
                </td>
                <td>
                  <asp:CheckBox ID="F_DuplicateFileNameAllowed"
                    Checked='<%# Bind("DuplicateFileNameAllowed") %>'
                    CssClass="mychk"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td colspan="2" style="text-align:right;padding:8px;">
                  <asp:Button ID="cmdSave" runat="server" CommandName="Update" Font-Size="14px" Text="Submit" CssClass="nt-but-primary" ValidationGroup="xDmsFolders" />
                </td>
              </tr>
            </table>
          </div>
        </EditItemTemplate>
      </asp:FormView>
    </ContentTemplate>
  </asp:UpdatePanel>
  <asp:ObjectDataSource
    ID="ODSxDmsFolders"
    DataObjectTypeName="SIS.xDMS.xDmsFolders"
    SelectMethod="xDmsFoldersGetByID"
    UpdateMethod="UZ_xDmsFoldersUpdate"
    OldValuesParameterFormatString="original_{0}"
    TypeName="SIS.xDMS.xDmsFolders"
    runat="server">
    <SelectParameters>
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="FolderID" Name="FolderID" Type="Int32" />
    </SelectParameters>
  </asp:ObjectDataSource>
  <script>
    parent.lgMessageBox.resizeFrame(552,300);
  </script>
</asp:Content>
