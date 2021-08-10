Imports System.Web.Script.Serialization
Partial Class AF_FAAdmin
  Inherits SIS.SYS.InsertBase
  Public Property Key As String
    Get
      If ViewState("key") IsNot Nothing Then
        Return ViewState("key")
      End If
      Return "c_-1"
    End Get
    Set(value As String)
      ViewState.Add("key", value)
    End Set
  End Property
  Public Property cmd As String
    Get
      If ViewState("cmd") IsNot Nothing Then
        Return ViewState("cmd")
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("cmd", value)
    End Set
  End Property
  Private Sub FVxDmsFolderAuthorizations_Load(sender As Object, e As EventArgs) Handles FVxDmsFolderAuthorizations.Load
    If Request.QueryString("key") IsNot Nothing Then
      Key = Request.QueryString("key")
    End If
    If Request.QueryString("cmd") IsNot Nothing Then
      cmd = Request.QueryString("cmd")
    End If
  End Sub
  Private Sub ODSxDmsFolderAuthorizations_Inserting(sender As Object, e As ObjectDataSourceMethodEventArgs) Handles ODSxDmsFolderAuthorizations.Inserting
    If HttpContext.Current.Session("LoginID") Is Nothing Then
      Dim re As String = New JavaScriptSerializer().Serialize(New With {
         .err = True,
         .msg = "Session Expired, Login again."
     })
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "parent.closeIframe('" & re & "');", True)
      e.Cancel = True
      Exit Sub
    End If
    Dim FolderID As String = CType(Key.Split("_".ToCharArray)(1), String)
    If FolderID = "-1" Then
      Dim re As String = New JavaScriptSerializer().Serialize(New With {
         .err = True,
         .msg = "Invalid Folder ID, refresh page or Login again."
     })
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "parent.closeIframe('" & re & "');", True)
      e.Cancel = True
      Exit Sub
    End If
    Try
      Dim x As SIS.xDMS.xDmsFolderAuthorizations = CType(e.InputParameters.Values(0), SIS.xDMS.xDmsFolderAuthorizations)
      Dim xUser As SIS.xDMS.xDmsUsers = SIS.xDMS.xDmsUsers.xDmsUsersGetByID(HttpContext.Current.Session("LoginID"))
      Dim found As Boolean = True
      Dim usrFld As SIS.xDMS.xDmsFolderAuthorizations = SIS.xDMS.xDmsFolderAuthorizations.xDmsFolderAuthorizationsGetByID(x.UserID, FolderID)
      If usrFld Is Nothing Then
        usrFld = New SIS.xDMS.xDmsFolderAuthorizations
        found = False
      End If
      With usrFld
        .UserID = x.UserID
        .FolderID = x.FolderID
        .CreateFolder = x.CreateFolder
        .UpdateFolder = x.UpdateFolder
        .DeleteFolder = x.DeleteFolder
        .UploadFile = x.UploadFile
        .DownloadFile = x.DownloadFile
        .DeleteFile = x.DeleteFile
        .CanAuthorizeFolder = x.CanAuthorizeFolder
        .CanPassAuthorization = x.CanPassAuthorization
        .CanViewAllRevisions = x.CanViewAllRevisions
        .IsAdmin = x.IsAdmin
        .CreatedBy = xUser.UserID
        .CreatedOn = Now
        .UploadedStatusID = x.UploadedStatusID
        .InitialWorkflowID = x.InitialWorkflowID
        .ReleaseWorkflowID = x.ReleaseWorkflowID
        .ReviseWorkflowID = x.ReviseWorkflowID
        .UseFileTypeWorkflow = x.UseFileTypeWorkflow
        .DuplicateFileNameAllowed = x.DuplicateFileNameAllowed
        .RequireExplicitAuthorization = x.RequireExplicitAuthorization
        .RequireExplicitWorkflow = x.RequireExplicitWorkflow
      End With
      If found Then
        usrFld = SIS.xDMS.xDmsFolderAuthorizations.UpdateData(usrFld)
      Else
        usrFld = SIS.xDMS.xDmsFolderAuthorizations.InsertData(usrFld)
      End If
      Dim re As New resp
      re.key = Key
      re.cmd = cmd
      re.ifrm = False
      re.load = False
      re.wrn = True
      re.wmsg = "Authorization Given"
      Dim str As String = New JavaScriptSerializer().Serialize(re)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "parent.closeIframe('" & str & "');", True)
    Catch ex As Exception
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
    End Try
    e.Cancel = True

  End Sub

  Protected Sub FVxDmsFolderAuthorizations_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFolderAuthorizations.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Controls") & "/AF_FAAdmin.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsFolderAuthorizations") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsFolderAuthorizations", mStr)
    End If
    CType(FVxDmsFolderAuthorizations.FindControl("F_UserID"), TextBox).Attributes.Add("onblur", "script_xDmsFolderAuthorizations.validate_UserID(this,'" & Key & "');")
    Dim FolderID As String = CType(Key.Split("_".ToCharArray)(1), String)
    Dim fld As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(FolderID)
    CType(FVxDmsFolderAuthorizations.FindControl("F_FolderID"), TextBox).Text = FolderID
    CType(FVxDmsFolderAuthorizations.FindControl("F_FolderID_Display"), Label).Text = fld.FolderName
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function FolderIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFolders.SelectxDmsFoldersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ReleaseWorkflowIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ReviseWorkflowIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function InitialWorkflowIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function UploadedStatusIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsStates.SelectxDmsStatesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_xDMS_FolderAuthorizations_UserID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim UserID As String = CType(aVal(1), String)
    Dim FolderID As String = CType(aVal(2).Split("_".ToCharArray)(1), String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(UserID)
    If oVar Is Nothing Then
      'mRet = "1|" & aVal(0) & "|Record not found."
      Return New JavaScriptSerializer().Serialize(New With {
         .err = True,
         .key = aVal(0),
         .msg = "Record not found.",
         .data = ""
     })

    Else
      'Dim jxx As New JavaScriptSerializer()
      'jxx.MaxJsonLength = Integer.MaxValue

      Dim oFA As SIS.xDMS.xDmsFolderAuthorizations = SIS.xDMS.xDmsFolderAuthorizations.xDmsFolderAuthorizationsGetByID(UserID, FolderID)
      'mRet = "0|" & aVal(0) & "|" & oVar.DisplayField & "|" & jxx.Serialize(oFA)
      Return New JavaScriptSerializer().Serialize(New With {
         .err = False,
         .key = aVal(0),
         .msg = oVar.DisplayField,
         .data = oFA
     })

    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_xDMS_FolderAuthorizations_FolderID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim FolderID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(FolderID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_xDMS_FolderAuthorizations_ReleaseWorkflowID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ReleaseWorkflowID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(ReleaseWorkflowID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_xDMS_FolderAuthorizations_ReviseWorkflowID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ReviseWorkflowID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(ReviseWorkflowID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_xDMS_FolderAuthorizations_UploadedStatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim UploadedStatusID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.xDMS.xDmsStates = SIS.xDMS.xDmsStates.xDmsStatesGetByID(UploadedStatusID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_xDMS_FolderAuthorizations_InitialWorkflowID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim InitialWorkflowID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(InitialWorkflowID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function

End Class
