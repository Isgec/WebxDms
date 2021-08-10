<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_xDmsWorkflows.aspx.vb" Inherits="EF_xDmsWorkflows" title="Edit: Workflows" %>
<asp:Content ID="CPHxDmsWorkflows" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsWorkflows" runat="server" Text="&nbsp;Edit: Workflows"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsWorkflows" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsWorkflows"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "xDmsWorkflows"
    runat = "server" />
<asp:FormView ID="FVxDmsWorkflows"
  runat = "server"
  DataKeyNames = "WorkflowID"
  DataSourceID = "ODSxDmsWorkflows"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_WorkflowID" runat="server" ForeColor="#CC6633" Text="Workflow ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WorkflowID"
            Text='<%# Bind("WorkflowID") %>'
            ToolTip="Value of Workflow ID."
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
          <asp:Label ID="L_WorkflowName" runat="server" Text="Workflow Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_WorkflowName"
            Text='<%# Bind("WorkflowName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsWorkflows"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Workflow Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVWorkflowName"
            runat = "server"
            ControlToValidate = "F_WorkflowName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsWorkflows"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ParentWorkflowID" runat="server" Text="Parent Workflow :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ParentWorkflowID"
            CssClass = "myfktxt"
            Text='<%# Bind("ParentWorkflowID") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Parent Workflow."
            onblur= "script_xDmsWorkflows.validate_ParentWorkflowID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ParentWorkflowID_Display"
            Text='<%# Eval("xDMS_Workflows5_WorkflowName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEParentWorkflowID"
            BehaviorID="B_ACEParentWorkflowID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ParentWorkflowIDCompletionList"
            TargetControlID="F_ParentWorkflowID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsWorkflows.ACEParentWorkflowID_Selected"
            OnClientPopulating="script_xDmsWorkflows.ACEParentWorkflowID_Populating"
            OnClientPopulated="script_xDmsWorkflows.ACEParentWorkflowID_Populated"
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
          <asp:Label ID="L_InitialStatusID" runat="server" Text="Can be Initiated when Status :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_xDmsStates
            ID="F_InitialStatusID"
            SelectedValue='<%# Bind("InitialStatusID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            onblur= "script_xDmsWorkflows.validate_InitialStatusID(this);"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FinalStatusID" runat="server" Text="Status after workflow :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_xDmsStates
            ID="F_FinalStatusID"
            SelectedValue='<%# Bind("FinalStatusID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            onblur= "script_xDmsWorkflows.validate_FinalStatusID(this);"
            Runat="Server" />
          </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ReturnStatusID" runat="server" Text="Status when returned :" />&nbsp;
        </td>
        <td colspan="3">
          <LGM:LC_xDmsStates
            ID="F_ReturnStatusID"
            SelectedValue='<%# Bind("ReturnStatusID") %>'
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
          <asp:Label ID="L_UserID" runat="server" Text="Executed by User :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_UserID"
            CssClass = "myfktxt"
            Text='<%# Bind("UserID") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Executed by User."
            onblur= "script_xDmsWorkflows.validate_UserID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_UserID_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
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
            OnClientItemSelected="script_xDmsWorkflows.ACEUserID_Selected"
            OnClientPopulating="script_xDmsWorkflows.ACEUserID_Populating"
            OnClientPopulated="script_xDmsWorkflows.ACEUserID_Populated"
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
          <asp:Label ID="L_GroupID" runat="server" Text="Executed by User Group :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_GroupID"
            CssClass = "myfktxt"
            Text='<%# Bind("GroupID") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Executed by User Group."
            onblur= "script_xDmsWorkflows.validate_GroupID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_GroupID_Display"
            Text='<%# Eval("xDMS_Groups2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEGroupID"
            BehaviorID="B_ACEGroupID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="GroupIDCompletionList"
            TargetControlID="F_GroupID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsWorkflows.ACEGroupID_Selected"
            OnClientPopulating="script_xDmsWorkflows.ACEGroupID_Populating"
            OnClientPopulated="script_xDmsWorkflows.ACEGroupID_Populated"
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
          <asp:Label ID="L_DynamicSelectUserID" runat="server" Text="Dynamic Select User :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_DynamicSelectUserID"
            Checked='<%# Bind("DynamicSelectUserID") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_DynamicSelectUserIDFromGroup" runat="server" Text="Dynamic Select User From Group :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_DynamicSelectUserIDFromGroup"
            Checked='<%# Bind("DynamicSelectUserIDFromGroup") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SendAlert" runat="server" Text="Send Alert :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_SendAlert"
            Checked='<%# Bind("SendAlert") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ToUserID" runat="server" Text="ToUserID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_ToUserID"
            Checked='<%# Bind("ToUserID") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ToGroupID" runat="server" Text="To Group Users :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_ToGroupID"
            Checked='<%# Bind("ToGroupID") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ToFolderAuthorized" runat="server" Text="To Users Authorized on Folder :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_ToFolderAuthorized"
            Checked='<%# Bind("ToFolderAuthorized") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ToDefinedAdditional" runat="server" Text="To Defined Additional Users :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_ToDefinedAdditional"
            Checked='<%# Bind("ToDefinedAdditional") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ToAdditional" runat="server" Text="Additional Users :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_ToAdditional"
            Text='<%# Bind("ToAdditional") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Additional Users."
            MaxLength="1000"
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
  ID = "ODSxDmsWorkflows"
  DataObjectTypeName = "SIS.xDMS.xDmsWorkflows"
  SelectMethod = "xDmsWorkflowsGetByID"
  UpdateMethod="UZ_xDmsWorkflowsUpdate"
  DeleteMethod="UZ_xDmsWorkflowsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsWorkflows"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="WorkflowID" Name="WorkflowID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
