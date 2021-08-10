Imports System.Web.Script.Serialization
Partial Class GF_xDmsFiles
  Inherits SIS.SYS.GridBase
  Protected Sub GVxDmsFiles_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsFiles.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim FileID As Int32 = GVxDmsFiles.DataKeys(e.CommandArgument).Values("FileID")
        Dim RedirectUrl As String = TBLxDmsFiles.EditUrl & "?FileID=" & FileID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVxDmsFiles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsFiles.Init
    DataClassName = "GxDmsFiles"
    SetGridView = GVxDmsFiles
  End Sub
  Protected Sub TBLxDmsFiles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFiles.Init
    SetToolBar = TBLxDmsFiles
  End Sub
  Protected Sub F_FileID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_FileID.TextChanged
    Session("F_FileID") = F_FileID.Text
    InitGridPage()
  End Sub
  Protected Sub F_FolderID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_FolderID.TextChanged
    Session("F_FolderID") = F_FolderID.Text
    Session("F_FolderID_Display") = F_FolderID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function FolderIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFolders.SelectxDmsFoldersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_StatusID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_StatusID.TextChanged
    Session("F_StatusID") = F_StatusID.Text
    Session("F_StatusID_Display") = F_StatusID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function StatusIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsStates.SelectxDmsStatesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_ParentIFileID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_ParentIFileID.TextChanged
    Session("F_ParentIFileID") = F_ParentIFileID.Text
    Session("F_ParentIFileID_Display") = F_ParentIFileID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ParentIFileIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFiles.SelectxDmsFilesAutoCompleteList(prefixText, count, contextKey)
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
    F_FolderID_Display.Text = String.Empty
    If Not Session("F_FolderID_Display") Is Nothing Then
      If Session("F_FolderID_Display") <> String.Empty Then
        F_FolderID_Display.Text = Session("F_FolderID_Display")
      End If
    End If
    F_FolderID.Text = String.Empty
    If Not Session("F_FolderID") Is Nothing Then
      If Session("F_FolderID") <> String.Empty Then
        F_FolderID.Text = Session("F_FolderID")
      End If
    End If
    Dim strScriptFolderID As String = "<script type=""text/javascript""> " & _
      "function ACEFolderID_Selected(sender, e) {" & _
      "  var F_FolderID = $get('" & F_FolderID.ClientID & "');" & _
      "  var F_FolderID_Display = $get('" & F_FolderID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_FolderID.value = p[0];" & _
      "  F_FolderID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_FolderID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_FolderID", strScriptFolderID)
      End If
    Dim strScriptPopulatingFolderID As String = "<script type=""text/javascript""> " & _
      "function ACEFolderID_Populating(o,e) {" & _
      "  var p = $get('" & F_FolderID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEFolderID_Populated(o,e) {" & _
      "  var p = $get('" & F_FolderID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_FolderIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_FolderIDPopulating", strScriptPopulatingFolderID)
      End If
    F_StatusID_Display.Text = String.Empty
    If Not Session("F_StatusID_Display") Is Nothing Then
      If Session("F_StatusID_Display") <> String.Empty Then
        F_StatusID_Display.Text = Session("F_StatusID_Display")
      End If
    End If
    F_StatusID.Text = String.Empty
    If Not Session("F_StatusID") Is Nothing Then
      If Session("F_StatusID") <> String.Empty Then
        F_StatusID.Text = Session("F_StatusID")
      End If
    End If
    Dim strScriptStatusID As String = "<script type=""text/javascript""> " & _
      "function ACEStatusID_Selected(sender, e) {" & _
      "  var F_StatusID = $get('" & F_StatusID.ClientID & "');" & _
      "  var F_StatusID_Display = $get('" & F_StatusID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_StatusID.value = p[0];" & _
      "  F_StatusID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_StatusID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_StatusID", strScriptStatusID)
      End If
    Dim strScriptPopulatingStatusID As String = "<script type=""text/javascript""> " & _
      "function ACEStatusID_Populating(o,e) {" & _
      "  var p = $get('" & F_StatusID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEStatusID_Populated(o,e) {" & _
      "  var p = $get('" & F_StatusID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_StatusIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_StatusIDPopulating", strScriptPopulatingStatusID)
      End If
    F_ParentIFileID_Display.Text = String.Empty
    If Not Session("F_ParentIFileID_Display") Is Nothing Then
      If Session("F_ParentIFileID_Display") <> String.Empty Then
        F_ParentIFileID_Display.Text = Session("F_ParentIFileID_Display")
      End If
    End If
    F_ParentIFileID.Text = String.Empty
    If Not Session("F_ParentIFileID") Is Nothing Then
      If Session("F_ParentIFileID") <> String.Empty Then
        F_ParentIFileID.Text = Session("F_ParentIFileID")
      End If
    End If
    Dim strScriptParentIFileID As String = "<script type=""text/javascript""> " & _
      "function ACEParentIFileID_Selected(sender, e) {" & _
      "  var F_ParentIFileID = $get('" & F_ParentIFileID.ClientID & "');" & _
      "  var F_ParentIFileID_Display = $get('" & F_ParentIFileID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_ParentIFileID.value = p[0];" & _
      "  F_ParentIFileID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ParentIFileID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ParentIFileID", strScriptParentIFileID)
      End If
    Dim strScriptPopulatingParentIFileID As String = "<script type=""text/javascript""> " & _
      "function ACEParentIFileID_Populating(o,e) {" & _
      "  var p = $get('" & F_ParentIFileID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEParentIFileID_Populated(o,e) {" & _
      "  var p = $get('" & F_ParentIFileID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_ParentIFileIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_ParentIFileIDPopulating", strScriptPopulatingParentIFileID)
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
    Dim strScriptStatusBy As String = "<script type=""text/javascript""> " &
      "function ACEStatusBy_Selected(sender, e) {" &
      "  var F_StatusBy = $get('" & F_StatusBy.ClientID & "');" &
      "  var F_StatusBy_Display = $get('" & F_StatusBy_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_StatusBy.value = p[0];" &
      "  F_StatusBy_Display.innerHTML = e.get_text();" &
      "}" &
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
    Dim validateScriptFolderID As String = "<script type=""text/javascript"">" & _
      "  function validate_FolderID(o) {" & _
      "    validated_FK_xDMS_Files_FolderID_main = true;" & _
      "    validate_FK_xDMS_Files_FolderID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFolderID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFolderID", validateScriptFolderID)
    End If
    Dim validateScriptStatusID As String = "<script type=""text/javascript"">" & _
      "  function validate_StatusID(o) {" & _
      "    validated_FK_xDMS_Files_StatusID_main = true;" & _
      "    validate_FK_xDMS_Files_StatusID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateStatusID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateStatusID", validateScriptStatusID)
    End If
    Dim validateScriptParentIFileID As String = "<script type=""text/javascript"">" & _
      "  function validate_ParentIFileID(o) {" & _
      "    validated_FK_xDMS_Files_ParentFileID_main = true;" & _
      "    validate_FK_xDMS_Files_ParentFileID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateParentIFileID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateParentIFileID", validateScriptParentIFileID)
    End If
    Dim validateScriptStatusBy As String = "<script type=""text/javascript"">" & _
      "  function validate_StatusBy(o) {" & _
      "    validated_FK_xDMS_Files_StatusBy_main = true;" & _
      "    validate_FK_xDMS_Files_StatusBy(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateStatusBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateStatusBy", validateScriptStatusBy)
    End If
    Dim validateScriptFK_xDMS_Files_StatusBy As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_xDMS_Files_StatusBy(o) {" & _
      "    var value = o.id;" & _
      "    var StatusBy = $get('" & F_StatusBy.ClientID & "');" & _
      "    try{" & _
      "    if(StatusBy.value==''){" & _
      "      if(validated_FK_xDMS_Files_StatusBy.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + StatusBy.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_xDMS_Files_StatusBy(value, validated_FK_xDMS_Files_StatusBy);" & _
      "  }" & _
      "  validated_FK_xDMS_Files_StatusBy_main = false;" & _
      "  function validated_FK_xDMS_Files_StatusBy(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_xDMS_Files_StatusBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_xDMS_Files_StatusBy", validateScriptFK_xDMS_Files_StatusBy)
    End If
    Dim validateScriptFK_xDMS_Files_ParentFileID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_xDMS_Files_ParentFileID(o) {" & _
      "    var value = o.id;" & _
      "    var ParentIFileID = $get('" & F_ParentIFileID.ClientID & "');" & _
      "    try{" & _
      "    if(ParentIFileID.value==''){" & _
      "      if(validated_FK_xDMS_Files_ParentFileID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + ParentIFileID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_xDMS_Files_ParentFileID(value, validated_FK_xDMS_Files_ParentFileID);" & _
      "  }" & _
      "  validated_FK_xDMS_Files_ParentFileID_main = false;" & _
      "  function validated_FK_xDMS_Files_ParentFileID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_xDMS_Files_ParentFileID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_xDMS_Files_ParentFileID", validateScriptFK_xDMS_Files_ParentFileID)
    End If
    Dim validateScriptFK_xDMS_Files_FolderID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_xDMS_Files_FolderID(o) {" & _
      "    var value = o.id;" & _
      "    var FolderID = $get('" & F_FolderID.ClientID & "');" & _
      "    try{" & _
      "    if(FolderID.value==''){" & _
      "      if(validated_FK_xDMS_Files_FolderID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + FolderID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_xDMS_Files_FolderID(value, validated_FK_xDMS_Files_FolderID);" & _
      "  }" & _
      "  validated_FK_xDMS_Files_FolderID_main = false;" & _
      "  function validated_FK_xDMS_Files_FolderID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_xDMS_Files_FolderID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_xDMS_Files_FolderID", validateScriptFK_xDMS_Files_FolderID)
    End If
    Dim validateScriptFK_xDMS_Files_StatusID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_xDMS_Files_StatusID(o) {" & _
      "    var value = o.id;" & _
      "    var StatusID = $get('" & F_StatusID.ClientID & "');" & _
      "    try{" & _
      "    if(StatusID.value==''){" & _
      "      if(validated_FK_xDMS_Files_StatusID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + StatusID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_xDMS_Files_StatusID(value, validated_FK_xDMS_Files_StatusID);" & _
      "  }" & _
      "  validated_FK_xDMS_Files_StatusID_main = false;" & _
      "  function validated_FK_xDMS_Files_StatusID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_xDMS_Files_StatusID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_xDMS_Files_StatusID", validateScriptFK_xDMS_Files_StatusID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_Files_StatusBy(ByVal value As String) As String
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
  Public Shared Function validate_FK_xDMS_Files_ParentFileID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ParentIFileID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(ParentIFileID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_Files_FolderID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim FolderID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(FolderID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_Files_StatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim StatusID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsStates = SIS.xDMS.xDmsStates.xDmsStatesGetByID(StatusID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
