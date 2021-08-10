Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  <DataObject()> _
  Partial Public Class xDmsERPTransmittalTypes
    Private Shared _RecordCount As Integer
    Public Property TransmittalTypeID As Int32 = 0
    Public Property TransmittalTypeName As String = ""
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _TransmittalTypeName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _TransmittalTypeID
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
    Public Class PKxDmsERPTransmittalTypes
      Private _TransmittalTypeID As Int32 = 0
      Public Property TransmittalTypeID() As Int32
        Get
          Return _TransmittalTypeID
        End Get
        Set(ByVal value As Int32)
          _TransmittalTypeID = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsERPTransmittalTypesSelectList(ByVal OrderBy As String) As List(Of SIS.xDMS.xDmsERPTransmittalTypes)
      Dim Results As List(Of SIS.xDMS.xDmsERPTransmittalTypes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsERPTransmittalTypesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsERPTransmittalTypes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsERPTransmittalTypes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function xDmsERPTransmittalTypesGetNewRecord() As SIS.xDMS.xDmsERPTransmittalTypes
      Return New SIS.xDMS.xDmsERPTransmittalTypes()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function xDmsERPTransmittalTypesGetByID(ByVal TransmittalTypeID As Int32) As SIS.xDMS.xDmsERPTransmittalTypes
      Dim Results As SIS.xDMS.xDmsERPTransmittalTypes = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsERPTransmittalTypesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransmittalTypeID", SqlDbType.Int, TransmittalTypeID.ToString.Length, TransmittalTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsERPTransmittalTypes(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function xDmsERPTransmittalTypesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.xDMS.xDmsERPTransmittalTypes)
      Dim Results As List(Of SIS.xDMS.xDmsERPTransmittalTypes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsERPTransmittalTypesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsERPTransmittalTypesSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsERPTransmittalTypes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsERPTransmittalTypes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsERPTransmittalTypesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function xDmsERPTransmittalTypesInsert(ByVal Record As SIS.xDMS.xDmsERPTransmittalTypes) As SIS.xDMS.xDmsERPTransmittalTypes
      Dim _Rec As SIS.xDMS.xDmsERPTransmittalTypes = SIS.xDMS.xDmsERPTransmittalTypes.xDmsERPTransmittalTypesGetNewRecord()
      With _Rec
        .TransmittalTypeID = Record.TransmittalTypeID
        .TransmittalTypeName = Record.TransmittalTypeName
      End With
      Return SIS.xDMS.xDmsERPTransmittalTypes.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.xDmsERPTransmittalTypes) As SIS.xDMS.xDmsERPTransmittalTypes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsERPTransmittalTypesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransmittalTypeID", SqlDbType.Int, 11, Record.TransmittalTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransmittalTypeName", SqlDbType.NVarChar, 51, IIf(Record.TransmittalTypeName = "", Convert.DBNull, Record.TransmittalTypeName))
          Cmd.Parameters.Add("@Return_TransmittalTypeID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_TransmittalTypeID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.TransmittalTypeID = Cmd.Parameters("@Return_TransmittalTypeID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function xDmsERPTransmittalTypesUpdate(ByVal Record As SIS.xDMS.xDmsERPTransmittalTypes) As SIS.xDMS.xDmsERPTransmittalTypes
      Dim _Rec As SIS.xDMS.xDmsERPTransmittalTypes = SIS.xDMS.xDmsERPTransmittalTypes.xDmsERPTransmittalTypesGetByID(Record.TransmittalTypeID)
      With _Rec
        .TransmittalTypeName = Record.TransmittalTypeName
      End With
      Return SIS.xDMS.xDmsERPTransmittalTypes.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.xDmsERPTransmittalTypes) As SIS.xDMS.xDmsERPTransmittalTypes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsERPTransmittalTypesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TransmittalTypeID", SqlDbType.Int, 11, Record.TransmittalTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransmittalTypeID", SqlDbType.Int, 11, Record.TransmittalTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransmittalTypeName", SqlDbType.NVarChar, 51, IIf(Record.TransmittalTypeName = "", Convert.DBNull, Record.TransmittalTypeName))
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)>
    Public Shared Function xDmsERPTransmittalTypesDelete(ByVal Record As SIS.xDMS.xDmsERPTransmittalTypes) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsERPTransmittalTypesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_TransmittalTypeID", SqlDbType.Int, Record.TransmittalTypeID.ToString.Length, Record.TransmittalTypeID)
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
    '    Autocomplete Method
    Public Shared Function SelectxDmsERPTransmittalTypesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsERPTransmittalTypesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix),0,IIf(Prefix.ToLower=Prefix, 0, 1)))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.xDMS.xDmsERPTransmittalTypes = New SIS.xDMS.xDmsERPTransmittalTypes(Reader)
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(Tmp.DisplayField, Tmp.PrimaryKey))
          End While
          Reader.Close()
        End Using
      End Using
      Return Results.ToArray
    End Function
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
