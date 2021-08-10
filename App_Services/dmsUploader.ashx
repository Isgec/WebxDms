
<%@ WebHandler Language="VB" Class="dmsUploader"  %>

Imports System
Imports System.IO
Imports System.Net
Imports System.Web
Imports System.Web.Script.Serialization
Imports ejiVault
Public Class dmsUploader : Implements IHttpHandler, IRequiresSessionState

  Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
    If Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then
      UploadTest(context)
    Else
      UploadLive(context)
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

  Private Sub UploadLive(ByVal context As HttpContext)
    Dim isErr As Boolean = False
    Dim errMsg As String = ""
    If Not ValidateSession() Then
      isErr = True
      errMsg = "Session Expired, Login again."
      GoTo done
    End If
    Dim I As Integer = 0
    Dim fCount As Integer = 0
    Dim fType As String = ""
    Try
      If context.Request.Files.Count > 0 Then
        Dim keyTarget As String = ""
        For Each key As String In context.Request.Form.AllKeys
          If key.IndexOf("file_target") >= 0 Then
            keyTarget = context.Request.Form(key)
          End If
          If key.IndexOf("file_number") >= 0 Then
            fCount = context.Request.Form(key)
          End If
          If key.IndexOf("file_type") >= 0 Then
            fType = context.Request.Form(key)
          End If
        Next
        fCount += 1
        Dim aCon As String() = keyTarget.Split("_".ToCharArray)
        Dim fldID As Integer = aCon(1)

        Dim JS As New System.Web.Script.Serialization.JavaScriptSerializer()


        Dim tmpPath As String = HttpContext.Current.Server.MapPath("~/../App_Temp")
        Dim tmpFilesToDelete As New ArrayList


        If EJI.DBCommon.ConnectLibrary() Then

          For I = 0 To context.Request.Files.Count - 1
            Dim fu As HttpPostedFile = context.Request.Files(I)
            If fu.ContentLength <= 0 Then Continue For
            If fu.FileName = "" Then Continue For
            Dim fileName As String = Path.GetFileName(fu.FileName)
            Dim tmpName As String = IO.Path.GetRandomFileName()
            Dim tmpFile As String = tmpPath & "\\" & tmpName
            fu.SaveAs(tmpFile)
            tmpFilesToDelete.Add(tmpFile)
            Dim dmsFile As New SIS.xDMS.xDmsFiles
            With dmsFile
              .FileName = fileName
              .FileRev = "00"
              .FileSize = fu.ContentLength
              .FileExtn = fu.ContentType ' Path.GetExtension(fu.FileName)
              .FolderID = fldID
              .Hseq = 0
              .ItemTypeID = "File"
              .KeyWords = ""
              .NodeLevel = 0
              .ParentIFileID = ""
              .StatusID = enumStatus.Free
              If dmsFile.FK_xDMS_Files_FolderID.UploadedStatusID <> "" Then
                .StatusID = dmsFile.FK_xDMS_Files_FolderID.UploadedStatusID
              End If
              .StatusBy = xUser.UserID
              .StatusOn = Now
              .StatusRemarks = "Uploaded"
              .VaultDRID = ""
            End With
            dmsFile = SIS.xDMS.xDmsFiles.InsertData(dmsFile)
            Dim vaultFile As EJI.ediAFile = Nothing
            Try
              vaultFile = EJI.ediAFile.UploadFile(dmsFile.AthHandle, dmsFile.AthIndex, tmpFile, xUser.UserID)
            Catch ex As Exception
              SIS.xDMS.xDmsFiles.xDmsFilesDelete(dmsFile)
              isErr = True
              errMsg = "Error: " & ex.Message
              GoTo done
            End Try
            dmsFile.VaultDRID = vaultFile.t_drid
            dmsFile = SIS.xDMS.xDmsFiles.UpdateData(dmsFile)
            vaultFile.t_fnam = fileName
            EJI.ediAFile.UpdateData(vaultFile)
            '========================
            SIS.xDMS.xDmsHFiles.CreateHistory(dmsFile.FileID, "Uploaded", True)
            '==========================
          Next
          For Each t As String In tmpFilesToDelete
            Try
              IO.File.Delete(t)
            Catch ex As Exception

            End Try
          Next
        End If
        EJI.DBCommon.DisconnectLibrary()
      End If
    Catch ex As Exception
      EJI.DBCommon.DisconnectLibrary()
      isErr = True
      errMsg = ex.Message
    End Try
