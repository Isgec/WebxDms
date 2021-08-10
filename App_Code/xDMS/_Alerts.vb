Imports System.Xml
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Net.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Text
Namespace SIS.xDMS
  Public Class Alerts
    Public Shared Sub AlertonWFStep(FileID As Integer)
      Dim uFil As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(FileID)
      Dim tmpWF As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(uFil.WorkflowStepID)
      If Not tmpWF.SendAlert Then Exit Sub
      Dim uUsr As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(uFil.StatusBy)

      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")

      Dim ad As MailAddress = Nothing
      Dim aIDs() As String = Nothing
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      With oMsg
        '1.From
        aIDs = uUsr.EMailID.Split(",;".ToCharArray)
        For Each tmp As String In aIDs
          If tmp.Trim <> "" Then
            ad = New MailAddress(tmp.Trim, tmp.Trim)
            If ad IsNot Nothing Then
              .From = ad
              Exit For
            End If
          End If
        Next
        If .From Is Nothing Then
          .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
        End If
        '2. To
        If tmpWF.ToUserID Then
          Dim tmpUsr As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(tmpWF.UserID)
          aIDs = tmpUsr.EMailID.Split(",;".ToCharArray)
          For Each tmp As String In aIDs
            If tmp.Trim <> "" Then
              ad = New MailAddress(tmp.Trim, tmp.Trim)
              If ad IsNot Nothing Then If Not .To.Contains(ad) Then .To.Add(ad)
            End If
          Next
        End If
        If tmpWF.ToGroupID Then
          Dim gus As List(Of SIS.xDMS.xDmsGroupUsers) = SIS.xDMS.xDmsGroupUsers.xDmsGroupUsersSelectList(0, 9999, "", False, "", tmpWF.GroupID)
          For Each gu As SIS.xDMS.xDmsGroupUsers In gus
            Dim tmpUsr As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(gu.UserID)
            aIDs = tmpUsr.EMailID.Split(",;".ToCharArray)
            For Each tmp As String In aIDs
              If tmp.Trim <> "" Then
                ad = New MailAddress(tmp.Trim, tmp.Trim)
                If ad IsNot Nothing Then If Not .To.Contains(ad) Then .To.Add(ad)
              End If
            Next
          Next
        End If
        If tmpWF.ToDefinedAdditional Then
          aIDs = tmpWF.ToAdditional.Split(",;".ToCharArray)
          For Each tmp As String In aIDs
            If tmp.Trim <> "" Then
              ad = New MailAddress(tmp.Trim, tmp.Trim)
              If ad IsNot Nothing Then If Not .To.Contains(ad) Then .To.Add(ad)
            End If
          Next
        End If
        If tmpWF.ToFolderAuthorized Then
          Dim tmpUs As List(Of String) = SIS.xDMS.xDmsFolderAuthorizations.GetAuthorizedUsers(uFil.FolderID)
          For Each tu As String In tmpUs
            Dim tmpUsr As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(tu)
            aIDs = tmpUsr.EMailID.Split(",;".ToCharArray)
            For Each tmp As String In aIDs
              If tmp.Trim <> "" Then
                ad = New MailAddress(tmp.Trim, tmp.Trim)
                If ad IsNot Nothing Then If Not .To.Contains(ad) Then .To.Add(ad)
              End If
            Next
          Next
        End If
        .Subject = "ISGEC DMS Notification: File " & uFil.FK_xDMS_Files_StatusID.StatusName
        .IsBodyHtml = True
        Dim oTbl As New Table
        oTbl.GridLines = GridLines.Both
        oTbl.Width = 900
        oTbl.Style.Add("text-align", "left")
        oTbl.Style.Add("font", "Tahoma")

        Dim oCol As TableCell = Nothing
        Dim oRow As TableRow = Nothing
        '1.
        oRow = New TableRow
        oCol = New TableCell
        oCol.Style.Add("text-align", "center")
        oCol.Font.Size = "14"
        oCol.ColumnSpan = 4
        oCol.Text = "File(s) List"
        oCol.BackColor = System.Drawing.Color.CadetBlue
        oCol.ForeColor = System.Drawing.Color.White
        oCol.Font.Bold = True
        oRow.Cells.Add(oCol)
        oTbl.Rows.Add(oRow)

        oRow = New TableRow

        oCol = New TableCell
        oCol.Text = uFil.FileName
        oCol.Font.Size = "10"
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = uFil.FK_xDMS_Files_StatusBy.UserFullName
        oCol.Font.Size = "10"
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = uFil.FK_xDMS_Files_StatusID.StatusName
        oCol.Font.Size = "10"
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = uFil.StatusOn
        oCol.Font.Size = "10"
        oRow.Cells.Add(oCol)

        oTbl.Rows.Add(oRow)

        Dim Results As List(Of SIS.xDMS.xDmsFiles) = SIS.xDMS.xDmsFiles.UZ_xDmsRefFilesSelectList(0, 9999, "", uFil.FileID)
        For Each xF As SIS.xDMS.xDmsFiles In Results
          With xF
            oRow = New TableRow

            oCol = New TableCell
            oCol.Text = .FileName
            oCol.Font.Size = "10"
            oRow.Cells.Add(oCol)

            oCol = New TableCell
            oCol.Text = .FK_xDMS_Files_StatusBy.UserFullName
            oCol.Font.Size = "10"
            oRow.Cells.Add(oCol)

            oCol = New TableCell
            oCol.Text = .FK_xDMS_Files_StatusID.StatusName
            oCol.Font.Size = "10"
            oRow.Cells.Add(oCol)

            oCol = New TableCell
            oCol.Text = .StatusOn
            oCol.Font.Size = "10"
            oRow.Cells.Add(oCol)

            oTbl.Rows.Add(oRow)
          End With
        Next


        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As IO.StringWriter = New IO.StringWriter(sb)
        Dim writer As HtmlTextWriter = New HtmlTextWriter(sw)
        Try
          oTbl.RenderControl(writer)
        Catch ex As Exception
        End Try
        Dim Header As String = ""
        Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header = Header & "<head>"
        Header = Header & "<title></title>"
        Header = Header & "<style>"
        Header = Header & "body{margin: 10px auto auto 60px;}"
        Header = Header & ".tblHd, .tblHd td{font-size: 12px;font-weight: bold;height: 30px !important;background-color:lightgray;}"
        Header = Header & "table{"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "border-collapse:collapse;"
        Header = Header & "font-family: Tahoma;}"

        Header = Header & "td{padding-left: 4px;"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "font-family: Tahoma;"
        Header = Header & "font-size: 9px;"
        Header = Header & "vertical-align:top;}"

        Header = Header & "</style>"
        Header = Header & "</head>"
        Header = Header & "<body>"
        Header = Header & sb.ToString
        Header = Header & "</body></html>"
        .Body = Header
      End With
      Try
        If Not Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then
          oClient.Send(oMsg)
        End If
      Catch ex As Exception
      End Try
    End Sub
    Public Shared Sub AlertWithoutWF(FileID As Integer)
      Dim uFil As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(FileID)
      Dim uUsr As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(uFil.StatusBy)

      Dim oClient As SmtpClient = New SmtpClient("192.9.200.214", 25)
      oClient.Credentials = New Net.NetworkCredential("adskvaultadmin", "isgec@123")

      Dim ad As MailAddress = Nothing
      Dim aIDs() As String = Nothing
      Dim oMsg As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage()
      With oMsg
        '1.From
        aIDs = uUsr.EMailID.Split(",;".ToCharArray)
        For Each tmp As String In aIDs
          If tmp.Trim <> "" Then
            ad = New MailAddress(tmp.Trim, tmp.Trim)
            If ad IsNot Nothing Then
              .From = ad
              Exit For
            End If
          End If
        Next
        If .From Is Nothing Then
          .From = New MailAddress("baansupport@isgec.co.in", "BaaN Support")
        End If
        '2. To
        Dim tmpUs As List(Of String) = SIS.xDMS.xDmsFolderAuthorizations.GetAuthorizedUsers(uFil.FolderID)
        For Each tu As String In tmpUs
          Dim tmpUsr As SIS.QCM.qcmUsers = SIS.QCM.qcmUsers.qcmUsersGetByID(tu)
          aIDs = tmpUsr.EMailID.Split(",;".ToCharArray)
          For Each tmp As String In aIDs
            If tmp.Trim <> "" Then
              ad = New MailAddress(tmp.Trim, tmp.Trim)
              If ad IsNot Nothing Then If Not .To.Contains(ad) Then .To.Add(ad)
            End If
          Next
        Next
        .Subject = "ISGEC DMS Notification: File " & uFil.FK_xDMS_Files_StatusID.StatusName
        .IsBodyHtml = True
        Dim oTbl As New Table
        oTbl.GridLines = GridLines.Both
        oTbl.Width = 900
        oTbl.Style.Add("text-align", "left")
        oTbl.Style.Add("font", "Tahoma")

        Dim oCol As TableCell = Nothing
        Dim oRow As TableRow = Nothing
        '1.
        oRow = New TableRow
        oCol = New TableCell
        oCol.Style.Add("text-align", "center")
        oCol.Font.Size = "14"
        oCol.ColumnSpan = 4
        oCol.Text = "File(s) List"
        oCol.BackColor = System.Drawing.Color.CadetBlue
        oCol.ForeColor = System.Drawing.Color.White
        oCol.Font.Bold = True
        oRow.Cells.Add(oCol)
        oTbl.Rows.Add(oRow)

        oRow = New TableRow

        oCol = New TableCell
        oCol.Text = uFil.FileName
        oCol.Font.Size = "10"
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = uFil.FK_xDMS_Files_StatusBy.UserFullName
        oCol.Font.Size = "10"
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = uFil.FK_xDMS_Files_StatusID.StatusName
        oCol.Font.Size = "10"
        oRow.Cells.Add(oCol)

        oCol = New TableCell
        oCol.Text = uFil.StatusOn
        oCol.Font.Size = "10"
        oRow.Cells.Add(oCol)

        oTbl.Rows.Add(oRow)

        Dim Results As List(Of SIS.xDMS.xDmsFiles) = SIS.xDMS.xDmsFiles.UZ_xDmsRefFilesSelectList(0, 9999, "", uFil.FileID)
        For Each xF As SIS.xDMS.xDmsFiles In Results
          With xF
            oRow = New TableRow

            oCol = New TableCell
            oCol.Text = .FileName
            oCol.Font.Size = "10"
            oRow.Cells.Add(oCol)

            oCol = New TableCell
            oCol.Text = .FK_xDMS_Files_StatusBy.UserFullName
            oCol.Font.Size = "10"
            oRow.Cells.Add(oCol)

            oCol = New TableCell
            oCol.Text = .FK_xDMS_Files_StatusID.StatusName
            oCol.Font.Size = "10"
            oRow.Cells.Add(oCol)

            oCol = New TableCell
            oCol.Text = .StatusOn
            oCol.Font.Size = "10"
            oRow.Cells.Add(oCol)

            oTbl.Rows.Add(oRow)
          End With
        Next




        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As IO.StringWriter = New IO.StringWriter(sb)
        Dim writer As HtmlTextWriter = New HtmlTextWriter(sw)
        Try
          oTbl.RenderControl(writer)
        Catch ex As Exception
        End Try
        Dim Header As String = ""
        Header = Header & "<html xmlns=""http://www.w3.org/1999/xhtml"">"
        Header = Header & "<head>"
        Header = Header & "<title></title>"
        Header = Header & "<style>"
        Header = Header & "body{margin: 10px auto auto 60px;}"
        Header = Header & ".tblHd, .tblHd td{font-size: 12px;font-weight: bold;height: 30px !important;background-color:lightgray;}"
        Header = Header & "table{"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "border-collapse:collapse;"
        Header = Header & "font-family: Tahoma;}"

        Header = Header & "td{padding-left: 4px;"
        Header = Header & "border: solid 1pt black;"
        Header = Header & "font-family: Tahoma;"
        Header = Header & "font-size: 9px;"
        Header = Header & "vertical-align:top;}"

        Header = Header & "</style>"
        Header = Header & "</head>"
        Header = Header & "<body>"
        Header = Header & sb.ToString
        Header = Header & "</body></html>"
        .Body = Header
      End With
      Try
        If Not Convert.ToBoolean(ConfigurationManager.AppSettings("Testing")) Then
          oClient.Send(oMsg)
        End If
      Catch ex As Exception
      End Try
    End Sub

  End Class

End Namespace

