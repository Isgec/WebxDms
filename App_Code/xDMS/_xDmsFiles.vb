Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  <DataObject()> _
  Partial Public Class xDmsFiles
    Private Shared _RecordCount As Integer
    Public Property FileID As Int32 = 0
    Public Property FileTypeID As String = ""
    Public Property FileName As String = ""
    Public Property FileRev As String = ""
    Public Property ItemTypeID As String = ""
    Public Property FolderID As Int32 = 0
    Public Property VaultDRID As String = ""
    Public Property FileExtn As String = ""
    Public Property FileSize As Int32 = 0
    Public Property StatusID As Int32 = 0
    Public Property Active As Boolean = False
    Public Property Hseq As Int32 = 0
    Public Property NodeLevel As Int32 = 0
    Public Property ParentIFileID As String = ""
    Private _StatusOn As String = ""
    Public Property StatusBy As String = ""
    Public Property KeyWords As String = ""
    Public Property StatusRemarks As String = ""
    Public Property WorkflowID As String = ""
    Public Property UserID As String = ""
    Public Property WorkflowNextStepID As String = ""
    Public Property GroupID As String = ""
    Public Property WorkflowStepID As String = ""
    Public Property UserRemarks As String = ""
    Public Property ProjectID As String = ""
    Public Property ElementID As String = ""
    Public Property BPID As String = ""
    Public Property CompanyID As String = ""
    Public Property DivisionID As String = ""
    Public Property DepartmentID As String = ""
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property xDMS_Files2_FileName As String = ""
    Public Property xDMS_Folders3_FolderName As String = ""
    Public Property xDMS_ItemTypes4_ItemName As String = ""
    Public Property xDMS_States5_StatusName As String = ""
    Public Property xDMS_FileTypes6_FileTypeName As String = ""
    Public Property xDMS_Workflows8_WorkflowName As String = ""
    Public Property xDMS_Workflows9_WorkflowName As String = ""
    Public Property xDMS_Workflows10_WorkflowName As String = ""
    Private _FK_xDMS_Files_StatusBy As SIS.QCM.qcmUsers = Nothing
    Private _FK_xDMS_Files_ParentFileID As SIS.xDMS.xDmsFiles = Nothing
    Private _FK_xDMS_Files_FolderID As SIS.xDMS.xDmsFolders = Nothing
    Private _FK_xDMS_Files_ItemTypeID As SIS.xDMS.xDmsItemTypes = Nothing
    Private _FK_xDMS_Files_StatusID As SIS.xDMS.xDmsStates = Nothing
    Private _FK_xDMS_Files_FileTypeID As SIS.xDMS.xDmsFileTypes = Nothing
    Private _FK_xDMS_Files_WorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
    Private _FK_xDMS_Files_WorkflowNextStepID As SIS.xDMS.xDmsWorkflows = Nothing
    Private _FK_xDMS_Files_WorkflowStepID As SIS.xDMS.xDmsWorkflows = Nothing
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
    Public Readonly Property DisplayField() As String
      Get
        Return "" & _FileName.ToString.PadRight(250, " ")
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _FileID
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
    Public Class PKxDmsFiles
      Private _FileID As Int32 = 0
      Public Property FileID() As Int32
        Get
          Return _FileID
        End Get
        Set(ByVal value As Int32)
          _FileID = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_xDMS_Files_StatusBy() As SIS.QCM.qcmUsers
      Get
        If _FK_xDMS_Files_StatusBy Is Nothing Then
          _FK_xDMS_Files_StatusBy = SIS.QCM.qcmUsers.qcmUsersGetByID(_StatusBy)
        End If
        Return _FK_xDMS_Files_StatusBy
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_Files_ParentFileID() As SIS.xDMS.xDmsFiles
      Get
        If _FK_xDMS_Files_ParentFileID Is Nothing Then
          _FK_xDMS_Files_ParentFileID = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(_ParentIFileID)
        End If
        Return _FK_xDMS_Files_ParentFileID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_Files_FolderID() As SIS.xDMS.xDmsFolders
      Get
        If _FK_xDMS_Files_FolderID Is Nothing Then
          _FK_xDMS_Files_FolderID = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(_FolderID)
        End If
        Return _FK_xDMS_Files_FolderID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_Files_ItemTypeID() As SIS.xDMS.xDmsItemTypes
      Get
        If _FK_xDMS_Files_ItemTypeID Is Nothing Then
          _FK_xDMS_Files_ItemTypeID = SIS.xDMS.xDmsItemTypes.xDmsItemTypesGetByID(_ItemTypeID)
        End If
        Return _FK_xDMS_Files_ItemTypeID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_Files_StatusID() As SIS.xDMS.xDmsStates
      Get
        If _FK_xDMS_Files_StatusID Is Nothing Then
          _FK_xDMS_Files_StatusID = SIS.xDMS.xDmsStates.xDmsStatesGetByID(_StatusID)
        End If
        Return _FK_xDMS_Files_StatusID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_Files_FileTypeID() As SIS.xDMS.xDmsFileTypes
      Get
        If _FK_xDMS_Files_FileTypeID Is Nothing Then
          _FK_xDMS_Files_FileTypeID = SIS.xDMS.xDmsFileTypes.xDmsFileTypesGetByID(_FileTypeID)
        End If
        Return _FK_xDMS_Files_FileTypeID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_Files_WorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_Files_WorkflowID Is Nothing Then
          _FK_xDMS_Files_WorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_WorkflowID)
        End If
        Return _FK_xDMS_Files_WorkflowID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_Files_WorkflowNextStepID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_Files_WorkflowNextStepID Is Nothing Then
          _FK_xDMS_Files_WorkflowNextStepID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_WorkflowNextStepID)
        End If
        Return _FK_xDMS_Files_WorkflowNextStepID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_Files_WorkflowStepID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_Files_WorkflowStepID Is Nothing Then
          _FK_xDMS_Files_WorkflowStepID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_WorkflowStepID)
        End If
        Return _FK_xDMS_Files_WorkflowStepID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function xDmsFilesSelectList(ByVal OrderBy As String) As List(Of SIS.xDMS.xDmsFiles)
      Dim Results As List(Of SIS.xDMS.xDmsFiles) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FileID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFilesSelectList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFiles)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFiles(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFilesGetNewRecord() As SIS.xDMS.xDmsFiles
      Return New SIS.xDMS.xDmsFiles()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFilesGetByID(ByVal FileID As Int32) As SIS.xDMS.xDmsFiles
      Dim xUser As SIS.xDMS.xDmsUsers = SIS.xDMS.xDmsUsers.xDmsUsersGetByID(HttpContext.Current.Session("LoginID"))
      Dim Results As SIS.xDMS.xDmsFiles = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFilesSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileID",SqlDbType.Int,FileID.ToString.Length, FileID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.xDmsFiles(Reader)
            If xUser IsNot Nothing Then
              Results.IsAdmin = xUser.IsAdmin
              Results.IsSAdmin = xUser.IsSAdmin
            End If
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFilesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FileID As Int32, ByVal FolderID As Int32, ByVal StatusID As Int32, ByVal ParentIFileID As Int32, ByVal StatusBy As String) As List(Of SIS.xDMS.xDmsFiles)
      Dim Results As List(Of SIS.xDMS.xDmsFiles) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FileID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsFilesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsFilesSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FileID",SqlDbType.Int,10, IIf(FileID = Nothing, 0,FileID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FolderID",SqlDbType.Int,10, IIf(FolderID = Nothing, 0,FolderID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusID",SqlDbType.Int,10, IIf(StatusID = Nothing, 0,StatusID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_ParentIFileID",SqlDbType.Int,10, IIf(ParentIFileID = Nothing, 0,ParentIFileID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_StatusBy",SqlDbType.NVarChar,8, IIf(StatusBy Is Nothing, String.Empty,StatusBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFiles)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFiles(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function xDmsFilesSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String, ByVal FileID As Int32, ByVal FolderID As Int32, ByVal StatusID As Int32, ByVal ParentIFileID As Int32, ByVal StatusBy As String) As Integer
      Return _RecordCount
    End Function
      'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function xDmsFilesGetByID(ByVal FileID As Int32, ByVal Filter_FileID As Int32, ByVal Filter_FolderID As Int32, ByVal Filter_StatusID As Int32, ByVal Filter_ParentIFileID As Int32, ByVal Filter_StatusBy As String) As SIS.xDMS.xDmsFiles
      Return xDmsFilesGetByID(FileID)
    End Function
    <DataObjectMethod(DataObjectMethodType.Insert, True)> _
    Public Shared Function xDmsFilesInsert(ByVal Record As SIS.xDMS.xDmsFiles) As SIS.xDMS.xDmsFiles
      Dim _Rec As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.xDmsFilesGetNewRecord()
      With _Rec
        .FileTypeID = Record.FileTypeID
        .FileName = Record.FileName
        .FileRev = Record.FileRev
        .ItemTypeID = Record.ItemTypeID
        .FolderID = Record.FolderID
        .VaultDRID = Record.VaultDRID
        .FileExtn = Record.FileExtn
        .FileSize = Record.FileSize
        .StatusID = Record.StatusID
        .Active = Record.Active
        .Hseq = Record.Hseq
        .NodeLevel = Record.NodeLevel
        .ParentIFileID = Record.ParentIFileID
        .StatusOn = Record.StatusOn
        .StatusBy = Record.StatusBy
        .KeyWords = Record.KeyWords
        .StatusRemarks = Record.StatusRemarks
      End With
      Return SIS.xDMS.xDmsFiles.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.xDmsFiles) As SIS.xDMS.xDmsFiles
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFilesInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileTypeID",SqlDbType.Int,11, Iif(Record.FileTypeID= "" ,Convert.DBNull, Record.FileTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,251, Iif(Record.FileName= "" ,Convert.DBNull, Record.FileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileRev",SqlDbType.NVarChar,11, Record.FileRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemTypeID",SqlDbType.NVarChar,11, Iif(Record.ItemTypeID= "" ,Convert.DBNull, Record.ItemTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID",SqlDbType.Int,11, Record.FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VaultDRID",SqlDbType.NVarChar,51, Iif(Record.VaultDRID= "" ,Convert.DBNull, Record.VaultDRID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileExtn",SqlDbType.NVarChar,51, Iif(Record.FileExtn= "" ,Convert.DBNull, Record.FileExtn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileSize",SqlDbType.Int,11, Record.FileSize)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Record.StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Hseq",SqlDbType.Int,11, Record.Hseq)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NodeLevel",SqlDbType.Int,11, Record.NodeLevel)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentIFileID",SqlDbType.Int,11, Iif(Record.ParentIFileID= "" ,Convert.DBNull, Record.ParentIFileID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusOn",SqlDbType.DateTime,21, Iif(Record.StatusOn= "" ,Convert.DBNull, Record.StatusOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusBy",SqlDbType.NVarChar,9, Iif(Record.StatusBy= "" ,Convert.DBNull, Record.StatusBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWords", SqlDbType.NVarChar, 201, IIf(Record.KeyWords = "", Convert.DBNull, Record.KeyWords))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusRemarks",SqlDbType.NVarChar,501, Iif(Record.StatusRemarks= "" ,Convert.DBNull, Record.StatusRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowID", SqlDbType.Int, 11, IIf(Record.WorkflowID = "", Convert.DBNull, Record.WorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowStepID", SqlDbType.Int, 11, IIf(Record.WorkflowStepID = "", Convert.DBNull, Record.WorkflowStepID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID", SqlDbType.NVarChar, 9, IIf(Record.UserID = "", Convert.DBNull, Record.UserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID", SqlDbType.Int, 11, IIf(Record.GroupID = "", Convert.DBNull, Record.GroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowNextStepID", SqlDbType.Int, 11, IIf(Record.WorkflowNextStepID = "", Convert.DBNull, Record.WorkflowNextStepID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserRemarks", SqlDbType.NVarChar, 501, IIf(Record.UserRemarks = "", Convert.DBNull, Record.UserRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ProjectID", SqlDbType.NVarChar, 7, IIf(Record.ProjectID = "", Convert.DBNull, Record.ProjectID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ElementID", SqlDbType.NVarChar, 9, IIf(Record.ElementID = "", Convert.DBNull, Record.ElementID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@BPID", SqlDbType.NVarChar, 10, IIf(Record.BPID = "", Convert.DBNull, Record.BPID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@CompanyID", SqlDbType.NVarChar, 7, IIf(Record.CompanyID = "", Convert.DBNull, Record.CompanyID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DivisionID", SqlDbType.NVarChar, 7, IIf(Record.DivisionID = "", Convert.DBNull, Record.DivisionID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@DepartmentID", SqlDbType.NVarChar, 7, IIf(Record.DepartmentID = "", Convert.DBNull, Record.DepartmentID))
          Cmd.Parameters.Add("@Return_FileID", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_FileID").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.FileID = Cmd.Parameters("@Return_FileID").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)> _
    Public Shared Function xDmsFilesUpdate(ByVal Record As SIS.xDMS.xDmsFiles) As SIS.xDMS.xDmsFiles
      Dim _Rec As SIS.xDMS.xDmsFiles = SIS.xDMS.xDmsFiles.xDmsFilesGetByID(Record.FileID)
      With _Rec
        .FileTypeID = Record.FileTypeID
        .FileName = Record.FileName
        .FileRev = Record.FileRev
        .ItemTypeID = Record.ItemTypeID
        .FolderID = Record.FolderID
        .VaultDRID = Record.VaultDRID
        .FileExtn = Record.FileExtn
        .FileSize = Record.FileSize
        .StatusID = Record.StatusID
        .Active = Record.Active
        .Hseq = Record.Hseq
        .NodeLevel = Record.NodeLevel
        .ParentIFileID = Record.ParentIFileID
        .StatusOn = Record.StatusOn
        .StatusBy = Record.StatusBy
        .KeyWords = Record.KeyWords
        .StatusRemarks = Record.StatusRemarks
      End With
      Return SIS.xDMS.xDmsFiles.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.xDmsFiles) As SIS.xDMS.xDmsFiles
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFilesUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_FileID",SqlDbType.Int,11, Record.FileID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileTypeID",SqlDbType.Int,11, Iif(Record.FileTypeID= "" ,Convert.DBNull, Record.FileTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileName",SqlDbType.NVarChar,251, Iif(Record.FileName= "" ,Convert.DBNull, Record.FileName))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileRev",SqlDbType.NVarChar,11, Record.FileRev)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ItemTypeID",SqlDbType.NVarChar,11, Iif(Record.ItemTypeID= "" ,Convert.DBNull, Record.ItemTypeID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID",SqlDbType.Int,11, Record.FolderID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@VaultDRID",SqlDbType.NVarChar,51, Iif(Record.VaultDRID= "" ,Convert.DBNull, Record.VaultDRID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileExtn",SqlDbType.NVarChar,51, Iif(Record.FileExtn= "" ,Convert.DBNull, Record.FileExtn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FileSize",SqlDbType.Int,11, Record.FileSize)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusID",SqlDbType.Int,11, Record.StatusID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active",SqlDbType.Bit,3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Hseq",SqlDbType.Int,11, Record.Hseq)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@NodeLevel",SqlDbType.Int,11, Record.NodeLevel)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentIFileID",SqlDbType.Int,11, Iif(Record.ParentIFileID= "" ,Convert.DBNull, Record.ParentIFileID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusOn",SqlDbType.DateTime,21, Iif(Record.StatusOn= "" ,Convert.DBNull, Record.StatusOn))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusBy",SqlDbType.NVarChar,9, Iif(Record.StatusBy= "" ,Convert.DBNull, Record.StatusBy))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWords", SqlDbType.NVarChar, 201, IIf(Record.KeyWords = "", Convert.DBNull, Record.KeyWords))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StatusRemarks",SqlDbType.NVarChar,501, Iif(Record.StatusRemarks= "" ,Convert.DBNull, Record.StatusRemarks))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowID", SqlDbType.Int, 11, IIf(Record.WorkflowID = "", Convert.DBNull, Record.WorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowStepID", SqlDbType.Int, 11, IIf(Record.WorkflowStepID = "", Convert.DBNull, Record.WorkflowStepID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UserID", SqlDbType.NVarChar, 9, IIf(Record.UserID = "", Convert.DBNull, Record.UserID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@GroupID", SqlDbType.Int, 11, IIf(Record.GroupID = "", Convert.DBNull, Record.GroupID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@WorkflowNextStepID", SqlDbType.Int, 11, IIf(Record.WorkflowNextStepID = "", Convert.DBNull, Record.WorkflowNextStepID))
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
    Public Shared Function xDmsFilesDelete(ByVal Record As SIS.xDMS.xDmsFiles) As Int32
      Dim _Result as Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFilesDelete"
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
'    Autocomplete Method
    Public Shared Function SelectxDmsFilesAutoCompleteList(ByVal Prefix As String, ByVal count As Integer, ByVal contextKey As String) As String()
      Dim Results As List(Of String) = Nothing
      Dim aVal() As String = contextKey.Split("|".ToCharArray)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsFilesAutoCompleteList"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@prefix", SqlDbType.NVarChar, 50, Prefix)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@records", SqlDbType.Int, -1, count)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@bycode", SqlDbType.Int, 1, IIf(IsNumeric(Prefix), 0, 1))
          Results = New List(Of String)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Not Reader.HasRows Then
            Results.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem("---Select Value---".PadRight(250, " "),""))
          End If
          While (Reader.Read())
            Dim Tmp As SIS.xDMS.xDmsFiles = New SIS.xDMS.xDmsFiles(Reader)
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
