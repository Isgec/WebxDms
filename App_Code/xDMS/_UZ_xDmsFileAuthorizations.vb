Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  Partial Public Class xDmsFileAuthorizations
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
    Public Shared Function UZ_xDmsFileAuthorizationsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String, ByVal FileID As Int32, ByVal CreatedBy As String) As List(Of SIS.xDMS.xDmsFileAuthorizations)
      Dim Results As List(Of SIS.xDMS.xDmsFileAuthorizations) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "UserID"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxdms_LG_xDmsFileAuthorizationsSelectListSearch"
            Cmd.CommandText = "spxdmsFileAuthorizationsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxdms_LG_xDmsFileAuthorizationsSelectListFilteres"
            Cmd.CommandText = "spxdmsFileAuthorizationsSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserID",SqlDbType.NVarChar,8, IIf(UserID Is Nothing, String.Empty,UserID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_FileID",SqlDbType.Int,10, IIf(FileID = Nothing, 0,FileID))
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_CreatedBy",SqlDbType.NVarChar,8, IIf(CreatedBy Is Nothing, String.Empty,CreatedBy))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFileAuthorizations)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFileAuthorizations(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_xDmsFileAuthorizationsInsert(ByVal Record As SIS.xDMS.xDmsFileAuthorizations) As SIS.xDMS.xDmsFileAuthorizations
      Dim _Result As SIS.xDMS.xDmsFileAuthorizations = xDmsFileAuthorizationsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFileAuthorizationsUpdate(ByVal Record As SIS.xDMS.xDmsFileAuthorizations) As SIS.xDMS.xDmsFileAuthorizations
      Dim _Result As SIS.xDMS.xDmsFileAuthorizations = xDmsFileAuthorizationsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFileAuthorizationsDelete(ByVal Record As SIS.xDMS.xDmsFileAuthorizations) As Integer
      Dim _Result as Integer = xDmsFileAuthorizationsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_UserID"), TextBox).Text = ""
        CType(.FindControl("F_UserID_Display"), Label).Text = ""
        CType(.FindControl("F_FileID"), TextBox).Text = ""
        CType(.FindControl("F_FileID_Display"), Label).Text = ""
        CType(.FindControl("F_DownloadFile"), CheckBox).Checked = False
        CType(.FindControl("F_DeleteFile"), CheckBox).Checked = False
        CType(.FindControl("F_CreatedBy"), TextBox).Text = ""
        CType(.FindControl("F_CreatedBy_Display"), Label).Text = ""
        CType(.FindControl("F_CreatedOn"), TextBox).Text = ""
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
