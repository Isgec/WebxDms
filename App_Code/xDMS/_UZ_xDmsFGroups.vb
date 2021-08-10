Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  Partial Public Class xDmsFGroups
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
    Public ReadOnly Property InitiateWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property InitiateWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function InitiateWF(ByVal FGroupID As Int32) As SIS.xDMS.xDmsFGroups
      Dim Results As SIS.xDMS.xDmsFGroups = xDmsFGroupsGetByID(FGroupID)
      Return Results
    End Function
    Public Shared Function UZ_xDmsFGroupsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.xDMS.xDmsFGroups)
      Dim Results As List(Of SIS.xDMS.xDmsFGroups) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "FGroupID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxdms_LG_xDmsFGroupsSelectListSearch"
            Cmd.CommandText = "spxDmsFGroupsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxdms_LG_xDmsFGroupsSelectListFilteres"
            Cmd.CommandText = "spxDmsFGroupsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsFGroups)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsFGroups(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_xDmsFGroupsInsert(ByVal Record As SIS.xDMS.xDmsFGroups) As SIS.xDMS.xDmsFGroups
      Dim _Result As SIS.xDMS.xDmsFGroups = xDmsFGroupsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFGroupsUpdate(ByVal Record As SIS.xDMS.xDmsFGroups) As SIS.xDMS.xDmsFGroups
      Dim _Result As SIS.xDMS.xDmsFGroups = xDmsFGroupsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsFGroupsDelete(ByVal Record As SIS.xDMS.xDmsFGroups) As Integer
      Dim _Result as Integer = xDmsFGroupsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_FGroupID"), TextBox).Text = ""
        CType(.FindControl("F_FGroupName"), TextBox).Text = ""
        CType(.FindControl("F_RequireExplicitAuthorization"), CheckBox).Checked = False
        CType(.FindControl("F_RequireExplicitWorkflow"), CheckBox).Checked = False
        CType(.FindControl("F_ReleaseWorkflowID"), TextBox).Text = ""
        CType(.FindControl("F_ReleaseWorkflowID_Display"), Label).Text = ""
        CType(.FindControl("F_ReviseWorkflowID"), TextBox).Text = ""
        CType(.FindControl("F_ReviseWorkflowID_Display"), Label).Text = ""
        CType(.FindControl("F_UseFileTypeWorkflow"), CheckBox).Checked = False
        CType(.FindControl("F_DuplicateFileNameAllowed"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
