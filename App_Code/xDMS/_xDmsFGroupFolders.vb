Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  <DataObject()> _
  Partial Public Class xDmsFGroupFolders
    Private Shared _RecordCount As Integer
    Public Property FGroupID As Int32 = 0
    Public Property FolderID As Int32 = 0
    Public Property xDMS_FGroups1_FGroupName As String = ""
    Public Property xDMS_Folders2_FolderName As String = ""
    Private _FK_xDMS_FGroupFolders_FGroupID As SIS.xDMS.xDmsFGroups = Nothing
    Private _FK_xDMS_FGroupFolders_FolderID As SIS.xDMS.xDmsFolders = Nothing
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
        Return _FGroupID & "|" & _FolderID
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
    Public Class PKxDmsFGroupFolders
      Private _FGroupID As Int32 = 0
      Private _FolderID As Int32 = 0
      Public Property FGroupID() As Int32
        Get
          Return _FGroupID
        End Get
        Set(ByVal value As Int32)
          _FGroupID = value
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
    Public ReadOnly Property FK_xDMS_FGroupFolders_FGroupID() As SIS.xDMS.xDmsFGroups
      Get
        If _FK_xDMS_FGroupFolders_FGroupID Is Nothing Then
          _FK_xDMS_FGroupFolders_FGroupID = SIS.xDMS.xDmsFGroups.xDmsFGroupsGetByID(_FGroupID)
        End If
        Return _FK_xDMS_FGroupFolders_FGroupID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_FGroupFolders_FolderID() As SIS.xDMS.xDmsFolders
      Get
        If _FK_xDMS_FGroupFolders_FolderID Is Nothing Then
          _FK_xDMS_FGroupFolders_FolderID = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(_FolderID)
        End If
        Return _FK_xDMS_FGroupFolders_FolderID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFGroupFoldersGetNewRecord() As SIS.xDMS.xDmsFGroupFolders
      Return New SIS.xDMS.xDmsFGroupFolders()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFGroupFoldersGetByID(ByVal FGroupID As Int32, ByVal FolderID As Int32) As SIS.xDMS.xDmsFGroupFolders
      Dim Results As SIS.xDMS.xDmsFGroupFolders = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFGroupFoldersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FGroupID",SqlDbType.Int,FGroupID.ToString.Length, FGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID",SqlDbType.Int,FolderID.ToString.Length, FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsFGroupFolders(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFGroupFoldersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.xDMS.xDmsFGroupFolders)
      Dim Results As List(Of SIS.xDMS.xDmsFGroupFolders) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsFGroupFoldersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsFGroupFoldersSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFGroupFolders)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFGroupFolders(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsFGroupFoldersSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function xDmsFGroupFoldersInsert(ByVal Record As SIS.xDMS.xDmsFGroupFolders) As SIS.xDMS.xDmsFGroupFolders
      Dim _Rec As SIS.xDMS.xDmsFGroupFolders = SIS.xDMS.xDmsFGroupFolders.xDmsFGroupFoldersGetNewRecord()
      With _Rec
        .FGroupID = Record.FGroupID
        .FolderID = Record.FolderID
      End With
      Return SIS.xDMS.xDmsFGroupFolders.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.xDmsFGroupFolders) As SIS.xDMS.xDmsFGroupFolders
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFGroupFoldersInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FGroupID",SqlDbType.Int,11, Record.FGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID",SqlDbType.Int,11, Record.FolderID)
          Cmd.Parameters.Add("@Return_FGroupID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FGroupID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_FolderID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FolderID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.FGroupID = Cmd.Parameters("@Return_FGroupID").Value
          Record.FolderID = Cmd.Parameters("@Return_FolderID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function xDmsFGroupFoldersUpdate(ByVal Record As SIS.xDMS.xDmsFGroupFolders) As SIS.xDMS.xDmsFGroupFolders
      Dim _Rec As SIS.xDMS.xDmsFGroupFolders = SIS.xDMS.xDmsFGroupFolders.xDmsFGroupFoldersGetByID(Record.FGroupID, Record.FolderID)
      With _Rec
      End With
      Return SIS.xDMS.xDmsFGroupFolders.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.xDmsFGroupFolders) As SIS.xDMS.xDmsFGroupFolders
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFGroupFoldersUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FGroupID",SqlDbType.Int,11, Record.FGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FolderID",SqlDbType.Int,11, Record.FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FGroupID",SqlDbType.Int,11, Record.FGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID",SqlDbType.Int,11, Record.FolderID)
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
    Public Shared Function xDmsFGroupFoldersDelete(ByVal Record As SIS.xDMS.xDmsFGroupFolders) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFGroupFoldersDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FGroupID",SqlDbType.Int,Record.FGroupID.ToString.Length, Record.FGroupID)
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
