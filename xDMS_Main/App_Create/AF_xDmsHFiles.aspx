<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_xDmsHFiles.aspx.vb" Inherits="AF_xDmsHFiles" title="Add: Files History" %>
<asp:Content ID="CPHxDmsHFiles" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsHFiles" runat="server" Text="&nbsp;Add: Files History"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsHFiles" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsHFiles"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    ValidationGroup = "xDmsHFiles"
    runat = "server" />
<asp:FormView ID="FVxDmsHFiles"
  runat = "server"
  DataKeyNames = "FileID,HFileID"
  DataSourceID = "ODSxDmsHFiles"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgxDmsHFiles" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FileID" ForeColor="#CC6633" runat="server" Text="FileID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_FileID"
            Text='<%# Bind("FileID") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mypktxt"
            ValidationGroup="xDmsHFiles"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEFileID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_FileID" />
          <AJX:MaskedEditValidator 
            ID = "MEVFileID"
            runat = "server"
            ControlToValidate = "F_FileID"
            ControlExtender = "MEEFileID"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <b><asp:Label ID="L_HFileID" ForeColor="#CC6633" runat="server" Text="HFileID :" /><span style="color:red">*</span></b>
        </td>
        <td>
          <asp:TextBox ID="F_HFileID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FileName" runat="server" Text="FileName :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_FileName"
            Text='<%# Bind("FileName") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsHFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for FileName."
            MaxLength="250"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFileName"
            runat = "server"
            ControlToValidate = "F_FileName"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_FileRev" runat="server" Text="FileRev :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_FileRev"
            Text='<%# Bind("FileRev") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsHFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for FileRev."
            MaxLength="10"
            Width="88px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFileRev"
            runat = "server"
            ControlToValidate = "F_FileRev"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_ItemTypeID" runat="server" Text="ItemTypeID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_ItemTypeID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("ItemTypeID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for ItemTypeID."
            ValidationGroup = "xDmsHFiles"
            onblur= "script_xDmsHFiles.validate_ItemTypeID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVItemTypeID"
            runat = "server"
            ControlToValidate = "F_ItemTypeID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_ItemTypeID_Display"
            Text='<%# Eval("xDMS_ItemTypes6_ItemName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEItemTypeID"
            BehaviorID="B_ACEItemTypeID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="ItemTypeIDCompletionList"
            TargetControlID="F_ItemTypeID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsHFiles.ACEItemTypeID_Selected"
            OnClientPopulating="script_xDmsHFiles.ACEItemTypeID_Populating"
            OnClientPopulated="script_xDmsHFiles.ACEItemTypeID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_FolderID" runat="server" Text="FolderID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FolderID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("FolderID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for FolderID."
            ValidationGroup = "xDmsHFiles"
            onblur= "script_xDmsHFiles.validate_FolderID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFolderID"
            runat = "server"
            ControlToValidate = "F_FolderID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_FolderID_Display"
            Text='<%# Eval("xDMS_Folders4_FolderName") %>'
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
            OnClientItemSelected="script_xDmsHFiles.ACEFolderID_Selected"
            OnClientPopulating="script_xDmsHFiles.ACEFolderID_Populating"
            OnClientPopulated="script_xDmsHFiles.ACEFolderID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusID" runat="server" Text="StatusID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_StatusID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("StatusID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for StatusID."
            ValidationGroup = "xDmsHFiles"
            onblur= "script_xDmsHFiles.validate_StatusID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVStatusID"
            runat = "server"
            ControlToValidate = "F_StatusID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_StatusID_Display"
            Text='<%# Eval("xDMS_States7_StatusName") %>'
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
            OnClientItemSelected="script_xDmsHFiles.ACEStatusID_Selected"
            OnClientPopulating="script_xDmsHFiles.ACEStatusID_Populating"
            OnClientPopulated="script_xDmsHFiles.ACEStatusID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_StatusBy" runat="server" Text="StatusBy :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_StatusBy"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("StatusBy") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for StatusBy."
            ValidationGroup = "xDmsHFiles"
            onblur= "script_xDmsHFiles.validate_StatusBy(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVStatusBy"
            runat = "server"
            ControlToValidate = "F_StatusBy"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_StatusBy_Display"
            Text='<%# Eval("aspnet_users2_UserFullName") %>'
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
            OnClientItemSelected="script_xDmsHFiles.ACEStatusBy_Selected"
            OnClientPopulating="script_xDmsHFiles.ACEStatusBy_Populating"
            OnClientPopulated="script_xDmsHFiles.ACEStatusBy_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_StatusOn" runat="server" Text="StatusOn :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_StatusOn"
            Text='<%# Bind("StatusOn") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="xDmsHFiles"
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
            ValidationGroup = "xDmsHFiles"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_StatusRemarks" runat="server" Text="StatusRemarks :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_StatusRemarks"
            Text='<%# Bind("StatusRemarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsHFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for StatusRemarks."
            MaxLength="500"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVStatusRemarks"
            runat = "server"
            ControlToValidate = "F_StatusRemarks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_VaultDRID" runat="server" Text="VaultDRID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_VaultDRID"
            Text='<%# Bind("VaultDRID") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsHFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for VaultDRID."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVVaultDRID"
            runat = "server"
            ControlToValidate = "F_VaultDRID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_FileExtn" runat="server" Text="FileExtn :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_FileExtn"
            Text='<%# Bind("FileExtn") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsHFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for FileExtn."
            MaxLength="50"
            Width="408px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFileExtn"
            runat = "server"
            ControlToValidate = "F_FileExtn"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FileSize" runat="server" Text="FileSize :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_FileSize"
            Text='<%# Bind("FileSize") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mytxt"
            ValidationGroup="xDmsHFiles"
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
            ValidationGroup = "xDmsHFiles"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_KeyWords" runat="server" Text="KeyWords :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_KeyWords"
            Text='<%# Bind("KeyWords") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsHFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for KeyWords."
            MaxLength="200"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVKeyWords"
            runat = "server"
            ControlToValidate = "F_KeyWords"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Active" runat="server" Text="Active :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Active"
           Checked='<%# Bind("Active") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_ParentIFileID" runat="server" Text="ParentIFileID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_ParentIFileID"
            Text='<%# Bind("ParentIFileID") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mytxt"
            ValidationGroup="xDmsHFiles"
            MaxLength="10"
            onfocus = "return this.select();"
            runat="server" />
          <AJX:MaskedEditExtender 
            ID = "MEEParentIFileID"
            runat = "server"
            mask = "9999999999"
            AcceptNegative = "Left"
            MaskType="Number"
            MessageValidatorTip="true"
            InputDirection="RightToLeft"
            ErrorTooltipEnabled="true"
            TargetControlID="F_ParentIFileID" />
          <AJX:MaskedEditValidator 
            ID = "MEVParentIFileID"
            runat = "server"
            ControlToValidate = "F_ParentIFileID"
            ControlExtender = "MEEParentIFileID"
            EmptyValueBlurredText = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_NodeLevel" runat="server" Text="NodeLevel :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_NodeLevel"
            Text='<%# Bind("NodeLevel") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mytxt"
            ValidationGroup="xDmsHFiles"
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
            ValidationGroup = "xDmsHFiles"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Hseq" runat="server" Text="Hseq :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_Hseq"
            Text='<%# Bind("Hseq") %>'
            Width="88px"
            style="text-align: Right"
            CssClass = "mytxt"
            ValidationGroup="xDmsHFiles"
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
            ValidationGroup = "xDmsHFiles"
            IsValidEmpty = "false"
            MinimumValue = "1"
            SetFocusOnError="true" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_FileTypeID" runat="server" Text="FileTypeID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_FileTypeID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("FileTypeID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for FileTypeID."
            ValidationGroup = "xDmsHFiles"
            onblur= "script_xDmsHFiles.validate_FileTypeID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVFileTypeID"
            runat = "server"
            ControlToValidate = "F_FileTypeID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_FileTypeID_Display"
            Text='<%# Eval("xDMS_FileTypes3_FileTypeName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEFileTypeID"
            BehaviorID="B_ACEFileTypeID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="FileTypeIDCompletionList"
            TargetControlID="F_FileTypeID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsHFiles.ACEFileTypeID_Selected"
            OnClientPopulating="script_xDmsHFiles.ACEFileTypeID_Populating"
            OnClientPopulated="script_xDmsHFiles.ACEFileTypeID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_WorkflowID" runat="server" Text="WorkflowID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_WorkflowID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("WorkflowID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for WorkflowID."
            ValidationGroup = "xDmsHFiles"
            onblur= "script_xDmsHFiles.validate_WorkflowID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVWorkflowID"
            runat = "server"
            ControlToValidate = "F_WorkflowID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_WorkflowID_Display"
            Text='<%# Eval("xDMS_Workflows8_WorkflowName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEWorkflowID"
            BehaviorID="B_ACEWorkflowID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="WorkflowIDCompletionList"
            TargetControlID="F_WorkflowID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsHFiles.ACEWorkflowID_Selected"
            OnClientPopulating="script_xDmsHFiles.ACEWorkflowID_Populating"
            OnClientPopulated="script_xDmsHFiles.ACEWorkflowID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_WorkflowStepID" runat="server" Text="WorkflowStepID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_WorkflowStepID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("WorkflowStepID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for WorkflowStepID."
            ValidationGroup = "xDmsHFiles"
            onblur= "script_xDmsHFiles.validate_WorkflowStepID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVWorkflowStepID"
            runat = "server"
            ControlToValidate = "F_WorkflowStepID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_WorkflowStepID_Display"
            Text='<%# Eval("xDMS_Workflows10_WorkflowName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEWorkflowStepID"
            BehaviorID="B_ACEWorkflowStepID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="WorkflowStepIDCompletionList"
            TargetControlID="F_WorkflowStepID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsHFiles.ACEWorkflowStepID_Selected"
            OnClientPopulating="script_xDmsHFiles.ACEWorkflowStepID_Populating"
            OnClientPopulated="script_xDmsHFiles.ACEWorkflowStepID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_WorkflowNextStepID" runat="server" Text="WorkflowNextStepID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_WorkflowNextStepID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("WorkflowNextStepID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for WorkflowNextStepID."
            ValidationGroup = "xDmsHFiles"
            onblur= "script_xDmsHFiles.validate_WorkflowNextStepID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVWorkflowNextStepID"
            runat = "server"
            ControlToValidate = "F_WorkflowNextStepID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_WorkflowNextStepID_Display"
            Text='<%# Eval("xDMS_Workflows9_WorkflowName") %>'
            CssClass="myLbl"
            Runat="Server" />
          <AJX:AutoCompleteExtender
            ID="ACEWorkflowNextStepID"
            BehaviorID="B_ACEWorkflowNextStepID"
            ContextKey=""
            UseContextKey="true"
            ServiceMethod="WorkflowNextStepIDCompletionList"
            TargetControlID="F_WorkflowNextStepID"
            EnableCaching="false"
            CompletionInterval="100"
            FirstRowSelected="true"
            MinimumPrefixLength="1"
            OnClientItemSelected="script_xDmsHFiles.ACEWorkflowNextStepID_Selected"
            OnClientPopulating="script_xDmsHFiles.ACEWorkflowNextStepID_Populating"
            OnClientPopulated="script_xDmsHFiles.ACEWorkflowNextStepID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UserID" runat="server" Text="UserID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_UserID"
            CssClass = "myfktxt"
            Width="72px"
            Text='<%# Bind("UserID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for UserID."
            ValidationGroup = "xDmsHFiles"
            onblur= "script_xDmsHFiles.validate_UserID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVUserID"
            runat = "server"
            ControlToValidate = "F_UserID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
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
            OnClientItemSelected="script_xDmsHFiles.ACEUserID_Selected"
            OnClientPopulating="script_xDmsHFiles.ACEUserID_Populating"
            OnClientPopulated="script_xDmsHFiles.ACEUserID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_GroupID" runat="server" Text="GroupID :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox
            ID = "F_GroupID"
            CssClass = "myfktxt"
            Width="88px"
            Text='<%# Bind("GroupID") %>'
            AutoCompleteType = "None"
            onfocus = "return this.select();"
            ToolTip="Enter value for GroupID."
            ValidationGroup = "xDmsHFiles"
            onblur= "script_xDmsHFiles.validate_GroupID(this);"
            Runat="Server" />
          <asp:RequiredFieldValidator 
            ID = "RFVGroupID"
            runat = "server"
            ControlToValidate = "F_GroupID"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
          <asp:Label
            ID = "F_GroupID_Display"
            Text='<%# Eval("xDMS_Groups5_Description") %>'
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
            OnClientItemSelected="script_xDmsHFiles.ACEGroupID_Selected"
            OnClientPopulating="script_xDmsHFiles.ACEGroupID_Populating"
            OnClientPopulated="script_xDmsHFiles.ACEGroupID_Populated"
            CompletionSetCount="10"
            CompletionListCssClass = "autocomplete_completionListElement"
            CompletionListItemCssClass = "autocomplete_listItem"
            CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem"
            Runat="Server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_SystemRemarks" runat="server" Text="SystemRemarks :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_SystemRemarks"
            Text='<%# Bind("SystemRemarks") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsHFiles"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for SystemRemarks."
            MaxLength="200"
            Width="350px"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVSystemRemarks"
            runat = "server"
            ControlToValidate = "F_SystemRemarks"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsHFiles"
            SetFocusOnError="true" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_Purgable" runat="server" Text="Purgable :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_Purgable"
           Checked='<%# Bind("Purgable") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="CreatedOn :" /><span style="color:red">*</span>
        </td>
        <td>
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            Width="80px"
            CssClass = "mytxt"
            ValidationGroup="xDmsHFiles"
            onfocus = "return this.select();"
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
            ValidationGroup = "xDmsHFiles"
            IsValidEmpty = "false"
            SetFocusOnError="true" />
        </td>
      <td></td><td></td></tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_UserRemarks" runat="server" Text="UserRemarks :" />
        </td>
        <td colspan="3">
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
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSxDmsHFiles"
  DataObjectTypeName = "SIS.xDMS.xDmsHFiles"
  InsertMethod="xDmsHFilesInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsHFiles"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
