Partial Class AF_xDmsFGroupFolders
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsFGroupFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFGroupFolders.Init
    DataClassName = "AxDmsFGroupFolders"
    SetFormView = FVxDmsFGroupFolders
  End Sub
  Protected Sub TBLxDmsFGroupFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFGroupFolders.Init
    SetToolBar = TBLxDmsFGroupFolders
  End Sub
  Protected Sub FVxDmsFGroupFolders_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFGroupFolders.DataBound
    SIS.xDMS.xDmsFGroupFolders.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsFGroupFolders_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFGroupFolders.PreRender
    Dim oF_FGroupID_Display As Label  = FVxDmsFGroupFolders.FindControl("F_FGroupID_Display")
    Dim oF_FGroupID As TextBox  = FVxDmsFGroupFolders.FindControl("F_FGroupID")
    Dim oF_FolderID_Display As Label  = FVxDmsFGroupFolders.FindControl("F_FolderID_Display")
    Dim oF_FolderID As TextBox  = FVxDmsFGroupFolders.FindControl("F_FolderID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsFGroupFolders.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsFGroupFolders") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsFGroupFolders", mStr)
    End If
    If Request.QueryString("FGroupID") IsNot Nothing Then
      CType(FVxDmsFGroupFolders.FindControl("F_FGroupID"), TextBox).Text = Request.QueryString("FGroupID")
      CType(FVxDmsFGroupFolders.FindControl("F_FGroupID"), TextBox).Enabled = False
    End If
    If Request.QueryString("FolderID") IsNot Nothing Then
      CType(FVxDmsFGroupFolders.FindControl("F_FolderID"), TextBox).Text = Request.QueryString("FolderID")
      CType(FVxDmsFGroupFolders.FindControl("F_FolderID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function FGroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFGroups.SelectxDmsFGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function FolderIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFolders.SelectxDmsFoldersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_FGroupFolders_FGroupID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim FGroupID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsFGroups = SIS.xDMS.xDmsFGroups.xDmsFGroupsGetByID(FGroupID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_FGroupFolders_FolderID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim FolderID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(FolderID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
