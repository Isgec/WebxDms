Partial Class AF_xDmsGroupFolders
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsGroupFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsGroupFolders.Init
    DataClassName = "AxDmsGroupFolders"
    SetFormView = FVxDmsGroupFolders
  End Sub
  Protected Sub TBLxDmsGroupFolders_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsGroupFolders.Init
    SetToolBar = TBLxDmsGroupFolders
  End Sub
  Protected Sub FVxDmsGroupFolders_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsGroupFolders.DataBound
    SIS.xDMS.xDmsGroupFolders.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsGroupFolders_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsGroupFolders.PreRender
    Dim oF_GroupID_Display As Label  = FVxDmsGroupFolders.FindControl("F_GroupID_Display")
    oF_GroupID_Display.Text = String.Empty
    If Not Session("F_GroupID_Display") Is Nothing Then
      If Session("F_GroupID_Display") <> String.Empty Then
        oF_GroupID_Display.Text = Session("F_GroupID_Display")
      End If
    End If
    Dim oF_GroupID As TextBox  = FVxDmsGroupFolders.FindControl("F_GroupID")
    oF_GroupID.Enabled = True
    oF_GroupID.Text = String.Empty
    If Not Session("F_GroupID") Is Nothing Then
      If Session("F_GroupID") <> String.Empty Then
        oF_GroupID.Text = Session("F_GroupID")
      End If
    End If
    Dim oF_FolderID_Display As Label  = FVxDmsGroupFolders.FindControl("F_FolderID_Display")
    Dim oF_FolderID As TextBox  = FVxDmsGroupFolders.FindControl("F_FolderID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsGroupFolders.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsGroupFolders") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsGroupFolders", mStr)
    End If
    If Request.QueryString("GroupID") IsNot Nothing Then
      CType(FVxDmsGroupFolders.FindControl("F_GroupID"), TextBox).Text = Request.QueryString("GroupID")
      CType(FVxDmsGroupFolders.FindControl("F_GroupID"), TextBox).Enabled = False
    End If
    If Request.QueryString("FolderID") IsNot Nothing Then
      CType(FVxDmsGroupFolders.FindControl("F_FolderID"), TextBox).Text = Request.QueryString("FolderID")
      CType(FVxDmsGroupFolders.FindControl("F_FolderID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function GroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsGroups.SelectxDmsGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function FolderIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFolders.SelectxDmsFoldersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_GroupFolders_FolderID(ByVal value As String) As String
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_GroupFolders_GroupID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim GroupID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsGroups = SIS.xDMS.xDmsGroups.xDmsGroupsGetByID(GroupID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
