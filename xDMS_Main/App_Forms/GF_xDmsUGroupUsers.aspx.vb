Imports System.Web.Script.Serialization
Partial Class GF_xDmsUGroupUsers
  Inherits SIS.SYS.GridBase
  Private _InfoUrl As String = "~/xDMS_Main/App_Display/DF_xDmsUGroupUsers.aspx"
  Protected Sub Info_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    Dim oBut As ImageButton = CType(sender, ImageButton)
    Dim aVal() As String = oBut.CommandArgument.ToString.Split(",".ToCharArray)
    Dim RedirectUrl As String = _InfoUrl  & "?GroupID=" & aVal(0) & "&UserID=" & aVal(1)
    Response.Redirect(RedirectUrl)
  End Sub
  Protected Sub GVxDmsUGroupUsers_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsUGroupUsers.RowCommand
    If e.CommandName.ToLower = "lgedit".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim UserID As String = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("UserID")  
        Dim RedirectUrl As String = TBLxDmsUGroupUsers.EditUrl & "?GroupID=" & GroupID & "&UserID=" & UserID
        Response.Redirect(RedirectUrl)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim UserID As String = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("UserID")  
        SIS.xDMS.xDmsUGroupUsers.DeleteWF(GroupID, UserID)
        GVxDmsUGroupUsers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Applywf".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim UserID As String = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("UserID")  
        SIS.xDMS.xDmsUGroupUsers.ApplyWF(GroupID, UserID)
        GVxDmsUGroupUsers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      Try
        Dim GroupID As Int32 = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("GroupID")  
        Dim UserID As String = GVxDmsUGroupUsers.DataKeys(e.CommandArgument).Values("UserID")  
        SIS.xDMS.xDmsUGroupUsers.InitiateWF(GroupID, UserID)
        GVxDmsUGroupUsers.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
  End Sub
  Protected Sub GVxDmsUGroupUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsUGroupUsers.Init
    DataClassName = "GxDmsUGroupUsers"
    SetGridView = GVxDmsUGroupUsers
  End Sub
  Protected Sub TBLxDmsUGroupUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsUGroupUsers.Init
    SetToolBar = TBLxDmsUGroupUsers
  End Sub
  Protected Sub F_GroupID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles F_GroupID.TextChanged
    Session("F_GroupID") = F_GroupID.Text
    Session("F_GroupID_Display") = F_GroupID_Display.Text
    InitGridPage()
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function GroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsUGroups.SelectxDmsUGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
    F_GroupID_Display.Text = String.Empty
    If Not Session("F_GroupID_Display") Is Nothing Then
      If Session("F_GroupID_Display") <> String.Empty Then
        F_GroupID_Display.Text = Session("F_GroupID_Display")
      End If
    End If
    F_GroupID.Text = String.Empty
    If Not Session("F_GroupID") Is Nothing Then
      If Session("F_GroupID") <> String.Empty Then
        F_GroupID.Text = Session("F_GroupID")
      End If
    End If
    Dim strScriptGroupID As String = "<script type=""text/javascript""> " & _
      "function ACEGroupID_Selected(sender, e) {" & _
      "  var F_GroupID = $get('" & F_GroupID.ClientID & "');" & _
      "  var F_GroupID_Display = $get('" & F_GroupID_Display.ClientID & "');" & _
      "  var retval = e.get_value();" & _
      "  var p = retval.split('|');" & _
      "  F_GroupID.value = p[0];" & _
      "  F_GroupID_Display.innerHTML = e.get_text();" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_GroupID") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_GroupID", strScriptGroupID)
      End If
    Dim strScriptPopulatingGroupID As String = "<script type=""text/javascript""> " & _
      "function ACEGroupID_Populating(o,e) {" & _
      "  var p = $get('" & F_GroupID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'url(../../images/loader.gif)';" & _
      "  p.style.backgroundRepeat= 'no-repeat';" & _
      "  p.style.backgroundPosition = 'right';" & _
      "  o._contextKey = '';" & _
      "}" & _
      "function ACEGroupID_Populated(o,e) {" & _
      "  var p = $get('" & F_GroupID.ClientID & "');" & _
      "  p.style.backgroundImage  = 'none';" & _
      "}" & _
      "</script>"
      If Not Page.ClientScript.IsClientScriptBlockRegistered("F_GroupIDPopulating") Then
        Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "F_GroupIDPopulating", strScriptPopulatingGroupID)
      End If
    Dim validateScriptGroupID As String = "<script type=""text/javascript"">" & _
      "  function validate_GroupID(o) {" & _
      "    validated_FK_xDMS_GroupUsers_GroupID_main = true;" & _
      "    validate_FK_xDMS_GroupUsers_GroupID(o);" & _
      "  }" & _
      "</script>"
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateGroupID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateGroupID", validateScriptGroupID)
    End If
    Dim validateScriptFK_xDMS_GroupUsers_GroupID As String = "<script type=""text/javascript"">" & _
      "  function validate_FK_xDMS_GroupUsers_GroupID(o) {" & _
      "    var value = o.id;" & _
      "    var GroupID = $get('" & F_GroupID.ClientID & "');" & _
      "    try{" & _
      "    if(GroupID.value==''){" & _
      "      if(validated_FK_xDMS_GroupUsers_GroupID.main){" & _
      "        var o_d = $get(o.id +'_Display');" & _
      "        try{o_d.innerHTML = '';}catch(ex){}" & _
      "      }" & _
      "    }" & _
      "    value = value + ',' + GroupID.value ;" & _
      "    }catch(ex){}" & _
      "    o.style.backgroundImage  = 'url(../../images/pkloader.gif)';" & _
      "    o.style.backgroundRepeat= 'no-repeat';" & _
      "    o.style.backgroundPosition = 'right';" & _
      "    PageMethods.validate_FK_xDMS_GroupUsers_GroupID(value, validated_FK_xDMS_GroupUsers_GroupID);" & _
      "  }" & _
      "  validated_FK_xDMS_GroupUsers_GroupID_main = false;" & _
      "  function validated_FK_xDMS_GroupUsers_GroupID(result) {" & _
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
    If Not Page.ClientScript.IsClientScriptBlockRegistered("validateFK_xDMS_GroupUsers_GroupID") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "validateFK_xDMS_GroupUsers_GroupID", validateScriptFK_xDMS_GroupUsers_GroupID)
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_GroupUsers_GroupID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim GroupID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsUGroups = SIS.xDMS.xDmsUGroups.xDmsUGroupsGetByID(GroupID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
End Class
