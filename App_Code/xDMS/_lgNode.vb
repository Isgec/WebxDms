Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Web.Script.Serialization
Namespace SIS.DMS

  Public Class vaultFile
    Public Property FileID As String = ""
    Public Property DRID As String = ""

  End Class
  Public Class Node
    Public Shared Function GetNode(ItemID As Integer, lvl As Integer) As String
      Dim mRet As String = ""
      Dim pItm As SIS.xDMS.xDmsFolders = Nothing
      Dim cItems As List(Of SIS.xDMS.xDmsFolders) = SIS.xDMS.xDmsFolders.UZ_xDmsChildFoldersGetByID(ItemID)
      If ItemID > 0 Then
        pItm = SIS.xDMS.xDmsFolders.UZ_xDmsFoldersGetByID(ItemID)
      Else
        mRet &= "<div style='display:flex;flex-direction:row;justify-content:space-between;background-color:#d5d4d4;'><div class='nt-but-silver' style='width:24px;' onclick='window.history.back();'><i class='fas fa-tachometer-alt' style=color:lime;font-size:14px;'></i></div><div class='nt-but-silver' onclick='return xdms_script.loadItem();'><i class='fas fa-sync' style=color:dodgerblue;font-size:14px;'></i></div></div>"
        pItm = New SIS.xDMS.xDmsFolders
        With pItm
          .FolderID = 0
          .FolderName = "FOLDER"
          .NodeLevel = 0
          .FoldersCount = cItems.Count
          .FilesCount = 0
        End With
      End If
      mRet &= GetDiv(pItm, True, True, lvl)
      For Each x As SIS.xDMS.xDmsFolders In cItems
        mRet &= GetDiv(x, False, False, lvl + 1)
      Next
      mRet &= "</div>"
      Return mRet
    End Function
    Private Shared Function GetDiv(x As SIS.xDMS.xDmsFolders, noTerm As Boolean, isSrc As Boolean, lvl As Integer) As String
      Dim mRet As String = ""
      mRet &= "<div id='ci_" & x.FolderID & "' class='nt-xcol'>"
      'Item row
      mRet &= "<div id='c_" & x.FolderID & "' class='nt-xrow nt-item-row' data-lvl='" & lvl & "' onclick='return xdms_script.showDetails(this);' oncontextmenu='xmnu_script.showMenu(this,event);'>"
      'Separators
      For i As Integer = 0 To lvl ' x.NodeLevel
        mRet &= "<div class='nt-sep'>&nbsp;</div>"
      Next
      If x.FoldersCount > 0 AndAlso Not isSrc Then
        mRet &= "<div id='e_" & x.FolderID & "' class='nt-xsep' data-xd='0' data-ld='0' data-lvl='" & lvl & "' onclick='return xdms_script.loadItem(this);'>+</div>"
      Else
        mRet &= "<div id='e_" & x.FolderID & "' class='nt-xsep' data-xd='1' data-ld='1' data-lvl='" & lvl & "' onclick='return xdms_script.loadItem(this);'>-</div>"
      End If
      'Child count
      mRet &= "<div class='nt-count'>" & x.FoldersCount & "</div>"
      mRet &= "<div class='nt-fcount'>" & x.FilesCount & "</div>"
      'Item
      mRet &= "<div id='i_" & x.FolderID & "' class='nt-item' onclick='return xdms_script.toggleView(this);'>" & x.FolderName & "</div>"
      mRet &= "</div>" 'End of Item row
      If Not noTerm Then
        mRet &= "</div>"
      End If
      Return mRet
    End Function

  End Class

  Partial Public Class DmsFolders
    Public Property FolderID As Int32 = 0
    Public Property FolderName As String = ""
    Public Property ItemTypeID As String = ""
    Public Property ParentFolderID As String = ""
    Public Property StatusBy As String = ""
    Private _StatusOn As String = ""
    Public Property StatusID As Int32 = 0
    Public Property StatusRemarks As String = ""
    Public Property KeyWords As String = ""
    Public Property Active As Boolean = False
    Public Property NodeLevel As Int32 = 0
    Public Property Hseq As Int32 = 0
    Public Property RequireExplicitAuthorization As Boolean = False
    Public Property FoldersCount As Integer = 0
    Public Property FilesCount As Integer = 0
    Public Property aspnet_Users1_UserFullName As String = ""
    Public Property xDMS_Folders2_FolderName As String = ""
    Public Property xDMS_ItemTypes3_ItemName As String = ""
    Public Property xDMS_States4_StatusName As String = ""
    Public Property StatusOn() As String
      Get
        If Not _StatusOn = String.Empty Then
          Return Convert.ToDateTime(_StatusOn).ToString("dd/MM/yyyy")
        End If
        Return _StatusOn
      End Get
      Set(ByVal value As String)
        If Convert.IsDBNull(value) Then
          _StatusOn = ""
        Else
          _StatusOn = value
        End If
      End Set
    End Property
    Public Shared Function ConvertTo(ByVal Record As SIS.DMS.DmsFolders) As SIS.xDMS.xDmsFolders
      Dim _Rec As New SIS.xDMS.xDmsFolders
      With _Rec
        .FolderName = Record.FolderName
        .ItemTypeID = Record.ItemTypeID
        .ParentFolderID = Record.ParentFolderID
        .StatusBy = Record.StatusBy
        .StatusOn = Record.StatusOn
        .StatusID = Record.StatusID
        .StatusRemarks = Record.StatusRemarks
        .KeyWords = Record.KeyWords
        .Active = Record.Active
        .NodeLevel = Record.NodeLevel
        .Hseq = Record.Hseq
        .RequireExplicitAuthorization = Record.RequireExplicitAuthorization
        .FoldersCount = Record.FoldersCount
        .FilesCount = Record.FilesCount
      End With
      Return SIS.xDMS.xDmsFolders.InsertData(_Rec)
    End Function
    Public Shared Function ConvertTo(ByVal Record As SIS.xDMS.xDmsFolders) As SIS.DMS.DmsFolders
      Dim _Rec As New SIS.DMS.DmsFolders
      With _Rec
        .FolderName = Record.FolderName
        .ItemTypeID = Record.ItemTypeID
        .ParentFolderID = Record.ParentFolderID
        .StatusBy = Record.StatusBy
        .StatusOn = Record.StatusOn
        .StatusID = Record.StatusID
        .StatusRemarks = Record.StatusRemarks
        .KeyWords = Record.KeyWords
        .Active = Record.Active
        .NodeLevel = Record.NodeLevel
        .Hseq = Record.Hseq
        .RequireExplicitAuthorization = Record.RequireExplicitAuthorization
        .FoldersCount = Record.FoldersCount
        .FilesCount = Record.FilesCount
      End With
      Return _Rec
    End Function
    Public Sub New()
    End Sub
  End Class

  Public Class SysUser
    Public Shared Function CreateUserDefaulst(LoginID As String) As Boolean
      'Called from Master Page Loggedin Event Handler
      Dim usr As SIS.xDMS.xDmsUsers = SIS.xDMS.xDmsUsers.xDmsUsersGetByID(LoginID)
      If usr Is Nothing Then
        usr = New SIS.xDMS.xDmsUsers
        With usr
          .CreateRootLevelFolder = False
          .CanAuthorizeFolder = False
          .CanPassAuthorization = False
          .CanViewAllRevisions = True
          .CreateFolder = True
          .UpdateFolder = True
          .DeleteFolder = True
          .UploadFile = True
          .DownloadFile = True
          .DeleteFile = True
          .IsAdmin = False
          .IsSAdmin = False
          .GroupID = ""
          .UserID = LoginID
        End With
        SIS.xDMS.xDmsUsers.InsertData(usr)
      End If
      If Not Convert.ToBoolean(ConfigurationManager.AppSettings("CreateDefaultUserFolder")) Then Return True

      Dim fld As SIS.xDMS.xDmsFolders = SIS.xDMS.xDmsFolders.UZ_xDmsFoldersGetByFolderName(LoginID & "_Folder")
      If fld Is Nothing Then
        fld = New SIS.xDMS.xDmsFolders
        With fld
          .FolderName = LoginID & "_Folder"
          .ItemTypeID = "SysUsrFld"
          .ParentFolderID = ""
          .StatusBy = LoginID
          .StatusOn = Now
          .StatusID = enumStatus.SysLock
          .StatusRemarks = "System Created User Folder"
          .KeyWords = "System Created User Folder"
          .Active = True
          .NodeLevel = 1
          .Hseq = 0
          .RequireExplicitAuthorization = False
        End With
        fld = SIS.xDMS.xDmsFolders.InsertData(fld)
      End If
      Dim usrFld As SIS.xDMS.xDmsFolderAuthorizations = SIS.xDMS.xDmsFolderAuthorizations.xDmsFolderAuthorizationsGetByID(usr.UserID, fld.FolderID)
      If usrFld Is Nothing Then
        usrFld = New SIS.xDMS.xDmsFolderAuthorizations
        With usrFld
          .UserID = usr.UserID
          .FolderID = fld.FolderID
          .CreateFolder = True
          .UpdateFolder = True
          .DeleteFolder = True
          .UploadFile = True
          .DownloadFile = True
          .DeleteFile = True
          .CanAuthorizeFolder = True
          .CanPassAuthorization = True
          .CreatedBy = ""
          .CreatedOn = Now
        End With
        usrFld = SIS.xDMS.xDmsFolderAuthorizations.InsertData(usrFld)
      End If
      Return True
    End Function

  End Class

  Public Class apiTags
    Public Property tagID As String = ""
    Public Property tagType As String = ""
    Public Property tagDescription As String = ""
    Public Property active As Boolean = False
    Public Property parentTagID As String = ""

    Public Shared Function selectAutoComplete(prefix As String, Optional count As Integer = 10) As String
      Dim mret As New List(Of String)
      Try
        Using Con As SqlConnection = New SqlConnection(SIS.SYS.SQLDatabase.DBCommon.GetConnectionString())
          Using Cmd As SqlCommand = Con.CreateCommand()
            Cmd.CommandType = CommandType.Text
            Cmd.CommandText = "select top " & count & " * from DMS_Tags where upper(tagID) like '" & prefix.ToUpper & "%'"
            Con.Open()
            Dim Reader As SqlDataReader = Cmd.ExecuteReader()
            While Reader.Read()
              mret.Add(Reader("tagID") & ", " & Reader("tagDescription"))
            End While
            Reader.Close()
          End Using
        End Using
        Return New JavaScriptSerializer().Serialize(New With {.err = False, .strHTML = mret})

      Catch ex As Exception
        Return New JavaScriptSerializer().Serialize(New With {.err = True, .msg = ex.Message})

      End Try
    End Function

    Sub New(rd As SqlDataReader)
      SIS.SYS.SQLDatabase.DBCommon.NewObj(Me, rd)
    End Sub
    Sub New()
    End Sub
  End Class

End Namespace
