Partial Class AF_xDmsFiles
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsFiles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFiles.Init
    DataClassName = "AxDmsFiles"
    SetFormView = FVxDmsFiles
  End Sub
  Protected Sub TBLxDmsFiles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFiles.Init
    SetToolBar = TBLxDmsFiles
  End Sub
  Protected Sub FVxDmsFiles_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFiles.DataBound
    SIS.xDMS.xDmsFiles.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsFiles_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsFiles.PreRender
    Dim oF_FolderID_Display As Label  = FVxDmsFiles.FindControl("F_FolderID_Display")
    oF_FolderID_Display.Text = String.Empty
    If Not Session("F_FolderID_Display") Is Nothing Then
      If Session("F_FolderID_Display") <> String.Empty Then
        oF_FolderID_Display.Text = Session("F_FolderID_Display")
      End If
    End If
    Dim oF_FolderID As TextBox  = FVxDmsFiles.FindControl("F_FolderID")
    oF_FolderID.Enabled = True
    oF_FolderID.Text = String.Empty
    If Not Session("F_FolderID") Is Nothing Then
      If Session("F_FolderID") <> String.Empty Then
        oF_FolderID.Text = Session("F_FolderID")
      End If
    End If
    Dim oF_StatusID_Display As Label  = FVxDmsFiles.FindControl("F_StatusID_Display")
    oF_StatusID_Display.Text = String.Empty
    If Not Session("F_StatusID_Display") Is Nothing Then
      If Session("F_StatusID_Display") <> String.Empty Then
        oF_StatusID_Display.Text = Session("F_StatusID_Display")
      End If
    End If
    Dim oF_StatusID As TextBox  = FVxDmsFiles.FindControl("F_StatusID")
    oF_StatusID.Enabled = True
    oF_StatusID.Text = String.Empty
    If Not Session("F_StatusID") Is Nothing Then
      If Session("F_StatusID") <> String.Empty Then
        oF_StatusID.Text = Session("F_StatusID")
      End If
    End If
    Dim oF_ParentIFileID_Display As Label  = FVxDmsFiles.FindControl("F_ParentIFileID_Display")
    oF_ParentIFileID_Display.Text = String.Empty
    If Not Session("F_ParentIFileID_Display") Is Nothing Then
      If Session("F_ParentIFileID_Display") <> String.Empty Then
        oF_ParentIFileID_Display.Text = Session("F_ParentIFileID_Display")
      End If
    End If
    Dim oF_ParentIFileID As TextBox  = FVxDmsFiles.FindControl("F_ParentIFileID")
    oF_ParentIFileID.Enabled = True
    oF_ParentIFileID.Text = String.Empty
    If Not Session("F_ParentIFileID") Is Nothing Then
      If Session("F_ParentIFileID") <> String.Empty Then
        oF_ParentIFileID.Text = Session("F_ParentIFileID")
      End If
    End If
    Dim oF_StatusBy_Display As Label  = FVxDmsFiles.FindControl("F_StatusBy_Display")
    oF_StatusBy_Display.Text = String.Empty
    If Not Session("F_StatusBy_Display") Is Nothing Then
      If Session("F_StatusBy_Display") <> String.Empty Then
        oF_StatusBy_Display.Text = Session("F_StatusBy_Display")
      End If
    End If
    Dim oF_StatusBy As TextBox  = FVxDmsFiles.FindControl("F_StatusBy")
    oF_StatusBy.Enabled = True
    oF_StatusBy.Text = String.Empty
    If Not Session("F_StatusBy") Is Nothing Then
      If Session("F_StatusBy") <> String.Empty Then
        oF_StatusBy.Text = Session("F_StatusBy")
      End If
    End If
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsFiles.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsFiles") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsFiles", mStr)
    End If
    If Request.QueryString("FileID") IsNot Nothing Then
      CType(FVxDmsFiles.FindControl("F_FileID"), TextBox).Text = Request.QueryString("FileID")
      CType(FVxDmsFiles.FindControl("F_FileID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function FolderIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFolders.SelectxDmsFoldersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function StatusIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsStates.SelectxDmsStatesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ParentIFileIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFiles.SelectxDmsFilesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function StatusByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_Files_StatusBy(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim StatusBy As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(StatusBy)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_Files_ParentFileID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ParentIFileID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(ParentIFileID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_Files_FolderID(ByVal value As String) As String
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
  Public Shared Function validate_FK_xDMS_Files_StatusID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim StatusID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsStates = SIS.xDMS.xDmsStates.xDmsStatesGetByID(StatusID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
