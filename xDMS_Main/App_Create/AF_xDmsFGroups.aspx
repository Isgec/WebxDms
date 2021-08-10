<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_xDmsFGroups.aspx.vb" Inherits="AF_xDmsFGroups" title="Add: Folder Groups" %>
<asp:Content ID="CPHxDmsFGroups" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsFGroups" runat="server" Text="&nbsp;Add: Folder Groups"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFGroups" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsFGroups"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/xDMS_Main/App_Edit/EF_xDmsFGroups.aspx"
    ValidationGroup = "xDmsFGroups"
    runat = "server" />
<asp:FormView ID="FVxDmsFGroups"
  runat = "server"
  DataKeyNames = "FGroupID"
  DataSourceID = "ODSxDmsFGroups"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgxDmsFGroups" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FGroupID" ForeColor="#CC6633" runat="server" Text="Folder Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FGroupID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FGroupName" runat="server" Text="Folder Group Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FGroupName"
            Text='<%# Bind("FGroupName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsFGroups"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Folder Group Name."
            MaxLength="50"
            Width="408px"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReleaseWorkflowID" runat="server" Text="Release Workflow :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ReleaseWorkflowID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("ReleaseWorkflowID") %>'
            AutoCompleteType = "None"
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
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReviseWorkflowID" runat="server" Text="Revise Workflow :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ReviseWorkflowID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("ReviseWorkflowID") %>'
            AutoCompleteType = "None"
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSxDmsFGroups"
  DataObjectTypeName = "SIS.xDMS.xDmsFGroups"
  InsertMethod="UZ_xDmsFGroupsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsFGroups"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
