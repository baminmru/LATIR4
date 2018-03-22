VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "Comdlg32.ocx"
Object = "{38911DA0-E448-11D0-84A3-00DD01104159}#1.1#0"; "COMCT332.OCX"
Begin VB.Form frmObj 
   ClientHeight    =   5985
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   9975
   Icon            =   "frmObj.frx":0000
   LinkTopic       =   "Form1"
   MDIChild        =   -1  'True
   ScaleHeight     =   5985
   ScaleWidth      =   9975
   Begin ComCtl3.CoolBar CoolBar1 
      Align           =   1  'Align Top
      Height          =   615
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   9975
      _ExtentX        =   17595
      _ExtentY        =   1085
      BandCount       =   2
      FixedOrder      =   -1  'True
      _CBWidth        =   9975
      _CBHeight       =   615
      _Version        =   "6.7.9782"
      Child1          =   "frmState"
      MinHeight1      =   555
      Width1          =   4995
      FixedBackground1=   0   'False
      NewRow1         =   0   'False
      Child2          =   "frmBtns"
      MinHeight2      =   555
      Width2          =   1935
      NewRow2         =   0   'False
      Begin VB.Frame frmState 
         BorderStyle     =   0  'None
         Height          =   555
         Left            =   30
         TabIndex        =   2
         Top             =   30
         Width           =   4935
         Begin VB.CommandButton cmdChange 
            Height          =   420
            Left            =   4395
            Style           =   1  'Graphical
            TabIndex        =   11
            Tag             =   "docchange.ico"
            ToolTipText     =   "Сменить состояние"
            Top             =   60
            Width           =   480
         End
         Begin VB.ComboBox cmbState 
            Height          =   315
            Left            =   1890
            Style           =   2  'Dropdown List
            TabIndex        =   4
            ToolTipText     =   "Перевести в новое состояние"
            Top             =   105
            Width           =   2415
         End
         Begin VB.Label lblState 
            Height          =   270
            Left            =   105
            TabIndex        =   3
            Top             =   150
            Width           =   2160
         End
      End
      Begin VB.Frame frmBtns 
         BorderStyle     =   0  'None
         Height          =   555
         Left            =   5190
         TabIndex        =   1
         Top             =   30
         Width           =   4695
         Begin VB.CommandButton cmdLoadXML 
            Height          =   420
            Left            =   1920
            Style           =   1  'Graphical
            TabIndex        =   10
            Tag             =   "DocLoad.ico"
            ToolTipText     =   "Загрузить из файла"
            Top             =   30
            Visible         =   0   'False
            Width           =   510
         End
         Begin VB.CommandButton cmdSaveXML 
            Height          =   420
            Left            =   600
            Style           =   1  'Graphical
            TabIndex        =   9
            Tag             =   "DocSave.ico"
            ToolTipText     =   "Сохранить в файл"
            Top             =   30
            Width           =   510
         End
         Begin VB.CommandButton cmdSecure 
            Height          =   420
            Left            =   1320
            Style           =   1  'Graphical
            TabIndex        =   8
            Tag             =   "DocSecure.ico"
            ToolTipText     =   "Установить права"
            Top             =   30
            Visible         =   0   'False
            Width           =   510
         End
         Begin VB.CommandButton cmdUnlock 
            Height          =   420
            Left            =   0
            Style           =   1  'Graphical
            TabIndex        =   7
            Tag             =   "DocUnlock.ico"
            ToolTipText     =   "Разблокировать документ"
            Top             =   30
            Width           =   510
         End
         Begin VB.CommandButton cmdLock 
            Height          =   420
            Left            =   3120
            Style           =   1  'Graphical
            TabIndex        =   6
            Tag             =   "doclock.ico"
            ToolTipText     =   "Заблокировать документ"
            Top             =   30
            Visible         =   0   'False
            Width           =   495
         End
         Begin VB.CommandButton cmdDel 
            Height          =   420
            Left            =   2520
            Style           =   1  'Graphical
            TabIndex        =   5
            Tag             =   "DocDelete.ico"
            ToolTipText     =   "Удалить документ"
            Top             =   30
            Visible         =   0   'False
            Width           =   510
         End
      End
   End
   Begin MSComDlg.CommonDialog cdlg 
      Left            =   0
      Top             =   735
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
End
Attribute VB_Name = "frmObj"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Public c As Object
Public item As Object
Public Host As GUI
Private mymode As String
Dim mm() As Object


