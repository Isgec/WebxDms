Imports System.Web.Script.Serialization
Partial Class GF_xDmsFileAuthorizations
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/xDMS_Main/App_Display/DF_xDmsFileAuthorizations.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?UserID=" & aVal(0) & "&FileID=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVxDmsFileAuthorizations_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsFileAuthorizations.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim UserID As String = GVxDmsFileAuthorizations.DataKeys(e.CommandArgument).Values("UserID")  
        Dim FileID As Int32 = GVxDmsFileAuthorizations.DataKeys(e.CommandArgument).Values("FileID")  
        Dim RedirectUrl As String = TBLxDmsFileAuthorizations.EditUrl & "?UserID=" & UserID & "&FileID=" & FileID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVxDmsFileAuthorizations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsFileAuthorizations.Init
    DataClassName = "GxDmsFileAuthorizations"
    SetGridView = GVxDmsFileAuthorizations
  End Sub
  Protected Sub TBLxDmsFileAuthorizations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFileAuthorizations.Init
    SetToolBar = TBLxDmsFileAuthorizations
  End Sub
  Protected Sub F_UserID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_UserID.TextChanged
    Session("F_UserID") = F_UserID.Text
    Session("F_UserID_Display") = F_UserID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_FileID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_FileID.TextChanged
    Session("F_FileID") = F_FileID.Text
    Session("F_FileID_Display") = F_FileID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function FileIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFiles.SelectxDmsFilesAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub F_CreatedBy_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_CreatedBy.TextChanged
    Session("F_CreatedBy") = F_CreatedBy.Text
    Session("F_CreatedBy_Display") = F_CreatedBy_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CreatedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_UserID_Display.Text = String.Empty
    If Not Session("F_UserID_Display") Is Nothing Then
      If Session("F_UserID_Display") <> String.Empty Then
        F_UserID_Display.Text = Session("F_UserID_Display")
      End If
    End If
    F_UserID.Text = String.Empty
    If Not Session("F_UserID") Is Nothing Then
      If Session("F_UserID") <> String.Empty Then
        F_UserID.Text = Session("F_UserID")
      End If
    End If
    Dim strScriptUserID As String = "<script type=""text/javascript""> " &
      "function ACEUserID_Selected(sender, e) {" &
      "  var F_UserID = $get('" & F_UserID.ClientID & "');" &
      "  var F_UserID_Display = $get('" & F_UserID_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_UserID.value = p[0];" &
      "  F_UserID_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_UserID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_UserID", strScriptUserID)
      End If
    Dim strScriptPopulatingUserID As String = "<script type=""text/javascript""> " & _
      "function ACEUserID_Populating(o,e) {" & _
      "  var p = $get('" & F_UserID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEUserID_Populated(o,e) {" & _
      "  var p = $get('" & F_UserID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_UserIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_UserIDPopulating", strScriptPopulatingUserID)
      End If
    F_FileID_Display.Text = String.Empty
    If Not Session("F_FileID_Display") Is Nothing Then
      If Session("F_FileID_Display") <> String.Empty Then
        F_FileID_Display.Text = Session("F_FileID_Display")
      End If
    End If
    F_FileID.Text = String.Empty
    If Not Session("F_FileID") Is Nothing Then
      If Session("F_FileID") <> String.Empty Then
        F_FileID.Text = Session("F_FileID")
      End If
    End If
    Dim strScriptFileID As String = "<script type=""text/javascript""> " & _
      "function ACEFileID_Selected(sender, e) {" & _
      "  var F_FileID = $get('" & F_FileID.ClientID & "');" & _
      "  var F_FileID_Display = $get('" & F_FileID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_FileID.value = p[0];" & _
      "  F_FileID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_FileID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_FileID", strScriptFileID)
      End If
    Dim strScriptPopulatingFileID As String = "<script type=""text/javascript""> " & _
      "function ACEFileID_Populating(o,e) {" & _
      "  var p = $get('" & F_FileID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEFileID_Populated(o,e) {" & _
      "  var p = $get('" & F_FileID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_FileIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_FileIDPopulating", strScriptPopulatingFileID)
      End If
    F_CreatedBy_Display.Text = String.Empty
    If Not Session("F_CreatedBy_Display") Is Nothing Then
      If Session("F_CreatedBy_Display") <> String.Empty Then
        F_CreatedBy_Display.Text = Session("F_CreatedBy_Display")
      End If
    End If
    F_CreatedBy.Text = String.Empty
    If Not Session("F_CreatedBy") Is Nothing Then
      If Session("F_CreatedBy") <> String.Empty Then
        F_CreatedBy.Text = Session("F_CreatedBy")
      End If
    End If
    Dim strScriptCreatedBy As String = "<script type=""text/javascript""> " &
      "function ACECreatedBy_Selected(sender, e) {" &
      "  var F_CreatedBy = $get('" & F_CreatedBy.ClientID & "');" &
      "  var F_CreatedBy_Display = $get('" & F_CreatedBy_Display.ClientID & "');" &
      "  var retval = e.get_value();" &
      "  var p = retval.split('|');" &
      "  F_CreatedBy.value = p[0];" &
      "  F_CreatedBy_Display.innerHTML = e.get_text();" &
      "}" &
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CreatedBy") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CreatedBy", strScriptCreatedBy)
      End If
    Dim strScriptPopulatingCreatedBy As String = "<script type=""text/javascript""> " & _
      "function ACECreatedBy_Populating(o,e) {" & _
      "  var p = $get('" & F_CreatedBy.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACECreatedBy_Populated(o,e) {" & _
      "  var p = $get('" & F_CreatedBy.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_CreatedByPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_CreatedByPopulating", strScriptPopulatingCreatedBy)
      End If
    Dim validateScriptUserID As String = "<script type=""text/javascript"">" & _
      "  function validate_UserID(o) {" & _
      "    validated_FK_xDMS_FileAuthorizations_UserID_main = true;" & _
      "    validate_FK_xDMS_FileAuthorizations_UserID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateUserID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateUserID", validateScriptUserID)
    End If
    Dim validateScriptFileID As String = "<script type=""text/javascript"">" & _
      "  function validate_FileID(o) {" & _
      "    validated_FK_xDMS_FileAuthorizations_FileID_main = true;" & _
      "    validate_FK_xDMS_FileAuthorizations_FileID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFileID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFileID", validateScriptFileID)
    End If
    Dim validateScriptCreatedBy As String = "<script type=""text/javascript"">" & _
      "  function validate_CreatedBy(o) {" & _
      "    validated_FK_xDMS_FileAuthorizations_CreatedBy_main = true;" & _
      "    validate_FK_xDMS_FileAuthorizations_CreatedBy(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateCreatedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateCreatedBy", validateScriptCreatedBy)
    End If
    Dim validateScriptFK_xDMS_FileAuthorizations_UserID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_xDMS_FileAuthorizations_UserID(o) {" & _
      "    var value = o.id;" & _
      "    var UserID = $get('" & F_UserID.ClientID & "');" & _
      "    try{" & _
      "    if(UserID.value==''){" & _
      "      if(validated_FK_xDMS_FileAuthorizations_UserID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + UserID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_xDMS_FileAuthorizations_UserID(value, validated_FK_xDMS_FileAuthorizations_UserID);" & _
      "  }" & _
      "  validated_FK_xDMS_FileAuthorizations_UserID_main = false;" & _
      "  function validated_FK_xDMS_FileAuthorizations_UserID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_xDMS_FileAuthorizations_UserID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_xDMS_FileAuthorizations_UserID", validateScriptFK_xDMS_FileAuthorizations_UserID)
    End If
    Dim validateScriptFK_xDMS_FileAuthorizations_CreatedBy As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_xDMS_FileAuthorizations_CreatedBy(o) {" & _
      "    var value = o.id;" & _
      "    var CreatedBy = $get('" & F_CreatedBy.ClientID & "');" & _
      "    try{" & _
      "    if(CreatedBy.value==''){" & _
      "      if(validated_FK_xDMS_FileAuthorizations_CreatedBy.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + CreatedBy.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_xDMS_FileAuthorizations_CreatedBy(value, validated_FK_xDMS_FileAuthorizations_CreatedBy);" & _
      "  }" & _
      "  validated_FK_xDMS_FileAuthorizations_CreatedBy_main = false;" & _
      "  function validated_FK_xDMS_FileAuthorizations_CreatedBy(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_xDMS_FileAuthorizations_CreatedBy") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_xDMS_FileAuthorizations_CreatedBy", validateScriptFK_xDMS_FileAuthorizations_CreatedBy)
    End If
    Dim validateScriptFK_xDMS_FileAuthorizations_FileID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_xDMS_FileAuthorizations_FileID(o) {" & _
      "    var value = o.id;" & _
      "    var FileID = $get('" & F_FileID.ClientID & "');" & _
      "    try{" & _
      "    if(FileID.value==''){" & _
      "      if(validated_FK_xDMS_FileAuthorizations_FileID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + FileID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_xDMS_FileAuthorizations_FileID(value, validated_FK_xDMS_FileAuthorizations_FileID);" & _
      "  }" & _
      "  validated_FK_xDMS_FileAuthorizations_FileID_main = false;" & _
      "  function validated_FK_xDMS_FileAuthorizations_FileID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_xDMS_FileAuthorizations_FileID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_xDMS_FileAuthorizations_FileID", validateScriptFK_xDMS_FileAuthorizations_FileID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_FileAuthorizations_UserID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim UserID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(UserID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_FileAuthorizations_CreatedBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim CreatedBy As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(CreatedBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_FileAuthorizations_FileID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim FileID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(FileID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
