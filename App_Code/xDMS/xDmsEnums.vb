Imports Microsoft.VisualBasic

Public Enum enumBaseStatus
  Free = 1
  WIP = 2 'Workin In Progress, checked In, working by uploaded / group users
  WIPOut = 3 'Work In Progress, Checked Out
  UIWF = 4 'Under Initial Workflow
  Released = 6 'Document will be revised
  Superseded = 7 'Old Revision
  Closed = 8 'No action can be performed on file
  SysLock = 9 'NOT Used
  UREWF = 10 'Under Release Work flow
  URVWF = 11 'Under Revise workflow
End Enum
Public Enum enumStatus
  Free = 1
  Published = 5
  Released = 6
  CheckedOut = 20
  SysLock = 50
End Enum
Public Enum enumReturnTypes
  TotalCount = 1
  FolderwiseCount = 2
  TotalList = 3
  FolderList = 4
End Enum