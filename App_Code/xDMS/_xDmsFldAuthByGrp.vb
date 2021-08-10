Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  <DataObject()> _
  Partial Public Class xDmsFldAuthByGrp
    Inherits SIS.xDMS.xDmsFolderAuthorizations
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFldAuthByGrpGetNewRecord() As SIS.xDMS.xDmsFldAuthByGrp
      Return New SIS.xDMS.xDmsFldAuthByGrp()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFldAuthByGrpSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal GroupID As Int32) As List(Of SIS.xDMS.xDmsFldAuthByGrp)
      Dim Results As List(Of SIS.xDMS.xDmsFldAuthByGrp) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "UserID"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsFldAuthByGrpSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsFldAuthByGrpSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_GroupID",SqlDbType.Int,10, IIf(GroupID = Nothing, 0,GroupID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFldAuthByGrp)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFldAuthByGrp(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsFldAuthByGrpSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal GroupID As Int32) As Integer
      Return RecordCount
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFldAuthByGrpGetByID(ByVal GroupID As Int32, ByVal UserID As String, ByVal FolderID As Int32) As SIS.xDMS.xDmsFldAuthByGrp
      Dim Results As SIS.xDMS.xDmsFldAuthByGrp = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFolderAuthorizationsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID",SqlDbType.Int,GroupID.ToString.Length, GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,UserID.ToString.Length, UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID",SqlDbType.Int,FolderID.ToString.Length, FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsFldAuthByGrp(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFldAuthByGrpGetByID(ByVal GroupID As Int32, ByVal UserID As String, ByVal FolderID As Int32, ByVal Filter_GroupID As Int32) As SIS.xDMS.xDmsFldAuthByGrp
      Dim Results As SIS.xDMS.xDmsFldAuthByGrp = SIS.xDMS.xDmsFldAuthByGrp.UZ_xDmsFldAuthByGrpGetByID(GroupID, UserID, FolderID)
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function xDmsFldAuthByGrpInsert(ByVal Record As SIS.xDMS.xDmsFldAuthByGrp) As SIS.xDMS.xDmsFldAuthByGrp
      Dim _Rec As SIS.xDMS.xDmsFldAuthByGrp = SIS.xDMS.xDmsFldAuthByGrp.xDmsFldAuthByGrpGetNewRecord()
      With _Rec
        .UserID = Record.UserID
        .FolderID = Record.FolderID
        .CreateFolder = Record.CreateFolder
        .UpdateFolder = Record.UpdateFolder
        .DeleteFolder = Record.DeleteFolder
        .UploadFile = Record.UploadFile
        .DownloadFile = Record.DownloadFile
        .DeleteFile = Record.DeleteFile
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
        .CanPassAuthorization = Record.CanPassAuthorization
        .GroupID = Record.GroupID
        .CanAuthorizeFolder = Record.CanAuthorizeFolder
      End With
      Return SIS.xDMS.xDmsFldAuthByGrp.InsertData(_Rec)
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function xDmsFldAuthByGrpUpdate(ByVal Record As SIS.xDMS.xDmsFldAuthByGrp) As SIS.xDMS.xDmsFldAuthByGrp
      Dim _Rec As SIS.xDMS.xDmsFldAuthByGrp = SIS.xDMS.xDmsFldAuthByGrp.UZ_xDmsFldAuthByGrpGetByID(Record.GroupID, Record.UserID, Record.FolderID)
      With _Rec
        .CreateFolder = Record.CreateFolder
        .UpdateFolder = Record.UpdateFolder
        .DeleteFolder = Record.DeleteFolder
        .UploadFile = Record.UploadFile
        .DownloadFile = Record.DownloadFile
        .DeleteFile = Record.DeleteFile
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
        .CanPassAuthorization = Record.CanPassAuthorization
        .CanAuthorizeFolder = Record.CanAuthorizeFolder
      End With
      Return SIS.xDMS.xDmsFldAuthByGrp.UpdateData(_Rec)
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      MyBase.New(Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
