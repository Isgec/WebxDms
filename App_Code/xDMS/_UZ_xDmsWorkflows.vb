Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  Partial Public Class xDmsWorkflows
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
    Public Shared Function UZ_xDmsWorkflowsSelectList(ByVal StartRowIndex As Integer, ByVal MaximumRows As Integer, ByVal OrderBy As String, ByVal SearchState As Boolean, ByVal SearchText As String) As List(Of SIS.xDMS.xDmsWorkflows)
      Dim Results As List(Of SIS.xDMS.xDmsWorkflows) = Nothing
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          If OrderBy = String.Empty Then OrderBy = "WorkflowID DESC"
          Cmd.CommandType = CommandType.StoredProcedure
          If SearchState Then
            Cmd.CommandText = "spxdms_LG_xDmsWorkflowsSelectListSearch"
            Cmd.CommandText = "spxDmsWorkflowsSelectListSearch"
            SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@KeyWord", SqlDbType.NVarChar, 250, SearchText)
          Else
            Cmd.CommandText = "spxdms_LG_xDmsWorkflowsSelectListFilteres"
            Cmd.CommandText = "spxDmsWorkflowsSelectListFilteres"
          End If
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@StartRowIndex", SqlDbType.Int, -1, StartRowIndex)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@MaximumRows", SqlDbType.Int, -1, MaximumRows)
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@LoginID", SqlDbType.NvarChar, 9, HttpContext.Current.Session("LoginID"))
          SIS.SYS.SQLDatabase.DBCommon.AddDBParameter(Cmd, "@OrderBy", SqlDbType.NVarChar, 50, OrderBy)
          Cmd.Parameters.Add("@RecordCount", SqlDbType.Int)
          Cmd.Parameters("@RecordCount").Direction = ParameterDirection.Output
          _RecordCount = -1
          Results = New List(Of SIS.xDMS.xDmsWorkflows)()
          Con.Open()
          Dim Reader As SqlDataReader = Cmd.ExecuteReader()
          While (Reader.Read())
            Results.Add(New SIS.xDMS.xDmsWorkflows(Reader))
          End While
          Reader.Close()
          _RecordCount = Cmd.Parameters("@RecordCount").Value
        End Using
      End Using
      Return Results
    End Function
    Public Shared Function UZ_xDmsWorkflowsInsert(ByVal Record As SIS.xDMS.xDmsWorkflows) As SIS.xDMS.xDmsWorkflows
      Dim _Result As SIS.xDMS.xDmsWorkflows = xDmsWorkflowsInsert(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsWorkflowsUpdate(ByVal Record As SIS.xDMS.xDmsWorkflows) As SIS.xDMS.xDmsWorkflows
      Dim _Result As SIS.xDMS.xDmsWorkflows = xDmsWorkflowsUpdate(Record)
      Return _Result
    End Function
    Public Shared Function UZ_xDmsWorkflowsDelete(ByVal Record As SIS.xDMS.xDmsWorkflows) As Integer
      Dim _Result as Integer = xDmsWorkflowsDelete(Record)
      Return _Result
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
          CType(.FindControl("F_WorkflowID"), TextBox).Text = ""
          CType(.FindControl("F_WorkflowName"), TextBox).Text = ""
          CType(.FindControl("F_ParentWorkflowID"), TextBox).Text = ""
          CType(.FindControl("F_ParentWorkflowID_Display"), Label).Text = ""
          CType(.FindControl("F_InitialStatusID"), Object).SelectedValue = ""
          CType(.FindControl("F_FinalStatusID"), Object).SelectedValue = ""
          CType(.FindControl("F_UserID"), TextBox).Text = ""
          CType(.FindControl("F_UserID_Display"), Label).Text = ""
          CType(.FindControl("F_GroupID"), TextBox).Text = ""
          CType(.FindControl("F_GroupID_Display"), Label).Text = ""
          CType(.FindControl("F_DynamicSelectUserID"), CheckBox).Checked = False
          CType(.FindControl("F_DynamicSelectUserIDFromGroup"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
    Public Shared Function GetMatchingWFStep(wfID As Integer, initialStatusID As Integer) As SIS.xDMS.xDmsWorkflows
      'There may be more than one chile having same initial status
      'Control this in entry that it should not happen
      'Auto assign initial status from parents final status
      Dim mRet As SIS.xDMS.xDmsWorkflows = Nothing
      Dim Sql As String = ""
      Sql &= "  WITH xcte (workflowid,initialstatusid) AS ( "
      Sql &= "    SELECT workflowid, initialstatusid FROM xdms_workflows WHERE workflowid=" & wfID
      Sql &= "    UNION ALL "
      Sql &= "  SELECT c.workflowid, c.initialstatusid FROM xdms_workflows c INNER JOIN xcte ON xcte.workflowid = c.parentworkflowid )"
      Sql &= "  SELECT top 1 * FROM xcte where initialstatusid=" & initialStatusID
      Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
        Using Cmd As SqlCommand = Con.CreateCommand()
          Cmd.CommandType = CommandType.Text
          Cmd.CommandText = Sql
          Con.Open()
          Dim rd As SqlDataReader = Cmd.ExecuteReader
          While rd.Read
            mRet = SIS.xDMS.xDmsWorkflows.xDmsWorkflowsGetByID(rd("WorkflowID"))
          End While
        End Using
      End Using
      Return mRet
    End Function
  End Class
End Namespace
