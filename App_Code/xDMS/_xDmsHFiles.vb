Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  <DataObject()> _
  Partial Public Class xDmsHFiles
    Private Shared _RecordCount As Integer
    Public Property FileID As Int32 = 0
    Public Property HFileID As Int32 = 0
    Public Property FileName As String = ""
    Public Property FileRev As String = ""
    Public Property ItemTypeID As String = ""
    Public Property FolderID As Int32 = 0
    Public Property StatusID As Int32 = 0
    Public Property StatusBy As String = ""
    Private _StatusOn As String = ""
    Public Property StatusRemarks As String = ""
    Public Property VaultDRID As String = ""
    Public Property FileExtn As String = ""
    Public Property FileSize As Int32 = 0
    Public Property KeyWords As String = ""
    Public Property Active As Boolean = False
    Public Property ParentIFileID As String = ""
    Public Property NodeLevel As Int32 = 0
    Public Property Hseq As Int32 = 0
    Public Property FileTypeID As String = ""
    Public Property WorkflowID As String = ""
    Public Property WorkflowStepID As String = ""
    Public Property WorkflowNextStepID As String = ""
    Public Property UserID As String = ""
    Public Property GroupID As String = ""
    Public Property SystemRemarks As String = ""
    Public Property Purgable As Boolean = False
    Private _CreatedOn As String = ""
    Public Property UserRemarks As String = ""
    Public Property ProjectID As String = ""
    Public Property ElementID As String = ""
    Public Property BPID As String = ""
    Public Property CompanyID As String = ""
    Public Property DivisionID As String = ""
    Public Property DepartmentID As String = ""
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property aspnet_Users2_UserFullName As String = ""
    Public Property xDMS_FileTypes3_FileTypeName As String = ""
    Public Property xDMS_Folders4_FolderName As String = ""
    Public Property xDMS_Groups5_Description As String = ""
    Public Property xDMS_ItemTypes6_ItemName As String = ""
    Public Property xDMS_States7_StatusName As String = ""
    Public Property xDMS_Workflows8_WorkflowName As String = ""
    Public Property xDMS_Workflows9_WorkflowName As String = ""
    Public Property xDMS_Workflows10_WorkflowName As String = ""
    Private _FK_xDMS_HFiles_UserID As SIS.QCM.qcmUsers = Nothing
    Private _FK_xDMS_HFiles_StatusBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_xDMS_HFiles_FileTypeID As SIS.xDMS.xDmsFileTypes = Nothing
    Private _FK_xDMS_HFiles_FolderID As SIS.xDMS.xDmsFolders = Nothing
    Private _FK_xDMS_HFiles_GroupID As SIS.xDMS.xDmsUGroups = Nothing
    Private _FK_xDMS_HFiles_ItemTypeID As SIS.xDMS.xDmsItemTypes = Nothing
    Private _FK_xDMS_HFiles_StatusID As SIS.xDMS.xDmsStates = Nothing
    Private _FK_xDMS_HFiles_WorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
    Private _FK_xDMS_HFiles_WorkflowNextStepID As SIS.xDMS.xDmsWorkflows = Nothing
    Private _FK_xDMS_HFiles_WorkflowStepID As SIS.xDMS.xDmsWorkflows = Nothing
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
         If Convert.IsDBNull(Value) Then
           _StatusOn = ""
         Else
           _StatusOn = value
         End If
      End Set
    End Property
    Public Property CreatedOn() As String
      Get
        If Not _CreatedOn = String.Empty Then
          Return Convert.ToDateTime(_CreatedOn).ToString("dd/MM/yyyy HH:mm")
        End If
        Return _CreatedOn
      End Get
      Set(ByVal value As String)
         If Convert.IsDBNull(Value) Then
           _CreatedOn = ""
         Else
           _CreatedOn = value
         End If
      End Set
    End Property
    Public Readonly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _FileID & "|" & _HFileID
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
    Public Class PKxDmsHFiles
      Private _FileID As Int32 = 0
      Private _HFileID As Int32 = 0
      Public Property FileID() As Int32
        Get
          Return _FileID
        End Get
        Set(ByVal value As Int32)
          _FileID = value
        End Set
      End Property
      Public Property HFileID() As Int32
        Get
          Return _HFileID
        End Get
        Set(ByVal value As Int32)
          _HFileID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_xDMS_HFiles_UserID() As SIS.QCM.qcmUsers
      Get
        If _FK_xDMS_HFiles_UserID Is Nothing Then
          _FK_xDMS_HFiles_UserID = SIS.QCM.qcmUsers.qcmUsersGetByID(_UserID)
        End If
        Return _FK_xDMS_HFiles_UserID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_HFiles_StatusBy() As SIS.QCM.qcmUsers
      Get
        If _FK_xDMS_HFiles_StatusBy Is Nothing Then
          _FK_xDMS_HFiles_StatusBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_StatusBy)
        End If
        Return _FK_xDMS_HFiles_StatusBy
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_HFiles_FileTypeID() As SIS.xDMS.xDmsFileTypes
      Get
        If _FK_xDMS_HFiles_FileTypeID Is Nothing Then
          _FK_xDMS_HFiles_FileTypeID = SIS.xDMS.xDmsFileTypes.xDmsFileTypesGetByID(_FileTypeID)
        End If
        Return _FK_xDMS_HFiles_FileTypeID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_HFiles_FolderID() As SIS.xDMS.xDmsFolders
      Get
        If _FK_xDMS_HFiles_FolderID Is Nothing Then
          _FK_xDMS_HFiles_FolderID = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(_FolderID)
        End If
        Return _FK_xDMS_HFiles_FolderID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_HFiles_GroupID() As SIS.xDMS.xDmsUGroups
      Get
        If _FK_xDMS_HFiles_GroupID Is Nothing Then
          _FK_xDMS_HFiles_GroupID = SIS.xDMS.xDmsUGroups.xDmsUGroupsGetByID(_GroupID)
        End If
        Return _FK_xDMS_HFiles_GroupID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_HFiles_ItemTypeID() As SIS.xDMS.xDmsItemTypes
      Get
        If _FK_xDMS_HFiles_ItemTypeID Is Nothing Then
          _FK_xDMS_HFiles_ItemTypeID = SIS.xDMS.xDmsItemTypes.xDmsItemTypesGetByID(_ItemTypeID)
        End If
        Return _FK_xDMS_HFiles_ItemTypeID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_HFiles_StatusID() As SIS.xDMS.xDmsStates
      Get
        If _FK_xDMS_HFiles_StatusID Is Nothing Then
          _FK_xDMS_HFiles_StatusID = SIS.xDMS.xDmsStates.xDmsStatesGetByID(_StatusID)
        End If
        Return _FK_xDMS_HFiles_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_HFiles_WorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_HFiles_WorkflowID Is Nothing Then
          _FK_xDMS_HFiles_WorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_WorkflowID)
        End If
        Return _FK_xDMS_HFiles_WorkflowID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_HFiles_WorkflowNextStepID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_HFiles_WorkflowNextStepID Is Nothing Then
          _FK_xDMS_HFiles_WorkflowNextStepID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_WorkflowNextStepID)
        End If
        Return _FK_xDMS_HFiles_WorkflowNextStepID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_HFiles_WorkflowStepID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_HFiles_WorkflowStepID Is Nothing Then
          _FK_xDMS_HFiles_WorkflowStepID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_WorkflowStepID)
        End If
        Return _FK_xDMS_HFiles_WorkflowStepID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsHFilesGetNewRecord() As SIS.xDMS.xDmsHFiles
      Return New SIS.xDMS.xDmsHFiles()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsHFilesGetByID(ByVal FileID As Int32, ByVal HFileID As Int32) As SIS.xDMS.xDmsHFiles
      Dim Results As SIS.xDMS.xDmsHFiles = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsHFilesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileID",SqlDbType.Int,FileID.ToString.Length, FileID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HFileID",SqlDbType.Int,HFileID.ToString.Length, HFileID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsHFiles(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsHFilesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FileID As Int32) As List(Of SIS.xDMS.xDmsHFiles)
      Dim Results As List(Of SIS.xDMS.xDmsHFiles) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsHFilesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsHFilesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FileID",SqlDbType.Int,10, IIf(FileID = Nothing, 0,FileID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsHFiles)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsHFiles(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsHFilesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FileID As Int32) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsHFilesGetByID(ByVal FileID As Int32, ByVal HFileID As Int32, ByVal Filter_FileID As Int32) As SIS.xDMS.xDmsHFiles
      Return xDmsHFilesGetByID(FileID, HFileID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function xDmsHFilesInsert(ByVal Record As SIS.xDMS.xDmsHFiles) As SIS.xDMS.xDmsHFiles
      Dim _Rec As SIS.xDMS.xDmsHFiles = SIS.xDMS.xDmsHFiles.xDmsHFilesGetNewRecord()
      With _Rec
        .FileID = Record.FileID
        .FileName = Record.FileName
        .FileRev = Record.FileRev
        .ItemTypeID = Record.ItemTypeID
        .FolderID = Record.FolderID
        .StatusID = Record.StatusID
        .StatusBy = Record.StatusBy
        .StatusOn = Record.StatusOn
        .StatusRemarks = Record.StatusRemarks
        .VaultDRID = Record.VaultDRID
        .FileExtn = Record.FileExtn
        .FileSize = Record.FileSize
        .KeyWords = Record.KeyWords
        .Active = Record.Active
        .ParentIFileID = Record.ParentIFileID
        .NodeLevel = Record.NodeLevel
        .Hseq = Record.Hseq
        .FileTypeID = Record.FileTypeID
        .WorkflowID = Record.WorkflowID
        .WorkflowStepID = Record.WorkflowStepID
        .WorkflowNextStepID = Record.WorkflowNextStepID
        .UserID = Record.UserID
        .GroupID = Record.GroupID
        .SystemRemarks = Record.SystemRemarks
        .Purgable = Record.Purgable
        .CreatedOn = Record.CreatedOn
      End With
      Return SIS.xDMS.xDmsHFiles.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.xDmsHFiles) As SIS.xDMS.xDmsHFiles
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsHFilesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileID", SqlDbType.Int, 11, Record.FileID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@HFileID", SqlDbType.Int, 11, Record.HFileID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName", SqlDbType.NVarChar, 251, IIf(Record.FileName = "", Convert.DBNull, Record.FileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileRev",SqlDbType.NVarChar,11, Record.FileRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemTypeID",SqlDbType.NVarChar,11, Iif(Record.ItemTypeID= "" ,Convert.DBNull, Record.ItemTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID",SqlDbType.Int,11, Record.FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Record.StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusBy",SqlDbType.NVarChar,9, Iif(Record.StatusBy= "" ,Convert.DBNull, Record.StatusBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusOn",SqlDbType.DateTime,21, Iif(Record.StatusOn= "" ,Convert.DBNull, Record.StatusOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusRemarks",SqlDbType.NVarChar,501, Iif(Record.StatusRemarks= "" ,Convert.DBNull, Record.StatusRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VaultDRID",SqlDbType.NVarChar,51, Iif(Record.VaultDRID= "" ,Convert.DBNull, Record.VaultDRID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileExtn",SqlDbType.NVarChar,51, Iif(Record.FileExtn= "" ,Convert.DBNull, Record.FileExtn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileSize",SqlDbType.Int,11, Record.FileSize)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWords", SqlDbType.NVarChar, 201, IIf(Record.KeyWords = "", Convert.DBNull, Record.KeyWords))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentIFileID",SqlDbType.Int,11, Iif(Record.ParentIFileID= "" ,Convert.DBNull, Record.ParentIFileID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NodeLevel",SqlDbType.Int,11, Record.NodeLevel)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Hseq",SqlDbType.Int,11, Record.Hseq)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileTypeID",SqlDbType.Int,11, Iif(Record.FileTypeID= "" ,Convert.DBNull, Record.FileTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowID",SqlDbType.Int,11, Iif(Record.WorkflowID= "" ,Convert.DBNull, Record.WorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowStepID",SqlDbType.Int,11, Iif(Record.WorkflowStepID= "" ,Convert.DBNull, Record.WorkflowStepID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowNextStepID",SqlDbType.Int,11, Iif(Record.WorkflowNextStepID= "" ,Convert.DBNull, Record.WorkflowNextStepID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Iif(Record.UserID= "" ,Convert.DBNull, Record.UserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID",SqlDbType.Int,11, Iif(Record.GroupID= "" ,Convert.DBNull, Record.GroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SystemRemarks",SqlDbType.NVarChar,201, Iif(Record.SystemRemarks= "" ,Convert.DBNull, Record.SystemRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Purgable",SqlDbType.Bit,3, Record.Purgable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserRemarks", SqlDbType.NVarChar, 501, IIf(Record.UserRemarks = "", Convert.DBNull, Record.UserRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID", SqlDbType.NVarChar, 9, IIf(Record.ElementID = "", Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID", SqlDbType.NVarChar, 10, IIf(Record.BPID = "", Convert.DBNull, Record.BPID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CompanyID", SqlDbType.NVarChar, 7, IIf(Record.CompanyID = "", Convert.DBNull, Record.CompanyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID", SqlDbType.NVarChar, 7, IIf(Record.DivisionID = "", Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.DepartmentID = "", Convert.DBNull, Record.DepartmentID))
          Cmd.Parameters.Add("@Return_FileID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FileID").Direction = ParameterDirection.Output
          Cmd.Parameters.Add("@Return_HFileID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_HFileID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.FileID = Cmd.Parameters("@Return_FileID").Value
          Record.HFileID = Cmd.Parameters("@Return_HFileID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function xDmsHFilesUpdate(ByVal Record As SIS.xDMS.xDmsHFiles) As SIS.xDMS.xDmsHFiles
      Dim _Rec As SIS.xDMS.xDmsHFiles = SIS.xDMS.xDmsHFiles.xDmsHFilesGetByID(Record.FileID, Record.HFileID)
      With _Rec
        .FileName = Record.FileName
        .FileRev = Record.FileRev
        .ItemTypeID = Record.ItemTypeID
        .FolderID = Record.FolderID
        .StatusID = Record.StatusID
        .StatusBy = Record.StatusBy
        .StatusOn = Record.StatusOn
        .StatusRemarks = Record.StatusRemarks
        .VaultDRID = Record.VaultDRID
        .FileExtn = Record.FileExtn
        .FileSize = Record.FileSize
        .KeyWords = Record.KeyWords
        .Active = Record.Active
        .ParentIFileID = Record.ParentIFileID
        .NodeLevel = Record.NodeLevel
        .Hseq = Record.Hseq
        .FileTypeID = Record.FileTypeID
        .WorkflowID = Record.WorkflowID
        .WorkflowStepID = Record.WorkflowStepID
        .WorkflowNextStepID = Record.WorkflowNextStepID
        .UserID = Record.UserID
        .GroupID = Record.GroupID
        .SystemRemarks = Record.SystemRemarks
        .Purgable = Record.Purgable
        .CreatedOn = Record.CreatedOn
      End With
      Return SIS.xDMS.xDmsHFiles.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.xDmsHFiles) As SIS.xDMS.xDmsHFiles
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsHFilesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FileID",SqlDbType.Int,11, Record.FileID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_HFileID",SqlDbType.Int,11, Record.HFileID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileID",SqlDbType.Int,11, Record.FileID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,251, Iif(Record.FileName= "" ,Convert.DBNull, Record.FileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileRev",SqlDbType.NVarChar,11, Record.FileRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemTypeID",SqlDbType.NVarChar,11, Iif(Record.ItemTypeID= "" ,Convert.DBNull, Record.ItemTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID",SqlDbType.Int,11, Record.FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Record.StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusBy",SqlDbType.NVarChar,9, Iif(Record.StatusBy= "" ,Convert.DBNull, Record.StatusBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusOn",SqlDbType.DateTime,21, Iif(Record.StatusOn= "" ,Convert.DBNull, Record.StatusOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusRemarks",SqlDbType.NVarChar,501, Iif(Record.StatusRemarks= "" ,Convert.DBNull, Record.StatusRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VaultDRID",SqlDbType.NVarChar,51, Iif(Record.VaultDRID= "" ,Convert.DBNull, Record.VaultDRID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileExtn",SqlDbType.NVarChar,51, Iif(Record.FileExtn= "" ,Convert.DBNull, Record.FileExtn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileSize",SqlDbType.Int,11, Record.FileSize)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWords", SqlDbType.NVarChar, 201, IIf(Record.KeyWords = "", Convert.DBNull, Record.KeyWords))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentIFileID",SqlDbType.Int,11, Iif(Record.ParentIFileID= "" ,Convert.DBNull, Record.ParentIFileID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NodeLevel",SqlDbType.Int,11, Record.NodeLevel)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Hseq",SqlDbType.Int,11, Record.Hseq)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileTypeID",SqlDbType.Int,11, Iif(Record.FileTypeID= "" ,Convert.DBNull, Record.FileTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowID",SqlDbType.Int,11, Iif(Record.WorkflowID= "" ,Convert.DBNull, Record.WorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowStepID",SqlDbType.Int,11, Iif(Record.WorkflowStepID= "" ,Convert.DBNull, Record.WorkflowStepID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowNextStepID",SqlDbType.Int,11, Iif(Record.WorkflowNextStepID= "" ,Convert.DBNull, Record.WorkflowNextStepID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID",SqlDbType.NVarChar,9, Iif(Record.UserID= "" ,Convert.DBNull, Record.UserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID",SqlDbType.Int,11, Iif(Record.GroupID= "" ,Convert.DBNull, Record.GroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SystemRemarks",SqlDbType.NVarChar,201, Iif(Record.SystemRemarks= "" ,Convert.DBNull, Record.SystemRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Purgable",SqlDbType.Bit,3, Record.Purgable)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CreatedOn",SqlDbType.DateTime,21, Iif(Record.CreatedOn= "" ,Convert.DBNull, Record.CreatedOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserRemarks", SqlDbType.NVarChar, 501, IIf(Record.UserRemarks = "", Convert.DBNull, Record.UserRemarks))
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
    <DataObjectMethod(DataObjectMethodType.Delete, True)> _
    Public Shared Function xDmsHFilesDelete(ByVal Record As SIS.xDMS.xDmsHFiles) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsHFilesDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FileID",SqlDbType.Int,Record.FileID.ToString.Length, Record.FileID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_HFileID",SqlDbType.Int,Record.HFileID.ToString.Length, Record.HFileID)
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
