Imports System.Web.Script.Serialization
Partial Class EF_FoldersAdmin
  Inherits SIS.SYS.UpdateBase
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
  Public Property FolderID As String
    Get
      If ViewState("FolderID") IsNot Nothing Then
        Return ViewState("FolderID")
      End If
      Return ""
    End Get
    Set(value As String)
      ViewState.Add("FolderID", value)
    End Set
  End Property

  Public Property PrimaryKey() As String
    Get
      If ViewState("PrimaryKey") IsNot Nothing Then
        Return CType(ViewState("PrimaryKey"), String)
      End If
      Return True
    End Get
    Set(ByVal value As String)
      ViewState.Add("PrimaryKey", value)
    End Set
  End Property
  Protected Sub ODSxDmsFolders_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles ODSxDmsFolders.Selected
    Dim tmp As SIS.xDMS.xDmsFolders = CType(e.ReturnValue, SIS.xDMS.xDmsFolders)
    PrimaryKey = tmp.PrimaryKey
  End Sub
  Protected Sub FVxDmsFolders_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFolders.PreRender
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Edit") & "/EF_xDmsFolders.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsFolders") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsFolders", mStr)
    End If
    CType(FVxDmsFolders.FindControl("F_FolderName"), TextBox).Attributes.Add("onblur", "script_xDmsFolders.validate_FolderName(this,'" & Key & "');")
  End Sub
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function ParentFolderIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFolders.SelectxDmsFoldersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function StatusIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsStates.SelectxDmsStatesAutoCompleteList(prefixText, count, contextKey)
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
  Public Shared Function validate_FK_xDMS_Folders_ParentFolderID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim ParentFolderID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(ParentFolderID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_xDMS_Folders_StatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim StatusID As Int32 = CType(aVal(1), Int32)
    Dim oVar As SIS.xDMS.xDmsStates = SIS.xDMS.xDmsStates.xDmsStatesGetByID(StatusID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_xDMS_Folders_ReleaseWorkflowID(ByVal value As String) As String
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
  Public Shared Function validate_FK_xDMS_Folders_ReviseWorkflowID(ByVal value As String) As String
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
  Public Shared Function validate_FK_xDMS_Folders_UploadedStatusID(ByVal value As String) As String
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
  Public Shared Function validate_FK_xDMS_Folders_InitialWorkflowID(ByVal value As String) As String
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
  Private Sub FVxDmsFolders_Load(sender As Object, e As EventArgs) Handles FVxDmsFolders.Load
    If Request.QueryString("key") IsNot Nothing Then
      Key = Request.QueryString("key")
    End If
    If Request.QueryString("cmd") IsNot Nothing Then
      cmd = Request.QueryString("cmd")
    End If
    If Request.QueryString("FolderID") IsNot Nothing Then
      FolderID = Request.QueryString("FolderID")
    End If
  End Sub

  Private Sub ODSxDmsFolders_Updating(sender As Object, e As ObjectDataSourceMethodEventArgs) Handles ODSxDmsFolders.Updating
    If HttpContext.Current.Session("LoginID") Is Nothing Then
      Dim re As String = New JavaScriptSerializer().Serialize(New With {
         .err = True,
         .msg = "Session Expired, Login again."
     })
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "parent.closeIframe('" & re & "');", True)
      e.Cancel = True
      Exit Sub
    End If
    If FolderID = "" Then
      Dim re As String = New JavaScriptSerializer().Serialize(New With {
         .err = True,
         .msg = "Invalid Parent Folder ID, refresh page or Login again."
     })
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "parent.closeIframe('" & re & "');", True)
      e.Cancel = True
      Exit Sub
    End If
    Try
      Dim x As SIS.xDMS.xDmsFolders = CType(e.InputParameters.Values(0), SIS.xDMS.xDmsFolders)
      Dim fld As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.UZ_xDmsFoldersGetByID(FolderID)
      Dim LastParentID As String = fld.ParentFolderID
      If x.ParentFolderID <> fld.ParentFolderID Then
        'Parent Changed
        If SIS.xDMS.xDmsFolders.IsFolderExist(x.ParentFolderID, x.FolderName) Then
          ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize("Folder with same name exists at target") & "');", True)
          e.Cancel = True
          Exit Sub
        End If
        If x.ParentFolderID <> "" Then
          Dim oJ As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.UZ_xDmsFoldersGetByID(x.ParentFolderID)
          fld.NodeLevel = oJ.NodeLevel + 1
          If Not x.RequireExplicitWorkflow Then
            fld.InitialWorkflowID = oJ.InitialWorkflowID
            fld.ReleaseWorkflowID = oJ.ReleaseWorkflowID
            fld.ReviseWorkflowID = oJ.ReviseWorkflowID
            fld.UploadedStatusID = oJ.UploadedStatusID
            fld.UseFileTypeWorkflow = oJ.UseFileTypeWorkflow
            fld.DuplicateFileNameAllowed = oJ.DuplicateFileNameAllowed
          End If
        Else
          fld.NodeLevel = 1
        End If
      Else
        fld.ReleaseWorkflowID = x.ReleaseWorkflowID
        fld.ReviseWorkflowID = x.ReviseWorkflowID
        fld.InitialWorkflowID = x.InitialWorkflowID
        fld.UploadedStatusID = x.UploadedStatusID
        fld.UseFileTypeWorkflow = x.UseFileTypeWorkflow
        fld.DuplicateFileNameAllowed = x.DuplicateFileNameAllowed
      End If
      fld.StatusOn = Now.ToString("dd/MM/yyyy")
      fld.StatusBy = HttpContext.Current.Session("LoginID")
      fld.StatusRemarks = "Updated By Admin"
      fld.ParentFolderID = x.ParentFolderID
      fld.KeyWords = x.KeyWords
      fld.RequireExplicitWorkflow = x.RequireExplicitWorkflow
      fld.RequireExplicitAuthorization = x.RequireExplicitAuthorization
      fld.FolderName = x.FolderName
      fld = SIS.xDMS.xDmsFolders.UpdateData(fld)

      Dim RequireAuthrization As Boolean = False
      Dim RequireUpdateAll As Boolean = False
      Dim RequireDeleteAll As Boolean = False

      If x.ParentFolderID = LastParentID Then
        'No Authorization Issue
      Else
        If x.ParentFolderID = "" And LastParentID <> "" Then
          'From Folder to Root
          RequireAuthrization = True
        ElseIf x.ParentFolderID <> "" And LastParentID = "" Then
          'From Root To Folder
          'No Authorization Required, Admin can get Authorization of parent Folder
          If Not x.RequireExplicitWorkflow Then
            RequireUpdateAll = True
          End If
          If x.RequireExplicitAuthorization Then
            RequireAuthrization = True
          Else
            'Delete Root Folder Authorization for All Users
            RequireUpdateAll = False
            RequireDeleteAll = True
          End If
        ElseIf x.ParentFolderID <> "" And LastParentID <> "" Then
          'From Folder to An Other Folder
          'It is same as from root to folder (above condition)
          If Not x.RequireExplicitWorkflow Then
            RequireUpdateAll = True
          End If
          If x.RequireExplicitAuthorization Then
            RequireAuthrization = True
          Else
            'Delete Root Folder Authorization for All Users
            RequireUpdateAll = False
            RequireDeleteAll = True
          End If
        End If
      End If
      'Now Execute above scenario
      'There may be delete all, and give authorization to admin
      'so first read the admin authorization if found
      Dim xUser As SIS.xDMS.xDmsUsers = SIS.xDMS.xDmsUsers.xDmsUsersGetByID(HttpContext.Current.Session("LoginID"))
      Dim usrFld As SIS.xDMS.xDmsFolderAuthorizations = SIS.xDMS.xDmsFolderAuthorizations.xDmsFolderAuthorizationsGetByID(xUser.UserID, fld.FolderID)

      If RequireDeleteAll Then
        SIS.xDMS.xDmsFolderAuthorizations.DeleteAllFA(fld.FolderID)
      End If
      If RequireUpdateAll Then

        SIS.xDMS.xDmsFolderAuthorizations.UpdateAllFA(fld.FolderID)
        'Get All Child folder tree, upto require explicit workflow and update workflows
        'find FAs to users for each child folder and update, FA.Require explicit workflows=false
      End If

      If RequireAuthrization Then
        Dim Found As Boolean = True
        If usrFld Is Nothing Then
          Found = False
          usrFld = New SIS.xDMS.xDmsFolderAuthorizations
        End If
        With usrFld
          If Not Found Then
            .UserID = xUser.UserID
            .FolderID = fld.FolderID
            .CreateFolder = xUser.CreateFolder
            .UpdateFolder = xUser.UpdateFolder
            .DeleteFolder = xUser.DeleteFolder
            .UploadFile = xUser.UploadFile
            .DownloadFile = xUser.DownloadFile
            .DeleteFile = xUser.DeleteFile
            .CanAuthorizeFolder = xUser.CanAuthorizeFolder
            .CanPassAuthorization = xUser.CanPassAuthorization
            .CanViewAllRevisions = xUser.CanViewAllRevisions
            .IsAdmin = xUser.IsAdmin
            .CreatedBy = xUser.UserID
            .CreatedOn = Now
          End If
          .UploadedStatusID = fld.UploadedStatusID
          .InitialWorkflowID = fld.InitialWorkflowID
          .ReleaseWorkflowID = fld.ReleaseWorkflowID
          .ReviseWorkflowID = fld.ReviseWorkflowID
          .UseFileTypeWorkflow = fld.UseFileTypeWorkflow
          .DuplicateFileNameAllowed = fld.DuplicateFileNameAllowed
          .RequireExplicitAuthorization = fld.RequireExplicitAuthorization
          .RequireExplicitWorkflow = fld.RequireExplicitWorkflow
        End With
        If (Not Found) Or RequireDeleteAll Then
          usrFld = SIS.xDMS.xDmsFolderAuthorizations.InsertData(usrFld)
        Else
          usrFld = SIS.xDMS.xDmsFolderAuthorizations.UpdateData(usrFld)
        End If
      End If
      Dim re As New resp
      re.key = "e_" & IIf(LastParentID = "", "0", LastParentID)
      'Following secondary load can not be executed
      '1. It may not be authorized to me
      '2. It may not be loaded at client (sub folder->dynamic load)
      If LastParentID <> fld.ParentFolderID Then
        re.sload = True
        re.skey = "e_" & IIf(fld.ParentFolderID = "", "0", fld.ParentFolderID)
      End If
      re.cmd = cmd
      re.ifrm = False
      re.load = True
      re.wrn = True
      re.wmsg = "Folder Updated"
      Dim str As String = New JavaScriptSerializer().Serialize(re)
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "parent.closeIframe('" & str & "');", True)
    Catch ex As Exception
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
    End Try
    e.Cancel = True

  End Sub
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FolderName(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim FolderName As String = CType(aVal(1), String)
    Dim FolderID As String = CType(aVal(2).Split("_".ToCharArray)(1), String)
    If SIS.xDMS.xDmsFolders.IsDuplicateFolder(FolderID, FolderName) Then
      mRet = "1|" & aVal(0) & "|Folder with this new name already exists."
    Else
      mRet = "0|" & aVal(0)
    End If
    Return mRet
  End Function
End Class
