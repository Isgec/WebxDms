<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_xDmsFolders.aspx.vb" Inherits="EF_xDmsFolders" title="Edit: DMS Folders" %>
<asp:Content ID="CPHxDmsFolders" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsFolders" runat="server" Text="&nbsp;Edit: DMS Folders"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFolders" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsFolders"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "xDmsFolders"
    runat = "server" />
<asp:FormView ID="FVxDmsFolders"
  runat = "server"
  DataKeyNames = "FolderID"
  DataSourceID = "ODSxDmsFolders"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FolderID" runat="server" ForeColor="#CC6633" Text="Folder ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FolderID"
            Text='<%# Bind("FolderID") %>'
            ToolTip="Value of Folder ID."
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
          <asp:Label ID="L_FolderName" runat="server" Text="Folder Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FolderName"
            Text='<%# Bind("FolderName") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsFolders"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Folder Name."
            MaxLength="250"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFolderName"
            runat = "server"
            ControlToValidate = "F_FolderName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsFolders"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemTypeID" runat="server" Text="Item Type  :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_xDmsItemTypes
            ID="F_ItemTypeID"
            SelectedValue='<%# Bind("ItemTypeID") %>'
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusBy" runat="server" Text="Status By :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_StatusBy"
            CssClass = "myfktxt"
            Text='<%# Bind("StatusBy") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Status By."
            onblur= "script_xDmsFolders.validate_StatusBy(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEStatusBy"
            BehaviorID="B_ACEStatusBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="StatusByCompletionList"
            TargetControlID="F_StatusBy"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsFolders.ACEStatusBy_Selected"
            OnClientPopulating="script_xDmsFolders.ACEStatusBy_Populating"
            OnClientPopulated="script_xDmsFolders.ACEStatusBy_Populated"
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
          <asp:Label ID="L_StatusOn" runat="server" Text="Status On :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_StatusOn"
            Text='<%# Bind("StatusOn") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            runat="server" />
          <asp:Image ID="ImageButtonStatusOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CEStatusOn"
            TargetControlID="F_StatusOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonStatusOn" />
          <AJX:MaskedEditExtender 
            ID = "MEEStatusOn"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_StatusOn" />
          <AJX:MaskedEditValidator 
            ID = "MEVStatusOn"
            runat = "server"
            ControlToValidate = "F_StatusOn"
            ControlExtender = "MEEStatusOn"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="Status :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_StatusID"
            CssClass = "myfktxt"
            Text='<%# Bind("StatusID") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Status."
            onblur= "script_xDmsFolders.validate_StatusID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text='<%# Eval("xDMS_States4_StatusName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEStatusID"
            BehaviorID="B_ACEStatusID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="StatusIDCompletionList"
            TargetControlID="F_StatusID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsFolders.ACEStatusID_Selected"
            OnClientPopulating="script_xDmsFolders.ACEStatusID_Populating"
            OnClientPopulated="script_xDmsFolders.ACEStatusID_Populated"
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
          <asp:Label ID="L_NodeLevel" runat="server" Text="Node Level :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_NodeLevel"
            Text='<%# Bind("NodeLevel") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEENodeLevel"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_NodeLevel" />
          <AJX:MaskedEditValidator 
            ID = "MEVNodeLevel"
            runat = "server"
            ControlToValidate = "F_NodeLevel"
            ControlExtender = "MEENodeLevel"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Hseq" runat="server" Text="Sequence :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Hseq"
            Text='<%# Bind("Hseq") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEHseq"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_Hseq" />
          <AJX:MaskedEditValidator 
            ID = "MEVHseq"
            runat = "server"
            ControlToValidate = "F_Hseq"
            ControlExtender = "MEEHseq"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            IsValidEmpty = "True"
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
          <asp:Label ID="L_StatusRemarks" runat="server" Text="Status Remarks :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_StatusRemarks"
            Text='<%# Bind("StatusRemarks") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Status Remarks."
            MaxLength="500"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_KeyWords" runat="server" Text="Key Words :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_KeyWords"
            Text='<%# Bind("KeyWords") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Key Words."
            MaxLength="200"
            runat="server" />
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
            onblur= "script_xDmsFolders.validate_ReleaseWorkflowID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ReleaseWorkflowID_Display"
            Text='<%# Eval("xDMS_Workflows5_WorkflowName") %>'
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
            OnClientItemSelected="script_xDmsFolders.ACEReleaseWorkflowID_Selected"
            OnClientPopulating="script_xDmsFolders.ACEReleaseWorkflowID_Populating"
            OnClientPopulated="script_xDmsFolders.ACEReleaseWorkflowID_Populated"
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
            onblur= "script_xDmsFolders.validate_ReviseWorkflowID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ReviseWorkflowID_Display"
            Text='<%# Eval("xDMS_Workflows6_WorkflowName") %>'
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
            OnClientItemSelected="script_xDmsFolders.ACEReviseWorkflowID_Selected"
            OnClientPopulating="script_xDmsFolders.ACEReviseWorkflowID_Populating"
            OnClientPopulated="script_xDmsFolders.ACEReviseWorkflowID_Populated"
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
            onblur= "script_xDmsFolders.validate_InitialWorkflowID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_InitialWorkflowID_Display"
            Text='<%# Eval("xDMS_Workflows8_WorkflowName") %>'
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
            OnClientItemSelected="script_xDmsFolders.ACEInitialWorkflowID_Selected"
            OnClientPopulating="script_xDmsFolders.ACEInitialWorkflowID_Populating"
            OnClientPopulated="script_xDmsFolders.ACEInitialWorkflowID_Populated"
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
          <asp:Label ID="L_UploadedStatusID" runat="server" Text="Uploaded Status :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_UploadedStatusID"
            CssClass = "myfktxt"
            Text='<%# Bind("UploadedStatusID") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Uploaded Status."
            onblur= "script_xDmsFolders.validate_UploadedStatusID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_UploadedStatusID_Display"
            Text='<%# Eval("xDMS_States7_StatusName") %>'
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
            OnClientItemSelected="script_xDmsFolders.ACEUploadedStatusID_Selected"
            OnClientPopulating="script_xDmsFolders.ACEUploadedStatusID_Populating"
            OnClientPopulated="script_xDmsFolders.ACEUploadedStatusID_Populated"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ProjectID" runat="server" Text="ProjectID :" />
        </td>
        <td>
          <asp:TextBox ID="F_ProjectID"
            Text='<%# Bind("ProjectID") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsHFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ProjectID."
            MaxLength="6"
            Width="56px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ElementID" runat="server" Text="ElementID :" />
        </td>
        <td>
          <asp:TextBox ID="F_ElementID"
            Text='<%# Bind("ElementID") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsHFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for ElementID."
            MaxLength="8"
            Width="72px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BPID" runat="server" Text="BPID :" />
        </td>
        <td>
          <asp:TextBox ID="F_BPID"
            Text='<%# Bind("BPID") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsHFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for BPID."
            MaxLength="9"
            Width="80px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CompanyID" runat="server" Text="CompanyID :" />
        </td>
        <td>
          <asp:TextBox ID="F_CompanyID"
            Text='<%# Bind("CompanyID") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsHFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for CompanyID."
            MaxLength="6"
            Width="56px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DivisionID" runat="server" Text="DivisionID :" />
        </td>
        <td>
          <asp:TextBox ID="F_DivisionID"
            Text='<%# Bind("DivisionID") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsHFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DivisionID."
            MaxLength="6"
            Width="56px"
            runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DepartmentID" runat="server" Text="DepartmentID :" />
        </td>
        <td>
          <asp:TextBox ID="F_DepartmentID"
            Text='<%# Bind("DepartmentID") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsHFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for DepartmentID."
            MaxLength="6"
            Width="56px"
            runat="server" />
        </td>
      </tr>
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSxDmsFolders"
  DataObjectTypeName = "SIS.xDMS.xDmsFolders"
  SelectMethod = "xDmsFoldersGetByID"
  UpdateMethod="UZ_xDmsFoldersUpdate"
  DeleteMethod="UZ_xDmsFoldersDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsFolders"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FolderID" Name="FolderID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
