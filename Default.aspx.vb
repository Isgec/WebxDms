Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Services
Imports System.IO
Imports ejiVault
Imports System.Web.Script.Serialization

Partial Class LGDefault
  Inherits System.Web.UI.Page
  Protected Sub cmdDms_Click(sender As Object, e As EventArgs)
    Response.Redirect("~/xDMS_Main/App_Forms/GF_DmsView.aspx")
  End Sub
  Private Sub showDashboard()
    '1.
    TotalFilesCount.InnerText = SIS.xDMS.Dashboard.TotalCount
    '2.
    Dim fcs As List(Of SIS.xDMS.FolderFilseCount) = SIS.xDMS.Dashboard.FolderwiseCount()
    Dim str As String = ""
    For Each fc As SIS.xDMS.FolderFilseCount In fcs
      str &= "<div class='db-row folder-count'><div style='flex-basis:280px;font-size:10px;'>" & fc.xDMS_Folders3_FolderName.Trim & "</div><div style='text-align:center;font-size:10px;'>" & fc.FilesCount & "</div></div>"
    Next
    FolderWiseCount.InnerHtml = str
    '3.
    SIS.xDMS.xDmsFiles.UnderApprovalSelectList(0, 20, "", False, "", 0, 0, 0, 0, "")
    TotalsubmittedFilesCount.InnerText = SIS.xDMS.xDmsFiles.RecordCount
  End Sub
  Private Sub LGDefault_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
    beforelogin.Visible = True
    afterlogin.Visible = False
    divMigrate.Visible = False
    If HttpContext.Current.User.Identity.IsAuthenticated Then
      beforelogin.Visible = False
      afterlogin.Visible = True
      showDashboard()
      If HttpContext.Current.Session("LoginID") = "0340" Then
        divMigrate.Visible = True
      End If
    End If
  End Sub
  Private StatusUser As String = ""
  Private tID As String = ""
  Private Sub cmdMigrate_Click(sender As Object, e As EventArgs) Handles cmdMigrate.Click
    Dim err As Boolean = False
    Dim msg As String = ""
    errmsg.InnerText = ""
    If F_TransmittalID.Text = "" Then
      Dim x As List(Of String) = ToMigrate()
      For Each s As String In x
        If s = "" Then Continue For
        If Left(s, 3) <> "BOI" Then Continue For
        Try
          Migrate(s, F_Forced.Checked)
        Catch ex As Exception
          err = True
          msg &= ex.Message & " UserID: " & StatusUser & " TranID: " & tID & "<br/>"
        End Try
      Next
    Else
      Try
        Migrate(F_TransmittalID.Text, F_Forced.Checked)
      Catch ex As Exception
        err = True
        msg = ex.Message & " UserID: " & StatusUser & " TranID: " & tID
      End Try
      End If
    If err Then
      errmsg.InnerText = msg
      'ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('" & New JavaScriptSerializer().Serialize(msg) & "');", True)
    End If
  End Sub
  Private Sub Migrate(TranID As String, Optional Forced As Boolean = False)
    tID = TranID
    Dim tRecs As List(Of tranData) = tranData.GetTranData(TranID)
    If tRecs.Count = 0 Then Exit Sub
    Dim issued As tranData = tRecs.Find(Function(n) n.Status = "1-Issued")
    'Create Transmittal Main File
    Dim Found As Boolean = True
    Dim mf As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.GetByFilename(issued.description)
    If mf Is Nothing Then
      'Create Project Folders
      SIS.xDMS.cDmsERPMapping.CreateFoldersForTransmittal(issued.ProjectID, "200")
      mf = New SIS.xDMS.xDmsFiles
      Found = False
    Else
      If Not Forced Then Exit Sub
    End If
    'Get Vault File Record
    Dim eF As EJI.ediAFile = SIS.xDMS.xDmsFiles.GetVaultFile(issued.description, issued.IsgecVaultID, issued.TransmittalID)
    If eF Is Nothing Then Exit Sub
    'Get File Info
    Dim fu As IO.FileInfo = New IO.FileInfo(eF.UploadedPathFile)
    If fu Is Nothing Then Exit Sub
    'Get Existing ERP Folder
    Dim erpf As SIS.xDMS.dmisg015 = SIS.xDMS.dmisg015.GetByFLDName(4, issued.ProjectID, issued.FldName, "200")
    If erpf Is Nothing Then Exit Sub
    'Get xDMS Folder 
    Dim fld As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(erpf.t_tfid)
    With mf
      .FileName = issued.description
      .FileRev = "00"
      Try
        .FileSize = fu.Length
      Catch ex As Exception
        .FileSize = 0
      End Try
      .FileExtn = clsMime.GetMimeType("PDF")
      .FolderID = erpf.t_tfid
      .Hseq = 0
      .ItemTypeID = "Tran"
      .KeyWords = "Prj:" & issued.ProjectID & ",Comp:200,EngFunc:" & erpf.t_tfld & ",Tran:" & issued.TransmittalID
      .NodeLevel = 0
      .ParentIFileID = ""
      .StatusID = fld.UploadedStatusID
      .StatusBy = issued.CreatedBy
      .StatusOn = issued.CreatedOn
      .StatusRemarks = "Created"
      .VaultDRID = eF.t_drid
      .ProjectID = issued.ProjectID
      .CompanyID = "200"
    End With
    StatusUser = mf.StatusBy
    If Not Found Then
      mf = SIS.xDMS.xDmsFiles.InsertData(mf)
    Else
      mf = SIS.xDMS.xDmsFiles.UpdateData(mf)
    End If
    'Create Child Files
    For Each tR As tranData In tRecs
      If tR.Status = "1-Issued" Then
        Found = True
        Dim cf As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.GetByFilename(tR.cfl_filename, mf.FileID)
        If cf Is Nothing Then
          cf = New SIS.xDMS.xDmsFiles
          Found = False
        End If
        'Get Vault File Record
        eF = SIS.xDMS.xDmsFiles.GetVaultFile(tR.cfl_filename, tR.cfl_vaultid, tR.TransmittalID & "_" & Path.GetFileNameWithoutExtension(tR.cfl_filename) & "_" & tR.RevisionNo)
        If eF Is Nothing Then Continue For
        'Get File Info
        fu = New IO.FileInfo(eF.UploadedPathFile)
        If fu Is Nothing Then Continue For
        With cf
          .FileName = tR.cfl_filename
          .FileRev = tR.RevisionNo
          Try
            .FileSize = fu.Length
          Catch ex As Exception
            .FileSize = 0
          End Try
          .FileExtn = clsMime.GetMimeType("PDF")
          .FolderID = mf.FolderID
          .Hseq = 0
          .ItemTypeID = "Tran"
          .KeyWords = mf.KeyWords
          .NodeLevel = 0
          .ParentIFileID = mf.FileID
          .StatusID = mf.StatusID
          .StatusBy = issued.CreatedBy
          .StatusOn = issued.CreatedOn
          .StatusRemarks = "Created"
          .VaultDRID = eF.t_drid
          .ProjectID = issued.ProjectID
          .CompanyID = "200"
        End With
        If Not Found Then
          cf = SIS.xDMS.xDmsFiles.InsertData(cf)
        Else
          cf = SIS.xDMS.xDmsFiles.UpdateData(cf)
        End If
      End If
    Next
    CreateHistory(mf.FileID, "Created", True)
    'Issued
    With mf
      mf.StatusID = 8
      .StatusRemarks = "Issued"
    End With
    mf = SIS.xDMS.xDmsFiles.UpdateData(mf)
    Dim Results As List(Of SIS.xDMS.xDmsFiles) = SIS.xDMS.xDmsFiles.UZ_xDmsRefFilesSelectList(0, 9999, "", mf.FileID)
    For Each xF As SIS.xDMS.xDmsFiles In Results
      With xF
        .StatusID = mf.StatusID
        .StatusRemarks = mf.StatusRemarks
      End With
      SIS.xDMS.xDmsFiles.UpdateData(xF)
    Next
    CreateHistory(mf.FileID, "Issued", True)
    'Ack
    Dim Returned As Boolean = True
    Dim ack As tranData = tRecs.Find(Function(n) n.Status = "3-Rtn")
    If ack Is Nothing Then
      Returned = False
      ack = tRecs.Find(Function(n) n.Status = "2-Ack")
    End If
    If ack Is Nothing Then Exit Sub
    If Returned Then
      mf.StatusID = 11 'Returned Closed
      mf.StatusRemarks = "Returned"
    Else
      mf.StatusID = 3
      mf.StatusRemarks = "Acknowledged"
    End If
    mf.StatusBy = ack.CreatedBy
    mf.StatusOn = ack.CreatedOn
    mf.UserRemarks = ack.ActionRemarks
    mf = SIS.xDMS.xDmsFiles.UpdateData(mf)
    For Each xF As SIS.xDMS.xDmsFiles In Results
      With xF
        .StatusID = mf.StatusID
        .StatusBy = mf.StatusBy
        .StatusOn = mf.StatusOn
        .UserRemarks = mf.UserRemarks
        .StatusRemarks = mf.StatusRemarks
      End With
      SIS.xDMS.xDmsFiles.UpdateData(xF)
    Next
    If Returned Then
      CreateHistory(mf.FileID, "Returned", True)
    Else
      CreateHistory(mf.FileID, "Acknowledged", True)
    End If

  End Sub

  Public Shared Function CreateHistory(FileID As Integer, Optional sRem As String = "", Optional purge As Boolean = False) As SIS.xDMS.xDmsHFiles
    Dim MainFile As SIS.xDMS.xDmsHFiles = SIS.xDMS.xDmsFiles.GetFileForHistory(FileID)
    'Create History Record only if NOT Created
    Dim hFil As Integer = SIS.xDMS.xDmsHFiles.GetMatchingHFileID(MainFile)
    If hFil > 0 Then Return Nothing
    Dim Results As List(Of SIS.xDMS.xDmsHFiles) = SIS.xDMS.xDmsFiles.GetChildFilesForHistory(FileID)
    With MainFile
      .SystemRemarks = sRem
      .Purgable = purge
    End With
    MainFile = SIS.xDMS.xDmsHFiles.InsertData(MainFile)
    For Each fl As SIS.xDMS.xDmsHFiles In Results
      With fl
        .HFileID = MainFile.HFileID
        .SystemRemarks = sRem
        .Purgable = purge
      End With
      fl = SIS.xDMS.xDmsHFiles.InsertData(fl)
    Next
    Return MainFile
  End Function
  Public Function ToMigrate() As List(Of String)
    Dim mRet As New List(Of String)
    Dim Sql As String = " select distinct substring(description,20,9) as tmtl from dms_items where  description like '%Transmittal%' "
    Sql = "  select distinct substring(description,20,9) as tmtl from dms_items where  description like '%Transmittal%' and substring(description,20,9) not in (select substring(filename,20,9) from xdms_files where ItemTypeID='Tran' and parentifileid is null) "
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          mRet.Add(Reader("tmtl"))
        End While
        Reader.Close()
      End Using
    End Using
    Return mRet
  End Function

