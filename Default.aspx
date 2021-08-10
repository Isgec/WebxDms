<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="LGDefault" title="Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" ClientIDMode="Static" runat="Server">
  <style>
    .db-container{
      display:flex;
      flex-direction:row;
      flex-wrap:wrap;
    }
    .db-container>div{
      background-color:rgba(192, 227, 252, 0.56);
      background-image:url(Images/DMS-Flow.png);
      background-position-x:center;
      background-size:contain;
      background-repeat:no-repeat;
      margin: 10px;
      border-radius:5px;
    }
    .db-container>div>div{
      background-color: #f1f1f1;
      margin: 5px;
      width: 400px;
    }
    .db-col{
      display:flex;
      flex-direction:column;
    }
    .db-col>div{
      margin:2px;
      height:22px;
    }
    .db-row{
      display:flex;
      flex-direction:row;
      background-color:antiquewhite;
      justify-content:space-around;
    }
    .db-row>div{
      margin:2px;
      padding:2px;
      border:1pt solid lightgrey;
      width:100px;
      background-color:aliceblue;
    }
    .folder-count:hover{
      background-color:rgba(181, 252, 3, 0.64);
      font-weight:bolder;
    }
  </style>
  <LGM:LGMessageBox
	 ID="LGMessage1"
	 runat="server" />

  <div class="db-container" id="afterlogin" runat="server" visible="false">
    <div>
      <div class="nt-but-cadet" style="text-align:center;font-size:16px;text-shadow:3px 2px 1px gray;">New File Count</div>
      <div style="line-height:150px;text-align:center;padding:4px;font-size:30px;text-shadow:3px 2px 1px gray;opacity:0.8;" id="TotalFilesCount" runat="server"></div>
      <div style="padding:4px;text-align:center;">
        <asp:Button 
          ID="cmdDms" 
          runat="server" 
          Text="VIEW ISGEC DMS" 
          CssClass="nt-but-danger"
          Font-Size="20px" 
          ClientIDMode="Static"
          OnClick="cmdDms_Click"
          style="padding:4px;border-radius:5px;box-shadow:5px 10px 8px rgba(136, 136, 136, 0.64);" />

      </div>
    </div>
    <div>
      <div class="nt-but-cadet" style="padding:4px;text-align:center;font-size:16px;text-shadow:3px 2px 1px gray;">Folder Wise New File Count</div>
      <div style="min-height:200px;max-height:300px;overflow-y:auto;padding:4px;opacity:0.8;">
      <div id="FolderWiseCount" runat="server" class="db-col">
      </div>
      </div>
    </div>
    <div>
      <div class="nt-but-cadet" style="text-align:center;font-size:16px;text-shadow:3px 2px 1px gray;">Submitted for Approval</div>
      <div style="line-height:150px;text-align:center;padding:4px;font-size:30px;text-shadow:3px 2px 1px gray;opacity:0.8;" id="TotalsubmittedFilesCount" runat="server">0</div>
      <div style="padding:4px;text-align:center;">
        <asp:Button 
          ID="cmdSubmitted" 
          runat="server" 
          Text="VIEW SUBMITTED FILES" 
          CssClass="nt-but-danger"
          Font-Size="20px" 
          OnClientClick="lgMessageBox.ExecuteURL('Under Approval', 'xDms_Main/App_Controls/GF_UnderApproval.aspx'); return false;"
          ClientIDMode="Static"
          style="padding:4px;border-radius:5px;box-shadow:5px 10px 8px rgba(136, 136, 136, 0.64);" />
      </div>
    </div>
  </div>
  <div class="db-container" id="beforelogin" runat="server" visible="true" style="align-items:center;">
    <div style="min-height:500px;width:100%;"></div>
  </div>
  <div id="divMigrate" runat="server">
    <asp:CheckBox ID="F_Forced" runat="server" Text="Forced Re-Import" TextAlign="Left" />
    <asp:TextBox ID="F_TransmittalID" runat="server" style="text-transform:uppercase" placeholder="Transmittal ID"></asp:TextBox>
    <asp:Button ID="cmdMigrate" runat="server" Text="Migrate" />
    <div id="errmsg" runat="server"></div>
  </div>
</asp:Content>