Private Function MyCtl() As Object
On Error Resume Next
Set MyCtl = c.object
End Function

Public Sub Init(ObjItem As Object, Optional Mode As String = "")
  Set item = ObjItem
  mymode = Mode
again:
  On Error Resume Next
  
  Err.Clear
  If Licenses.item(item.TypeName & "GUI.ctl" & Mode & "_main") Is Nothing Then
    Err.Clear
    Call Licenses.Add(item.TypeName & "GUI.ctl" & Mode & "_main")
  End If
'  If Err.Number > 0 Then
'    MsgBox Err.Description
'  End If
'  Err.Clear
'
  Set c = Me.Controls.Add(item.TypeName & "GUI.ctl" & Mode & "_main", "ctl")
  If c Is Nothing Then
  If Mode <> "" Then
    Mode = ""
    GoTo again
  End If
  End If
  c.Visible = True
  TestLock
  
  Call c.object.Init(ObjItem, Nothing, False, Me)
End Sub

Private Sub cmdChange_Click()
On Error Resume Next

  If item Is Nothing Then Exit Sub
  If cmbState.ListIndex = -1 Then Exit Sub
  If RoleDocCanSwitchStatus(item) Then
    If BeforeChangeStatus(item, mm(cmbState.ItemData(cmbState.ListIndex)).Tag) Then
      item.StatusID = mm(cmbState.ItemData(cmbState.ListIndex)).Tag
      CheckStatus
      Me.Hide
      Unload Me
    End If
  Else
  MsgBox "Для этой роли не разрешено изменение статуса документа", vbOKOnly + vbInformation, "Изменение состояния"
  End If
End Sub

Private Sub cmdDel_Click()
On Error GoTo bye
  If item Is Nothing Then Exit Sub
  If RoleDocAllowDelete(item) Then
    If MsgBox("Удалить документ?", vbQuestion + vbYesNo) = vbYes Then
      item.UnLockResource
      item.WorkOffline = False
      item.Manager.DeleteInstance item.id
      item.Manager.FreeInstanceObject item.id
      Me.Hide
      Unload Me
    End If
  Else
    MsgBox "Не предусмотрено удаление документа", vbOKOnly + vbInformation
  End If
  Exit Sub
bye:
   MsgBox Err.Description, vbCritical, "Ошибка при удалении"
End Sub

Private Sub cmdLoadXML_Click()
On Error Resume Next
  If item Is Nothing Then Exit Sub
  If MyRole.ROLES_DEF.item(1).FileExch_Denied = Boolean_Da Then
    MsgBox "Сохранение и загрузка документа в файл запрещены"
    Exit Sub
  End If
  If item.Application.MTZSession.CheckRight(item.SecureStyleID, "XMLLOAD") Then
  
  On Error GoTo bye
  Dim fn As String
  cdlg.CancelError = True
  cdlg.Filter = "Документ XML |*.XML"
  cdlg.DefaultExt = "XML"
  cdlg.Filename = App.Path & "\" & item.id & ".xml"
  cdlg.Flags = cdlOFNPathMustExist + cdlOFNHideReadOnly + cdlOFNFileMustExist
  cdlg.ShowOpen
  fn = cdlg.Filename
  
  Dim xdom As MSXML2.DOMDocument
  Set xdom = New MSXML2.DOMDocument
  xdom.Load fn
  item.XMLLoad xdom.lastChild, 1
  item.WorkOffline = False
  item.BatchUpdate
  Set xdom = Nothing
  
 End If
bye:
  Exit Sub
End Sub

Private Sub cmdLock_Click()
On Error Resume Next
  If item Is Nothing Then Exit Sub
  item.LockResource True
  TestLock
End Sub

Private Sub cmdSaveXML_Click()
On Error Resume Next
 If item Is Nothing Then Exit Sub
 If MyRole.ROLES_DEF.item(1).FileExch_Denied = Boolean_Da Then
  MsgBox "Сохранение и загрузка документа в файл запрещены"
  Exit Sub
