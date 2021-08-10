<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_cDmsERPMapping.aspx.vb" Inherits="EF_cDmsERPMapping" title="Edit: ERP Mapping" %>
<asp:Content ID="CPHcDmsERPMapping" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelcDmsERPMapping" runat="server" Text="&nbsp;Edit: ERP Mapping"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLcDmsERPMapping" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLcDmsERPMapping"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "cDmsERPMapping"
    runat = "server" />
<asp:FormView ID="FVcDmsERPMapping"
  runat = "server"
  DataKeyNames = "SerialNo"
  DataSourceID = "ODScDmsERPMapping"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_SerialNo" runat="server" ForeColor="#CC6633" Text="Seria lNo :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_SerialNo"
            Text='<%# Bind("SerialNo") %>'
            ToolTip="Value of Seria lNo."
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
          <asp:Label ID="L_TransmittalTypeID" runat="server" Text="Transmittal Type :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <LGM:LC_xDmsERPTransmittalTypes
            ID="F_TransmittalTypeID"
            SelectedValue='<%# Bind("TransmittalTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "cDmsERPMapping"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FolderName" runat="server" Text="Folder Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FolderName"
            Text='<%# Bind("FolderName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="cDmsERPMapping"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Folder Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFolderName"
            runat = "server"
            ControlToValidate = "F_FolderName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "cDmsERPMapping"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ParentFolderID" runat="server" Text="Parent Folder :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ParentFolderID"
            CssClass = "myfktxt"
            Text='<%# Bind("ParentFolderID") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Parent Folder."
            onblur= "script_cDmsERPMapping.validate_ParentFolderID(this);"
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
            OnClientItemSelected="script_cDmsERPMapping.ACEParentFolderID_Selected"
            OnClientPopulating="script_cDmsERPMapping.ACEParentFolderID_Populating"
            OnClientPopulated="script_cDmsERPMapping.ACEParentFolderID_Populated"
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
          <asp:Label ID="L_InitialWorkflowID" runat="server" Text="Initial Workflow :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_InitialWorkflowID"
            CssClass = "myfktxt"
            Text='<%# Bind("InitialWorkflowID") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Initial Workflow."
            onblur= "script_cDmsERPMapping.validate_InitialWorkflowID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_InitialWorkflowID_Display"
            Text='<%# Eval("xDMS_Workflows3_WorkflowName") %>'
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
            OnClientItemSelected="script_cDmsERPMapping.ACEInitialWorkflowID_Selected"
            OnClientPopulating="script_cDmsERPMapping.ACEInitialWorkflowID_Populating"
            OnClientPopulated="script_cDmsERPMapping.ACEInitialWorkflowID_Populated"
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
            onblur= "script_cDmsERPMapping.validate_ReleaseWorkflowID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ReleaseWorkflowID_Display"
            Text='<%# Eval("xDMS_Workflows4_WorkflowName") %>'
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
            OnClientItemSelected="script_cDmsERPMapping.ACEReleaseWorkflowID_Selected"
            OnClientPopulating="script_cDmsERPMapping.ACEReleaseWorkflowID_Populating"
            OnClientPopulated="script_cDmsERPMapping.ACEReleaseWorkflowID_Populated"
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
            onblur= "script_cDmsERPMapping.validate_ReviseWorkflowID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ReviseWorkflowID_Display"
            Text='<%# Eval("xDMS_Workflows5_WorkflowName") %>'
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
            OnClientItemSelected="script_cDmsERPMapping.ACEReviseWorkflowID_Selected"
            OnClientPopulating="script_cDmsERPMapping.ACEReviseWorkflowID_Populating"
            OnClientPopulated="script_cDmsERPMapping.ACEReviseWorkflowID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ERPsrno" runat="server" Text="ERP Serial No :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ERPsrno"
            Text='<%# Bind("ERPsrno") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="cDmsERPMapping"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter ERP Serial No.."
            MaxLength="3"
            Width="40px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVERPsrno"
            runat = "server"
            ControlToValidate = "F_ERPsrno"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "cDmsERPMapping"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UploadStatusID" runat="server" Text="Upload Status :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_xDmsStates
            ID="F_UploadStatusID"
            SelectedValue='<%# Bind("UploadStatusID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Active" runat="server" Text="Active :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_Active"
            Checked='<%# Bind("Active") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODScDmsERPMapping"
  DataObjectTypeName = "SIS.xDMS.cDmsERPMapping"
  SelectMethod = "cDmsERPMappingGetByID"
  UpdateMethod="cDmsERPMappingUpdate"
  DeleteMethod="cDmsERPMappingDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.cDmsERPMapping"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="SerialNo" Name="SerialNo" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
