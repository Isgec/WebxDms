<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_xDmsUGroups.aspx.vb" Inherits="EF_xDmsUGroups" title="Edit: DMS Groups" %>
<asp:Content ID="CPHxDmsUGroups" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsUGroups" runat="server" Text="&nbsp;Edit: DMS Groups"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsUGroups" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsUGroups"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "xDmsUGroups"
    runat = "server" />
<asp:FormView ID="FVxDmsUGroups"
  runat = "server"
  DataKeyNames = "GroupID"
  DataSourceID = "ODSxDmsUGroups"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GroupID" runat="server" ForeColor="#CC6633" Text="GroupID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GroupID"
            Text='<%# Bind("GroupID") %>'
            ToolTip="Value of GroupID."
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
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            Width="408px"
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsUGroups"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            runat="server" />
          <asp:RequiredFieldValidator 
            ID = "RFVDescription"
            runat = "server"
            ControlToValidate = "F_Description"
            ErrorMessage = "<div class='errorLG'>Required!</div>"
            Display = "Dynamic"
            EnableClientScript = "true"
            ValidationGroup = "xDmsUGroups"
            SetFocusOnError="true" />
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
          <asp:Label ID="L_IsAdmin" runat="server" Text="Is Admin :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_IsAdmin"
            Checked='<%# Bind("IsAdmin") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_IsSAdmin" runat="server" Text="IsSAdmin :" />&nbsp;
        </td>
        <td>
          <asp:CheckBox ID="F_IsSAdmin"
            Checked='<%# Bind("IsSAdmin") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreateRootLevelFolder" runat="server" Text="CreateRootLevelFolder :" />&nbsp;
        </td>
        <td colspan="3">
          <asp:CheckBox ID="F_CreateRootLevelFolder"
            Checked='<%# Bind("CreateRootLevelFolder") %>'
            CssClass = "mychk"
            runat="server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
        </td>
        <td>
          <asp:TextBox ID="F_CreatedOn"
            Text='<%# Bind("CreatedOn") %>'
            ToolTip="Value of Created On."
            Enabled = "False"
            Width="168px"
            CssClass = "dmytxt"
            runat="server" />
        </td>
        <td class="alignright">
          <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
        </td>
        <td>
          <asp:TextBox
            ID = "F_CreatedBy"
            Width="72px"
            Text='<%# Bind("CreatedBy") %>'
            Enabled = "False"
            ToolTip="Value of Created By."
            CssClass = "dmyfktxt"
            Runat="Server" />
          <asp:Label
            ID = "F_CreatedBy_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
    </table>
  </div>
<fieldset class="ui-widget-content page">
<legend>
    <asp:Label ID="LabelxDmsUGroupUsers" runat="server" Text="&nbsp;List: Group Users"></asp:Label>
</legend>
<div class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsUGroupUsers" runat="server">
  <ContentTemplate>
    <table width="100%"><tr><td class="sis_formview"> 
    <LGM:ToolBar0 
      ID = "TBLxDmsUGroupUsers"
      ToolType = "lgNMGrid"
      EditUrl = "~/xDMS_Main/App_Edit/EF_xDmsUGroupUsers.aspx"
      AddUrl = "~/xDMS_Main/App_Create/AF_xDmsUGroupUsers.aspx"
      AddPostBack = "True"
      EnableExit = "false"
      ValidationGroup = "xDmsUGroupUsers"
      runat = "server" />
    <asp:UpdateProgress ID="UPGSxDmsUGroupUsers" runat="server" AssociatedUpdatePanelID="UPNLxDmsUGroupUsers" DisplayAfter="100">
      <ProgressTemplate>
        <span style="color: #ff0033">Loading...</span>
      </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:GridView ID="GVxDmsUGroupUsers" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsUGroupUsers" DataKeyNames="GroupID,UserID">
      <Columns>
        <asp:TemplateField HeaderText="EDIT">
          <ItemTemplate>
            <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="GroupID" SortExpression="[xDMS_Groups2].[Description]">
          <ItemTemplate>
             <asp:Label ID="L_GroupID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("GroupID") %>' Text='<%# Eval("xDMS_Groups2_Description") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="UserID" SortExpression="[aspnet_users1].[UserFullName]">
          <ItemTemplate>
             <asp:Label ID="L_UserID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UserID") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
          </ItemTemplate>
          <HeaderStyle Width="100px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Delete">
          <ItemTemplate>
            <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Apply">
          <ItemTemplate>
            <asp:ImageButton ID="cmdApply" ValidationGroup='<%# "Apply" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApplyWFVisible") %>' Enabled='<%# EVal("ApplyWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Apply" SkinID="Apply" OnClientClick='<%# "return Page_ClientValidate(""Apply" & Container.DataItemIndex & """) && confirm(""Apply record ?"");" %>' CommandName="ApplyWF" CommandArgument='<%# Container.DataItemIndex %>' />
          </ItemTemplate>
          <ItemStyle CssClass="alignCenter" />
          <HeaderStyle CssClass="alignCenter" Width="30px" />
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Forward">
          <ItemTemplate>
            <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Forward" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Forward record ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
      ID = "ODSxDmsUGroupUsers"
      runat = "server"
      DataObjectTypeName = "SIS.xDMS.xDmsUGroupUsers"
      OldValuesParameterFormatString = "original_{0}"
      SelectMethod = "xDmsUGroupUsersSelectList"
      TypeName = "SIS.xDMS.xDmsUGroupUsers"
      SelectCountMethod = "xDmsUGroupUsersSelectCount"
      SortParameterName="OrderBy" EnablePaging="True">
      <SelectParameters >
        <asp:ControlParameter ControlID="F_GroupID" PropertyName="Text" Name="GroupID" Type="Int32" Size="10" />
        <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
        <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
      </SelectParameters>
    </asp:ObjectDataSource>
    <br />
  </td></tr></table>
  </ContentTemplate>
  <Triggers>
    <asp:AsyncPostBackTrigger ControlID="GVxDmsUGroupUsers" EventName="PageIndexChanged" />
  </Triggers>
</asp:UpdatePanel>
</div>
</fieldset>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSxDmsUGroups"
  DataObjectTypeName = "SIS.xDMS.xDmsUGroups"
  SelectMethod = "xDmsUGroupsGetByID"
  UpdateMethod="xDmsUGroupsUpdate"
  DeleteMethod="xDmsUGroupsDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsUGroups"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="GroupID" Name="GroupID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
