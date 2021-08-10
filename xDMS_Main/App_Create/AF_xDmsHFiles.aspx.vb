Partial Class AF_xDmsHFiles
  Inherits SIS.SYS.InsertBase
  Protected Sub FVxDmsHFiles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsHFiles.Init
    DataClassName = "AxDmsHFiles"
    SetFormView = FVxDmsHFiles
  End Sub
  Protected Sub TBLxDmsHFiles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsHFiles.Init
    SetToolBar = TBLxDmsHFiles
  End Sub
  Protected Sub FVxDmsHFiles_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsHFiles.DataBound
    SIS.xDMS.xDmsHFiles.SetDefaultValues(sender, e) 
  End Sub
  Protected Sub FVxDmsHFiles_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles FVxDmsHFiles.PreRender
    Dim oF_ItemTypeID_Display As Label  = FVxDmsHFiles.FindControl("F_ItemTypeID_Display")
    Dim oF_ItemTypeID As TextBox  = FVxDmsHFiles.FindControl("F_ItemTypeID")
    Dim oF_FolderID_Display As Label  = FVxDmsHFiles.FindControl("F_FolderID_Display")
    Dim oF_FolderID As TextBox  = FVxDmsHFiles.FindControl("F_FolderID")
    Dim oF_StatusID_Display As Label  = FVxDmsHFiles.FindControl("F_StatusID_Display")
    Dim oF_StatusID As TextBox  = FVxDmsHFiles.FindControl("F_StatusID")
    Dim oF_StatusBy_Display As Label  = FVxDmsHFiles.FindControl("F_StatusBy_Display")
    Dim oF_StatusBy As TextBox  = FVxDmsHFiles.FindControl("F_StatusBy")
    Dim oF_FileTypeID_Display As Label  = FVxDmsHFiles.FindControl("F_FileTypeID_Display")
    Dim oF_FileTypeID As TextBox  = FVxDmsHFiles.FindControl("F_FileTypeID")
    Dim oF_WorkflowID_Display As Label  = FVxDmsHFiles.FindControl("F_WorkflowID_Display")
    Dim oF_WorkflowID As TextBox  = FVxDmsHFiles.FindControl("F_WorkflowID")
    Dim oF_WorkflowStepID_Display As Label  = FVxDmsHFiles.FindControl("F_WorkflowStepID_Display")
    Dim oF_WorkflowStepID As TextBox  = FVxDmsHFiles.FindControl("F_WorkflowStepID")
    Dim oF_WorkflowNextStepID_Display As Label  = FVxDmsHFiles.FindControl("F_WorkflowNextStepID_Display")
    Dim oF_WorkflowNextStepID As TextBox  = FVxDmsHFiles.FindControl("F_WorkflowNextStepID")
    Dim oF_UserID_Display As Label  = FVxDmsHFiles.FindControl("F_UserID_Display")
    Dim oF_UserID As TextBox  = FVxDmsHFiles.FindControl("F_UserID")
    Dim oF_GroupID_Display As Label  = FVxDmsHFiles.FindControl("F_GroupID_Display")
    Dim oF_GroupID As TextBox  = FVxDmsHFiles.FindControl("F_GroupID")
    Dim mStr As String = ""
    Dim oTR As IO.StreamReader = New IO.StreamReader(HttpContext.Current.Server.MapPath("~/xDMS_Main/App_Create") & "/AF_xDmsHFiles.js")
    mStr = oTR.ReadToEnd
    oTR.Close()
    oTR.Dispose()
    If Not Page.ClientScript.IsClientScriptBlockRegistered("scriptxDmsHFiles") Then
      Page.ClientScript.RegisterClientScriptBlock(GetType(System.String), "scriptxDmsHFiles", mStr)
    End If
    If Request.QueryString("FileID") IsNot Nothing Then
      CType(FVxDmsHFiles.FindControl("F_FileID"), TextBox).Text = Request.QueryString("FileID")
      CType(FVxDmsHFiles.FindControl("F_FileID"), TextBox).Enabled = False
    End If
    If Request.QueryString("HFileID") IsNot Nothing Then
      CType(FVxDmsHFiles.FindControl("F_HFileID"), TextBox).Text = Request.QueryString("HFileID")
      CType(FVxDmsHFiles.FindControl("F_HFileID"), TextBox).Enabled = False
    End If
  End Sub
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function ItemTypeIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsItemTypes.SelectxDmsItemTypesAutoCompleteList(prefixText, count, contextKey)
  End Function
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
  Public Shared Function StatusByCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function FileTypeIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsFileTypes.SelectxDmsFileTypesAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function WorkflowIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function WorkflowStepIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function WorkflowNextStepIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsWorkflows.SelectxDmsWorkflowsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  <System.Web.Script.Services.ScriptMethod()> _
  Public Shared Function GroupIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.xDMS.xDmsUGroups.SelectxDmsUGroupsAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_HFiles_UserID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim UserID As String = CType(aVal(1),String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(UserID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_HFiles_StatusBy(ByVal value As String) As String
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
  Public Shared Function validate_FK_xDMS_HFiles_FileTypeID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim FileTypeID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsFileTypes = SIS.xDMS.xDmsFileTypes.xDmsFileTypesGetByID(FileTypeID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_HFiles_FolderID(ByVal value As String) As String
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
  Public Shared Function validate_FK_xDMS_HFiles_GroupID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim GroupID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsUGroups = SIS.xDMS.xDmsUGroups.xDmsUGroupsGetByID(GroupID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_HFiles_ItemTypeID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim ItemTypeID As String = CType(aVal(1),String)
    Dim oVar As SIS.xDMS.xDmsItemTypes = SIS.xDMS.xDmsItemTypes.xDmsItemTypesGetByID(ItemTypeID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_HFiles_StatusID(ByVal value As String) As String
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
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_HFiles_WorkflowID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim WorkflowID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(WorkflowID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_HFiles_WorkflowNextStepID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim WorkflowNextStepID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(WorkflowNextStepID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function
  <System.Web.Services.WebMethod()> _
  Public Shared Function validate_FK_xDMS_HFiles_WorkflowStepID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String="0|" & aVal(0)
    Dim WorkflowStepID As Int32 = CType(aVal(1),Int32)
    Dim oVar As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(WorkflowStepID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found." 
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField 
    End If
    Return mRet
  End Function

End Class
