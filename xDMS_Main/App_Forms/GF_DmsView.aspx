<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="GF_DmsView.aspx.vb" Inherits="GF_DmsView" title="DMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph1" runat="Server">

  <style>
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
      font-size: 12px;
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
    .nt-selected{
     background-color:lightcyan;
    }
  </style>
  <style>
    .rst-alert {
      width: 30%;
      position: absolute;
      top: 5%;
      right: 2%;
      padding: 20px;
      background-color: #f44336;
      border-radius: 5px;
      color: white;
      z-index:600;
      box-shadow: 5px 10px 8px #888888;
    }

    .closebtn {
      margin-left: 15px;
      color: white;
      font-weight: bold;
      float: right;
      font-size: 22px;
      line-height: 20px;
      cursor: pointer;
      transition: 0.3s;
    }

      .closebtn:hover {
        color: black;
      }

  </style>
  <style>
    .dms-word-container {
      display: flex;
      flex-wrap: wrap;
      background-color: aquamarine;
      border: 1pt solid #7d8ff7;
    }

    .dms-word {
      display: flex;
      flex-direction: row;
      background-color: #e8e3e3;
      border: 1pt solid #9b9898;
      margin: 2px;
      padding: 2px;
      border-radius: 5px;
    }

    .dms-word-remove {
      padding-left: 6px;
      color: #9b9898;
      cursor: pointer;
      vertical-align: top;
    }

      .dms-word-remove:hover {
        color: orangered;
      }

    .dms-popup-container {
      display: none;
      flex-direction: column;
      background-color: #eed54d;
      border: 1pt solid #cbad06;
      position: absolute;
      z-index: 10005;
    }

    .dms-popup-value {
      background-color: #fbe778;
      border: 1pt solid #ffd800;
      margin: 1pt;
      cursor: pointer;
    }

      .dms-popup-value:hover {
        background-color: #fff5c0;
      }

  </style>
  <script>
    var script_xDmsUsers = {
      ACEUserID_Selected: function (sender, e) {
        var Prefix = sender._element.id.replace('UserID', '');
        var F_UserID = $get(sender._element.id);
        var F_UserID_Display = $get(sender._element.id + '_Display');
        var retval = e.get_value();
        var p = retval.split('|');
        F_UserID.value = p[0];
        F_UserID_Display.innerHTML = e.get_text();
      },
      ACEUserID_Populating: function (sender, e) {
        var p = sender.get_element();
        var Prefix = sender._element.id.replace('UserID', '');
        p.style.backgroundImage = 'url(../../images/loader.gif)';
        p.style.backgroundRepeat = 'no-repeat';
        p.style.backgroundPosition = 'right';
        sender._contextKey = '';
      },
      ACEUserID_Populated: function (sender, e) {
        var p = sender.get_element();
        p.style.backgroundImage = 'none';
      },
      validate_UserID: function (sender) {
        var Prefix = sender.id.replace('UserID', '');
        this.validated_FK_xDMS_Users_UserID_main = true;
        this.validate_FK_xDMS_Users_UserID(sender, Prefix);
      },
      validate_FK_xDMS_Users_UserID: function (o, Prefix) {
        var value = o.id;
        var UserID = $get(Prefix + 'UserID');
        if (UserID.value == '') {
          if (this.validated_FK_xDMS_Users_UserID_main) {
            var o_d = $get(Prefix + 'UserID' + '_Display');
            try { o_d.innerHTML = ''; } catch (ex) { }
          }
          return true;
        }
        value = value + ',' + UserID.value;
        o.style.backgroundImage = 'url(../../images/pkloader.gif)';
        o.style.backgroundRepeat = 'no-repeat';
        o.style.backgroundPosition = 'right';
        PageMethods.validate_FK_xDMS_Users_UserID(value, this.validated_FK_xDMS_Users_UserID);
      },
      validated_FK_xDMS_Users_UserID_main: false,
      validated_FK_xDMS_Users_UserID: function (result) {
        var p = result.split('|');
        var o = $get(p[1]);
        if (script_xDmsUsers.validated_FK_xDMS_Users_UserID_main) {
          var o_d = $get(p[1] + '_Display');
          try { o_d.innerHTML = p[2]; } catch (ex) { }
        }
        o.style.backgroundImage = 'none';
        if (p[0] == '1') {
          o.value = '';
          o.focus();
        }
      },
      temp: function () {
      }
    }

  </script>
  <LGM:LGMessageBox
	 ID="LGMessage1"
	 runat="server" />
  <div class="rst-alert" style="display: none;">
    <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
    <div id="dmsError"></div>
  </div>
  <div id="dmsAlert" style="position: absolute; top: 50%; left: 50%; display: none; padding: 20px; border: 1pt solid black; background-color: lightgray; border-radius: 30px; box-shadow: 10px 10px 10px 10px darkgray; color: black; font-weight: bold; font-size: 14px; transform: translateY(-50%); transform: translateX(-50%);">
  </div>
      <div id='xLoading' class='nt-xloading loading' style='background-color:cadetblue;display:none;'>
      </div>

  <div id="splitSection">
    <div id="dmsTree" class="split content split-horizontal" style="overflow-y: scroll;">
      <div id="ci_0" class="nt-col">
      </div>
    </div>
    <div id="dmsDetails" class="split content split-horizontal">
      <div id="dmsList" class="split content">
        <asp:UpdatePanel ID="UPNLxDmsFiles" runat="server">
          <ContentTemplate>
            <div style="display:none;">
              <asp:TextBox ID="SelectedFileList" runat="server" ClientIDMode="Static" Text=""></asp:TextBox>
              <asp:Button ID="cmdFiles" runat="server" ClientIDMode="Static" />
              <asp:TextBox ID="L_FolderID" CssClass="nt-lbl" Enabled="false" Text="" ClientIDMode="Static" runat="Server" />
              <input type="file" id="F_Checkin" name="F_Checkin" onchange="return checkin_script.filesSelected(event);">
              <asp:TextBox ID="F_CheckinID" runat="server" ClientIDMode="Static" Text="0"></asp:TextBox>
              <asp:TextBox ID="F_CheckinName" runat="server" ClientIDMode="Static" Text="0"></asp:TextBox>
              <asp:TextBox ID="F_CheckinType" runat="server" ClientIDMode="Static" Text="0"></asp:TextBox>
              <input type="file" id="F_Refdocs" name="F_Refdocs[]" multiple="multiple" onchange="return refdocs_script.filesSelected(event);">
              <script>
                var checkin_script = {
                  choose_file: function (z) {
                    $get('F_CheckinID').value = z.dataset.fileid;
                    $get('F_CheckinName').value = z.dataset.filename;
                    $get('F_CheckinType').value = z.dataset.filetype;
                    $get('F_Checkin').click(); return false;
                  },
                  filesSelected: function (evt) {
                    var files = evt.target.files; // FileList object
                    var f = files[0];
                      var n = f.name.replace(/,/g, '-').replace(/'/g, '-');
                      if (n.toLowerCase().split('.').slice(0, -1).join('.') != $get('F_CheckinName').value.toLowerCase().split('.').slice(0, -1).join('.')) {
                        evt.target.files[0] = null;
                        alert('File name should be same.');
                        return;
                      }
                      if (f.type.toLowerCase().split('/')[0] != $get('F_CheckinType').value.toLowerCase().split('/')[0]) {
                        //evt.target.files[0] = null;
                        alert('File type should be same.');
                        //return;
                      }
                        xdms_script.itemLoading();
                        var fd = new FormData();
                        fd.append('file_target', $get('F_CheckinID').value);
                        fd.append('file_number', 1);
                        fd.append('file_id', f.id);
                        fd.append('file_type', f.type);
                        fd.append('file_data', f, f.fileName);
                        var that = this;
                        $.ajax({
                          url: xdms_script.site + 'App_Services/dmsCheckin.ashx',
                          context: that,
                          type: 'POST',
                          data: fd,
                          cache: false,
                          contentType: false,
                          processData: false,
                          error: function (xhr, status, error) {
                            xdms_script.itemLoaded();
                            alert("An error occured: " + xhr.status + " " + xhr.statusText);
                          },
                          success: function (data, status, xhr) {

                            if (data.err) {
                              alert(data.msg)
                            } else {
                              $get('cmdFiles').click();
                              //$get('cmdHFiles').click();
                            }
                            xdms_script.itemLoaded();
                          }
                        });
                  }
                }
              </script>
              <script>
                var refdocs_script = {
                  choose_files: function (z) {
                    $get('F_CheckinID').value = z.dataset.fileid;
                    $get('F_CheckinName').value = z.dataset.filename;
                    $get('F_CheckinType').value = z.dataset.filetype;
                    $get('F_Refdocs').click();
                    return false;
                  },
                  refDocsCount: 0,
                  refDocsList: '',
                  filesSelected: function (evt) {
                    var files = evt.target.files; // FileList object
                    if (files.length > 0) {
                      this.refDocsCount = files.length;
                      this.refDocsList = files;
                      xdms_script.itemLoading();
                      this.startUpload(0);
                    }
                  },
                  startUpload: function (i) {
                    var that = this;
                    if (i < this.refDocsCount) {
                      var f = this.refDocsList[i];
                      if (f == null) {
                        this.startUpload(i + 1);
                        return;
                      }
                      var fd = new FormData();
                      fd.append('file_target', $get('F_CheckinID').value);
                      fd.append('file_number', i);
                      fd.append('file_id', f.id);
                      fd.append('file_type', f.type);
                      fd.append('file_data', f, f.fileName);
                      $.ajax({
                        url: xdms_script.site + 'App_Services/dmsRefdocs.ashx',
                        context: that,
                        type: 'POST',
                        data: fd,
                        cache: false,
                        contentType: false,
                        processData: false,
                        error: function (xhr, status, error) {
                          xdms_script.itemLoaded();
                          alert("An error occured: " + xhr.status + " " + xhr.statusText);
                        },
                        success: function (data, status, xhr) {
                          if (data.err) {
                            xdms_script.itemLoaded();
                            alert(data.msg);
                          } else {
                            this.startUpload(data.i);
                          }
                        }
                      });
                    } else {
                      xdms_script.itemLoaded();
                      this.refDocsList = '';
                      this.refDocsCount = 0;
                      $get('cmdFiles').click();
                    }
                  }
                }
              </script>
            </div>
            <div class="nt-col">
              <style>
                .tbl-container{
                  display:flex;
                  flex-direction:row;
                  justify-content:space-between;
                  background-color:#d5d4d4;
                }
                .tbl-container>div{
                  width:50%;
                }
                .tbl-button-row{
                  display:flex;
                  flex-direction:row;
                  justify-content:flex-end;
                  align-items:center;
                  text-align:right;
                }
                .tbl-button-row>div{
                  margin:2px 4px 2px 4px;
                  width:30px;
                }
              </style>
                <div class="tbl-container">
                  <div>
                    <asp:TextBox ID="L_FolderName" runat="server" CssClass="nt-lbl" Enabled="false" style="background-color:transparent;" Font-Size="14px" Font-Bold="true" Font-Italic="true" Font-Underline="true" ClientIDMode="Static" Text=""></asp:TextBox>
                  </div>
                  <div class="tbl-button-row">
                    <div style="flex-basis:80px;">
                      <asp:LinkButton ID="SelectedList" runat="server" CssClass="nt-but-warning" ToolTip="Selected Files" OnClientClick="return xdms_script.showSelected(); false;" Text="X"><i class="fas fa-cart-arrow-down fa-lg" style="font-size:14px;"></i><asp:Label runat="server" ID="L_SelectedCount" ClientIDMode="Static" Font-Bold="true" Font-Size="10px" ForeColor="Black" Text="0" style="padding-left:2px;"></asp:Label></asp:LinkButton>
                    </div>
                    <div>
                      <asp:LinkButton ID="ShareSelected" runat="server" CssClass="nt-but-success" ToolTip="Share selected files" OnClientClick="return xdms_script.shareSelected(this);"  Text="X"><i class="fas fa-cogs fa-lg" style="font-size:14px;"></i></asp:LinkButton>
                    </div>
                    <div>
                      <asp:LinkButton ID="cmdUnderApproval" runat="server" CssClass="nt-but-cadet" ToolTip="Under Approval" data-key="ua_0"  data-cmd="Under Approval" OnClientClick="return xdms_script.uaClicked(this);" Text="X"><i class="far  fa-check-square fa-lg" style="font-size:14px;"></i></asp:LinkButton>
                    </div>
                    <div>
                      <asp:LinkButton ID="ForwardSelected" runat="server" CssClass="nt-but-coral" ToolTip="Publish Selected" OnClientClick="return confirm('Selected Files will be Published, Do you want to continue ?');" Text="X"><i class="fas fa-file-export fa-lg" style="font-size:14px;"></i> </asp:LinkButton>
                    </div>
                    <div>
                      <asp:LinkButton ID="DeleteSelected" runat="server" CssClass="nt-but-danger" ToolTip="Delete Selected" OnClientClick="return confirm('Selected Files will be deleted, Do you want to continue ?');" Text="X" ><i class="fas fa-trash-alt fa-lg" style="font-size:14px;"></i></asp:LinkButton>
                    </div>
                    <div>
                      <asp:LinkButton ID="DownloadSelected" CssClass="nt-but-primary" runat="server" ToolTip="Download Selected" Text="X"><i class="fas fa-download fa-lg" style="font-size:14px;"></i></asp:LinkButton>
                    </div>
                  </div>
                </div>
              <div>
                <LGM:ToolBarDMS ID = "TBLxDmsFiles" runat="server" />
              </div>
              <div>
                <asp:GridView ID="GVxDmsFiles" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsFiles" DataKeyNames="FileID">
                  <Columns>
                    <asp:TemplateField HeaderText="Ref">
                      <ItemTemplate>
                        <asp:Button ID="cmdRef" runat="server" CssClass="nt-but-grey" ToolTip="Show reference documents."  Text="+" CommandName="ShowRefDoc" CommandArgument='<%# Container.DataItemIndex %>' ></asp:Button>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File ID" SortExpression="[xDMS_Files].[FileID]">
                      <ItemTemplate>
                        <asp:Button ID="LabelFileID" runat="server" CssClass="nt-but-grey" Enabled='<%# Eval("DeleteWFVisible") %>' data-key='<%# "zz_" & Eval("FileID") %>' data-cmd="Keyword" ToolTip="Enter Key Words"  Text='<%# EVal("FileID") %>' OnClientClick="return xdms_script.fileClicked(this);" CommandName="KeyWordWF" CommandArgument='<%# Container.DataItemIndex %>' ></asp:Button>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File Name" SortExpression="[xDMS_Files].[FileName]">
                      <ItemTemplate>
                        <asp:LinkButton ID="LabelFileName" runat="server" Font-Underline="true" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("FileName") %>' OnClientClick='<%# EVal("DownloadLink") %>'></asp:LinkButton>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="REV" SortExpression="[xDMS_Files].[FileRev]">
                      <ItemTemplate>
                        <asp:Button ID="LabelFileRev" runat="server" CssClass="nt-but-grey" CommandName="select" CommandArgument='<%# Container.DataItemIndex %>' ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("FileRev") %>'></asp:Button>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CheckIn/ Checkout" >
                      <ItemTemplate>
                        <asp:Button ID="L_CheckIn" runat="server" ToolTip="Checkin" Visible='<%# Eval("CheckInVisible") %>' CssClass="nt-but-success" Width="18px"  Text="I" data-fileid='<%# Eval("FileID") %>' data-filename='<%# Eval("FileName") %>' data-filetype='<%# Eval("FileExtn") %>' OnClientClick="return checkin_script.choose_file(this);" CommandName="CheckIn" CommandArgument='<%# Container.DataItemIndex %>' ></asp:Button>
                        <asp:Button ID="L_CheckOut" runat="server" ToolTip="Checkout" Visible='<%# Eval("CheckoutVisible") %>' CssClass="nt-but-primary" Width="18px"  Text="O" OnClientClick='<%# EVal("CheckoutLink") %>' CommandName="CheckOut" CommandArgument='<%# Container.DataItemIndex %>' ></asp:Button>
                        <asp:Button ID="L_Undo" runat="server" ToolTip="Undo checkout" Visible='<%# Eval("UndoCheckoutVisible") %>' CssClass="nt-but-danger" Width="18px"  Text="X" CommandName="UndoCheckOut" CommandArgument='<%# Container.DataItemIndex %>' ></asp:Button>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status By" SortExpression="[aspnet_users1].[UserFullName]">
                      <ItemTemplate>
                         <asp:Label ID="L_StatusBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Size" SortExpression="[xDMS_Files].[FileSize]">
                      <ItemTemplate>
                         <asp:Label ID="L_strFileSize" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("strFileSize") %>' Text='<%# Eval("strFileSize") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignright" />
                      <HeaderStyle CssClass="alignright" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status On" SortExpression="[xDMS_Files].[StatusOn]">
                      <ItemTemplate>
                        <asp:Label ID="LabelStatusOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StatusOn") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                    <HeaderStyle CssClass="alignCenter" Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" SortExpression="[xDMS_States5].[StatusName]">
                      <ItemTemplate>
                        <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusID") %>' Text='<%# Eval("xDMS_States5_StatusName") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <HeaderTemplate>
                        <asp:Button ID="ToggalSelection" runat="server" CssClass="nt-but-warning" Text="&nbsp;&nbsp;&nbsp;" ToolTip="Change Selection" CommandName="ToggleSelect" />
                      </HeaderTemplate>
                      <ItemTemplate>
                        <asp:LinkButton ID="cmdSelect" runat="server" ToolTip='<%# Eval("FileID") %>' Text="X" Font-Size="14px"  CommandName="fileSelected" CommandArgument='<%# Container.DataItemIndex %>'><i class="fas fa-toggle-off" style="color:grey;" ></i></asp:LinkButton>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DEL">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdDelete" runat="server" Visible='<%# Eval("DeleteWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick="return confirm('Delete File ?');" CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Publish">
                      <ItemTemplate>
                        <asp:ImageButton ID="cmdInitiateWF" runat="server" Visible='<%# Eval("InitiateWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Publish File" SkinID="forward" OnClientClick="return confirm('Publish File ?');" CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
                        <asp:ImageButton ID="cmdRevertWF" runat="server" Visible='<%# Eval("RevertWFVisible") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Revrt Published File" SkinID="return" OnClientClick="return confirm('Revert Published File ?');" CommandName="RevertWF" CommandArgument='<%# Container.DataItemIndex %>' />
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ref. Doc.">
                      <ItemTemplate>
                        <asp:LinkButton ID="cmdRefDoc" runat="server" Visible='<%# Eval("UploadRefVisible") %>' data-fileid='<%# Eval("FileID") %>' data-filename='<%# Eval("FileName") %>' data-filetype='<%# Eval("FileExtn") %>' OnClientClick="return refdocs_script.choose_files(this);" ToolTip="Upload Reference Documents" CommandName="RefDocs" CommandArgument='<%# Container.DataItemIndex %>' ><i class="fas fa-file-upload" style="font-size:16px; color:grey;" ></i></asp:LinkButton>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemTemplate>
                        </td>
                        </tr>
                        <tr>
                          <td></td>
                          <td colspan="13">
                            <asp:Label runat="server" Font-Size="8px" Font-Italic="true" ForeColor="#999999" Text='<%# Eval("Keywords") %>'></asp:Label>
                          </td>
                        </tr>
                        <tr style="background-color:#f8f4dc;">
                          <td></td>
                          <td colspan="13" >
                            <div id="divRefFiles" runat="server" visible="false" style="width:100%;display:flex;justify-content:flex-start;">
                              <div style="width:80%;padding:3px 10px 10px 0px;">
                                <%--Ref Grid--%>
                                <asp:GridView ID="GVxDmsRefFiles" OnRowCommand="GVxDmsRefFiles_RowCommand" SkinID="gv_lsilver" DataSourceID="ODSxDmsRefFiles" ShowHeader="false" GridLines="Both" runat="server" DataKeyNames="FileID">
                                  <Columns>
                                    <asp:TemplateField HeaderText="File ID" SortExpression="[xDMS_Files].[FileID]">
                                      <ItemTemplate>
                                        <asp:Label ID="LabelFileID" runat="server" ForeColor='<%# Eval("RefForeColor") %>' Text='<%# Eval("FileID") %>'></asp:Label>
                                      </ItemTemplate>
                                      <ItemStyle CssClass="alignCenter" />
                                      <HeaderStyle CssClass="alignCenter" Width="40px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name" SortExpression="[xDMS_Files].[FileName]">
                                      <ItemTemplate>
                                        <asp:LinkButton ID="LabelFileName" runat="server" Font-Underline="true" ForeColor='<%# Eval("RefForeColor") %>' Text='<%# Bind("FileName") %>' OnClientClick='<%# EVal("DownloadLink") %>'></asp:LinkButton>
                                      </ItemTemplate>
                                      <ItemStyle CssClass="alignleft" />
                                      <HeaderStyle CssClass="alignleft" Width="300px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status By" SortExpression="[aspnet_users1].[UserFullName]">
                                      <ItemTemplate>
                                         <asp:Label ID="L_StatusBy" runat="server" ForeColor='<%# Eval("RefForeColor") %>' Title='<%# EVal("StatusBy") %>' Text='<%# Eval("aspnet_users1_UserFullName") %>'></asp:Label>
                                      </ItemTemplate>
                                      <HeaderStyle Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status On" SortExpression="[xDMS_Files].[StatusOn]">
                                      <ItemTemplate>
                                        <asp:Label ID="LabelStatusOn" runat="server" ForeColor='<%# Eval("RefForeColor") %>' Text='<%# Bind("StatusOn") %>'></asp:Label>
                                      </ItemTemplate>
                                      <ItemStyle CssClass="alignCenter" />
                                    <HeaderStyle CssClass="alignCenter" Width="90px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Size" SortExpression="[xDMS_Files].[FileSize]">
                                      <ItemTemplate>
                                         <asp:Label ID="L_strRFileSize" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("strFileSize") %>' Text='<%# Eval("strFileSize") %>'></asp:Label>
                                      </ItemTemplate>
                                      <ItemStyle CssClass="alignright" />
                                      <HeaderStyle CssClass="alignright" Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                      <ItemTemplate>
                                        <asp:ImageButton ID="cmdDelete" runat="server" Visible='<%# Eval("RefDeleteVisible") %>'   AlternateText='<%# Eval("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick="return confirm('Delete File ?');" CommandName="RefDeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
                                      </ItemTemplate>
                                      <ItemStyle CssClass="alignCenter" />
                                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                                    </asp:TemplateField>
                                  </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource
                                  ID="ODSxDmsRefFiles"
                                  runat="server"
                                  DataObjectTypeName="SIS.xDMS.xDmsFiles"
                                  OldValuesParameterFormatString="original_{0}"
                                  SelectMethod="UZ_xDmsRefFilesSelectList"
                                  TypeName="SIS.xDMS.xDmsFiles"
                                  SelectCountMethod="xDmsRefFilesSelectCount"
                                  SortParameterName="OrderBy" 
                                  EnablePaging="True">
                                  <SelectParameters>
                                    <asp:Parameter Name="ParentIFileID" Type="Int32" Direction="Input" Size="10" DefaultValue="0" />
                                  </SelectParameters>
                                </asp:ObjectDataSource>
                              </div>
                            </div>
                          </td>
                        </tr>
                      </ItemTemplate>
                      <HeaderStyle Width="1px" />
                    </asp:TemplateField>
                  </Columns>
                  <EmptyDataTemplate>
                    <asp:Label ID="LabelEmpty" runat="server" Font-Size="12px" ForeColor="Red" Text="No record found !!!"></asp:Label>
                  </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource
                  ID="ODSxDmsFiles"
                  runat="server"
                  DataObjectTypeName="SIS.xDMS.xDmsFiles"
                  OldValuesParameterFormatString="original_{0}"
                  SelectMethod="UZ_xDmsFilesSelectList"
                  TypeName="SIS.xDMS.xDmsFiles"
                  SelectCountMethod="xDmsFilesSelectCount"
                  SortParameterName="OrderBy" EnablePaging="True">
                  <SelectParameters>
                    <asp:ControlParameter ControlID="L_FolderID" PropertyName="Text" Name="FolderID" Type="Int32" Size="10" />
                    <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                    <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                  </SelectParameters>
                </asp:ObjectDataSource>
              </div>
            </div>
          </ContentTemplate>
          <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GVxDmsFiles" EventName="PageIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="GVxDmsFiles" EventName="RowCommand" />
            <asp:AsyncPostBackTrigger ControlID="cmdFiles" EventName="Click" />
          </Triggers>
        </asp:UpdatePanel>
      </div>
      <div id="dmsHistory" class="split content">
        <asp:UpdatePanel ID="UPNLxDmsHFiles" runat="server">
          <ContentTemplate>
            <div class="nt-col">
              <div>
                <LGM:ToolBarDMS ID = "TBLxDmsHFiles" runat="server" />
                 <asp:TextBox ID="L_HFileID" CssClass="nt-lbl" Enabled="false" Text="0" ClientIDMode="Static" style="display:none;" runat="Server" />
                <asp:TextBox ID="RefreshHGrid" runat="server" ClientIDMode="Static" Text="0" style="display:none;"></asp:TextBox>
                  <asp:Button ID="cmdHFiles" runat="server" ClientIDMode="Static" style="display:none;" />
              </div>
              <div>
      <%--History Grid--%>
                <asp:GridView ID="GVxDmsHFiles" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsHFiles" DataKeyNames="FileID,HFileID">
                  <Columns>
                    <asp:TemplateField HeaderText="Ref">
                      <ItemTemplate>
                        <asp:Button ID="cmdHRef" runat="server" CssClass="nt-but-grey" ToolTip="Show reference documents."  Text="+" CommandName="ShowRefDoc" CommandArgument='<%# Container.DataItemIndex %>' ></asp:Button>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="20px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hist ID" SortExpression="[xDMS_HFiles].[HFileID]">
                      <ItemTemplate>
                        <asp:Label ID="LabelFileID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Eval("HFileID") %>' ></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File Name" SortExpression="[xDMS_HFiles].[FileName]">
                      <ItemTemplate>
                        <asp:LinkButton ID="LabelFileName" runat="server" Font-Underline="true" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("FileName") %>' OnClientClick='<%# EVal("DownloadLink") %>'></asp:LinkButton>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignleft" />
                      <HeaderStyle CssClass="alignleft" Width="300px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="REV" SortExpression="[xDMS_HFiles].[FileRev]">
                      <ItemTemplate>
                        <asp:Label ID="LabelFileRev" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("FileRev") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status By" SortExpression="[aspnet_users1].[UserFullName]">
                      <ItemTemplate>
                         <asp:Label ID="L_StatusBy" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("StatusBy") %>' Text='<%# Eval("aspnet_users2_UserFullName") %>'></asp:Label>
                      </ItemTemplate>
                      <HeaderStyle Width="200px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status On" SortExpression="[xDMS_HFiles].[StatusOn]">
                      <ItemTemplate>
                        <asp:Label ID="LabelStatusOn" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("StatusOn") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                    <HeaderStyle CssClass="alignCenter" Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Status" SortExpression="[xDMS_HFiles].[SystemRemarks]">
                      <ItemTemplate>
                        <asp:Label ID="L_StatusID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("SystemRemarks") %>' Text='<%# Eval("SystemRemarks") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignCenter" />
                      <HeaderStyle CssClass="alignCenter" Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Size" SortExpression="[xDMS_HFiles].[FileSize]">
                      <ItemTemplate>
                         <asp:Label ID="L_strHFileSize" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("strFileSize") %>' Text='<%# Eval("strFileSize") %>'></asp:Label>
                      </ItemTemplate>
                      <ItemStyle CssClass="alignright" />
                      <HeaderStyle CssClass="alignright" Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                      <ItemTemplate>
                        </td>
                        </tr>
                        <tr>
                          <td></td>
                          <td colspan="13">
                            <asp:Label runat="server" Font-Size="8px" Font-Italic="true" ForeColor="#999999" Text='<%# Eval("Keywords") %>'></asp:Label>
                          </td>
                        </tr>
                        <tr style="background-color:#f8f4dc;">
                          <td></td>
                          <td colspan="13" >
                            <div id="divRefHFiles" runat="server" visible="false" style="width:100%;display:flex;justify-content:flex-start;">
                              <div style="width:80%;padding:3px 10px 10px 0px;">
                                <%--History Ref Grid--%>
                                <asp:GridView ID="GVxDmsHRefFiles" SkinID="gv_lsilver" DataSourceID="ODSxDmsHRefFiles" ShowHeader="false" GridLines="Both" runat="server" DataKeyNames="FileID,HFileID">
                                  <Columns>
                                    <asp:TemplateField HeaderText="File ID" SortExpression="[xDMS_HFiles].[FileID]">
                                      <ItemTemplate>
                                        <asp:Label ID="LabelHFileID" runat="server" ForeColor='<%# Eval("RefForeColor") %>' Text='<%# Eval("FileID") %>'></asp:Label>
                                      </ItemTemplate>
                                      <ItemStyle CssClass="alignCenter" />
                                      <HeaderStyle CssClass="alignCenter" Width="40px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File Name" SortExpression="[xDMS_HFiles].[FileName]">
                                      <ItemTemplate>
                                        <asp:LinkButton ID="LabelHFileName" runat="server" Font-Underline="true" ForeColor='<%# Eval("RefForeColor") %>' Text='<%# Bind("FileName") %>' OnClientClick='<%# EVal("DownloadLink") %>'></asp:LinkButton>
                                      </ItemTemplate>
                                      <ItemStyle CssClass="alignleft" />
                                      <HeaderStyle CssClass="alignleft" Width="300px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status By" SortExpression="[aspnet_users2].[UserFullName]">
                                      <ItemTemplate>
                                         <asp:Label ID="L_HStatusBy" runat="server" ForeColor='<%# Eval("RefForeColor") %>' Title='<%# EVal("StatusBy") %>' Text='<%# Eval("aspnet_users2_UserFullName") %>'></asp:Label>
                                      </ItemTemplate>
                                      <HeaderStyle Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status On" SortExpression="[xDMS_HFiles].[StatusOn]">
                                      <ItemTemplate>
                                        <asp:Label ID="LabelHStatusOn" runat="server" ForeColor='<%# Eval("RefForeColor") %>' Text='<%# Bind("StatusOn") %>'></asp:Label>
                                      </ItemTemplate>
                                      <ItemStyle CssClass="alignCenter" />
                                    <HeaderStyle CssClass="alignCenter" Width="90px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Size" SortExpression="[xDMS_HFiles].[FileSize]">
                                      <ItemTemplate>
                                         <asp:Label ID="L_strrefHFileSize" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("strFileSize") %>' Text='<%# Eval("strFileSize") %>'></asp:Label>
                                      </ItemTemplate>
                                      <ItemStyle CssClass="alignright" />
                                      <HeaderStyle CssClass="alignright" Width="50px" />
                                    </asp:TemplateField>
                                  </Columns>
                                </asp:GridView>
                                <asp:ObjectDataSource
                                  ID="ODSxDmsHRefFiles"
                                  runat="server"
                                  DataObjectTypeName="SIS.xDMS.xDmsHFiles"
                                  OldValuesParameterFormatString="original_{0}"
                                  SelectMethod="UZ_xDmsRefHFilesSelectList"
                                  TypeName="SIS.xDMS.xDmsHFiles"
                                  SelectCountMethod="xDmsRefHFilesSelectCount"
                                  SortParameterName="OrderBy" 
                                  EnablePaging="True">
                                  <SelectParameters>
                                    <asp:Parameter Name="ParentIFileID" Type="Int32" Direction="Input" Size="10" DefaultValue="0" />
                                    <asp:Parameter Name="HFileID" Type="Int32" Direction="Input" Size="10" DefaultValue="0" />
                                  </SelectParameters>
                                </asp:ObjectDataSource>
                              </div>
                            </div>
                          </td>
                        </tr>
                      </ItemTemplate>
                      <HeaderStyle Width="1px" />
                    </asp:TemplateField>
                  </Columns>
                  <EmptyDataTemplate>
                    <asp:Label ID="LabelEmpty" runat="server" Font-Size="12px" ForeColor="Red" Text="No record found !!!"></asp:Label>
                  </EmptyDataTemplate>
                </asp:GridView>
                <asp:ObjectDataSource
                  ID="ODSxDmsHFiles"
                  runat="server"
                  DataObjectTypeName="SIS.xDMS.xDmsHFiles"
                  OldValuesParameterFormatString="original_{0}"
                  SelectMethod="UZ_xDmsHFilesSelectList"
                  TypeName="SIS.xDMS.xDmsHFiles"
                  SelectCountMethod="xDmsHFilesSelectCount"
                  SortParameterName="OrderBy" EnablePaging="True">
                  <SelectParameters>
                    <asp:ControlParameter ControlID="L_HFileID" PropertyName="Text" Name="FileID" Type="Int32" Size="10" />
                    <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                    <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                  </SelectParameters>
                </asp:ObjectDataSource>
              </div>
            </div>
          </ContentTemplate>
          <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GVxDmsHFiles" EventName="PageIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="L_HFileID" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="cmdHFiles" EventName="Click" />
          </Triggers>
        </asp:UpdatePanel>
      </div>
    </div>
  </div>
  <div class="nt-col nt-con-mnu" id="dmsContextMenu" style="display:none;">
  </div>
  <%--Upload Form--%>
  <div id="frmUpload" class="nt-modal-container nt-col">
    <div class="nt-modal-window dragit" style="width:50%;">
      <div class="nt-col nt-modal-content">
        <div>Upload Files</div>
        <div class="nt-col" style="margin-top:10px;" >
          <div style="display:none;">
            <input type="file" id="f_Uploads" name="f_Uploads[]" multiple="multiple" onchange="return xdms_script.filesSelected(event);">
          </div>
          <div id="UploadFiles" class="nt-col">
            <%--Columns of File list--%>
          </div>
        </div>
        <div class="nt-row nt-modal-command">
          <div>
            <input type="button" class="nt-but-warning"  value="Select Files" style="width:80px;" onclick="xdms_script.choose_file(); false;" />
          </div>
          <div>
            <input type="button" class="nt-but-primary"  value="Upload" style="width:80px;" onclick="xdms_script.startUpload(0); false;" />
          </div>
          <div>
            <input type="button" class="nt-but-danger" value="Cancel" style="width:80px;" onclick="$get('frmUpload').style.display = 'none'; false;" />
          </div>
        </div>
      </div>
    </div>
  </div>
  
  <%--CreateFolder--%>
  <div id="mBox" class="nt-modal-container nt-col">
    <div id="mBody" class="nt-modal-window dragit" style="width:50%;">
      <div class="nt-col nt-modal-content">
        <div id="divUserID" >
          <div class="nt-row"><span class="nt-lbl">User ID:</span>
            <asp:TextBox ID = "F_UserID" CssClass = "mypktxt" Width="72px" Text="" ClientIDMode="Static" AutoCompleteType = "None" onfocus = "return this.select();" onblur= "script_xDmsUsers.validate_UserID(this);" Runat="Server" />  <asp:Label ID = "F_UserID_Display" ClientIDMode="Static" Text="" CssClass="myLbl" Runat="Server" /> <AJX:AutoCompleteExtender ID="ACEUserID" BehaviorID="B_ACEUserID" ClientIDMode="Static" ContextKey="" UseContextKey="true" ServiceMethod="UserIDCompletionList" TargetControlID="F_UserID" EnableCaching="false" CompletionInterval="100" FirstRowSelected="true" MinimumPrefixLength="1" OnClientItemSelected="script_xDmsUsers.ACEUserID_Selected" OnClientPopulating="script_xDmsUsers.ACEUserID_Populating" OnClientPopulated="script_xDmsUsers.ACEUserID_Populated" CompletionSetCount="10" CompletionListCssClass = "autocomplete_completionListElement" CompletionListItemCssClass = "autocomplete_listItem" CompletionListHighlightedItemCssClass = "autocomplete_highlightedListItem" Runat="Server" />
          </div>
        </div>
        <div id="frmInput" class="nt-col" style="margin-top:10px;" >
        </div>
        <div class="nt-row nt-modal-command">
          <div>
            <input type="button" class="nt-but-success"  value="OK" style="width:80px;" onclick="xdms_script.frmUpdate(); false;" />
          </div>
          <div>
            <input type="button" class="nt-but-danger" value="Cancel" style="width:80px;" onclick="$get('mBox').style.display = 'none'; false;" />
          </div>
        </div>
      </div>
    </div>
  </div>

   <div id="dFrame" class="nt-modal-container nt-col">
    <div class="nt-modal-window dragit" style="width:50%;height:50%;">
      <div class="nt-row nt-modal-command">
        <div>
          <input type="button" class="nt-but-danger" value="&times;" style="font-size:16px;" onclick="$get('dFrame').style.display = 'none'; $get('miframe').srcdoc = ''; $get('miframe').src = ''; false;" />
        </div>
      </div>
      <div class="nt-col nt-modal-content" style="height:99%;">
        <div id="dFrameData" style="height:100%;width:100%;border:0;overflow-y:scroll;">
        </div>
      </div>
    </div>
  </div>


   <div id="mFrame" class="nt-modal-container nt-col">
    <div id="mFrameBody" class="nt-modal-window dragit" style="width:70%;height:60%;">
      <div class="nt-row nt-modal-command">
        <div>
          <input type="button" class="nt-but-danger" value="&times;" style="font-size:16px;" onclick="$get('mFrame').style.display = 'none'; $get('miframe').srcdoc = ''; $get('miframe').src = ''; false;" />
        </div>
      </div>
      <div class="nt-col nt-modal-content" style="height:99%;">
        <iframe id="miframe" style="height:100%;width:100%;border:0;" srcdoc="" name="miframe_modal"></iframe>
