Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  Partial Public Class xDmsFileTypes
    Public Function GetColor() As System.Drawing.Color
      Dim mRet As System.Drawing.Color = Drawing.Color.Blue
      Return mRet
    End Function
    Public Function GetVisible() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEnable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetEditable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public Function GetDeleteable() As Boolean
      Dim mRet As Boolean = True
      Return mRet
    End Function
    Public ReadOnly Property Editable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEditable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property Deleteable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetDeleteable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function UZ_xDmsFileTypesSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.xDMS.xDmsFileTypes)
      Dim Results As List(Of SIS.xDMS.xDmsFileTypes) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FileTypeID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxdms_LG_xDmsFileTypesSelectListSearch"
            Cmd.CommandText = "spxDmsFileTypesSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxdms_LG_xDmsFileTypesSelectListFilteres"
            Cmd.CommandText = "spxDmsFileTypesSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFileTypes)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFileTypes(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_xDmsFileTypesInsert(ByVal Record As SIS.xDMS.xDmsFileTypes) As SIS.xDMS.xDmsFileTypes
      Dim _Result As SIS.xDMS.xDmsFileTypes = xDmsFileTypesInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFileTypesUpdate(ByVal Record As SIS.xDMS.xDmsFileTypes) As SIS.xDMS.xDmsFileTypes
      Dim _Result As SIS.xDMS.xDmsFileTypes = xDmsFileTypesUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFileTypesDelete(ByVal Record As SIS.xDMS.xDmsFileTypes) As Integer
      Dim _Result as Integer = xDmsFileTypesDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_FileTypeID"), TextBox).Text = ""
        CType(.FindControl("F_FileTypeName"), TextBox).Text = ""
        CType(.FindControl("F_BasedOnFileExtension"), CheckBox).Checked = False
        CType(.FindControl("F_FileExtentionList"), TextBox).Text = ""
        CType(.FindControl("F_ReleaseWorkflowID"), TextBox).Text = ""
        CType(.FindControl("F_ReleaseWorkflowID_Display"), Label).Text = ""
        CType(.FindControl("F_ReviseWorkflowID"), TextBox).Text = ""
        CType(.FindControl("F_ReviseWorkflowID_Display"), Label).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
