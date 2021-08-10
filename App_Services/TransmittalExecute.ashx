<%@ WebHandler Language="VB" Class="TransmittalExecute" %>

Imports System
Imports System.Web
Imports System.Net
Imports System.Web.Script.Serialization

Public Class TransmittalExecute : Implements IHttpHandler, IRequiresSessionState

  Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
    Dim MainFileID As String = ""
    Dim LoginID As String = ""
    Dim UserID As String = ""
    Dim Comp As String = ""
    Dim Password As String = ""
    For Each key As String In context.Request.Form.AllKeys
      If key.IndexOf("MainFileID") >= 0 Then
        MainFileID = context.Request.Form(key)
      End If
      If key.IndexOf("LoginID") >= 0 Then
        LoginID = context.Request.Form(key)
      End If
      If key.IndexOf("Comp") >= 0 Then
        Comp = context.Request.Form(key)
      End If
      If key.IndexOf("UserID") >= 0 Then
        UserID = context.Request.Form(key)
      End If
      If key.IndexOf("Password") >= 0 Then
        Password = context.Request.Form(key)
      End If
    Next
    Dim re As New SIS.xDMS.TransmittalResp
    If UserID <> "Isgec" Or Password <> "Indian@12345" Then
      re.err = True
      re.msg = "Authentication Failed"
    Else
      Try
        HttpContext.Current.Session("LoginID") = LoginID
        HttpContext.Current.Session("FinanceCompany") = Comp
        SIS.xDMS.xDmsFiles.InitiateWF(MainFileID, True)
      Catch ex As Exception
        re.err = True
        re.msg = ex.Message
      End Try
    End If
    Dim mStr As String = New JavaScriptSerializer().Serialize(re)
    context.Response.StatusCode = CInt(HttpStatusCode.OK)
    context.Response.ContentType = "text/json"
    context.Response.Write(mStr)
  End Sub

  Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
    Get
      Return False
    End Get
  End Property

End Class