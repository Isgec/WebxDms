<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="AF_xDmsUGroups.aspx.vb" Inherits="AF_xDmsUGroups" title="Add: DMS Groups" %>
<asp:Content ID="CPHxDmsUGroups" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsUGroups" runat="server" Text="&nbsp;Add: DMS Groups"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsUGroups" runat="server" >
  <ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsUGroups"
    ToolType = "lgNMAdd"
    InsertAndStay = "False"
    AfterInsertURL = "~/xDMS_Main/App_Edit/EF_xDmsUGroups.aspx"
    ValidationGroup = "xDmsUGroups"
    runat = "server" />
<asp:FormView ID="FVxDmsUGroups"
  runat = "server"
  DataKeyNames = "GroupID"
  DataSourceID = "ODSxDmsUGroups"
  DefaultMode = "Insert" CssClass="sis_formview">
  <InsertItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <asp:Label ID="L_ErrMsgxDmsUGroups" runat="server" ForeColor="Red" Font-Bold="true" Text=""></asp:Label>
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GroupID" ForeColor="#CC6633" runat="server" Text="GroupID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_GroupID" Enabled="False" CssClass="mypktxt" Width="88px" runat="server" Text="0" />
        </td>
      </tr>
      <tr>
        <td class="alignright">
          <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color:red">*</span>
        </td>
        <td colspan="3">
          <asp:TextBox ID="F_Description"
            Text='<%# Bind("Description") %>'
            CssClass = "mytxt"
            onfocus = "return this.select();"
            ValidationGroup="xDmsUGroups"
            onblur= "this.value=this.value.replace(/\'/g,'');"
            ToolTip="Enter value for Description."
            MaxLength="50"
            Width="408px"
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
          <asp:Label ID="L_CanAuthorizeFolder" runat="server" Text="Can Authorize Folder :" />&nbsp;
        </td>
        <td colspan="3">
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
        <td colspan="3">
          <asp:CheckBox ID="F_CanPassAuthorization"
           Checked='<%# Bind("CanPassAuthorization") %>'
           CssClass = "mychk"
           runat="server" />
        </td>
      </tr>
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
    </table>
    </div>
  </InsertItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSxDmsUGroups"
  DataObjectTypeName = "SIS.xDMS.xDmsUGroups"
  InsertMethod="xDmsUGroupsInsert"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsUGroups"
  SelectMethod = "GetNewRecord"
  runat = "server" >
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
