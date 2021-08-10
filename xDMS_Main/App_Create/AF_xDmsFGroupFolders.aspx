<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_xDmsFGroupFolders.aspx.vb" Inherits="AF_xDmsFGroupFolders" title="Add: Folders" %>
<asp:Content ID="CPHxDmsFGroupFolders" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsFGroupFolders" runat="server" Text="&nbsp;Add: Folders"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFGroupFolders" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsFGroupFolders"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "xDmsFGroupFolders"
    runat = "server" />
<asp:FormView ID="FVxDmsFGroupFolders"
  runat = "server"
  DataKeyNames = "FGroupID,FolderID"
  DataSourceID = "ODSxDmsFGroupFolders"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgxDmsFGroupFolders" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FGroupID" ForeColor="#CC6633" runat="server" Text="Folder Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FGroupID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("FGroupID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Folder Group ID."
            ValidationGroup = "xDmsFGroupFolders"
            onblur= "script_xDmsFGroupFolders.validate_FGroupID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFGroupID"
            runat = "server"
            ControlToValidate = "F_FGroupID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsFGroupFolders"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_FGroupID_Display"
            Text='<%# Eval("xDMS_FGroups1_FGroupName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFGroupID"
            BehaviorID="B_ACEFGroupID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FGroupIDCompletionList"
            TargetControlID="F_FGroupID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsFGroupFolders.ACEFGroupID_Selected"
            OnClientPopulating="script_xDmsFGroupFolders.ACEFGroupID_Populating"
            OnClientPopulated="script_xDmsFGroupFolders.ACEFGroupID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FolderID" ForeColor="#CC6633" runat="server" Text="Folder ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FolderID"
            CssClass = "mypktxt"
            Width="88px"
            Text='<%# Bind("FolderID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for Folder ID."
            ValidationGroup = "xDmsFGroupFolders"
            onblur= "script_xDmsFGroupFolders.validate_FolderID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFolderID"
            runat = "server"
            ControlToValidate = "F_FolderID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsFGroupFolders"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_FolderID_Display"
            Text='<%# Eval("xDMS_Folders2_FolderName") %>'
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
            OnClientItemSelected="script_xDmsFGroupFolders.ACEFolderID_Selected"
            OnClientPopulating="script_xDmsFGroupFolders.ACEFolderID_Populating"
            OnClientPopulated="script_xDmsFGroupFolders.ACEFolderID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSxDmsFGroupFolders"
  DataObjectTypeName = "SIS.xDMS.xDmsFGroupFolders"
  InsertMethod="UZ_xDmsFGroupFoldersInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsFGroupFolders"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
