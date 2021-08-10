Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  Public Class Dashboard


    Public Shared Function TotalCount() As Integer
      Dim cnt As Integer = 0
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDms_LG_NewFilesSinceLastLogout"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID", SqlDbType.Int, 10, 0)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnType", SqlDbType.Int, 10, enumReturnTypes.TotalCount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          cnt = Cmd.ExecuteScalar
        End Using
      End Using
      Return cnt
    End Function
    Public Shared Function FolderwiseCount() As List(Of SIS.xDMS.FolderFilseCount)
      Dim Fcnt As New List(Of SIS.xDMS.FolderFilseCount)
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.StoredProcedure
          Cmd.CommandText = "spxDms_LG_NewFilesSinceLastLogout"
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@FolderID", SqlDbType.Int, 10, 0)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@ReturnType", SqlDbType.Int, 10, enumReturnTypes.FolderwiseCount)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NVarChar, 9, HttpContext.Current.Session("LoginID"))
          Con.Open()
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While rd.Read()
            Fcnt.Add(New SIS.xDMS.FolderFilseCount(rd))
          End While
          rd.Close()
        End Using
      End Using
      Return Fcnt
    End Function

  End Class
  Public Class FolderFilseCount
    Public Property FolderID As Integer = 0
    Public Property xDMS_Folders3_FolderName As String = ""
    Public Property FilesCount As Integer = 0
    Sub New()

    End Sub
    Sub New(rd As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, rd)
    End Sub
  End Class
End Namespace