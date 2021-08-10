Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  <DataObject()> _
  Partial Public Class xDmsUsers
    Private Shared _RecordCount As Integer
    Public Property UserID As String = ""
    Public Property CreateRootLevelFolder As Boolean = False
    Public Property CreateFolder As Boolean = False
    Public Property UpdateFolder As Boolean = False
    Public Property DeleteFolder As Boolean = False
    Public Property UploadFile As Boolean = False
    Public Property DownloadFile As Boolean = False
    Public Property DeleteFile As Boolean = False
    Public Property IsAdmin As Boolean = False
    Public Property IsSAdmin As Boolean = False
    Public Property GroupID As String = ""
    Public Property CanPassAuthorization As Boolean = False
    Public Property CanAuthorizeFolder As Boolean = False
    Public Property CanViewAllRevisions As Boolean = True
    Public Property aspnet_Users1_UserFullName As String = ""
    Private _FK_xDMS_Users_UserID As SIS.QCM.qcmUsers = Nothing
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
        Return _UserID
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
    Public Class PKxDmsUsers
      Private _UserID As String = ""
      Public Property UserID() As String
        Get
          Return _UserID
        End Get
        Set(ByVal value As String)
          _UserID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_xDMS_Users_UserID() As SIS.QCM.qcmUsers
      Get
        If _FK_xDMS_Users_UserID Is Nothing Then
          _FK_xDMS_Users_UserID = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserID)
        End If
        Return _FK_xDMS_Users_UserID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsUsersGetNewRecord() As SIS.xDMS.xDmsUsers
      Return New SIS.xDMS.xDmsUsers()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsUsersGetByID(ByVal UserID As String) As SIS.xDMS.xDmsUsers
      Dim Results As SIS.xDMS.xDmsUsers = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsUsersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,UserID.ToString.Length, UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsUsers(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsUsersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String) As List(Of SIS.xDMS.xDmsUsers)
      Dim Results As List(Of SIS.xDMS.xDmsUsers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "UserID"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsUsersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsUsersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserID",SqlDbType.NVarChar,8, IIf(UserID Is Nothing, String.Empty,UserID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsUsers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsUsers(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsUsersSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsUsersGetByID(ByVal UserID As String, ByVal Filter_UserID As String) As SIS.xDMS.xDmsUsers
      Return xDmsUsersGetByID(UserID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function xDmsUsersInsert(ByVal Record As SIS.xDMS.xDmsUsers) As SIS.xDMS.xDmsUsers
      Dim _Rec As SIS.xDMS.xDmsUsers = SIS.xDMS.xDmsUsers.xDmsUsersGetNewRecord()
      With _Rec
        .UserID = Record.UserID
        .CreateRootLevelFolder = Record.CreateRootLevelFolder
        .CreateFolder = Record.CreateFolder
        .UpdateFolder = Record.UpdateFolder
        .DeleteFolder = Record.DeleteFolder
        .UploadFile = Record.UploadFile
        .DownloadFile = Record.DownloadFile
        .DeleteFile = Record.DeleteFile
        .IsAdmin = Record.IsAdmin
        .IsSAdmin = Record.IsSAdmin
        .CanPassAuthorization = Record.CanPassAuthorization
        .CanAuthorizeFolder = Record.CanAuthorizeFolder
        .CanViewAllRevisions = Record.CanViewAllRevisions
      End With
      Return SIS.xDMS.xDmsUsers.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.xDmsUsers) As SIS.xDMS.xDmsUsers
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsUsersInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreateRootLevelFolder",SqlDbType.Bit,3, Record.CreateRootLevelFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreateFolder",SqlDbType.Bit,3, Record.CreateFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdateFolder",SqlDbType.Bit,3, Record.UpdateFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteFolder",SqlDbType.Bit,3, Record.DeleteFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadFile",SqlDbType.Bit,3, Record.UploadFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadFile",SqlDbType.Bit,3, Record.DownloadFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteFile",SqlDbType.Bit,3, Record.DeleteFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsAdmin", SqlDbType.Bit, 3, Record.IsAdmin)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsSAdmin", SqlDbType.Bit, 3, Record.IsSAdmin)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanPassAuthorization", SqlDbType.Bit, 3, Record.CanPassAuthorization)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanAuthorizeFolder", SqlDbType.Bit, 3, Record.CanAuthorizeFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanViewAllRevisions", SqlDbType.Bit, 3, Record.CanViewAllRevisions)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID", SqlDbType.NVarChar, 10, IIf(Record.GroupID = "", Convert.DBNull, Record.GroupID))
          Cmd.Parameters.Add("@Return_UserID", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_UserID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.UserID = Cmd.Parameters("@Return_UserID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function xDmsUsersUpdate(ByVal Record As SIS.xDMS.xDmsUsers) As SIS.xDMS.xDmsUsers
      Dim _Rec As SIS.xDMS.xDmsUsers = SIS.xDMS.xDmsUsers.xDmsUsersGetByID(Record.UserID)
      With _Rec
        .CreateRootLevelFolder = Record.CreateRootLevelFolder
        .CreateFolder = Record.CreateFolder
        .UpdateFolder = Record.UpdateFolder
        .DeleteFolder = Record.DeleteFolder
        .UploadFile = Record.UploadFile
        .DownloadFile = Record.DownloadFile
        .DeleteFile = Record.DeleteFile
        .IsAdmin = Record.IsAdmin
        .IsSAdmin = Record.IsSAdmin
        .CanPassAuthorization = Record.CanPassAuthorization
        .CanAuthorizeFolder = Record.CanAuthorizeFolder
        .CanViewAllRevisions = Record.CanViewAllRevisions
      End With
      Return SIS.xDMS.xDmsUsers.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.xDmsUsers) As SIS.xDMS.xDmsUsers
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsUsersUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreateRootLevelFolder",SqlDbType.Bit,3, Record.CreateRootLevelFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreateFolder",SqlDbType.Bit,3, Record.CreateFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdateFolder",SqlDbType.Bit,3, Record.UpdateFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteFolder",SqlDbType.Bit,3, Record.DeleteFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadFile",SqlDbType.Bit,3, Record.UploadFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadFile",SqlDbType.Bit,3, Record.DownloadFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteFile",SqlDbType.Bit,3, Record.DeleteFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsAdmin",SqlDbType.Bit,3, Record.IsAdmin)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsSAdmin", SqlDbType.Bit, 3, Record.IsSAdmin)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanPassAuthorization", SqlDbType.Bit, 3, Record.CanPassAuthorization)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanAuthorizeFolder",SqlDbType.Bit,3, Record.CanAuthorizeFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID", SqlDbType.NVarChar, 10, IIf(Record.GroupID = "", Convert.DBNull, Record.GroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanViewAllRevisions", SqlDbType.Bit, 3, Record.CanViewAllRevisions)
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
    Public Shared Function xDmsUsersDelete(ByVal Record As SIS.xDMS.xDmsUsers) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsUsersDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID",SqlDbType.NVarChar,Record.UserID.ToString.Length, Record.UserID)
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
