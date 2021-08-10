Partial Class AF_xDmsUGroupUsers
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsUGroupUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUGroupUsers.Init
    DataClassName = "AxDmsUGroupUsers"
    SetFormView = FVxDmsUGroupUsers
  End Sub
  Protected Sub TBLxDmsUGroupUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsUGroupUsers.Init
    SetToolBar = TBLxDmsUGroupUsers
  End Sub
  Protected Sub FVxDmsUGroupUsers_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUGroupUsers.DataBound
    SIS.xDMS.xDmsUGroupUsers.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsUGroupUsers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUGroupUsers.PreRender
    Dim oF_GroupID_Display As Label  = FVxDmsUGroupUsers.FindControl("F_GroupID_Display")
    oF_GroupID_Display.Text = String.Empty
    If Not Session("F_GroupID_Display") Is Nothing Then
      If Session("F_GroupID_Display") <> String.Empty Then
        oF_GroupID_Display.Text = Session("F_GroupID_Display")
      End If
    End If
    Dim oF_GroupID As TextBox  = FVxDmsUGroupUsers.FindControl("F_GroupID")
    oF_GroupID.Enabled = True
    oF_GroupID.Text = String.Empty
    If Not Session("F_GroupID") Is Nothing Then
      If Session("F_GroupID") <> String.Empty Then
        oF_GroupID.Text = Session("F_GroupID")
      End If
    End If
    Dim oF_UserID_Display As Label  = FVxDmsUGroupUsers.FindControl("F_UserID_Display")
    Dim oF_UserID As TextBox  = FVxDmsUGroupUsers.FindControl("F_UserID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsUGroupUsers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsUGroupUsers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsUGroupUsers", mStr)
    End If
    If Request.QueryString("GroupID") IsNot Nothing Then
      CType(FVxDmsUGroupUsers.FindControl("F_GroupID"), TextBox).Text = Request.QueryString("GroupID")
      CType(FVxDmsUGroupUsers.FindControl("F_GroupID"), TextBox).Enabled = False
    End If
    If Request.QueryString("UserID") IsNot Nothing Then
      CType(FVxDmsUGroupUsers.FindControl("F_UserID"), TextBox).Text = Request.QueryString("UserID")
      CType(FVxDmsUGroupUsers.FindControl("F_UserID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function GroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsUGroups.SelectxDmsUGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_GroupUsers_UserID(ByVal value As String) As String
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
