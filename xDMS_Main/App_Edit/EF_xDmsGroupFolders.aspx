<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_xDmsGroupFolders.aspx.vb" Inherits="EF_xDmsGroupFolders" title="Edit: Group Folders" %>
<asp:Content ID="CPHxDmsGroupFolders" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsGroupFolders" runat="server" Text="&nbsp;Edit: Group Folders"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsGroupFolders" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsGroupFolders"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "xDmsGroupFolders"
    runat = "server" />
<asp:FormView ID="FVxDmsGroupFolders"
  runat = "server"
  DataKeyNames = "GroupID,FolderID"
  DataSourceID = "ODSxDmsGroupFolders"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_GroupID" runat="server" ForeColor="#CC6633" Text="GroupID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_GroupID"
            Width="88px"
            Text='<%# Bind("GroupID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of GroupID."
            Runat="Server" />
          <asp:Label
            ID = "F_GroupID_Display"
            Text='<%# Eval("xDMS_Groups2_Description") %>'
            CssClass="myLbl"
            Runat="Server" />
        </td>
      </tr>
      <tr><td colspan="4" style="border-top: solid 1pt LightGrey" ></td></tr>
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FolderID" runat="server" ForeColor="#CC6633" Text="FolderID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FolderID"
            Width="88px"
            Text='<%# Bind("FolderID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of FolderID."
            Runat="Server" />
          <asp:Label
            ID = "F_FolderID_Display"
            Text='<%# Eval("xDMS_Folders1_FolderName") %>'
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
    </table>
  </div>
  </EditItemTemplate>
</asp:FormView>
  </ContentTemplate>
</asp:UpdatePanel>
<asp:ObjectDataSource 
  ID = "ODSxDmsGroupFolders"
  DataObjectTypeName = "SIS.xDMS.xDmsGroupFolders"
  SelectMethod = "xDmsGroupFoldersGetByID"
  UpdateMethod="xDmsGroupFoldersUpdate"
  DeleteMethod="xDmsGroupFoldersDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsGroupFolders"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="GroupID" Name="GroupID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FolderID" Name="FolderID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
