<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Login0.ascx.vb" Inherits="Login0" %>
<div>
  <asp:LoginView ID="LoginFormView1" runat="server">
    <AnonymousTemplate>
      <asp:Login ID="Login0" OnLoggedIn="LoggedIn" OnLoginError="LoginError" OnLoggingIn="LoggingIn" runat="server">
        <LayoutTemplate>
          <asp:Panel ID="panel1" runat="server" DefaultButton="LoginButton">
            <table>
              <tr>
                <td>
                  <asp:Label runat="server" Font-Size="12px" Text="Login ID:"></asp:Label>
                </td>
                <td style="height: 22px">
                  <asp:TextBox ID="UserName" runat="server" CssClass="mytxt" MaxLength="20" Width="60px"></asp:TextBox>
                </td>
                <td>
                  <asp:Label ID="Label1" runat="server" Font-Size="12px" Text="Password:"></asp:Label>
                </td>
                <td style="height: 22px">
                  <asp:TextBox ID="Password" runat="server" CssClass="mytxt" MaxLength="20" TextMode="Password" Width="60px"></asp:TextBox>
                </td>
                <td style="height: 22px">
                  <asp:Button ID="LoginButton" CssClass="nt-but-danger" runat="server" Font-Size="12px" Width="70px" CommandName="Login" ValidationGroup="ctl00$ctl00$Login0" Text="Sign In" />
                </td>
              </tr>
              <tr>
                <td colspan="5" style="color:#66FF66; font-weight: bold; background-color: Black;text-align:center;" >
                  <asp:Label ID="FailureText" runat="server" EnableViewState="False"></asp:Label>
                </td>
              </tr>
            </table>
          </asp:Panel>
        </LayoutTemplate>
      </asp:Login>
    </AnonymousTemplate>
    <LoggedInTemplate>
      <table>
        <td>
          <LGM:Informations ID="Informations1" Visible="false" runat="server" />
          <asp:Label ID="sysInfo" runat="server" Text=""></asp:Label>
        </td>
        <td>
          <asp:Button    ID   ="cmdChangePW" runat="server" CssClass="nt-but-primary" Height="24px" Width="100px" OnClick="cmdChangePW_Click" Text="Change Password" /><br />
          <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="nt-but-danger" Height="14px" Width="90px" LoginText="Sign In" LogoutAction="Redirect" LogoutPageUrl="~/Default.aspx" OnLoggingOut="LoginStatus1_LoggingOut" LogoutText="Sign Out" ToolTip="Sign Out" />
        </td>
      </table>
    </LoggedInTemplate>
  </asp:LoginView>
</div>
