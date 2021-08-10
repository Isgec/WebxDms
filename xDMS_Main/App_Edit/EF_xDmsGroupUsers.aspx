<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_xDmsGroupUsers.aspx.vb" Inherits="EF_xDmsGroupUsers" title="Edit: Group Users" %>
<asp:Content ID="CPHxDmsGroupUsers" ContentPlaceHolderID="cph1" Runat="Server">
<div id="div1" class="ui-widget-content page">
<div id="div2" class="caption">
    <asp:Label ID="LabelxDmsGroupUsers" runat="server" Text="&nbsp;Edit: Group Users"></asp:Label>
</div>
<div id="div3" class="pagedata">
<asp:UpdatePanel ID="UPNLxDmsGroupUsers" runat="server" >
<ContentTemplate>
  <LGM:ToolBar0 
    ID = "TBLxDmsGroupUsers"
    ToolType = "lgNMEdit"
    UpdateAndStay = "False"
    ValidationGroup = "xDmsGroupUsers"
    runat = "server" />
<asp:FormView ID="FVxDmsGroupUsers"
  runat = "server"
  DataKeyNames = "GroupID,UserID"
  DataSourceID = "ODSxDmsGroupUsers"
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
          <b><asp:Label ID="L_UserID" runat="server" ForeColor="#CC6633" Text="UserID :" /><span style="color:red">*</span></b>
        </td>
        <td colspan="3">
          <asp:TextBox
            ID = "F_UserID"
            Width="72px"
            Text='<%# Bind("UserID") %>'
            CssClass = "mypktxt"
            Enabled = "False"
            ToolTip="Value of UserID."
            Runat="Server" />
          <asp:Label
            ID = "F_UserID_Display"
            Text='<%# Eval("aspnet_users1_UserFullName") %>'
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
  ID = "ODSxDmsGroupUsers"
  DataObjectTypeName = "SIS.xDMS.xDmsGroupUsers"
  SelectMethod = "xDmsGroupUsersGetByID"
  UpdateMethod="xDmsGroupUsersUpdate"
  DeleteMethod="xDmsGroupUsersDelete"
  OldValuesParameterFormatString = "original_{0}"
  TypeName = "SIS.xDMS.xDmsGroupUsers"
  runat = "server" >
<SelectParameters>
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="GroupID" Name="GroupID" Type="Int32" />
  <asp:QueryStringParameter DefaultValue="0" QueryStringField="UserID" Name="UserID" Type="String" />
</SelectParameters>
</asp:ObjectDataSource>
</div>
</div>
</asp:Content>
