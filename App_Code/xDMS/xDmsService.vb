Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Serialization
<System.Web.Script.Services.ScriptService()>
<WebService(Namespace:="http://tempuri.org/")>
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)>
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Public Class xDmsService
  Inherits System.Web.Services.WebService
  Private xUser As SIS.xDMS.xDmsUsers = Nothing
#Region " ValidateSession "
  Private Function ValidateSession() As Boolean
    If HttpContext.Current.Session("LoginID") IsNot Nothing Then
      xUser = SIS.xDMS.xDmsUsers.xDmsUsersGetByID(HttpContext.Current.Session("LoginID"))
    End If
    If xUser Is Nothing Then Return False
    Return True
  End Function
#End Region
#Region " SessionExpired "
  Private Function SessionExpired() As String
    Return New JavaScriptSerializer().Serialize(New With {
         .err = True,
         .msg = "Session Expired, Login again."
     })
  End Function
#End Region
#Region " Error Do Nothing  "
  Private Function ErrorDoNothing() As String
    Return New JavaScriptSerializer().Serialize(New With {.err = True})
  End Function
#End Region
#Region " Return Error Message  "
  Private Function ErrorMessage(strMsg As String) As String
    Return New JavaScriptSerializer().Serialize(New With {.err = True, .msg = strMsg})
  End Function
#End Region
#Region " Return Default  "
  Private Function DoDefault(re As resp) As String
    Return New JavaScriptSerializer().Serialize(re)
  End Function
