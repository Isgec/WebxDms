Imports System.Data.SqlClient
Imports System.Data
Imports ejiVault
Namespace SIS.SYS.Utilities
  Public Class ApplicationSpacific
    Public Shared Sub Initialize()
      With HttpContext.Current
        .Session("ApplicationID") = 107
        .Session("ApplicationDefaultPage") = "~/Default.aspx"
        .Session("FinanceCompany") = "200"
      End With
      EJI.DBCommon.BaaNLive = Convert.ToBoolean(ConfigurationManager.AppSettings("BaaNLive"))
      EJI.DBCommon.JoomlaLive = Convert.ToBoolean(ConfigurationManager.AppSettings("JoomlaLive"))
      EJI.DBCommon.ERPCompany = ConfigurationManager.AppSettings("ERPCompany")
      EJI.DBCommon.IsLocalISGECVault = Convert.ToBoolean(ConfigurationManager.AppSettings("IsLocalISGECVault"))
      EJI.DBCommon.ISGECVaultIP = ConfigurationManager.AppSettings("ISGECVaultIP")
    End Sub
    Public Shared Sub LoggedOut()
      Dim Sql As String = ""
      Sql &= " declare @u nvarchar(8) = '' "
      Sql &= "  select @u = isnull(userid,'') from xdms_logout where userid='" & HttpContext.Current.Session("LoginID") & "' "
      Sql &= " if(@u='') "
      Sql &= " 	insert into xdms_logout (userid,lastlogout) values('" & HttpContext.Current.Session("LoginID") & "',getdate()) "
      Sql &= " else "
      Sql &= " 	update xdms_logout set lastlogout=getdate() where userid=@u "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
    End Sub
    Public Function LastLogout() As DateTime
      Dim mRet As DateTime = Now
      Dim Sql As String = ""
      Sql &= " declare @u nvarchar(8) = '' "
      Sql &= "  select @u = isnull(userid,'') from xdms_logout where userid='" & HttpContext.Current.Session("LoginID") & "' "
      Sql &= " if(@u='') "
      Sql &= " begin "
      Sql &= " 	insert into xdms_logout (userid,lastlogout) values('" & HttpContext.Current.Session("LoginID") & "',getdate()) "
      Sql &= "  select lastlogout from xdms_logout where userid='" & HttpContext.Current.Session("LoginID") & "'"
      Sql &= " end "
      Sql &= " else "
      Sql &= "  select lastlogout from xdms_logout where userid='" & HttpContext.Current.Session("LoginID") & "'"
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          mRet = Cmd.ExecuteScalar
        End Using
      End Using
      Return mRet
    End Function
    Public Shared Function ContentType(ByVal FileName As String) As String
      Dim mRet As String = "application/octet-stream"
      If FileName Is Nothing Then Return mRet
      Dim Extn As String = IO.Path.GetExtension(FileName).ToLower.Replace(".", "")
      Select Case Extn
        Case "pdf", "rtf"
          mRet = "application/" & Extn
        Case "doc", "docx"
          mRet = "application/vnd.ms-works"
        Case "xls", "xlsx"
          mRet = "application/vnd.ms-excel"
        Case "gif", "jpg", "jpeg", "png", "tif", "bmp"
          mRet = "image/" & Extn
        Case "pot", "ppt", "pps", "pptx", "ppsx"
          mRet = "application/vnd.ms-powerpoint"
        Case "htm", "html"
          mRet = "text/HTML"
        Case "txt"
          mRet = "text/plain"
        Case "zip"
          mRet = "application/zip"
        Case "rar", "tar", "tgz"
          mRet = "application/x-compressed"
        Case Else
          mRet = "application/octet-stream"
      End Select
      Return mRet
    End Function
  End Class
End Namespace