<%@ Page Language="VB" MasterPageFile="~/PlaneMaster.master" AutoEventWireup="false" ClientIDMode="Static" CodeFile="EF_FoldersUser.aspx.vb" Inherits="EF_FoldersUser" %>
<asp:Content ID="CPHxDmsFolders" ContentPlaceHolderID="cph1" runat="Server">
  <asp:UpdatePanel ID="UPNLxDmsFolders" runat="server">
    <ContentTemplate>
      <asp:FormView ID="FVxDmsFolders"
        runat="server"
        DataKeyNames="FolderID"
        DataSourceID="ODSxDmsFolders"
        DefaultMode="Edit"
        CssClass="sis_formview">
        <EditItemTemplate>
          <div class="nt-col" style="width:450px;">
            <table style="margin: auto; border: solid 1pt lightgrey; font-size: 12px;">
              <tr>
                <td class="alignright">
                  <b>
                    <asp:Label ID="L_FolderID" runat="server" ForeColor="#CC6633" Text="Folder ID :" /><span style="color: red">*</span></b>
                </td>
                <td colspan="3">
                  <asp:TextBox ID="F_FolderID"
                    Text='<%# Bind("FolderID") %>'
                    Enabled="False"
                    CssClass="mypktxt"
                    Width="88px"
                    Style="text-align: right"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_FolderName" runat="server" Text="Folder Name :" /><span style="color: red">*</span>
                </td>
                <td>
                  <asp:TextBox ID="F_FolderName"
                    Text='<%# Bind("FolderName") %>'
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    ValidationGroup="xDmsFolders"
                    ToolTip="Enter value for Folder Name."
                    MaxLength="250"
                    Width="350px"
                    runat="server" />
                  <br />
                  <asp:Label ID="L_ErrMsgxDmsFolders" runat="server" ForeColor="Red" Text=""></asp:Label>
                  <asp:RequiredFieldValidator
                    ID="RFVFolderName"
                    runat="server"
                    ControlToValidate="F_FolderName"
                    ErrorMessage="<div class='errorLG'>Required!</div>"
                    Display="Dynamic"
                    EnableClientScript="true"
                    ValidationGroup="xDmsFolders"
                    SetFocusOnError="true" />
                </td>
              </tr>
              <tr>
                <td class="alignright">
                  <asp:Label ID="L_KeyWords" runat="server" Text="Key Words :" />&nbsp;
                </td>
                <td>
                  <asp:TextBox ID="F_KeyWords"
                    Text='<%# Bind("KeyWords") %>'
                    CssClass="mytxt"
                    onfocus="return this.select();"
                    onblur="this.value=this.value.replace(/\'/g,'');"
                    ToolTip="Enter value for Key Words."
                    MaxLength="500"
                    Width="350px"
                    runat="server" />
                </td>
              </tr>
              <tr>
                <td colspan="2" style="text-align:right;padding:8px;">
                  <asp:Button ID="cmdSave" runat="server" CommandName="Update" Font-Size="14px" Text="Submit" CssClass="nt-but-primary" ValidationGroup="xDmsFolders" />
                </td>
              </tr>
            </table>
          </div>
        </EditItemTemplate>
      </asp:FormView>
    </ContentTemplate>
  </asp:UpdatePanel>
  <asp:ObjectDataSource
    ID="ODSxDmsFolders"
    DataObjectTypeName="SIS.xDMS.xDmsFolders"
    SelectMethod="xDmsFoldersGetByID"
    UpdateMethod="UZ_xDmsFoldersUpdate"
    OldValuesParameterFormatString="original_{0}"
    TypeName="SIS.xDMS.xDmsFolders"
    runat="server">
    <SelectParameters>
      <asp:QueryStringParameter DefaultValue="0" QueryStringField="FolderID" Name="FolderID" Type="Int32" />
    </SelectParameters>
  </asp:ObjectDataSource>
  <script>
    parent.lgMessageBox.resizeFrame(450,200);
  </script>
</asp:Content>
