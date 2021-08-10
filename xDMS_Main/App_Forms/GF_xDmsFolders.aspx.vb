Imports System.Web.Script.Serialization
Partial Class GF_xDmsFolders
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/xDMS_Main/App_Display/DF_xDmsFolders.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?FolderID=" & aVal(0)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVxDmsFolders_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsFolders.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FolderID As Int32 = GVxDmsFolders.DataKeys(e.CommandArgument).Values("FolderID")  
        Dim RedirectUrl As String = TBLxDmsFolders.EditUrl & "?FolderID=" & FolderID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVxDmsFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsFolders.Init
    DataClassName = "GxDmsFolders"
    SetGridView = GVxDmsFolders
  End Sub
  Protected Sub TBLxDmsFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFolders.Init
    SetToolBar = TBLxDmsFolders
  End Sub
  Protected Sub F_FolderID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_FolderID.TextChanged
    Session("F_FolderID") = F_FolderID.Text
    InitGridPage()
  End Sub
  Protected Sub F_ParentFolderID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ParentFolderID.TextChanged
    Session("F_ParentFolderID") = F_ParentFolderID.Text
    Session("F_ParentFolderID_Display") = F_ParentFolderID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ParentFolderIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFolders.SelectxDmsFoldersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_StatusBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_StatusBy.TextChanged
    Session("F_StatusBy") = F_StatusBy.Text
    Session("F_StatusBy_Display") = F_StatusBy_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function StatusByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_ParentFolderID_Display.Text = String.Empty
    If Not Session("F_ParentFolderID_Display") Is Nothing Then
      If Session("F_ParentFolderID_Display") <> String.Empty Then
        F_ParentFolderID_Display.Text = Session("F_ParentFolderID_Display")
      End If
    End If
    F_ParentFolderID.Text = String.Empty
    If Not Session("F_ParentFolderID") Is Nothing Then
      If Session("F_ParentFolderID") <> String.Empty Then
        F_ParentFolderID.Text = Session("F_ParentFolderID")
      End If
    End If
    Dim strScriptParentFolderID As String = "<script type=""text/javascript""> " & _
      "function ACEParentFolderID_Selected(sender, e) {" & _
      "  var F_ParentFolderID = $get('" & F_ParentFolderID.ClientID & "');" & _
      "  var F_ParentFolderID_Display = $get('" & F_ParentFolderID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_ParentFolderID.value = p[0];" & _
      "  F_ParentFolderID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ParentFolderID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ParentFolderID", strScriptParentFolderID)
      End If
    Dim strScriptPopulatingParentFolderID As String = "<script type=""text/javascript""> " & _
      "function ACEParentFolderID_Populating(o,e) {" & _
      "  var p = $get('" & F_ParentFolderID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEParentFolderID_Populated(o,e) {" & _
      "  var p = $get('" & F_ParentFolderID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ParentFolderIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ParentFolderIDPopulating", strScriptPopulatingParentFolderID)
      End If
    F_StatusBy_Display.Text = String.Empty
    If Not Session("F_StatusBy_Display") Is Nothing Then
      If Session("F_StatusBy_Display") <> String.Empty Then
        F_StatusBy_Display.Text = Session("F_StatusBy_Display")
      End If
    End If
    F_StatusBy.Text = String.Empty
    If Not Session("F_StatusBy") Is Nothing Then
      If Session("F_StatusBy") <> String.Empty Then
        F_StatusBy.Text = Session("F_StatusBy")
      End If
    End If
    Dim strScriptStatusBy As String = "<script type=""text/javascript""> " & _
      "function ACEStatusBy_Selected(sender, e) {" & _
      "  var F_StatusBy = $get('" & F_StatusBy.ClientID & "');" & _
      "  var F_StatusBy_Display = $get('" & F_StatusBy_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_StatusBy_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_StatusBy") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_StatusBy", strScriptStatusBy)
      End If
    Dim strScriptPopulatingStatusBy As String = "<script type=""text/javascript""> " & _
      "function ACEStatusBy_Populating(o,e) {" & _
      "  var p = $get('" & F_StatusBy.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEStatusBy_Populated(o,e) {" & _
      "  var p = $get('" & F_StatusBy.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_StatusByPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_StatusByPopulating", strScriptPopulatingStatusBy)
      End If
    Dim validateScriptParentFolderID As String = "<script type=""text/javascript"">" & _
      "  function validate_ParentFolderID(o) {" & _
      "    validated_FK_xDMS_Folders_ParentFolderID_main = true;" & _
      "    validate_FK_xDMS_Folders_ParentFolderID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateParentFolderID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateParentFolderID", validateScriptParentFolderID)
    End If
    Dim validateScriptStatusBy As String = "<script type=""text/javascript"">" & _
      "  function validate_StatusBy(o) {" & _
      "    validated_FK_xDMS_Folders_StatusBy_main = true;" & _
      "    validate_FK_xDMS_Folders_StatusBy(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateStatusBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateStatusBy", validateScriptStatusBy)
    End If
    Dim validateScriptFK_xDMS_Folders_StatusBy As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_xDMS_Folders_StatusBy(o) {" & _
      "    var value = o.id;" & _
      "    var StatusBy = $get('" & F_StatusBy.ClientID & "');" & _
      "    try{" & _
      "    if(StatusBy.value==''){" & _
      "      if(validated_FK_xDMS_Folders_StatusBy.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + StatusBy.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_xDMS_Folders_StatusBy(value, validated_FK_xDMS_Folders_StatusBy);" & _
      "  }" & _
      "  validated_FK_xDMS_Folders_StatusBy_main = false;" & _
      "  function validated_FK_xDMS_Folders_StatusBy(result) {" & _
      "    var p = result.split('|');" & _
      "    var o = $get(p[1]);" & _
      "    var o_d = $get(p[1]+'_Display');" & _
      "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
      "    o.style.backgroundImage  = 'none';" & _
      "    if(p[0]=='1'){" & _
      "      o.value='';" & _
      "      try{o_d.innerHTML = '';}catch(ex){}" & _
      "      __doPostBack(o.id, o.value);" & _
      "    }" & _
      "    else" & _
      "      __doPostBack(o.id, o.value);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_xDMS_Folders_StatusBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_xDMS_Folders_StatusBy", validateScriptFK_xDMS_Folders_StatusBy)
    End If
    Dim validateScriptFK_xDMS_Folders_ParentFolderID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_xDMS_Folders_ParentFolderID(o) {" & _
      "    var value = o.id;" & _
      "    var ParentFolderID = $get('" & F_ParentFolderID.ClientID & "');" & _
      "    try{" & _
      "    if(ParentFolderID.value==''){" & _
      "      if(validated_FK_xDMS_Folders_ParentFolderID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ParentFolderID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_xDMS_Folders_ParentFolderID(value, validated_FK_xDMS_Folders_ParentFolderID);" & _
      "  }" & _
      "  validated_FK_xDMS_Folders_ParentFolderID_main = false;" & _
      "  function validated_FK_xDMS_Folders_ParentFolderID(result) {" & _
      "    var p = result.split('|');" & _
      "    var o = $get(p[1]);" & _
      "    var o_d = $get(p[1]+'_Display');" & _
      "    try{o_d.innerHTML = p[2];}catch(ex){}" & _
      "    o.style.backgroundImage  = 'none';" & _
      "    if(p[0]=='1'){" & _
      "      o.value='';" & _
      "      try{o_d.innerHTML = '';}catch(ex){}" & _
      "      __doPostBack(o.id, o.value);" & _
      "    }" & _
      "    else" & _
      "      __doPostBack(o.id, o.value);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_xDMS_Folders_ParentFolderID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_xDMS_Folders_ParentFolderID", validateScriptFK_xDMS_Folders_ParentFolderID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_Folders_StatusBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim StatusBy As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(StatusBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_Folders_ParentFolderID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ParentFolderID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(ParentFolderID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
