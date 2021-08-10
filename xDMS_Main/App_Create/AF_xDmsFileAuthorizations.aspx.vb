Partial Class AF_xDmsFileAuthorizations
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsFileAuthorizations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFileAuthorizations.Init
    DataClassName = "AxDmsFileAuthorizations"
    SetFormView = FVxDmsFileAuthorizations
  End Sub
  Protected Sub TBLxDmsFileAuthorizations_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFileAuthorizations.Init
    SetToolBar = TBLxDmsFileAuthorizations
  End Sub
  Protected Sub FVxDmsFileAuthorizations_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFileAuthorizations.DataBound
    SIS.xDMS.xDmsFileAuthorizations.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsFileAuthorizations_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFileAuthorizations.PreRender
    Dim oF_UserID_Display As Label  = FVxDmsFileAuthorizations.FindControl("F_UserID_Display")
    oF_UserID_Display.Text = String.Empty
    If Not Session("F_UserID_Display") Is Nothing Then
      If Session("F_UserID_Display") <> String.Empty Then
        oF_UserID_Display.Text = Session("F_UserID_Display")
      End If
    End If
    Dim oF_UserID As TextBox  = FVxDmsFileAuthorizations.FindControl("F_UserID")
    oF_UserID.Enabled = True
    oF_UserID.Text = String.Empty
    If Not Session("F_UserID") Is Nothing Then
      If Session("F_UserID") <> String.Empty Then
        oF_UserID.Text = Session("F_UserID")
      End If
    End If
    Dim oF_FileID_Display As Label  = FVxDmsFileAuthorizations.FindControl("F_FileID_Display")
    oF_FileID_Display.Text = String.Empty
    If Not Session("F_FileID_Display") Is Nothing Then
      If Session("F_FileID_Display") <> String.Empty Then
        oF_FileID_Display.Text = Session("F_FileID_Display")
      End If
    End If
    Dim oF_FileID As TextBox  = FVxDmsFileAuthorizations.FindControl("F_FileID")
    oF_FileID.Enabled = True
    oF_FileID.Text = String.Empty
    If Not Session("F_FileID") Is Nothing Then
      If Session("F_FileID") <> String.Empty Then
        oF_FileID.Text = Session("F_FileID")
      End If
    End If
    Dim oF_CreatedBy_Display As Label  = FVxDmsFileAuthorizations.FindControl("F_CreatedBy_Display")
    oF_CreatedBy_Display.Text = String.Empty
    If Not Session("F_CreatedBy_Display") Is Nothing Then
      If Session("F_CreatedBy_Display") <> String.Empty Then
        oF_CreatedBy_Display.Text = Session("F_CreatedBy_Display")
      End If
    End If
    Dim oF_CreatedBy As TextBox  = FVxDmsFileAuthorizations.FindControl("F_CreatedBy")
    oF_CreatedBy.Enabled = True
    oF_CreatedBy.Text = String.Empty
    If Not Session("F_CreatedBy") Is Nothing Then
      If Session("F_CreatedBy") <> String.Empty Then
        oF_CreatedBy.Text = Session("F_CreatedBy")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsFileAuthorizations.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsFileAuthorizations") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsFileAuthorizations", mStr)
    End If
    If Request.QueryString("UserID") IsNot Nothing Then
      CType(FVxDmsFileAuthorizations.FindControl("F_UserID"), TextBox).Text = Request.QueryString("UserID")
      CType(FVxDmsFileAuthorizations.FindControl("F_UserID"), TextBox).Enabled = False
    End If
    If Request.QueryString("FileID") IsNot Nothing Then
      CType(FVxDmsFileAuthorizations.FindControl("F_FileID"), TextBox).Text = Request.QueryString("FileID")
      CType(FVxDmsFileAuthorizations.FindControl("F_FileID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function FileIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFiles.SelectxDmsFilesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function CreatedByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
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
