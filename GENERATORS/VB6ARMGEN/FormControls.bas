Attribute VB_Name = "FormControls"
Option Explicit


Public Sub GenerateControls(fd As Object, fld As FIELD, pos As Long, SaveFields As String, LoadFields As String, COLUMN As Long, MINPOS As Long, pname As String, body As String, decl As String, GenStyle As String, IsOK As String, Optional ReadOnly As Boolean = False)
 On Error GoTo bye
 
  Dim mproc As String, pp As Long, txt As String

  If pos > 420 * Screen.TwipsPerPixelY Then
   COLUMN = COLUMN + 1
   pos = MINPOS
  End If
  
  Dim ft As FIELDTYPE
  Set ft = fld.FIELDTYPE
  
  
  Dim ctl As ControlData
  Set ctl = fd.ControlData.Add()
    
  ctl.ProgId = "VB.Label"
 
  Call AddProp(ctl, "BackStyle", 0)
  Call AddProp(ctl, "NAME", "lbl" & fld.name)
  Call AddProp(ctl, "Caption", NoLF(fld.Caption) & ":")
  Call AddProp(ctl, "Top", pos)
  Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
  Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
  Call AddProp(ctl, "Width", 200 * Screen.TwipsPerPixelY)
  
  
  Call AddProp(ctl, "Enabled", Not ReadOnly)
  
  
  
  If fld.AllowNull Then
    Call AddProp(ctl, "ForeColor", vbBlue)
  Else
    Call AddProp(ctl, "ForeColor", vbBlack)
  End If

  pos = pos + 22 * Screen.TwipsPerPixelY
  '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
  ' control labeled

    If GenStyle = "REFERENCE" Then
      Set ctl = fd.ControlData.Add()
      ctl.ProgId = "VB.textbox"
      Call AddProp(ctl, "NAME", "txt" & fld.name)
      Call AddProp(ctl, "Text", "")
      Call AddProp(ctl, "Locked", True)
      Call AddProp(ctl, "Enabled", Not ReadOnly)
      Call AddProp(ctl, "Top", pos)
      Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
      Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "Width", 170 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
 
        
      Set ctl = fd.ControlData.Add()
      ctl.ProgId = "MTZ_PANEL.DropButton"
      Call AddProp(ctl, "NAME", "cmd" & fld.name)
      Call AddProp(ctl, "Caption", "")
      Call AddProp(ctl, "Tag", "refopen.ico")
      Call AddProp(ctl, "Top", pos)
      Call AddProp(ctl, "Enabled", Not ReadOnly)
      Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX + 170 * Screen.TwipsPerPixelX)
      Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "Width", 30 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))

      pos = pos + 25 * Screen.TwipsPerPixelY

      body = body & vbCrLf & "private sub txt" & fld.name & "_Change()"
      body = body & vbCrLf & "  Changing"
      body = body & vbCrLf & "end sub"

      If Not fld.AllowNull Then
        IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK = txt" & fld.name & ".Tag<>"""""
      End If
      
      
      
      LoadFields = LoadFields & vbCrLf & "If Not item." & fld.name & " Is Nothing Then"
      LoadFields = LoadFields & vbCrLf & "  txt" & fld.name & ".Tag = item." & fld.name & ".id"
      LoadFields = LoadFields & vbCrLf & "  txt" & fld.name & " = item." & fld.name & ".brief"
      LoadFields = LoadFields & vbCrLf & "else"
      LoadFields = LoadFields & vbCrLf & "  txt" & fld.name & ".Tag = """" "
      LoadFields = LoadFields & vbCrLf & "  txt" & fld.name & " = """" "
      LoadFields = LoadFields & vbCrLf & "End If"
      
      LoadFields = LoadFields & vbCrLf & " LoadBtnPictures cmd" & fld.name & ",cmd" & fld.name & ".tag"
      LoadFields = LoadFields & vbCrLf & "  cmd" & fld.name & ".RemoveAllMenu"
      
      If fld.AllowNull Then
        LoadFields = LoadFields & vbCrLf & "  cmd" & fld.name & ".AddMenu ""��������"" "
      End If
            
      If fld.ReferenceType = ReferenceType_Na_ob_ekt_ Then
        LoadFields = LoadFields & vbCrLf & "  cmd" & fld.name & ".AddMenu ""�������"" "
        If Not ReadOnly Then
          If Not fld.CreateRefOnly Then
            LoadFields = LoadFields & vbCrLf & "  cmd" & fld.name & ".AddMenu ""�������"" "
            LoadFields = LoadFields & vbCrLf & "  cmd" & fld.name & ".AddMenu ""�������"" "
          End If
        End If
        If Not ReadOnly Then
          SaveFields = SaveFields & vbCrLf & "If txt" & fld.name & ".Tag <> """" Then"
          SaveFields = SaveFields & vbCrLf & "  Set item." & fld.name & " = Item.Application.Manager.GetInstanceObject(txt" & fld.name & ".Tag)"
          SaveFields = SaveFields & vbCrLf & "Else"
          SaveFields = SaveFields & vbCrLf & "  Set item." & fld.name & " = Nothing"
          SaveFields = SaveFields & vbCrLf & "End If"
        End If
        
        body = body & vbCrLf & "private sub cmd" & fld.name & "_CLick()"
        body = body & vbCrLf & "  on error resume next"
        body = body & vbCrLf & "     If txt" & fld.name & ".Tag ="""" then"
        
        If Not ReadOnly Then
          If Not fld.CreateRefOnly Then
            body = body & vbCrLf & "       cmd" & fld.name & "_MenuClick ""�������"" "
          Else
            body = body & vbCrLf & "       cmd" & fld.name & "_MenuClick ""�������"" "
          End If
        End If
        
        body = body & vbCrLf & "     Else"
        body = body & vbCrLf & "       cmd" & fld.name & "_MenuClick ""�������"" "
        body = body & vbCrLf & "     End If"
        body = body & vbCrLf & "end sub"
        
        body = body & vbCrLf & "private sub cmd" & fld.name & "_MenuClick(ByVal sCaption As String)"
        body = body & vbCrLf & "  on error resume next"
        body = body & vbCrLf & "    dim inst as object"
        body = body & vbCrLf & "    dim obj as object"
        body = body & vbCrLf & "    Dim OK As boolean"
        body = body & vbCrLf & "    Dim id As string"
        body = body & vbCrLf & "    Dim brief As string"
        
        If Not ReadOnly Then
          body = body & vbCrLf & "  if sCaption =""��������"" then"
        
          If fld.CreateRefOnly = Boolean_Da Then
            body = body & vbCrLf & "       if txt" & fld.name & ".Tag <> """" then"
            body = body & vbCrLf & "         item.Application.MTZSession.SetOwner txt" & fld.name & ".Tag, """", item.ID"
            body = body & vbCrLf & "         item.Application.Manager.DeleteInstance txt" & fld.name & ".Tag"
            body = body & vbCrLf & "       end if"
          End If
          
        
          body = body & vbCrLf & "          txt" & fld.name & ".Tag = """""
          body = body & vbCrLf & "          txt" & fld.name & " = """""
          body = body & vbCrLf & "  end if"
        End If ' not ReadOnly
        
        body = body & vbCrLf & "  if sCaption =""�������"" then"
        body = body & vbCrLf & "    if txt" & fld.name & ".tag ="""" then exit sub"
        body = body & vbCrLf & "    set inst  = item.Application.Manager.GetInstanceObject(txt" & fld.name & ".tag)"
        body = body & vbCrLf & "    if inst is nothing then exit sub"
        body = body & vbCrLf & "    set obj = item.Application.Manager.GetInstanceGUI(txt" & fld.name & ".tag)"
        body = body & vbCrLf & "    obj.show """", inst,true"
        body = body & vbCrLf & "    set obj =nothing"
        body = body & vbCrLf & "    set inst =nothing"
        body = body & vbCrLf & "  end if"
        
        If Not ReadOnly Then
          body = body & vbCrLf & "  if sCaption =""�������"" then"
          If fld.RefToType Is Nothing Then
            body = body & vbCrLf & "        OK=Item.Application.Manager.GetObjectListDialog2(id,brief,"""","""")"
          Else
            body = body & vbCrLf & "        OK=Item.Application.Manager.GetObjectListDialog2(id,brief,"""",""" & fld.RefToType.name & """)"
          End If
          
          body = body & vbCrLf & "        If OK Then"
          body = body & vbCrLf & "          txt" & fld.name & ".Tag = left(ID,38)"
          body = body & vbCrLf & "          txt" & fld.name & " = brief"
          body = body & vbCrLf & "        End If"
          body = body & vbCrLf & "  end if"
       
       
          body = body & vbCrLf & "  if sCaption =""�������"" then"
          body = body & vbCrLf & "     on error resume next"
          If fld.RefToType Is Nothing Then
            body = body & vbCrLf & "        Set obj = Item.Application.Manager.GetNewObject()"
          Else
            body = body & vbCrLf & "        id =Createguid2"
            body = body & vbCrLf & "        Item.Application.Manager.NewInstance id,""" & fld.RefToType.name & """,""" & NoLF(fld.RefToType.the_comment) & " "" & Now "
            body = body & vbCrLf & "        Set obj = Item.Application.Manager.GetInstanceObject(id)"
            
          End If
          
          body = body & vbCrLf & "        If not obj is nothing Then"
          If fld.CreateRefOnly Then
            body = body & vbCrLf & "          item.Application.MTZSession.SetOwner obj.ID, item.PartName, item.ID"
          End If
          body = body & vbCrLf & "          txt" & fld.name & ".Tag = obj.ID"
          body = body & vbCrLf & "          txt" & fld.name & " = obj.brief"
          body = body & vbCrLf & "          set obj = nothing"
          body = body & vbCrLf & "        End If"
          body = body & vbCrLf & "  end if"
        End If ' not readonly
        
        body = body & vbCrLf & "End sub"
      End If ' Ref to object

      If fld.ReferenceType = ReferenceType_Na_stroku_razdela Then
      
        If Not ReadOnly Then
          SaveFields = SaveFields & vbCrLf & "If txt" & fld.name & ".Tag <> """" Then"
          SaveFields = SaveFields & vbCrLf & "  Set item." & fld.name & " = Item.Application.FindRowObject(""" & fld.RefToPart.name & """,txt" & fld.name & ".Tag)"
          SaveFields = SaveFields & vbCrLf & "Else"
          SaveFields = SaveFields & vbCrLf & "  Set item." & fld.name & " = Nothing"
          SaveFields = SaveFields & vbCrLf & "End If"
        End If ' not readonly
      
        body = body & vbCrLf & "private sub cmd" & fld.name & "_CLick()"
        body = body & vbCrLf & "  on error resume next"
        
        If Not ReadOnly Then
          body = body & vbCrLf & "        Dim id As String, brief As String"
          Dim strScript As String
          
          strScript = GetDynamicFieldFilter(fld.DINAMICFILTERSCRIPT, LastTID)
          If strScript <> "" Then
            If fld.InternalReference = Boolean_Da Then
                      body = body & vbCrLf & "        If item.Application.Manager.GetReferenceDialogEx2(""" & fld.RefToPart.name & """, id, brief,item.application.ID,, " + strScript + ") Then"
            Else
                      body = body & vbCrLf & "        If item.Application.Manager.GetReferenceDialogEx2(""" & fld.RefToPart.name & """, id, brief,,," + strScript + ") Then"
            End If
          Else
            If fld.InternalReference = Boolean_Da Then
                      body = body & vbCrLf & "        If item.Application.Manager.GetReferenceDialogEx2(""" & fld.RefToPart.name & """, id, brief,item.application.ID) Then"
            Else
                      body = body & vbCrLf & "        If item.Application.Manager.GetReferenceDialogEx2(""" & fld.RefToPart.name & """, id, brief) Then"
            End If
          End If
                    
          body = body & vbCrLf & "          txt" & fld.name & ".Tag = Left(id, 38)"
          body = body & vbCrLf & "          txt" & fld.name & " = brief"
          body = body & vbCrLf & "        End If"
          
        Else
          body = body & vbCrLf & "        MsgBox ""����� �� ��������������� ��������������"",vbInformation"
        End If ' not readonly
        body = body & vbCrLf & "end sub"
        
        
        body = body & vbCrLf & "private sub cmd" & fld.name & "_MenuClick(ByVal sCaption As String)"
        If Not ReadOnly Then
          body = body & vbCrLf & "          txt" & fld.name & ".Tag = """""
          body = body & vbCrLf & "          txt" & fld.name & " = """""
        Else
          body = body & vbCrLf & "        MsgBox ""����� �� ��������������� ��������������"",vbInformation"
        End If ' not readonly
        body = body & vbCrLf & "End sub"

        
      End If ' ref to row
      
    End If 'REFERENCE

    If GenStyle = "TEXT" Or GenStyle = "PASSWORD" Or GenStyle = "GUID" Then
      Set ctl = fd.ControlData.Add()
      ctl.ProgId = "VB.textbox"
      Call AddProp(ctl, "NAME", "txt" & fld.name)
      Call AddProp(ctl, "Text", "")
      Call AddProp(ctl, "Top", pos)
      Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
      Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "Width", 200 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "MaxLength", fld.DataSize)
      Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
      Call AddProp(ctl, "Locked", ReadOnly)
      Call AddProp(ctl, "Enabled", Not ReadOnly)
      
      If GenStyle = "PASSWORD" Then
        Call AddProp(ctl, "PasswordChar", "*")
      End If
      pos = pos + 25 * Screen.TwipsPerPixelY
      body = body & vbCrLf & "private sub txt" & fld.name & "_Change()"
      body = body & vbCrLf & "  Changing"
      body = body & vbCrLf & "end sub"
      If Not ReadOnly Then
        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = txt" & fld.name
      End If
      LoadFields = LoadFields & vbCrLf & "txt" & fld.name & " = item." & fld.name
      
      If Not fld.AllowNull Then
        IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =IsSet(txt" & fld.name & ".text)"
      End If
      
      
    End If ' TEXT PASSWORD GUID

    ' todo
    If GenStyle = "EMAIL" Then
      Set ctl = fd.ControlData.Add()
      ctl.ProgId = "VB.textbox"
      Call AddProp(ctl, "NAME", "txt" & fld.name)
      Call AddProp(ctl, "Text", "")
      Call AddProp(ctl, "Top", pos)
      Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
      Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "Width", 170 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "MaxLength", fld.DataSize)
      Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
      Call AddProp(ctl, "Locked", ReadOnly)
      Call AddProp(ctl, "Enabled", Not ReadOnly)
      
      Set ctl = fd.ControlData.Add()
      ctl.ProgId = "MTZ_PANEL.DropButton"
      Call AddProp(ctl, "NAME", "cmd" & fld.name)
      Call AddProp(ctl, "Caption", "")
      Call AddProp(ctl, "Tag", "mailopen.ico")
      Call AddProp(ctl, "Top", pos)
      Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX + 170 * Screen.TwipsPerPixelX)
      Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "Width", 30 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))

      
      pos = pos + 25 * Screen.TwipsPerPixelY

      body = body & vbCrLf & "private sub txt" & fld.name & "_Change()"
      body = body & vbCrLf & "  Changing"
      body = body & vbCrLf & "end sub"
      
      body = body & vbCrLf & "private sub cmd" & fld.name & "_CLick()"
      'body = body & vbCrLf & "  on error resume next"
      'body = body & vbCrLf & "        shell ""start mailto:"" &   txt" & fld.name
      
      body = body & vbCrLf & "  on error resume next"
      body = body & vbCrLf & "  Dim s As String"
      body = body & vbCrLf & "  s = s & ""mailto:"" & txt" & fld.name & ".text "
      body = body & vbCrLf & "  OpenDocument 0, s"
      
      body = body & vbCrLf & "end sub"
      
      If Not ReadOnly Then
        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = txt" & fld.name
      End If
      LoadFields = LoadFields & vbCrLf & "txt" & fld.name & " = item." & fld.name
      LoadFields = LoadFields & vbCrLf & " LoadBtnPictures cmd" & fld.name & ",cmd" & fld.name & ".tag"
      LoadFields = LoadFields & vbCrLf & "  cmd" & fld.name & ".RemoveAllMenu"
      
      If Not fld.AllowNull Then
        IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =IsSet(txt" & fld.name & ".text)"
      End If
      
    End If 'EMAIL


    ' todo
    If GenStyle = "URL" Then
      Set ctl = fd.ControlData.Add()
      ctl.ProgId = "VB.textbox"
      Call AddProp(ctl, "NAME", "txt" & fld.name)
      Call AddProp(ctl, "Text", "")
      Call AddProp(ctl, "Top", pos)
      Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
      Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "Width", 170 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "MaxLength", fld.DataSize)
      Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
      Call AddProp(ctl, "Locked", ReadOnly)
      Call AddProp(ctl, "Enabled", Not ReadOnly)
      
      Set ctl = fd.ControlData.Add()
      ctl.ProgId = "MTZ_PANEL.DropButton"
      Call AddProp(ctl, "NAME", "cmd" & fld.name)
      Call AddProp(ctl, "Caption", "")
      Call AddProp(ctl, "Tag", "urlopen.ico")
      Call AddProp(ctl, "Top", pos)
      Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX + 170 * Screen.TwipsPerPixelX)
      Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "Width", 30 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
      
      
      pos = pos + 25 * Screen.TwipsPerPixelY

      body = body & vbCrLf & "private sub txt" & fld.name & "_Change()"
      body = body & vbCrLf & "  Changing"
      body = body & vbCrLf & "end sub"

      body = body & vbCrLf & "private sub cmd" & fld.name & "_CLick()"
      body = body & vbCrLf & "  on error resume next"
      body = body & vbCrLf & "  Dim s As String"
      body = body & vbCrLf & "  s = s & ""http:\\"" & txt" & fld.name & ".text "
      body = body & vbCrLf & "  OpenDocument 0, s"
      body = body & vbCrLf & "end sub"

      If Not ReadOnly Then
        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = txt" & fld.name
      End If
      
      LoadFields = LoadFields & vbCrLf & "txt" & fld.name & " = item." & fld.name
      LoadFields = LoadFields & vbCrLf & " LoadBtnPictures cmd" & fld.name & ",cmd" & fld.name & ".tag"
      LoadFields = LoadFields & vbCrLf & "  cmd" & fld.name & ".RemoveAllMenu"
      
      If Not fld.AllowNull Then
        IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =IsSet(txt" & fld.name & ".text)"
      End If
      
    End If 'URL





    If GenStyle = "HTML" Then
'       Set ctl = fd.ControlData.Add()
'       ctl.ProgId = "SHDocVwCtl.WebBrowser"
'       Call AddProp(ctl, "NAME", "www" & fld.name)
'       Call AddProp(ctl, "Top", pos)
'       Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
'       Call AddProp(ctl, "Height", 80 * Screen.TwipsPerPixelY)
'       Call AddProp(ctl, "Width", 170 * Screen.TwipsPerPixelY)
'
'
'      Set ctl = fd.ControlData.Add()
'      ctl.ProgId = "MTZ_PANEL.DropButton"
'      Call AddProp(ctl, "NAME", "cmd" & fld.name)
'      Call AddProp(ctl, "Caption", "")
'      Call AddProp(ctl, "Tag", "htmlopen.ico")
'      Call AddProp(ctl, "Top", pos)
'      Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX + 170 * Screen.TwipsPerPixelX)
'      Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
'      Call AddProp(ctl, "Width", 30 * Screen.TwipsPerPixelY)
'      Call AddProp(ctl, "ToolTipText", nolf( fld.Caption))
'
'      pos = pos + 85 * Screen.TwipsPerPixelY
'
'       ' dilog for file open
'        If fd.ControlData.Item("Dialog") Is Nothing Then
'          Set ctl = fd.ControlData.Add("Dialog")
'          ctl.ProgId = "MSComDlg.CommonDialog"
'          Call AddProp(ctl, "Name", "Dialog")
'          Call AddProp(ctl, "Top", pos - 10 * Screen.TwipsPerPixelY)
'          Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
'       End If
'      On Error GoTo bye
'
'      ' procedure for load file into field
'      mproc = ""
'      mproc = mproc & vbCrLf & " Dialog.flags = cdlOFNFileMustExist + cdlOFNHideReadOnly + cdlOFNPathMustExist"
'      mproc = mproc & vbCrLf & " Dialog.filter = ""(*.htm;*.html)|*.htm;*.html"""
'      mproc = mproc & vbCrLf & " Dialog.DialogTitle = ""�������������� ����"""
'      mproc = mproc & vbCrLf & " Dialog.CancelError = True"
'      mproc = mproc & vbCrLf & " On Error Resume Next"
'      mproc = mproc & vbCrLf & " Dialog.ShowOpen"
'      mproc = mproc & vbCrLf & " If (Err.Number > 0) Then"
'      mproc = mproc & vbCrLf & "  Err.Clear"
'      mproc = mproc & vbCrLf & "  Exit Sub"
'      mproc = mproc & vbCrLf & " End If"
'      mproc = mproc & vbCrLf & " www" & fld.name & ".navigate Dialog.filename"
'      mproc = mproc & vbCrLf & " item." & fld.name & "= FileToArray(Dialog.FileName)"
'      mproc = mproc & vbCrLf & " Changing"
'
'      body = body & vbCrLf & "private sub CMD" & fld.name & "_CLICK()"
'      body = body & vbCrLf & "  on error resume next"
'      body = body & vbCrLf & mproc
'      body = body & vbCrLf & "end sub"
'
'      mproc = ""
'      mproc = mproc & vbCrLf & " sTRINGToFile APP.PATH & ""\EMPTY.HTM"",""<HTML><BODY></BODY></HTML>"""
'      mproc = mproc & vbCrLf & " www" & fld.name & ".navigate APP.PATH & ""\EMPTY.HTM"""
'      mproc = mproc & vbCrLf & " item." & fld.name & "= null"
'      mproc = mproc & vbCrLf & " Changing"
'
'      body = body & vbCrLf & "private sub cmd" & fld.name & "_MenuClick(ByVal sCaption As String)"
'      body = body & vbCrLf & mproc
'      body = body & vbCrLf & "          txt" & fld.name & " = """""
'      body = body & vbCrLf & "End sub"
'
'
'
'      SaveFields = SaveFields & vbCrLf & " ' SEE cmd" & fld.name & "_CLICK"
'
'      LoadFields = LoadFields & vbCrLf & " STRINGToFile APP.PATH & ""\EMPTY.HTM"",""<HTML><BODY></BODY></HTML>"""
'      LoadFields = LoadFields & vbCrLf & " www" & fld.name & ".navigate APP.PATH & ""\EMPTY.HTM"""
'      LoadFields = LoadFields & vbCrLf & " while www" & fld.name & ".busy"
'      LoadFields = LoadFields & vbCrLf & " doevents"
'      LoadFields = LoadFields & vbCrLf & " wend"
'      LoadFields = LoadFields & vbCrLf & " if  not isnull(item." & fld.name & ") then "
'      LoadFields = LoadFields & vbCrLf & "   arraytofile APP.PATH & ""\temp.HTM"",item." & fld.name
'      LoadFields = LoadFields & vbCrLf & "   www" & fld.name & ".navigate APP.PATH & ""\TEMP.HTM"""
'      LoadFields = LoadFields & vbCrLf & " else "
'      LoadFields = LoadFields & vbCrLf & "   STRINGToFile APP.PATH & ""\EMPTY.HTM"",""<HTML><BODY></BODY></HTML>"""
'      LoadFields = LoadFields & vbCrLf & "   www" & fld.name & ".navigate APP.PATH & ""\EMPTY.HTM"""
'      LoadFields = LoadFields & vbCrLf & " end if "
'      LoadFields = LoadFields & vbCrLf & " LoadBtnPictures cmd" & fld.name & ",cmd" & fld.name & ".tag"
'      LoadFields = LoadFields & vbCrLf & "  cmd" & fld.name & ".RemoveAllMenu"
'      LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".AddMenu ""��������"""
      
      Set ctl = fd.ControlData.Add()
      ctl.ProgId = "VB.textbox"
      Call AddProp(ctl, "NAME", "txt" & fld.name)
      Call AddProp(ctl, "Text", "")
      Call AddProp(ctl, "Top", pos)
      Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
      Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "Width", 200 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "Multiline", True)
      Call AddProp(ctl, "Scrollbars", 3)
      Call AddProp(ctl, "Locked", ReadOnly)
      Call AddProp(ctl, "Enabled", Not ReadOnly)

      Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
      
      pos = pos + 25 * Screen.TwipsPerPixelY
      body = body & vbCrLf & "private sub txt" & fld.name & "_Change()"
      body = body & vbCrLf & "  Changing"
      body = body & vbCrLf & "end sub"
      If Not ReadOnly Then
        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = txt" & fld.name
      End If
      LoadFields = LoadFields & vbCrLf & "txt" & fld.name & " = item." & fld.name
      
      If Not fld.AllowNull Then
        IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =IsSet(item." & fld.name & ")"
      End If
      
    End If 'HTML




   If GenStyle = "MEMO" Then
       Set ctl = fd.ControlData.Add()
       ctl.ProgId = "VB.textbox"
       Call AddProp(ctl, "NAME", "txt" & fld.name)
       Call AddProp(ctl, "Text", "")
       Call AddProp(ctl, "Top", pos)
       Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
       Call AddProp(ctl, "Height", 80 * Screen.TwipsPerPixelY)
       Call AddProp(ctl, "Width", 200 * Screen.TwipsPerPixelY)
       Call AddProp(ctl, "Multiline", True)
       Call AddProp(ctl, "Scrollbars", 2)
       Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
       Call AddProp(ctl, "Locked", ReadOnly)
       Call AddProp(ctl, "Enabled", Not ReadOnly)
       pos = pos + 85 * Screen.TwipsPerPixelY


       body = body & vbCrLf & "private sub txt" & fld.name & "_Change()"
       body = body & vbCrLf & "  Changing"
       body = body & vbCrLf & "end sub"
      If Not ReadOnly Then
        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = txt" & fld.name
      End If
      LoadFields = LoadFields & vbCrLf & "txt" & fld.name & " = item." & fld.name

      If Not fld.AllowNull Then
        IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =IsSet(txt" & fld.name & ".text)"
      End If

    End If ' MEMO


    If GenStyle = "RTF" Then
       Set ctl = fd.ControlData.Add()
       ctl.ProgId = "MTZ_PANEL.RTFEDITOR"
       Call AddProp(ctl, "NAME", "txt" & fld.name)
       Call AddProp(ctl, "Text", "")
       Call AddProp(ctl, "Top", pos)
       Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
       Call AddProp(ctl, "Height", 80 * Screen.TwipsPerPixelY)
       Call AddProp(ctl, "Width", 200 * Screen.TwipsPerPixelY)
       Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
       Call AddProp(ctl, "Enabled", Not ReadOnly)
       
       pos = pos + 85 * Screen.TwipsPerPixelY


       body = body & vbCrLf & "private sub txt" & fld.name & "_OnChange()"
       body = body & vbCrLf & "  Changing"
       body = body & vbCrLf & "end sub"

      If Not ReadOnly Then
        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = txt" & fld.name & ".RTF"
      End If
      LoadFields = LoadFields & vbCrLf & "txt" & fld.name & ".RTF = item." & fld.name

      If Not fld.AllowNull Then
        IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =IsSet(txt" & fld.name & ".RTF)"
      End If

    End If ' RTF



   ''''''''''' File
   
   If GenStyle = "FILE" Then
       Set ctl = fd.ControlData.Add()
       ctl.ProgId = "VB.textbox"
       Call AddProp(ctl, "NAME", "txt" & fld.name)
       Call AddProp(ctl, "Top", pos)
       Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
       Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
       Call AddProp(ctl, "Width", 170 * Screen.TwipsPerPixelY)
       Call AddProp(ctl, "Locked", True)
       Call AddProp(ctl, "Enabled", Not ReadOnly)
       Call AddProp(ctl, "BorderStyle", 1)
       Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))


      Set ctl = fd.ControlData.Add()
      ctl.ProgId = "MTZ_PANEL.DropButton"
      Call AddProp(ctl, "NAME", "cmd" & fld.name)
      Call AddProp(ctl, "Caption", "")
      Call AddProp(ctl, "Tag", "fileopen.ico")
      Call AddProp(ctl, "Top", pos)
      Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX + 170 * Screen.TwipsPerPixelX)
      Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "Width", 30 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
      
      pos = pos + 25 * Screen.TwipsPerPixelY

       ' dilog for file open
        If fd.ControlData.item("Dialog") Is Nothing Then
          Set ctl = fd.ControlData.Add("Dialog")
          ctl.ProgId = "MSComDlg.CommonDialog"
          Call AddProp(ctl, "Name", "Dialog")
          Call AddProp(ctl, "Top", pos - 10 * Screen.TwipsPerPixelY)
          Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
       End If
      On Error GoTo bye
      
        
        body = body & vbCrLf & "Private Sub cmd" & fld.name & "_Click()"
        body = body & vbCrLf & "  on error resume next"
        body = body & vbCrLf & "  if item." & fld.name & "_ext <>"""" and not isnull(item." & fld.name & ")  then"
        body = body & vbCrLf & "    cmd" & fld.name & "_MenuClick ""�������"""
        If Not ReadOnly Then
          body = body & vbCrLf & "  else"
          body = body & vbCrLf & "    cmd" & fld.name & "_MenuClick ""�������"""
        End If
        body = body & vbCrLf & "  End if"
        body = body & vbCrLf & "End Sub"
        body = body & vbCrLf & ""
        body = body & vbCrLf & "Private Sub cmd" & fld.name & "_MenuClick(ByVal sCaption As String)"
        If Not ReadOnly Then
          body = body & vbCrLf & "  If sCaption = ""�������"" Then"
          body = body & vbCrLf & "   Dialog.Flags = cdlOFNFileMustExist + cdlOFNHideReadOnly + cdlOFNPathMustExist"
          body = body & vbCrLf & "   Dialog.Filter = ""(*.*)|*.*"""
          body = body & vbCrLf & "   Dialog.DialogTitle = ""����"""
          body = body & vbCrLf & "   Dialog.CancelError = True"
          body = body & vbCrLf & "   On Error Resume Next"
          body = body & vbCrLf & "   Dialog.ShowOpen"
          body = body & vbCrLf & "   If (Err.Number > 0) Then"
          body = body & vbCrLf & "    Err.Clear"
          body = body & vbCrLf & "    Exit Sub"
          body = body & vbCrLf & "   End If"
          body = body & vbCrLf & "   txt" & fld.name & " = Dialog.FileName"
          body = body & vbCrLf & "   item." & fld.name & " = FileToArray(Dialog.FileName)"
          body = body & vbCrLf & "   item." & fld.name & "_ext = GetFileExtension2(Dialog.FileName)"
          body = body & vbCrLf & "   Changing"
          body = body & vbCrLf & "  End If"
          
          body = body & vbCrLf & "  If sCaption = ""��������"" Then"
          body = body & vbCrLf & "   txt" & fld.name & " = """" "
          body = body & vbCrLf & "   item." & fld.name & " = null"
          body = body & vbCrLf & "   item." & fld.name & "_ext = """""
          body = body & vbCrLf & "   Changing"
          body = body & vbCrLf & "  End If"
        End If
        body = body & vbCrLf & "  If sCaption = ""�������"" Then"
        body = body & vbCrLf & "    item.Application.manager.StoreTempFileData DoOpenFile( item." & fld.name & ", item." & fld.name & "_ext),item.partname,item.id"
        body = body & vbCrLf & "  End If"
        
        body = body & vbCrLf & "  If sCaption = ""���������"" Then"
        body = body & vbCrLf & "   Dialog.Flags = cdlOFNHideReadOnly + cdlOFNPathMustExist"
        body = body & vbCrLf & "   Dialog.Filter = ""(*.*)|*.*"""
        body = body & vbCrLf & "   Dialog.DialogTitle = ""����"""
        body = body & vbCrLf & "   Dialog.CancelError = True"
        body = body & vbCrLf & "   On Error Resume Next"
        body = body & vbCrLf & "   Dialog.ShowSave"
        body = body & vbCrLf & "   If (Err.Number > 0) Then"
        body = body & vbCrLf & "    Err.Clear"
        body = body & vbCrLf & "    Exit Sub"
        body = body & vbCrLf & "   End If"
        body = body & vbCrLf & "   ArrayToFile Dialog.FileName, item." & fld.name
        body = body & vbCrLf & "  End If"
        body = body & vbCrLf & "End Sub"

      
      SaveFields = SaveFields & vbCrLf & " ' SEE cmd" & fld.name & "_CLICK"
      
      LoadFields = LoadFields & vbCrLf & " if  lenb(item." & fld.name & ")>0 then "
      LoadFields = LoadFields & vbCrLf & "   txt" & fld.name & "=""������ ("" & item." & fld.name & "_ext & "")"""
      LoadFields = LoadFields & vbCrLf & " else "
      LoadFields = LoadFields & vbCrLf & "   txt" & fld.name & "="""""
      LoadFields = LoadFields & vbCrLf & " end if "
      
      LoadFields = LoadFields & vbCrLf & " LoadBtnPictures cmd" & fld.name & ",cmd" & fld.name & ".tag"
      LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".RemoveAllMenu"
      LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".AddMenu ""�������"""
      LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".AddMenu ""���������"""
      LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".AddMenu ""�������"""
      
      If fld.AllowNull Then
        LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".AddMenu ""��������"""
      End If
      
      If Not fld.AllowNull Then
        IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =(lenb(item." & fld.name & ")>0)"
      End If
      
    End If ' FILE
   
   '''''''''''
   
   If GenStyle = "IMAGE" Then
       Set ctl = fd.ControlData.Add()
       ctl.ProgId = "VB.image"
       Call AddProp(ctl, "NAME", "img" & fld.name)
       Call AddProp(ctl, "Top", pos)
       Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
       Call AddProp(ctl, "Height", 80 * Screen.TwipsPerPixelY)
       Call AddProp(ctl, "Width", 170 * Screen.TwipsPerPixelY)
       Call AddProp(ctl, "Stretch", True)
       Call AddProp(ctl, "BorderStyle", 1)
       Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))

      

      decl = decl & vbCrLf & " dim m_" & fld.name
       
      Set ctl = fd.ControlData.Add()
      ctl.ProgId = "MTZ_PANEL.DropButton"
      Call AddProp(ctl, "NAME", "cmd" & fld.name)
      Call AddProp(ctl, "Caption", "")
      Call AddProp(ctl, "Tag", "imageopen.ico")
      Call AddProp(ctl, "Top", pos)
      Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX + 170 * Screen.TwipsPerPixelX)
      Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "Width", 30 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
      Call AddProp(ctl, "Visible", Not ReadOnly)
      
      
       ' dilog for file open
       If fd.ControlData.item("Dialog") Is Nothing Then
         Set ctl = fd.ControlData.Add("Dialog")
         ctl.ProgId = "MSComDlg.CommonDialog"
         Call AddProp(ctl, "Name", "Dialog")
         Call AddProp(ctl, "Top", pos - 10 * Screen.TwipsPerPixelY)
         Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
       End If
       
       pos = pos + 85 * Screen.TwipsPerPixelY

      On Error GoTo bye

      ' procedure for load file into image
      If Not ReadOnly Then
        mproc = ""
        
        mproc = mproc & vbCrLf & " Dialog.flags = cdlOFNFileMustExist + cdlOFNHideReadOnly + cdlOFNPathMustExist"
        mproc = mproc & vbCrLf & " Dialog.filter = ""(*.BMP;*.ICO;*.GIF;*.JPG)|*.BMP;*.ICO;*.GIF;*.JPG"""
        mproc = mproc & vbCrLf & " Dialog.DialogTitle = ""���� �����������"""
        mproc = mproc & vbCrLf & " Dialog.CancelError = True"
        mproc = mproc & vbCrLf & " On Error Resume Next"
        mproc = mproc & vbCrLf & " Dialog.ShowOpen"
        mproc = mproc & vbCrLf & " If (Err.Number > 0) Then"
        mproc = mproc & vbCrLf & "  Err.Clear"
        mproc = mproc & vbCrLf & "  Exit Sub"
        mproc = mproc & vbCrLf & " End If"
        mproc = mproc & vbCrLf & " set img" & fld.name & ".picture=LoadPicture(Dialog.FileName)"
        mproc = mproc & vbCrLf & " item." & fld.name & "=FileToArray( Dialog.FileName)"
        mproc = mproc & vbCrLf & " Changing"
        
        
        body = body & vbCrLf & "private sub CMD" & fld.name & "_CLICK()"
        body = body & vbCrLf & "  on error resume next"
        body = body & vbCrLf & mproc
        body = body & vbCrLf & "end sub"
        
        mproc = ""
        mproc = mproc & vbCrLf & " set img" & fld.name & ".picture=LoadPicture()"
        mproc = mproc & vbCrLf & " item." & fld.name & "= null"
        mproc = mproc & vbCrLf & " Changing"
        
        body = body & vbCrLf & "Private Sub cmd" & fld.name & "_MenuClick(ByVal sCaption As String)"
        body = body & vbCrLf & mproc
        body = body & vbCrLf & "end sub"
        
        SaveFields = SaveFields & vbCrLf & " ' SEE cmd" & fld.name & "_CLICK"
      End If
      
      LoadFields = LoadFields & vbCrLf & " LoadImage img" & fld.name & ", item." & fld.name
      LoadFields = LoadFields & vbCrLf & " LoadBtnPictures cmd" & fld.name & ",cmd" & fld.name & ".tag"
      LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".RemoveAllMenu"
      LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".AddMenu ""��������"""
      
      If Not fld.AllowNull Then
        IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =(lenb(item." & fld.name & ")>0)"
      End If
      
    End If 'IMAGE


    ' numeric type
    'Double
    'Integer
    'Long

    If GenStyle = "NUMERIC" Or GenStyle = "INTEGER" Or GenStyle = "INTERVAL" Then

       Set ctl = fd.ControlData.Add()
       ctl.ProgId = "VB.textbox"
       Call AddProp(ctl, "NAME", "txt" & fld.name)
       Call AddProp(ctl, "Text", "")
       Call AddProp(ctl, "Top", pos)
       Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
       Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
       Call AddProp(ctl, "Width", 120 * Screen.TwipsPerPixelY)
       Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
       Call AddProp(ctl, "CausesValidation", True)
       Call AddProp(ctl, "Locked", ReadOnly)
       Call AddProp(ctl, "Enabled", Not ReadOnly)
       
       If GenStyle = "NUMERIC" Then
        Call AddProp(ctl, "MaxLength", 27)
       Else
        Call AddProp(ctl, "MaxLength", 15)
       End If
      If Not ReadOnly Then
        If GenStyle = "NUMERIC" Then
        body = body & vbCrLf & "private sub txt" & fld.name & "_Validate(cancel as boolean)"
        body = body & vbCrLf & _
          "if txt" & fld.name & ".text<>"""" then " & vbCrLf & _
          " on error resume next " & vbCrLf & _
          "  if not isnumeric(txt" & fld.name & ".text) then " & vbCrLf & _
          "     cancel=true " & vbCrLf & _
          "     msgbox ""��������� �����"",vbokonly+vbexclamation,""��������"" " & vbCrLf & _
          "  elseif Val(txt" & fld.name & ".text) < -922337203685477.5808 or Val(txt" & fld.name & ".text)>+922337203685477.5807 then " & vbCrLf & _
          "     cancel=true " & vbCrLf & _
          "     msgbox ""�������� ��� ����������� ���������"",vbokonly+vbexclamation,""��������"" " & vbCrLf & _
          "  end if" & vbCrLf & _
          "end if"
         body = body & vbCrLf & "end sub"
        ElseIf GenStyle = "INTEGER" Then
          body = body & vbCrLf & "private sub txt" & fld.name & "_Validate(cancel as boolean)"
          body = body & vbCrLf & _
          "if txt" & fld.name & ".text<>"""" then " & vbCrLf & _
          " on error resume next " & vbCrLf & _
          "  if not isnumeric(txt" & fld.name & ".text) then " & vbCrLf & _
          "     cancel=true " & vbCrLf & _
          "     msgbox ""��������� �����"",vbokonly+vbexclamation,""��������"" " & vbCrLf & _
          "  elseif Val(txt" & fld.name & ".text) <>clng(Val(txt" & fld.name & ".text)) then " & vbCrLf & _
          "     cancel=true " & vbCrLf & _
          "     msgbox ""��������� ����� �����"",vbokonly+vbexclamation,""��������"" " & vbCrLf & _
          "  end if" & vbCrLf & _
          "end if"
          body = body & vbCrLf & "end sub"
        ElseIf GenStyle = "INTERVAL" Then
          body = body & vbCrLf & "private sub txt" & fld.name & "_Validate(cancel as boolean)"
          body = body & vbCrLf & _
          "if txt" & fld.name & ".text<>"""" then " & vbCrLf & _
          " on error resume next " & vbCrLf & _
          "  if not isnumeric(txt" & fld.name & ".text) then " & vbCrLf & _
          "     cancel=true " & vbCrLf & _
          "     msgbox ""��������� �����"",vbokonly+vbexclamation,""��������"" " & vbCrLf & _
          "  elseif Val(txt" & fld.name & ".text) <>clng(Val(txt" & fld.name & ".text)) then " & vbCrLf & _
          "     cancel=true " & vbCrLf & _
          "     msgbox ""��������� ����� �����"",vbokonly+vbexclamation,""��������"" " & vbCrLf & _
          "  elseif Val(txt" & fld.name & ".text) < 0" & ft.Minimum & " or  Val(txt" & fld.name & ".text)> 0" & ft.Maximum & " then " & vbCrLf & _
          "     cancel=true " & vbCrLf & _
          "     msgbox ""�������� ��� ����������� ���������"",vbokonly+vbexclamation,""��������"" " & vbCrLf & _
          "  end if" & vbCrLf & _
          "end if"
          body = body & vbCrLf & "end sub"
        End If
        
        
        body = body & vbCrLf & "Private Sub txt" & fld.name & "_KeyPess(KeyAscii As Integer)"
        body = body & vbCrLf & "Dim s As String" & vbCrLf & _
        "s = ""0123456789.,-"" & Chr(8)" & vbCrLf & _
        "If InStr(s, Chr(KeyAscii)) > 0 Then Exit Sub" & vbCrLf & _
        "KeyAscii = 0" & vbCrLf
        body = body & vbCrLf & "End Sub"
      End If
      
      body = body & vbCrLf & "private sub txt" & fld.name & "_Change()"
      body = body & vbCrLf & "  Changing"
      body = body & vbCrLf & "end sub"

      If Not ReadOnly Then
        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = cdbl(txt" & fld.name & ")"
      End If
      LoadFields = LoadFields & vbCrLf & "txt" & fld.name & " = item." & fld.name

      If Not fld.AllowNull Then
        IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK = IsSet(txt" & fld.name & ".text)"
      End If


      pos = pos + 25 * Screen.TwipsPerPixelY
    End If

    ' date type
    If GenStyle = "DATE" Or GenStyle = "DATETIME" Or GenStyle = "TIME" Then

       Set ctl = fd.ControlData.Add()
       ctl.ProgId = "MSComCtl2.DTPicker"
       Call AddProp(ctl, "NAME", "dtp" & fld.name)
       Call AddProp(ctl, "Top", pos)
       Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
       Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
       Call AddProp(ctl, "Format", 3)
       Call AddProp(ctl, "Enabled", Not ReadOnly)
       
       Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
       If GenStyle = "DATETIME" Then
          Call AddProp(ctl, "CustomFormat", "dd/MM/yyyy HH:mm:ss")
          Call AddProp(ctl, "Width", 150 * Screen.TwipsPerPixelY)
          LoadFields = LoadFields & vbCrLf & "dtp" & fld.name & " = now"
       End If
       If GenStyle = "DATE" Then
         Call AddProp(ctl, "CustomFormat", "dd/MM/yyyy")
         Call AddProp(ctl, "Width", 120 * Screen.TwipsPerPixelY)
         LoadFields = LoadFields & vbCrLf & "dtp" & fld.name & " = date"
       End If
       If GenStyle = "TIME" Then
         Call AddProp(ctl, "CustomFormat", "HH:mm:ss")
         Call AddProp(ctl, "Width", 120 * Screen.TwipsPerPixelY)
         Call AddProp(ctl, "UpDown", True)
         LoadFields = LoadFields & vbCrLf & "dtp" & fld.name & " = time"
       End If

       If fld.AllowNull Then
        Call AddProp(ctl, "CheckBox", True)
       Else
        Call AddProp(ctl, "CheckBox", False)
       End If

       body = body & vbCrLf & "private sub dtp" & fld.name & "_Change()"
       body = body & vbCrLf & "  Changing"
       body = body & vbCrLf & "end sub"


       If Not ReadOnly Then
        SaveFields = SaveFields & vbCrLf & "  if  isnull(dtp" & fld.name & ") then"
        SaveFields = SaveFields & vbCrLf & "    item." & fld.name & " = 0"
        SaveFields = SaveFields & vbCrLf & "  else"
        SaveFields = SaveFields & vbCrLf & "    item." & fld.name & " = dtp" & fld.name & ".value"
        SaveFields = SaveFields & vbCrLf & "  end if"
       End If
       
       LoadFields = LoadFields & vbCrLf & "if item." & fld.name & " <> 0 then"
       LoadFields = LoadFields & vbCrLf & " dtp" & fld.name & " = item." & fld.name
       If fld.AllowNull Then
          LoadFields = LoadFields & vbCrLf & "else"
          LoadFields = LoadFields & vbCrLf & " dtp" & fld.name & ".value = null"
       End If
       LoadFields = LoadFields & vbCrLf & "end if"
       pos = pos + 25 * Screen.TwipsPerPixelY
       
       If Not fld.AllowNull Then
        IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK = IsSet(dtp" & fld.name & ".value)"
      End If

       
    End If ' DATE TIME DATETIME

    ' Enum !!!
    If GenStyle = "COMBOBOX" Or GenStyle = "CHECKBOX" Then

      Set ctl = fd.ControlData.Add()
      ctl.ProgId = "VB.ComboBox"
      Call AddProp(ctl, "NAME", "cmb" & fld.name)
      Call AddProp(ctl, "Style", 2)
      Call AddProp(ctl, "Sorted", True)
      Call AddProp(ctl, "Top", pos)
      Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
      Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
      Call AddProp(ctl, "Width", 200 * Screen.TwipsPerPixelY)
      Call AddProp(ctl, "Enabled", Not ReadOnly)

      
      body = body & vbCrLf & "private sub cmb" & fld.name & "_Click()"
      body = body & vbCrLf & "  on error resume next"
      body = body & vbCrLf & "  Changing"
      body = body & vbCrLf & "end sub"

      If Not ReadOnly Then
        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = cmb" & fld.name & ".itemdata(cmb" & fld.name & ".listindex)"
      End If

      Dim ii As Long
      LoadFields = LoadFields & vbCrLf & "cmb" & fld.name & ".Clear"
      For ii = 1 To fld.FIELDTYPE.ENUMITEM.Count
        LoadFields = LoadFields & vbCrLf & "cmb" & fld.name & ".additem """ & fld.FIELDTYPE.ENUMITEM.item(ii).name & """"
        LoadFields = LoadFields & vbCrLf & "cmb" & fld.name & ".itemdata(cmb" & fld.name & ".newindex)= " & fld.FIELDTYPE.ENUMITEM.item(ii).NameValue
      Next
      
      LoadFields = LoadFields & vbCrLf & " For iii = 0 To cmb" & fld.name & ".ListCount-1"
      LoadFields = LoadFields & vbCrLf & "  If Item." & fld.name & " = cmb" & fld.name & ".ItemData(iii) Then"
      LoadFields = LoadFields & vbCrLf & "   cmb" & fld.name & ".ListIndex = iii"
      LoadFields = LoadFields & vbCrLf & "   Exit For"
      LoadFields = LoadFields & vbCrLf & "  End If"
      LoadFields = LoadFields & vbCrLf & " Next"

      If Not fld.AllowNull Then
        IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =(cmb" & fld.name & ".ListIndex >=0)"
      End If

      pos = pos + 25 * Screen.TwipsPerPixelY
    End If


    Exit Sub
bye:
    MsgBox Err.Description
    'Stop
    'Resume
End Sub








