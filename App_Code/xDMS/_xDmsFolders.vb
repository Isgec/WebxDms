Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Namespace SIS.xDMS
  <DataObject()>
  Partial Public Class xDmsFolders
    Private Shared _RecordCount As Integer
    Public Property FolderID As Int32 = 0
    Public Property FolderName As String = ""
    Public Property ItemTypeID As String = ""
    Public Property ParentFolderID As String = ""
    Public Property StatusBy As String = ""
    Private _StatusOn As String = ""
    Public Property StatusID As Int32 = 0
    Public Property StatusRemarks As String = ""
    Public Property KeyWords As String = ""
    Public Property Active As Boolean = False
    Public Property NodeLevel As Int32 = 0
    Public Property Hseq As Int32 = 0
    Public Property ReleaseWorkflowID As String = ""
    Public Property ReviseWorkflowID As String = ""
    Public Property InitialWorkflowID As String = ""
    Public Property UploadedStatusID As String = ""
    Public Property UseFileTypeWorkflow As Boolean = False
    Public Property DuplicateFileNameAllowed As Boolean = False
    Public Property RequireExplicitAuthorization As Boolean = False
    Public Property RequireExplicitWorkflow As Boolean = False 'Not Used
    Public Property ProjectID As String = ""
    Public Property ElementID As String = ""
    Public Property BPID As String = ""
    Public Property CompanyID As String = ""
    Public Property DivisionID As String = ""
    Public Property DepartmentID As String = ""
    Public Property FoldersCount As Integer = 0
    Public Property FilesCount As Integer = 0
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property xDMS_Folders2_FolderName As String = ""
    Public Property xDMS_ItemTypes3_ItemName As String = ""
    Public Property xDMS_States4_StatusName As String = ""
    Public Property xDMS_Workflows5_WorkflowName As String = ""
    Public Property xDMS_Workflows6_WorkflowName As String = ""
    Public Property xDMS_States7_StatusName As String = ""
    Public Property xDMS_Workflows8_WorkflowName As String = ""
    Private _FK_xDMS_Folders_StatusBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_xDMS_Folders_ParentFolderID As SIS.xDMS.xDmsFolders = Nothing
    Private _FK_xDMS_Folders_ItemTypeID As SIS.xDMS.xDmsItemTypes = Nothing
    Private _FK_xDMS_Folders_StatusID As SIS.xDMS.xDmsStates = Nothing
    Private _FK_xDMS_Folders_ReleaseWorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
    Private _FK_xDMS_Folders_ReviseWorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
    Private _FK_xDMS_Folders_UploadedStatusID As SIS.xDMS.xDmsStates = Nothing
    Private _FK_xDMS_Folders_InitialWorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
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
    Public Property StatusOn() As String
      Get
        If Not _StatusOn = String.Empty Then
          Return Convert.ToDateTime(_StatusOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _StatusOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _StatusOn = ""
        Else
          _StatusOn = value
        End If
      End Set
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return "" & _FolderName.ToString.PadRight(250, " ")
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _FolderID
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
    Public Class PKxDmsFolders
      Private _FolderID As Int32 = 0
      Public Property FolderID() As Int32
        Get
          Return _FolderID
        End Get
        Set(ByVal value As Int32)
          _FolderID = value
        End Set
      End Property
    End Class
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_Folders_StatusBy() As SIS.QCM.qcmUsers
      Get
        If _FK_xDMS_Folders_StatusBy Is Nothing Then
          _FK_xDMS_Folders_StatusBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_StatusBy)
        End If
        Return _FK_xDMS_Folders_StatusBy
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_Folders_ParentFolderID() As SIS.xDMS.xDmsFolders
      Get
        If _FK_xDMS_Folders_ParentFolderID Is Nothing Then
          If ParentFolderID <> "" Then _FK_xDMS_Folders_ParentFolderID = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(_ParentFolderID)
        End If
        Return _FK_xDMS_Folders_ParentFolderID
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_Folders_ItemTypeID() As SIS.xDMS.xDmsItemTypes
      Get
        If _FK_xDMS_Folders_ItemTypeID Is Nothing Then
          _FK_xDMS_Folders_ItemTypeID = SIS.xDMS.xDmsItemTypes.xDmsItemTypesGetByID(_ItemTypeID)
        End If
        Return _FK_xDMS_Folders_ItemTypeID
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_Folders_StatusID() As SIS.xDMS.xDmsStates
      Get
        If _FK_xDMS_Folders_StatusID Is Nothing Then
          _FK_xDMS_Folders_StatusID = SIS.xDMS.xDmsStates.xDmsStatesGetByID(_StatusID)
        End If
        Return _FK_xDMS_Folders_StatusID
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_Folders_ReleaseWorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_Folders_ReleaseWorkflowID Is Nothing Then
          If ReleaseWorkflowID <> "" Then _FK_xDMS_Folders_ReleaseWorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_ReleaseWorkflowID)
        End If
        Return _FK_xDMS_Folders_ReleaseWorkflowID
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_Folders_ReviseWorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_Folders_ReviseWorkflowID Is Nothing Then
          If ReviseWorkflowID <> "" Then _FK_xDMS_Folders_ReviseWorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_ReviseWorkflowID)
        End If
        Return _FK_xDMS_Folders_ReviseWorkflowID
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_Folders_UploadedStatusID() As SIS.xDMS.xDmsStates
      Get
        If _FK_xDMS_Folders_UploadedStatusID Is Nothing Then
          If UploadedStatusID <> "" Then _FK_xDMS_Folders_UploadedStatusID = SIS.xDMS.xDmsStates.xDmsStatesGetByID(_UploadedStatusID)
        End If
        Return _FK_xDMS_Folders_UploadedStatusID
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_Folders_InitialWorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_Folders_InitialWorkflowID Is Nothing Then
          If InitialWorkflowID <> "" Then _FK_xDMS_Folders_InitialWorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_InitialWorkflowID)
        End If
        Return _FK_xDMS_Folders_InitialWorkflowID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function xDmsFoldersSelectList(ByVal OrderBy As String) As List(Of SIS.xDMS.xDmsFolders)
      Dim Results As List(Of SIS.xDMS.xDmsFolders) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FolderID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFoldersSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFolders)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFolders(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function xDmsFoldersGetNewRecord() As SIS.xDMS.xDmsFolders
      Return New SIS.xDMS.xDmsFolders()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function xDmsFoldersGetByID(ByVal FolderID As Int32) As SIS.xDMS.xDmsFolders
      Dim Results As SIS.xDMS.xDmsFolders = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFoldersSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID", SqlDbType.Int, FolderID.ToString.Length, FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsFolders(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function xDmsFoldersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FolderID As Int32, ByVal ParentFolderID As Int32, ByVal StatusBy As String) As List(Of SIS.xDMS.xDmsFolders)
      Dim Results As List(Of SIS.xDMS.xDmsFolders) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FolderID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsFoldersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsFoldersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FolderID", SqlDbType.Int, 10, IIf(FolderID = Nothing, 0, FolderID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ParentFolderID", SqlDbType.Int, 10, IIf(ParentFolderID = Nothing, 0, ParentFolderID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusBy", SqlDbType.NVarChar, 8, IIf(StatusBy Is Nothing, String.Empty, StatusBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFolders)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFolders(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsFoldersSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FolderID As Int32, ByVal ParentFolderID As Int32, ByVal StatusBy As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function xDmsFoldersGetByID(ByVal FolderID As Int32, ByVal Filter_FolderID As Int32, ByVal Filter_ParentFolderID As Int32, ByVal Filter_StatusBy As String) As SIS.xDMS.xDmsFolders
      Return xDmsFoldersGetByID(FolderID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function xDmsFoldersInsert(ByVal Record As SIS.xDMS.xDmsFolders) As SIS.xDMS.xDmsFolders
      Dim _Rec As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetNewRecord()
      With _Rec
        .FolderName = Record.FolderName
        .ItemTypeID = Record.ItemTypeID
        .ParentFolderID = Record.ParentFolderID
        .StatusBy = Record.StatusBy
        .StatusOn = Record.StatusOn
        .StatusID = Record.StatusID
        .NodeLevel = Record.NodeLevel
        .Hseq = Record.Hseq
        .RequireExplicitAuthorization = Record.RequireExplicitAuthorization
        .StatusRemarks = Record.StatusRemarks
        .KeyWords = Record.KeyWords
        .Active = Record.Active
        .RequireExplicitWorkflow = Record.RequireExplicitWorkflow
        .ReleaseWorkflowID = Record.ReleaseWorkflowID
        .ReviseWorkflowID = Record.ReviseWorkflowID
        .InitialWorkflowID = Record.InitialWorkflowID
        .UploadedStatusID = Record.UploadedStatusID
        .UseFileTypeWorkflow = Record.UseFileTypeWorkflow
        .DuplicateFileNameAllowed = Record.DuplicateFileNameAllowed
      End With
      Return SIS.xDMS.xDmsFolders.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.xDmsFolders) As SIS.xDMS.xDmsFolders
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFoldersInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderName", SqlDbType.NVarChar, 251, Record.FolderName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemTypeID", SqlDbType.NVarChar, 11, IIf(Record.ItemTypeID = "", Convert.DBNull, Record.ItemTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentFolderID", SqlDbType.Int, 11, IIf(Record.ParentFolderID = "", Convert.DBNull, Record.ParentFolderID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusBy", SqlDbType.NVarChar, 9, IIf(Record.StatusBy = "", Convert.DBNull, Record.StatusBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusOn", SqlDbType.DateTime, 21, IIf(Record.StatusOn = "", Convert.DBNull, Record.StatusOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID", SqlDbType.Int, 11, Record.StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NodeLevel", SqlDbType.Int, 11, Record.NodeLevel)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Hseq", SqlDbType.Int, 11, Record.Hseq)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequireExplicitAuthorization", SqlDbType.Bit, 3, Record.RequireExplicitAuthorization)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusRemarks", SqlDbType.NVarChar, 501, IIf(Record.StatusRemarks = "", Convert.DBNull, Record.StatusRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWords", SqlDbType.NVarChar, 201, IIf(Record.KeyWords = "", Convert.DBNull, Record.KeyWords))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active", SqlDbType.Bit, 3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequireExplicitWorkflow", SqlDbType.Bit, 3, Record.RequireExplicitWorkflow)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReleaseWorkflowID", SqlDbType.Int, 11, IIf(Record.ReleaseWorkflowID = "", Convert.DBNull, Record.ReleaseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReviseWorkflowID", SqlDbType.Int, 11, IIf(Record.ReviseWorkflowID = "", Convert.DBNull, Record.ReviseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitialWorkflowID", SqlDbType.Int, 11, IIf(Record.InitialWorkflowID = "", Convert.DBNull, Record.InitialWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadedStatusID", SqlDbType.Int, 11, IIf(Record.UploadedStatusID = "", Convert.DBNull, Record.UploadedStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UseFileTypeWorkflow", SqlDbType.Bit, 3, Record.UseFileTypeWorkflow)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DuplicateFileNameAllowed", SqlDbType.Bit, 3, Record.DuplicateFileNameAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID", SqlDbType.NVarChar, 9, IIf(Record.ElementID = "", Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID", SqlDbType.NVarChar, 10, IIf(Record.BPID = "", Convert.DBNull, Record.BPID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CompanyID", SqlDbType.NVarChar, 7, IIf(Record.CompanyID = "", Convert.DBNull, Record.CompanyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID", SqlDbType.NVarChar, 7, IIf(Record.DivisionID = "", Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.DepartmentID = "", Convert.DBNull, Record.DepartmentID))
          Cmd.Parameters.Add("@Return_FolderID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FolderID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.FolderID = Cmd.Parameters("@Return_FolderID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function xDmsFoldersUpdate(ByVal Record As SIS.xDMS.xDmsFolders) As SIS.xDMS.xDmsFolders
      Dim _Rec As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(Record.FolderID)
      With _Rec
        .FolderName = Record.FolderName
        .ItemTypeID = Record.ItemTypeID
        .ParentFolderID = Record.ParentFolderID
        .StatusBy = Record.StatusBy
        .StatusOn = Record.StatusOn
        .StatusID = Record.StatusID
        .NodeLevel = Record.NodeLevel
        .Hseq = Record.Hseq
        .RequireExplicitAuthorization = Record.RequireExplicitAuthorization
        .StatusRemarks = Record.StatusRemarks
        .KeyWords = Record.KeyWords
        .Active = Record.Active
        .RequireExplicitWorkflow = Record.RequireExplicitWorkflow
        .ReleaseWorkflowID = Record.ReleaseWorkflowID
        .ReviseWorkflowID = Record.ReviseWorkflowID
        .InitialWorkflowID = Record.InitialWorkflowID
        .UploadedStatusID = Record.UploadedStatusID
        .UseFileTypeWorkflow = Record.UseFileTypeWorkflow
        .DuplicateFileNameAllowed = Record.DuplicateFileNameAllowed
      End With
      Return SIS.xDMS.xDmsFolders.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.xDmsFolders) As SIS.xDMS.xDmsFolders
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFoldersUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FolderID", SqlDbType.Int, 11, Record.FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderName", SqlDbType.NVarChar, 251, Record.FolderName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemTypeID", SqlDbType.NVarChar, 11, IIf(Record.ItemTypeID = "", Convert.DBNull, Record.ItemTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentFolderID", SqlDbType.Int, 11, IIf(Record.ParentFolderID = "", Convert.DBNull, Record.ParentFolderID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusBy", SqlDbType.NVarChar, 9, IIf(Record.StatusBy = "", Convert.DBNull, Record.StatusBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusOn", SqlDbType.DateTime, 21, IIf(Record.StatusOn = "", Convert.DBNull, Record.StatusOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID", SqlDbType.Int, 11, Record.StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NodeLevel", SqlDbType.Int, 11, Record.NodeLevel)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Hseq", SqlDbType.Int, 11, Record.Hseq)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequireExplicitAuthorization", SqlDbType.Bit, 3, Record.RequireExplicitAuthorization)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusRemarks", SqlDbType.NVarChar, 501, IIf(Record.StatusRemarks = "", Convert.DBNull, Record.StatusRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWords", SqlDbType.NVarChar, 201, IIf(Record.KeyWords = "", Convert.DBNull, Record.KeyWords))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active", SqlDbType.Bit, 3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequireExplicitWorkflow", SqlDbType.Bit, 3, Record.RequireExplicitWorkflow)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReleaseWorkflowID", SqlDbType.Int, 11, IIf(Record.ReleaseWorkflowID = "", Convert.DBNull, Record.ReleaseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReviseWorkflowID", SqlDbType.Int, 11, IIf(Record.ReviseWorkflowID = "", Convert.DBNull, Record.ReviseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitialWorkflowID", SqlDbType.Int, 11, IIf(Record.InitialWorkflowID = "", Convert.DBNull, Record.InitialWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadedStatusID", SqlDbType.Int, 11, IIf(Record.UploadedStatusID = "", Convert.DBNull, Record.UploadedStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UseFileTypeWorkflow", SqlDbType.Bit, 3, Record.UseFileTypeWorkflow)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DuplicateFileNameAllowed", SqlDbType.Bit, 3, Record.DuplicateFileNameAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID", SqlDbType.NVarChar, 9, IIf(Record.ElementID = "", Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID", SqlDbType.NVarChar, 10, IIf(Record.BPID = "", Convert.DBNull, Record.BPID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CompanyID", SqlDbType.NVarChar, 7, IIf(Record.CompanyID = "", Convert.DBNull, Record.CompanyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID", SqlDbType.NVarChar, 7, IIf(Record.DivisionID = "", Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.DepartmentID = "", Convert.DBNull, Record.DepartmentID))
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
    Public Shared Function xDmsFoldersDelete(ByVal Record As SIS.xDMS.xDmsFolders) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFoldersDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FolderID", SqlDbType.Int, Record.FolderID.ToString.Length, Record.FolderID)
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
    Public Shared Function SelectxDmsFoldersAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFoldersAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(250, " "), ""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.xDMS.xDmsFolders = New SIS.xDMS.xDmsFolders(Reader)
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
