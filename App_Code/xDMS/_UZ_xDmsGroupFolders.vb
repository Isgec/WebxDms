Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Namespace SIS.xDMS
  Partial Public Class xDmsGroupFolders
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
    Public ReadOnly Property DeleteWFVisible() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetVisible()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public ReadOnly Property DeleteWFEnable() As Boolean
      Get
        Dim mRet As Boolean = True
        Try
          mRet = GetEnable()
        Catch ex As Exception
        End Try
        Return mRet
      End Get
    End Property
    Public Shared Function DeleteWF(ByVal GroupID As Int32, ByVal FolderID As Int32) As SIS.xDMS.xDmsGroupFolders
      Dim Results As SIS.xDMS.xDmsGroupFolders = xDmsGroupFoldersGetByID(GroupID, FolderID)
      Return Results
    End Function
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
    Public Shared Function InitiateWF(ByVal GroupID As Int32, ByVal FolderID As Int32) As SIS.xDMS.xDmsGroupFolders
      Dim Results As SIS.xDMS.xDmsGroupFolders = xDmsGroupFoldersGetByID(GroupID, FolderID)
      Return Results
    End Function
    Public Shared Function SetDefaultValues(ByVal sender As System.Web.UI.WebControls.FormView, ByVal e As System.EventArgs) As System.Web.UI.WebControls.FormView
      With sender
        Try
        CType(.FindControl("F_GroupID"), TextBox).Text = ""
        CType(.FindControl("F_GroupID_Display"), Label).Text = ""
        CType(.FindControl("F_FolderID"), TextBox).Text = ""
        CType(.FindControl("F_FolderID_Display"), Label).Text = ""
        CType(.FindControl("F_CreateFolder"), CheckBox).Checked = False
        CType(.FindControl("F_UpdateFolder"), CheckBox).Checked = False
        CType(.FindControl("F_DeleteFolder"), CheckBox).Checked = False
        CType(.FindControl("F_UploadFile"), CheckBox).Checked = False
        CType(.FindControl("F_DownloadFile"), CheckBox).Checked = False
        CType(.FindControl("F_DeleteFile"), CheckBox).Checked = False
        CType(.FindControl("F_CanAuthorizeFolder"), CheckBox).Checked = False
        CType(.FindControl("F_CanPassAuthorization"), CheckBox).Checked = False
        Catch ex As Exception
        End Try
      End With
      Return sender
    End Function
  End Class
End Namespace
