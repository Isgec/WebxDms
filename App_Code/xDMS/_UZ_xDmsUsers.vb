Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  Partial Public Class xDmsUsers
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
    Public Shared Function UZ_xDmsUsersSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String, ByVal UserID As String) As List(Of SIS.xDMS.xDmsUsers)
      Dim Results As List(Of SIS.xDMS.xDmsUsers) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "UserID"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxdms_LG_xDmsUsersSelectListSearch"
            Cmd.CommandText = "spxdmsUsersSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxdms_LG_xDmsUsersSelectListFilteres"
            Cmd.CommandText = "spxdmsUsersSelectListFilteres"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@Filter_UserID",SqlDbType.NVarChar,8, IIf(UserID Is Nothing, String.Empty,UserID))
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsUsers)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsUsers(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_xDmsUsersInsert(ByVal Record As SIS.xDMS.xDmsUsers) As SIS.xDMS.xDmsUsers
      Dim _Result As SIS.xDMS.xDmsUsers = xDmsUsersInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsUsersUpdate(ByVal Record As SIS.xDMS.xDmsUsers) As SIS.xDMS.xDmsUsers
      Dim _Result As SIS.xDMS.xDmsUsers = xDmsUsersUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsUsersDelete(ByVal Record As SIS.xDMS.xDmsUsers) As Integer
      Dim _Result as Integer = xDmsUsersDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_UserID"), TextBox).Text = ""
          CType(.FindControl("F_UserID_Display"), Label).Text = ""
          CType(.FindControl("F_CreateRootLevelFolder"), CheckBox).Checked = False
          CType(.FindControl("F_CreateFolder"), CheckBox).Checked = False
          CType(.FindControl("F_UpdateFolder"), CheckBox).Checked = False
          CType(.FindControl("F_DeleteFolder"), CheckBox).Checked = False
          CType(.FindControl("F_UploadFile"), CheckBox).Checked = False
          CType(.FindControl("F_DownloadFile"), CheckBox).Checked = False
          CType(.FindControl("F_DeleteFile"), CheckBox).Checked = False
          CType(.FindControl("F_IsAdmin"), CheckBox).Checked = False
          CType(.FindControl("F_CanPassAuthorization"), CheckBox).Checked = False
          CType(.FindControl("F_CanAuthorizeFolder"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
