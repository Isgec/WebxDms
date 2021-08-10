Imports System.Web.Script.Serialization
Partial Class GF_DmsView
  Inherits SIS.SYS.xGridBaseDMS
  Public Property SelectedFiles As List(Of String)
    Get
      If ViewState("SelectedFiles") IsNot Nothing Then
        Return CType(ViewState("SelectedFiles"), List(Of String))
      End If
      Return New List(Of String)
    End Get
    Set(value As List(Of String))
      ViewState.Add("SelectedFiles", value)
    End Set
  End Property
#Region " INIT Events "
  Protected Sub GVxDmsFiles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles GVxDmsFiles.Init
    DataClassName = "GxDmsFiles"
    SetGridView = GVxDmsFiles
  End Sub
  Protected Sub TBLxDmsFiles_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBLxDmsFiles.Init
    SetToolBar = TBLxDmsFiles
  End Sub
  Partial Class gvBase
    Inherits SIS.SYS.xGridBaseDMS
  End Class
  Private WithEvents gvBaseHFiles As New gvBase
  Private Sub GVxDmsHFiles_Init(sender As Object, e As EventArgs) Handles GVxDmsHFiles.Init
    gvBaseHFiles.DataClassName = "GVxDmsHFiles"
    gvBaseHFiles.SetGridView = GVxDmsHFiles
  End Sub
  Private Sub TBLxDmsHFiles_Init(sender As Object, e As EventArgs) Handles TBLxDmsHFiles.Init
    gvBaseHFiles.SetToolBar = TBLxDmsHFiles
  End Sub

#End Region
#Region " Web Methods "
  <System.Web.Services.WebMethod()>
  <System.Web.Script.Services.ScriptMethod()>
  Public Shared Function UserIDCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()
    Return SIS.QCM.qcmUsers.SelectqcmUsersAutoCompleteList(prefixText, count, contextKey)
  End Function
  <System.Web.Services.WebMethod()>
  Public Shared Function validate_FK_xDMS_Users_UserID(ByVal value As String) As String
    Dim aVal() As String = value.Split(",".ToCharArray)
    Dim mRet As String = "0|" & aVal(0)
    Dim UserID As String = CType(aVal(1), String)
    Dim oVar As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(UserID)
    If oVar Is Nothing Then
      mRet = "1|" & aVal(0) & "|Record not found."
    Else
      mRet = "0|" & aVal(0) & "|" & oVar.DisplayField
    End If
    Return mRet
  End Function


#End Region

