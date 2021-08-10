<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_xDmsGroupFolders.aspx.vb" Inherits="AF_xDmsGroupFolders" title="Add: Group Folders" %>
<asp:Content ID="CPHxDmsGroupFolders" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsGroupFolders" runat="server" Text="&nbsp;Add: Group Folders"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsGroupFolders" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsGroupFolders"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "xDmsGroupFolders"
    runat = "server" />
<asp:FormView ID="FVxDmsGroupFolders"
  runat = "server"
  DataKeyNames = "GroupID,FolderID"
  DataSourceID = "ODSxDmsGroupFolders"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgxDmsGroupFolders" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GroupID" ForeColor="#CC6633" runat="server" Text="GroupID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_GroupID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("GroupID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for GroupID."
            ValidationGroup = "xDmsGroupFolders"
            onblur= "script_xDmsGroupFolders.validate_GroupID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVGroupID"
            runat = "server"
            ControlToValidate = "F_GroupID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsGroupFolders"
            SetFocusOnError="true" />
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
            OnClientItemSelected="script_xDmsGroupFolders.ACEGroupID_Selected"
            OnClientPopulating="script_xDmsGroupFolders.ACEGroupID_Populating"
            OnClientPopulated="script_xDmsGroupFolders.ACEGroupID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FolderID" ForeColor="#CC6633" runat="server" Text="FolderID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FolderID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("FolderID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for FolderID."
            ValidationGroup = "xDmsGroupFolders"
            onblur= "script_xDmsGroupFolders.validate_FolderID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFolderID"
            runat = "server"
            ControlToValidate = "F_FolderID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsGroupFolders"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_FolderID_Display"
            Text='<%# Eval("xDMS_Folders1_FolderName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFolderID"
            BehaviorID="B_ACEFolderID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FolderIDCompletionList"
            TargetControlID="F_FolderID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsGroupFolders.ACEFolderID_Selected"
            OnClientPopulating="script_xDmsGroupFolders.ACEFolderID_Populating"
            OnClientPopulated="script_xDmsGroupFolders.ACEFolderID_Populated"
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
        <td colspan="3">
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
        <td colspan="3">
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
        <td colspan="3">
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
        <td colspan="3">
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
        <td colspan="3">
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
        <td colspan="3">
          <asp:CheckBox ID="F_DeleteFile"
           Checked='<%# Bind("DeleteFile") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CanPassAuthorization" runat="server" Text="Can Pass Authorization :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_CanPassAuthorization"
           Checked='<%# Bind("CanPassAuthorization") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CanAuthorizeFolder" runat="server" Text="Can Authorize Folder :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_CanAuthorizeFolder"
           Checked='<%# Bind("CanAuthorizeFolder") %>'
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
  ID = "ODSxDmsGroupFolders"
  DataObjectTypeName = "SIS.xDMS.xDmsGroupFolders"
  InsertMethod="xDmsGroupFoldersInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsGroupFolders"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