End If
 If item.Application.MTZSession.CheckRight(item.SecureStyleID, "XMLSAVE") Then
 
  On Error GoTo bye
  Dim fn As String
  cdlg.CancelError = True
  cdlg.Filter = "Документ XML|*.XML"
  cdlg.DefaultExt = "XML"
  cdlg.Filename = App.Path & "\" & item.id & ".xml"
  cdlg.Flags = cdlOFNPathMustExist + cdlOFNHideReadOnly + cdlOFNOverwritePrompt 'cdlOFNFileMustExist
  cdlg.ShowSave
  fn = cdlg.Filename
   item.LockResource True
   item.LoadAll
   item.WorkOffline = True
   Dim xdom As MSXML2.DOMDocument
   Set xdom = New MSXML2.DOMDocument
   xdom.loadXML "<root></root>"
   item.XMLSave xdom.lastChild, xdom
   xdom.Save fn
   item.WorkOffline = False
 End If
bye:
End Sub

Private Sub cmdSecure_Click()
On Error Resume Next
  
  If item Is Nothing Then Exit Sub
  If MyRole.ROLES_DEF.item(1).RightsSet_Denied = Boolean_Da Then
    MsgBox "Настройка прав запрещена"
    Exit Sub
  End If
  
  item.Application.Manager.ShowSecurityDialog item
End Sub

Private Sub cmdUnlock_Click()
On Error Resume Next
  
  If item Is Nothing Then Exit Sub
  If item.IsLocked Then
    item.UnLockResource
  Else
  MsgBox "Объект не заблокирован", vbInformation
  End If
  TestLock
End Sub

Private Sub CheckStatus()
  If MyCtl.StatusMenuCount > 0 Then
    Dim i As Long
    CoolBar1.Bands.item(1).Visible = True
    cmbState.Clear
    lblstate = ""
    For i = 1 To MyCtl.StatusMenuCount
      If mm(i).Enabled Then
        cmbState.AddItem mm(i).Caption
        cmbState.ItemData(cmbState.NewIndex) = i
      End If
      If mm(i).Checked Then
        lblstate.Caption = mm(i).Caption
      End If
    Next
    MyCtl.CheckStatusMenu mm
  Else
   CoolBar1.Bands.item(1).Visible = False
  End If
End Sub

Private Sub form_Activate()
    On Error Resume Next
  If Me.WindowState = 0 Then
 
    Me.Width = GetSetting(App.Title & "." & App.Major & "." & App.Minor, item.TypeName, "WIDTH", 15000)
    Me.Height = GetSetting(App.Title & "." & App.Major & "." & App.Minor, item.TypeName, "HEIGHT", 5000)
  End If
  
  'item.TypeName
  If Not c Is Nothing Then
    c.Top = CoolBar1.Height
    c.Left = 0
    c.Width = Me.ScaleWidth
    c.Height = Me.ScaleHeight - CoolBar1.Height
    c.Visible = True
  End If
  LoadBtnPictures cmdDel, cmdDel.Tag
  LoadBtnPictures cmdLoadXML, cmdLoadXML.Tag
  LoadBtnPictures cmdLock, cmdLock.Tag
  LoadBtnPictures cmdSaveXML, cmdSaveXML.Tag
  LoadBtnPictures cmdSecure, cmdSecure.Tag
  LoadBtnPictures cmdUnlock, cmdUnlock.Tag
  LoadBtnPictures cmdChange, cmdChange.Tag
  TestLock
  PreLoadState
  CheckStatus

End Sub

Public Function TestLock()
  If item.IsLocked = 0 Then
    Me.Caption = item.Name
  ElseIf item.IsLocked < 3 Then
    Me.Caption = item.Name & " (Заблокирован)"
  Else
    Me.Caption = item.Name & " (Заблокирован другим пользователем)"
  End If
End Function


Private Sub Form_GotFocus()
 
  PreLoadState
End Sub

Private Sub Form_Initialize()
  Debug.Print "frmObj.Init"
End Sub

