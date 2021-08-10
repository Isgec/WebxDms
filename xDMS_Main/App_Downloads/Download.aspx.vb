Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.Script.Serialization
Imports Ionic
Imports Ionic.Zip
Imports ejiVault
Partial Class Download
  Inherits System.Web.UI.Page
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    If Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then
      Try
        If Request.QueryString("id") IsNot Nothing Then
          TestDownloadFile(Request.QueryString("id"))
        End If
        If Request.QueryString("zip") IsNot Nothing Then
          TestDownloadZip(Request.QueryString("zip"))
        End If
      Catch ex As Exception
      End Try
    Else
      Try
        If Request.QueryString("id") IsNot Nothing Then
          DownloadFile(Request.QueryString("id"))
        End If
        If Request.QueryString("zip") IsNot Nothing Then
          DownloadZip(Request.QueryString("zip"))
        End If
      Catch ex As Exception
      End Try
    End If
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
  Private Sub DownloadZip(SNs As String)
    Dim aSN() As String = SNs.Split(",".ToCharArray)
    Dim FileID As String = aSN(0)
    Dim dmsFile As SIS.xDMS.xDmsFiles = Nothing
    'SIS.xDMS.xDmsFiles.xDmsFilesGetByID(FileID)

    Dim re As resp = Nothing
    're = New resp
    're = ValidateFolder(dmsFile.FolderID)
    'If Not re.err Then
    '  For Each sn As String In aSN
    '    re = ValidateFile(sn)
    '    If re.err Then
    '      Exit For
    '    End If
    '  Next
    'End If
    'If Not re.err Then
    Dim dridS As List(Of SIS.DMS.vaultFile) = SIS.xDMS.xDmsFiles.GetVaultDRIDs(SNs)
    Dim Found As Boolean = False
    Using zip As New ZipFile

      zip.CompressionLevel = Zlib.CompressionLevel.Level5
      Dim LibraryID As String = ""
      For Each vf As SIS.DMS.vaultFile In dridS

        dmsFile = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(vf.FileID)
        re = New resp
        re = ValidateFolder(dmsFile.FolderID)
        If Not re.err Then
          re = ValidateFile(vf.FileID)
          If re.err Then
            Continue For
          End If
        Else
          Continue For
        End If
        Dim rDoc As EJI.ediAFile = Nothing
        If dmsFile.StatusRemarks = "Migrated" Then
          rDoc = EJI.ediAFile.GetFileByFileID(vf.DRID)
        Else
          rDoc = EJI.ediAFile.GetFileByRecordID(vf.DRID)
        End If
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
        Dim cDmsFiles As List(Of SIS.xDMS.xDmsFiles) = SIS.xDMS.xDmsFiles.UZ_xDmsRefFilesSelectList(0, 9999, "", vf.FileID)
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
    'End If
    'If re IsNot Nothing Then
    '  If re.err Then
    '    Response.Clear()
    '    Response.Write(re.msg)
    '  End If
    'End If
    HttpContext.Current.Server.ScriptTimeout = st
    Response.End()
  End Sub


  Private Sub DownloadFile(ByVal fileID As String)
    Response.Clear()
    Dim re As resp = Nothing
    Try
      Dim dmsFile As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(fileID)
      Dim cDmsFiles As List(Of SIS.xDMS.xDmsFiles) = SIS.xDMS.xDmsFiles.UZ_xDmsRefFilesSelectList(0, 9999, "", fileID)
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

            dmsFile = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(fileID)
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

  Private Sub TestDownloadZip(SNs As String)
    Dim aSNs() As String = SNs.Split(",".ToCharArray)
    Dim Found As Boolean = False
    Dim tmpPath As String = HttpContext.Current.Server.MapPath("~/../App_Temp")
    Using zip As New ZipFile
      zip.CompressionLevel = Zlib.CompressionLevel.Level5
      For Each sn As String In aSNs
        Dim fl As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(sn)
        If fl IsNot Nothing Then
          Dim PathFile As String = tmpPath & "\" & fl.FileName
          If IO.File.Exists(PathFile) Then
            Try
              zip.AddFile(PathFile, "Files").FileName = fl.FileName
              Found = True
            Catch ex As Exception
            End Try
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
    End Using
    Response.End()
    HttpContext.Current.Server.ScriptTimeout = st
  End Sub

  Private Sub TestDownloadFile(ByVal Value As String)
    Response.Clear()
    Try
      Dim dmsFile As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(Value)
      Dim tmpPath As String = HttpContext.Current.Server.MapPath("~/../App_Temp")
      Dim PathFile As String = tmpPath & "\" & dmsFile.FileName
      If IO.File.Exists(PathFile) Then
        Response.AppendHeader("content-disposition", "attachment; filename=" & dmsFile.FileName)
        Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(dmsFile.FileName)
        Response.WriteFile(PathFile)
        HttpContext.Current.Server.ScriptTimeout = st
      End If
    Catch ex As Exception
      Response.Write(ex.Message)
    End Try
    HttpContext.Current.Server.ScriptTimeout = st
    Response.End()
  End Sub


End Class
