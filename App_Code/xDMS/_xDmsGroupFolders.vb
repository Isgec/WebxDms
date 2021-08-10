Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  <DataObject()> _
  Partial Public Class xDmsGroupFolders
    Private Shared _RecordCount As Integer
    Public Property GroupID As Int32 = 0
    Public Property FolderID As Int32 = 0
    Public Property CreateFolder As Boolean = False
    Public Property UpdateFolder As Boolean = False
    Public Property DeleteFolder As Boolean = False
    Public Property UploadFile As Boolean = False
    Public Property DownloadFile As Boolean = False
    Public Property DeleteFile As Boolean = False
    Public Property CanAuthorizeFolder As Boolean = False
    Public Property CanPassAuthorization As Boolean = False
    Public Property xDMS_Folders1_FolderName As String = ""
    Public Property xDMS_Groups2_Description As String = ""
    Private _FK_xDMS_GroupFolders_FolderID As SIS.xDMS.xDmsFolders = Nothing
    Private _FK_xDMS_GroupFolders_GroupID As SIS.xDMS.xDmsGroups = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Blue
        Try
          mRet = GetColor()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Visible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Enable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _GroupID & "|" & _FolderID
      End Get
    End Property
    Public Shared Property RecordCount() As Integer
      Get
        Return _RecordCount
      End Get
      Set(ByVal value As Integer)
        _RecordCount = value
      End Set
    End Property
    Public Class PKxDmsGroupFolders
      Private _GroupID As Int32 = 0
      Private _FolderID As Int32 = 0
      Public Property GroupID() As Int32
        Get
          Return _GroupID
        End Get
        Set(ByVal value As Int32)
          _GroupID = value
        End Set
      End Property
      Public Property FolderID() As Int32
        Get
          Return _FolderID
        End Get
        Set(ByVal value As Int32)
          _FolderID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_xDMS_GroupFolders_FolderID() As SIS.xDMS.xDmsFolders
      Get
        If _FK_xDMS_GroupFolders_FolderID Is Nothing Then
          _FK_xDMS_GroupFolders_FolderID = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(_FolderID)
        End If
        Return _FK_xDMS_GroupFolders_FolderID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_GroupFolders_GroupID() As SIS.xDMS.xDmsGroups
      Get
        If _FK_xDMS_GroupFolders_GroupID Is Nothing Then
          _FK_xDMS_GroupFolders_GroupID = SIS.xDMS.xDmsGroups.xDmsGroupsGetByID(_GroupID)
        End If
        Return _FK_xDMS_GroupFolders_GroupID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsGroupFoldersGetNewRecord() As SIS.xDMS.xDmsGroupFolders
      Return New SIS.xDMS.xDmsGroupFolders()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsGroupFoldersGetByID(ByVal GroupID As Int32, ByVal FolderID As Int32) As SIS.xDMS.xDmsGroupFolders
      Dim Results As SIS.xDMS.xDmsGroupFolders = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsGroupFoldersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID",SqlDbType.Int,GroupID.ToString.Length, GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID",SqlDbType.Int,FolderID.ToString.Length, FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsGroupFolders(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsGroupFoldersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal GroupID As Int32) As List(Of SIS.xDMS.xDmsGroupFolders)
      Dim Results As List(Of SIS.xDMS.xDmsGroupFolders) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FolderID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsGroupFoldersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsGroupFoldersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_GroupID",SqlDbType.Int,10, IIf(GroupID = Nothing, 0,GroupID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsGroupFolders)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsGroupFolders(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsGroupFoldersSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal GroupID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsGroupFoldersGetByID(ByVal GroupID As Int32, ByVal FolderID As Int32, ByVal Filter_GroupID As Int32) As SIS.xDMS.xDmsGroupFolders
      Return xDmsGroupFoldersGetByID(GroupID, FolderID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function xDmsGroupFoldersInsert(ByVal Record As SIS.xDMS.xDmsGroupFolders) As SIS.xDMS.xDmsGroupFolders
      Dim _Rec As SIS.xDMS.xDmsGroupFolders = SIS.xDMS.xDmsGroupFolders.xDmsGroupFoldersGetNewRecord()
      With _Rec
        .GroupID = Record.GroupID
        .FolderID = Record.FolderID
        .CreateFolder = Record.CreateFolder
        .UpdateFolder = Record.UpdateFolder
        .DeleteFolder = Record.DeleteFolder
        .UploadFile = Record.UploadFile
        .DownloadFile = Record.DownloadFile
        .DeleteFile = Record.DeleteFile
        .CanAuthorizeFolder = Record.CanAuthorizeFolder
        .CanPassAuthorization = Record.CanPassAuthorization
      End With
      Return SIS.xDMS.xDmsGroupFolders.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.xDmsGroupFolders) As SIS.xDMS.xDmsGroupFolders
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsGroupFoldersInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID",SqlDbType.Int,11, Record.GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID",SqlDbType.Int,11, Record.FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreateFolder",SqlDbType.Bit,3, Record.CreateFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdateFolder",SqlDbType.Bit,3, Record.UpdateFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteFolder",SqlDbType.Bit,3, Record.DeleteFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadFile",SqlDbType.Bit,3, Record.UploadFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadFile",SqlDbType.Bit,3, Record.DownloadFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteFile",SqlDbType.Bit,3, Record.DeleteFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanAuthorizeFolder",SqlDbType.Bit,3, Record.CanAuthorizeFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanPassAuthorization",SqlDbType.Bit,3, Record.CanPassAuthorization)
          Cmd.Parameters.Add("@Return_GroupID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_GroupID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_FolderID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FolderID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.GroupID = Cmd.Parameters("@Return_GroupID").Value
          Record.FolderID = Cmd.Parameters("@Return_FolderID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function xDmsGroupFoldersUpdate(ByVal Record As SIS.xDMS.xDmsGroupFolders) As SIS.xDMS.xDmsGroupFolders
      Dim _Rec As SIS.xDMS.xDmsGroupFolders = SIS.xDMS.xDmsGroupFolders.xDmsGroupFoldersGetByID(Record.GroupID, Record.FolderID)
      With _Rec
        .CreateFolder = Record.CreateFolder
        .UpdateFolder = Record.UpdateFolder
        .DeleteFolder = Record.DeleteFolder
        .UploadFile = Record.UploadFile
        .DownloadFile = Record.DownloadFile
        .DeleteFile = Record.DeleteFile
        .CanAuthorizeFolder = Record.CanAuthorizeFolder
        .CanPassAuthorization = Record.CanPassAuthorization
      End With
      Return SIS.xDMS.xDmsGroupFolders.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.xDmsGroupFolders) As SIS.xDMS.xDmsGroupFolders
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsGroupFoldersUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GroupID",SqlDbType.Int,11, Record.GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FolderID",SqlDbType.Int,11, Record.FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID",SqlDbType.Int,11, Record.GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID",SqlDbType.Int,11, Record.FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreateFolder",SqlDbType.Bit,3, Record.CreateFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdateFolder",SqlDbType.Bit,3, Record.UpdateFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteFolder",SqlDbType.Bit,3, Record.DeleteFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadFile",SqlDbType.Bit,3, Record.UploadFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadFile",SqlDbType.Bit,3, Record.DownloadFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteFile",SqlDbType.Bit,3, Record.DeleteFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanAuthorizeFolder",SqlDbType.Bit,3, Record.CanAuthorizeFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanPassAuthorization",SqlDbType.Bit,3, Record.CanPassAuthorization)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function xDmsGroupFoldersDelete(ByVal Record As SIS.xDMS.xDmsGroupFolders) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsGroupFoldersDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GroupID",SqlDbType.Int,Record.GroupID.ToString.Length, Record.GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FolderID",SqlDbType.Int,Record.FolderID.ToString.Length, Record.FolderID)
          Cmd.Parameters.Add("@RowCount", SqlDbType.Int)
          Cmd.Parameters("@RowCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Con.Open()
          Cmd.ExecuteNonQuery()
          _RecordCount = Cmd.Parameters("@RowCount").Value
        End Using
      End Using
      Return _RecordCount
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