Private Sub Form_Load()
  On Error Resume Next
  If Not c Is Nothing Then
    c.Top = 0
    c.Left = 0
    c.Width = Me.ScaleWidth
    c.Height = Me.ScaleHeight
    c.Visible = True
  End If
  
End Sub

Private Sub Form_LostFocus()
'frmMain.mnuDocument.Visible = False
End Sub

Private Sub Form_Resize()
On Error Resume Next
If Not c Is Nothing Then

  c.Move 0, CoolBar1.Height, Me.ScaleWidth, Me.ScaleHeight - CoolBar1.Height
End If

End Sub

Private Sub Form_Terminate()
  Debug.Print "frmObj.Terminate"
  Manager.FreeAllInstanses
End Sub

Private Sub Form_Unload(Cancel As Integer)
  On Error Resume Next
 
  If Me.WindowState = 0 Then
    Call SaveSetting(App.Title & "." & App.Major & "." & App.Minor, item.TypeName, "WIDTH", Me.Width)
    Call SaveSetting(App.Title & "." & App.Major & "." & App.Minor, item.TypeName, "HEIGHT", Me.Height)
  End If
  
  If Not Host Is Nothing Then
    If Not item Is Nothing Then
      Host.EraseForm item.id, mymode, False
    End If
  End If
  If Not c Is Nothing Then
   Set c.object.ParentForm = Nothing
   Set c.object.item = Nothing
   Set c.object.Host = Nothing
  End If
  Set c = Nothing
  Set item = Nothing
  Set Host = Nothing
End Sub
Private Sub Form_QueryUnload(Cancel As Integer, UnloadMode As Integer)
If UnloadMode = vbFormControlMenu Or UnloadMode = vbFormMDIForm Or UnloadMode = vbAppWindows Then


  If Not Host Is Nothing Then
    If Not item Is Nothing Then
      If Not c Is Nothing Then
On Error GoTo bye
        If c.object.IsChanged Then
            If MsgBox("Закрыть без сохранения?", vbCritical + vbYesNo, Me.Caption) = vbYes Then
                If Not CheckIsOk(item) Then
                    If MsgBox("Поля не заполнены. Удалить документ?", vbCritical + vbYesNo, Me.Caption) = vbYes Then
                        On Error Resume Next
                        item.Manager.DeleteInstance item.id
                        Host.EraseForm item.id, mymode, False
                        Set item = Nothing
                        Exit Sub
                    End If
                End If
            Else
                Cancel = -1
                Exit Sub
            End If
        Else
            If CheckIsNew(item) Then
              'If MsgBox("Поля не заполнены. Удалить документ?", vbCritical + vbYesNo, Me.Caption) = vbYes Then
                On Error Resume Next
                item.Manager.DeleteInstance item.id
                Host.EraseForm item.id, mymode, False
                Set item = Nothing
                Exit Sub
              'End If
            End If

            If Not CheckIsOk(item) Then
                If MsgBox("Поля не заполнены. Удалить документ?", vbCritical + vbYesNo, Me.Caption) = vbYes Then
                    On Error Resume Next
                    item.Manager.DeleteInstance item.id
                    Host.EraseForm item.id, mymode, False
                    Set item = Nothing
                    Exit Sub
                End If
            End If
        End If
On Error Resume Next
      End If
      Host.EraseForm item.id, mymode, False
    End If
  End If
End If
Exit Sub
bye:
  If MsgBox("Ошибка при закрытии:" & vbCrLf & Err.Description, vbCritical + vbYesNo, "Закрыть окно?") = vbNo Then
    Cancel = -1
  End If


  
  
  
        

End Sub

Private Function BeforeChangeStatus(item As Object, NewStatus As String) As Boolean
  Dim logic As Object
  Dim result As Boolean
  result = True
  On Error Resume Next
  Set logic = CreateObject(item.TypeName & "BST.BEFORESTATUS")
  If Not logic Is Nothing Then
    result = logic.Check(item, NewStatus, MyUser, item.TypeName)
    Set logic = Nothing
  End If
  BeforeChangeStatus = result
End Function

