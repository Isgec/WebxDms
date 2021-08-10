Imports System.Web.Script.Serialization
Partial Class EF_FoldersUser
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
      fld.StatusOn = Now.ToString("dd/MM/yyyy")
      fld.StatusBy = HttpContext.Current.Session("LoginID")
      fld.StatusRemarks = "Updated By User"
      fld.KeyWords = x.KeyWords
      fld.FolderName = x.FolderName
      fld = SIS.xDMS.xDmsFolders.UpdateData(fld)


      Dim re As New resp
      re.key = "e_" & IIf(fld.ParentFolderID = "", "0", fld.ParentFolderID)
      re.sload = False
      re.skey = ""
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
