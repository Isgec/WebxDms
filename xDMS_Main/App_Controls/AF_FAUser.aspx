<%@ Page Language="VB" MasterPageFile="~/PlaneMaster.master" AutoEventWireup="false" ClientIDMode="Static" CodeFile="AF_FAUser.aspx.vb" Inherits="AF_FAUser" %>
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
          <div class="nt-col" style="width:410px;">
    <asp:Label ID="L_ErrMsgxDmsFolderAuthorizations" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey;font-size: 12px;min-width:400px;">
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
    parent.lgMessageBox.resizeFrame(410,278);
  </script>
</asp:Content>
