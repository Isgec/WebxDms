Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  Partial Public Class xDmsFldAuthByGrp
    Public Shadows Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Shadows Function GetDeleteable() As Boolean
      Dim mRet As Boolean = False
      Return mRet
    End Function
    Public Shadows ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shadows ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_xDmsFldAuthByGrpSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal GroupID As Int32) As List(Of SIS.xDMS.xDmsFldAuthByGrp)
      Dim Results As List(Of SIS.xDMS.xDmsFldAuthByGrp) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "UserID"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxdms_LG_xDmsFldAuthByGrpSelectListSearch"
            Cmd.CommandText = "spxDmsFldAuthByGrpSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxdms_LG_xDmsFldAuthByGrpSelectListFilteres"
            Cmd.CommandText = "spxDmsFldAuthByGrpSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_GroupID", SqlDbType.Int, 10, IIf(GroupID = Nothing, 0, GroupID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFldAuthByGrp)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFldAuthByGrp(Reader))
          End While
          Reader.Close()
          RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_xDmsFldAuthByGrpInsert(ByVal Record As SIS.xDMS.xDmsFldAuthByGrp) As SIS.xDMS.xDmsFldAuthByGrp
      Dim _Result As SIS.xDMS.xDmsFldAuthByGrp = xDmsFldAuthByGrpInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFldAuthByGrpUpdate(ByVal Record As SIS.xDMS.xDmsFldAuthByGrp) As SIS.xDMS.xDmsFldAuthByGrp
      Dim _Result As SIS.xDMS.xDmsFldAuthByGrp = xDmsFldAuthByGrpUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFldAuthByGrpDelete(ByVal Record As SIS.xDMS.xDmsFldAuthByGrp) As Int32
      Dim _Result As Integer = xDmsFolderAuthorizationsDelete(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFldAuthByGrpGetByID(ByVal GroupID As Int32, ByVal UserID As String, ByVal FolderID As Int32) As SIS.xDMS.xDmsFldAuthByGrp
      Dim Results As SIS.xDMS.xDmsFldAuthByGrp = xDmsFldAuthByGrpGetByID(GroupID, UserID, FolderID)
      Return Results
    End Function
  End Class
End Namespace
