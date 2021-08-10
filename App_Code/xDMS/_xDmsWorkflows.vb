Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  <DataObject()> _
  Partial Public Class xDmsWorkflows
    Private Shared _RecordCount As Integer
    Public Property WorkflowID As Int32 = 0
    Public Property WorkflowName As String = ""
    Public Property ParentWorkflowID As String = ""
    Public Property InitialStatusID As Int32 = 0
    Public Property FinalStatusID As Int32 = 0
    Public Property UserID As String = ""
    Public Property GroupID As String = ""
    Public Property DynamicSelectUserID As Boolean = False
    Public Property DynamicSelectUserIDFromGroup As Boolean = False
    Public Property SendAlert As Boolean = False
    Public Property ToUserID As Boolean = False
    Public Property ToGroupID As Boolean = False
    Public Property ToFolderAuthorized As Boolean = False
    Public Property ToDefinedAdditional As Boolean = False
    Public Property ToAdditional As String = ""
    Public Property ReturnStatusID As String = ""
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property xDMS_Groups2_Description As String = ""
    Public Property xDMS_States3_StatusName As String = ""
    Public Property xDMS_States4_StatusName As String = ""
    Public Property xDMS_Workflows5_WorkflowName As String = ""
    Private _FK_xDMS_Workflows_UserID As SIS.QCM.qcmUsers = Nothing
    Private _FK_xDMS_Workflows_GroupID As SIS.xDMS.xDmsUGroups = Nothing
    Private _FK_xDMS_Workflows_InitialStatusID As SIS.xDMS.xDmsStates = Nothing
    Private _FK_xDMS_Workflows_FinalStatusID As SIS.xDMS.xDmsStates = Nothing
    Private _FK_xDMS_Workflows_ParentWorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
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
        Return "" & _WorkflowName.ToString.PadRight(50, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _WorkflowID
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
    Public Class PKxDmsWorkflows
      Private _WorkflowID As Int32 = 0
      Public Property WorkflowID() As Int32
        Get
          Return _WorkflowID
        End Get
        Set(ByVal value As Int32)
          _WorkflowID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_xDMS_Workflows_UserID() As SIS.QCM.qcmUsers
      Get
        If _FK_xDMS_Workflows_UserID Is Nothing Then
          _FK_xDMS_Workflows_UserID = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserID)
        End If
        Return _FK_xDMS_Workflows_UserID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_Workflows_GroupID() As SIS.xDMS.xDmsUGroups
      Get
        If _FK_xDMS_Workflows_GroupID Is Nothing Then
          _FK_xDMS_Workflows_GroupID = SIS.xDMS.xDmsUGroups.xDmsUGroupsGetByID(_GroupID)
        End If
        Return _FK_xDMS_Workflows_GroupID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_Workflows_InitialStatusID() As SIS.xDMS.xDmsStates
      Get
        If _FK_xDMS_Workflows_InitialStatusID Is Nothing Then
          _FK_xDMS_Workflows_InitialStatusID = SIS.xDMS.xDmsStates.xDmsStatesGetByID(_InitialStatusID)
        End If
        Return _FK_xDMS_Workflows_InitialStatusID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_Workflows_FinalStatusID() As SIS.xDMS.xDmsStates
      Get
        If _FK_xDMS_Workflows_FinalStatusID Is Nothing Then
          _FK_xDMS_Workflows_FinalStatusID = SIS.xDMS.xDmsStates.xDmsStatesGetByID(_FinalStatusID)
        End If
        Return _FK_xDMS_Workflows_FinalStatusID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_Workflows_ParentWorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_Workflows_ParentWorkflowID Is Nothing Then
          _FK_xDMS_Workflows_ParentWorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_ParentWorkflowID)
        End If
        Return _FK_xDMS_Workflows_ParentWorkflowID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsWorkflowsSelectList(ByVal OrderBy As String) As List(Of SIS.xDMS.xDmsWorkflows)
      Dim Results As List(Of SIS.xDMS.xDmsWorkflows) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "WorkflowID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsWorkflowsSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsWorkflows)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsWorkflows(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsWorkflowsGetNewRecord() As SIS.xDMS.xDmsWorkflows
      Return New SIS.xDMS.xDmsWorkflows()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsWorkflowsGetByID(ByVal WorkflowID As Int32) As SIS.xDMS.xDmsWorkflows
      Dim Results As SIS.xDMS.xDmsWorkflows = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsWorkflowsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowID",SqlDbType.Int,WorkflowID.ToString.Length, WorkflowID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsWorkflows(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsWorkflowsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.xDMS.xDmsWorkflows)
      Dim Results As List(Of SIS.xDMS.xDmsWorkflows) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "WorkflowID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsWorkflowsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsWorkflowsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsWorkflows)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsWorkflows(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsWorkflowsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function xDmsWorkflowsInsert(ByVal Record As SIS.xDMS.xDmsWorkflows) As SIS.xDMS.xDmsWorkflows
      Dim _Rec As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetNewRecord()
      With _Rec
        .WorkflowName = Record.WorkflowName
        .ParentWorkflowID = Record.ParentWorkflowID
        .InitialStatusID = Record.InitialStatusID
        .FinalStatusID = Record.FinalStatusID
        .UserID = Record.UserID
        .GroupID = Record.GroupID
        .DynamicSelectUserID = Record.DynamicSelectUserID
        .DynamicSelectUserIDFromGroup = Record.DynamicSelectUserIDFromGroup
        .SendAlert = Record.SendAlert
        .ToUserID = Record.ToUserID
        .ToGroupID = Record.ToGroupID
        .ToFolderAuthorized = Record.ToFolderAuthorized
        .ToDefinedAdditional = Record.ToDefinedAdditional
        .ToAdditional = Record.ToAdditional
        .ReturnStatusID = Record.ReturnStatusID
      End With
      Return SIS.xDMS.xDmsWorkflows.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.xDmsWorkflows) As SIS.xDMS.xDmsWorkflows
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsWorkflowsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowName",SqlDbType.NVarChar,51, Record.WorkflowName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentWorkflowID",SqlDbType.Int,11, Iif(Record.ParentWorkflowID= "" ,Convert.DBNull, Record.ParentWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitialStatusID",SqlDbType.Int,11, Record.InitialStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinalStatusID",SqlDbType.Int,11, Record.FinalStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Iif(Record.UserID= "" ,Convert.DBNull, Record.UserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID",SqlDbType.Int,11, Iif(Record.GroupID= "" ,Convert.DBNull, Record.GroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DynamicSelectUserID",SqlDbType.Bit,3, Record.DynamicSelectUserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DynamicSelectUserIDFromGroup",SqlDbType.Bit,3, Record.DynamicSelectUserIDFromGroup)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SendAlert",SqlDbType.Bit,3, Record.SendAlert)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToUserID",SqlDbType.Bit,3, Record.ToUserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToGroupID",SqlDbType.Bit,3, Record.ToGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToFolderAuthorized",SqlDbType.Bit,3, Record.ToFolderAuthorized)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToDefinedAdditional",SqlDbType.Bit,3, Record.ToDefinedAdditional)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToAdditional",SqlDbType.NVarChar,1001, Iif(Record.ToAdditional= "" ,Convert.DBNull, Record.ToAdditional))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnStatusID", SqlDbType.Int, 11, If(Record.ReturnStatusID = "", Convert.DBNull, Record.ReturnStatusID))
          Cmd.Parameters.Add("@Return_WorkflowID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_WorkflowID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.WorkflowID = Cmd.Parameters("@Return_WorkflowID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function xDmsWorkflowsUpdate(ByVal Record As SIS.xDMS.xDmsWorkflows) As SIS.xDMS.xDmsWorkflows
      Dim _Rec As SIS.xDMS.xDmsWorkflows = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(Record.WorkflowID)
      With _Rec
        .WorkflowName = Record.WorkflowName
        .ParentWorkflowID = Record.ParentWorkflowID
        .InitialStatusID = Record.InitialStatusID
        .FinalStatusID = Record.FinalStatusID
        .UserID = Record.UserID
        .GroupID = Record.GroupID
        .DynamicSelectUserID = Record.DynamicSelectUserID
        .DynamicSelectUserIDFromGroup = Record.DynamicSelectUserIDFromGroup
        .SendAlert = Record.SendAlert
        .ToUserID = Record.ToUserID
        .ToGroupID = Record.ToGroupID
        .ToFolderAuthorized = Record.ToFolderAuthorized
        .ToDefinedAdditional = Record.ToDefinedAdditional
        .ToAdditional = Record.ToAdditional
        .ReturnStatusID = Record.ReturnStatusID
      End With
      Return SIS.xDMS.xDmsWorkflows.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.xDmsWorkflows) As SIS.xDMS.xDmsWorkflows
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsWorkflowsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_WorkflowID",SqlDbType.Int,11, Record.WorkflowID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowName",SqlDbType.NVarChar,51, Record.WorkflowName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentWorkflowID",SqlDbType.Int,11, Iif(Record.ParentWorkflowID= "" ,Convert.DBNull, Record.ParentWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitialStatusID",SqlDbType.Int,11, Record.InitialStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FinalStatusID",SqlDbType.Int,11, Record.FinalStatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Iif(Record.UserID= "" ,Convert.DBNull, Record.UserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID",SqlDbType.Int,11, Iif(Record.GroupID= "" ,Convert.DBNull, Record.GroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DynamicSelectUserID",SqlDbType.Bit,3, Record.DynamicSelectUserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DynamicSelectUserIDFromGroup",SqlDbType.Bit,3, Record.DynamicSelectUserIDFromGroup)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SendAlert",SqlDbType.Bit,3, Record.SendAlert)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToUserID",SqlDbType.Bit,3, Record.ToUserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToGroupID",SqlDbType.Bit,3, Record.ToGroupID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToFolderAuthorized",SqlDbType.Bit,3, Record.ToFolderAuthorized)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToDefinedAdditional",SqlDbType.Bit,3, Record.ToDefinedAdditional)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ToAdditional",SqlDbType.NVarChar,1001, Iif(Record.ToAdditional= "" ,Convert.DBNull, Record.ToAdditional))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnStatusID", SqlDbType.Int, 11, If(Record.ReturnStatusID = "", Convert.DBNull, Record.ReturnStatusID))
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
    Public Shared Function xDmsWorkflowsDelete(ByVal Record As SIS.xDMS.xDmsWorkflows) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsWorkflowsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_WorkflowID",SqlDbType.Int,Record.WorkflowID.ToString.Length, Record.WorkflowID)
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
    Public Shared Function SelectxDmsWorkflowsAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsWorkflowsAutoCompleteList"
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
            Dim Tmp As SIS.xDMS.xDmsWorkflows = New SIS.xDMS.xDmsWorkflows(Reader)
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