#Region " GV-File Row Command "
  Protected Sub GVxDmsFiles_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GVxDmsFiles.RowCommand
    If e.CommandName.ToLower = "ShowRefDoc".ToLower Then
      Try
        Dim pnl As HtmlGenericControl = CType(GVxDmsFiles.Rows(e.CommandArgument).FindControl("divRefFiles"), HtmlGenericControl)
        If pnl.Visible Then
          pnl.Visible = False
          CType(e.CommandSource, Button).Text = "+"
        Else
          Dim FileID As Int32 = GVxDmsFiles.DataKeys(e.CommandArgument).Values("FileID")
          Dim gv As GridView = CType(GVxDmsFiles.Rows(e.CommandArgument).FindControl("GVxDmsRefFiles"), GridView)
          Dim ods As ObjectDataSource = CType(GVxDmsFiles.Rows(e.CommandArgument).FindControl("ODSxDmsRefFiles"), ObjectDataSource)
          ods.SelectParameters("ParentIFileID").DefaultValue = FileID
          gv.DataBind()
          pnl.Visible = True
          CType(e.CommandSource, Button).Text = "-"
        End If
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Revertwf".ToLower Then
      Try
        Dim FileID As Int32 = GVxDmsFiles.DataKeys(e.CommandArgument).Values("FileID")
        SIS.xDMS.xDmsFiles.RevertWF(FileID)
        GVxDmsFiles.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "Deletewf".ToLower Then
      Dim FolderID As Integer = 0
      Try
        FolderID = L_FolderID.Text
      Catch ex As Exception
        FolderID = 0
      End Try
      Try
        Dim FileID As Int32 = GVxDmsFiles.DataKeys(e.CommandArgument).Values("FileID")
        SIS.xDMS.xDmsFiles.DeleteWF(FileID)
        GVxDmsFiles.DataBind()
        'ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.loadItem(" & New JavaScriptSerializer().Serialize("zz_" & FolderID) & ");", True)
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "initiatewf".ToLower Then
      'Forward
      Try
        Dim FileID As Int32 = GVxDmsFiles.DataKeys(e.CommandArgument).Values("FileID")
        SIS.xDMS.xDmsFiles.InitiateWF(FileID)
        GVxDmsFiles.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "select".ToLower Then
      Try
        Dim FileID As Int32 = GVxDmsFiles.DataKeys(e.CommandArgument).Values("FileID")
        L_HFileID.Text = FileID
        GVxDmsHFiles.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If

    If e.CommandName.ToLower = "Checkout".ToLower Then
      'Forward
      Try
        Dim FileID As Int32 = GVxDmsFiles.DataKeys(e.CommandArgument).Values("FileID")
        SIS.xDMS.xDmsFiles.CheckedOut(FileID)
        GVxDmsFiles.DataBind()
        GVxDmsHFiles.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "UndoCheckout".ToLower Then
      'Forward
      Try
        Dim FileID As Int32 = GVxDmsFiles.DataKeys(e.CommandArgument).Values("FileID")
        SIS.xDMS.xDmsFiles.UndoCheckedOut(FileID)
        GVxDmsFiles.DataBind()
        GVxDmsHFiles.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If
    If e.CommandName.ToLower = "KeyWordWF".ToLower Then
      'Handled at client side
    End If
    If e.CommandName.ToLower = "FileSelected".ToLower Then
      Dim FileID As Int32 = GVxDmsFiles.DataKeys(e.CommandArgument).Values("FileID")
      Dim x As List(Of String) = SelectedFileList.Text.Split(",".ToCharArray).ToList
      Dim Found As Boolean = False
      For Each tmp As String In x
        If tmp = FileID.ToString Then
          x.Remove(tmp)
          Found = True
          'CType(e.CommandSource, LinkButton).Text = "<i class='fas fa-toggle-off' style='color:grey;' ></i>"
          Exit For
        End If
      Next
      If Not Found Then
        x.Add(FileID)
        'CType(e.CommandSource, LinkButton).Text = "<i class='fas fa-toggle-on' style='color:green;'></i>"
      End If
      SelectedFileList.Text = String.Join(",", x)
      L_SelectedCount.Text = x.Count - 1
      GVxDmsFiles.DataBind()
    End If
    If e.CommandName.ToLower = "ToggleSelect".ToLower Then
      Try
        Dim x As List(Of String) = SelectedFileList.Text.Split(",".ToCharArray).ToList
        For Each r As GridViewRow In GVxDmsFiles.Rows
          If r.RowType = DataControlRowType.DataRow Then
            Dim y As LinkButton = CType(r.FindControl("cmdSelect"), LinkButton)
            If Not y.Visible Then Continue For
            Dim FileID As Int32 = GVxDmsFiles.DataKeys(r.RowIndex).Values("FileID")
            Dim Found As Boolean = False
            For Each tmp As String In x
              If tmp = FileID.ToString Then
                x.Remove(tmp)
                Found = True
                'y.Text = "<i class='fas fa-toggle-off' style='color:grey;' ></i>"
                Exit For
              End If
            Next
            If Not Found Then
              x.Add(FileID)
              'y.Text = "<i class='fas fa-toggle-on' style='color:green;'></i>"
            End If
          End If
        Next
        SelectedFileList.Text = String.Join(",", x)
        L_SelectedCount.Text = x.Count - 1
        GVxDmsFiles.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If

  End Sub

#End Region
#Region " Ref File Row Command "
  Protected Sub GVxDmsRefFiles_RowCommand(sender As Object, e As GridViewCommandEventArgs)
    If e.CommandName.ToLower = "RefDeletewf".ToLower Then
      Try
        Dim x As GridView = CType(sender, GridView)
        Dim FileID As Int32 = x.DataKeys(e.CommandArgument).Values("FileID")
        SIS.xDMS.xDmsFiles.RefDeleteWF(FileID)
        x.DataBind()
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If

  End Sub

#End Region
#Region " H-File Row Command "
  Private Sub GVxDmsHFiles_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVxDmsHFiles.RowCommand
    If e.CommandName.ToLower = "ShowRefDoc".ToLower Then
      Try
        Dim pnl As HtmlGenericControl = CType(GVxDmsHFiles.Rows(e.CommandArgument).FindControl("divRefHFiles"), HtmlGenericControl)
        If pnl.Visible Then
          pnl.Visible = False
          CType(e.CommandSource, Button).Text = "+"
        Else
          Dim FileID As Int32 = GVxDmsHFiles.DataKeys(e.CommandArgument).Values("FileID")
          Dim HFileID As Int32 = GVxDmsHFiles.DataKeys(e.CommandArgument).Values("HFileID")
          Dim gv As GridView = CType(GVxDmsHFiles.Rows(e.CommandArgument).FindControl("GVxDmsHRefFiles"), GridView)
          Dim ods As ObjectDataSource = CType(GVxDmsHFiles.Rows(e.CommandArgument).FindControl("ODSxDmsHRefFiles"), ObjectDataSource)
          ods.SelectParameters("ParentIFileID").DefaultValue = FileID
          ods.SelectParameters("HFileID").DefaultValue = HFileID
          gv.DataBind()
          pnl.Visible = True
          CType(e.CommandSource, Button).Text = "-"
        End If
      Catch ex As Exception
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
      End Try
    End If

  End Sub

