<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_xDmsFGroupFolders.aspx.vb" Inherits="EF_xDmsFGroupFolders" title="Edit: Folders" %>
<asp:Content ID="CPHxDmsFGroupFolders" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsFGroupFolders" runat="server" Text="&nbsp;Edit: Folders"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsFGroupFolders" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsFGroupFolders"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "xDmsFGroupFolders"
    runat = "server" />
<asp:FormView ID="FVxDmsFGroupFolders"
  runat = "server"
  DataKeyNames = "FGroupID,FolderID"
  DataSourceID = "ODSxDmsFGroupFolders"
  DefaultMode = "Edit" CssClass="sis_formview">
  <EditItemTemplate>
    <div id="frmdiv" class="ui-widget-content minipage">
    <table style="margin:auto;border: solid 1pt lightgrey">
      <tr>
        <td class="alignright">
          <b><asp:Label ID="L_FGroupID" runat="server" ForeColor="#CC6633" Text="Folder Group ID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_FGroupID"
            Width="88px"
            Text='<%# Bind("FGroupID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of Folder Group ID."
            Runat="Server" />
          <asp:Label
            ID = "F_FGroupID_Display"
            Text='<%# Eval("xDMS_FGroups1_FGroupName") %>'
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
            Text='<%# Eval("xDMS_Folders2_FolderName") %>'
            CssClass="myLbl"
            Runat="Server" />
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
  ID = "ODSxDmsFGroupFolders"
  DataObjectTypeName = "SIS.xDMS.xDmsFGroupFolders"
  SelectMethod = "xDmsFGroupFoldersGetByID"
  UpdateMethod="UZ_xDmsFGroupFoldersUpdate"
  DeleteMethod="UZ_xDmsFGroupFoldersDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsFGroupFolders"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FGroupID" Name="FGroupID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="FolderID" Name="FolderID" Type="Int32" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
