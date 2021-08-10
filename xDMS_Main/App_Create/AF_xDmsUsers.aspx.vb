Partial Class AF_xDmsUsers
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUsers.Init
    DataClassName = "AxDmsUsers"
    SetFormView = FVxDmsUsers
  End Sub
  Protected Sub TBLxDmsUsers_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsUsers.Init
    SetToolBar = TBLxDmsUsers
  End Sub
  Protected Sub FVxDmsUsers_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUsers.DataBound
    SIS.xDMS.xDmsUsers.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsUsers_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsUsers.PreRender
    Dim oF_UserID_Display As Label  = FVxDmsUsers.FindControl("F_UserID_Display")
    oF_UserID_Display.Text = String.Empty
    If Not Session("F_UserID_Display") Is Nothing Then
      If Session("F_UserID_Display") <> String.Empty Then
        oF_UserID_Display.Text = Session("F_UserID_Display")
      End If
    End If
    Dim oF_UserID As TextBox  = FVxDmsUsers.FindControl("F_UserID")
    oF_UserID.Enabled = True
    oF_UserID.Text = String.Empty
    If Not Session("F_UserID") Is Nothing Then
      If Session("F_UserID") <> String.Empty Then
        oF_UserID.Text = Session("F_UserID")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsUsers.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsUsers") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsUsers", mStr)
    End If
    If Request.QueryString("UserID") IsNot Nothing Then
      CType(FVxDmsUsers.FindControl("F_UserID"), TextBox).Text = Request.QueryString("UserID")
      CType(FVxDmsUsers.FindControl("F_UserID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_Users_UserID(ByVal value As String) As String
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

End Class
