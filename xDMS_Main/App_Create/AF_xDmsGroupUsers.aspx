<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_xDmsGroupUsers.aspx.vb" Inherits="AF_xDmsGroupUsers" title="Add: Group Users" %>
<asp:Content ID="CPHxDmsGroupUsers" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsGroupUsers" runat="server" Text="&nbsp;Add: Group Users"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsGroupUsers" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsGroupUsers"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "xDmsGroupUsers"
    runat = "server" />
<asp:FormView ID="FVxDmsGroupUsers"
  runat = "server"
  DataKeyNames = "GroupID,UserID"
  DataSourceID = "ODSxDmsGroupUsers"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgxDmsGroupUsers" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
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
            ValidationGroup = "xDmsGroupUsers"
            onblur= "script_xDmsGroupUsers.validate_GroupID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVGroupID"
            runat = "server"
            ControlToValidate = "F_GroupID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsGroupUsers"
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
            OnClientItemSelected="script_xDmsGroupUsers.ACEGroupID_Selected"
            OnClientPopulating="script_xDmsGroupUsers.ACEGroupID_Populating"
            OnClientPopulated="script_xDmsGroupUsers.ACEGroupID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_UserID" ForeColor="#CC6633" runat="server" Text="UserID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_UserID"
            CssClass = "mypktxt"
            Width="72px"
            Text='<%# Bind("UserID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for UserID."
            ValidationGroup = "xDmsGroupUsers"
            onblur= "script_xDmsGroupUsers.validate_UserID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVUserID"
            runat = "server"
            ControlToValidate = "F_UserID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsGroupUsers"
            SetFocusOnError="true" />
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
            OnClientItemSelected="script_xDmsGroupUsers.ACEUserID_Selected"
            OnClientPopulating="script_xDmsGroupUsers.ACEUserID_Populating"
            OnClientPopulated="script_xDmsGroupUsers.ACEUserID_Populated"
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
  ID = "ODSxDmsGroupUsers"
  DataObjectTypeName = "SIS.xDMS.xDmsGroupUsers"
  InsertMethod="xDmsGroupUsersInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsGroupUsers"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