done:
    Dim mStr As String = ""
    If Not isErr Then
      mStr = New JavaScriptSerializer().Serialize(New With {
          .i = fCount,
          .err = False,
          .msg = "Uploaded"
      })
    Else
      mStr = New JavaScriptSerializer().Serialize(New With {
          .err = True,
          .msg = errMsg
      })

    End If
    'context.Response.Clear()
    'context.Response.Headers.Clear()
    context.Response.StatusCode = CInt(HttpStatusCode.OK)
    context.Response.ContentType = "text/json"
    context.Response.Write(mStr)
    context.Response.End()
  End Sub
  Private Sub UploadTest(ByVal context As HttpContext)
    Dim isErr As Boolean = False
    Dim errMsg As String = ""
    If Not ValidateSession() Then
      isErr = True
      errMsg = "Session Expired, Login again."
      GoTo done
    End If
    Dim I As Integer = 0
    Dim fCount As Integer = 0
    Try
      If context.Request.Files.Count > 0 Then
        Dim keyTarget As String = ""
        For Each key As String In context.Request.Form.AllKeys
          If key.IndexOf("file_target") >= 0 Then
            keyTarget = context.Request.Form(key)
          End If
          If key.IndexOf("file_number") >= 0 Then
            fCount = context.Request.Form(key)
          End If
        Next
        fCount += 1
        Dim aCon As String() = keyTarget.Split("_".ToCharArray)
        Dim fldID As Integer = aCon(1)
        Dim JS As New System.Web.Script.Serialization.JavaScriptSerializer()

        Dim folderPath As String = context.Server.MapPath("~/../App_Temp/")
        For I = 0 To context.Request.Files.Count - 1
          Dim fu As HttpPostedFile = context.Request.Files(I)
          Dim fileName As String = Path.GetFileName(fu.FileName)
          If fu.ContentLength > 0 AndAlso fileName <> "" Then
            fu.SaveAs(folderPath + fileName)
            Dim dmsFile As New SIS.xDMS.xDmsFiles
            With dmsFile
              .FileName = fileName
              .FileRev = "00"
              .FileSize = fu.ContentLength
              .FileExtn = Path.GetExtension(fu.FileName)
              .FolderID = fldID
              .Hseq = 0
              .ItemTypeID = "File"
              .KeyWords = ""
              .NodeLevel = 0
              .ParentIFileID = ""
              .StatusID = enumStatus.Free
              .StatusBy = xUser.UserID
              .StatusOn = Now
              .StatusRemarks = "Uploaded"
              .VaultDRID = ""
            End With
            dmsFile = SIS.xDMS.xDmsFiles.InsertData(dmsFile)
          End If
        Next
      End If
    Catch ex As Exception
      isErr = True
      errMsg = ex.Message
    End Try
done:
    Dim mStr As String = ""
    If Not isErr Then
      mStr = New JavaScriptSerializer().Serialize(New With {
          .i = fCount,
          .err = False,
          .msg = "Uploaded"
      })
    Else
      mStr = New JavaScriptSerializer().Serialize(New With {
          .err = True,
          .msg = errMsg
      })
    End If
    context.Response.StatusCode = CInt(HttpStatusCode.OK)
    context.Response.ContentType = "text/json"
    context.Response.Write(mStr)
    context.Response.End()
  End Sub
  Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
    Get
      Return False
    End Get
  End Property

End Class