Public Sub PreLoadState()
  On Error Resume Next
  cmbState.Visible = False
  If MyCtl.StatusMenuCount > 0 Then
    Dim i As Long
    
    
    cmbState.Visible = True
    Erase mm

    ReDim mm(1 To MyCtl.StatusMenuCount)

    For i = 1 To MyCtl.StatusMenuCount
     
     Set mm(i) = New mnuStub
    Next
    MyCtl.SetupStatusMenu mm
    CheckStatus
  
  Else
    cmbState.Visible = False
  End If
End Sub


Public Function CheckIsOk(o As Object)
    'get plain part
    Dim res As Boolean
    Dim p_col As Object
    Dim P As Object
    Dim rs As ADODB.Recordset
    Dim rsf As ADODB.Recordset
    Dim val As Object
    Dim strval As String
    Dim numres As Double

    res = False
    Set rs = o.MTZSession.GetData("select part.name as pName,PartType from part, objecttype where part.parentstructrowid=objecttype.objecttypeid and objecttype.Name='" & o.TypeName & "' and part.parentrowid is null") ' and part.Parttype=0")

    While Not rs.EOF
        Dim PartName As String
        Dim FieldName As String
        PartName = rs!pName & ""
        If rs!PartType = 0 Then
          Set p_col = CallByName(o, PartName, VbGet, False)
          Set P = p_col.item(1)
          Set rsf = o.Application.MTZSession.GetData("select field.name as fName from field, part where field.parentstructrowId=part.partid and part.name='" & PartName & "'")
          While Not rsf.EOF
              FieldName = rsf!fname & ""
              On Error Resume Next
              Set val = CallByName(P, FieldName, VbGet)
              If Err.Number <> 0 Then
                  Err.Clear
                  numres = CallByName(P, FieldName, VbGet)
                  If Err.Number <> 0 Then
                      Err.Clear
                      strval = CallByName(P, FieldName, VbGet)
                      If Len(strval) > 0 Then
                          CheckIsOk = True
                      End If
                  Else
                      If numres <> 0 Then
                          CheckIsOk = True
                      End If
                  End If
              Else
                  If Not (val Is Nothing) Then
                      CheckIsOk = True
                  End If
              End If
              rsf.MoveNext
          Wend
        Else
          Set p_col = CallByName(o, PartName, VbGet, False)
          If p_col.Count > 0 Then
            CheckIsOk = True
          End If
        End If
        rs.MoveNext
    Wend
End Function


Public Function CheckIsNew(o As Object)
    'get plain part
    Dim res As Boolean
    Dim p_col As Object
    Dim P As Object
    Dim rs As ADODB.Recordset
    Dim rsf As ADODB.Recordset
    Dim rsfcheck As ADODB.Recordset
    Dim val As Object
    Dim strval As String
    Dim numres As Double

    res = False
    CheckIsNew = True
    Set rs = o.MTZSession.GetData("select part.name as pName from part, objecttype where part.parentrowid is null and  part.parentstructrowid=objecttype.objecttypeid and objecttype.Name='" & o.TypeName & "'") ' and part.Parttype=0")

    While Not rs.EOF
        Dim PartName As String
        Dim FieldName As String
        PartName = rs!pName & ""
        Set rsf = o.Application.MTZSession.GetData("select Count(*) cnt from " & PartName & " where instanceid='" & o.id & "'")
        If Not rsf Is Nothing Then
          If Not rsf.EOF Then
            If rsf!cnt > 0 Then
              Set rsf = o.Application.MTZSession.GetData("select field.name as fName from field, part where field.parentstructrowId=part.partid and part.name='" & PartName & "'  and  IsAutoNumber=0 ") ' and AllowNull=-1
              While Not rsf.EOF
              Set rsfcheck = o.Application.MTZSession.GetData("select Count(*) cnt from " & PartName & " where instanceid='" & o.id & "' and " & rsf!fname & " is not null")
              If Not rsfcheck Is Nothing Then
                If Not rsfcheck.EOF Then
                  If rsfcheck!cnt > 0 Then
                    CheckIsNew = False
                  End If
                End If
              End If
              rsf.MoveNext
              Wend
              Set rsf = Nothing
            End If
          End If
        End If
        Set rsf = Nothing
        rs.MoveNext
    Wend
    Set rs = Nothing
End Function
