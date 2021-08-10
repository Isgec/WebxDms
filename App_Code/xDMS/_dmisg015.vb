Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  <DataObject()> _
  Partial Public Class dmisg015
    Private Shared _RecordCount As Integer
    Public Property t_type As Int32 = 0
    Public Property t_cprj As String = ""
    Public Property t_srno As Int32 = 0
    Public Property t_tfld As String = ""
    Public Property t_tfid As Int32 = 0
    Public Property t_Refcntd As Int32 = 0
    Public Property t_Refcntu As Int32 = 0
    Public ReadOnly Property DisplayField() As String
      Get
        Return ""
      End Get
    End Property
    Public Readonly Property PrimaryKey() As String
      Get
        Return _t_type & "|" & _t_cprj & "|" & _t_srno
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
    Public Class PKdmisg015
      Private _t_type As Int32 = 0
      Private _t_cprj As String = ""
      Private _t_srno As Int32 = 0
      Public Property t_type() As Int32
        Get
          Return _t_type
        End Get
        Set(ByVal value As Int32)
          _t_type = value
        End Set
      End Property
      Public Property t_cprj() As String
        Get
          Return _t_cprj
        End Get
        Set(ByVal value As String)
          _t_cprj = value
        End Set
      End Property
      Public Property t_srno() As Int32
        Get
          Return _t_srno
        End Get
        Set(ByVal value As Int32)
          _t_srno = value
        End Set
      End Property
    End Class
    <DataObjectMethod(DataObjectMethodType.Select)> _
    Public Shared Function dmisg015GetNewRecord() As SIS.xDMS.dmisg015
      Return New SIS.xDMS.dmisg015()
    End Function
    <DataObjectMethod(DataObjectMethodType.Select)>
    Public Shared Function dmisg015GetByID(ByVal t_type As Int32, ByVal t_cprj As String, ByVal t_tfld As String, Comp As String) As SIS.xDMS.dmisg015
      Dim Sql As String = ""
      Sql &= "  SELECT * "
      Sql &= "  FROM tdmisg015" & Comp
      Sql &= "  WHERE "
      Sql &= "  t_type = " & t_type
      Sql &= "  AND t_cprj = '" & t_cprj.ToUpper & "'"
      Sql &= "  And lower(t_tfld) = '" & t_tfld.ToLower & "'"
      Dim Results As SIS.xDMS.dmisg015 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.dmisg015(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function InsertData(ByVal Record As SIS.xDMS.dmisg015, Comp As String) As SIS.xDMS.dmisg015
      Dim Sql As String = ""
      Sql &= "  INSERT [tdmisg015" & Comp & " ] "
      Sql &= "  (                               "
      Sql &= "   [t_type]                       "
      Sql &= "  ,[t_cprj]                       "
      Sql &= "  ,[t_srno]                       "
      Sql &= "  ,[t_tfld]                       "
      Sql &= "  ,[t_tfid]                       "
      Sql &= "  ,[t_Refcntd]                    "
      Sql &= "  ,[t_Refcntu]                    "
      Sql &= "  )                               "
      Sql &= "  VALUES                          "
      Sql &= "  (                               "
      Sql &= "  " & Record.t_type & ""
      Sql &= ",'" & Record.t_cprj.ToUpper & "'"
      Sql &= ", " & Record.t_srno & ""
      Sql &= ",'" & Record.t_tfld & "'"
      Sql &= ", " & Record.t_tfid & ""
      Sql &= ", " & Record.t_Refcntd & ""
      Sql &= ", " & Record.t_Refcntu & ""
      Sql &= "  )  "
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return Record
    End Function
    Public Shared Function UpdateData(ByVal Record As SIS.xDMS.dmisg015, Comp As String) As SIS.xDMS.dmisg015
      Dim Sql As String = ""
      Sql &= "  UPDATE [tdmisg015" & Comp & " ] SET "
      Sql &= "   [t_type] = " & Record.t_type
      Sql &= "  ,[t_cprj] = '" & Record.t_cprj.ToUpper & "'"
      Sql &= "  ,[t_srno] = " & Record.t_srno
      Sql &= "  ,[t_tfld] = '" & Record.t_tfld & "'"
      Sql &= "  ,[t_tfid] = " & Record.t_tfid
      Sql &= "  ,[t_Refcntd] = " & Record.t_Refcntd
      Sql &= "  ,[t_Refcntu] = " & Record.t_Refcntu
      Sql &= "  WHERE "
      Sql &= "  [t_type] = " & Record.t_type
      Sql &= "  AND [t_cprj] = '" & Record.t_cprj.ToUpper & "'"
      Sql &= "  And [t_srno] = " & Record.t_srno
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return Record
    End Function
    <DataObjectMethod(DataObjectMethodType.Delete, True)>
    Public Shared Function dmisg015Delete(ByVal Record As SIS.xDMS.dmisg015, Comp As String) As Int32
      Dim Sql As String = ""
      Sql &= "  DELETE [tdmisg015" & Comp & " ] "
      Sql &= "  WHERE "
      Sql &= "  [t_type] = " & Record.t_type
      Sql &= "  AND [t_cprj] = '" & Record.t_cprj.ToUpper & "'"
      Sql &= "  And [t_srno] = " & Record.t_srno
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Cmd.ExecuteNonQuery()
        End Using
      End Using
      Return 0
    End Function
    Public Shared Function GetByFLDName(ByVal t_type As Int32, ByVal t_cprj As String, ByVal t_tfld As String, Comp As String) As SIS.xDMS.dmisg015
      Dim Sql As String = ""
      Sql &= "  SELECT * "
      Sql &= "  FROM tdmisg015" & Comp
      Sql &= "  WHERE "
      Sql &= "  t_type = " & t_type
      Sql &= "  AND t_cprj = '" & t_cprj.ToUpper & "'"
      Sql &= "  And lower(t_tfld) = '" & t_tfld.ToLower & "'"
      Dim Results As SIS.xDMS.dmisg015 = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetBaaNConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          If Reader.Read() Then
            Results = New SIS.xDMS.dmisg015(Reader)
          End If
          Reader.Close()
        End Using
      End Using
      Return Results
    End Function

    Public Sub New(ByVal Reader As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, Reader)
    End Sub
    Public Sub New()
    End Sub
  End Class
End Namespace
