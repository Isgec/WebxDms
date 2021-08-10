<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="EF_xDmsGroups.aspx.vb" Inherits="EF_xDmsGroups" title="Edit: DMS Groups" %>
<asp:Content ID="CPHxDmsGroups" ContentPlaceHolderID="cph1" runat="Server">
  <div id="div1" class="ui-widget-content page">
    <div id="div2" class="caption">
      <asp:Label ID="LabelxDmsGroups" runat="server" Text="&nbsp;Edit: DMS Groups"></asp:Label>
    </div>
    <div id="div3" class="pagedata">
      <asp:UpdatePanel ID="UPNLxDmsGroups" runat="server">
        <ContentTemplate>
          <LGM:ToolBar0
            ID="TBLxDmsGroups"
            ToolType="lgNMEdit"
            UpdateAndStay="False"
            ValidationGroup="xDmsGroups"
            runat="server" />
          <asp:FormView ID="FVxDmsGroups"
            runat="server"
            DataKeyNames="GroupID"
            DataSourceID="ODSxDmsGroups"
            DefaultMode="Edit" CssClass="sis_formview">
            <EditItemTemplate>
              <div id="frmdiv" class="ui-widget-content minipage">
                <table style="margin: auto; border: solid 1pt lightgrey">
                  <tr>
                    <td class="alignright">
                      <b>
                        <asp:Label ID="L_GroupID" runat="server" ForeColor="#CC6633" Text="GroupID :" /><span style="color: red">*</span></b>
                    </td>
                    <td colspan="3">
                      <asp:TextBox ID="F_GroupID"
                        Text='<%# Bind("GroupID") %>'
                        ToolTip="Value of GroupID."
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
                      <asp:Label ID="L_Description" runat="server" Text="Description :" /><span style="color: red">*</span>
                    </td>
                    <td colspan="3">
                      <asp:TextBox ID="F_Description"
                        Text='<%# Bind("Description") %>'
                        Width="408px"
                        CssClass="mytxt"
                        onfocus="return this.select();"
                        ValidationGroup="xDmsGroups"
                        onblur="this.value=this.value.replace(/\'/g,'');"
                        ToolTip="Enter value for Description."
                        MaxLength="50"
                        runat="server" />
                      <asp:RequiredFieldValidator
                        ID="RFVDescription"
                        runat="server"
                        ControlToValidate="F_Description"
                        ErrorMessage="<div class='errorLG'>Required!</div>"
                        Display="Dynamic"
                        EnableClientScript="true"
                        ValidationGroup="xDmsGroups"
                        SetFocusOnError="true" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_Active" runat="server" Text="Active :" />&nbsp;
                    </td>
                    <td colspan="3">
                      <asp:CheckBox ID="F_Active"
                        Checked='<%# Bind("Active") %>'
                        CssClass="mychk"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_CreateFolder" runat="server" Text="Create Folder :" />&nbsp;
                    </td>
                    <td colspan="3">
                      <asp:CheckBox ID="F_CreateFolder"
                        Checked='<%# Bind("CreateFolder") %>'
                        CssClass="mychk"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_UpdateFolder" runat="server" Text="Update Folder :" />&nbsp;
                    </td>
                    <td colspan="3">
                      <asp:CheckBox ID="F_UpdateFolder"
                        Checked='<%# Bind("UpdateFolder") %>'
                        CssClass="mychk"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_DeleteFolder" runat="server" Text="Delete Folder :" />&nbsp;
                    </td>
                    <td colspan="3">
                      <asp:CheckBox ID="F_DeleteFolder"
                        Checked='<%# Bind("DeleteFolder") %>'
                        CssClass="mychk"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_UploadFile" runat="server" Text="Upload File :" />&nbsp;
                    </td>
                    <td colspan="3">
                      <asp:CheckBox ID="F_UploadFile"
                        Checked='<%# Bind("UploadFile") %>'
                        CssClass="mychk"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_DownloadFile" runat="server" Text="Download File :" />&nbsp;
                    </td>
                    <td colspan="3">
                      <asp:CheckBox ID="F_DownloadFile"
                        Checked='<%# Bind("DownloadFile") %>'
                        CssClass="mychk"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_DeleteFile" runat="server" Text="Delete File :" />&nbsp;
                    </td>
                    <td colspan="3">
                      <asp:CheckBox ID="F_DeleteFile"
                        Checked='<%# Bind("DeleteFile") %>'
                        CssClass="mychk"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_CanAuthorizeFolder" runat="server" Text="Can Authorize Folder :" />&nbsp;
                    </td>
                    <td colspan="3">
                      <asp:CheckBox ID="F_CanAuthorizeFolder"
                        Checked='<%# Bind("CanAuthorizeFolder") %>'
                        CssClass="mychk"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_CanPassAuthorization" runat="server" Text="Can Pass Authorization :" />&nbsp;
                    </td>
                    <td colspan="3">
                      <asp:CheckBox ID="F_CanPassAuthorization"
                        Checked='<%# Bind("CanPassAuthorization") %>'
                        CssClass="mychk"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_CanViewAllRevisions" runat="server" Text="Can View All Revisions :" />&nbsp;
                    </td>
                    <td colspan="3">
                      <asp:CheckBox ID="F_CanViewAllRevisions"
                       Checked='<%# Bind("CanViewAllRevisions") %>'
                       CssClass = "mychk"
                       runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_CreatedBy" runat="server" Text="Created By :" />&nbsp;
                    </td>
                    <td colspan="3">
                      <asp:TextBox
                        ID="F_CreatedBy"
                        Width="72px"
                        Text='<%# Bind("CreatedBy") %>'
                        Enabled="False"
                        ToolTip="Value of Created By."
                        CssClass="dmyfktxt"
                        runat="Server" />
                      <asp:Label
                        ID="F_CreatedBy_Display"
                        Text='<%# Eval("aspnet_users1_UserFullName") %>'
                        CssClass="myLbl"
                        runat="Server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                  <tr>
                    <td class="alignright">
                      <asp:Label ID="L_CreatedOn" runat="server" Text="Created On :" />&nbsp;
                    </td>
                    <td colspan="3">
                      <asp:TextBox ID="F_CreatedOn"
                        Text='<%# Bind("CreatedOn") %>'
                        ToolTip="Value of Created On."
                        Enabled="False"
                        Width="168px"
                        CssClass="dmytxt"
                        runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td colspan="4" style="border-top: solid 1pt LightGrey"></td>
                  </tr>
                </table>
              </div>
              <fieldset class="ui-widget-content page">
                <legend>
                  <asp:Label ID="LabelxDmsGroupUsers" runat="server" Text="&nbsp;List: Group Users"></asp:Label>
                </legend>
                <div class="pagedata">
                  <asp:UpdatePanel ID="UPNLxDmsGroupUsers" runat="server">
                    <ContentTemplate>
                      <table width="100%">
                        <tr>
                          <td class="sis_formview">
                            <LGM:ToolBar0
                              ID="TBLxDmsGroupUsers"
                              ToolType="lgNMGrid"
                              EditUrl="~/xDMS_Main/App_Edit/EF_xDmsGroupUsers.aspx"
                              AddUrl="~/xDMS_Main/App_Create/AF_xDmsGroupUsers.aspx"
                              AddPostBack="True"
                              EnableExit="false"
                              ValidationGroup="xDmsGroupUsers"
                              runat="server" />
                            <asp:UpdateProgress ID="UPGSxDmsGroupUsers" runat="server" AssociatedUpdatePanelID="UPNLxDmsGroupUsers" DisplayAfter="100">
                              <ProgressTemplate>
                                <span style="color: #ff0033">Loading...</span>
                              </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:GridView ID="GVxDmsGroupUsers" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsGroupUsers" DataKeyNames="GroupID,UserID">
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
                                <asp:TemplateField HeaderText="Apply User">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdApply" ValidationGroup='<%# "Apply" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("ApplyWFVisible") %>' Enabled='<%# EVal("ApplyWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Apply" SkinID="Forward" OnClientClick='<%# "return Page_ClientValidate(""Apply" & Container.DataItemIndex & """) && confirm(""Apply Group Authorization definition on User ?"");" %>' CommandName="ApplyWF" CommandArgument='<%# Container.DataItemIndex %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apply Folder">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Apply Folder" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Apply All Folder Authorization definition on User-All Folder ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
                              ID="ODSxDmsGroupUsers"
                              runat="server"
                              DataObjectTypeName="SIS.xDMS.xDmsGroupUsers"
                              OldValuesParameterFormatString="original_{0}"
                              SelectMethod="xDmsGroupUsersSelectList"
                              TypeName="SIS.xDMS.xDmsGroupUsers"
                              SelectCountMethod="xDmsGroupUsersSelectCount"
                              SortParameterName="OrderBy" EnablePaging="True">
                              <SelectParameters>
                                <asp:ControlParameter ControlID="F_GroupID" PropertyName="Text" Name="GroupID" Type="Int32" Size="10" />
                                <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                                <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                              </SelectParameters>
                            </asp:ObjectDataSource>
                            <br />
                          </td>
                        </tr>
                      </table>
                    </ContentTemplate>
                    <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="GVxDmsGroupUsers" EventName="PageIndexChanged" />
                    </Triggers>
                  </asp:UpdatePanel>
                </div>
              </fieldset>
              <fieldset class="ui-widget-content page">
                <legend>
                  <asp:Label ID="LabelxDmsGroupFolders" runat="server" Text="&nbsp;List: Group Folders"></asp:Label>
                </legend>
                <div class="pagedata">
                  <asp:UpdatePanel ID="UPNLxDmsGroupFolders" runat="server">
                    <ContentTemplate>
                      <table width="100%">
                        <tr>
                          <td class="sis_formview">
                            <LGM:ToolBar0
                              ID="TBLxDmsGroupFolders"
                              ToolType="lgNMGrid"
                              EditUrl="~/xDMS_Main/App_Edit/EF_xDmsGroupFolders.aspx"
                              AddUrl="~/xDMS_Main/App_Create/AF_xDmsGroupFolders.aspx"
                              AddPostBack="True"
                              EnableExit="false"
                              ValidationGroup="xDmsGroupFolders"
                              runat="server" />
                            <asp:UpdateProgress ID="UPGSxDmsGroupFolders" runat="server" AssociatedUpdatePanelID="UPNLxDmsGroupFolders" DisplayAfter="100">
                              <ProgressTemplate>
                                <span style="color: #ff0033">Loading...</span>
                              </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:GridView ID="GVxDmsGroupFolders" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsGroupFolders" DataKeyNames="GroupID,FolderID">
                              <Columns>
                                <asp:TemplateField HeaderText="EDIT">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# Eval("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GroupID" SortExpression="[xDMS_Groups2].[Description]">
                                  <ItemTemplate>
                                    <asp:Label ID="L_GroupID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("GroupID") %>' Text='<%# Eval("xDMS_Groups2_Description") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FolderID" SortExpression="[xDMS_Folders1].[FolderName]">
                                  <ItemTemplate>
                                    <asp:Label ID="L_FolderID" runat="server" ForeColor='<%# Eval("ForeColor") %>' Title='<%# EVal("FolderID") %>' Text='<%# Eval("xDMS_Folders1_FolderName") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Create Folder" SortExpression="[xDMS_GroupFolders].[CreateFolder]">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelCreateFolder" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("CreateFolder") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Update Folder" SortExpression="[xDMS_GroupFolders].[UpdateFolder]">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelUpdateFolder" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("UpdateFolder") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete Folder" SortExpression="[xDMS_GroupFolders].[DeleteFolder]">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelDeleteFolder" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("DeleteFolder") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Upload File" SortExpression="[xDMS_GroupFolders].[UploadFile]">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelUploadFile" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("UploadFile") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Download File" SortExpression="[xDMS_GroupFolders].[DownloadFile]">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelDownloadFile" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("DownloadFile") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete File" SortExpression="[xDMS_GroupFolders].[DeleteFile]">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelDeleteFile" runat="server" ForeColor='<%# Eval("ForeColor") %>' Text='<%# Bind("DeleteFile") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apply Folder">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdInitiateWF" ValidationGroup='<%# "Initiate" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("InitiateWFVisible") %>' Enabled='<%# EVal("InitiateWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Apply Folder Authorization" SkinID="forward" OnClientClick='<%# "return Page_ClientValidate(""Initiate" & Container.DataItemIndex & """) && confirm(""Apply Folder Authorization Definition on All User-Folder ?"");" %>' CommandName="InitiateWF" CommandArgument='<%# Container.DataItemIndex %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdDelete" ValidationGroup='<%# "Delete" & Container.DataItemIndex %>' CausesValidation="true" runat="server" Visible='<%# EVal("DeleteWFVisible") %>' Enabled='<%# EVal("DeleteWFEnable") %>' AlternateText='<%# EVal("PrimaryKey") %>' ToolTip="Delete" SkinID="Delete" OnClientClick='<%# "return Page_ClientValidate(""Delete" & Container.DataItemIndex & """) && confirm(""Delete record ?"");" %>' CommandName="DeleteWF" CommandArgument='<%# Container.DataItemIndex %>' />
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
                              ID="ODSxDmsGroupFolders"
                              runat="server"
                              DataObjectTypeName="SIS.xDMS.xDmsGroupFolders"
                              OldValuesParameterFormatString="original_{0}"
                              SelectMethod="xDmsGroupFoldersSelectList"
                              TypeName="SIS.xDMS.xDmsGroupFolders"
                              SelectCountMethod="xDmsGroupFoldersSelectCount"
                              SortParameterName="OrderBy" EnablePaging="True">
                              <SelectParameters>
                                <asp:ControlParameter ControlID="F_GroupID" PropertyName="Text" Name="GroupID" Type="Int32" Size="10" />
                                <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                                <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                              </SelectParameters>
                            </asp:ObjectDataSource>
                            <br />
                          </td>
                        </tr>
                      </table>
                    </ContentTemplate>
                    <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="GVxDmsGroupFolders" EventName="PageIndexChanged" />
                    </Triggers>
                  </asp:UpdatePanel>
                </div>
              </fieldset>
              <fieldset class="ui-widget-content page">
                <legend>
                  <asp:Label ID="LabelxDmsFldAuthByGrp" runat="server" Text="&nbsp;List: DMS Folder Authorizations By Group"></asp:Label>
                </legend>
                <div class="pagedata">
                  <asp:UpdatePanel ID="UPNLxDmsFldAuthByGrp" runat="server">
                    <ContentTemplate>
                      <table width="100%">
                        <tr>
                          <td class="sis_formview">
                            <LGM:ToolBar0
                              ID="TBLxDmsFldAuthByGrp"
                              ToolType="lgNMGrid"
                              EditUrl="~/xDMS_Main/App_Edit/EF_xDmsFldAuthByGrp.aspx"
                              EnableAdd="False"
                              EnableExit="false"
                              ValidationGroup="xDmsFldAuthByGrp"
                              runat="server" />
                            <asp:UpdateProgress ID="UPGSxDmsFldAuthByGrp" runat="server" AssociatedUpdatePanelID="UPNLxDmsFldAuthByGrp" DisplayAfter="100">
                              <ProgressTemplate>
                                <span style="color: #ff0033">Loading...</span>
                              </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:GridView ID="GVxDmsFldAuthByGrp" SkinID="gv_silver" runat="server" DataSourceID="ODSxDmsFldAuthByGrp" DataKeyNames="GroupID,UserID,FolderID">
                              <Columns>
                                <asp:TemplateField HeaderText="EDIT">
                                  <ItemTemplate>
                                    <asp:ImageButton ID="cmdEditPage" ValidationGroup="Edit" runat="server" Visible='<%# EVal("Visible") %>' Enabled='<%# EVal("Enable") %>' AlternateText="Edit" ToolTip="Edit the record." SkinID="Edit" CommandName="lgEdit" CommandArgument='<%# Container.DataItemIndex %>' />
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User ID" SortExpression="[aspnet_users2].[UserFullName]">
                                  <ItemTemplate>
                                    <asp:Label ID="L_UserID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("UserID") %>' Text='<%# Eval("aspnet_users2_UserFullName") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Folder ID" SortExpression="[xDMS_Folders3].[FolderName]">
                                  <ItemTemplate>
                                    <asp:Label ID="L_FolderID" runat="server" ForeColor='<%# EVal("ForeColor") %>' Title='<%# EVal("FolderID") %>' Text='<%# Eval("xDMS_Folders3_FolderName") %>'></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Create Folder" SortExpression="[xDMS_FolderAuthorizations].[CreateFolder]">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelCreateFolder" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("CreateFolder") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Update Folder" SortExpression="[xDMS_FolderAuthorizations].[UpdateFolder]">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelUpdateFolder" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UpdateFolder") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete Folder" SortExpression="[xDMS_FolderAuthorizations].[DeleteFolder]">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelDeleteFolder" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DeleteFolder") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Upload File" SortExpression="[xDMS_FolderAuthorizations].[UploadFile]">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelUploadFile" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("UploadFile") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Download File" SortExpression="[xDMS_FolderAuthorizations].[DownloadFile]">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelDownloadFile" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DownloadFile") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete File" SortExpression="[xDMS_FolderAuthorizations].[DeleteFile]">
                                  <ItemTemplate>
                                    <asp:Label ID="LabelDeleteFile" runat="server" ForeColor='<%# EVal("ForeColor") %>' Text='<%# Bind("DeleteFile") %>'></asp:Label>
                                  </ItemTemplate>
                                  <ItemStyle CssClass="alignCenter" />
                                  <HeaderStyle CssClass="alignCenter" Width="50px" />
                                </asp:TemplateField>
                              </Columns>
                              <EmptyDataTemplate>
                                <asp:Label ID="LabelEmpty" runat="server" Font-Size="Small" ForeColor="Red" Text="No record found !!!"></asp:Label>
                              </EmptyDataTemplate>
                            </asp:GridView>
                            <asp:ObjectDataSource
                              ID="ODSxDmsFldAuthByGrp"
                              runat="server"
                              DataObjectTypeName="SIS.xDMS.xDmsFldAuthByGrp"
                              OldValuesParameterFormatString="original_{0}"
                              SelectMethod="UZ_xDmsFldAuthByGrpSelectList"
                              TypeName="SIS.xDMS.xDmsFldAuthByGrp"
                              SelectCountMethod="xDmsFldAuthByGrpSelectCount"
                              SortParameterName="OrderBy" EnablePaging="True">
                              <SelectParameters>
                                <asp:ControlParameter ControlID="F_GroupID" PropertyName="Text" Name="GroupID" Type="Int32" Size="10" />
                                <asp:Parameter Name="SearchState" Type="Boolean" Direction="Input" DefaultValue="false" />
                                <asp:Parameter Name="SearchText" Type="String" Direction="Input" DefaultValue="" />
                              </SelectParameters>
                            </asp:ObjectDataSource>
                            <br />
                          </td>
                        </tr>
                      </table>
                    </ContentTemplate>
                    <Triggers>
                      <asp:AsyncPostBackTrigger ControlID="GVxDmsFldAuthByGrp" EventName="PageIndexChanged" />
                    </Triggers>
                  </asp:UpdatePanel>
                </div>
              </fieldset>
            </EditItemTemplate>
          </asp:FormView>
        </ContentTemplate>
      </asp:UpdatePanel>
      <asp:ObjectDataSource
        ID="ODSxDmsGroups"
        DataObjectTypeName="SIS.xDMS.xDmsGroups"
        SelectMethod="xDmsGroupsGetByID"
        UpdateMethod="xDmsGroupsUpdate"
        DeleteMethod="xDmsGroupsDelete"
        OldValuesParameterFormatString="original_{0}"
        TypeName="SIS.xDMS.xDmsGroups"
        runat="server">
        <SelectParameters>
          <asp:QueryStringParameter DefaultValue="0" QueryStringField="GroupID" Name="GroupID" Type="Int32" />
        </SelectParameters>
      </asp:ObjectDataSource>
    </div>
  </div>
</asp:Content>
