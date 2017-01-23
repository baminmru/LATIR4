Option Strict Off
Option Explicit On
Imports MTZMetaModel

Module FilterControls
	
	
    Public Sub GenerateFilterControls(ByRef fd As Object, ByRef fld As MTZFltr.MTZFltr.FileterField, ByVal GenStyle As String, ByRef pos As Integer, ByRef SaveFields As String, ByRef LoadFields As String, ByRef COLUMN As Integer, ByRef MINPOS As Integer, ByRef body As String, ByRef decl As String, ByRef IsOK As String)
        On Error GoTo bye

        Dim mproc, txt As String
        Dim pp As Integer
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        ft = fld.FIELDTYPE

        If pos > 420 * VB6.TwipsPerPixelY Then
            COLUMN = COLUMN + 1
            pos = MINPOS
        End If

        Dim ctl As LATIRGenerator.ControlData
        'UPGRADE_WARNING: Couldn't resolve default property of object fd.ControlData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ctl = fd.ControlData.Add()
        ctl.ProgId = "VB.CheckBox"

        Call AddProp(ctl, "BackStyle", CStr(0))
        Call AddProp(ctl, "NAME", "lbl" & fld.name)
        Call AddProp(ctl, "Caption", NoLF(fld.Caption) & ":")
        Call AddProp(ctl, "Top", CStr(pos))
        Call AddProp(ctl, "Left", CStr((210 * COLUMN + 20) * VB6.TwipsPerPixelX))
        Call AddProp(ctl, "Height", CStr(20 * VB6.TwipsPerPixelY))
        Call AddProp(ctl, "Width", CStr(200 * VB6.TwipsPerPixelY))
        Call AddProp(ctl, "ForeColor", System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black).ToString)

        pos = pos + 22 * VB6.TwipsPerPixelY
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' control labeled

        If GenStyle = "REFERENCE" Then
            'UPGRADE_WARNING: Couldn't resolve default property of object fd.ControlData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ctl = fd.ControlData.Add()
            ctl.ProgId = "VB.textbox"
            Call AddProp(ctl, "NAME", "txt" & fld.name)
            Call AddProp(ctl, "Text", "")
            Call AddProp(ctl, "Locked", CStr(True))
            Call AddProp(ctl, "Enabled", CStr(True))
            Call AddProp(ctl, "Top", CStr(pos))
            Call AddProp(ctl, "Left", CStr((210 * COLUMN + 20) * VB6.TwipsPerPixelX))
            Call AddProp(ctl, "Height", CStr(20 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Width", CStr(170 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))


            'UPGRADE_WARNING: Couldn't resolve default property of object fd.ControlData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ctl = fd.ControlData.Add()
            ctl.ProgId = "MTZ_PANEL.DropButton"
            Call AddProp(ctl, "NAME", "cmd" & fld.name)
            Call AddProp(ctl, "Caption", "")
            Call AddProp(ctl, "Tag", "refopen.ico")
            Call AddProp(ctl, "Top", CStr(pos))
            Call AddProp(ctl, "Enabled", CStr(True))
            Call AddProp(ctl, "Left", CStr((210 * COLUMN + 20) * VB6.TwipsPerPixelX + 170 * VB6.TwipsPerPixelX))
            Call AddProp(ctl, "Height", CStr(20 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Width", CStr(30 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))

            pos = pos + 25 * VB6.TwipsPerPixelY

            body = body & vbCrLf & "private sub txt" & fld.name & "_Change()"
            body = body & vbCrLf & "  Changing"
            body = body & vbCrLf & "end sub"


            LoadFields = LoadFields & vbCrLf & "  txt" & fld.name & ".Tag = """" "
            LoadFields = LoadFields & vbCrLf & "  txt" & fld.name & " = """" "


            LoadFields = LoadFields & vbCrLf & " LoadBtnPictures cmd" & fld.name & ",cmd" & fld.name & ".tag"
            LoadFields = LoadFields & vbCrLf & "  cmd" & fld.name & ".RemoveAllMenu"


            'LoadFields = LoadFields & vbCrLf & "  cmd" & fld.name & ".AddMenu ""Очистить"" "


            If fld.RefType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                'LoadFields = LoadFields & vbCrLf & "  cmd" & fld.name & ".AddMenu ""Открыть"" "
                LoadFields = LoadFields & vbCrLf & "  cmd" & fld.name & ".AddMenu ""Выбрать"" "


                body = body & vbCrLf & "private sub cmd" & fld.name & "_CLick()"
                body = body & vbCrLf & "  on error resume next"
                'body = body & vbCrLf & "     If txt" & fld.name & ".Tag ="""" then"
                body = body & vbCrLf & "       cmd" & fld.name & "_MenuClick ""Выбрать"" "

                'body = body & vbCrLf & "     Else"
                'body = body & vbCrLf & "       cmd" & fld.name & "_MenuClick ""Открыть"" "
                'body = body & vbCrLf & "     End If"
                body = body & vbCrLf & "end sub"

                body = body & vbCrLf & "private sub cmd" & fld.name & "_MenuClick(ByVal sCaption As String)"
                body = body & vbCrLf & "  on error resume next"
                body = body & vbCrLf & "    dim inst as object"
                body = body & vbCrLf & "    dim obj as object"
                body = body & vbCrLf & "    Dim OK As boolean"
                body = body & vbCrLf & "    Dim id As string"
                body = body & vbCrLf & "    Dim brief As string"

                body = body & vbCrLf & "  if sCaption =""Очистить"" then"

                body = body & vbCrLf & "          txt" & fld.name & ".Tag = """""
                body = body & vbCrLf & "          txt" & fld.name & " = """""
                body = body & vbCrLf & "  end if"

                body = body & vbCrLf & "  if sCaption =""Открыть"" then"
                body = body & vbCrLf & "    if txt" & fld.name & ".tag ="""" then exit sub"
                body = body & vbCrLf & "    set inst  = item.Application.Manager.GetInstanceObject(txt" & fld.name & ".tag)"
                body = body & vbCrLf & "    if inst is nothing then exit sub"
                body = body & vbCrLf & "    set obj = item.Application.Manager.GetInstanceGUI(txt" & fld.name & ".tag)"
                body = body & vbCrLf & "    obj.show """", inst,true"
                body = body & vbCrLf & "    set obj =nothing"
                body = body & vbCrLf & "    set inst =nothing"
                body = body & vbCrLf & "  end if"

                body = body & vbCrLf & "  if sCaption =""Выбрать"" then"
                If fld.RefToType Is Nothing Then
                    body = body & vbCrLf & "        OK=Item.Application.Manager.GetObjectListDialog2(id,brief,"""","""")"
                Else
                    'UPGRADE_WARNING: Couldn't resolve default property of object ctype(fld.reftotype,Mtzmetamodel.mtzmetamodel.Objecttype).name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    body = body & vbCrLf & "        OK=Item.Application.Manager.GetObjectListDialog2(id,brief,"""",""" & CType(fld.RefToType, MTZMetaModel.MTZMetaModel.OBJECTTYPE).Name & """)"
                End If

                body = body & vbCrLf & "        If OK Then"
                body = body & vbCrLf & "          txt" & fld.name & ".Tag = left(ID,38)"
                body = body & vbCrLf & "          txt" & fld.name & " = brief"
                body = body & vbCrLf & "        End If"
                body = body & vbCrLf & "  end if"

                body = body & vbCrLf & "End sub"
            End If ' Ref to object

            If fld.RefType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then


                body = body & vbCrLf & "private sub cmd" & fld.name & "_Click()"
                body = body & vbCrLf & "  on error resume next"
                body = body & vbCrLf & "        Dim id As String, brief As String"
                'UPGRADE_WARNING: Couldn't resolve default property of object ctype(fld.reftopart,Mtzmetamodel.mtzmetamodel.Part).name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                body = body & vbCrLf & "        If item.Application.Manager.GetReferenceDialogEx2(""" & CType(fld.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name & """, id, brief) Then"
                body = body & vbCrLf & "          txt" & fld.name & ".Tag = Left(id, 38)"
                body = body & vbCrLf & "          txt" & fld.name & " = brief"
                body = body & vbCrLf & "        End If"
                body = body & vbCrLf & "end sub"


                body = body & vbCrLf & "private sub cmd" & fld.name & "_MenuClick(ByVal sCaption As String)"
                'body = body & vbCrLf & "          txt" & fld.name & ".Tag = """""
                'body = body & vbCrLf & "          txt" & fld.name & " = """""
                body = body & vbCrLf & "End sub"


            End If ' ref to row

        End If 'REFERENCE


        If GenStyle = "TEXT" Or GenStyle = "PASSWORD" Or GenStyle = "GUID" Then
            'UPGRADE_WARNING: Couldn't resolve default property of object fd.ControlData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ctl = fd.ControlData.Add()
            ctl.ProgId = "VB.textbox"
            Call AddProp(ctl, "NAME", "txt" & fld.name)
            Call AddProp(ctl, "Text", "")
            Call AddProp(ctl, "Top", CStr(pos))
            Call AddProp(ctl, "Left", CStr((210 * COLUMN + 20) * VB6.TwipsPerPixelX))
            Call AddProp(ctl, "Height", CStr(20 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Width", CStr(200 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "MaxLength", CStr(fld.FieldSize))
            Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
            Call AddProp(ctl, "Locked", CStr(False))
            Call AddProp(ctl, "Enabled", CStr(True))

            If GenStyle = "PASSWORD" Then
                Call AddProp(ctl, "PasswordChar", "*")
            End If
            pos = pos + 25 * VB6.TwipsPerPixelY
            body = body & vbCrLf & "private sub txt" & fld.name & "_Change()"
            body = body & vbCrLf & "  Changing"
            body = body & vbCrLf & "end sub"
            '      If True Then
            '        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = txt" & fld.name
            '      End If
            LoadFields = LoadFields & vbCrLf & "txt" & fld.name & " = """""




        End If ' TEXT PASSWORD GUID

        ' todo
        If GenStyle = "EMAIL" Then
            'UPGRADE_WARNING: Couldn't resolve default property of object fd.ControlData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ctl = fd.ControlData.Add()
            ctl.ProgId = "VB.textbox"
            Call AddProp(ctl, "NAME", "txt" & fld.name)
            Call AddProp(ctl, "Text", "")
            Call AddProp(ctl, "Top", CStr(pos))
            Call AddProp(ctl, "Left", CStr((210 * COLUMN + 20) * VB6.TwipsPerPixelX))
            Call AddProp(ctl, "Height", CStr(20 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Width", CStr(170 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "MaxLength", CStr(fld.FieldSize))
            Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
            Call AddProp(ctl, "Locked", CStr(False))
            Call AddProp(ctl, "Enabled", CStr(True))

            'UPGRADE_WARNING: Couldn't resolve default property of object fd.ControlData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ctl = fd.ControlData.Add()
            ctl.ProgId = "MTZ_PANEL.DropButton"
            Call AddProp(ctl, "NAME", "cmd" & fld.name)
            Call AddProp(ctl, "Caption", "")
            Call AddProp(ctl, "Tag", "mailopen.ico")
            Call AddProp(ctl, "Top", CStr(pos))
            Call AddProp(ctl, "Left", CStr((210 * COLUMN + 20) * VB6.TwipsPerPixelX + 170 * VB6.TwipsPerPixelX))
            Call AddProp(ctl, "Height", CStr(20 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Width", CStr(30 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))


            pos = pos + 25 * VB6.TwipsPerPixelY

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

            '      If True Then
            '        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = txt" & fld.name
            '      End If
            'LoadFields = LoadFields & vbCrLf & "txt" & fld.name & " = item." & fld.name
            LoadFields = LoadFields & vbCrLf & " LoadBtnPictures cmd" & fld.name & ",cmd" & fld.name & ".tag"
            LoadFields = LoadFields & vbCrLf & "  cmd" & fld.name & ".RemoveAllMenu"



        End If 'EMAIL


        ' todo
        If GenStyle = "URL" Then
            'UPGRADE_WARNING: Couldn't resolve default property of object fd.ControlData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ctl = fd.ControlData.Add()
            ctl.ProgId = "VB.textbox"
            Call AddProp(ctl, "NAME", "txt" & fld.name)
            Call AddProp(ctl, "Text", "")
            Call AddProp(ctl, "Top", CStr(pos))
            Call AddProp(ctl, "Left", CStr((210 * COLUMN + 20) * VB6.TwipsPerPixelX))
            Call AddProp(ctl, "Height", CStr(20 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Width", CStr(170 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "MaxLength", CStr(fld.FieldSize))
            Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
            Call AddProp(ctl, "Locked", CStr(False))
            Call AddProp(ctl, "Enabled", CStr(True))

            'UPGRADE_WARNING: Couldn't resolve default property of object fd.ControlData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ctl = fd.ControlData.Add()
            ctl.ProgId = "MTZ_PANEL.DropButton"
            Call AddProp(ctl, "NAME", "cmd" & fld.name)
            Call AddProp(ctl, "Caption", "")
            Call AddProp(ctl, "Tag", "urlopen.ico")
            Call AddProp(ctl, "Top", CStr(pos))
            Call AddProp(ctl, "Left", CStr((210 * COLUMN + 20) * VB6.TwipsPerPixelX + 170 * VB6.TwipsPerPixelX))
            Call AddProp(ctl, "Height", CStr(20 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Width", CStr(30 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))


            pos = pos + 25 * VB6.TwipsPerPixelY

            body = body & vbCrLf & "private sub txt" & fld.name & "_Change()"
            body = body & vbCrLf & "  Changing"
            body = body & vbCrLf & "end sub"

            body = body & vbCrLf & "private sub cmd" & fld.name & "_CLick()"
            body = body & vbCrLf & "  on error resume next"
            body = body & vbCrLf & "  Dim s As String"
            body = body & vbCrLf & "  s = s & ""http:\\"" & txt" & fld.name & ".text "
            body = body & vbCrLf & "  OpenDocument 0, s"
            body = body & vbCrLf & "end sub"

            '      If True Then
            '        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = txt" & fld.name
            '      End If

            'LoadFields = LoadFields & vbCrLf & "txt" & fld.name & " = item." & fld.name
            LoadFields = LoadFields & vbCrLf & " LoadBtnPictures cmd" & fld.name & ",cmd" & fld.name & ".tag"
            LoadFields = LoadFields & vbCrLf & "  cmd" & fld.name & ".RemoveAllMenu"



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
            '      mproc = mproc & vbCrLf & " Dialog.flags = cdlOFNFileMustExist + cdlOFNHidefalse + cdlOFNPathMustExist"
            '      mproc = mproc & vbCrLf & " Dialog.filter = ""(*.htm;*.html)|*.htm;*.html"""
            '      mproc = mproc & vbCrLf & " Dialog.DialogTitle = ""Гипертекстовый файл"""
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
            '      LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".AddMenu ""Очистить"""

            'UPGRADE_WARNING: Couldn't resolve default property of object fd.ControlData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ctl = fd.ControlData.Add()
            ctl.ProgId = "VB.textbox"
            Call AddProp(ctl, "NAME", "txt" & fld.name)
            Call AddProp(ctl, "Text", "")
            Call AddProp(ctl, "Top", CStr(pos))
            Call AddProp(ctl, "Left", CStr((210 * COLUMN + 20) * VB6.TwipsPerPixelX))
            Call AddProp(ctl, "Height", CStr(20 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Width", CStr(200 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Multiline", CStr(True))
            Call AddProp(ctl, "Scrollbars", CStr(3))
            Call AddProp(ctl, "Locked", CStr(False))
            Call AddProp(ctl, "Enabled", CStr(True))

            Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))

            pos = pos + 25 * VB6.TwipsPerPixelY
            body = body & vbCrLf & "private sub txt" & fld.name & "_Change()"
            body = body & vbCrLf & "  Changing"
            body = body & vbCrLf & "end sub"
            '      If True Then
            '        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = txt" & fld.name
            '      End If
            '      LoadFields = LoadFields & vbCrLf & "txt" & fld.name & " = item." & fld.name



        End If 'HTML




        If GenStyle = "MEMO" Then
            'UPGRADE_WARNING: Couldn't resolve default property of object fd.ControlData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ctl = fd.ControlData.Add()
            ctl.ProgId = "VB.textbox"
            Call AddProp(ctl, "NAME", "txt" & fld.name)
            Call AddProp(ctl, "Text", "")
            Call AddProp(ctl, "Top", CStr(pos))
            Call AddProp(ctl, "Left", CStr((210 * COLUMN + 20) * VB6.TwipsPerPixelX))
            Call AddProp(ctl, "Height", CStr(80 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Width", CStr(200 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Multiline", CStr(True))
            Call AddProp(ctl, "Scrollbars", CStr(2))
            Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
            Call AddProp(ctl, "Locked", CStr(False))
            Call AddProp(ctl, "Enabled", CStr(True))
            pos = pos + 85 * VB6.TwipsPerPixelY


            body = body & vbCrLf & "private sub txt" & fld.name & "_Change()"
            body = body & vbCrLf & "  Changing"
            body = body & vbCrLf & "end sub"
            '      If True Then
            '        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = txt" & fld.name
            '      End If
            '      LoadFields = LoadFields & vbCrLf & "txt" & fld.name & " = item." & fld.name



        End If ' MEMO


        If GenStyle = "RTF" Then
            'UPGRADE_WARNING: Couldn't resolve default property of object fd.ControlData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ctl = fd.ControlData.Add()
            ctl.ProgId = "MTZ_PANEL.RTFEDITOR"
            Call AddProp(ctl, "NAME", "txt" & fld.name)
            Call AddProp(ctl, "Text", "")
            Call AddProp(ctl, "Top", CStr(pos))
            Call AddProp(ctl, "Left", CStr((210 * COLUMN + 20) * VB6.TwipsPerPixelX))
            Call AddProp(ctl, "Height", CStr(80 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Width", CStr(200 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
            Call AddProp(ctl, "Enabled", CStr(True))

            pos = pos + 85 * VB6.TwipsPerPixelY


            body = body & vbCrLf & "private sub txt" & fld.name & "_OnChange()"
            body = body & vbCrLf & "  Changing"
            body = body & vbCrLf & "end sub"

            '      If True Then
            '        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = txt" & fld.name & ".RTF"
            '      End If
            '      LoadFields = LoadFields & vbCrLf & "txt" & fld.name & ".RTF = item." & fld.name



        End If ' RTF



        ''''''''''' File

        If GenStyle = "FILE" Then
            '''       Set ctl = fd.ControlData.Add()
            '''       ctl.ProgId = "VB.textbox"
            '''       Call AddProp(ctl, "NAME", "txt" & fld.name)
            '''       Call AddProp(ctl, "Top", pos)
            '''       Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
            '''       Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
            '''       Call AddProp(ctl, "Width", 170 * Screen.TwipsPerPixelY)
            '''       Call AddProp(ctl, "Locked", True)
            '''       Call AddProp(ctl, "Enabled", True)
            '''       Call AddProp(ctl, "BorderStyle", 1)
            '''       Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
            '''
            '''
            '''      Set ctl = fd.ControlData.Add()
            '''      ctl.ProgId = "MTZ_PANEL.DropButton"
            '''      Call AddProp(ctl, "NAME", "cmd" & fld.name)
            '''      Call AddProp(ctl, "Caption", "")
            '''      Call AddProp(ctl, "Tag", "fileopen.ico")
            '''      Call AddProp(ctl, "Top", pos)
            '''      Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX + 170 * Screen.TwipsPerPixelX)
            '''      Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
            '''      Call AddProp(ctl, "Width", 30 * Screen.TwipsPerPixelY)
            '''      Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
            '''
            '''      pos = pos + 25 * Screen.TwipsPerPixelY
            '''
            '''       ' dilog for file open
            '''        If fd.ControlData.Item("Dialog") Is Nothing Then
            '''          Set ctl = fd.ControlData.Add("Dialog")
            '''          ctl.ProgId = "MSComDlg.CommonDialog"
            '''          Call AddProp(ctl, "Name", "Dialog")
            '''          Call AddProp(ctl, "Top", pos - 10 * Screen.TwipsPerPixelY)
            '''          Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
            '''       End If
            '''      On Error GoTo bye
            '''
            '''
            '''        body = body & vbCrLf & "Private Sub cmd" & fld.name & "_Click()"
            '''        body = body & vbCrLf & "  on error resume next"
            '''        body = body & vbCrLf & "  if item." & fld.name & "_ext <>"""" and not isnull(item." & fld.name & ")  then"
            '''        body = body & vbCrLf & "    cmd" & fld.name & "_MenuClick ""Открыть"""
            '''        If True Then
            '''          body = body & vbCrLf & "  else"
            '''          body = body & vbCrLf & "    cmd" & fld.name & "_MenuClick ""Выбрать"""
            '''        End If
            '''        body = body & vbCrLf & "  End if"
            '''        body = body & vbCrLf & "End Sub"
            '''        body = body & vbCrLf & ""
            '''        body = body & vbCrLf & "Private Sub cmd" & fld.name & "_MenuClick(ByVal sCaption As String)"
            '''        If True Then
            '''          body = body & vbCrLf & "  If sCaption = ""Выбрать"" Then"
            '''          body = body & vbCrLf & "   Dialog.Flags = cdlOFNFileMustExist + cdlOFNHidefalse + cdlOFNPathMustExist"
            '''          body = body & vbCrLf & "   Dialog.Filter = ""(*.*)|*.*"""
            '''          body = body & vbCrLf & "   Dialog.DialogTitle = ""Файл"""
            '''          body = body & vbCrLf & "   Dialog.CancelError = True"
            '''          body = body & vbCrLf & "   On Error Resume Next"
            '''          body = body & vbCrLf & "   Dialog.ShowOpen"
            '''          body = body & vbCrLf & "   If (Err.Number > 0) Then"
            '''          body = body & vbCrLf & "    Err.Clear"
            '''          body = body & vbCrLf & "    Exit Sub"
            '''          body = body & vbCrLf & "   End If"
            '''          body = body & vbCrLf & "   txt" & fld.name & " = Dialog.FileName"
            '''          body = body & vbCrLf & "   item." & fld.name & " = FileToArray(Dialog.FileName)"
            '''          body = body & vbCrLf & "   item." & fld.name & "_ext = GetFileExtension2(Dialog.FileName)"
            '''          body = body & vbCrLf & "   Changing"
            '''          body = body & vbCrLf & "  End If"
            '''
            '''          body = body & vbCrLf & "  If sCaption = ""Очистить"" Then"
            '''          body = body & vbCrLf & "   txt" & fld.name & " = """" "
            '''          body = body & vbCrLf & "   item." & fld.name & " = null"
            '''          body = body & vbCrLf & "   item." & fld.name & "_ext = """""
            '''          body = body & vbCrLf & "   Changing"
            '''          body = body & vbCrLf & "  End If"
            '''        End If
            '''        body = body & vbCrLf & "  If sCaption = ""Открыть"" Then"
            '''        body = body & vbCrLf & "    item.Application.manager.StoreTempFileData DoOpenFile( item." & fld.name & ", item." & fld.name & "_ext),item.partname,item.id"
            '''        body = body & vbCrLf & "  End If"
            '''
            '''        body = body & vbCrLf & "  If sCaption = ""Сохранить"" Then"
            '''        body = body & vbCrLf & "   Dialog.Flags = cdlOFNHidefalse + cdlOFNPathMustExist"
            '''        body = body & vbCrLf & "   Dialog.Filter = ""(*.*)|*.*"""
            '''        body = body & vbCrLf & "   Dialog.DialogTitle = ""Файл"""
            '''        body = body & vbCrLf & "   Dialog.CancelError = True"
            '''        body = body & vbCrLf & "   On Error Resume Next"
            '''        body = body & vbCrLf & "   Dialog.ShowSave"
            '''        body = body & vbCrLf & "   If (Err.Number > 0) Then"
            '''        body = body & vbCrLf & "    Err.Clear"
            '''        body = body & vbCrLf & "    Exit Sub"
            '''        body = body & vbCrLf & "   End If"
            '''        body = body & vbCrLf & "   ArrayToFile Dialog.FileName, item." & fld.name
            '''        body = body & vbCrLf & "  End If"
            '''        body = body & vbCrLf & "End Sub"
            '''
            '''
            '''      SaveFields = SaveFields & vbCrLf & " ' SEE cmd" & fld.name & "_CLICK"
            '''
            '''      LoadFields = LoadFields & vbCrLf & " if  lenb(item." & fld.name & ")>0 then "
            '''      LoadFields = LoadFields & vbCrLf & "   txt" & fld.name & "=""Данные ("" & item." & fld.name & "_ext & "")"""
            '''      LoadFields = LoadFields & vbCrLf & " else "
            '''      LoadFields = LoadFields & vbCrLf & "   txt" & fld.name & "="""""
            '''      LoadFields = LoadFields & vbCrLf & " end if "
            '''
            '''      LoadFields = LoadFields & vbCrLf & " LoadBtnPictures cmd" & fld.name & ",cmd" & fld.name & ".tag"
            '''      LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".RemoveAllMenu"
            '''      LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".AddMenu ""Выбрать"""
            '''      LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".AddMenu ""Сохранить"""
            '''      LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".AddMenu ""Открыть"""
            '''


        End If ' FILE

        '''''''''''

        If GenStyle = "IMAGE" Then
            '''       Set ctl = fd.ControlData.Add()
            '''       ctl.ProgId = "VB.image"
            '''       Call AddProp(ctl, "NAME", "img" & fld.name)
            '''       Call AddProp(ctl, "Top", pos)
            '''       Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
            '''       Call AddProp(ctl, "Height", 80 * Screen.TwipsPerPixelY)
            '''       Call AddProp(ctl, "Width", 170 * Screen.TwipsPerPixelY)
            '''       Call AddProp(ctl, "Stretch", True)
            '''       Call AddProp(ctl, "BorderStyle", 1)
            '''       Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
            '''
            '''
            '''
            '''      decl = decl & vbCrLf & " dim m_" & fld.name
            '''
            '''      Set ctl = fd.ControlData.Add()
            '''      ctl.ProgId = "MTZ_PANEL.DropButton"
            '''      Call AddProp(ctl, "NAME", "cmd" & fld.name)
            '''      Call AddProp(ctl, "Caption", "")
            '''      Call AddProp(ctl, "Tag", "imageopen.ico")
            '''      Call AddProp(ctl, "Top", pos)
            '''      Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX + 170 * Screen.TwipsPerPixelX)
            '''      Call AddProp(ctl, "Height", 20 * Screen.TwipsPerPixelY)
            '''      Call AddProp(ctl, "Width", 30 * Screen.TwipsPerPixelY)
            '''      Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
            '''      Call AddProp(ctl, "Visible", True)
            '''
            '''
            '''       ' dilog for file open
            '''       If fd.ControlData.Item("Dialog") Is Nothing Then
            '''         Set ctl = fd.ControlData.Add("Dialog")
            '''         ctl.ProgId = "MSComDlg.CommonDialog"
            '''         Call AddProp(ctl, "Name", "Dialog")
            '''         Call AddProp(ctl, "Top", pos - 10 * Screen.TwipsPerPixelY)
            '''         Call AddProp(ctl, "Left", (210 * COLUMN + 20) * Screen.TwipsPerPixelX)
            '''       End If
            '''
            '''       pos = pos + 85 * Screen.TwipsPerPixelY
            '''
            '''      On Error GoTo bye
            '''
            '''      ' procedure for load file into image
            '''      If True Then
            '''        mproc = ""
            '''
            '''        mproc = mproc & vbCrLf & " Dialog.flags = cdlOFNFileMustExist + cdlOFNHidefalse + cdlOFNPathMustExist"
            '''        mproc = mproc & vbCrLf & " Dialog.filter = ""(*.BMP;*.ICO;*.GIF;*.JPG)|*.BMP;*.ICO;*.GIF;*.JPG"""
            '''        mproc = mproc & vbCrLf & " Dialog.DialogTitle = ""Файл изображения"""
            '''        mproc = mproc & vbCrLf & " Dialog.CancelError = True"
            '''        mproc = mproc & vbCrLf & " On Error Resume Next"
            '''        mproc = mproc & vbCrLf & " Dialog.ShowOpen"
            '''        mproc = mproc & vbCrLf & " If (Err.Number > 0) Then"
            '''        mproc = mproc & vbCrLf & "  Err.Clear"
            '''        mproc = mproc & vbCrLf & "  Exit Sub"
            '''        mproc = mproc & vbCrLf & " End If"
            '''        mproc = mproc & vbCrLf & " set img" & fld.name & ".picture=LoadPicture(Dialog.FileName)"
            '''        mproc = mproc & vbCrLf & " item." & fld.name & "=FileToArray( Dialog.FileName)"
            '''        mproc = mproc & vbCrLf & " Changing"
            '''
            '''
            '''        body = body & vbCrLf & "private sub CMD" & fld.name & "_CLICK()"
            '''        body = body & vbCrLf & "  on error resume next"
            '''        body = body & vbCrLf & mproc
            '''        body = body & vbCrLf & "end sub"
            '''
            '''        mproc = ""
            '''        mproc = mproc & vbCrLf & " set img" & fld.name & ".picture=LoadPicture()"
            '''        mproc = mproc & vbCrLf & " item." & fld.name & "= null"
            '''        mproc = mproc & vbCrLf & " Changing"
            '''
            '''        body = body & vbCrLf & "Private Sub cmd" & fld.name & "_MenuClick(ByVal sCaption As String)"
            '''        body = body & vbCrLf & mproc
            '''        body = body & vbCrLf & "end sub"
            '''
            '''        SaveFields = SaveFields & vbCrLf & " ' SEE cmd" & fld.name & "_CLICK"
            '''      End If
            '''
            '''      LoadFields = LoadFields & vbCrLf & " LoadImage img" & fld.name & ", item." & fld.name
            '''      LoadFields = LoadFields & vbCrLf & " LoadBtnPictures cmd" & fld.name & ",cmd" & fld.name & ".tag"
            '''      LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".RemoveAllMenu"
            '''      LoadFields = LoadFields & vbCrLf & " cmd" & fld.name & ".AddMenu ""Очистить"""
            '''
            '''      If Not fld.AllowNull Then
            '''        IsOK = IsOK & vbCrLf & "if mIsOK then mIsOK =(lenb(item." & fld.name & ")>0)"
            '''      End If

        End If 'IMAGE


        ' numeric type
        'Double
        'Integer
        'Long

        If GenStyle = "NUMERIC" Or GenStyle = "INTEGER" Or GenStyle = "INTERVAL" Then

            'UPGRADE_WARNING: Couldn't resolve default property of object fd.ControlData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ctl = fd.ControlData.Add()
            ctl.ProgId = "VB.textbox"
            Call AddProp(ctl, "NAME", "txt" & fld.name)
            Call AddProp(ctl, "Text", "")
            Call AddProp(ctl, "Top", CStr(pos))
            Call AddProp(ctl, "Left", CStr((210 * COLUMN + 20) * VB6.TwipsPerPixelX))
            Call AddProp(ctl, "Height", CStr(20 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Width", CStr(120 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
            Call AddProp(ctl, "CausesValidation", CStr(True))
            Call AddProp(ctl, "Locked", CStr(False))
            Call AddProp(ctl, "Enabled", CStr(True))

            If GenStyle = "NUMERIC" Then
                Call AddProp(ctl, "MaxLength", CStr(27))
            Else
                Call AddProp(ctl, "MaxLength", CStr(15))
            End If
            If True Then
                If GenStyle = "NUMERIC" Then
                    body = body & vbCrLf & "private sub txt" & fld.name & "_Validate(cancel as boolean)"
                    body = body & vbCrLf & "if txt" & fld.name & ".text<>"""" then " & vbCrLf & " on error resume next " & vbCrLf & "  if not isnumeric(txt" & fld.name & ".text) then " & vbCrLf & "     cancel=true " & vbCrLf & "     msgbox ""Ожидалось число"",vbokonly+vbexclamation,""Внимание"" " & vbCrLf & "  elseif Val(txt" & fld.name & ".text) < -922337203685477.5808 or Val(txt" & fld.name & ".text)>+922337203685477.5807 then " & vbCrLf & "     cancel=true " & vbCrLf & "     msgbox ""Значение вне допустимого диапазона"",vbokonly+vbexclamation,""Внимание"" " & vbCrLf & "  end if" & vbCrLf & "end if"
                    body = body & vbCrLf & "end sub"
                ElseIf GenStyle = "INTEGER" Then
                    body = body & vbCrLf & "private sub txt" & fld.name & "_Validate(cancel as boolean)"
                    body = body & vbCrLf & "if txt" & fld.name & ".text<>"""" then " & vbCrLf & " on error resume next " & vbCrLf & "  if not isnumeric(txt" & fld.name & ".text) then " & vbCrLf & "     cancel=true " & vbCrLf & "     msgbox ""Ожидалось число"",vbokonly+vbexclamation,""Внимание"" " & vbCrLf & "  elseif Val(txt" & fld.name & ".text) <>clng(Val(txt" & fld.name & ".text)) then " & vbCrLf & "     cancel=true " & vbCrLf & "     msgbox ""Ожидалось целое число"",vbokonly+vbexclamation,""Внимание"" " & vbCrLf & "  end if" & vbCrLf & "end if"
                    body = body & vbCrLf & "end sub"
                ElseIf GenStyle = "INTERVAL" Then
                    body = body & vbCrLf & "private sub txt" & fld.name & "_Validate(cancel as boolean)"
                    body = body & vbCrLf & "if txt" & fld.name & ".text<>"""" then " & vbCrLf & " on error resume next " & vbCrLf & "  if not isnumeric(txt" & fld.name & ".text) then " & vbCrLf & "     cancel=true " & vbCrLf & "     msgbox ""Ожидалось число"",vbokonly+vbexclamation,""Внимание"" " & vbCrLf & "  elseif Val(txt" & fld.name & ".text) <>clng(Val(txt" & fld.name & ".text)) then " & vbCrLf & "     cancel=true " & vbCrLf & "     msgbox ""Ожидалось целое число"",vbokonly+vbexclamation,""Внимание"" " & vbCrLf & "  elseif Val(txt" & fld.name & ".text) < 0" & ft.Minimum & " or  Val(txt" & fld.name & ".text)> 0" & ft.Maximum & " then " & vbCrLf & "     cancel=true " & vbCrLf & "     msgbox ""Значение вне допустимого диапазона"",vbokonly+vbexclamation,""Внимание"" " & vbCrLf & "  end if" & vbCrLf & "end if"
                    body = body & vbCrLf & "end sub"
                End If


                body = body & vbCrLf & "Private Sub txt" & fld.name & "_KeyPess(KeyAscii As Integer)"
                body = body & vbCrLf & "Dim s As String" & vbCrLf & "s = ""0123456789.,-"" & Chr(8)" & vbCrLf & "If InStr(s, Chr(KeyAscii)) > 0 Then Exit Sub" & vbCrLf & "KeyAscii = 0" & vbCrLf
                body = body & vbCrLf & "End Sub"
            End If

            body = body & vbCrLf & "private sub txt" & fld.name & "_Change()"
            body = body & vbCrLf & "  Changing"
            body = body & vbCrLf & "end sub"

            '      If True Then
            '        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = cdbl(txt" & fld.name & ")"
            '      End If
            '      LoadFields = LoadFields & vbCrLf & "txt" & fld.name & " = item." & fld.name

            pos = pos + 25 * VB6.TwipsPerPixelY
        End If

        ' date type
        If GenStyle = "DATE" Or GenStyle = "DATETIME" Or GenStyle = "TIME" Then

            'UPGRADE_WARNING: Couldn't resolve default property of object fd.ControlData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ctl = fd.ControlData.Add()
            ctl.ProgId = "MSComCtl2.DTPicker"
            Call AddProp(ctl, "NAME", "dtp" & fld.name)
            Call AddProp(ctl, "Top", CStr(pos))
            Call AddProp(ctl, "Left", CStr((210 * COLUMN + 20) * VB6.TwipsPerPixelX))
            Call AddProp(ctl, "Height", CStr(20 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Format", CStr(3))
            Call AddProp(ctl, "Enabled", CStr(True))

            Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
            If GenStyle = "DATETIME" Then
                Call AddProp(ctl, "CustomFormat", "dd/MM/yyyy HH:mm:ss")
                Call AddProp(ctl, "Width", CStr(150 * VB6.TwipsPerPixelY))
                LoadFields = LoadFields & vbCrLf & "dtp" & fld.name & " = now"
            End If
            If GenStyle = "DATE" Then
                Call AddProp(ctl, "CustomFormat", "dd/MM/yyyy")
                Call AddProp(ctl, "Width", CStr(120 * VB6.TwipsPerPixelY))
                LoadFields = LoadFields & vbCrLf & "dtp" & fld.name & " = date"
            End If
            If GenStyle = "TIME" Then
                Call AddProp(ctl, "CustomFormat", "HH:mm:ss")
                Call AddProp(ctl, "Width", CStr(120 * VB6.TwipsPerPixelY))
                Call AddProp(ctl, "UpDown", CStr(True))
                LoadFields = LoadFields & vbCrLf & "dtp" & fld.name & " = time"
            End If


            Call AddProp(ctl, "CheckBox", CStr(False))


            body = body & vbCrLf & "private sub dtp" & fld.name & "_Change()"
            body = body & vbCrLf & "  Changing"
            body = body & vbCrLf & "end sub"


            '       If True Then
            '        SaveFields = SaveFields & vbCrLf & "  if  isnull(dtp" & fld.name & ") then"
            '        SaveFields = SaveFields & vbCrLf & "    item." & fld.name & " = 0"
            '        SaveFields = SaveFields & vbCrLf & "  else"
            '        SaveFields = SaveFields & vbCrLf & "    item." & fld.name & " = dtp" & fld.name & ".value"
            '        SaveFields = SaveFields & vbCrLf & "  end if"
            '       End If

            '       LoadFields = LoadFields & vbCrLf & "if item." & fld.name & " <> 0 then"
            '       LoadFields = LoadFields & vbCrLf & " dtp" & fld.name & " = item." & fld.name
            '
            '       LoadFields = LoadFields & vbCrLf & "end if"
            pos = pos + 25 * VB6.TwipsPerPixelY




        End If ' DATE TIME DATETIME
        Debug.Print(GenStyle)
        ' Enum !!!
        Dim ii As Integer
        If GenStyle = "COMBOBOX" Or GenStyle = "CHECKBOX" Then

            'UPGRADE_WARNING: Couldn't resolve default property of object fd.ControlData. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ctl = fd.ControlData.Add()
            ctl.ProgId = "VB.ComboBox"
            Call AddProp(ctl, "NAME", "cmb" & fld.name)
            Call AddProp(ctl, "Style", CStr(2))
            Call AddProp(ctl, "Sorted", CStr(True))
            Call AddProp(ctl, "Top", CStr(pos))
            Call AddProp(ctl, "Left", CStr((210 * COLUMN + 20) * VB6.TwipsPerPixelX))
            Call AddProp(ctl, "ToolTipText", NoLF(fld.Caption))
            Call AddProp(ctl, "Width", CStr(200 * VB6.TwipsPerPixelY))
            Call AddProp(ctl, "Enabled", CStr(True))


            body = body & vbCrLf & "private sub cmb" & fld.name & "_Click()"
            body = body & vbCrLf & "  on error resume next"
            body = body & vbCrLf & "  Changing"
            body = body & vbCrLf & "end sub"

            '      If True Then
            '        SaveFields = SaveFields & vbCrLf & "item." & fld.name & " = cmb" & fld.name & ".itemdata(cmb" & fld.name & ".listindex)"
            '      End If

            LoadFields = LoadFields & vbCrLf & "cmb" & fld.name & ".Clear"
            'UPGRADE_WARNING: Couldn't resolve default property of object ctype(fld.FIELDTYPE,Mtzmetamodel.mtzmetamodel.Fieldtype).ENUMITEM. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            For ii = 1 To CType(fld.FieldType, MTZMetaModel.MTZMetaModel.FIELDTYPE).ENUMITEM.Count
                'UPGRADE_WARNING: Couldn't resolve default property of object ctype(fld.FIELDTYPE,Mtzmetamodel.mtzmetamodel.Fieldtype).ENUMITEM. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LoadFields = LoadFields & vbCrLf & "cmb" & fld.Name & ".additem """ & CType(fld.FieldType, MTZMetaModel.MTZMetaModel.FIELDTYPE).ENUMITEM.Item(ii).Name & """"
                'UPGRADE_WARNING: Couldn't resolve default property of object ctype(fld.FIELDTYPE,Mtzmetamodel.mtzmetamodel.Fieldtype).ENUMITEM. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                LoadFields = LoadFields & vbCrLf & "cmb" & fld.Name & ".itemdata(cmb" & fld.Name & ".newindex)= " & CType(fld.FieldType, MTZMetaModel.MTZMetaModel.FIELDTYPE).ENUMITEM.Item(ii).NameValue
            Next

            '      LoadFields = LoadFields & vbCrLf & " For iii = 0 To cmb" & fld.name & ".ListCount-1"
            '      LoadFields = LoadFields & vbCrLf & "  If Item." & fld.name & " = cmb" & fld.name & ".ItemData(iii) Then"
            '      LoadFields = LoadFields & vbCrLf & "   cmb" & fld.name & ".ListIndex = iii"
            '      LoadFields = LoadFields & vbCrLf & "   Exit For"
            '      LoadFields = LoadFields & vbCrLf & "  End If"
            '      LoadFields = LoadFields & vbCrLf & " Next"



            pos = pos + 25 * VB6.TwipsPerPixelY
        End If


        Exit Sub
bye:
        MsgBox(Err.Description)
        Stop
        Resume
    End Sub
End Module