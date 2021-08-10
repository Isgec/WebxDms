Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  <DataObject()> _
  Partial Public Class xDmsFileTypes
    Private Shared _RecordCount As Integer
    Public Property FileTypeID As Int32 = 0
    Public Property FileTypeName As String = ""
    Public Property BasedOnFileExtension As Boolean = False
    Public Property FileExtentionList As String = ""
    Public Property ReleaseWorkflowID As String = ""
    Public Property ReviseWorkflowID As String = ""
    Public Property xDMS_Workflows1_WorkflowName As String = ""
    Public Property xDMS_Workflows2_WorkflowName As String = ""
    Private _FK_xDMS_FileTypes_ReleaseWorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
    Private _FK_xDMS_FileTypes_ReviseWorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
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
        Return "" & _FileTypeName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _FileTypeID
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
    Public Class PKxDmsFileTypes
      Private _FileTypeID As Int32 = 0
      Public Property FileTypeID() As Int32
        Get
          Return _FileTypeID
        End Get
        Set(ByVal value As Int32)
          _FileTypeID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_xDMS_FileTypes_ReleaseWorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_FileTypes_ReleaseWorkflowID Is Nothing Then
          _FK_xDMS_FileTypes_ReleaseWorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_ReleaseWorkflowID)
        End If
        Return _FK_xDMS_FileTypes_ReleaseWorkflowID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_FileTypes_ReviseWorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_FileTypes_ReviseWorkflowID Is Nothing Then
          _FK_xDMS_FileTypes_ReviseWorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_ReviseWorkflowID)
        End If
        Return _FK_xDMS_FileTypes_ReviseWorkflowID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFileTypesSelectList(ByVal OrderBy As String) As List(Of SIS.xDMS.xDmsFileTypes)
      Dim Results As List(Of SIS.xDMS.xDmsFileTypes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FileTypeID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFileTypesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFileTypes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFileTypes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFileTypesGetNewRecord() As SIS.xDMS.xDmsFileTypes
      Return New SIS.xDMS.xDmsFileTypes()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFileTypesGetByID(ByVal FileTypeID As Int32) As SIS.xDMS.xDmsFileTypes
      Dim Results As SIS.xDMS.xDmsFileTypes = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFileTypesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileTypeID",SqlDbType.Int,FileTypeID.ToString.Length, FileTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsFileTypes(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFileTypesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.xDMS.xDmsFileTypes)
      Dim Results As List(Of SIS.xDMS.xDmsFileTypes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FileTypeID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsFileTypesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsFileTypesSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFileTypes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFileTypes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsFileTypesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function xDmsFileTypesInsert(ByVal Record As SIS.xDMS.xDmsFileTypes) As SIS.xDMS.xDmsFileTypes
      Dim _Rec As SIS.xDMS.xDmsFileTypes = SIS.xDMS.xDmsFileTypes.xDmsFileTypesGetNewRecord()
      With _Rec
        .FileTypeName = Record.FileTypeName
        .BasedOnFileExtension = Record.BasedOnFileExtension
        .FileExtentionList = Record.FileExtentionList
        .ReleaseWorkflowID = Record.ReleaseWorkflowID
        .ReviseWorkflowID = Record.ReviseWorkflowID
      End With
      Return SIS.xDMS.xDmsFileTypes.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.xDmsFileTypes) As SIS.xDMS.xDmsFileTypes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFileTypesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileTypeName",SqlDbType.NVarChar,51, Iif(Record.FileTypeName= "" ,Convert.DBNull, Record.FileTypeName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BasedOnFileExtension",SqlDbType.Bit,3, Record.BasedOnFileExtension)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileExtentionList",SqlDbType.NVarChar,501, Iif(Record.FileExtentionList= "" ,Convert.DBNull, Record.FileExtentionList))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReleaseWorkflowID",SqlDbType.Int,11, Iif(Record.ReleaseWorkflowID= "" ,Convert.DBNull, Record.ReleaseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReviseWorkflowID",SqlDbType.Int,11, Iif(Record.ReviseWorkflowID= "" ,Convert.DBNull, Record.ReviseWorkflowID))
          Cmd.Parameters.Add("@Return_FileTypeID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FileTypeID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.FileTypeID = Cmd.Parameters("@Return_FileTypeID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function xDmsFileTypesUpdate(ByVal Record As SIS.xDMS.xDmsFileTypes) As SIS.xDMS.xDmsFileTypes
      Dim _Rec As SIS.xDMS.xDmsFileTypes = SIS.xDMS.xDmsFileTypes.xDmsFileTypesGetByID(Record.FileTypeID)
      With _Rec
        .FileTypeName = Record.FileTypeName
        .BasedOnFileExtension = Record.BasedOnFileExtension
        .FileExtentionList = Record.FileExtentionList
        .ReleaseWorkflowID = Record.ReleaseWorkflowID
        .ReviseWorkflowID = Record.ReviseWorkflowID
      End With
      Return SIS.xDMS.xDmsFileTypes.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.xDmsFileTypes) As SIS.xDMS.xDmsFileTypes
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFileTypesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FileTypeID",SqlDbType.Int,11, Record.FileTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileTypeName",SqlDbType.NVarChar,51, Iif(Record.FileTypeName= "" ,Convert.DBNull, Record.FileTypeName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BasedOnFileExtension",SqlDbType.Bit,3, Record.BasedOnFileExtension)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileExtentionList",SqlDbType.NVarChar,501, Iif(Record.FileExtentionList= "" ,Convert.DBNull, Record.FileExtentionList))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReleaseWorkflowID",SqlDbType.Int,11, Iif(Record.ReleaseWorkflowID= "" ,Convert.DBNull, Record.ReleaseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReviseWorkflowID",SqlDbType.Int,11, Iif(Record.ReviseWorkflowID= "" ,Convert.DBNull, Record.ReviseWorkflowID))
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
    Public Shared Function xDmsFileTypesDelete(ByVal Record As SIS.xDMS.xDmsFileTypes) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFileTypesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FileTypeID",SqlDbType.Int,Record.FileTypeID.ToString.Length, Record.FileTypeID)
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
    Public Shared Function SelectxDmsFileTypesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFileTypesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(50, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.xDMS.xDmsFileTypes = New SIS.xDMS.xDmsFileTypes(Reader)
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
