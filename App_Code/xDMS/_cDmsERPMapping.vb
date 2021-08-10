Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  <DataObject()>
  Partial Public Class cDmsERPMapping
    Private Shared _RecordCount As Integer
    Public Property SerialNo As Int32 = 0
    Public Property TransmittalTypeID As Int32 = 0
    Public Property ERPsrno As Int32 = 0
    Public Property FolderName As String = ""
    Public Property ParentFolderID As String = ""
    Public Property InitialWorkflowID As String = ""
    Public Property ReleaseWorkflowID As String = ""
    Public Property ReviseWorkflowID As String = ""
    Public Property UploadStatusID As String = ""
    Public Property Active As Boolean = False
    Public Property xDMS_ERPTransmittalTypes1_TransmittalTypeName As String = ""
    Public Property xDMS_Folders2_FolderName As String = ""
    Public Property xDMS_Workflows3_WorkflowName As String = ""
    Public Property xDMS_Workflows4_WorkflowName As String = ""
    Public Property xDMS_Workflows5_WorkflowName As String = ""
    Private _FK_xDMS_ERPMapping_TransmittalTypeID As SIS.xDMS.xDmsERPTransmittalTypes = Nothing
    Private _FK_xDMS_ERPMapping_ParentFolderID As SIS.xDMS.xDmsFolders = Nothing
    Private _FK_xDMS_ERPMapping_InitialWorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
    Private _FK_xDMS_ERPMapping_ReleaseWorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
    Private _FK_xDMS_ERPMapping_ReviseWorkflowID As SIS.xDMS.xDmsWorkflows = Nothing
    Public ReadOnly Property ForeColor() As System.Drawing.Color
      Get
        Dim mRet As System.Drawing.Color = Drawing.Color.Black
        Try
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public ReadOnly Property PrimaryKey() As String
      Get
        Return _SerialNo
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
    Public Class PKcDmsERPMapping
      Private _SerialNo As Int32 = 0
      Public Property SerialNo() As Int32
        Get
          Return _SerialNo
        End Get
        Set(ByVal value As Int32)
          _SerialNo = value
        End Set
      End Property
    End Class
    Public ReadOnly Property FK_xDMS_ERPMapping_TransmittalTypeID() As SIS.xDMS.xDmsERPTransmittalTypes
      Get
        If _FK_xDMS_ERPMapping_TransmittalTypeID Is Nothing Then
          _FK_xDMS_ERPMapping_TransmittalTypeID = SIS.xDMS.xDmsERPTransmittalTypes.xDmsERPTransmittalTypesGetByID(_TransmittalTypeID)
        End If
        Return _FK_xDMS_ERPMapping_TransmittalTypeID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_ERPMapping_ParentFolderID() As SIS.xDMS.xDmsFolders
      Get
        If _FK_xDMS_ERPMapping_ParentFolderID Is Nothing Then
          _FK_xDMS_ERPMapping_ParentFolderID = SIS.xDMS.xDmsFolders.xDmsFoldersGetByID(_ParentFolderID)
        End If
        Return _FK_xDMS_ERPMapping_ParentFolderID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_ERPMapping_InitialWorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_ERPMapping_InitialWorkflowID Is Nothing Then
          _FK_xDMS_ERPMapping_InitialWorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_InitialWorkflowID)
        End If
        Return _FK_xDMS_ERPMapping_InitialWorkflowID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_ERPMapping_ReleaseWorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_ERPMapping_ReleaseWorkflowID Is Nothing Then
          _FK_xDMS_ERPMapping_ReleaseWorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_ReleaseWorkflowID)
        End If
        Return _FK_xDMS_ERPMapping_ReleaseWorkflowID
      End Get
    End Property
    Public ReadOnly Property FK_xDMS_ERPMapping_ReviseWorkflowID() As SIS.xDMS.xDmsWorkflows
      Get
        If _FK_xDMS_ERPMapping_ReviseWorkflowID Is Nothing Then
          _FK_xDMS_ERPMapping_ReviseWorkflowID = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(_ReviseWorkflowID)
        End If
        Return _FK_xDMS_ERPMapping_ReviseWorkflowID
      End Get
    End Property
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function cDmsERPMappingGetNewRecord() As SIS.xDMS.cDmsERPMapping
      Return New SIS.xDMS.cDmsERPMapping()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function cDmsERPMappingGetByID(ByVal SerialNo As Int32) As SIS.xDMS.cDmsERPMapping
      Dim Results As SIS.xDMS.cDmsERPMapping = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsERPMappingSelectByID"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@SerialNo", SqlDbType.Int, SerialNo.ToString.Length, SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.cDmsERPMapping(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function cDmsERPMappingSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.xDMS.cDmsERPMapping)
      Dim Results As List(Of SIS.xDMS.cDmsERPMapping) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxDmsERPMappingSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxDmsERPMappingSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, "")
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active", SqlDbType.Bit, 2, True)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.cDmsERPMapping)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.cDmsERPMapping(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function cDmsERPMappingSelectCount(ByVal SearchState As Boolean, ByVal SearchText As String) As Integer
      Return _RecordCount
    End Function
    'Select By ID One Record Filtered Overloaded GetByID
    <DataObjectMethod(DataObjectMethodType.Insert, True)>
    Public Shared Function cDmsERPMappingInsert(ByVal Record As SIS.xDMS.cDmsERPMapping) As SIS.xDMS.cDmsERPMapping
      Dim _Rec As SIS.xDMS.cDmsERPMapping = SIS.xDMS.cDmsERPMapping.cDmsERPMappingGetNewRecord()
      With _Rec
        .TransmittalTypeID = Record.TransmittalTypeID
        .FolderName = Record.FolderName
        .ParentFolderID = Record.ParentFolderID
        .InitialWorkflowID = Record.InitialWorkflowID
        .ReleaseWorkflowID = Record.ReleaseWorkflowID
        .ReviseWorkflowID = Record.ReviseWorkflowID
        .ERPsrno = Record.ERPsrno
        .UploadStatusID = Record.UploadStatusID
        .Active = True
      End With
      Return SIS.xDMS.cDmsERPMapping.InsertData(_Rec)
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.cDmsERPMapping) As SIS.xDMS.cDmsERPMapping
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsERPMappingInsert"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransmittalTypeID", SqlDbType.Int, 11, Record.TransmittalTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderName", SqlDbType.NVarChar, 51, Record.FolderName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentFolderID", SqlDbType.Int, 11, Iif(Record.ParentFolderID = "", Convert.DBNull, Record.ParentFolderID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitialWorkflowID", SqlDbType.Int, 11, Iif(Record.InitialWorkflowID = "", Convert.DBNull, Record.InitialWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReleaseWorkflowID", SqlDbType.Int, 11, Iif(Record.ReleaseWorkflowID = "", Convert.DBNull, Record.ReleaseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReviseWorkflowID", SqlDbType.Int, 11, Iif(Record.ReviseWorkflowID = "", Convert.DBNull, Record.ReviseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active", SqlDbType.Bit, 3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPsrno", SqlDbType.Int, 11, Record.ERPsrno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadStatusID", SqlDbType.Int, 11, IIf(Record.UploadStatusID = "", Convert.DBNull, Record.UploadStatusID))
          Cmd.Parameters.Add("@Return_SerialNo", SqlDbType.Int, 11)
          Cmd.Parameters("@Return_SerialNo").Direction = ParameterDirection.Output
          Con.Open()
          Cmd.ExecuteNonQuery()
          Record.SerialNo = Cmd.Parameters("@Return_SerialNo").Value
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Update, True)>
    Public Shared Function cDmsERPMappingUpdate(ByVal Record As SIS.xDMS.cDmsERPMapping) As SIS.xDMS.cDmsERPMapping
      Dim _Rec As SIS.xDMS.cDmsERPMapping = SIS.xDMS.cDmsERPMapping.cDmsERPMappingGetByID(Record.SerialNo)
      With _Rec
        .TransmittalTypeID = Record.TransmittalTypeID
        .FolderName = Record.FolderName
        .ParentFolderID = Record.ParentFolderID
        .InitialWorkflowID = Record.InitialWorkflowID
        .ReleaseWorkflowID = Record.ReleaseWorkflowID
        .ReviseWorkflowID = Record.ReviseWorkflowID
        .ERPsrno = Record.ERPsrno
        .UploadStatusID = Record.UploadStatusID
        .Active = Record.Active
      End With
      Return SIS.xDMS.cDmsERPMapping.UpdateData(_Rec)
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.cDmsERPMapping) As SIS.xDMS.cDmsERPMapping
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsERPMappingUpdate"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo", SqlDbType.Int, 11, Record.SerialNo)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@TransmittalTypeID", SqlDbType.Int, 11, Record.TransmittalTypeID)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderName", SqlDbType.NVarChar, 51, Record.FolderName)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ParentFolderID", SqlDbType.Int, 11, Iif(Record.ParentFolderID = "", Convert.DBNull, Record.ParentFolderID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@InitialWorkflowID", SqlDbType.Int, 11, Iif(Record.InitialWorkflowID = "", Convert.DBNull, Record.InitialWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReleaseWorkflowID", SqlDbType.Int, 11, Iif(Record.ReleaseWorkflowID = "", Convert.DBNull, Record.ReleaseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReviseWorkflowID", SqlDbType.Int, 11, Iif(Record.ReviseWorkflowID = "", Convert.DBNull, Record.ReviseWorkflowID))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Active", SqlDbType.Bit, 3, Record.Active)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ERPsrno", SqlDbType.Int, 11, Record.ERPsrno)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@UploadStatusID", SqlDbType.Int, 11, IIf(Record.UploadStatusID = "", Convert.DBNull, Record.UploadStatusID))
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
    Public Shared Function cDmsERPMappingDelete(ByVal Record As SIS.xDMS.cDmsERPMapping) As Int32
      Dim _Result As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDmsERPMappingDelete"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Original_SerialNo", SqlDbType.Int, Record.SerialNo.ToString.Length, Record.SerialNo)
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
    Public Shared Function CreateFoldersForTransmittal(ProjectID As String, Comp As String) As Boolean
      Dim mRet As Boolean = True
      Try
        Dim prj As SIS.QCM.qcmProjects = SIS.QCM.qcmProjects.GetProjectFromERP(ProjectID, Comp)

        Dim maps As List(Of SIS.xDMS.cDmsERPMapping) = SIS.xDMS.cDmsERPMapping.cDmsERPMappingSelectList(0, 999, "", False, "")
        For Each map As SIS.xDMS.cDmsERPMapping In maps
          If map.ParentFolderID = "" Then map.ParentFolderID = "0"
          Dim FolderName As String = prj.ProjectID & "-" & prj.Description

          '1. Create Project Folder 
          Dim Found As Boolean = True
          Dim prjFld As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.UZ_xDmsFoldersGetByFolderName(FolderName, map.ParentFolderID)
          If prjFld Is Nothing Then
            prjFld = New SIS.xDMS.xDmsFolders
            Found = False
          End If
          With prjFld
            .FolderName = FolderName
            .KeyWords = "Prj:" & prj.ProjectID & ",Comp:" & Comp
            .Active = True
            .Hseq = 0
            .ItemTypeID = "Tran"
            If map.ParentFolderID = "0" Then
              .NodeLevel = 1
              .ParentFolderID = ""
            Else
              .NodeLevel = 1  ' As It is Not used, dynamically derived pFld.NodeLevel + 1
              .ParentFolderID = map.ParentFolderID
            End If
            .RequireExplicitAuthorization = False
            .StatusBy = "0340"
            .StatusID = enumStatus.Free
            .StatusOn = Now
            .StatusRemarks = "Created By System"
            .ProjectID = prj.ProjectID
            .CompanyID = Comp
          End With
          If Found Then
            prjFld = SIS.xDMS.xDmsFolders.UpdateData(prjFld)
          Else
            prjFld = SIS.xDMS.xDmsFolders.InsertData(prjFld)
          End If
          'In Case of PIPING, Not Found in ERP, do not create in Joomla
          Dim erpFld As SIS.xDMS.dmisg015 = Nothing
          'If map.FolderName = "PIPING" Then
          '  erpFld = SIS.xDMS.dmisg015.dmisg015GetByID(map.TransmittalTypeID, prj.ProjectID, map.FolderName, Comp)
          '  If erpFld Is Nothing Then Continue For
          'End If
          '2. Create mapped folder Under Project Folder
          Found = True
          Dim mapFld As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.UZ_xDmsFoldersGetByFolderName(map.FolderName, prjFld.FolderID)
          If mapFld Is Nothing Then
            mapFld = New SIS.xDMS.xDmsFolders
            Found = False
          End If
          With mapFld
            .FolderName = map.FolderName
            .KeyWords = "Prj:" & prj.ProjectID & ",Comp:" & Comp & ",EngFunc:" & map.ERPsrno
            .Active = True
            .Hseq = 0
            .ItemTypeID = "Tran"
            .NodeLevel = 1  ' As It is Not used, dynamically derived pFld.NodeLevel + 1
            .ParentFolderID = prjFld.FolderID
            .RequireExplicitAuthorization = False
            .StatusBy = "0340"
            .StatusID = enumStatus.Free
            .StatusOn = Now
            .StatusRemarks = "Created By System"
            .InitialWorkflowID = map.InitialWorkflowID
            .ReleaseWorkflowID = map.ReleaseWorkflowID
            .ReviseWorkflowID = map.ReviseWorkflowID
            .UploadedStatusID = map.UploadStatusID
            .ProjectID = prjFld.ProjectID
            .CompanyID = prjFld.CompanyID
          End With
          If Found Then
            mapFld = SIS.xDMS.xDmsFolders.UpdateData(mapFld)
          Else
            mapFld = SIS.xDMS.xDmsFolders.InsertData(mapFld)
          End If

          '3. Create Mapping in ERP
          Found = True
          erpFld = SIS.xDMS.dmisg015.dmisg015GetByID(map.TransmittalTypeID, prj.ProjectID, map.FolderName, Comp)
          If erpFld Is Nothing Then
            Found = False
            erpFld = New SIS.xDMS.dmisg015
            'If found in ERP dont change ERP srno
            erpFld.t_srno = map.ERPsrno
          End If
          With erpFld
            .t_cprj = prj.ProjectID
            .t_tfid = mapFld.FolderID
            .t_tfld = mapFld.FolderName
            .t_type = map.TransmittalTypeID
            .t_Refcntd = 0
            .t_Refcntu = 0
          End With
          If Found Then
            SIS.xDMS.dmisg015.UpdateData(erpFld, Comp)
          Else
            Try
              SIS.xDMS.dmisg015.InsertData(erpFld, Comp)
            Catch ex As Exception
              SIS.xDMS.dmisg015.UpdateData(erpFld, Comp)
            End Try
          End If
        Next
      Catch ex As Exception
        Throw New Exception("Error in creating Folder Structure", New Exception(ex.Message))
      End Try
      Return mRet
    End Function
  End Class
  Public Class TransmittalResp
    Public Property err As Boolean = False
    Public Property msg As String = "Success"
  End Class
End Namespace
