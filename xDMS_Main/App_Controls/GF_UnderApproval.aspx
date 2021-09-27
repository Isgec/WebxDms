<%@ Page Language="VB" MasterPageFile="~/PlaneMaster.master" AutoEventWireup="False" CodeFile="GF_UnderApproval.aspx.vb" Inherits="GF_xDmsFiles" title="Maintain List: DMS Files" %>
<asp:Content ID="CPHxDmsFiles" ContentPlaceHolderID="cph1" runat="Server">
  <style>
    .nt-but-grey>img{
      height:10px;
      width:10px;
    }
    .nt-xloading{
      background-image:url(../../Images/spin1.gif);
      background-repeat:no-repeat;
      background-position:center;
      width: 100%;
      height: 100%;            
      position: absolute;
      top: 0;
      left: 0;
      opacity: 0.8;
    }
    .loading{
      z-index:10;
    }
    .nt-sticky{
      justify-content:flex-end;
    }
    .nt-xcol {
      display: flex;
      flex-direction: column;
      flex-wrap:nowrap;
    }

    .nt-xrow {
      display: flex;
      flex-direction: row;
      line-height: 10px;
      flex-wrap:nowrap;
    }

    .nt-col {
      display: flex;
      flex-direction: column;
    }

    .nt-row {
      display: flex;
      flex-direction: row;
      line-height: 10px;
      flex-wrap:wrap;
    }
    .nt-row>div{
      padding:3px;
    }

    .nt-sep {
      min-width: 10px!important;
    }

    .nt-xsep {
      min-width: 10px!important;
      cursor: pointer;
    }

    .nt-item {
      font-size: .8rem;
      color: black;
      white-space: nowrap;
      cursor: pointer;
    }

    .nt-count {
      font-size: .5rem;
      color: black;
      background-color: #cdd4fc;
      border-radius: 10px;
      min-width:15px;
      text-align:center;
    }
    .nt-fcount {
      font-size: .5rem;
      color: black;
      background-color:#fbdfb8;
      border-radius: 10px;
      min-width:15px;
      text-align:center;
    }

    .nt-sep,
    .nt-xsep,
    .nt-count,
    .nt-fcount,
    .nt-item {
      margin: 3px;
      padding: 3px;
    }

    .nt-item-row:hover {
      background-color: #f4fb58;
    }
    .nt-lbl{
      border:none;
      width:auto;
      font-size:0.8rem;
      min-width:200px;
    }
    .nt-txt{
      border:1pt solid #C0C0C0;
      background-color: #e4e4e4;
      border-radius:6px;
      padding:4px;
      width:100%;
      font-size:0.9rem;
    }
    .nt-lbl,
    .nt-txt{
      margin-top:3px;
      font-family:Tahoma;
    }
    .nt-txt:hover{
      border:1pt solid black;
      background-color:white;
    }
    .nt-con-mnu{
      position:absolute;z-index:600;background-color:#f4fb58;padding:10px;border-radius:8px;
      box-shadow: 5px 10px 8px #888888;
      border:1pt solid #a2a732;
    }
    .nt-mnu{
      cursor:pointer;
      padding:5px;
    }
    .nt-mnu:hover{
      background-color:#cad30b;
      color:#fe1504;
    }
    .nt-modal-container{
      display: none; 
      position: fixed;
      z-index:600; 
      left: 0;
      top: 0;
      width: 100%;
      height: 100%;
      overflow:hidden;
      background-color: rgb(0,0,0);
      background-color: rgba(0,0,0,0.4);
      vertical-align:middle;
    }

    .nt-modal-window {
      border: 1pt solid #b7b5b5;
      border-radius: 6px;
      background-color: #dddbdb;
      margin: auto;
      position: absolute;
      top: 50%;
      left: 50%;
      -ms-transform: translate(-50%, -50%);
      transform: translate(-50%, -50%);

    }
    .nt-modal-content
    {
      border: 1pt solid #b7b5b5;
      border-radius: 6px;
      background-color: #dddbdb;
      padding:5px;
    }
    .nt-modal-command {
      margin-top:10px;
      justify-content:flex-end;
    }
    .nt-modal-command>div {
      margin:10px;
    }
    .nt-filelist{
      padding:5px;
    }
    .nt-filelist:hover{
      background-color:#C0C0C0;
    }
    .nt-filename{
      font-size:0.8rem;
      font-family:Tahoma;
      color:blue;
      width:60%;
      margin-top:6px;
    }
    .nt-pbar{
      background-color:#4cff00;
      width:0%;
      height:100%;
    }
    .nt-xpbar{
      width:20%;
      background-color:#f8c3bf;
      border:1pt solid #fc685d;
    }
    .nt-pbarval{
      font-size:0.8rem;
      font-family:Tahoma;
      width:10%;
      color:red;
      margin-top:5px;
      cursor:pointer;
    }

    .nt-filedel{
      font-size:0.9rem;
      font-weight:bold;
      font-family:Tahoma;
      width:5%;
      color:red;
      margin-top:5px;
      cursor:pointer;
    }
  </style>
  <asp:UpdatePanel ID="UPNLxDmsFiles" runat="server">
    <ContentTemplate>
      <div class="nt-col" style="width:1000px;height:500px;">
        <div>
          <LGM:ToolBarDMS ID="TBLxDmsFiles" runat="server" />
        </div>
        <div>
          <asp:Panel ID="pnlH" runat="server" CssClass="cph_filter">
            <div style="padding: 5px; cursor: pointer; vertical-align: middle;">
              <div style="float: left;">Filter Records </div>
              <div style="float: left; margin-left: 20px;">
                <asp:Label ID="lblH" runat="server">(Show Filters...)</asp:Label>
              </div>
              <div style="float: right; vertical-align: middle;">
                <asp:ImageButton ID="imgH" runat="server" ImageUrl="~/images/ua.png" AlternateText="(Show Filters...)" />
              </div>
            </div>
          </asp:Panel>
          <asp:Panel ID="pnlD" runat="server" CssClass="cp_filter" Height="0">
            <table>
              <tr>
                <td class="alignright">
                  <b>
                    <asp:Label ID="L_FileID" runat="server" Text="File ID :" /></b>
                </td>
                <td>
                  <asp:TextBox ID="F_FileID"
                    Text=""
                    Width="88px"
                    Style="text-align: right"
                    CssClass="mytxt"
                    MaxLength="10"
                    onfocus="return this.select();"
                    runat="server" />
                  <AJX:MaskedEditExtender
                    ID="MEEFileID"
                    runat="server"
                    Mask="9999999999"
                    AcceptNegative="Left"
                    MaskType="Number"
                    MessageValidatorTip="true"
                    InputDirection="RightToLeft"
                    ErrorTooltipEnabled="true"
                    TargetControlID="F_FileID" />
                  <AJX:MaskedEditValidator
                    ID="MEVFileID"
                    runat="server"
                    ControlToValidate="F_FileID"
                    ControlExtender="MEEFileID"
                    InvalidValueMessage="*"
                    EmptyValueMessage=""
                    EmptyValueBlurredText=""
                    Display="Dynamic"
                    EnableClientScript="true"
                    IsValidEmpty="True"
                    SetFocusOnError="true" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b>
                    <asp:Label ID="L_FolderID" runat="server" Text="Folder :" /></b>
                </td>
                <td>
                  <asp:TextBox
                    ID="F_FolderID"
                    CssClass="myfktxt"
                    Width="88px"
                    Text=""
                    onfocus="return this.select();"
                    AutoCompleteType="None"
                    onblur="validate_FolderID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_FolderID_Display"
                    Text=""
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACEFolderID"
                    BehaviorID="B_ACEFolderID"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="FolderIDCompletionList"
                    TargetControlID="F_FolderID"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="ACEFolderID_Selected"
                    OnClientPopulating="ACEFolderID_Populating"
                    OnClientPopulated="ACEFolderID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b>
                    <asp:Label ID="L_StatusID" runat="server" Text="Status :" /></b>
                </td>
                <td>
                  <asp:TextBox
                    ID="F_StatusID"
                    CssClass="myfktxt"
                    Width="88px"
                    Text=""
                    onfocus="return this.select();"
                    AutoCompleteType="None"
                    onblur="validate_StatusID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_StatusID_Display"
                    Text=""
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACEStatusID"
                    BehaviorID="B_ACEStatusID"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="StatusIDCompletionList"
                    TargetControlID="F_StatusID"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="ACEStatusID_Selected"
                    OnClientPopulating="ACEStatusID_Populating"
                    OnClientPopulated="ACEStatusID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b>
                    <asp:Label ID="L_ParentIFileID" runat="server" Text="ParentI File ID :" /></b>
                </td>
                <td>
                  <asp:TextBox
                    ID="F_ParentIFileID"
                    CssClass="myfktxt"
                    Width="88px"
                    Text=""
                    onfocus="return this.select();"
                    AutoCompleteType="None"
                    onblur="validate_ParentIFileID(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_ParentIFileID_Display"
                    Text=""
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACEParentIFileID"
                    BehaviorID="B_ACEParentIFileID"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="ParentIFileIDCompletionList"
                    TargetControlID="F_ParentIFileID"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="ACEParentIFileID_Selected"
                    OnClientPopulating="ACEParentIFileID_Populating"
                    OnClientPopulated="ACEParentIFileID_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <b>
                    <asp:Label ID="L_StatusBy" runat="server" Text="Status By :" /></b>
                </td>
                <td>
                  <asp:TextBox
                    ID="F_StatusBy"
                    CssClass="myfktxt"
                    Width="72px"
                    Text=""
                    onfocus="return this.select();"
                    AutoCompleteType="None"
                    onblur="validate_StatusBy(this);"
                    runat="Server" />
                  <asp:Label
                    ID="F_StatusBy_Display"
                    Text=""
                    runat="Server" />
                  <AJX:AutoCompleteExtender
                    ID="ACEStatusBy"
                    BehaviorID="B_ACEStatusBy"
                    ContextKey=""
                    UseContextKey="true"
                    ServiceMethod="StatusByCompletionList"
                    TargetControlID="F_StatusBy"
                    CompletionInterval="100"
                    FirstRowSelected="true"
                    MinimumPrefixLength="1"
                    OnClientItemSelected="ACEStatusBy_Selected"
                    OnClientPopulating="ACEStatusBy_Populating"
                    OnClientPopulated="ACEStatusBy_Populated"
                    CompletionSetCount="10"
                    CompletionListCssClass="autocomplete_completionListElement"
                    CompletionListItemCssClass="autocomplete_listItem"
                    CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
                    runat="Server" />
                </td>
              </tr>
            </table>
          </asp:Panel>
          <AJX:CollapsiblePanelExtender ID="cpe1" runat="Server" TargetControlID="pnlD" ExpandControlID="pnlH" CollapseControlID="pnlH" Collapsed="True" TextLabelID="lblH" ImageControlID="imgH" ExpandedText="(Hide Filters...)" CollapsedText="(Show Filters...)" ExpandedImage="~/images/ua.png" CollapsedImage="~/images/da.png" SuppressPostBack="true" />
          <asp:GridView ID="GVxDmsFiles" SkinID="gv_silver"  runat="server" DataSourceID="ODSxDmsFiles" DataKeyNames="FileID">
            <Columns>
              <asp:TemplateField HeaderText="File ID" SortExpression="[xDMS_Files].[FileID]">
                <ItemTemplate>
                  <asp:Label ID="LabelFileID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
                <HeaderStyle CssClass="alignCenter" Width="40px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="File Name" SortExpression="[xDMS_Files].[FileName]">
                <ItemTemplate>
                  <asp:LinkButton ID="L_FileName" runat="server" Font-Underline="true" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("FileName") %>' OnClientClick='<%# EVal("DownloadLink") %>'></asp:LinkButton>
                </ItemTemplate>
                <ItemStyle CssClass="alignleft" />
                <HeaderStyle CssClass="alignleft" Width="300px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="File Rev" SortExpression="[xDMS_Files].[FileRev]">
                <ItemTemplate>
                  <asp:Label ID="LabelFileRev" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("FileRev") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
                <HeaderStyle CssClass="alignCenter" Width="50px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Status By" SortExpression="[aspnet_users1].[UserFullName]">
                <ItemTemplate>
                    <asp:Label ID="L_StatusBy" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("StatusBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignleft" />
                <HeaderStyle CssClass="alignleft" Width="100px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Status On" SortExpression="[xDMS_Files].[StatusOn]">
                <ItemTemplate>
                  <asp:Label ID="LabelStatusOn" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("StatusOn") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
              <HeaderStyle CssClass="alignCenter" Width="100px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Status" SortExpression="[xDMS_States5].[StatusName]">
                <ItemTemplate>
                  <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("xDMS_States5_StatusName") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
                <HeaderStyle CssClass="alignCenter" Width="100px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Size" SortExpression="[xDMS_Files].[FileSize]">
                <ItemTemplate>
                    <asp:Label ID="L_strFileSize" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("strFileSize") %>' Text='<%# Eval("strFileSize") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="alignright" />
                <HeaderStyle CssClass="alignright" Width="50px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Comments" >
                <ItemTemplate>
                  <asp:TextBox ID="F_UserRemarks" runat="server" CssClass="mytxt" Width="250px" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>'></asp:TextBox>
                  <asp:RequiredFieldValidator 
                    ID = "RFVUserRemarks"
                    runat = "server"
                    ControlToValidate = "F_UserRemarks"
                    ErrorMessage = "<div class='errorLG'>Required!</div>"
                    Display = "Dynamic"
                    EnableClientScript = "true"
                    ValidationGroup='<%# "Delete" & Container.DataItemIndex %>'
                    SetFocusOnError="true" />
                </ItemTemplate>
                <ItemStyle CssClass="alignleft" />
                <HeaderStyle CssClass="alignleft" Width="250px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Return">
                <ItemTemplate>
                  <asp:ImageButton ID="cmdReturn" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server"  AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Return" SkinID="Return" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Return record ?"");" %>' CommandName="ReturnWF" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
                <HeaderStyle CssClass="alignCenter" Width="30px" />
              </asp:TemplateField>
              <asp:TemplateField HeaderText="Approve">
                <ItemTemplate>
                  <asp:ImageButton ID="cmdInitiateWF" runat="server"  AlternateText='<%# Eval("PrimaryKey") %>' ToolTip="Approve" SkinID="forward" OnClientClick="return confirm('Approve record ?');" CommandName="ApproveWF" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
                <ItemStyle CssClass="alignCenter" />
                <HeaderStyle CssClass="alignCenter" Width="30px" />
              </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
              <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
            </EmptyDataTemplate>
          </asp:GridView>
          <asp:ObjectDataSource
            ID="ODSxDmsFiles"
            runat="server"
            DataObjectTypeName="SIS.xDMS.xDmsFiles"
            OldValuesParameterFormatString="original_{0}"
            SelectMethod="UnderApprovalSelectList"
            TypeName="SIS.xDMS.xDmsFiles"
            SelectCountMethod="xDmsFilesSelectCount"
            SortParameterName="OrderBy" EnablePaging="True">
            <SelectParameters>
              <asp:ControlParameter ControlID="F_FileID" PropertyName="Text" Name="FileID" Type="Int32" Size="10" />
              <asp:ControlParameter ControlID="F_FolderID" PropertyName="Text" Name="FolderID" Type="Int32" Size="10" />
              <asp:ControlParameter ControlID="F_StatusID" PropertyName="Text" Name="StatusID" Type="Int32" Size="10" />
              <asp:ControlParameter ControlID="F_ParentIFileID" PropertyName="Text" Name="ParentIFileID" Type="Int32" Size="10" />
              <asp:ControlParameter ControlID="F_StatusBy" PropertyName="Text" Name="StatusBy" Type="String" Size="8" />
              <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
              <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
            </SelectParameters>
          </asp:ObjectDataSource>
        </div>
      </div>
    </ContentTemplate>
    <Triggers>
      <asp:AsyncPostBackTrigger ControlID="GVxDmsFiles" EventName="PageIndexChanged" />
      <asp:AsyncPostBackTrigger ControlID="F_FileID" />
      <asp:AsyncPostBackTrigger ControlID="F_FolderID" />
      <asp:AsyncPostBackTrigger ControlID="F_StatusID" />
      <asp:AsyncPostBackTrigger ControlID="F_ParentIFileID" />
      <asp:AsyncPostBackTrigger ControlID="F_StatusBy" />
    </Triggers>
  </asp:UpdatePanel>
  <script>
    parent.lgMessageBox.resizeFrame(1000,500);
  </script>
</asp:Content>
