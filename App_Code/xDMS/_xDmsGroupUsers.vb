Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  <DataObject()> _
  Partial Public Class xDmsGroupUsers
    Private Shared _RecordCount As Integer
    Public Property GroupID As Int32 = 0
    Public Property UserID As String = ""
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property xDMS_Groups2_Description As String = ""
    Private _FK_xDMS_GroupUsers_UserID As SIS.QCM.qcmUsers = Nothing
    Private _FK_xDMS_GroupUsers_GroupID As SIS.xDMS.xDmsGroups = Nothing
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
        Return _GroupID & "|" & _UserID
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
    Public Class PKxDmsGroupUsers
      Private _GroupID As Int32 = 0
      Private _UserID As String = ""
      Public Property GroupID() As Int32
        Get
          Return _GroupID
        End Get
        Set(ByVal value As Int32)
          _GroupID = value
        End Set
      End Property
      Public Property UserID() As String
        Get
          Return _UserID
        End Get
        Set(ByVal value As String)
          _UserID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_xDMS_GroupUsers_UserID() As SIS.QCM.qcmUsers
      Get
        If _FK_xDMS_GroupUsers_UserID Is Nothing Then
          _FK_xDMS_GroupUsers_UserID = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserID)
        End If
        Return _FK_xDMS_GroupUsers_UserID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_GroupUsers_GroupID() As SIS.xDMS.xDmsGroups
      Get
        If _FK_xDMS_GroupUsers_GroupID Is Nothing Then
          _FK_xDMS_GroupUsers_GroupID = SIS.xDMS.xDmsGroups.xDmsGroupsGetByID(_GroupID)
        End If
        Return _FK_xDMS_GroupUsers_GroupID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsGroupUsersGetNewRecord() As SIS.xDMS.xDmsGroupUsers
      Return New SIS.xDMS.xDmsGroupUsers()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsGroupUsersGetByID(ByVal GroupID As Int32, ByVal UserID As String) As SIS.xDMS.xDmsGroupUsers
      Dim Results As SIS.xDMS.xDmsGroupUsers = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsGroupUsersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID",SqlDbType.Int,GroupID.ToString.Length, GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,UserID.ToString.Length, UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsGroupUsers(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsGroupUsersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal GroupID As Int32) As List(Of SIS.xDMS.xDmsGroupUsers)
      Dim Results As List(Of SIS.xDMS.xDmsGroupUsers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "UserID"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsGroupUsersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsGroupUsersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_GroupID",SqlDbType.Int,10, IIf(GroupID = Nothing, 0,GroupID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsGroupUsers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsGroupUsers(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsGroupUsersSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal GroupID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsGroupUsersGetByID(ByVal GroupID As Int32, ByVal UserID As String, ByVal Filter_GroupID As Int32) As SIS.xDMS.xDmsGroupUsers
      Return xDmsGroupUsersGetByID(GroupID, UserID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function xDmsGroupUsersInsert(ByVal Record As SIS.xDMS.xDmsGroupUsers) As SIS.xDMS.xDmsGroupUsers
      Dim _Rec As SIS.xDMS.xDmsGroupUsers = SIS.xDMS.xDmsGroupUsers.xDmsGroupUsersGetNewRecord()
      With _Rec
        .GroupID = Record.GroupID
        .UserID = Record.UserID
      End With
      Return SIS.xDMS.xDmsGroupUsers.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.xDmsGroupUsers) As SIS.xDMS.xDmsGroupUsers
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsGroupUsersInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID",SqlDbType.Int,11, Record.GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Record.UserID)
          Cmd.Parameters.Add("@Return_GroupID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_GroupID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_UserID", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_UserID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.GroupID = Cmd.Parameters("@Return_GroupID").Value
          Record.UserID = Cmd.Parameters("@Return_UserID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function xDmsGroupUsersUpdate(ByVal Record As SIS.xDMS.xDmsGroupUsers) As SIS.xDMS.xDmsGroupUsers
      Dim _Rec As SIS.xDMS.xDmsGroupUsers = SIS.xDMS.xDmsGroupUsers.xDmsGroupUsersGetByID(Record.GroupID, Record.UserID)
      With _Rec
      End With
      Return SIS.xDMS.xDmsGroupUsers.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.xDmsGroupUsers) As SIS.xDMS.xDmsGroupUsers
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsGroupUsersUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GroupID",SqlDbType.Int,11, Record.GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID",SqlDbType.NVarChar,9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID",SqlDbType.Int,11, Record.GroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Record.UserID)
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
    Public Shared Function xDmsGroupUsersDelete(ByVal Record As SIS.xDMS.xDmsGroupUsers) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsGroupUsersDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_GroupID",SqlDbType.Int,Record.GroupID.ToString.Length, Record.GroupID)
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