#End Region
  Private Sub cmdFiles_Click(sender As Object, e As EventArgs) Handles cmdFiles.Click
    L_SelectedCount.Text = SelectedFileList.Text.Split(",".ToCharArray).Count - 1
    GVxDmsFiles.DataBind()
    GVxDmsHFiles.DataBind()
  End Sub
  Private Sub cmdHFiles_Click(sender As Object, e As EventArgs) Handles cmdHFiles.Click
    GVxDmsHFiles.DataBind()
  End Sub

#Region " Selected Actions "
  Private Sub DownloadSelected_Click(sender As Object, e As EventArgs) Handles DownloadSelected.Click
    Try
      Dim FileList As String = ""
      Dim SNs As String = ""
      Dim found As Boolean = False
      SNs = SelectedFileList.Text
      If SNs <> "" Then
        Dim script As String = "javascript:window.open('" & HttpContext.Current.Request.Url.Scheme & Uri.SchemeDelimiter & HttpContext.Current.Request.Url.Authority & HttpContext.Current.Request.ApplicationPath & "/xDMS_Main/App_Downloads/download.aspx?zip=" & SNs & "', 'windnzip', 'left=20,top=20,width=100,height=100,toolbar=1,resizable=1,scrollbars=1');"
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", script, True)
      Else
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize("File NOT selected.") & "');", True)
      End If
    Catch ex As Exception
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
    End Try
  End Sub
  Private Sub ForwardSelected_Click(sender As Object, e As EventArgs) Handles ForwardSelected.Click
    Try
      Dim ActionTaken As Boolean = False
      Dim x As List(Of String) = SelectedFileList.Text.Split(",".ToCharArray).ToList
      For Each r As String In x
        If r <> "" Then
          Try
            SIS.xDMS.xDmsFiles.InitiateWF(r)
            ActionTaken = True
          Catch ex As Exception
          End Try
        End If
      Next
      If ActionTaken Then
        GVxDmsFiles.DataBind()
      End If
    Catch ex As Exception
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
    End Try
  End Sub
  Private Sub DeleteSelected_Click(sender As Object, e As EventArgs) Handles DeleteSelected.Click
    Dim mRet As Integer = 0
    Try
      Dim ActionTaken As Boolean = False
      Dim x As List(Of String) = SelectedFileList.Text.Split(",".ToCharArray).ToList
      For Each r As String In x
        If r <> "" Then
          SIS.xDMS.xDmsFiles.DeleteWF(r)
          ActionTaken = True
          mRet += 1
        End If
      Next
      If ActionTaken Then
        SelectedFileList.Text = ""
        L_SelectedCount.Text = "0"
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.takeAction('" & New JavaScriptSerializer().Serialize(New With {.err = False, .wrn = True, .wmsg = mRet & " record(s) deleted."}) & "');", True)
        GVxDmsFiles.DataBind()
      End If
    Catch ex As Exception
      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
    End Try
  End Sub

#End Region
#Region " File Selection "
  Private Sub GVxDmsFiles_RowCreated(sender As Object, e As GridViewRowEventArgs) Handles GVxDmsFiles.RowCreated
    If e.Row.RowType = DataControlRowType.DataRow Then
      Dim rd As LinkButton = CType(e.Row.FindControl("cmdSelect"), LinkButton)
      Dim y As List(Of String) = SelectedFileList.Text.Split(",".ToCharArray).ToList
      For Each tmp As String In y
        If tmp = GVxDmsFiles.DataKeys(e.Row.RowIndex).Value.ToString Then
          rd.Text = "<i class='fas fa-toggle-on' style='color:green;'></i>"
          Exit For
        End If
      Next
    End If
  End Sub
#End Region

  'If e.CommandName.ToLower = "RevertSelected".ToLower Then
  'Dim mRet As Integer = 0
  'Try
  'Dim ActionTaken As Boolean = False
  'For Each r As GridViewRow In GVxDmsFiles.Rows
  'If r.RowType = DataControlRowType.DataRow Then
  'Dim tmp As CheckBox = CType(r.FindControl("chkSelect"), CheckBox)
  'If Not tmp.Visible Then Continue For
  '          If tmp.Checked Then
  'Try
  'Dim FileID As Int32 = GVxDmsFiles.DataKeys(r.RowIndex).Values("FileID")
  '              SIS.xDMS.xDmsFiles.RevertWF(FileID)
  '              ActionTaken = True
  '              mRet += 1
  '            Catch ex As Exception
  '              ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
  '            End Try
  'End If
  'End If
  'Next
  'If ActionTaken Then
  '        GVxDmsFiles.DataBind()
  '        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(mRet & " Record(s) Reverted.") & "');", True)
  '      End If
  'Catch ex As Exception
  '      ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "xdms_script.showAlert('" & New JavaScriptSerializer().Serialize(ex.Message) & "');", True)
  '    End Try
  'End If

End Class
