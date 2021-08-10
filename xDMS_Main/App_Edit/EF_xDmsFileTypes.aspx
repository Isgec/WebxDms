<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_xDmsFileTypes.aspx.vb" Inherits="EF_xDmsFileTypes" title="Edit: File Types" %>
<asp:Content ID="CPHxDmsFileTypes" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsFileTypes" runat="server" Text="&nbsp;Edit: File Types"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFileTypes" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsFileTypes"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "xDmsFileTypes"
    runat = "server" />
<asp:FormView ID="FVxDmsFileTypes"
  runat = "server"
  DataKeyNames = "FileTypeID"
  DataSourceID = "ODSxDmsFileTypes"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FileTypeID" runat="server" ForeColor="#CC6633" Text="File Type ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FileTypeID"
            Text='<%# Bind("FileTypeID") %>'
            ToolTip="Value of File Type ID."
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
          <asp:Label ID="L_FileTypeName" runat="server" Text="File Type Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FileTypeName"
            Text='<%# Bind("FileTypeName") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsFileTypes"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for File Type Name."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFileTypeName"
            runat = "server"
            ControlToValidate = "F_FileTypeName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsFileTypes"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_BasedOnFileExtension" runat="server" Text="Based On File Extension :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_BasedOnFileExtension"
            Checked='<%# Bind("BasedOnFileExtension") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FileExtentionList" runat="server" Text="File Extention List :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FileExtentionList"
            Text='<%# Bind("FileExtentionList") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for File Extention List."
            MaxLength="500"
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
            onblur= "script_xDmsFileTypes.validate_ReleaseWorkflowID(this);"
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
            OnClientItemSelected="script_xDmsFileTypes.ACEReleaseWorkflowID_Selected"
            OnClientPopulating="script_xDmsFileTypes.ACEReleaseWorkflowID_Populating"
            OnClientPopulated="script_xDmsFileTypes.ACEReleaseWorkflowID_Populated"
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
            onblur= "script_xDmsFileTypes.validate_ReviseWorkflowID(this);"
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
            OnClientItemSelected="script_xDmsFileTypes.ACEReviseWorkflowID_Selected"
            OnClientPopulating="script_xDmsFileTypes.ACEReviseWorkflowID_Populating"
            OnClientPopulated="script_xDmsFileTypes.ACEReviseWorkflowID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
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
  ID = "ODSxDmsFileTypes"
  DataObjectTypeName = "SIS.xDMS.xDmsFileTypes"
  SelectMethod = "xDmsFileTypesGetByID"
  UpdateMethod="UZ_xDmsFileTypesUpdate"
  DeleteMethod="UZ_xDmsFileTypesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsFileTypes"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FileTypeID" Name="FileTypeID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