End Class
Public Class tranData
  Public Property TransmittalID As String = ""
  Public Property ProjectID As String = ""
  Public Property ItemID As String = ""
  Public Property description As String = ""
  Public Property Status As String = ""
  Public Property ActionRemarks As String = ""
  Public Property CreatedBy As String = ""
  Public Property CreatedOn As String = ""
  Public Property IsgecVaultID As String = ""
  Public Property parentitemid As String = ""
  Public Property FldName As String = ""
  Public Property cfl_itemid As String = ""
  Public Property cfl_Parentitemid As String = ""
  Public Property cfl_filename As String = ""
  Public Property RevisionNo As String = ""
  Public Property cfl_vaultid As String = ""

  Public Shared Function GetTranData(TranID As String) As List(Of tranData)
    Dim mRet As New List(Of tranData)
    Dim Sql As String = ""
    Sql &= " SELECT substring(ih.description,20,9) as TransmittalID "
    Sql &= " ,substring(ih.description,1,6) as ProjectID "
    Sql &= " ,ih.ItemID,ih.description,  "
    Sql &= " Case ih.statusid when 16 then '1-Issued' when 15 then '2-Ack' when 1 then '3-Ret' end as Status, "
    Sql &= " ih.ActionRemarks, "
    Sql &= " ih.CreatedBy, ih.CreatedOn, ih.IsgecVaultID, ih.parentitemid "
    Sql &= " ,fld.description as FldName "
    Sql &= " ,cfl.ItemID as cfl_itemid "
    Sql &= " ,cfl.ParentItemID as cfl_Parentitemid "
    Sql &= " ,cfl.description as cfl_filename "
    Sql &= " ,cfl.RevisionNo  "
    Sql &= " ,cfl.IsgecVaultID as cfl_vaultid "
    Sql &= " FROM DMS_History as ih "
    Sql &= " inner join dms_items as fld on ih.parentitemid=fld.itemid "
    Sql &= " inner join dms_items as cfl on cfl.ParentItemID = ih.itemid "
    Sql &= " where  ih.description like '%Transmittal%'  "
    Sql &= " and substring(ih.description,20,9)='" & TranID & "'"
    Sql &= " order by ih.itemid,status, cfl.ItemID "
    Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
      Using Cmd As SqlCommand = Con.CreateCommand()
        Cmd.CommandType = CommandType.Text
        Cmd.CommandText = Sql
        Con.Open()
        Dim Reader As SqlDataReader = Cmd.ExecuteReader()
        While (Reader.Read())
          mRet.Add(New tranData(Reader))
        End While
        Reader.Close()
      End Using
    End Using
    Return mRet

  End Function
  Sub New()

  End Sub
  Sub New(rd As SqlDataReader)
    SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, rd)
  End Sub
