Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Script.Serialization
Imports Ionic
Imports Ionic.Zip
Imports ejiVault
Partial Class DownloadHistory
  Inherits System.Web.UI.Page
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Try
      If Request.QueryString("id") IsNot Nothing Then
        If Request.QueryString("hid") IsNot Nothing Then
          DownloadFile(Request.QueryString("id"), Request.QueryString("hid"))
        End If
      End If
    Catch ex As Exception
    End Try
  End Sub
  Private xUser As SIS.xDMS.xDmsUsers = Nothing
  Private Function ValidateSession() As Boolean
    If HttpContext.Current.Session("LoginID") IsNot Nothing Then
      xUser = SIS.xDMS.xDmsUsers.xDmsUsersGetByID(HttpContext.Current.Session("LoginID"))
    End If
    If xUser Is Nothing Then Return False
    Return True
  End Function
  Private Class resp
    Public Property err As Boolean = False
    Public Property msg As String = ""
  End Class
  Private Function ValidateFolder(fldID As Integer) As resp
    If Not ValidateSession() Then Return (New resp With {.err = True, .msg = "Session Expired"})
    Dim Root As Boolean = IIf(fldID = 0, True, False)

    Dim fld As SIS.xDMS.xDmsFolders = Nothing
    If Not Root Then fld = SIS.xDMS.xDmsFolders.GetAuthRootFolder(fldID, xUser.UserID)

    Dim fldUsr As SIS.xDMS.xDmsFolderAuthorizations = Nothing
    If Not Root Then fldUsr = SIS.xDMS.xDmsFolderAuthorizations.xDmsFolderAuthorizationsGetByID(xUser.UserID, fld.FolderID)
    If xUser.IsAdmin Or xUser.IsSAdmin Then
      Return New resp
    End If
    Dim re As New resp
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
  End Function
  Private Function ValidateFile(FileID As Integer) As resp
    If Not ValidateSession() Then Return (New resp With {.err = True, .msg = "Session Expired"})
    If xUser.IsAdmin Or xUser.IsSAdmin Then
      Return New resp
    End If
    Dim tFile As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(FileID)
    Dim filUsr As SIS.xDMS.xDmsFileAuthorizations = SIS.xDMS.xDmsFileAuthorizations.xDmsFileAuthorizationsGetByID(xUser.UserID, FileID)
    Dim re As New resp
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
  End Function

  Private Sub DownloadFile(ByVal fileID As String, HFileID As String)
    Response.Clear()
    Dim re As resp = Nothing
    Try
      Dim dmsFile As SIS.xDMS.xDmsHFiles = SIS.xDMS.xDmsHFiles.xDmsHFilesGetByID(fileID, HFileID)
      Dim cDmsFiles As List(Of SIS.xDMS.xDmsHFiles) = SIS.xDMS.xDmsHFiles.UZ_xDmsRefHFilesSelectList(0, 9999, "", fileID, HFileID)
      re = New resp
      re = ValidateFolder(dmsFile.FolderID)
      If Not re.err Then
        re = ValidateFile(fileID)
      End If
      If Not re.err Then
        If cDmsFiles.Count = 0 Then
          Dim vltFile As EJI.ediAFile = Nothing
          If dmsFile.StatusRemarks = "Migrated" Then
            vltFile = EJI.ediAFile.GetFileByFileID(dmsFile.VaultDRID)
          Else
            vltFile = EJI.ediAFile.GetFileByRecordID(dmsFile.VaultDRID)
          End If
          Dim aLib As EJI.ediALib = EJI.ediALib.GetLibraryByID(vltFile.t_lbcd)
          If EJI.DBCommon.ConnectLibrary(vltFile.t_lbcd) Then
            Dim PathFile As String = aLib.LibraryPath & "\" & vltFile.t_dcid
            Response.AppendHeader("content-disposition", "attachment; filename=" & vltFile.t_fnam)
            Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(vltFile.t_fnam)
            Response.WriteFile(PathFile)
            HttpContext.Current.Server.ScriptTimeout = st
            EJI.DBCommon.DisconnectLibrary()
          End If
        Else
          Dim Found As Boolean = False
          Using zip As New ZipFile

            zip.CompressionLevel = Zlib.CompressionLevel.Level5
            Dim LibraryID As String = ""

            dmsFile = SIS.xDMS.xDmsHFiles.xDmsHFilesGetByID(fileID, HFileID)
            Dim rDoc As EJI.ediAFile = Nothing
            rDoc = EJI.ediAFile.GetFileByRecordID(dmsFile.VaultDRID)
            If rDoc IsNot Nothing Then
              Dim rLib As EJI.ediALib = EJI.ediALib.GetLibraryByID(rDoc.t_lbcd)
              If rLib IsNot Nothing Then
                If LibraryID <> rDoc.t_lbcd Then
                  If Not EJI.DBCommon.IsLocalISGECVault Then
                    EJI.ediALib.ConnectISGECVault(rLib)
                  End If
                  LibraryID = rDoc.t_lbcd
                End If
                Dim filePath As String = rLib.LibraryPath & "\" & rDoc.t_dcid
                If IO.File.Exists(filePath) Then
                  Try
                    zip.AddFile(filePath, "Files").FileName = rDoc.t_fnam
                    Found = True
                  Catch ex As Exception
                  End Try
                End If
              End If
            End If
            'Get Child Files
            For Each dmsFile In cDmsFiles
              rDoc = EJI.ediAFile.GetFileByRecordID(dmsFile.VaultDRID)
              If rDoc IsNot Nothing Then
                Dim rLib As EJI.ediALib = EJI.ediALib.GetLibraryByID(rDoc.t_lbcd)
                If rLib IsNot Nothing Then
                  If LibraryID <> rDoc.t_lbcd Then
                    If Not EJI.DBCommon.IsLocalISGECVault Then
                      EJI.ediALib.ConnectISGECVault(rLib)
                    End If
                    LibraryID = rDoc.t_lbcd
                  End If
                  Dim filePath As String = rLib.LibraryPath & "\" & rDoc.t_dcid
                  If IO.File.Exists(filePath) Then
                    Try
                      zip.AddFile(filePath, dmsFile.ParentIFileID).FileName = dmsFile.ParentIFileID & "\" & rDoc.t_fnam
                      Found = True
                    Catch ex As Exception
                    End Try
                  End If
                End If
              End If
            Next
            If Found Then
              Dim FileName As String = "Download.zip"
              Response.Clear()
              Response.AppendHeader("content-disposition", "attachment; filename=" & FileName)
              Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(FileName)
              zip.Save(Response.OutputStream)
            Else
              Response.Write("File NOT found to download.")
            End If
            If Not EJI.DBCommon.IsLocalISGECVault Then
              EJI.ediALib.DisconnectISGECVault()
            End If
          End Using

        End If

      End If
    Catch ex As Exception
      Response.Write(ex.Message)
    End Try
    If re IsNot Nothing Then
      If re.err Then
        Response.Write(re.msg)
      End If
    End If
    HttpContext.Current.Server.ScriptTimeout = st
    Response.End()
  End Sub

End Class
