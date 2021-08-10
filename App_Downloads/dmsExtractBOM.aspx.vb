Imports OfficeOpenXml
Imports System.Web.Script.Serialization
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports Ionic
Imports Ionic.Zip
Imports System.Net
Partial Class dmsExtractBOM
  Inherits System.Web.UI.Page
  Private st As Long = HttpContext.Current.Server.ScriptTimeout
  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    HttpContext.Current.Server.ScriptTimeout = Integer.MaxValue
    Dim ProjectID As String = ""
    Dim Comp As String = ""
    Dim EngFunc As String = ""
    Dim TranID As String = ""
    Dim Key As String = ""
    If Request.QueryString("key") IsNot Nothing Then Key = Request.QueryString("Key")

    Dim FolderID As String = ""
    If Key <> "" Then FolderID = Key.Split("_".ToCharArray)(1)
    If FolderID <> "" Then
      Dim tmp As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(FolderID)
      Dim aVal() As String = tmp.KeyWords.Split(",".ToCharArray)
      For Each x As String In aVal
        If x.StartsWith("Prj") Then ProjectID = x.Split(":".ToCharArray)(1)
        If x.StartsWith("Comp") Then Comp = x.Split(":".ToCharArray)(1)
        If x.StartsWith("EngFunc") Then EngFunc = x.Split(":".ToCharArray)(1)
        If x.StartsWith("Tran") Then TranID = x.Split(":".ToCharArray)(1)
      Next
    End If

    'If Request.QueryString("ProjectID") IsNot Nothing Then ProjectID = Request.QueryString("ProjectID")
    'If Request.QueryString("Comp") IsNot Nothing Then Comp = Request.QueryString("Comp")
    'If Request.QueryString("EngFunc") IsNot Nothing Then EngFunc = Request.QueryString("EngFunc")
    'If Request.QueryString("TranID") IsNot Nothing Then TranID = Request.QueryString("TranID")
    If ProjectID <> "" Then
      Dim DownloadName As String = ""
      Dim FileName As String = DownloadLive(ProjectID, EngFunc, TranID, Comp, DownloadName)
      Response.Clear()
      Response.AppendHeader("content-disposition", "attachment; filename=" & DownloadName)
      Response.ContentType = SIS.SYS.Utilities.ApplicationSpacific.ContentType(DownloadName)
      Response.WriteFile(FileName)
      Response.Flush()
      Response.End()
    Else
      Response.Clear()
      Response.End()
    End If
  End Sub

  Private Function DownloadLive(Project As String, EnggFunc As String, TranID As String, Comp As String, ByRef DownloadName As String) As String
    Dim TemplateName As String = "BOM_Template.xlsx"
    Dim tmpFile As String = Server.MapPath("~/App_Templates/" & TemplateName)
    Dim FileName As String = Server.MapPath("~/..") & "App_Temp/" & Guid.NewGuid().ToString()
    IO.File.Copy(tmpFile, FileName)
    Dim FileInfo As IO.FileInfo = New IO.FileInfo(FileName)
    Dim xlPk As ExcelPackage = New ExcelPackage(FileInfo)

    Dim xlWS As ExcelWorksheet = xlPk.Workbook.Worksheets("Data")
    Dim r As Integer = 3
    Dim c As Integer = 1
    Dim cnt As Integer = 1
    DownloadName = Project & IIf(EnggFunc <> "", "_" & EnggFunc, "") & ".xlsx"

    Dim tmpDocs As List(Of SIS.DMISG.TDocs) = SIS.DMISG.TDocs.GetDocs(Project, EnggFunc, Comp)

    For Each doc As SIS.DMISG.TDocs In tmpDocs
      Dim tmpDoc As SIS.DMISG.BOM = SIS.DMISG.BOM.GetDoc(doc.DocumentID, doc.RevisionNo, Comp)
      If tmpDoc Is Nothing Then
        xlWS.Cells(r, 1).Value = doc.DocumentID & "_" & doc.RevisionNo & " NOT in dmisg001200."
        r += 1
        Continue For
      End If
      With xlWS
        c = 1
        .Cells(r, c).Value = tmpDoc.DocumentID
        c += 1
        .Cells(r, c).Value = tmpDoc.RevisionNo
        c += 1
        .Cells(r, c).Value = tmpDoc.Title
        c += 1
        .Cells(r, c).Value = tmpDoc.DocWeight
        c += 1
        .Cells(r, c).Value = "Kg"
        r += 1
      End With
      Dim tmpBoms As List(Of SIS.DMISG.BOM) = SIS.DMISG.BOM.GetBOM(doc.DocumentID, doc.RevisionNo, Comp)
      For Each tmp As SIS.DMISG.BOM In tmpBoms
        With xlWS
          c = 6
          .Cells(r, c).Value = tmpDoc.ProjectID & "-" & tmp.ItemID.Trim
          c += 1
          .Cells(r, c).Value = tmp.ItemID
          c += 1
          .Cells(r, c).Value = tmp.ItemDescription
          c += 1
          .Cells(r, c).Value = tmp.ItemQuantity
          c += 1
          .Cells(r, c).Value = tmp.ItemWeight
          c += 1
          .Cells(r, c).Value = tmp.ItemUnit
          c += 1
          .Cells(r, c).Value = ""
          r += 1
        End With
        Dim tmpPBoms As List(Of SIS.DMISG.BOM) = SIS.DMISG.BOM.GetPBOM(doc.DocumentID, doc.RevisionNo, tmp.SrNo, Comp)
        For Each ptmp As SIS.DMISG.BOM In tmpPBoms
          With xlWS
            c = 13
            .Cells(r, c).Value = ptmp.PartItemID
            c += 1
            .Cells(r, c).Value = ptmp.PartDescription
            c += 1
            .Cells(r, c).Value = ptmp.PartSpecification
            c += 1
            .Cells(r, c).Value = ptmp.PartSize
            c += 1
            .Cells(r, c).Value = ptmp.PartQuantity
            c += 1
            .Cells(r, c).Value = ptmp.PartWeight
            c += 1
            .Cells(r, c).Value = ptmp.PartRemarks
            r += 1
          End With
        Next
      Next
      Dim tmpRefBoms As List(Of SIS.DMISG.BOM) = SIS.DMISG.BOM.GetRefBOM(doc.DocumentID, doc.RevisionNo, Comp)
      For Each tmp As SIS.DMISG.BOM In tmpRefBoms
        With xlWS
          c = 6
          .Cells(r, c).Value = tmpDoc.ProjectID & "-" & tmp.ItemID.Trim
          c += 1
          .Cells(r, c).Value = tmp.ItemID
          c += 1
          .Cells(r, c).Value = tmp.ItemDescription
          c += 1
          .Cells(r, c).Value = tmp.ItemQuantity
          c += 1
          .Cells(r, c).Value = tmp.ItemWeight
          c += 1
          .Cells(r, c).Value = tmp.ItemUnit
          c += 1
          .Cells(r, c).Value = ""
          r += 1
        End With
        Dim tmpRefPBoms As List(Of SIS.DMISG.BOM) = SIS.DMISG.BOM.GetRefPBOM(doc.DocumentID, doc.RevisionNo, tmp.SrNo, Comp)
        For Each ptmp As SIS.DMISG.BOM In tmpRefPBoms
          With xlWS
            c = 13
            .Cells(r, c).Value = ptmp.PartItemID
            c += 1
            .Cells(r, c).Value = ptmp.PartDescription
            c += 1
            .Cells(r, c).Value = ptmp.PartSpecification
            c += 1
            .Cells(r, c).Value = ptmp.PartSize
            c += 1
            .Cells(r, c).Value = ptmp.PartQuantity
            c += 1
            .Cells(r, c).Value = ptmp.PartWeight
            c += 1
            .Cells(r, c).Value = ptmp.PartRemarks
          End With
          r += 1
        Next
      Next
    Next
    xlPk.Save()
    xlPk.Dispose()
    HttpContext.Current.Server.ScriptTimeout = st
    Return FileName
  End Function
End Class