<%--        <div>
          <LGM:AF_CFoldersAdmin id="afc" runat="server"></LGM:AF_CFoldersAdmin>
        </div>--%>
        <div id="mFrameData" style="overflow-y:scroll">

        </div>
      </div>
    </div>
  </div>
  <script>
    function closeIframe(z) {
      lgMessageBox.close();
      var y = JSON.parse(z);
      xdms_script.takeAction(y);
    }
  </script>

  <script>
    var aInput = [];
    aInput['FolderName'] = '<div class="nt-row"><input type="text" id="F_FolderName" class="nt-txt" placeholder="Folder Name" maxlength="250" required="required" /></div>'
    aInput['FolderID'] = '<div class="nt-row"><input type="text" id="F_FolderID" class="nt-txt" placeholder="Folder ID" maxlength="10" required="required" onblur="return dc(this,0);" /></div>'
    aInput['KeyWords'] = '<div id="divWords" class="nt-row dms-word-container"></div><div class="nt-row"><input id="dmsKeyWordInput" type="text" class="nt-txt" onkeydown="xdms_script.dmsKey(event);" onkeyup="xdms_script.dmsKeyWordHelp(event);" /><input type="text" id="F_KeyWords" style="display:none;"/></div><div class="nt-row dms-popup-container"></div>'
    aInput['NotInherit'] = '<div class="nt-row"><span class="nt-lbl">Required Explicit Authorization:</span><input type="checkbox" id="F_NotInherit" class="nt-lbl" /></div>'
    aInput['CreateFolder'] = '<div class="nt-row"><span class="nt-lbl">Create Folder:</span><input type="checkbox" id="F_CreateFolder" class="nt-lbl" /></div>'
    aInput['UpdateFolder'] = '<div class="nt-row"><span class="nt-lbl">Update Folder:</span><input type="checkbox" id="F_UpdateFolder" class="nt-lbl" /></div>'
    aInput['DeleteFolder'] = '<div class="nt-row"><span class="nt-lbl">Delete Folder:</span><input type="checkbox" id="F_DeleteFolder" class="nt-lbl" /></div>'
    aInput['UploadFile'] = '<div class="nt-row"><span class="nt-lbl">Upload File:</span><input type="checkbox" id="F_UploadFile" class="nt-lbl" /></div>'
    aInput['DownloadFile'] = '<div class="nt-row"><span class="nt-lbl">Download File:</span><input type="checkbox" id="F_DownloadFile" class="nt-lbl" /></div>'
    aInput['DeleteFile'] = '<div class="nt-row"><span class="nt-lbl">Delete File:</span><input type="checkbox" id="F_DeleteFile" class="nt-lbl" /></div>'
    aInput['CanPassAuthorization'] = '<div class="nt-row"><span class="nt-lbl">Can Pass Authorization:</span><input type="checkbox" id="F_CanPassAuthorization" class="nt-lbl" /></div>'
    aInput['CanAuthorizeFolder'] = '<div class="nt-row"><span class="nt-lbl">Can Authorize Folder:</span><input type="checkbox" id="F_CanAuthorizeFolder" class="nt-lbl" /></div>'

    var xdms_script = {
      site: '/WebxDms/',
      frmAction: '',
      CTRLUpload: '',
      fileNumber: 0,
      selected:'',
      url: function () {return this.site + 'App_Services/xDmsService.asmx/';},
      itemLoading:function () { $get('xLoading').style.display = 'block'; },
      itemLoaded: function () {
        if (this.selected != '') { try { $get(this.selected).classList.add('nt-selected'); } catch (x) { } }
        $get('xLoading').style.display = 'none';
      },
      failed: function (z) {
          this.itemLoaded();
          if (z != '') {
            $get('dmsError').innerHTML = z;
            $get("dmsError").parentElement.style.display = 'block';
          }
        },
      showAlert: function (z) {
        if (z != '') {
          $get('dmsAlert').innerHTML = z;
          $get('dmsAlert').style.zIndex = 100;
          $("#dmsAlert").show().delay(1000).fadeOut().delay(3000);
        }
      },
      loadItem: function (z) {
        this.itemLoading();
        var key = 'e_0';
        var lvl = 0;
        if (typeof (z) != 'undefined') {
          if (typeof (z) == 'object')
            key = z.id;
          else
            key = z;
          lvl = $get(key).dataset.lvl;
        }
        var that = this;
        $.ajax({
          type: 'POST',
          url: that.url() + 'LoadItem',
          context: that,
          dataType: 'json',
          cache: false,
          data: "{key:'" + key + "',lvl:'" + lvl + "'}",
          contentType: "application/json; charset=utf-8"
        }).done(function (data, status, xhr) {
          var y = JSON.parse(data.d);
          if (y.err) {
            this.failed(y.msg)
          } else {
            this.render(y);
          }
        }).fail(function (xhr, status, err) {
          this.failed(err);
        });
        return false;
      },
      render: function (z) {
        $get('ci_' + z.key.split('_')[1]).innerHTML = z.html;
        this.itemLoaded();
      },
      toggleView: function (z) {
        var y = $get('e_' + z.id.split('_')[1]);
        var x = $get('ci_' + z.id.split('_')[1]);
        if (y.dataset.ld == 0) {
          this.loadItem(y);
          return false;
        }
        var found = false;
        if (y.dataset.xd == '0') {
          for (var i = 0; i < x.children[0].children.length; i++) {
            if (x.children[0].children[i].id.startsWith('ci_')) {
              x.children[0].children[i].style.display = 'block';
              found = true;
            }
          }
          if (found) {
            y.dataset.xd = '1';
            y.innerText = '-';
          }
        } else {
          for (var i = 0; i < x.children[0].children.length ; i++) {
            if (x.children[0].children[i].id.startsWith('ci_')) {
              x.children[0].children[i].style.display = 'none';
              found = true;
            }
          }
          if (found) {
            y.dataset.xd = '0';
            y.innerText = '+';
          }
        }
      },
      showDetails: function (z) {
        var y = '';
        if (typeof (z) == 'object')
          y = z.id;
        else
          y = z;
        if (this.selected != '') { try { $get(this.selected).classList.remove('nt-selected'); } catch (x) { } }
        this.selected = y; try { $get(this.selected).classList.add('nt-selected'); } catch (x) { }
        $get('L_FolderID').value = y.split('_')[1];
        $get('L_FolderName').value = $get('i_' + y.split('_')[1]).innerText;
        $get('L_HFileID').value = 1;
        $get('cmdFiles').click();
      },
      menuClicked: function (t) {
      this.submitEvent(t.dataset.key, t.dataset.cmd, '', 'MenuClicked');},
      uaClicked: function (t) {
        this.submitEvent(t.dataset.key, t.dataset.cmd, '', 'UnderApproval'); return false;
      },
      fileClicked: function (t) {
        this.submitEvent(t.dataset.key, t.dataset.cmd, '', 'FileClicked');
        return false;
      },
      takeAction: function (y) {
        if (y.wrn) this.showAlert(y.wmsg);
        if (y.ifrm) this.inputForm(y);
        if (y.dfrm) this.displayForm(y);
        if (y.load) this.loadItem(y.key);
        if (y.sload) this.sloadItem(y.skey);
        if (y.ufrm) this.uploadForm(y);
        if (y.fdet) this.showFileDetails(y);
        if (y.down) this.showDownload(y);
      },
      sloadItem: function(skey){
        var z = $get(skey);
        if (typeof (z) != 'undefined') {
          if (typeof (z) == 'object')
            this.loadItem(skey);
        }
      },
      uploadForm: function (z) {
        this.frmAction = z;
        $get('frmUpload').style.display = 'block';
      },
      displayForm: function (z) {
        this.frmAction = z;
        $get('frmInput').innerHTML = z.html;
        $get('mBox').style.display = 'block';
      },
      inputForm: function (z) {
        this.frmAction = z;
        if (z.data != '') {
          lgMessageBox.ExecuteURL(z.cmd, z.data);
          //$get('miframe').srcdoc = z.data;
          //$get('miframe').src = z.data;
          //$get('mFrame').style.display = 'block';
          return;
        }
        var isKW = false;
        this.frmAction = z;
        var aVar = z.html.split(',');
        var s = '';
        $get('divUserID').style.display = 'none';
        for (var i = 0; i < aVar.length; i++) {
          if (aVar[i] == 'KeyWords')
            isKW = true;
          if (aVar[i] == 'UserID')
            $get('divUserID').style.display = 'block';
          else
            s += aInput[aVar[i]];
        }
        $get('frmInput').innerHTML = s;
        if (isKW) {
          $get('F_KeyWords').value = z.data;
          this.setKeyWords();
        }

        $get('mBox').style.display = 'block';
      },
      showDownload: function (z) {
        this.frmAction = z;
        if (z.data != '') {
          window.open(z.data, 'dwin', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');
          return;
        }
      },
      frmUpdate: function () {
        $get('mBox').style.display = 'none';
        if (typeof (this.frmAction) != 'object')
          return;
        var z = this.frmAction;
        var aVar = z.html.split(',');
        z.data = '';
        for (var i = 0; i < aVar.length; i++) {
          if (z.data != '')
            z.data += '|';
          var y = $get('F_' + aVar[i]);
          if (y.type == 'checkbox')
            z.data += y.checked;
          else {
            if (y.id == 'F_KeyWords') {
              y.value = this.getKeyWords($('.dms-word-value'));
            }
            z.data += y.value;
          }
        }
        this.submitEvent(z.key, z.cmd, z.data, 'SelectUpdate');
      },
      submitEvent:function(key,cmd,data,execute){
        var that = this;
        $.ajax({
          type: 'POST',
          url: that.url() + execute,
          context: that,
          dataType: 'json',
          cache: false,
          data: "{key:'" + key + "',cmd:'" + cmd + "',data:'" + data + "'}",
          contentType: "application/json; charset=utf-8"
        }).done(function (data, status, xhr) {
          var y = JSON.parse(data.d);
          if (y.err) {
            this.failed(y.msg)
          } else {
            this.takeAction(y);
          }
        }).fail(function (xhr, status, err) {
          this.failed(err);
        });

      },
      shareSelected:function(){
        this.showAlert('Under Development !!!');
      },
      showSelected:function(){
        var filesList = $get('SelectedFileList').value;
        if(filesList!='')
          this.submitEvent('', '', filesList, 'SelectedFileDetails');
        return false;
      },
      getFileSize: function (x) {
        var y = parseInt(x);
        if (y > 1073741824) return (y / 1073741824).toFixed(2) + ' GB';
        if (y > 1048576) return (y / 1048576).toFixed(2) + ' MB';
        if (y > 1024) return (y / 1024).toFixed(2) + ' KB';
        return y + ' Bytes';
      },
      showFileDetails: function (z) {
        var zf = JSON.parse(z.data);
        var output = [];
        output.push(
           '<div class="nt-row nt-filelist">',
           '  <div class="nt-filename"><b>File Name</b></div>',
           '  <div ><b>File Size</b></div>',
           '  <div ><b>Remove</b></div>',
           '</div>'
        );
        for (var i = 0, f; f = zf[i]; i++) {
          var n = f.FileName.replace(/,/g, '-').replace(/'/g, '-');
          output.push(
             '<div class="nt-row nt-filelist">',
             '  <div class="nt-filename">', n, '</div>',
             '  <div class="nt-filename">', xdms_script.getFileSize(f.FileSize), '</div>',
             '  <div id="zf_' + f.FileID + '" class="nt-filedel" onclick="xdms_script.removeSelected(this);">x</div>',
             '</div>'
          );
        }
        $get('dFrameData').innerHTML = output.join('');
        $get('dFrame').style.display = 'block';
      },
      removeSelected: function(y){
        var z = y.id.split('_')[1];
        var fl = $get('SelectedFileList').value.split(',');
        var rl = fl.indexOf(z);
        fl.splice(rl, 1);
        $get('SelectedFileList').value = fl.join(',');
        y.parentElement.style.display = 'none';
        $get('cmdFiles').click();
      },
      choose_file: function () {$get('f_Uploads').click(); return false;},
      filesSelected: function (evt) {
        this.CTRLUpload = evt.target;
        var files = evt.target.files; // FileList object
        var output = [];
        for (var i = 0, f; f = files[i]; i++) {
          var n = f.name.replace(/,/g, '-').replace(/'/g, '-');
          output.push(
             '<div class="nt-row nt-filelist">',
             '  <div class="nt-filename">', n, '</div>',
             '  <div class="nt-filename">', xdms_script.getFileSize(f.size), '</div>',
             '  <div class="nt-xpbar"><div id="pbar_' + i.toString() + '" class="nt-pbar"></div></div>',
             '  <div id="pbarval_' + i.toString() + '" class="nt-pbarval">0</div>',
             '  <div id="file_' + i.toString() + '" class="nt-filedel" onclick="xdms_script.remove_file(this);">x</div>',
              '</div>'
          );
        }
        $get('UploadFiles').innerHTML = output.join('');
      },
      remove_file: function (z) {
        z.parentElement.style.display = 'none';
        this.CTRLUpload.files[z.id.split('_')[1]] = null;
      },
      startUpload: function (i) {
        var key = this.frmAction.key;
        var that = this;
        if (i < this.CTRLUpload.files.length) {
          var f = this.CTRLUpload.files[i];
          if (f == null) {
            this.startUpload(i + 1);
            return;
          }
          $get('file_' + i).innerHTML = '';
          $get('pbar_' + i).style.width = '0%';
          this.fileNumber = i;
          var fd = new FormData();
          fd.append('file_target', key);
          fd.append('file_number', i);
          fd.append('file_id', f.id);
          fd.append('file_type', f.type);
          fd.append('file_data', this.CTRLUpload.files[i], f.fileName);
          $.ajax({
            url: that.site + 'App_Services/dmsUploader.ashx',
            context: that,
            type: 'POST',
            data: fd,
            cache: false,
            contentType: false,
            processData: false,
            error: function (xhr, status, error) {
              this.failed("An error occured: " + xhr.status + " " + xhr.statusText);
            },
            success: function (data, status, xhr) {
              if (data.err) {
                this.failed(data.msg)
              } else {
                this.startUpload(data.i);
              }
            },
            xhr: function () {
              var fileXhr = $.ajaxSettings.xhr();
              if (fileXhr.upload) {
                fileXhr.upload.addEventListener("progress", xdms_script.uploadProgress, false);
              }
              return fileXhr;
            }
          });
        } else {
          $get('UploadFiles').innerHTML = '';
          this.CTRLUpload.value = '';
          $get('frmUpload').style.display = 'none';
          this.showDetails(this.frmAction.key);
          this.loadItem(this.frmAction.key);
        }
      },
      uploadProgress: function (e) {
        if (e.lengthComputable) {
          var s = 0;
          try { s = parseInt((e.loaded / e.total) * 100); } catch (e) { }
          $get('pbarval_' + xdms_script.fileNumber).innerHTML = s + ' %';
          $get('pbar_' + xdms_script.fileNumber).style.width = s + '%';
        }
      },
      //===============Key Word Related===================
      DmsWord: function (x) {
        var output = [];
        output.push(
          '<div class="dms-word">',
            '<div class="dms-word-value">',
               x,
            '</div>',
            '<div class="dms-word-remove" onclick="$(this).parent().fadeOut(300) && xdms_script.removeKey(this);">&times;</div>',
          '</div>'
          );
        return output.join('');
      },
      removeKey: function (x) {
        x.parentNode.parentNode.removeChild(x.parentNode);
      },
      setKeyWords: function () {
        var fv = $get('F_KeyWords').value.split(',');
        if (fv.length > 0) {
          var dv = $get('divWords');
          dv.innerHTML = '';
          for (var i = 0; i < fv.length; i++) {
            dv.innerHTML += this.DmsWord(fv[i]);
          }
        }
      },
      getKeyWords: function (x) {
        var y = '';
        for (i = 0; i < x.length; i++) {
          if (y == '')
            y = x[i].innerText;
          else
            y = y + ',' + x[i].innerText;
        }
        return y;
      },
      dmsKey: function (e) {
        var y = e.char || e.key;
        if (y == ',') {
          var t = e.target;
          var z = this.DmsWord(t.value.replace(',', ''));
          $get('divWords').innerHTML += z;
          t.value = '';
          e.preventDefault();
          return false;
        }
      },
      dmsHelpNode: function (x) {
        var output = [];
        output.push(
          '<div class="dms-popup-value" onclick="xdms_script.dmsHelpNodeSelected(this);">',
               x,
          '</div>'
          );
        return output.join('');
      },
      dmsHelpNodeSelected: function (x) {
        var ib = $get('dmsKeyWordInput');
        var p = x.innerHTML.split(',');
        for (i = 0; i < p.length; i++) {
          var z = this.DmsWord(p[i]);
          $get('divWords').innerHTML += z;
        }
        ib.value = '';
        ib.focus();
      },
      dmsKeyWordHelp: function (event) {
        var e = event;
        var tgt = e.target;
        var str = tgt.value;
        var pc = $('.dms-popup-container')[0];
        if (event.char == ',') {
          return;
        }
        if (event.keyCode == 27) {
          pc.style.display = 'none';
        }
        pc.style.top = parseFloat(tgt.style.top) + parseFloat(tgt.style.height) + 25 + 'px';
        pc.style.left = parseFloat(tgt.style.left) + 'px';
        pc.style.width = (parseFloat(tgt.style.width) || tgt.clientWidth) + 'px';
        pc.style.display = 'flex';
        $(document).bind("click", function (event) {
          $('.dms-popup-container')[0].style.display = 'none';
        });
        window.event.returnValue = false;
        pc.innerHTML = '';
        var that = xdms_script;
        $.ajax({
          type: 'POST',
          url: that.url() + 'getTags',
          context: that,
          dataType: 'json',
          cache: false,
          data: "{context:'" + str + "',cnt:'" + 10 + "'}",
          contentType: "application/json; charset=utf-8"
        }).done(function (data, status, xhr) {
          var y = JSON.parse(data.d);
          if (y.err) {
            this.failed(y.msg)
          } else {
            var pc = $('.dms-popup-container')[0];
            for (var i = 0, f; f = y.strHTML[i]; i++) {
              pc.innerHTML += xdms_script.dmsHelpNode(f);
            }
          }
        }).fail(function (xhr, status, err) {
          this.failed(err);
        });
      },
    }

    var xmnu_script = {
      showMenu: function (z, e) {
        if (xdms_script.selected != '') { try { $get(xdms_script.selected).classList.remove('nt-selected'); } catch (x) { } }
        xdms_script.selected = z.id; try { $get(xdms_script.selected).classList.add('nt-selected') } catch (x) { }
        var menu = $get("dmsContextMenu");
        menu.innerHTML = this.getMenuStr(z);
        menu.style.top = parseFloat(this.mouseY(event)) - 25 + 'px';
        menu.style.left = this.mouseX(event) + 'px';
        menu.style.display = 'block';
        $(document).bind("click", function (event) {
          $get("dmsContextMenu").style.display = 'none';
        });
        window.event.returnValue = false;
      },
      getMenuStr: function (z) {
        var str = '';
        for (var i = 0; i < mnuOpt.length; i++) {
          var x = mnuOpt[i].split('|');
          var y = x[0];
          var disabled = false;
          if (x[0].substring(0, 1) == '#') {
            y = x[0].replace('#', '');
            disabled = true;
          }
          if (!disabled)
            str = str + "<div class='nt-mnu' data-key='" + z.id + "' data-cmd='" + y + "' onclick='return xdms_script.menuClicked(this);'>";
          else
            str = str + "<div class='nt-mnu-disabled' data-key='" + z.id + "' data-cmd='" + y + "'>";

          str = str +  y;
          str = str + "</div>"
        }
        return str;
      },
      enableMenu: function () {
        window.addEventListener("contextmenu", function (e) {
          e.preventDefault()
        });
      },
      mouseX: function (evt) {
        if (evt.pageX) {
          return evt.pageX;
        } else if (evt.clientX) {
          return evt.clientX + (document.documentElement.scrollLeft ?
              document.documentElement.scrollLeft :
              document.body.scrollLeft);
        } else {
          return null;
        }
      },
      mouseY: function (evt) {
        if (evt.pageY) {
          return evt.pageY;
        } else if (evt.clientY) {
          return evt.clientY + (document.documentElement.scrollTop ?
          document.documentElement.scrollTop :
          document.body.scrollTop);
        } else {
          return null;
        }
      }

    }
    var mnuOpt = [];
    mnuOpt[0] = 'Create';
    mnuOpt[1] = 'Edit';
    mnuOpt[2] = 'Delete';
    mnuOpt[3] = 'Authorize to User';
    mnuOpt[4] = 'Authorize to User Group';
    mnuOpt[5] = 'Upload Files';
    mnuOpt[6] = 'Download Files';
    mnuOpt[7] = '#----------------------------';
    mnuOpt[8] = 'Export BOM';

  </script>
  <script>
    try{
      //Startup Scripts
      //Enable Context Menu
      xmnu_script.enableMenu();
      //Make it Resizable
      $("#splitSection").resizable();
      //Load Root Item
      xdms_script.loadItem();
      //$get('dmsKeyWordInput').addEventListener('keyup', dmsScript.dmsKeyWordHelp);

    }catch(e){}
  </script>
  <style>
    /*Splitter*/
    .split {
      -webkit-box-sizing: border-box;
      -moz-box-sizing: border-box;
      box-sizing: border-box;
      overflow-y: auto;
      overflow-x: auto;
    }

    .content {
      border: 1px solid #C0C0C0;
      box-shadow: inset 0 1px 2px #e4e4e4;
    }

    .gutter {
      background-color: lavender;
      background-repeat: no-repeat;
      background-position: 50%;
    }

      .gutter.gutter-horizontal {
        cursor: col-resize;
        background-image: url('App_Scripts/splitMaster/grips/vertical.png');
      }

      .gutter.gutter-vertical {
        cursor: row-resize;
        background-image: url('App_Scripts/splitMaster/grips/horizontal.png');
      }

      .split.split-horizontal, .gutter.gutter-horizontal {
        height: 100%;
        float: left;
      }
  </style>
  <script>
    $(window).trigger('resize');
  </script>

  <script src="../../splitMaster/src/split.min.js"></script>
  <script>
  try{
    Split(['#dmsList', '#dmsHistory'], {
      sizes: [75, 25],
      gutterSize: 10,
      direction: 'vertical',
    });
    Split(['#dmsTree', '#dmsDetails'], {
      sizes: [25, 75],
      gutterSize: 10,
      cursor: 'row-resize',
    });
    //Split(['#p', '#q'], {
    //  sizes: [60, 40],
    //  gutterSize: 10,
    //  cursor: 'row-resize',
    //});

  }catch (e){}
</script>

</asp:Content>

