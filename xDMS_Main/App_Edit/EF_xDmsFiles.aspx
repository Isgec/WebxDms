<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_xDmsFiles.aspx.vb" Inherits="EF_xDmsFiles" title="Edit: DMS Files" %>
<asp:Content ID="CPHxDmsFiles" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsFiles" runat="server" Text="&nbsp;Edit: DMS Files"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFiles" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsFiles"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "xDmsFiles"
    runat = "server" />
<asp:FormView ID="FVxDmsFiles"
  runat = "server"
  DataKeyNames = "FileID"
  DataSourceID = "ODSxDmsFiles"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FileID" runat="server" ForeColor="#CC6633" Text="File ID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_FileID"
            Text='<%# Bind("FileID") %>'
            ToolTip="Value of File ID."
            Enabled = "False"
            CssClass = "mypktxt"
            Width="88px"
            style="text-align: right"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_FileTypeID" runat="server" Text="FileType :" /><span style="color:red">*</span>
        </td>
        <td>
          <LGM:LC_xDmsFileTypes
            ID="F_FileTypeID"
            SelectedValue='<%# Bind("FileTypeID") %>'
            OrderBy="DisplayField"
            DataTextField="DisplayField"
            DataValueField="PrimaryKey"
            IncludeDefault="true"
            DefaultText="-- Select --"
            Width="200px"
            CssClass="myddl"
            ValidationGroup = "xDmsFiles"
            RequiredFieldErrorMessage = "<div class='errorLG'>Required!</div>"
            onblur= "script_xDmsFiles.validate_FileTypeID(this);"
            Runat="Server" />
          </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FileName" runat="server" Text="File Name :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FileName"
            Text='<%# Bind("FileName") %>'
            Width="350px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for File Name."
            MaxLength="250"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFileName"
            runat = "server"
            ControlToValidate = "F_FileName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsFiles"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FileRev" runat="server" Text="File Rev :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FileRev"
            Text='<%# Bind("FileRev") %>'
            Width="88px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for File Rev."
            MaxLength="10"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFileRev"
            runat = "server"
            ControlToValidate = "F_FileRev"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsFiles"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemTypeID" runat="server" Text="Item Type :" />&nbsp;
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
          <asp:Label ID="L_FolderID" runat="server" Text="Folder :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FolderID"
            CssClass = "myfktxt"
            Text='<%# Bind("FolderID") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for Folder."
            ValidationGroup = "xDmsFiles"
            onblur= "script_xDmsFiles.validate_FolderID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFolderID"
            runat = "server"
            ControlToValidate = "F_FolderID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsFiles"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_FolderID_Display"
            Text='<%# Eval("xDMS_Folders3_FolderName") %>'
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
            OnClientItemSelected="script_xDmsFiles.ACEFolderID_Selected"
            OnClientPopulating="script_xDmsFiles.ACEFolderID_Populating"
            OnClientPopulated="script_xDmsFiles.ACEFolderID_Populated"
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
          <asp:Label ID="L_VaultDRID" runat="server" Text="Vault DRID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_VaultDRID"
            Text='<%# Bind("VaultDRID") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Vault DRID."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FileExtn" runat="server" Text="File Extn :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FileExtn"
            Text='<%# Bind("FileExtn") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for File Extn."
            MaxLength="50"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FileSize" runat="server" Text="File Size :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_FileSize"
            Text='<%# Bind("FileSize") %>'
            style="text-align: right"
            Width="88px"
            CssClass = "mytxt"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEFileSize"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FileSize" />
          <AJX:MaskedEditValidator 
            ID = "MEVFileSize"
            runat = "server"
            ControlToValidate = "F_FileSize"
            ControlExtender = "MEEFileSize"
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
          <asp:Label ID="L_StatusID" runat="server" Text="Status :" /><span style="color:red">*</span>
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
            ValidationGroup = "xDmsFiles"
            onblur= "script_xDmsFiles.validate_StatusID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVStatusID"
            runat = "server"
            ControlToValidate = "F_StatusID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsFiles"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text='<%# Eval("xDMS_States5_StatusName") %>'
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
            OnClientItemSelected="script_xDmsFiles.ACEStatusID_Selected"
            OnClientPopulating="script_xDmsFiles.ACEStatusID_Populating"
            OnClientPopulated="script_xDmsFiles.ACEStatusID_Populated"
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
          <asp:Label ID="L_ParentIFileID" runat="server" Text="ParentI File ID :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_ParentIFileID"
            CssClass = "myfktxt"
            Text='<%# Bind("ParentIFileID") %>'
            AutoCompleteType = "None"
            Width="88px"
            onfocus = "return this.select();"
            ToolTip="Enter value for ParentI File ID."
            onblur= "script_xDmsFiles.validate_ParentIFileID(this);"
            Runat="Server" />
          <asp:Label
            ID = "F_ParentIFileID_Display"
            Text='<%# Eval("xDMS_Files2_FileName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEParentIFileID"
            BehaviorID="B_ACEParentIFileID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ParentIFileIDCompletionList"
            TargetControlID="F_ParentIFileID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsFiles.ACEParentIFileID_Selected"
            OnClientPopulating="script_xDmsFiles.ACEParentIFileID_Populating"
            OnClientPopulated="script_xDmsFiles.ACEParentIFileID_Populated"
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
            onblur= "script_xDmsFiles.validate_StatusBy(this);"
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
            OnClientItemSelected="script_xDmsFiles.ACEStatusBy_Selected"
            OnClientPopulating="script_xDmsFiles.ACEStatusBy_Populating"
            OnClientPopulated="script_xDmsFiles.ACEStatusBy_Populated"
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
          <asp:Label ID="L_UserRemarks" runat="server" Text="UserRemarks :" />
        </td>
        <td>
          <asp:TextBox ID="F_UserRemarks"
            Text='<%# Bind("UserRemarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsHFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for UserRemarks."
            MaxLength="500"
            Width="350px"
            runat="server" />
        </td>
      </tr>
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
  ID = "ODSxDmsFiles"
  DataObjectTypeName = "SIS.xDMS.xDmsFiles"
  SelectMethod = "xDmsFilesGetByID"
  UpdateMethod="UZ_xDmsFilesUpdate"
  DeleteMethod="UZ_xDmsFilesDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsFiles"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FileID" Name="FileID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
