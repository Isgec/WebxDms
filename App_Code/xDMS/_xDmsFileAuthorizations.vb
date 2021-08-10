Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  <DataObject()> _
  Partial Public Class xDmsFileAuthorizations
    Private Shared _RecordCount As Integer
    Public Property UserID As String = ""
    Public Property FileID As Int32 = 0
    Public Property DownloadFile As Boolean = False
    Public Property DeleteFile As Boolean = False
    Public Property CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property aspnet_Users2_UserFullName As String = ""
    Public Property xDMS_Files3_FileName As String = ""
    Private _FK_xDMS_FileAuthorizations_UserID As SIS.QCM.qcmUsers = Nothing
    Private _FK_xDMS_FileAuthorizations_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_xDMS_FileAuthorizations_FileID As SIS.xDMS.xDmsFiles = Nothing
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
    Public Property CreatedOn() As String
      Get
        If Not _CreatedOn = String.Empty Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _CreatedOn
      End Get
      Set(ByVal value As String)
         _CreatedOn = value
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _UserID & "|" & _FileID
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
    Public Class PKxDmsFileAuthorizations
      Private _UserID As String = ""
      Private _FileID As Int32 = 0
      Public Property UserID() As String
        Get
          Return _UserID
        End Get
        Set(ByVal value As String)
          _UserID = value
        End Set
      End Property
      Public Property FileID() As Int32
        Get
          Return _FileID
        End Get
        Set(ByVal value As Int32)
          _FileID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_xDMS_FileAuthorizations_UserID() As SIS.QCM.qcmUsers
      Get
        If _FK_xDMS_FileAuthorizations_UserID Is Nothing Then
          _FK_xDMS_FileAuthorizations_UserID = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserID)
        End If
        Return _FK_xDMS_FileAuthorizations_UserID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_FileAuthorizations_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_xDMS_FileAuthorizations_CreatedBy Is Nothing Then
          _FK_xDMS_FileAuthorizations_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_xDMS_FileAuthorizations_CreatedBy
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_FileAuthorizations_FileID() As SIS.xDMS.xDmsFiles
      Get
        If _FK_xDMS_FileAuthorizations_FileID Is Nothing Then
          _FK_xDMS_FileAuthorizations_FileID = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(_FileID)
        End If
        Return _FK_xDMS_FileAuthorizations_FileID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFileAuthorizationsGetNewRecord() As SIS.xDMS.xDmsFileAuthorizations
      Return New SIS.xDMS.xDmsFileAuthorizations()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFileAuthorizationsGetByID(ByVal UserID As String, ByVal FileID As Int32) As SIS.xDMS.xDmsFileAuthorizations
      Dim Results As SIS.xDMS.xDmsFileAuthorizations = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFileAuthorizationsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,UserID.ToString.Length, UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileID",SqlDbType.Int,FileID.ToString.Length, FileID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsFileAuthorizations(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFileAuthorizationsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal FileID As Int32, ByVal CreatedBy As String) As List(Of SIS.xDMS.xDmsFileAuthorizations)
      Dim Results As List(Of SIS.xDMS.xDmsFileAuthorizations) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "UserID"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsFileAuthorizationsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsFileAuthorizationsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserID",SqlDbType.NVarChar,8, IIf(UserID Is Nothing, String.Empty,UserID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FileID",SqlDbType.Int,10, IIf(FileID = Nothing, 0,FileID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy",SqlDbType.NVarChar,8, IIf(CreatedBy Is Nothing, String.Empty,CreatedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFileAuthorizations)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFileAuthorizations(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsFileAuthorizationsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal FileID As Int32, ByVal CreatedBy As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFileAuthorizationsGetByID(ByVal UserID As String, ByVal FileID As Int32, ByVal Filter_UserID As String, ByVal Filter_FileID As Int32, ByVal Filter_CreatedBy As String) As SIS.xDMS.xDmsFileAuthorizations
      Return xDmsFileAuthorizationsGetByID(UserID, FileID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function xDmsFileAuthorizationsInsert(ByVal Record As SIS.xDMS.xDmsFileAuthorizations) As SIS.xDMS.xDmsFileAuthorizations
      Dim _Rec As SIS.xDMS.xDmsFileAuthorizations = SIS.xDMS.xDmsFileAuthorizations.xDmsFileAuthorizationsGetNewRecord()
      With _Rec
        .UserID = Record.UserID
        .FileID = Record.FileID
        .DownloadFile = Record.DownloadFile
        .DeleteFile = Record.DeleteFile
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
      End With
      Return SIS.xDMS.xDmsFileAuthorizations.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.xDmsFileAuthorizations) As SIS.xDMS.xDmsFileAuthorizations
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFileAuthorizationsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileID",SqlDbType.Int,11, Record.FileID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadFile",SqlDbType.Bit,3, Record.DownloadFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteFile",SqlDbType.Bit,3, Record.DeleteFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Record.CreatedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Record.CreatedOn)
          Cmd.Parameters.Add("@Return_UserID", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_UserID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_FileID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FileID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.UserID = Cmd.Parameters("@Return_UserID").Value
          Record.FileID = Cmd.Parameters("@Return_FileID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function xDmsFileAuthorizationsUpdate(ByVal Record As SIS.xDMS.xDmsFileAuthorizations) As SIS.xDMS.xDmsFileAuthorizations
      Dim _Rec As SIS.xDMS.xDmsFileAuthorizations = SIS.xDMS.xDmsFileAuthorizations.xDmsFileAuthorizationsGetByID(Record.UserID, Record.FileID)
      With _Rec
        .DownloadFile = Record.DownloadFile
        .DeleteFile = Record.DeleteFile
        .CreatedBy = Record.CreatedBy
        .CreatedOn = Record.CreatedOn
      End With
      Return SIS.xDMS.xDmsFileAuthorizations.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.xDmsFileAuthorizations) As SIS.xDMS.xDmsFileAuthorizations
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFileAuthorizationsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FileID",SqlDbType.Int,11, Record.FileID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileID",SqlDbType.Int,11, Record.FileID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadFile",SqlDbType.Bit,3, Record.DownloadFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteFile",SqlDbType.Bit,3, Record.DeleteFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy",SqlDbType.NVarChar,9, Record.CreatedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Record.CreatedOn)
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
    Public Shared Function xDmsFileAuthorizationsDelete(ByVal Record As SIS.xDMS.xDmsFileAuthorizations) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFileAuthorizationsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID",SqlDbType.NVarChar,Record.UserID.ToString.Length, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FileID",SqlDbType.Int,Record.FileID.ToString.Length, Record.FileID)
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