#End Region

  <WebMethod(EnableSession:=True)>
  Public Function LoadItem(key As String, lvl As String) As String
    If Not ValidateSession() Then Return SessionExpired()
    Dim aCon As String() = key.Split("_".ToCharArray)
    Dim fldID As Integer = aCon(1)
    Dim jxx As New JavaScriptSerializer()
    jxx.MaxJsonLength = Integer.MaxValue
    Dim re As New resp
    With re
      .key = key
      .html = SIS.DMS.Node.GetNode(fldID, lvl)
    End With
    Return jxx.Serialize(re)
  End Function
  Private Function DeleteFolder(re As resp) As resp
    Try
      Dim aCon As String() = re.key.Split("_".ToCharArray)
      Dim fldID As Integer = aCon(1)

      Dim fld As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.UZ_xDmsFoldersGetByID(fldID)
      If fld.FoldersCount > 0 Or fld.FilesCount > 0 Then
        re = New resp
        re.err = True
        re.msg = "There are contents in folder, can NOT delete."
        Return re
      End If
      SIS.xDMS.xDmsFolderAuthorizations.DeleteAuthorizationsForFolderID(fldID)
      SIS.xDMS.xDmsFolders.UZ_xDmsFoldersDelete(fld)
      re.wrn = True
      re.wmsg = "Folder Deleted"
      re.load = True
      re.key = aCon(0) & "_" & IIf(fld.ParentFolderID = "", "0", fld.ParentFolderID)
    Catch ex As Exception
      re = New resp
      re.err = True
      re.msg = ex.Message
    End Try
    Return re
  End Function
  Private Function ValidateFolder(re As resp) As resp
    Dim aCon As String() = re.key.Split("_".ToCharArray)
    Dim fldID As Integer = aCon(1)
    Dim Root As Boolean = IIf(fldID = 0, True, False)

    Dim fld As SIS.xDMS.xDmsFolders = Nothing
    If Not Root Then fld = SIS.xDMS.xDmsFolders.GetAuthRootFolder(fldID, xUser.UserID)

    Dim fldUsr As SIS.xDMS.xDmsFolderAuthorizations = Nothing
    If Not Root Then fldUsr = SIS.xDMS.xDmsFolderAuthorizations.xDmsFolderAuthorizationsGetByID(xUser.UserID, fld.FolderID)

    Select Case re.cmd.ToLower
      Case "Upload Files".ToLower
        If Root Then
          re.err = True
          re.msg = "Files can not be uploaded at Root."
          Return re
        End If
        If xUser.IsAdmin Or xUser.IsSAdmin Then
          re.ufrm = True
          Return re
        End If
        If fld.StatusBy <> xUser.UserID Then
          If Not xUser.UploadFile Then
            re.err = True
            re.msg = "User permission: Not Allowed."
            Return re
          End If
          If fldUsr Is Nothing Then
            re.msg = "User is not authorized for this folder"
            re.err = True
            Return re
          End If
          If Not fldUsr.UploadFile Then
            re.msg = "User permission: Not Allowed."
            re.err = True
            Return re
          End If
        End If
        re.ufrm = True
      Case "Delete".ToLower
        If xUser.IsAdmin Or xUser.IsSAdmin Then
          Return DeleteFolder(re)
        End If
        If Root Then
          If Not xUser.CreateRootLevelFolder Then
            re.err = True
            re.msg = "User permission: Not Allowed."
            Return re
          End If
        Else
          If fld.StatusBy <> xUser.UserID Then
            If Not xUser.DeleteFolder Then
              re.err = True
              re.msg = "User permission: Not Allowed."
              Return re
            End If
            If fldUsr Is Nothing Then
              re.msg = "User is not authorized for this folder"
              re.err = True
              Return re
            End If
            If Not fldUsr.DeleteFolder Then
              re.msg = "User permission: Not Allowed."
              re.err = True
              Return re
            End If
          End If
        End If
        Return DeleteFolder(re)
      Case "Create".ToLower
        're.html = "FolderName,KeyWords" & IIf(xUser.IsAdmin, ",NotInherit", "")
        If xUser.IsAdmin Or xUser.IsSAdmin Then
          re.data = "../App_Controls/AF_FoldersAdmin.aspx?key=" & re.key & "&cmd=" & re.cmd
          re.ifrm = True
          Return re
        End If
        If Root Then
          If Not xUser.CreateRootLevelFolder Then
            re.err = True
            re.msg = "User permission: Not Allowed."
            Return re
          End If
        Else
          If fld.StatusBy <> xUser.UserID Then
            If Not xUser.CreateFolder Then
              re.err = True
              re.msg = "User permission: Not Allowed."
              Return re
            End If
            If fldUsr Is Nothing Then
              re.msg = "User is not authorized for this folder"
              re.err = True
              Return re
            End If
            If Not fldUsr.CreateFolder Then
              re.msg = "User permission: Not Allowed."
              re.err = True
              Return re
            End If
          End If
        End If
        re.data = "../App_Controls/AF_FoldersUser.aspx?key=" & re.key & "&cmd=" & re.cmd
        re.ifrm = True
      Case "Edit".ToLower
        're.html = "FolderName,KeyWords" & IIf(xUser.IsAdmin, ",NotInherit", "")
        If xUser.IsAdmin Or xUser.IsSAdmin Then
          re.data = "../App_Controls/EF_FoldersAdmin.aspx?key=" & re.key & "&cmd=" & re.cmd & "&FolderID=" & fldID
          re.ifrm = True
          Return re
        End If
        If fld.StatusBy <> xUser.UserID Then
          re.err = True
          re.msg = "User permission: Not Allowed."
          Return re
        End If
        re.data = "../App_Controls/EF_FoldersUser.aspx?key=" & re.key & "&cmd=" & re.cmd & "&FolderID=" & fldID
        re.ifrm = True
      Case "Authorize to User".ToLower
        're.html = "UserID,CreateFolder,UpdateFolder,DeleteFolder,UploadFile,DownloadFile,DeleteFile,CanAuthorizeFolder,CanPassAuthorization"
        If Root Then
          re.err = True
          re.msg = "Root Folder can not be Authorized."
          Return re
        Else
          If xUser.IsAdmin Or xUser.IsSAdmin Then
            re.data = "../App_Controls/AF_FAAdmin.aspx?key=" & re.key & "&cmd=" & re.cmd
            re.ifrm = True
            Return re
          End If
          If Not fldUsr.CanPassAuthorization Then
            re.msg = "Folder permission: Not Allowed."
            re.err = True
            Return re
          End If
          If fld.StatusBy <> xUser.UserID Then
            If Not xUser.CanPassAuthorization Then
              re.err = True
              re.msg = "User permission: Not Allowed."
              Return re
            End If
            If fldUsr Is Nothing Then
              re.msg = "User is not authorized for this folder"
              re.err = True
              Return re
            End If
          Else
            If Not xUser.CanAuthorizeFolder Then
              re.msg = "User permission: Not Allowed."
              re.err = True
              Return re
            End If
          End If
        End If
        re.data = "../App_Controls/AF_FAUser.aspx?key=" & re.key & "&cmd=" & re.cmd
        re.ifrm = True
      Case "Download".ToLower
        If xUser.IsAdmin Or xUser.IsSAdmin Then
          Return re
        End If
        If fld.StatusBy <> xUser.UserID Then
          If Not xUser.DownloadFile Then
            re.err = True
            re.msg = "User permission: Not Allowed."
            Return re
          End If
          If fldUsr Is Nothing Then
            re.msg = "User is not authorized for this folder"
            re.err = True
            Return re
          End If
          If Not fldUsr.DownloadFile Then
            re.msg = "User permission: Not Allowed."
            re.err = True
            Return re
          End If
        End If
        Return re
      Case "Export BOM".ToLower
        If Root Then
          re.err = True
          re.msg = "Export BOM can not done at Root"
          Return re
        End If
        Dim cfld As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(fldID)
        If cfld.KeyWords.IndexOf("Prj:") < 0 Then
          re.err = True
          re.msg = "Folder is NOT for Export BOM"
          Return re
        End If
        re.data = "../../App_Downloads/dmsExtractBOM.aspx?key=" & re.key
        re.down = True
      Case "Other"
    End Select
    Return re
  End Function
  <WebMethod(EnableSession:=True)>
  Public Function MenuClicked(key As String, cmd As String) As String
    If Not ValidateSession() Then Return SessionExpired()
    Dim re As New resp
    re.key = key
    re.cmd = cmd

    re = ValidateFolder(re)
    If re.err Then Return ErrorMessage(re.msg)

    Return DoDefault(re)
  End Function
  <WebMethod(EnableSession:=True)>
  Public Function UnderApproval(key As String, cmd As String) As String
    If Not ValidateSession() Then Return SessionExpired()
    Dim re As New resp
    re.key = key
    re.cmd = cmd
    re.ifrm = True
    re.data = "../App_Controls/GF_UnderApproval.aspx?key=" & re.key & "&cmd=" & re.cmd
    're = ValidateFile(re)
    'If re.err Then Return ErrorMessage(re.msg)

    Return DoDefault(re)
  End Function
  Private Function ValidateFile(re As resp) As resp
    Dim aCon As String() = re.key.Split("_".ToCharArray)
    Dim filID As Integer = aCon(1)
    Dim tFile As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(filID)
    Dim filUsr As SIS.xDMS.xDmsFileAuthorizations = SIS.xDMS.xDmsFileAuthorizations.xDmsFileAuthorizationsGetByID(xUser.UserID, filID)

    Select Case re.cmd.ToLower
      Case "Keyword".ToLower
        re.html = "KeyWords"
        re.data = tFile.KeyWords
        Select Case tFile.BaseStatus
          Case enumBaseStatus.Free, enumBaseStatus.WIP
          Case Else
            re.err = True
            re.msg = "File Status is NOT Free."
            Return re
        End Select
        re.ifrm = True
      Case "Download".ToLower
        If xUser.IsAdmin Or xUser.IsSAdmin Then
          Return re
        End If
        If tFile.StatusBy <> xUser.UserID Then
          If Not xUser.DownloadFile Then
            re.err = True
            re.msg = "User permission: Not Allowed."
            Return re
          End If
          If filUsr IsNot Nothing Then
            If Not filUsr.DownloadFile Then
              re.msg = "User is not authorized for this file"
              re.err = True
              Return re
            End If
          End If
        End If
        Return re
      Case "Other"
    End Select
    Return re
  End Function

  <WebMethod(EnableSession:=True)>
  Public Function FileClicked(key As String, cmd As String) As String
    If Not ValidateSession() Then Return SessionExpired()
    Dim re As New resp
    re.key = key
    re.cmd = cmd

    re = ValidateFile(re)
    If re.err Then Return ErrorMessage(re.msg)

    Return DoDefault(re)
  End Function
  <WebMethod(EnableSession:=True)>
  Public Function SelectUpdate(key As String, cmd As String, data As String) As String
    Select Case cmd.ToLower
      Case "Keyword".ToLower
        Return FileUpdate(key, cmd, data)
      Case Else
        Return FolderUpdate(key, cmd, data)
    End Select
  End Function

  Private Function FolderUpdate(key As String, cmd As String, data As String) As String
    If Not ValidateSession() Then Return SessionExpired()
    Dim re As New resp
    re.key = key
    re.cmd = cmd

    re = ValidateFolder(re)
    re.ifrm = False

    If re.err Then Return ErrorMessage(re.msg)

    Dim aCon As String() = key.Split("_".ToCharArray)
    Dim fldID As Integer = aCon(1)
    Dim Root As Boolean = IIf(fldID = 0, True, False)
    Dim pFld As SIS.xDMS.xDmsFolders = Nothing
    If Not Root Then pFld = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(fldID)

    Dim aData() As String = data.Split("|".ToCharArray)

    Select Case cmd.ToLower
      Case "Create".ToLower
        Dim tmpFld As New SIS.xDMS.xDmsFolders
        With tmpFld
          .FolderName = aData(0)
          .KeyWords = aData(1)
          .Active = True
          .Hseq = 0
          .ItemTypeID = "Folder"
          If Root Then
            .NodeLevel = 1
            .ParentFolderID = ""
          Else
            .NodeLevel = pFld.NodeLevel + 1
            .ParentFolderID = fldID
          End If
          If xUser.IsAdmin Or xUser.IsSAdmin Then
            .RequireExplicitAuthorization = Convert.ToBoolean(aData(2))
          Else
            .RequireExplicitAuthorization = False
          End If
          .StatusBy = xUser.UserID
          .StatusID = enumStatus.Free
          .StatusOn = Now
          .StatusRemarks = "Created By User"
        End With
        tmpFld = SIS.xDMS.xDmsFolders.InsertData(tmpFld)
        If Root Then
          Dim usrFld As New SIS.xDMS.xDmsFolderAuthorizations
          With usrFld
            .UserID = xUser.UserID
            .FolderID = tmpFld.FolderID
            .CreateFolder = True
            .UpdateFolder = True
            .DeleteFolder = True
            .UploadFile = True
            .DownloadFile = True
            .DeleteFile = True
            .CanAuthorizeFolder = True
            .CanPassAuthorization = True
            .CreatedBy = ""
            .CreatedOn = Now
          End With
          usrFld = SIS.xDMS.xDmsFolderAuthorizations.InsertData(usrFld)
        End If
        re.load = True
        re.wrn = True
        re.wmsg = "Folder Created"
      Case "Authorize to User".ToLower
        If aData.Count >= 9 AndAlso aData(0) <> "" Then
          Dim Found As Boolean = True
          Dim usrFld As SIS.xDMS.xDmsFolderAuthorizations = SIS.xDMS.xDmsFolderAuthorizations.xDmsFolderAuthorizationsGetByID(aData(0), fldID)
          If usrFld Is Nothing Then
            Found = False
            usrFld = New SIS.xDMS.xDmsFolderAuthorizations
          End If
          With usrFld
            .UserID = aData(0)
            .FolderID = fldID
            .CreateFolder = Convert.ToBoolean(aData(1))
            .UpdateFolder = Convert.ToBoolean(aData(2))
            .DeleteFolder = Convert.ToBoolean(aData(3))
            .UploadFile = Convert.ToBoolean(aData(4))
            .DownloadFile = Convert.ToBoolean(aData(5))
            .DeleteFile = Convert.ToBoolean(aData(6))
            .CanAuthorizeFolder = Convert.ToBoolean(aData(7))
            .CanPassAuthorization = Convert.ToBoolean(aData(8))
            .CreatedBy = xUser.UserID
            .CreatedOn = Now
          End With
          If Found Then
            usrFld = SIS.xDMS.xDmsFolderAuthorizations.UpdateData(usrFld)
            re.wmsg = "Authorization Updated"
          Else
            usrFld = SIS.xDMS.xDmsFolderAuthorizations.InsertData(usrFld)
            re.wmsg = "Authorization Given"
          End If
          re.wrn = True
        Else
          re.err = True
          re.msg = "User ID not provided for authorization"
        End If
    End Select


    Return DoDefault(re)
  End Function

  Private Function FileUpdate(key As String, cmd As String, data As String) As String
    If Not ValidateSession() Then Return SessionExpired()
    Dim re As New resp
    re.key = key
    re.cmd = cmd

    re = ValidateFile(re)
    re.ifrm = False

    If re.err Then Return ErrorMessage(re.msg)

    Dim aCon As String() = key.Split("_".ToCharArray)
    Dim filID As Integer = aCon(1)

    Dim aData() As String = data.Split("|".ToCharArray)

    Select Case cmd.ToLower
      Case "Keyword".ToLower
        Dim tmpFile As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(filID)
        With tmpFile
          .KeyWords = aData(0)
          .StatusOn = Now
        End With
        tmpFile = SIS.xDMS.xDmsFiles.UpdateData(tmpFile)
        re.wrn = True
        re.wmsg = "Keywords Updated"
    End Select
    Return DoDefault(re)
  End Function
  <WebMethod(EnableSession:=True)>
  Public Function getTags(context As String, cnt As String) As String
    Return SIS.DMS.apiTags.selectAutoComplete(context, cnt)
  End Function

  <WebMethod(EnableSession:=True)>
  Public Function SelectedFileDetails(key As String, cmd As String, data As String) As String
    If Not ValidateSession() Then Return SessionExpired()
    Dim re As New resp
    re.key = key
    re.cmd = "SelectedFileDetails"

    Dim fIds As List(Of String) = data.Split(",".ToCharArray).ToList
    Dim fd As New List(Of SIS.xDMS.FileDetails)
    For Each fid As String In fIds
      If fid = "" Then Continue For
      fd.Add(SIS.xDMS.FileDetails.GetFileDetails(fid))
    Next
    'Validate file status to be shared, delete, publish etc
    If re.err Then Return ErrorMessage(re.msg)

    re.data = New JavaScriptSerializer().Serialize(fd)
    re.fdet = True
    Return DoDefault(re)
  End Function