End Class
Class clsMime
  Private Shared _mappings As IDictionary(Of String, String) = New Dictionary(Of String, String)(StringComparer.InvariantCultureIgnoreCase) From {
        {".323", "text/h323"},
        {".3g2", "video/3gpp2"},
        {".3gp", "video/3gpp"},
        {".3gp2", "video/3gpp2"},
        {".3gpp", "video/3gpp"},
        {".7z", "application/x-7z-compressed"},
        {".aa", "audio/audible"},
        {".AAC", "audio/aac"},
        {".aaf", "application/octet-stream"},
        {".aax", "audio/vnd.audible.aax"},
        {".ac3", "audio/ac3"},
        {".aca", "application/octet-stream"},
        {".accda", "application/msaccess.addin"},
        {".accdb", "application/msaccess"},
        {".accdc", "application/msaccess.cab"},
        {".accde", "application/msaccess"},
        {".accdr", "application/msaccess.runtime"},
        {".accdt", "application/msaccess"},
        {".accdw", "application/msaccess.webapplication"},
        {".accft", "application/msaccess.ftemplate"},
        {".acx", "application/internet-property-stream"},
        {".AddIn", "text/xml"},
        {".ade", "application/msaccess"},
        {".adobebridge", "application/x-bridge-url"},
        {".adp", "application/msaccess"},
        {".ADT", "audio/vnd.dlna.adts"},
        {".ADTS", "audio/aac"},
        {".afm", "application/octet-stream"},
        {".ai", "application/postscript"},
        {".aif", "audio/x-aiff"},
        {".aifc", "audio/aiff"},
        {".aiff", "audio/aiff"},
        {".air", "application/vnd.adobe.air-application-installer-package+zip"},
        {".amc", "application/x-mpeg"},
        {".application", "application/x-ms-application"},
        {".art", "image/x-jg"},
        {".asa", "application/xml"},
        {".asax", "application/xml"},
        {".ascx", "application/xml"},
        {".asd", "application/octet-stream"},
        {".asf", "video/x-ms-asf"},
        {".ashx", "application/xml"},
        {".asi", "application/octet-stream"},
        {".asm", "text/plain"},
        {".asmx", "application/xml"},
        {".aspx", "application/xml"},
        {".asr", "video/x-ms-asf"},
        {".asx", "video/x-ms-asf"},
        {".atom", "application/atom+xml"},
        {".au", "audio/basic"},
        {".avi", "video/x-msvideo"},
        {".axs", "application/olescript"},
        {".bas", "text/plain"},
        {".bcpio", "application/x-bcpio"},
        {".bin", "application/octet-stream"},
        {".bmp", "image/bmp"},
        {".c", "text/plain"},
        {".cab", "application/octet-stream"},
        {".caf", "audio/x-caf"},
        {".calx", "application/vnd.ms-office.calx"},
        {".cat", "application/vnd.ms-pki.seccat"},
        {".cc", "text/plain"},
        {".cd", "text/plain"},
        {".cdda", "audio/aiff"},
        {".cdf", "application/x-cdf"},
        {".cer", "application/x-x509-ca-cert"},
        {".chm", "application/octet-stream"},
        {".class", "application/x-java-applet"},
        {".clp", "application/x-msclip"},
        {".cmx", "image/x-cmx"},
        {".cnf", "text/plain"},
        {".cod", "image/cis-cod"},
        {".config", "application/xml"},
        {".contact", "text/x-ms-contact"},
        {".coverage", "application/xml"},
        {".cpio", "application/x-cpio"},
        {".cpp", "text/plain"},
        {".crd", "application/x-mscardfile"},
        {".crl", "application/pkix-crl"},
        {".crt", "application/x-x509-ca-cert"},
        {".cs", "text/plain"},
        {".csdproj", "text/plain"},
        {".csh", "application/x-csh"},
        {".csproj", "text/plain"},
        {".css", "text/css"},
        {".csv", "text/csv"},
        {".cur", "application/octet-stream"},
        {".cxx", "text/plain"},
        {".dat", "application/octet-stream"},
        {".datasource", "application/xml"},
        {".dbproj", "text/plain"},
        {".dcr", "application/x-director"},
        {".def", "text/plain"},
        {".deploy", "application/octet-stream"},
        {".der", "application/x-x509-ca-cert"},
        {".dgml", "application/xml"},
        {".dib", "image/bmp"},
        {".dif", "video/x-dv"},
        {".dir", "application/x-director"},
        {".disco", "text/xml"},
        {".dll", "application/x-msdownload"},
        {".dll.config", "text/xml"},
        {".dlm", "text/dlm"},
        {".doc", "application/msword"},
        {".docm", "application/vnd.ms-word.document.macroEnabled.12"},
        {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"},
        {".dot", "application/msword"},
        {".dotm", "application/vnd.ms-word.template.macroEnabled.12"},
        {".dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template"},
        {".dsp", "application/octet-stream"},
        {".dsw", "text/plain"},
        {".dtd", "text/xml"},
        {".dtsConfig", "text/xml"},
        {".dv", "video/x-dv"},
        {".dvi", "application/x-dvi"},
        {".dwf", "drawing/x-dwf"},
        {".dwp", "application/octet-stream"},
        {".dxr", "application/x-director"},
        {".eml", "message/rfc822"},
        {".emz", "application/octet-stream"},
        {".eot", "application/octet-stream"},
        {".eps", "application/postscript"},
        {".etl", "application/etl"},
        {".etx", "text/x-setext"},
        {".evy", "application/envoy"},
        {".exe", "application/octet-stream"},
        {".exe.config", "text/xml"},
        {".fdf", "application/vnd.fdf"},
        {".fif", "application/fractals"},
        {".filters", "Application/xml"},
        {".fla", "application/octet-stream"},
        {".flr", "x-world/x-vrml"},
        {".flv", "video/x-flv"},
        {".fsscript", "application/fsharp-script"},
        {".fsx", "application/fsharp-script"},
        {".generictest", "application/xml"},
        {".gif", "image/gif"},
        {".group", "text/x-ms-group"},
        {".gsm", "audio/x-gsm"},
        {".gtar", "application/x-gtar"},
        {".gz", "application/x-gzip"},
        {".h", "text/plain"},
        {".hdf", "application/x-hdf"},
        {".hdml", "text/x-hdml"},
        {".hhc", "application/x-oleobject"},
        {".hhk", "application/octet-stream"},
        {".hhp", "application/octet-stream"},
        {".hlp", "application/winhlp"},
        {".hpp", "text/plain"},
        {".hqx", "application/mac-binhex40"},
        {".hta", "application/hta"},
        {".htc", "text/x-component"},
        {".htm", "text/html"},
        {".html", "text/html"},
        {".htt", "text/webviewhtml"},
        {".hxa", "application/xml"},
        {".hxc", "application/xml"},
        {".hxd", "application/octet-stream"},
        {".hxe", "application/xml"},
        {".hxf", "application/xml"},
        {".hxh", "application/octet-stream"},
        {".hxi", "application/octet-stream"},
        {".hxk", "application/xml"},
        {".hxq", "application/octet-stream"},
        {".hxr", "application/octet-stream"},
        {".hxs", "application/octet-stream"},
        {".hxt", "text/html"},
        {".hxv", "application/xml"},
        {".hxw", "application/octet-stream"},
        {".hxx", "text/plain"},
        {".i", "text/plain"},
        {".ico", "image/x-icon"},
        {".ics", "application/octet-stream"},
        {".idl", "text/plain"},
        {".ief", "image/ief"},
        {".iii", "application/x-iphone"},
        {".inc", "text/plain"},
        {".inf", "application/octet-stream"},
        {".inl", "text/plain"},
        {".ins", "application/x-internet-signup"},
        {".ipa", "application/x-itunes-ipa"},
        {".ipg", "application/x-itunes-ipg"},
        {".ipproj", "text/plain"},
        {".ipsw", "application/x-itunes-ipsw"},
        {".iqy", "text/x-ms-iqy"},
        {".isp", "application/x-internet-signup"},
        {".ite", "application/x-itunes-ite"},
        {".itlp", "application/x-itunes-itlp"},
        {".itms", "application/x-itunes-itms"},
        {".itpc", "application/x-itunes-itpc"},
        {".IVF", "video/x-ivf"},
        {".jar", "application/java-archive"},
        {".java", "application/octet-stream"},
        {".jck", "application/liquidmotion"},
        {".jcz", "application/liquidmotion"},
        {".jfif", "image/pjpeg"},
        {".jnlp", "application/x-java-jnlp-file"},
        {".jpb", "application/octet-stream"},
        {".jpe", "image/jpeg"},
        {".jpeg", "image/jpeg"},
        {".jpg", "image/jpeg"},
        {".js", "application/x-javascript"},
        {".json", "application/json"},
        {".jsx", "text/jscript"},
        {".jsxbin", "text/plain"},
        {".latex", "application/x-latex"},
        {".library-ms", "application/windows-library+xml"},
        {".lit", "application/x-ms-reader"},
        {".loadtest", "application/xml"},
        {".lpk", "application/octet-stream"},
        {".lsf", "video/x-la-asf"},
        {".lst", "text/plain"},
        {".lsx", "video/x-la-asf"},
        {".lzh", "application/octet-stream"},
        {".m13", "application/x-msmediaview"},
        {".m14", "application/x-msmediaview"},
        {".m1v", "video/mpeg"},
        {".m2t", "video/vnd.dlna.mpeg-tts"},
        {".m2ts", "video/vnd.dlna.mpeg-tts"},
        {".m2v", "video/mpeg"},
        {".m3u", "audio/x-mpegurl"},
        {".m3u8", "audio/x-mpegurl"},
        {".m4a", "audio/m4a"},
        {".m4b", "audio/m4b"},
        {".m4p", "audio/m4p"},
        {".m4r", "audio/x-m4r"},
        {".m4v", "video/x-m4v"},
        {".mac", "image/x-macpaint"},
        {".mak", "text/plain"},
        {".man", "application/x-troff-man"},
        {".manifest", "application/x-ms-manifest"},
        {".map", "text/plain"},
        {".master", "application/xml"},
        {".mda", "application/msaccess"},
        {".mdb", "application/x-msaccess"},
        {".mde", "application/msaccess"},
        {".mdp", "application/octet-stream"},
        {".me", "application/x-troff-me"},
        {".mfp", "application/x-shockwave-flash"},
        {".mht", "message/rfc822"},
        {".mhtml", "message/rfc822"},
        {".mid", "audio/mid"},
        {".midi", "audio/mid"},
        {".mix", "application/octet-stream"},
        {".mk", "text/plain"},
        {".mmf", "application/x-smaf"},
        {".mno", "text/xml"},
        {".mny", "application/x-msmoney"},
        {".mod", "video/mpeg"},
        {".mov", "video/quicktime"},
        {".movie", "video/x-sgi-movie"},
        {".mp2", "video/mpeg"},
        {".mp2v", "video/mpeg"},
        {".mp3", "audio/mpeg"},
        {".mp4", "video/mp4"},
        {".mp4v", "video/mp4"},
        {".mpa", "video/mpeg"},
        {".mpe", "video/mpeg"},
        {".mpeg", "video/mpeg"},
        {".mpf", "application/vnd.ms-mediapackage"},
        {".mpg", "video/mpeg"},
        {".mpp", "application/vnd.ms-project"},
        {".mpv2", "video/mpeg"},
        {".mqv", "video/quicktime"},
        {".ms", "application/x-troff-ms"},
        {".msi", "application/octet-stream"},
        {".mso", "application/octet-stream"},
        {".mts", "video/vnd.dlna.mpeg-tts"},
        {".mtx", "application/xml"},
        {".mvb", "application/x-msmediaview"},
        {".mvc", "application/x-miva-compiled"},
        {".mxp", "application/x-mmxp"},
        {".nc", "application/x-netcdf"},
        {".nsc", "video/x-ms-asf"},
        {".nws", "message/rfc822"},
        {".ocx", "application/octet-stream"},
        {".oda", "application/oda"},
        {".odc", "text/x-ms-odc"},
        {".odh", "text/plain"},
        {".odl", "text/plain"},
        {".odp", "application/vnd.oasis.opendocument.presentation"},
        {".ods", "application/oleobject"},
        {".odt", "application/vnd.oasis.opendocument.text"},
        {".one", "application/onenote"},
        {".onea", "application/onenote"},
        {".onepkg", "application/onenote"},
        {".onetmp", "application/onenote"},
        {".onetoc", "application/onenote"},
        {".onetoc2", "application/onenote"},
        {".orderedtest", "application/xml"},
        {".osdx", "application/opensearchdescription+xml"},
        {".p10", "application/pkcs10"},
        {".p12", "application/x-pkcs12"},
        {".p7b", "application/x-pkcs7-certificates"},
        {".p7c", "application/pkcs7-mime"},
        {".p7m", "application/pkcs7-mime"},
        {".p7r", "application/x-pkcs7-certreqresp"},
        {".p7s", "application/pkcs7-signature"},
        {".pbm", "image/x-portable-bitmap"},
        {".pcast", "application/x-podcast"},
        {".pct", "image/pict"},
        {".pcx", "application/octet-stream"},
        {".pcz", "application/octet-stream"},
        {".pdf", "application/pdf"},
        {".pfb", "application/octet-stream"},
        {".pfm", "application/octet-stream"},
        {".pfx", "application/x-pkcs12"},
        {".pgm", "image/x-portable-graymap"},
        {".pic", "image/pict"},
        {".pict", "image/pict"},
        {".pkgdef", "text/plain"},
        {".pkgundef", "text/plain"},
        {".pko", "application/vnd.ms-pki.pko"},
        {".pls", "audio/scpls"},
        {".pma", "application/x-perfmon"},
        {".pmc", "application/x-perfmon"},
        {".pml", "application/x-perfmon"},
        {".pmr", "application/x-perfmon"},
        {".pmw", "application/x-perfmon"},
        {".png", "image/png"},
        {".pnm", "image/x-portable-anymap"},
        {".pnt", "image/x-macpaint"},
        {".pntg", "image/x-macpaint"},
        {".pnz", "image/png"},
        {".pot", "application/vnd.ms-powerpoint"},
        {".potm", "application/vnd.ms-powerpoint.template.macroEnabled.12"},
        {".potx", "application/vnd.openxmlformats-officedocument.presentationml.template"},
        {".ppa", "application/vnd.ms-powerpoint"},
        {".ppam", "application/vnd.ms-powerpoint.addin.macroEnabled.12"},
        {".ppm", "image/x-portable-pixmap"},
        {".pps", "application/vnd.ms-powerpoint"},
        {".ppsm", "application/vnd.ms-powerpoint.slideshow.macroEnabled.12"},
        {".ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow"},
        {".ppt", "application/vnd.ms-powerpoint"},
        {".pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12"},
        {".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation"},
        {".prf", "application/pics-rules"},
        {".prm", "application/octet-stream"},
        {".prx", "application/octet-stream"},
        {".ps", "application/postscript"},
        {".psc1", "application/PowerShell"},
        {".psd", "application/octet-stream"},
        {".psess", "application/xml"},
        {".psm", "application/octet-stream"},
        {".psp", "application/octet-stream"},
        {".pub", "application/x-mspublisher"},
        {".pwz", "application/vnd.ms-powerpoint"},
        {".qht", "text/x-html-insertion"},
        {".qhtm", "text/x-html-insertion"},
        {".qt", "video/quicktime"},
        {".qti", "image/x-quicktime"},
        {".qtif", "image/x-quicktime"},
        {".qtl", "application/x-quicktimeplayer"},
        {".qxd", "application/octet-stream"},
        {".ra", "audio/x-pn-realaudio"},
        {".ram", "audio/x-pn-realaudio"},
        {".rar", "application/octet-stream"},
        {".ras", "image/x-cmu-raster"},
        {".rat", "application/rat-file"},
        {".rc", "text/plain"},
        {".rc2", "text/plain"},
        {".rct", "text/plain"},
        {".rdlc", "application/xml"},
        {".resx", "application/xml"},
        {".rf", "image/vnd.rn-realflash"},
        {".rgb", "image/x-rgb"},
        {".rgs", "text/plain"},
        {".rm", "application/vnd.rn-realmedia"},
        {".rmi", "audio/mid"},
        {".rmp", "application/vnd.rn-rn_music_package"},
        {".roff", "application/x-troff"},
        {".rpm", "audio/x-pn-realaudio-plugin"},
        {".rqy", "text/x-ms-rqy"},
        {".rtf", "application/rtf"},
        {".rtx", "text/richtext"},
        {".ruleset", "application/xml"},
        {".s", "text/plain"},
        {".safariextz", "application/x-safari-safariextz"},
        {".scd", "application/x-msschedule"},
        {".sct", "text/scriptlet"},
        {".sd2", "audio/x-sd2"},
        {".sdp", "application/sdp"},
        {".sea", "application/octet-stream"},
        {".searchConnector-ms", "application/windows-search-connector+xml"},
        {".setpay", "application/set-payment-initiation"},
        {".setreg", "application/set-registration-initiation"},
        {".settings", "application/xml"},
        {".sgimb", "application/x-sgimb"},
        {".sgml", "text/sgml"},
        {".sh", "application/x-sh"},
        {".shar", "application/x-shar"},
        {".shtml", "text/html"},
        {".sit", "application/x-stuffit"},
        {".sitemap", "application/xml"},
        {".skin", "application/xml"},
        {".sldm", "application/vnd.ms-powerpoint.slide.macroEnabled.12"},
        {".sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide"},
        {".slk", "application/vnd.ms-excel"},
        {".sln", "text/plain"},
        {".slupkg-ms", "application/x-ms-license"},
        {".smd", "audio/x-smd"},
        {".smi", "application/octet-stream"},
        {".smx", "audio/x-smd"},
        {".smz", "audio/x-smd"},
        {".snd", "audio/basic"},
        {".snippet", "application/xml"},
        {".snp", "application/octet-stream"},
        {".sol", "text/plain"},
        {".sor", "text/plain"},
        {".spc", "application/x-pkcs7-certificates"},
        {".spl", "application/futuresplash"},
        {".src", "application/x-wais-source"},
        {".srf", "text/plain"},
        {".SSISDeploymentManifest", "text/xml"},
        {".ssm", "application/streamingmedia"},
        {".sst", "application/vnd.ms-pki.certstore"},
        {".stl", "application/vnd.ms-pki.stl"},
        {".sv4cpio", "application/x-sv4cpio"},
        {".sv4crc", "application/x-sv4crc"},
        {".svc", "application/xml"},
        {".swf", "application/x-shockwave-flash"},
        {".t", "application/x-troff"},
        {".tar", "application/x-tar"},
        {".tcl", "application/x-tcl"},
        {".testrunconfig", "application/xml"},
        {".testsettings", "application/xml"},
        {".tex", "application/x-tex"},
        {".texi", "application/x-texinfo"},
        {".texinfo", "application/x-texinfo"},
        {".tgz", "application/x-compressed"},
        {".thmx", "application/vnd.ms-officetheme"},
        {".thn", "application/octet-stream"},
        {".tif", "image/tiff"},
        {".tiff", "image/tiff"},
        {".tlh", "text/plain"},
        {".tli", "text/plain"},
        {".toc", "application/octet-stream"},
        {".tr", "application/x-troff"},
        {".trm", "application/x-msterminal"},
        {".trx", "application/xml"},
        {".ts", "video/vnd.dlna.mpeg-tts"},
        {".tsv", "text/tab-separated-values"},
        {".ttf", "application/octet-stream"},
        {".tts", "video/vnd.dlna.mpeg-tts"},
        {".txt", "text/plain"},
        {".u32", "application/octet-stream"},
        {".uls", "text/iuls"},
        {".user", "text/plain"},
        {".ustar", "application/x-ustar"},
        {".vb", "text/plain"},
        {".vbdproj", "text/plain"},
        {".vbk", "video/mpeg"},
        {".vbproj", "text/plain"},
        {".vbs", "text/vbscript"},
        {".vcf", "text/x-vcard"},
        {".vcproj", "Application/xml"},
        {".vcs", "text/plain"},
        {".vcxproj", "Application/xml"},
        {".vddproj", "text/plain"},
        {".vdp", "text/plain"},
        {".vdproj", "text/plain"},
        {".vdx", "application/vnd.ms-visio.viewer"},
        {".vml", "text/xml"},
        {".vscontent", "application/xml"},
        {".vsct", "text/xml"},
        {".vsd", "application/vnd.visio"},
        {".vsi", "application/ms-vsi"},
        {".vsix", "application/vsix"},
        {".vsixlangpack", "text/xml"},
        {".vsixmanifest", "text/xml"},
        {".vsmdi", "application/xml"},
        {".vspscc", "text/plain"},
        {".vss", "application/vnd.visio"},
        {".vsscc", "text/plain"},
        {".vssettings", "text/xml"},
        {".vssscc", "text/plain"},
        {".vst", "application/vnd.visio"},
        {".vstemplate", "text/xml"},
        {".vsto", "application/x-ms-vsto"},
        {".vsw", "application/vnd.visio"},
        {".vsx", "application/vnd.visio"},
        {".vtx", "application/vnd.visio"},
        {".wav", "audio/wav"},
        {".wave", "audio/wav"},
        {".wax", "audio/x-ms-wax"},
        {".wbk", "application/msword"},
        {".wbmp", "image/vnd.wap.wbmp"},
        {".wcm", "application/vnd.ms-works"},
        {".wdb", "application/vnd.ms-works"},
        {".wdp", "image/vnd.ms-photo"},
        {".webarchive", "application/x-safari-webarchive"},
        {".webtest", "application/xml"},
        {".wiq", "application/xml"},
        {".wiz", "application/msword"},
        {".wks", "application/vnd.ms-works"},
        {".WLMP", "application/wlmoviemaker"},
        {".wlpginstall", "application/x-wlpg-detect"},
        {".wlpginstall3", "application/x-wlpg3-detect"},
        {".wm", "video/x-ms-wm"},
        {".wma", "audio/x-ms-wma"},
        {".wmd", "application/x-ms-wmd"},
        {".wmf", "application/x-msmetafile"},
        {".wml", "text/vnd.wap.wml"},
        {".wmlc", "application/vnd.wap.wmlc"},
        {".wmls", "text/vnd.wap.wmlscript"},
        {".wmlsc", "application/vnd.wap.wmlscriptc"},
        {".wmp", "video/x-ms-wmp"},
        {".wmv", "video/x-ms-wmv"},
        {".wmx", "video/x-ms-wmx"},
        {".wmz", "application/x-ms-wmz"},
        {".wpl", "application/vnd.ms-wpl"},
        {".wps", "application/vnd.ms-works"},
        {".wri", "application/x-mswrite"},
        {".wrl", "x-world/x-vrml"},
        {".wrz", "x-world/x-vrml"},
        {".wsc", "text/scriptlet"},
        {".wsdl", "text/xml"},
        {".wvx", "video/x-ms-wvx"},
        {".x", "application/directx"},
        {".xaf", "x-world/x-vrml"},
        {".xaml", "application/xaml+xml"},
        {".xap", "application/x-silverlight-app"},
        {".xbap", "application/x-ms-xbap"},
        {".xbm", "image/x-xbitmap"},
        {".xdr", "text/plain"},
        {".xht", "application/xhtml+xml"},
        {".xhtml", "application/xhtml+xml"},
        {".xla", "application/vnd.ms-excel"},
        {".xlam", "application/vnd.ms-excel.addin.macroEnabled.12"},
        {".xlc", "application/vnd.ms-excel"},
        {".xld", "application/vnd.ms-excel"},
        {".xlk", "application/vnd.ms-excel"},
        {".xll", "application/vnd.ms-excel"},
        {".xlm", "application/vnd.ms-excel"},
        {".xls", "application/vnd.ms-excel"},
        {".xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12"},
        {".xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12"},
        {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
        {".xlt", "application/vnd.ms-excel"},
        {".xltm", "application/vnd.ms-excel.template.macroEnabled.12"},
        {".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template"},
        {".xlw", "application/vnd.ms-excel"},
        {".xml", "text/xml"},
        {".xmta", "application/xml"},
        {".xof", "x-world/x-vrml"},
        {".XOML", "text/plain"},
        {".xpm", "image/x-xpixmap"},
        {".xps", "application/vnd.ms-xpsdocument"},
        {".xrm-ms", "text/xml"},
        {".xsc", "application/xml"},
        {".xsd", "text/xml"},
        {".xsf", "text/xml"},
        {".xsl", "text/xml"},
        {".xslt", "text/xml"},
        {".xsn", "application/octet-stream"},
        {".xss", "application/xml"},
        {".xtp", "application/octet-stream"},
        {".xwd", "image/x-xwindowdump"},
        {".z", "application/x-compress"},
        {".zip", "application/x-zip-compressed"}
    }

  Public Shared Function GetMimeType(ByVal extension As String) As String
    If extension Is Nothing Then
      Throw New ArgumentNullException("extension")
    End If

    If Not extension.StartsWith(".") Then
      extension = "." & extension
    End If

    Dim mime As String = ""
    Return If(_mappings.TryGetValue(extension, mime), mime, "application/octet-stream")
  End Function
End Class