Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Namespace SIS.xDMS
  <DataObject()>
  Partial Public Class xDmsFolderAuthorizations
    Private Shared _RecordCount As Integer
    Public Property UserID As String = ""
    Public Property FolderID As Int32 = 0
    Public Property CreateFolder As Boolean = False
    Public Property UpdateFolder As Boolean = False
    Public Property DeleteFolder As Boolean = False
    Public Property UploadFile As Boolean = False
    Public Property DownloadFile As Boolean = False
    Public Property DeleteFile As Boolean = False
    Public Property CanAuthorizeFolder As Boolean = False
    Public Property CanPassAuthorization As Boolean = False
    Public Property CanViewAllRevisions As Boolean = True
    Public Property RequireExplicitAuthorization As Boolean = False
    Public Property RequireExplicitWorkflow As Boolean = False
    Public Property ReleaseWorkflowID As String = ""
    Public Property ReviseWorkflowID As String = ""
    Public Property InitialWorkflowID As String = ""
    Public Property UploadedStatusID As String = ""
    Public Property UseFileTypeWorkflow As Boolean = False
    Public Property DuplicateFileNameAllowed As Boolean = False
    Public Property ShowAtRoot As Boolean = False
    Public Property IsAdmin As Boolean = False
    Public Property GroupID As String = ""
    Public Property FGroupID As String = ""
    Public Property CreatedBy As String = ""
    Private _CreatedOn As String = ""
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property aspnet_Users2_UserFullName As String = ""
    Public Property xDMS_Folders3_FolderName As String = ""
    Public Property xDMS_FGroups4_FGroupName As String = ""
    Public Property xDMS_Groups5_Description As String = ""
    Public Property xDMS_Workflows6_WorkflowName As String = ""
    Public Property xDMS_Workflows7_WorkflowName As String = ""
    Public Property xDMS_States8_StatusName As String = ""
    Public Property xDMS_Workflows9_WorkflowName As String = ""
    Private _FK_xDMS_FolderAuthorizations_CreatedBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_xDMS_FolderAuthorizations_UserID As SIS.QCM.qcmUsers = Nothing
    Private _FK_xDMS_FolderAuthorizations_FolderID As SIS.xDMS.xDmsFolders = Nothing
    Private _FK_xDMS_FolderAuthorizations_FGroupID As SIS.xDMS.xDmsFGroups = Nothing
    Private _FK_xDMS_FolderAuthorizations_GroupID As SIS.xDMS.xDmsUGroups = Nothing
    Private _FK_xDMS_FolderAuthorizations_ReleaseWorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
    Private _FK_xDMS_FolderAuthorizations_ReviseWorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
    Private _FK_xDMS_FolderAuthorizations_UploadedStatusID As SIS.xDMS.xDmsStates = Nothing
    Private _FK_xDMS_FolderAuthorizations_InitialWorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
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
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _UserID & "|" & _FolderID
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
    Public Class PKxDmsFolderAuthorizations
      Private _UserID As String = ""
      Private _FolderID As Int32 = 0
      Public Property UserID() As String
        Get
          Return _UserID
        End Get
        Set(ByVal value As String)
          _UserID = value
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
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_FolderAuthorizations_CreatedBy() As SIS.QCM.qcmUsers
      Get
        If _FK_xDMS_FolderAuthorizations_CreatedBy Is Nothing Then
          _FK_xDMS_FolderAuthorizations_CreatedBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_CreatedBy)
        End If
        Return _FK_xDMS_FolderAuthorizations_CreatedBy
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_FolderAuthorizations_UserID() As SIS.QCM.qcmUsers
      Get
        If _FK_xDMS_FolderAuthorizations_UserID Is Nothing Then
          _FK_xDMS_FolderAuthorizations_UserID = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserID)
        End If
        Return _FK_xDMS_FolderAuthorizations_UserID
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_FolderAuthorizations_FolderID() As SIS.xDMS.xDmsFolders
      Get
        If _FK_xDMS_FolderAuthorizations_FolderID Is Nothing Then
          _FK_xDMS_FolderAuthorizations_FolderID = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(_FolderID)
        End If
        Return _FK_xDMS_FolderAuthorizations_FolderID
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_FolderAuthorizations_FGroupID() As SIS.xDMS.xDmsFGroups
      Get
        If _FK_xDMS_FolderAuthorizations_FGroupID Is Nothing Then
          _FK_xDMS_FolderAuthorizations_FGroupID = SIS.xDMS.xDmsFGroups.xDmsFGroupsGetByID(_FGroupID)
        End If
        Return _FK_xDMS_FolderAuthorizations_FGroupID
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_FolderAuthorizations_GroupID() As SIS.xDMS.xDmsUGroups
      Get
        If _FK_xDMS_FolderAuthorizations_GroupID Is Nothing Then
          _FK_xDMS_FolderAuthorizations_GroupID = SIS.xDMS.xDmsUGroups.xDmsUGroupsGetByID(_GroupID)
        End If
        Return _FK_xDMS_FolderAuthorizations_GroupID
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_FolderAuthorizations_ReleaseWorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_FolderAuthorizations_ReleaseWorkflowID Is Nothing Then
          _FK_xDMS_FolderAuthorizations_ReleaseWorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_ReleaseWorkflowID)
        End If
        Return _FK_xDMS_FolderAuthorizations_ReleaseWorkflowID
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_FolderAuthorizations_ReviseWorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_FolderAuthorizations_ReviseWorkflowID Is Nothing Then
          _FK_xDMS_FolderAuthorizations_ReviseWorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_ReviseWorkflowID)
        End If
        Return _FK_xDMS_FolderAuthorizations_ReviseWorkflowID
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_FolderAuthorizations_UploadedStatusID() As SIS.xDMS.xDmsStates
      Get
        If _FK_xDMS_FolderAuthorizations_UploadedStatusID Is Nothing Then
          _FK_xDMS_FolderAuthorizations_UploadedStatusID = SIS.xDMS.xDmsStates.xDmsStatesGetByID(_UploadedStatusID)
        End If
        Return _FK_xDMS_FolderAuthorizations_UploadedStatusID
      End Get
    End Property
    <ScriptIgnore>
    Public ReadOnly Property FK_xDMS_FolderAuthorizations_InitialWorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_FolderAuthorizations_InitialWorkflowID Is Nothing Then
          _FK_xDMS_FolderAuthorizations_InitialWorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_InitialWorkflowID)
        End If
        Return _FK_xDMS_FolderAuthorizations_InitialWorkflowID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function xDmsFolderAuthorizationsGetNewRecord() As SIS.xDMS.xDmsFolderAuthorizations
      Return New SIS.xDMS.xDmsFolderAuthorizations()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function xDmsFolderAuthorizationsGetByID(ByVal UserID As String, ByVal FolderID As Int32) As SIS.xDMS.xDmsFolderAuthorizations
      Dim Results As SIS.xDMS.xDmsFolderAuthorizations = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFolderAuthorizationsSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID", SqlDbType.NVarChar, UserID.ToString.Length, UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID", SqlDbType.Int, FolderID.ToString.Length, FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsFolderAuthorizations(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function xDmsFolderAuthorizationsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal FolderID As Int32, ByVal CreatedBy As String) As List(Of SIS.xDMS.xDmsFolderAuthorizations)
      Dim Results As List(Of SIS.xDMS.xDmsFolderAuthorizations) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "UserID"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsFolderAuthorizationsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsFolderAuthorizationsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserID", SqlDbType.NVarChar, 8, IIf(UserID Is Nothing, String.Empty, UserID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FolderID", SqlDbType.Int, 10, IIf(FolderID = Nothing, 0, FolderID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy", SqlDbType.NVarChar, 8, IIf(CreatedBy Is Nothing, String.Empty, CreatedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFolderAuthorizations)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFolderAuthorizations(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsFolderAuthorizationsSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal FolderID As Int32, ByVal CreatedBy As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function xDmsFolderAuthorizationsGetByID(ByVal UserID As String, ByVal FolderID As Int32, ByVal Filter_UserID As String, ByVal Filter_FolderID As Int32, ByVal Filter_CreatedBy As String) As SIS.xDMS.xDmsFolderAuthorizations
      Return xDmsFolderAuthorizationsGetByID(UserID, FolderID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function xDmsFolderAuthorizationsInsert(ByVal Record As SIS.xDMS.xDmsFolderAuthorizations) As SIS.xDMS.xDmsFolderAuthorizations
      Dim _Rec As SIS.xDMS.xDmsFolderAuthorizations = SIS.xDMS.xDmsFolderAuthorizations.xDmsFolderAuthorizationsGetNewRecord()
      With _Rec
        .UserID = Record.UserID
        .FolderID = Record.FolderID
        .CreateFolder = Record.CreateFolder
        .UpdateFolder = Record.UpdateFolder
        .DeleteFolder = Record.DeleteFolder
        .UploadFile = Record.UploadFile
        .DownloadFile = Record.DownloadFile
        .DeleteFile = Record.DeleteFile
        .CanAuthorizeFolder = Record.CanAuthorizeFolder
        .CanPassAuthorization = Record.CanPassAuthorization
        .CanViewAllRevisions = Record.CanViewAllRevisions
        .RequireExplicitAuthorization = Record.RequireExplicitAuthorization
        .RequireExplicitWorkflow = Record.RequireExplicitWorkflow
        .ReleaseWorkflowID = Record.ReleaseWorkflowID
        .ReviseWorkflowID = Record.ReviseWorkflowID
        .InitialWorkflowID = Record.InitialWorkflowID
        .UploadedStatusID = Record.UploadedStatusID
        .UseFileTypeWorkflow = Record.UseFileTypeWorkflow
        .DuplicateFileNameAllowed = Record.DuplicateFileNameAllowed
        .ShowAtRoot = Record.ShowAtRoot
        .IsAdmin = Record.IsAdmin
        .GroupID = Record.GroupID
        .FGroupID = Record.FGroupID
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      Return SIS.xDMS.xDmsFolderAuthorizations.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.xDmsFolderAuthorizations) As SIS.xDMS.xDmsFolderAuthorizations
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFolderAuthorizationsInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID", SqlDbType.NVarChar, 9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID", SqlDbType.Int, 11, Record.FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreateFolder", SqlDbType.Bit, 3, Record.CreateFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdateFolder", SqlDbType.Bit, 3, Record.UpdateFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteFolder", SqlDbType.Bit, 3, Record.DeleteFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadFile", SqlDbType.Bit, 3, Record.UploadFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadFile", SqlDbType.Bit, 3, Record.DownloadFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteFile", SqlDbType.Bit, 3, Record.DeleteFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanAuthorizeFolder", SqlDbType.Bit, 3, Record.CanAuthorizeFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanPassAuthorization", SqlDbType.Bit, 3, Record.CanPassAuthorization)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequireExplicitAuthorization", SqlDbType.Bit, 3, Record.RequireExplicitAuthorization)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequireExplicitWorkflow", SqlDbType.Bit, 3, Record.RequireExplicitWorkflow)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReleaseWorkflowID", SqlDbType.Int, 11, IIf(Record.ReleaseWorkflowID = "", Convert.DBNull, Record.ReleaseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReviseWorkflowID", SqlDbType.Int, 11, IIf(Record.ReviseWorkflowID = "", Convert.DBNull, Record.ReviseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitialWorkflowID", SqlDbType.Int, 11, IIf(Record.InitialWorkflowID = "", Convert.DBNull, Record.InitialWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadedStatusID", SqlDbType.Int, 11, IIf(Record.UploadedStatusID = "", Convert.DBNull, Record.UploadedStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UseFileTypeWorkflow", SqlDbType.Bit, 3, Record.UseFileTypeWorkflow)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DuplicateFileNameAllowed", SqlDbType.Bit, 3, Record.DuplicateFileNameAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShowAtRoot", SqlDbType.Bit, 3, Record.ShowAtRoot)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsAdmin", SqlDbType.Bit, 3, Record.IsAdmin)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID", SqlDbType.Int, 11, IIf(Record.GroupID = "", Convert.DBNull, Record.GroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FGroupID", SqlDbType.Int, 11, IIf(Record.FGroupID = "", Convert.DBNull, Record.FGroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.NVarChar, 9, Record.CreatedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn", SqlDbType.DateTime, 21, Record.CreatedOn)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanViewAllRevisions", SqlDbType.Bit, 3, Record.CanViewAllRevisions)
          Cmd.Parameters.Add("@Return_UserID", SqlDbType.NVarChar, 9)
          Cmd.Parameters("@Return_UserID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_FolderID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FolderID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.UserID = Cmd.Parameters("@Return_UserID").Value
          Record.FolderID = Cmd.Parameters("@Return_FolderID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function xDmsFolderAuthorizationsUpdate(ByVal Record As SIS.xDMS.xDmsFolderAuthorizations) As SIS.xDMS.xDmsFolderAuthorizations
      Dim _Rec As SIS.xDMS.xDmsFolderAuthorizations = SIS.xDMS.xDmsFolderAuthorizations.xDmsFolderAuthorizationsGetByID(Record.UserID, Record.FolderID)
      With _Rec
        .CreateFolder = Record.CreateFolder
        .UpdateFolder = Record.UpdateFolder
        .DeleteFolder = Record.DeleteFolder
        .UploadFile = Record.UploadFile
        .DownloadFile = Record.DownloadFile
        .DeleteFile = Record.DeleteFile
        .CanAuthorizeFolder = Record.CanAuthorizeFolder
        .CanPassAuthorization = Record.CanPassAuthorization
        .CanViewAllRevisions = Record.CanViewAllRevisions
        .RequireExplicitAuthorization = Record.RequireExplicitAuthorization
        .RequireExplicitWorkflow = Record.RequireExplicitWorkflow
        .ReleaseWorkflowID = Record.ReleaseWorkflowID
        .ReviseWorkflowID = Record.ReviseWorkflowID
        .InitialWorkflowID = Record.InitialWorkflowID
        .UploadedStatusID = Record.UploadedStatusID
        .UseFileTypeWorkflow = Record.UseFileTypeWorkflow
        .DuplicateFileNameAllowed = Record.DuplicateFileNameAllowed
        .ShowAtRoot = Record.ShowAtRoot
        .IsAdmin = Record.IsAdmin
        .GroupID = Record.GroupID
        .FGroupID = Record.FGroupID
        .CreatedBy = Global.System.Web.HttpContext.Current.Session("LoginID")
        .CreatedOn = Now
      End With
      Return SIS.xDMS.xDmsFolderAuthorizations.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.xDmsFolderAuthorizations) As SIS.xDMS.xDmsFolderAuthorizations
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFolderAuthorizationsUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID", SqlDbType.NVarChar, 9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FolderID", SqlDbType.Int, 11, Record.FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID", SqlDbType.NVarChar, 9, Record.UserID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID", SqlDbType.Int, 11, Record.FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreateFolder", SqlDbType.Bit, 3, Record.CreateFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UpdateFolder", SqlDbType.Bit, 3, Record.UpdateFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteFolder", SqlDbType.Bit, 3, Record.DeleteFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadFile", SqlDbType.Bit, 3, Record.UploadFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DownloadFile", SqlDbType.Bit, 3, Record.DownloadFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DeleteFile", SqlDbType.Bit, 3, Record.DeleteFile)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanAuthorizeFolder", SqlDbType.Bit, 3, Record.CanAuthorizeFolder)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CanPassAuthorization", SqlDbType.Bit, 3, Record.CanPassAuthorization)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequireExplicitAuthorization", SqlDbType.Bit, 3, Record.RequireExplicitAuthorization)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@RequireExplicitWorkflow", SqlDbType.Bit, 3, Record.RequireExplicitWorkflow)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReleaseWorkflowID", SqlDbType.Int, 11, IIf(Record.ReleaseWorkflowID = "", Convert.DBNull, Record.ReleaseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReviseWorkflowID", SqlDbType.Int, 11, IIf(Record.ReviseWorkflowID = "", Convert.DBNull, Record.ReviseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitialWorkflowID", SqlDbType.Int, 11, IIf(Record.InitialWorkflowID = "", Convert.DBNull, Record.InitialWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadedStatusID", SqlDbType.Int, 11, IIf(Record.UploadedStatusID = "", Convert.DBNull, Record.UploadedStatusID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UseFileTypeWorkflow", SqlDbType.Bit, 3, Record.UseFileTypeWorkflow)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DuplicateFileNameAllowed", SqlDbType.Bit, 3, Record.DuplicateFileNameAllowed)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ShowAtRoot", SqlDbType.Bit, 3, Record.ShowAtRoot)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@IsAdmin", SqlDbType.Bit, 3, Record.IsAdmin)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID", SqlDbType.Int, 11, IIf(Record.GroupID = "", Convert.DBNull, Record.GroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FGroupID", SqlDbType.Int, 11, IIf(Record.FGroupID = "", Convert.DBNull, Record.FGroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedBy", SqlDbType.NVarChar, 9, Record.CreatedBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn", SqlDbType.DateTime, 21, Record.CreatedOn)
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)>
    Public Shared Function xDmsFolderAuthorizationsDelete(ByVal Record As SIS.xDMS.xDmsFolderAuthorizations) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFolderAuthorizationsDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_UserID", SqlDbType.NVarChar, Record.UserID.ToString.Length, Record.UserID)
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
    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