End Class


'Case "Attach Workflow", "Remove Workflow"
'  Dim reqItem As SIS.DMS.UI.apiItem = SIS.DMS.UI.GetItem(Req.Item)
'  If Not dmsUser.IsAdmin Then
'    If dmsUser.CreateFolder = enumQualities.AllAuthorized Then
'      Return ErrorMessage("User permission: Not Allowed.")
'    Else
'      If dmsUser.RenameFolder = enumQualities.NotAllowed Then
'        Return ErrorMessage("User permission: Not Allowed.")
'      Else
'        If reqItem.RenameFolder = enumQualities.NotAllowed Then
'          Return ErrorMessage("Folder Setting: Not Allowed.")
'        Else
'          If reqItem.RenameFolder = enumQualities.CreatorOnly Then
'            If reqItem.CreatedBy <> dmsUser.UserID Then
'              Return ErrorMessage("Folder Setting: By Creater Only.")
'            End If
'          End If
'        End If
'      End If
'    End If
'  End If
'  mRet.strHTML.Add(New JavaScriptSerializer().Serialize(reqItem))
'Case "Publish"
'  Return doPublish(Req)
'Case "Approve / Acknowledge"
'  Dim reqItem As SIS.DMS.UI.apiItem = SIS.DMS.UI.GetItem(Req.Item)
'  mRet.err = False
'  mRet.msg = ""
'  mRet.Target = ""
'  mRet.strHTML.Add(New JavaScriptSerializer().Serialize(reqItem))
'  Return New JavaScriptSerializer().Serialize(mRet)
'Case "Authorize to User"
'  Dim reqItem As SIS.DMS.UI.apiItem = SIS.DMS.UI.GetItem(Req.Item)
'  If Not dmsUser.IsAdmin Then
'    If dmsUser.GrantAuthorization = enumQualities.NotAllowed Then
'      Return ErrorMessage("User permission: Not Allowed.")
'    Else
'      Select Case reqItem.GrantAuthorization
'        Case enumQualities.NotAllowed
'          Return ErrorMessage("Folder Setting: Can not Granted to any other.")
'        Case enumQualities.CreatorOnly
'          If reqItem.CreatedBy <> dmsUser.UserID Then
'            Return ErrorMessage("Folder Setting: Can be Granted by Creater Only.")
'          End If
'      End Select
'    End If
'  End If
'  Return DoDefault(New JavaScriptSerializer().Serialize(reqItem))
'Case "Upload Files", "Upload Ref. Files"
'  Dim mayGo As Boolean = True
'  Try
'    If Req.Item = 0 Then
'      Return ErrorMessage("File can not be uploaded at selected node.")
'    End If
'    Dim reqItem As SIS.DMS.UI.apiItem = SIS.DMS.UI.GetItem(Req.Item)
'    If Not dmsUser.IsAdmin Then
'      If dmsUser.CreateFile = enumQualities.NotAllowed Then
'        Return ErrorMessage("User permission: Not Allowed.")
'      Else
'        Select Case reqItem.CreateFile
'          Case enumQualities.NotAllowed
'            Return ErrorMessage("Folder Setting: Upload File NOT Allowed.")
'          Case enumQualities.CreatorOnly
'            If reqItem.CreatedBy <> dmsUser.UserID Then
'              Return ErrorMessage("Folder Setting: Files can be uploaded by Creater Only.")
'            End If
'        End Select
'        If reqItem.ItemTypeID = enumItemTypes.File Then
'          Dim FxStatus As SIS.DMS.UI.apiStatus = reqItem.Status
'          If FxStatus.Locked Then
'            Return ErrorMessage("File is NOT Updatable.")
'          Else
'            If reqItem.StatusID = enumDMSStates.CheckedOut Then
'              If reqItem.CreatedBy <> dmsUser.UserID Then
'                Return ErrorMessage("File NOT Updatable - checkedout by other user")
'              End If
'            End If
'          End If
'        End If
'      End If
'    End If
'  Catch ex As Exception
'    Return ErrorMessage("Error: During Checking Authorization: " & ex.Message)
'  End Try
'  If mayGo Then
'    Return DoDefault()
'  End If
'Case "Edit", "Edit and Publish"      '"Edit User of Group" discontinued only Delete UserGroupUser is used
'  Dim mayEdit As Boolean = True
'  Dim reqItem As SIS.DMS.UI.apiItem = SIS.DMS.UI.GetItem(Req.Item)
'  Select Case Req.Type
'    Case enumItemTypes.File
'      If Not dmsUser.IsAdmin Then
'        If dmsUser.CreateFile = enumQualities.NotAllowed Then
'          Return ErrorMessage("User permission: Not Allowed.")
'        Else
'          Dim parentFolder As SIS.DMS.UI.apiItem = SIS.DMS.UI.GetParentFolder(reqItem.ItemID)
'          Select Case parentFolder.CreateFile
'            Case enumQualities.NotAllowed
'              Return ErrorMessage("Folder Setting: Editing NOT Allowed.")
'            Case enumQualities.CreatorOnly
'              If reqItem.CreatedBy <> dmsUser.UserID Then
'                Return ErrorMessage("Folder Setting: Can be Edited by Creater Only.")
'              End If
'          End Select
'          Dim FxStatus As SIS.DMS.UI.apiStatus = reqItem.Status()
'          If Not FxStatus.OpenType Then
'            'OpenType Field is Used for IsEditable
'            Return ErrorMessage("File is NOT Updatable.")
'          Else
'            If reqItem.StatusID = enumDMSStates.CheckedOut Then
'              If reqItem.CreatedBy <> dmsUser.UserID Then
'                Return ErrorMessage("File NOT Updatable - checkedout by other user")
'              End If
'            End If
'          End If
'        End If
'      End If
'    Case enumItemTypes.Folder
'      If Not dmsUser.IsAdmin Then
'        If dmsUser.RenameFolder = enumQualities.NotAllowed Then
'          Return ErrorMessage("User permission: Not Allowed.")
'        Else
'          Select Case reqItem.RenameFolder
'            Case enumQualities.NotAllowed
'              Return ErrorMessage("Folder Setting: Editing NOT Allowed.")
'            Case enumQualities.CreatorOnly
'              If reqItem.CreatedBy <> dmsUser.UserID Then
'                Return ErrorMessage("Folder Setting: Can be Edited by Creater Only.")
'              End If
'          End Select
'        End If
'      End If
'    Case Else
'      mayEdit = True
'  End Select
'  If mayEdit Then
'    mRet.err = False
'    mRet.msg = ""
'    mRet.Target = ""
'    mRet.strHTML.Add(New JavaScriptSerializer().Serialize(reqItem))
'    Return New JavaScriptSerializer().Serialize(mRet)
'  End If
'Case "Delete User from Group"
'  Dim reqItem As SIS.DMS.UI.apiItem = SIS.DMS.UI.GetItem(Req.Item)
'  mRet = SIS.DMS.UI.DeleteUserAuthByGroup(reqItem.ParentItemID, reqItem.LinkedItemID)
'  If Not mRet.err Then
'    SIS.DMS.UI.DirectDeleteItem(Req.Item)
'  End If
'  mRet.nofrm = True
'  mRet.okmsg = "Deleted successfully"
'  mRet.Target = Req.Parent
'  Return New JavaScriptSerializer().Serialize(mRet)
'Case "Delete Authorization"
'  Dim reqItem As SIS.DMS.UI.apiItem = SIS.DMS.UI.GetItem(Req.Item)
'  If reqItem.ForwardLinkedItemTypeID = enumItemTypes.Folder AndAlso reqItem.LinkedItemTypeID = enumItemTypes.UserGroup Then
'    mRet = SIS.DMS.UI.DeleteGroupAuth(reqItem.ForwardLinkedItemID, reqItem.LinkedItemID)
'    mRet = SIS.DMS.UI.DeleteMultiItems(reqItem.LinkedItemID, enumMultiTypes.Authorized, reqItem.ForwardLinkedItemTypeID, reqItem.ForwardLinkedItemID)
'  ElseIf reqItem.ForwardLinkedItemTypeID = enumItemTypes.Folder AndAlso reqItem.LinkedItemTypeID = enumItemTypes.User Then
'    mRet = SIS.DMS.UI.DeleteMultiItems(reqItem.LinkedItemID, enumMultiTypes.Authorized, reqItem.ForwardLinkedItemTypeID, reqItem.ForwardLinkedItemID)
'  End If
'  If Not mRet.err Then
'    mRet = SIS.DMS.UI.DeleteMultiItems("", enumMultiTypes.Created, enumItemTypes.Authorization, reqItem.ItemID)
'    If Not mRet.err Then
'      SIS.DMS.UI.DirectDeleteItem(Req.Item)
'    End If
'  End If
'  mRet.nofrm = True
'  mRet.okmsg = "Deleted successfully"
'  mRet.Target = Req.Parent
'Case "Delete"
'  '===============
'  Select Case Req.Type
'    Case enumItemTypes.Searches
'      Try
'        SIS.DMS.dmsSearchData.DeleteLastResults(Req.Item)
'        SIS.DMS.UI.DeleteItem(Req.Type, Req.Item)
'        mRet.err = False
'        mRet.msg = ""
'        mRet.Target = Req.Parent
'        mRet.nofrm = True
'        mRet.okmsg = "Deleted successfully"
'        Return New JavaScriptSerializer().Serialize(mRet)
'      Catch ex As Exception
'        Return ErrorMessage(ex.Message)
'      End Try
'  End Select
'  '==============
'  Dim reqItem As SIS.DMS.UI.apiItem = SIS.DMS.UI.GetItem(Req.Item)
'  Dim pItm As SIS.DMS.UI.apiItem = Nothing
'  If Req.Childs > 0 Then
'    Return ErrorMessage("There are child Items, DELETE child Items first.")
'  End If
'  Dim mayDelete As Boolean = True
'  Select Case Req.Type
'    Case enumItemTypes.UserGroup
'      If reqItem.CreatedBy = dmsUser.UserID Then
'        mayDelete = True
'      Else
'        Return ErrorMessage("Authorized Item: Deletion NOT allowed.")
'      End If
'    Case enumItemTypes.Folder
'      If Not dmsUser.IsAdmin Then
'        If dmsUser.DeleteFolder = enumQualities.NotAllowed Then
'          Return ErrorMessage("User Permission: Deletion NOT allowed.")
'        Else
'          Dim ParentFolder As SIS.DMS.UI.apiItem = SIS.DMS.UI.GetParentFolder(reqItem.ItemID)
'          If ParentFolder.DeleteFolder = enumQualities.NotAllowed Then
'            Return ErrorMessage("Folder Permission: Deletion NOT allowed.")
'          Else
'            If ParentFolder.DeleteFolder = enumQualities.CreatorOnly Then
'              If reqItem.CreatedBy <> dmsUser.UserID Then
'                Return ErrorMessage("Folder Permission: Can be deleted by Creater Only.")
'              End If
'            End If
'          End If
'        End If
'      End If
'    Case Else
'      If Not dmsUser.IsAdmin Then
'        If dmsUser.DeleteFile = enumQualities.NotAllowed Then
'          Return ErrorMessage("User Permission: Deletion NOT allowed.")
'        Else
'          Dim ParentFolder As SIS.DMS.UI.apiItem = SIS.DMS.UI.GetParentFolder(reqItem.ItemID)
'          If ParentFolder.DeleteFile = enumQualities.NotAllowed Then
'            Return ErrorMessage("Folder Permission: Deletion NOT allowed.")
'          Else
'            If ParentFolder.DeleteFile = enumQualities.CreatorOnly Then
'              If reqItem.CreatedBy <> dmsUser.UserID Then
'                Return ErrorMessage("Folder Permission: Can be deleted by Creater Only.")
'              End If
'            End If
'            If reqItem.StatusID <> enumDMSStates.Created Then
'              Return ErrorMessage("Item Status Error: Can NOT be deleted.")
'            End If
'          End If
'        End If
'      End If
'  End Select
'  If mayDelete Then
'    Try
'      SIS.DMS.UI.DeleteItem(Req.Type, Req.Item)
'    Catch ex As Exception
'      Return ErrorMessage(ex.Message)
'    End Try
'    mRet.err = False
'    mRet.msg = ""
'    mRet.Target = Req.Parent
'    mRet.nofrm = True
'    mRet.okmsg = "Deleted successfully"
'    Return New JavaScriptSerializer().Serialize(mRet)
'  End If
'Case "Create"
'  Select Case Req.Type
'    Case enumItemTypes.Folder
'      If dmsUser.IsAdmin Then
'        Return DoDefault()
'      Else
'        If dmsUser.CreateFolder = enumQualities.NotAllowed Then
'          Return ErrorMessage("User permission: Not Allowed.")
'        Else
'          If Req.Base = "Type" Then
'            Return DoDefault()
'          Else
'            Dim tmpTarget As SIS.DMS.UI.apiItem = SIS.DMS.UI.GetItem(Req.Item)
'            Select Case tmpTarget.CreateFolder
'              Case enumQualities.NotAllowed
'                Return ErrorMessage("Folder Setting: Sub folder can not be created.")
'              Case enumQualities.CreatorOnly
'                If tmpTarget.CreatedBy <> dmsUser.UserID Then
'                  Return ErrorMessage("Folder Setting: Sub folder can not be created by any other user.")
'                Else
'                  Return DoDefault()
'                End If
'              Case Else
'                Return DoDefault()
'            End Select
'          End If
'        End If
'      End If
'  End Select
'Case "Extract BOM"
'  Return DoDefault()
