Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  <DataObject()> _
  Partial Public Class xDmsFGroups
    Private Shared _RecordCount As Integer
    Public Property FGroupID As Int32 = 0
    Public Property FGroupName As String = ""
    Public Property RequireExplicitAuthorization As Boolean = False
    Public Property RequireExplicitWorkflow As Boolean = False
    Public Property ReleaseWorkflowID As String = ""
    Public Property ReviseWorkflowID As String = ""
    Public Property UseFileTypeWorkflow As Boolean = False
    Public Property DuplicateFileNameAllowed As Boolean = False
    Public Property xDMS_Workflows1_WorkflowName As String = ""
    Public Property xDMS_Workflows2_WorkflowName As String = ""
    Private _FK_xDMS_FGroups_ReleaseWorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
    Private _FK_xDMS_FGroups_ReviseWorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
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
        Return "" & _FGroupName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _FGroupID
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
    Public Class PKxDmsFGroups
      Private _FGroupID As Int32 = 0
      Public Property FGroupID() As Int32
        Get
          Return _FGroupID
        End Get
        Set(ByVal value As Int32)
          _FGroupID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_xDMS_FGroups_ReleaseWorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_FGroups_ReleaseWorkflowID Is Nothing Then
          _FK_xDMS_FGroups_ReleaseWorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_ReleaseWorkflowID)
        End If
        Return _FK_xDMS_FGroups_ReleaseWorkflowID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_FGroups_ReviseWorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_FGroups_ReviseWorkflowID Is Nothing Then
          _FK_xDMS_FGroups_ReviseWorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_ReviseWorkflowID)
        End If
        Return _FK_xDMS_FGroups_ReviseWorkflowID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFGroupsSelectList(ByVal OrderBy As String) As List(Of SIS.xDMS.xDmsFGroups)
      Dim Results As List(Of SIS.xDMS.xDmsFGroups) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FGroupID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFGroupsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFGroups)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFGroups(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFGroupsGetNewRecord() As SIS.xDMS.xDmsFGroups
      Return New SIS.xDMS.xDmsFGroups()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFGroupsGetByID(ByVal FGroupID As Int32) As SIS.xDMS.xDmsFGroups
      Dim Results As SIS.xDMS.xDmsFGroups = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFGroupsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FGroupID",SqlDbType.Int,FGroupID.ToString.Length, FGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsFGroups(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFGroupsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.xDMS.xDmsFGroups)
      Dim Results As List(Of SIS.xDMS.xDmsFGroups) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FGroupID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsFGroupsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsFGroupsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFGroups)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFGroups(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsFGroupsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function xDmsFGroupsInsert(ByVal Record As SIS.xDMS.xDmsFGroups) As SIS.xDMS.xDmsFGroups
      Dim _Rec As SIS.xDMS.xDmsFGroups = SIS.xDMS.xDmsFGroups.xDmsFGroupsGetNewRecord()
      With _Rec
        .FGroupName = Record.FGroupName
        .RequireExplicitAuthorization = Record.RequireExplicitAuthorization
        .RequireExplicitWorkflow = Record.RequireExplicitWorkflow
        .ReleaseWorkflowID = Record.ReleaseWorkflowID
        .ReviseWorkflowID = Record.ReviseWorkflowID
        .UseFileTypeWorkflow = Record.UseFileTypeWorkflow
        .DuplicateFileNameAllowed = Record.DuplicateFileNameAllowed
      End With
      Return SIS.xDMS.xDmsFGroups.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.xDmsFGroups) As SIS.xDMS.xDmsFGroups
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFGroupsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FGroupName",SqlDbType.NVarChar,51, Iif(Record.FGroupName= "" ,Convert.DBNull, Record.FGroupName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequireExplicitAuthorization",SqlDbType.Bit,3, Record.RequireExplicitAuthorization)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequireExplicitWorkflow",SqlDbType.Bit,3, Record.RequireExplicitWorkflow)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReleaseWorkflowID",SqlDbType.Int,11, Iif(Record.ReleaseWorkflowID= "" ,Convert.DBNull, Record.ReleaseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReviseWorkflowID",SqlDbType.Int,11, Iif(Record.ReviseWorkflowID= "" ,Convert.DBNull, Record.ReviseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UseFileTypeWorkflow",SqlDbType.Bit,3, Record.UseFileTypeWorkflow)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DuplicateFileNameAllowed",SqlDbType.Bit,3, Record.DuplicateFileNameAllowed)
          Cmd.Parameters.Add("@Return_FGroupID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FGroupID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.FGroupID = Cmd.Parameters("@Return_FGroupID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function xDmsFGroupsUpdate(ByVal Record As SIS.xDMS.xDmsFGroups) As SIS.xDMS.xDmsFGroups
      Dim _Rec As SIS.xDMS.xDmsFGroups = SIS.xDMS.xDmsFGroups.xDmsFGroupsGetByID(Record.FGroupID)
      With _Rec
        .FGroupName = Record.FGroupName
        .RequireExplicitAuthorization = Record.RequireExplicitAuthorization
        .RequireExplicitWorkflow = Record.RequireExplicitWorkflow
        .ReleaseWorkflowID = Record.ReleaseWorkflowID
        .ReviseWorkflowID = Record.ReviseWorkflowID
        .UseFileTypeWorkflow = Record.UseFileTypeWorkflow
        .DuplicateFileNameAllowed = Record.DuplicateFileNameAllowed
      End With
      Return SIS.xDMS.xDmsFGroups.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.xDmsFGroups) As SIS.xDMS.xDmsFGroups
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFGroupsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FGroupID",SqlDbType.Int,11, Record.FGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FGroupName",SqlDbType.NVarChar,51, Iif(Record.FGroupName= "" ,Convert.DBNull, Record.FGroupName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequireExplicitAuthorization",SqlDbType.Bit,3, Record.RequireExplicitAuthorization)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequireExplicitWorkflow",SqlDbType.Bit,3, Record.RequireExplicitWorkflow)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReleaseWorkflowID",SqlDbType.Int,11, Iif(Record.ReleaseWorkflowID= "" ,Convert.DBNull, Record.ReleaseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReviseWorkflowID",SqlDbType.Int,11, Iif(Record.ReviseWorkflowID= "" ,Convert.DBNull, Record.ReviseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UseFileTypeWorkflow",SqlDbType.Bit,3, Record.UseFileTypeWorkflow)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DuplicateFileNameAllowed",SqlDbType.Bit,3, Record.DuplicateFileNameAllowed)
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
    Public Shared Function xDmsFGroupsDelete(ByVal Record As SIS.xDMS.xDmsFGroups) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFGroupsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FGroupID",SqlDbType.Int,Record.FGroupID.ToString.Length, Record.FGroupID)
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
    Public Shared Function SelectxDmsFGroupsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFGroupsAutoCompleteList"
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
            Dim Tmp As SIS.xDMS.xDmsFGroups = New SIS.xDMS.xDmsFGroups(Reader)
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
