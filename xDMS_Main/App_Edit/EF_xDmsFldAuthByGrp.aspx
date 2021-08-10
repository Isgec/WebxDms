<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_xDmsFldAuthByGrp.aspx.vb" Inherits="EF_xDmsFldAuthByGrp" title="Edit: DMS Folder Authorizations By Group" %>
<asp:Content ID="CPHxDmsFldAuthByGrp" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsFldAuthByGrp" runat="server" Text="&nbsp;Edit: DMS Folder Authorizations By Group"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFldAuthByGrp" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsFldAuthByGrp"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    EnableDelete = "False"
    ValidationGroup = "xDmsFldAuthByGrp"
    runat = "server" />
<asp:FormView ID="FVxDmsFldAuthByGrp"
  runat = "server"
  DataKeyNames = "GroupID,UserID,FolderID"
  DataSourceID = "ODSxDmsFldAuthByGrp"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GroupID" runat="server" ForeColor="#CC6633" Text="GroupID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_GroupID"
            Text='<%# Bind("GroupID") %>'
            ToolTip="Value of GroupID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_UserID" runat="server" ForeColor="#CC6633" Text="User ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox
            ID = "F_UserID"
            Width="72px"
            Text='<%# Bind("UserID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of User ID."
            Runat="Server" />
          <asp:Label
            ID = "F_UserID_Display"
            Text='<%# Eval("aspnet_users2_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FolderID" runat="server" ForeColor="#CC6633" Text="Folder ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FolderID"
            Width="88px"
            Text='<%# Bind("FolderID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Folder ID."
            Runat="Server" />
          <asp:Label
            ID = "F_FolderID_Display"
            Text='<%# Eval("xDMS_Folders3_FolderName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
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
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_CreatedBy"
            CssClass = "myfktxt"
            Text='<%# Bind("CreatedBy") %>'
            AutoCompleteType = "None"
            Width="72px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Created By."
            ValidationGroup = "xDmsFldAuthByGrp"
            onblur= "script_xDmsFldAuthByGrp.validate_CreatedBy(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVCreatedBy"
            runat = "server"
            ControlToValidate = "F_CreatedBy"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsFldAuthByGrp"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACECreatedBy"
            BehaviorID="B_ACECreatedBy"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="CreatedByCompletionList"
            TargetControlID="F_CreatedBy"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsFldAuthByGrp.ACECreatedBy_Selected"
            OnClientPopulating="script_xDmsFldAuthByGrp.ACECreatedBy_Populating"
            OnClientPopulated="script_xDmsFldAuthByGrp.ACECreatedBy_Populated"
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
          <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            Width="80px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsFldAuthByGrp"
            runat="server" />
          <asp:Image ID="ImageButtonCreatedOn" runat="server" ToolTip="Click to open calendar" style="cursor: pointer; vertical-align:bottom" ImageUrl="~/Images/cal.png" />
          <AJX:CalendarExtender 
            ID = "CECreatedOn"
            TargetControlID="F_CreatedOn"
            Format="dd/MM/yyyy"
            runat = "server" CssClass="MyCalendar" PopupButtonID="ImageButtonCreatedOn" />
          <AJX:MaskedEditExtender 
            ID = "MEECreatedOn"
            runat = "server"
            mask = "99/99/9999"
            MaskType="Date"
            CultureName = "en-GB"
            MessageValidatorTip="true"
            InputDirection="LeftToRight"
            ErrorTooltipEnabled="true"
            TargetControlID="F_CreatedOn" />
          <AJX:MaskedEditValidator 
            ID = "MEVCreatedOn"
            runat = "server"
            ControlToValidate = "F_CreatedOn"
            ControlExtender = "MEECreatedOn"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsFldAuthByGrp"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
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
  ID = "ODSxDmsFldAuthByGrp"
  DataObjectTypeName = "SIS.xDMS.xDmsFldAuthByGrp"
  SelectMethod = "UZ_xDmsFldAuthByGrpGetByID"
  UpdateMethod="UZ_xDmsFldAuthByGrpUpdate"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsFldAuthByGrp"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="GroupID" Name="GroupID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="UserID" Name="UserID" Type="String" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FolderID" Name="FolderID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
