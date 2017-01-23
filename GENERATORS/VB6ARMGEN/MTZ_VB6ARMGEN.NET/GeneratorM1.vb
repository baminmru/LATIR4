Option Strict Off
Option Explicit On
<System.Runtime.InteropServices.ProgId("Generator_NET.Generator")> <System.Runtime.InteropServices.ComVisible(False)> Public Class GeneratorM1
    Dim m As MTZMetaModel.MTZMetaModel.Application
    Dim arm As MTZwp.MTZwp.Application
    'UPGRADE_WARNING: Arrays in structure o may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Dim o As LATIRGenerator.Response
    Dim Manager As LATIR.Manager
    Dim Session As LATIR.Session
    Dim tid As String
    Dim log As String
    Dim fltrCol As Collection

    Public Sub Setup()
        MsgBox("Этот генератор не требует настройки", MsgBoxStyle.Information, "Генератор объектной модели")
    End Sub



    ' method for activate generation process
    Public Function Run(ByRef aModel As Object, ByRef aManager As Object, ByRef aSession As Object, ByRef Output As Object, ByVal ARMID As String, ByRef atid As String) As String
        Manager = aManager
        Session = aSession
        m = aModel
        tid = atid
        o = Output
        log = ""

        Dim i, j As Integer
        Dim body, desc, code As String
        Dim os As MTZMetaModel.MTZMetaModel.PART

        On Error GoTo bye
        o.Project.Attributes.Add("Type").Value = "exe"
        o.Project.Attributes.Add("Template").Value = My.Application.Info.DirectoryPath & "\Template\Template.vbp"

        If ARMID = "" Then
            log = log & vbCrLf & "Define ARM ID!!!"
            Run = ""
            Exit Function
        End If
        arm = Manager.GetInstanceObject(New Guid(ARMID))
        If arm Is Nothing Then
            log = log & vbCrLf & "Wrong ARM ID!!!"
            Run = ""
            Exit Function
        End If

        o.Project.Attributes.Add("Name").Value = MakeValidName(Left(arm.WorkPlace.Item(1).Name, 20))
        o.Project.Attributes.Add("ProjectName").Value = MakeValidName(Left(arm.WorkPlace.Item(1).Name, 20))
        o.Project.Attributes.Add("Description").Value = arm.WorkPlace.Item(1).Caption
        o.Project.Attributes.Add("ExeName").Value = MakeValidName(Left(arm.WorkPlace.Item(1).Name, 20)) & ".Exe"
        log = log & vbCrLf & "Create code for type " & arm.WorkPlace.Item(1).Name


        o.Project.Modules.Item("frmMain").Attributes.Add("Type").Value = "form"
        Dim mainmodule As LATIRGenerator.ModuleHolder
        mainmodule = o.Project.Modules.Item("frmMain")
        o.Block = "'form"
        mainmodule.Blocks.Item((o.Block)).Attributes.Add("Type").Value = "form"



        '#If TRIAL = 1 Then
        '		'UPGRADE_NOTE: #If #EndIf block was not upgraded because the expression TRIAL = 1 did not evaluate to True or was not evaluated. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"'
        '		If Date < DateSerial(2008, 7, 1) Then
        '		'  1. Строим главное меню
        '		'  2. Смотрим какие у нас задействованы журналы (при обработке меню?)
        '		'  3. Сканируем меню и подключаем отчеты
        '		CreateMenu mainmodule, mainmodule.Blocks.Item(1).FormData, arm
        '		End If
        '#Else
        CreateMenu(mainmodule, mainmodule.Blocks.Item(1).FormData, arm)
        '#End If



        code = ""
        code = code & vbCrLf & "private sub UnloadObjects() "
        code = code & vbCrLf & UnloadList(arm.EntryPoints)
        code = code & vbCrLf & "end sub"
        SaveModule("frmMain", "form", "", code)



        code = ""
        code = code & vbCrLf & "public function ARMID() as string"
        code = code & vbCrLf & "   ARMID=""" & ARMID & """"
        code = code & vbCrLf & "end function"
        SaveModule("RoleSupport", "module", "", code)

        '  5. Сканируем список документов и стрим функцию регистрации типов, как MDI документов
        code = ""
        code = code & vbCrLf & "private sub RegisterMDIGUI()"
        code = code & vbCrLf & " Dim g As GUI"

        For i = 1 To arm.ARMTypes.Count
            If Not CType(arm.ARMTypes.Item(i).TheDocumentType, MTZMetaModel.MTZMetaModel.OBJECTTYPE) Is Nothing Then
                code = code & vbCrLf & "Set g = New GUI"
                'UPGRADE_WARNING: Couldn't resolve default property of object arm.ARMTypes.Item().TheDocumentType.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                code = code & vbCrLf & "g.Init """ & CType(arm.ARMTypes.Item(i).TheDocumentType, MTZMetaModel.MTZMetaModel.OBJECTTYPE).Name & """"
                'UPGRADE_WARNING: Couldn't resolve default property of object arm.ARMTypes.Item().TheDocumentType.name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                code = code & vbCrLf & "Manager.RegisterGUI g, """ & CType(arm.ARMTypes.Item(i).TheDocumentType, MTZMetaModel.MTZMetaModel.OBJECTTYPE).Name & """"
            End If
        Next

        code = code & vbCrLf & ""
        code = code & vbCrLf & "end sub"
        SaveModule("Module1", "module", "", code)



        '  4. Сканируем меню и строим фильтры


        CreateFilters(arm.EntryPoints)


        MakeUtil()

        ' return results
        Run = log

        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
        MsgBox(Err.Description)
        'Stop
        'Resume
        Run = log

    End Function





    ' return script code for specified generation target
    Private Function MapScript(ByVal sc As MTZMetaModel.MTZMetaModel.SCRIPT_col) As String
        On Error GoTo bye
        Dim i As Object

        For i = 1 To sc.Count
            'UPGRADE_WARNING: Couldn't resolve default property of object sc.Item(i).Target.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If sc.Item(i).Target.ID.ToString = tid Then
                MapScript = sc.Item(i).Code
                Exit Function
            End If
        Next

        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Stop
        '  Resume
    End Function





    'UPGRADE_NOTE: module was upgraded to module_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub CreateMenu(ByRef module_Renamed As LATIRGenerator.ModuleHolder, ByRef fd As LATIRGenerator.FormData, ByRef arm As MTZwp.MTZwp.Application)
        Dim m As LATIRGenerator.ControlData
        Dim ep As MTZwp.MTZwp.EntryPoints
        Dim i As Integer

        arm.EntryPoints.Sort = "sequence"
        For i = 1 To arm.EntryPoints.Count
            m = fd.ControlData.Add
            m.PROGID = "VB.Menu"
            m.Name = arm.EntryPoints.Item(i).Name
            AddProp(m, "Caption", arm.EntryPoints.Item(i).Caption)
            AddProp(m, "Name", m.Name)

            CreateSubMenu(module_Renamed, fd, m, arm.EntryPoints.Item(i))
            MakeMenuCode(module_Renamed, arm.EntryPoints.Item(i))
        Next
    End Sub

    'UPGRADE_NOTE: module was upgraded to module_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub CreateSubMenu(ByRef module_Renamed As LATIRGenerator.ModuleHolder, ByRef fd As LATIRGenerator.FormData, ByRef cd As LATIRGenerator.ControlData, ByRef ep1 As MTZwp.MTZwp.EntryPoints)

        Dim m As LATIRGenerator.ControlData
        Dim ep As MTZwp.MTZwp.EntryPoints
        Dim i As Integer
        ep1.EntryPoints.Sort = "sequence"
        For i = 1 To ep1.EntryPoints.Count
            m = cd.ControlData.Add
            m.PROGID = "VB.Menu"
            m.Name = ep1.EntryPoints.Item(i).Name
            AddProp(m, "Caption", ep1.EntryPoints.Item(i).Caption)
            AddProp(m, "Name", m.Name)

            CreateSubMenu(module_Renamed, fd, m, ep1.EntryPoints.Item(i))
            MakeMenuCode(module_Renamed, ep1.EntryPoints.Item(i))
        Next

    End Sub


    Private Sub CreateFilters(ByRef ep As MTZwp.MTZwp.EntryPoints_col)

        LoadFilters(ep)

        Dim fltr As MTZFltr.MTZFltr.Application
        For Each fltr In fltrCol
            CreateFilterForm(fltr)
        Next fltr
    End Sub

    Private Sub LoadFilters(ByRef ep As MTZwp.MTZwp.EntryPoints_col)
        Dim fltr As MTZFltr.MTZFltr.Application
        Dim i As Integer

        If fltrCol Is Nothing Then
            fltrCol = New Collection
        End If

        For i = 1 To ep.Count
            If ep.Item(i).ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Otkrit__gurnal Or ep.Item(i).ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Otkrit__otcet Then
                If Not ep.Item(i).TheFilter Is Nothing Then
                    fltr = ep.Item(i).TheFilter
                    On Error Resume Next
                    If Not fltr Is Nothing Then
                        fltrCol.Add(fltr, fltr.ID.ToString)
                    End If
                End If
            End If
            LoadFilters(ep.Item(i).EntryPoints)
        Next

    End Sub


    Private Sub CreateFilterPanels(ByRef fd As LATIRGenerator.FormData, ByRef fltr As MTZFltr.MTZFltr.Application)
        Dim SaveFields, LoadFields As String
        Dim decl, CheckFields, mproc, NullFields, code As String

        Dim panel As LATIRGenerator.ControlData
        Dim pos As Integer
        Dim fld As String
        Dim COLUMN, MINPOS As Integer
        Dim ctl As LATIRGenerator.ControlData

        ' place controls to edit form
        Dim i, j As Integer
        Dim p As MTZFltr.MTZFltr.FilterFieldGroup
        Dim ftmap As String
        Dim RO As Boolean


        fltr.FilterFieldGroup.Sort = "sequence"

        On Error GoTo bye

        If fltr.Filters.Count = 0 Then
            With CType(fltr.Filters.Add, MTZFltr.MTZFltr.Filters)
                .Name = MakeValidName(fltr.Name)
                .TheCaption = fltr.Name
                .Save()
            End With
        End If


        code = code & vbCrLf & "private sub Changing"
        code = code & vbCrLf & "if OnInit then exit sub"
        '''      'code = code & vbCrLf & SaveFields
        code = code & vbCrLf & " raiseevent Changed()"
        code = code & vbCrLf & "end sub"

        For j = 1 To fltr.FilterFieldGroup.Count
            p = fltr.FilterFieldGroup.Item(j)


            pos = 5 * VB6.TwipsPerPixelY



            SaveFields = ""
            LoadFields = ""

            COLUMN = 0
            MINPOS = pos

            panel = fd.ControlData.Add()
            panel.PROGID = "MTZ_panel.Scrolledwindow"
            panel.Name = "Panel" & p.Name
            Call AddProp(panel, "BackStyle", CStr(0))
            Call AddProp(panel, "NAME", panel.Name)
            Call AddProp(panel, "Top", CStr(0))
            Call AddProp(panel, "Left", CStr(0))
            Call AddProp(panel, "Height", CStr(1000))
            Call AddProp(panel, "Width", CStr(1000))

            '      code = code & vbCrLf & "private sub Usercontrol_resize()"
            '      code = code & vbCrLf & "  on error resume next"
            '      code = code & vbCrLf & "  panel." & p.name & "width = usercontrol.width"
            '      code = code & vbCrLf & "  panel." & p.name & "height = usercontrol.height"
            '      code = code & vbCrLf & "end sub"
            '      code = code & vbCrLf & ""


            p.FileterField.Sort = "sequence"

            For i = 1 To p.FileterField.Count
                'UPGRADE_WARNING: Couldn't resolve default property of object p.FileterField.Item().FIELDTYPE.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ftmap = MapFT(m, p.FileterField.Item(i).FieldType.ID.ToString, tid)
                GenerateFilterControls(panel, p.FileterField.Item(i), ftmap, pos, SaveFields, LoadFields, COLUMN, MINPOS, code, decl, CheckFields)
            Next






            code = code & vbCrLf & "private sub " & panel.Name & "Init()"
            code = code & vbCrLf & "OnInit = true"
            code = code & vbCrLf & "dim iii as long ' for combo only"
            '      code = code & vbCrLf & "if item.CanChange then"
            '      code = code & vbCrLf & "  panel." & p.name & "enabled = true"
            '      code = code & vbCrLf & "else"
            '      code = code & vbCrLf & "  panel." & p.name & "enabled = false"
            '      code = code & vbCrLf & "end if"
            code = code & vbCrLf & LoadFields
            code = code & vbCrLf & "OnInit = false"
            code = code & vbCrLf & "end sub"





            '      code = code & vbCrLf & " Public sub OptimalSize(x As Single, y as single)"
            '      code = code & vbCrLf & "   panel." & p.name & "OptimalSize x, y"
            '      code = code & vbCrLf & "   x=x + panel." & p.name & "left"
            '      code = code & vbCrLf & "   y=y + panel." & p.name & "top"
            '      code = code & vbCrLf & " End sub"
            '      code = code & vbCrLf & " "
            '      code = code & vbCrLf & " "
            '      code = code & vbCrLf & " Public Function OptimalY() As Single"
            '      code = code & vbCrLf & "   Dim x As Single, y As Single"
            '      code = code & vbCrLf & "   panel." & p.name & "OptimalSize x, y"
            '      code = code & vbCrLf & "   OptimalY = y"
            '      code = code & vbCrLf & " End Function"
            '
            '
            '      code = code & vbCrLf & " Public sub Customize()"
            '      code = code & vbCrLf & "   panel." & p.name & "Customize"
            '      code = code & vbCrLf & " End sub"
            '
            '      code = code & vbCrLf & " Public property get PanelCustomisationString() as string"
            '      code = code & vbCrLf & "   PanelCustomisationString =panel." & p.name & "PanelCustomisationString"
            '      code = code & vbCrLf & " End property"
            '
            '      code = code & vbCrLf & " Public property Let PanelCustomisationString(s as string)"
            '      code = code & vbCrLf & "   panel." & p.name & "PanelCustomisationString = s"
            '      code = code & vbCrLf & " End property"
            '
            '
            '      code = code & vbCrLf & " Public property get Enabled() as boolean"
            '      code = code & vbCrLf & "   Enabled =panel." & p.name & "Enabled"
            '      code = code & vbCrLf & " End property"
            '
            '      code = code & vbCrLf & " Public property Let Enabled(byval v as boolean)"
            '      code = code & vbCrLf & "   panel." & p.name & "Enabled = v"
            '      code = code & vbCrLf & " End property"
            '


        Next


        SaveModule("frm" & fltr.Filters.Item(1).Name, "form", decl, code)

        Exit Sub
bye:

        MsgBox(Err.Description, MsgBoxStyle.Critical)
        'Stop
        'Resume
    End Sub

    Private Function UnloadList(ByRef epc As MTZwp.MTZwp.EntryPoints_col) As String
        Dim ep As MTZwp.MTZwp.EntryPoints
        Dim i As Integer
        Dim ss As String
        For i = 1 To epc.Count
            ep = epc.Item(i)
            If ep.ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Nicego_ne_delat_ Then

            End If
            If ep.ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Otkrit__dokument Then


            End If
            If ep.ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Otkrit__gurnal Then
                If Not ep.Journal Is Nothing Then
                    ss = ss & vbCrLf & "unload  jf" & ep.Name & ""
                    ss = ss & vbCrLf & "set  jf" & ep.Name & " = nothing"
                End If
            End If
            If ep.ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Otkrit__otcet Then

                If Not ep.Report Is Nothing Then
                    ss = ss & vbCrLf & "set  rpt" & ep.Name & " = nothing"
                End If

            End If
            If ep.ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Zapustit__ARM Then
            End If

            ss = ss & vbCrLf & UnloadList(ep.EntryPoints)
        Next
        UnloadList = ss
    End Function


    'UPGRADE_NOTE: module was upgraded to module_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub MakeMenuCode(ByRef module_Renamed As LATIRGenerator.ModuleHolder, ByRef ep As MTZwp.MTZwp.EntryPoints)
        Dim desc As String
        Dim code As String
        Dim fltr As MTZFltr.MTZFltr.Application

        On Error GoTo bye


        '  ep.TheExtention
        '  ep.Document
        '  ep.Journal
        '  ep.Method
        '  ep.TheFilter
        '  ep.arm
        '
        If ep.ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Nicego_ne_delat_ Then
            code = ""
            desc = ""
        End If
        If ep.ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Otkrit__dokument Then

            If Not ep.Document Is Nothing Then
                code = code & vbCrLf & "private sub " & ep.Name & "_Click()"
                code = code & vbCrLf & " Dim o As Object"
                'UPGRADE_WARNING: Couldn't resolve default property of object ep.Document.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                code = code & vbCrLf & "  Set o = Manager.GetInstanceObject(""" & ep.Document.ID.ToString & """)"
                code = code & vbCrLf & "  If IsDocDenied(o) Then"
                code = code & vbCrLf & "    MsgBox ""Не разрешен доступ к документам такого типа"""
                code = code & vbCrLf & "    Exit Sub"
                code = code & vbCrLf & "  End If"
                code = code & vbCrLf & ""
                code = code & vbCrLf & "  Dim g  As Object"
                code = code & vbCrLf & "  Set g = Manager.GetInstanceGUI(o.ID)"
                code = code & vbCrLf & "  If Not g Is Nothing Then"
                code = code & vbCrLf & "    g.Show GetDocumentMode(o), o, False"
                code = code & vbCrLf & "  End If"
                code = code & vbCrLf & "end sub "
            ElseIf Not CType(ep.ObjectType, MTZMetaModel.MTZMetaModel.OBJECTTYPE) Is Nothing Then
                code = code & vbCrLf & "private sub " & ep.Name & "_Click()"
                code = code & vbCrLf & " Dim o As Object"
                code = code & vbCrLf & " Dim rs  As ADODB.Recordset"
                code = code & vbCrLf & " Dim ID as string"
                'UPGRADE_WARNING: Couldn't resolve default property of object ctype(ep.ObjectType,mtzmetamodel.mtzmetamodel.objecttype).name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                code = code & vbCrLf & "  Set rs = Manager.ListInstances("""",""" & CType(ep.ObjectType, MTZMetaModel.MTZMetaModel.OBJECTTYPE).Name & """)"
                code = code & vbCrLf & "  if not  rs.eof then"
                code = code & vbCrLf & "    id =rs!Instanceid "
                code = code & vbCrLf & "  else"
                code = code & vbCrLf & "    id =createguid2"
                'UPGRADE_WARNING: Couldn't resolve default property of object ctype(ep.ObjectType,mtzmetamodel.mtzmetamodel.objecttype).the_comment. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object ctype(ep.ObjectType,mtzmetamodel.mtzmetamodel.objecttype).name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                code = code & vbCrLf & "    Manager.NewInstance id, """ & CType(ep.ObjectType, MTZMetaModel.MTZMetaModel.OBJECTTYPE).Name & """, """ & CType(ep.ObjectType, MTZMetaModel.MTZMetaModel.OBJECTTYPE).the_Comment & """ "
                code = code & vbCrLf & "  End If"
                code = code & vbCrLf & "    Set o = Manager.GetInstanceObject( id)"
                code = code & vbCrLf & "    If IsDocDenied(o) Then"
                code = code & vbCrLf & "      MsgBox ""Не разрешен доступ к документам такого типа"""
                code = code & vbCrLf & "      Exit Sub"
                code = code & vbCrLf & "    End If"
                code = code & vbCrLf & ""
                code = code & vbCrLf & "    Dim g  As Object"
                code = code & vbCrLf & "    Set g = Manager.GetInstanceGUI(o.ID)"
                code = code & vbCrLf & "    If Not g Is Nothing Then"
                code = code & vbCrLf & "      g.Show GetDocumentMode(o), o, False"
                code = code & vbCrLf & "    End If"

                code = code & vbCrLf & "  set rs = nothing"
                code = code & vbCrLf & "end sub "
            End If

        End If
        Dim rowsrc As String
        Dim jrnl As MTZJrnl.MTZJrnl.Application
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim wp2 As MTZwp.MTZwp.Application
        Dim iii As Integer
        'UPGRADE_NOTE: pv was upgraded to pv_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim pv_Renamed As MTZMetaModel.MTZMetaModel.PARTVIEW
        If ep.ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Otkrit__gurnal Then
            If Not ep.Journal Is Nothing Then

                desc = "dim withevents jf" & ep.Name & " as frmJournalShow"

                code = code & vbCrLf & "private sub " & ep.Name & "_Click()"



                code = code & vbCrLf & "    Dim journal As Object"
                code = code & vbCrLf & "    On Error Resume Next"
                code = code & vbCrLf & "    If jf" & ep.Name & " Is Nothing Then"
                code = code & vbCrLf & "      Set jf" & ep.Name & " = New frmJournalShow"
                'UPGRADE_WARNING: Couldn't resolve default property of object ep.Journal.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                code = code & vbCrLf & "      Set journal = Manager.GetInstanceObject(""" & ep.Journal.ID.ToString & """)"
                code = code & vbCrLf & "      Manager.LockInstanceObject journal.ID"
                code = code & vbCrLf & "      Set jf" & ep.Name & ".jv.journal = journal"
                code = code & vbCrLf & "      jf" & ep.Name & ".jv.OpenModal = False"
                code = code & vbCrLf & "      jf" & ep.Name & ".Caption = """ & ep.Caption & """"
                code = code & vbCrLf & "      Me.MousePointer = vbHourglass"
                code = code & vbCrLf & "      DoEvents"
                code = code & vbCrLf & "      Dim f As String"


                jrnl = ep.Journal
                rowsrc = ""
                code = code & vbCrLf & "    f=""1=1"""
                If jrnl.JournalSrc.Count = 1 Then
                    If ep.JournalFixedQuery <> "" Then
                        code = code & vbCrLf & "   f=""" & ep.JournalFixedQuery & """ "
                        rowsrc = jrnl.JournalSrc.Item(1).ViewAlias
                        code = code & vbCrLf & "    jf" & ep.Name & ".jv.Filter.Add """ & rowsrc & """, f"
                    End If
                End If


                If Not ep.TheFilter Is Nothing Then
                    fltr = ep.TheFilter
                    code = code & vbCrLf & "    Dim fltr As frm" & MakeValidName(fltr.Filters.Item(1).Name)
                    code = code & vbCrLf & "    set fltr = new frm" & MakeValidName(fltr.Filters.Item(1).Name)
                    code = code & vbCrLf & "    fltr.show vbmodal"
                    code = code & vbCrLf & "    if fltr.ok then "
                    code = code & vbCrLf & "    ' build flter expression "

                    ep.EPFilterLink.Sort = "RowSource"
                    If ep.EPFilterLink.Count > 0 Then
                        rowsrc = ep.EPFilterLink.Item(1).RowSource
                        For iii = 1 To ep.EPFilterLink.Count
                            code = code & vbCrLf & "      if fltr.lbl" & ep.EPFilterLink.Item(iii).FilterField & ".Value=vbChecked then"
                            code = code & vbCrLf & "        f=f &  "" and " & ep.EPFilterLink.Item(iii).TheExpression
                            code = code & vbCrLf & "      end if"
                            If rowsrc <> ep.EPFilterLink.Item(iii).RowSource Then
                                code = code & vbCrLf & "    jf" & ep.Name & ".jv.Filter.Add """ & rowsrc & """, f"
                                code = code & vbCrLf & "    f=""1=1"""
                                rowsrc = ep.EPFilterLink.Item(iii).RowSource
                            End If
                        Next
                    End If
                    If rowsrc <> "" Then
                        code = code & vbCrLf & "    jf" & ep.Name & ".jv.Filter.Add """ & rowsrc & """, f"
                    End If
                    code = code & vbCrLf & "    end if "
                End If

                code = code & vbCrLf & "      jf" & ep.Name & ".jv.Refresh"
                code = code & vbCrLf & "      Me.MousePointer = vbNormal"
                code = code & vbCrLf & "    End If"
                code = code & vbCrLf & "    jf" & ep.Name & ".Show"
                code = code & vbCrLf & "    jf" & ep.Name & ".WindowState = 0"
                code = code & vbCrLf & "    jf" & ep.Name & ".ZOrder 0"
                code = code & vbCrLf & "end sub "



                If Not ep.TheFilter Is Nothing Then
                    fltr = ep.TheFilter
                    code = code & vbCrLf & "private sub   jf" & ep.Name & "_OnFilter( usedefault as boolean)  "
                    code = code & vbCrLf & "    Dim fltr As frm" & MakeValidName(fltr.Filters.Item(1).Name)
                    code = code & vbCrLf & "    Dim f as string"
                    code = code & vbCrLf & "    set fltr = new frm" & MakeValidName(fltr.Filters.Item(1).Name)
                    code = code & vbCrLf & "    fltr.show vbmodal"
                    code = code & vbCrLf & "    if fltr.ok then "
                    code = code & vbCrLf & "    ' build flter expression "

                    ep.EPFilterLink.Sort = "RowSource"

                    code = code & vbCrLf & "    f=""1=1"""
                    If jrnl.JournalSrc.Count = 1 Then
                        If ep.JournalFixedQuery <> "" Then
                            code = code & vbCrLf & "   f=""" & ep.JournalFixedQuery & """ "
                        End If
                    End If

                    rowsrc = ""
                    If ep.EPFilterLink.Count > 0 Then
                        rowsrc = ep.EPFilterLink.Item(1).RowSource
                        For iii = 1 To ep.EPFilterLink.Count
                            code = code & vbCrLf & "      if fltr.lbl" & ep.EPFilterLink.Item(iii).FilterField & ".Value=vbChecked then"
                            code = code & vbCrLf & "        f=f &  "" and " & ep.EPFilterLink.Item(iii).TheExpression
                            code = code & vbCrLf & "      end if"
                            If rowsrc <> ep.EPFilterLink.Item(iii).RowSource Then
                                code = code & vbCrLf & "    jf" & ep.Name & ".jv.Filter.Add """ & rowsrc & """, f"

                                code = code & vbCrLf & "    f=""1=1"""
                                rowsrc = ep.EPFilterLink.Item(iii).RowSource
                            End If
                        Next

                        If rowsrc <> "" Then
                            code = code & vbCrLf & "    jf" & ep.Name & ".jv.Filter.Add """ & rowsrc & """, f"
                        End If
                    End If
                    code = code & vbCrLf & "    end if "
                    code = code & vbCrLf & "    unload fltr "
                    code = code & vbCrLf & "    usedefault = false"
                    code = code & vbCrLf & "end sub "

                    code = code & vbCrLf & "private sub   jf" & ep.Name & "_OnClearFilter()  "
                    jrnl = ep.Journal

                    If jrnl.JournalSrc.Count = 1 Then
                        If ep.JournalFixedQuery <> "" Then
                            code = code & vbCrLf & "   jf" & ep.Name & ".jv.Filter.Add  """ & jrnl.JournalSrc.Item(1).ViewAlias & """,""" & ep.JournalFixedQuery & """ "
                        End If
                    End If
                    code = code & vbCrLf & "end sub "
                End If


                If jrnl.JournalSrc.Count = 1 Then

                    pv_Renamed = m.FindRowObject("PARTVIEW", jrnl.JournalSrc.Item(1).PartView)

                    If Not pv_Renamed Is Nothing Then
                        'UPGRADE_WARNING: Couldn't resolve default property of object pv_Renamed.parent.parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        ot = TypeForStruct(pv_Renamed.Parent.Parent)

                        code = code & vbCrLf & "Private Sub jf" & ep.Name & "_OnAdd(usedefaut As Boolean, Refesh As Boolean)"
                        code = code & vbCrLf & "  Dim objGui  As Object"
                        code = code & vbCrLf & "  Dim o As Object"
                        code = code & vbCrLf & "  Dim ID As String"
                        code = code & vbCrLf & "  ID = CreateGUID2"
                        code = code & vbCrLf & "  Manager.NewInstance ID, """ & ot.Name & """, """ & ot.the_Comment & """ & Now, Site"
                        code = code & vbCrLf & "  Set o = Manager.GetInstanceObject(ID)"
                        code = code & vbCrLf & "  If IsDocDenied(o) Then"
                        code = code & vbCrLf & "    MsgBox ""Не разрешен доступ к документам такого типа"""
                        code = code & vbCrLf & "    Exit Sub"
                        code = code & vbCrLf & "  End If"
                        code = code & vbCrLf & ""
                        code = code & vbCrLf & "  Dim g  As Object"
                        code = code & vbCrLf & "  Set g = Manager.GetInstanceGUI(o.ID)"
                        code = code & vbCrLf & "  If Not g Is Nothing Then"
                        code = code & vbCrLf & "    g.Show GetDocumentMode(o), o, False"
                        code = code & vbCrLf & "  End If"
                        code = code & vbCrLf & "  usedefaut = False"
                        code = code & vbCrLf & "  Refesh = False"
                        code = code & vbCrLf & "End Sub"
                    End If
                End If
            End If
        End If
        If ep.ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Otkrit__otcet Then

            If Not ep.Report Is Nothing Then
                desc = "dim rpt" & ep.Name & " as ReportShow"
            End If

            code = code & vbCrLf & "private sub " & ep.Name & "_Click()"
            code = code & vbCrLf & "If rpt" & ep.Name & " Is Nothing Then Set rpt" & ep.Name & " = New ReportShow"

            If Not ep.TheFilter Is Nothing Then
                fltr = ep.TheFilter
                code = code & vbCrLf & "    Dim fltr As frm" & MakeValidName(fltr.Filters.Item(1).Name)
                code = code & vbCrLf & "    set fltr = new frm" & MakeValidName(fltr.Filters.Item(1).Name)
                code = code & vbCrLf & "    fltr.show vbmodal"
                code = code & vbCrLf & "    if fltr.ok then "
                code = code & vbCrLf & "    ' todo build flter expression "
                code = code & vbCrLf & "    end if "
            End If


            code = code & vbCrLf & "rpt" & ep.Name & ".ReportSource = ""..."""
            code = code & vbCrLf & "rpt" & ep.Name & ".Caption = """ & ep.Caption & """"
            code = code & vbCrLf & "rpt" & ep.Name & ".ReportPath = App.Path & ""\""" & ep.Name & ".rpt"""
            code = code & vbCrLf & "rpt" & ep.Name & ".Run"
            code = code & vbCrLf & "end sub "
        End If
        If ep.ActionType = MTZMetaModel.MTZMetaModel.enumMenuActionType.MenuActionType_Zapustit__ARM Then
            code = code & vbCrLf & "private sub " & ep.Name & "_Click()"
            wp2 = ep.ARM
            code = code & vbCrLf & "ShellExecute 0, ""Open"" & Chr(0), App.Path & ""\..\" & wp2.ID.ToString & "\" & MakeValidName(Left(wp2.WorkPlace.Item(1).Name, 20)) & ".exe"" & Chr(0), ""  usr:"" & UserName & "" pwd:"" & UserPassword & "" APP:"" & Site & Chr(0), 0&, 5"
            code = code & vbCrLf & "Me.WindowState = 1"
            code = code & vbCrLf & "end sub "
        End If
        SaveModule("frmMain", "form", desc, code)

        Exit Sub
bye:
        Stop
        Resume
    End Sub









    Public Sub SaveModule(ByVal name As String, ByRef moduleType As String, ByRef desc As String, ByRef body As String)
        On Error GoTo bye
        'o_module = name
        'o.Project.Modules.Item(o_module).ModuleName = name
        o.Project.Modules.Item((name)).Attributes.Add("Type").Value = moduleType


        o.Block = "'description"
        o.Project.Modules.Item((name)).Blocks.Item((o.Block)).Attributes.Add("Type").Value = "description"
        o.OutNL(desc)

        o.Block = "'codebody"
        o.Project.Modules.Item((name)).Blocks.Item((o.Block)).Attributes.Add("Type").Value = "code"
        o.OutNL(body)

        Exit Sub
bye:

        MsgBox(Err.Description, MsgBoxStyle.Critical)
        'Stop
        'Resume
    End Sub



    'Private Sub CreateFltrCtl(fltr As MTZFltr.MTZFltr.Application)
    '  Const maxCD As Long = 20
    '  Dim i As Long
    '  Dim j As Long
    '  Dim fd As FormData, decl As String, body As String, frm As String
    '  Dim pctl As ControlData, tctl As ControlData
    '  Dim lctl As ControlData, mctl As ControlData, smctl As ControlData
    '  Dim tsClick As String, tsInit As String
    '
    '
    '  On Error GoTo bye
    '  fltr.FilterFieldGroup.Sort = "sequence"
    '  For i = 1 To fltr.FilterFieldGroup.Count
    '      CreateViewPanel fltr, fltr.FilterFieldGroup.Item(i)
    '  Next
    '
    '  o_module = "fctl" & fltr.Filters.Item(1).name
    '  o.Block = "'form"
    '  With o.Project.Modules.Item(o_module).Blocks.Item(o.Block)
    '    .Attributes.Add("Type").value = "controlset"
    '    Set fd = .FormData
    '  End With
    '
    '  decl = "public Item as object"
    '  decl = decl & vbCrLf & "Private TSCustom As MTZ_CUSTOMTAB.TabStripCustomizer"
    '
    '
    '  Set mctl = fd.ControlData.Add()
    '  mctl.name = "mnuCtl"
    '  mctl.ProgId = "VB.Menu"
    '  AddProp mctl, "Caption", "mnuCtl"
    '  AddProp mctl, "Name", mctl.name
    '  AddProp mctl, "Visible", False
    '
    '  Set smctl = mctl.ControlData.Add()
    '  smctl.name = "mnuSetup"
    '  smctl.ProgId = "VB.Menu"
    '  AddProp smctl, "Caption", "Настройка"
    '  AddProp smctl, "Name", smctl.name
    '  AddProp smctl, "Enabled", True
    '  AddProp smctl, "Visible", True
    '
    '  ''''''''''''''''' SUPPORT FOR TAB CUSTOMIZATION '''''''''''''''
    '  body = body & vbCrLf & "Private Sub mnuSetup_Click()"
    '  body = body & vbCrLf & "TSCustom.Setup ts"
    '  body = body & vbCrLf & "End Sub"
    '
    '  body = body & vbCrLf & "Private Sub ts_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)"
    '  body = body & vbCrLf & "  If Button = 2 And Shift = 0 Then"
    '  body = body & vbCrLf & "    PopupMenu mnuCtl"
    '  body = body & vbCrLf & "  End If"
    '  body = body & vbCrLf & "End Sub"
    '
    '
    '  ''''''''''''''''''''''''''''''' make groups ''''''''''''''''''''''''
    '
    '  ' TabStrip
    '  Set tctl = fd.ControlData.Add()
    '  tctl.name = "ts"
    '  AddProp tctl, "Name", "ts"
    '  tctl.ProgId = "mscomctllib.tabstrip"
    '  AddProp tctl, "Top", 0
    '  AddProp tctl, "Left", 0
    '  AddProp tctl, "Width", 100 * Screen.TwipsPerPixelX
    '  AddProp tctl, "Height", 100 * Screen.TwipsPerPixelY
    '
    '
    '
    '  fltr.Filters.Sort = "sequence"
    '  For i = 1 To fltr.FilterFieldGroup.Count
    '        ' panel
    '        Set pctl = fd.ControlData.Add()
    '        pctl.name = "pnl" & fltr.FilterFieldGroup.Item(i).name
    '        pctl.ProgId = o.Project.Attributes.Item("ProjectName").value & ".vpn" & fltr.Filters.Item(1).name & "_" & fltr.FilterFieldGroup.Item(i).name
    '        AddProp pctl, "Name", pctl.name
    '        AddProp pctl, "visible", False
    '        AddProp pctl, "Top", 100 * Screen.TwipsPerPixelX * (i \ 5)
    '        AddProp pctl, "Left", 100 * Screen.TwipsPerPixelX * (i Mod 5)
    '        AddProp pctl, "Width", 100 * Screen.TwipsPerPixelX
    '        AddProp pctl, "Height", 100 * Screen.TwipsPerPixelY
    '
    '        If tsInit = "" Then
    '          tsInit = tsInit & vbCrLf & "ts.Tabs.Item(1).Caption = """ & NoLF(fltr.FilterFieldGroup.Item(i).Caption) & """"
    '          tsInit = tsInit & vbCrLf & "ts.Tabs.Item(1).key = """ & fltr.FilterFieldGroup.Item(i).name & """"
    '        Else
    '          tsInit = tsInit & vbCrLf & "call ts.Tabs.Add(, """ & fltr.FilterFieldGroup.Item(i).name & """, """ & NoLF(fltr.FilterFieldGroup.Item(i).Caption) & """)"
    '        End If
    '
    '        tsInit = tsInit & vbCrLf & pctl.name & ".OnInit item"
    '
    '
    '        If tsClick = "" Then
    '          tsClick = tsClick & vbCrLf & "   Select Case ts.SelectedItem.Key"
    '        End If
    '
    '        tsClick = "  " & pctl.name & ".Visible = False" & vbCrLf & tsClick
    '        tsClick = tsClick & vbCrLf & "   Case """ & fltr.FilterFieldGroup.Item(i).name & """"
    '        tsClick = tsClick & vbCrLf & "     With " & pctl.name
    '        tsClick = tsClick & vbCrLf & "     .Top = ts.ClientTop"
    '        tsClick = tsClick & vbCrLf & "     .Left = ts.ClientLeft"
    '        tsClick = tsClick & vbCrLf & "     .Width = ts.ClientWidth"
    '        tsClick = tsClick & vbCrLf & "     .Height = ts.ClientHeight"
    '        tsClick = tsClick & vbCrLf & "     .Visible = True"
    '        tsClick = tsClick & vbCrLf & "     .ZOrder 0"
    '        tsClick = tsClick & vbCrLf & "     " & pctl.name & ".OnClick item"
    '        tsClick = tsClick & vbCrLf & "     End With"
    '      Next
    '
    '  If tsClick <> "" Then
    '    tsClick = tsClick & vbCrLf & "     End select"
    '    body = body & vbCrLf & "private sub ts_click()"
    '    body = body & vbCrLf & "  on error resume next"
    '
    '    body = body & vbCrLf & tsClick
    '    body = body & vbCrLf & "end sub"
    '  End If
    '
    '  body = body & vbCrLf & "public sub Init( ObjItem as object)"
    '  body = body & vbCrLf & "  on error resume next"
    '  body = body & vbCrLf & " set Item = objItem"
    '  body = body & vbCrLf & "  Dim ff As Long, buf As String"
    '  body = body & vbCrLf & tsInit
    '  body = body & vbCrLf & "  Set TSCustom = New MTZ_CUSTOMTAB.TabStripCustomizer"
    '  body = body & vbCrLf & "  TSCustom.Init ts, """ & fltr.Filters.Item(1).name & """, ""fctl" & fltr.Filters.Item(1).name & """"
    '  body = body & vbCrLf & "  TSCustom.SetupFromRegistry ts"
    '  body = body & vbCrLf & " ts_click"
    '  body = body & vbCrLf & "end sub"
    '
    '  body = body & vbCrLf & "Private Sub UserControl_Terminate()"
    '  body = body & vbCrLf & "  on error resume next"
    '  body = body & vbCrLf & "  set item=nothing"
    '  body = body & vbCrLf & "  Set TSCustom = Nothing"
    '  For i = 1 To fltr.FilterFieldGroup.Count
    '     body = body & vbCrLf & " pnl" & fltr.FilterFieldGroup.Item(i).name & ".CloseClass"
    '  Next
    '  body = body & vbCrLf & "End Sub"
    '
    '
    '  body = body & vbCrLf & "public function IsChanged() as boolean"
    '  body = body & vbCrLf & "  dim m_IsChanged as boolean"
    '  body = body & vbCrLf & "  on error resume next"
    '  For i = 1 To fltr.FilterFieldGroup.Count
    '      body = body & vbCrLf & "m_IsChanged = m_IsChanged or pnl" & fltr.FilterFieldGroup.Item(i).name & ".IsChanged"
    '  Next
    '  body = body & vbCrLf & "  IsChanged = m_IsChanged"
    '  body = body & vbCrLf & "end function"
    '
    '  body = body & vbCrLf & "private sub UserControl_Resize()"
    '  body = body & vbCrLf & " on error resume next"
    '  body = body & vbCrLf & "ts.Top = 0"
    '  body = body & vbCrLf & "ts.Left = 0"
    '  body = body & vbCrLf & "ts.Width = usercontrol.Width"
    '  body = body & vbCrLf & "ts.Height = usercontrol.Height"
    '  body = body & vbCrLf & "ts_Click"
    '  body = body & vbCrLf & "end sub"
    '
    '
    '  SaveModule "fctl" & fltr.Filters.Item(1).name, "control", decl, body
    '
    '  Set fd = Nothing
    '  Exit Sub
    'bye:
    '  MsgBox Err.Description, vbCritical
    '  'Stop
    '  'Resume
    'End Sub


    Private Sub CreateViewPanel(ByRef fltr As MTZFltr.MTZFltr.Application, ByRef root As MTZFltr.MTZFltr.FilterFieldGroup)
        Const maxCD As Integer = 20
        Dim i As Integer
        Dim fd As LATIRGenerator.FormData
        Dim body, decl, frm As String
        'UPGRADE_NOTE: Interface was upgraded to Interface_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim Interface_Renamed, childInterface As String
        Dim Child, parent As MTZMetaModel.MTZMetaModel.PART
        Dim pctl, tctl As LATIRGenerator.ControlData
        Dim mctl, lctl, rctl, smctl As LATIRGenerator.ControlData
        Dim tsClick, tsInit As String
        Dim fnd1, fnd2 As String
        Dim OnSave, IsChanged As String

        On Error GoTo bye

        Dim o_module As String
        o_module = "vpn" & fltr.Filters.Item(1).Name & "_" & root.Name
        o.Block = "'form"

        With o.Project.Modules.Item((o_module)).Blocks.Item((o.Block))
            .Attributes.Add("Type").Value = "controlset"
            fd = .FormData
        End With


        decl = "public Item as object"


        pctl = fd.ControlData.Add()
        pctl.Name = "pnl" & root.Name
        pctl.PROGID = "VB.Frame"
        AddProp(pctl, "Name", pctl.Name)
        AddProp(pctl, "visible", CStr(True))
        AddProp(pctl, "Top", CStr(0 * VB6.TwipsPerPixelX))
        AddProp(pctl, "Left", CStr(0 * VB6.TwipsPerPixelX))
        AddProp(pctl, "Width", CStr(600 * VB6.TwipsPerPixelX))
        AddProp(pctl, "Height", CStr(400 * VB6.TwipsPerPixelY))

        AddProp(pctl, "BorderStyle", CStr(0))
        MakeSinglePanel((o.Project.Attributes.Item("ProjectName").Value), pctl, fltr, root, body, tsClick, tsInit)

        IsChanged = IsChanged & vbCrLf & " m_isChanged = m_isChanged or item.Changed"

        OnSave = OnSave & vbCrLf & "  edit" & root.Name & ".Save"
        OnSave = OnSave & vbCrLf & "if edit" & root.Name & ".item.Changed then"
        OnSave = OnSave & vbCrLf & "  edit" & root.Name & ".item.Save"
        OnSave = OnSave & vbCrLf & "end if"


        body = body & vbCrLf & "public sub OnInit(aItem as object)"
        body = body & vbCrLf & " on error resume next"
        body = body & vbCrLf & " set Item =aItem"
        body = body & vbCrLf & tsInit
        body = body & vbCrLf & "end sub"

        body = body & vbCrLf & "private sub OnTabClick()"
        body = body & vbCrLf & tsClick
        body = body & vbCrLf & "end sub"

        body = body & vbCrLf & "public sub OnClick(aItem as object)"
        body = body & vbCrLf & "  on error resume next"
        body = body & vbCrLf & "  set Item =aItem"
        body = body & vbCrLf & "  OnTabClick"
        body = body & vbCrLf & "end sub"


        body = body & vbCrLf & "public function IsChanged() as boolean"
        body = body & vbCrLf & "  dim m_IsChanged as boolean"
        body = body & vbCrLf & "  on error resume next"
        body = body & vbCrLf & "  " & IsChanged
        body = body & vbCrLf & "  IsChanged = m_IsChanged"
        body = body & vbCrLf & "end function"

        body = body & vbCrLf & "private sub UserControl_Resize()"
        body = body & vbCrLf & "  On Error Resume Next"
        body = body & vbCrLf & "  " & pctl.Name & ".Move 0, 0, UserControl.Width, UserControl.Height"
        body = body & vbCrLf & "  OnTabClick"
        body = body & vbCrLf & "end sub"



        body = body & vbCrLf & "public sub CloseClass()"
        body = body & vbCrLf & "  On Error Resume Next"
        body = body & vbCrLf & "  set item = nothing"
        If fnd1 <> "" Then
            body = body & vbCrLf & "  set " & fnd1 & " = nothing"
        End If
        If fnd2 <> "" Then
            body = body & vbCrLf & "  set " & fnd2 & " = nothing"
        End If

        body = body & vbCrLf & "end sub"


        body = body & vbCrLf & "private sub UserControl_Terminate()"
        body = body & vbCrLf & "  On Error Resume Next"
        body = body & vbCrLf & "  CloseClass"
        body = body & vbCrLf & "end sub"

bye:

        SaveModule(o_module, "control", decl, body)

    End Sub


    ' same as MAPFT, but return fieldtypemap object
    Private Function MapFTObj(ByVal TypeID As String) As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        On Error GoTo bye

        Dim i, s As Object
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        ft = m.FIELDTYPE.Item(TypeID)
        If ft Is Nothing Then Exit Function
        For i = 1 To ft.FIELDTYPEMAP.Count
            'UPGRADE_WARNING: Couldn't resolve default property of object ft.FIELDTYPEMAP.Item(i).Target.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If ft.FIELDTYPEMAP.Item(i).Target.ID.ToString = tid Then
                MapFTObj = ft.FIELDTYPEMAP.Item(i)
                Exit For
            End If
        Next
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Stop
        'Resume
    End Function


    Private Sub CreateFilterForm(ByRef ot As MTZFltr.MTZFltr.Application)
        Const maxCD As Integer = 20
        Dim i As Integer
        Dim fd As LATIRGenerator.FormData
        Dim body, decl, frm As String
        'UPGRADE_NOTE: Interface was upgraded to Interface_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim Interface_Renamed, childInterface As String
        Dim Child, parent As MTZMetaModel.MTZMetaModel.PART
        Dim pctl, tctl As LATIRGenerator.ControlData
        Dim mctl, lctl, rctl, smctl As LATIRGenerator.ControlData
        Dim tsClick, tsInit As String
        Dim fltr As MTZFltr.MTZFltr.Application

        fltr = ot
        On Error GoTo bye
        Dim o_module As String
        o_module = "frm" & ot.Filters.Item(1).Name
        o.Block = "'form"
        With o.Project.Modules.Item((o_module)).Blocks.Item((o.Block))
            .Attributes.Add("Type").Value = "form"
            fd = .FormData
        End With

        AddFProp(fd, "tag", "Card.ICO")
        AddFProp(fd, "caption", NoLF(ot.Filters.Item(1).TheCaption))
        AddFProp(fd, "ShowInTaskBar", CStr(True))


        '  ' TabStrip
        '  Set tctl = fd.ControlData.Add()
        '  tctl.name = "ctl"
        '  AddProp tctl, "Name", tctl.name
        '  tctl.ProgId = o.Project.Attributes("ProjectName").value & ".fctl" & ot.Filters.Item(1).name
        '  AddProp tctl, "Top", 0
        '  AddProp tctl, "Left", 0
        '  AddProp tctl, "Width", 100 * Screen.TwipsPerPixelX
        '  AddProp tctl, "Height", 100 * Screen.TwipsPerPixelY


        Dim btn As LATIRGenerator.ControlData

        btn = fd.ControlData.Add()
        btn.PROGID = "VB.CommandButton"
        btn.Name = "cmdOK"
        AddProp(btn, "Name", btn.Name)
        AddProp(btn, "Caption", "OK")
        AddProp(btn, "Tag", "")
        AddProp(btn, "ToolTipText", "Применить фильтр")
        AddProp(btn, "UseMaskColor", CStr(True))
        AddProp(btn, "Height", CStr(22 * VB6.TwipsPerPixelY))
        AddProp(btn, "Width", CStr(50 * VB6.TwipsPerPixelX))
        AddProp(btn, "Top", CStr(0 * VB6.TwipsPerPixelY))
        AddProp(btn, "Left", CStr(0 * VB6.TwipsPerPixelY))


        body = body & vbCrLf & "Private Sub cmdOK_Click()"
        body = body & vbCrLf & "    on error resume next "
        body = body & vbCrLf & "    OK = true"
        body = body & vbCrLf & "    me.hide"
        body = body & vbCrLf & "End Sub"

        btn = fd.ControlData.Add()
        btn.PROGID = "VB.CommandButton"
        btn.Name = "cmdCancel"
        AddProp(btn, "Name", btn.Name)
        AddProp(btn, "Caption", "Отмена")
        AddProp(btn, "Tag", "")
        AddProp(btn, "ToolTipText", "Отказ от задания фильтра")
        AddProp(btn, "UseMaskColor", CStr(True))
        AddProp(btn, "Height", CStr(22 * VB6.TwipsPerPixelY))
        AddProp(btn, "Width", CStr(50 * VB6.TwipsPerPixelX))
        AddProp(btn, "Top", CStr(0 * VB6.TwipsPerPixelY))
        AddProp(btn, "Left", CStr(0 * VB6.TwipsPerPixelY))


        body = body & vbCrLf & "Private Sub cmdCancel_Click()"
        body = body & vbCrLf & "    on error resume next "
        body = body & vbCrLf & "    OK = false"
        body = body & vbCrLf & "    me.hide"
        body = body & vbCrLf & "End Sub"


        decl = "Public Item as object"
        decl = decl & vbCrLf & "public OK as boolean"
        decl = decl & vbCrLf & "private OnInit as boolean"
        decl = decl & vbCrLf & "public event Changed"

        body = body & vbCrLf & "public sub Init( ObjItem as object)"
        body = body & vbCrLf & " set Item = objItem"
        body = body & vbCrLf & " if Item is nothing then set Item =Myuser.application"
        body = body & vbCrLf & " TInit"
        body = body & vbCrLf & "end sub"



        body = body & vbCrLf & "Private Sub Form_Load()"
        body = body & vbCrLf & "  on error resume next"
        body = body & vbCrLf & "  Dim ff As Long, buf As String"
        body = body & vbCrLf & "  LoadFromSkin me"
        body = body & vbCrLf & "  ts.Move 0,0,Me.ScaleWidth,Me.ScaleHeight-cmdOK.height"
        body = body & vbCrLf & "  cmdOK.Move Me.ScaleWidth - 110 * screen.twipsperpixelx,Me.ScaleHeight-cmdOK.height,cmdok.width,cmdok.height"
        body = body & vbCrLf & "  cmdCancel.Move Me.ScaleWidth - 55 * screen.twipsperpixelx,Me.ScaleHeight-cmdOK.height,cmdcancel.width,cmdok.height"
        body = body & vbCrLf & "  if Item is nothing then Init Myuser.Application"
        body = body & vbCrLf & "End Sub"



        body = body & vbCrLf & "Private Sub Form_Unload(Cancel As Integer)"
        body = body & vbCrLf & "  on error resume next"
        body = body & vbCrLf & "  set item=nothing"
        body = body & vbCrLf & "  Set TSCustom = Nothing"
        body = body & vbCrLf & "  SaveToSkin me"
        body = body & vbCrLf & "  exit sub"
        body = body & vbCrLf & "bye:"
        body = body & vbCrLf & "  msgbox err.description,vbokonly"
        body = body & vbCrLf & "  cancel = -1"
        body = body & vbCrLf & "End Sub"

        body = body & vbCrLf & "private sub Form_Resize()"
        body = body & vbCrLf & " if me.windowstate =1 then exit sub"
        body = body & vbCrLf & " on error resume next"
        body = body & vbCrLf & "  ts.Move 0,0,Me.ScaleWidth,Me.ScaleHeight-cmdOK.height"
        body = body & vbCrLf & "  cmdOK.Move Me.ScaleWidth - 110 * screen.twipsperpixelx,Me.ScaleHeight-cmdOK.height,cmdok.width,cmdok.height"
        body = body & vbCrLf & "  cmdCancel.Move Me.ScaleWidth - 55 * screen.twipsperpixelx,Me.ScaleHeight-cmdOK.height,cmdcancel.width,cmdok.height"
        body = body & vbCrLf & "  ts_click"
        body = body & vbCrLf & "end sub"



        decl = decl & vbCrLf & "Private TSCustom As MTZ_CUSTOMTAB.TabStripCustomizer"


        mctl = fd.ControlData.Add()
        mctl.Name = "mnuCtl"
        mctl.PROGID = "VB.Menu"
        AddProp(mctl, "Caption", "mnuCtl")
        AddProp(mctl, "Name", mctl.Name)
        AddProp(mctl, "Visible", CStr(False))

        smctl = mctl.ControlData.Add()
        smctl.Name = "mnuSetup"
        smctl.PROGID = "VB.Menu"
        AddProp(smctl, "Caption", "Настройка")
        AddProp(smctl, "Name", smctl.Name)
        AddProp(smctl, "Enabled", CStr(True))
        AddProp(smctl, "Visible", CStr(True))

        ''''''''''''''''' SUPPORT FOR TAB CUSTOMIZATION '''''''''''''''
        body = body & vbCrLf & "Private Sub mnuSetup_Click()"
        body = body & vbCrLf & "TSCustom.Setup ts"
        body = body & vbCrLf & "End Sub"

        body = body & vbCrLf & "Private Sub ts_MouseUp(Button As Integer, Shift As Integer, X As Single, Y As Single)"
        body = body & vbCrLf & "  If Button = 2 And Shift = 0 Then"
        body = body & vbCrLf & "    PopupMenu mnuCtl"
        body = body & vbCrLf & "  End If"
        body = body & vbCrLf & "End Sub"


        ''''''''''''''''''''''''''''''' make groups ''''''''''''''''''''''''

        ' TabStrip
        tctl = fd.ControlData.Add()
        tctl.Name = "ts"
        AddProp(tctl, "Name", "ts")
        tctl.PROGID = "mscomctllib.tabstrip"
        AddProp(tctl, "Top", CStr(0))
        AddProp(tctl, "Left", CStr(0))
        AddProp(tctl, "Width", CStr(100 * VB6.TwipsPerPixelX))
        AddProp(tctl, "Height", CStr(100 * VB6.TwipsPerPixelY))



        fltr.Filters.Sort = "sequence"
        Dim pctlName As String
        For i = 1 To fltr.FilterFieldGroup.Count

            ' panel
            '        Set pctl = fd.ControlData.Add()
            pctlName = "panel" & fltr.FilterFieldGroup.Item(i).Name
            '        pctl.ProgId = o.Project.Attributes.Item("ProjectName").value & ".vpn" & fltr.Filters.Item(1).name & "_" & fltr.FilterFieldGroup.Item(i).name
            '        AddProp pctl, "Name", pctl.name
            '        AddProp pctl, "visible", False
            '        AddProp pctl, "Top", 100 * Screen.TwipsPerPixelX * (i \ 5)
            '        AddProp pctl, "Left", 100 * Screen.TwipsPerPixelX * (i Mod 5)
            '        AddProp pctl, "Width", 100 * Screen.TwipsPerPixelX
            '        AddProp pctl, "Height", 100 * Screen.TwipsPerPixelY

            If tsInit = "" Then
                tsInit = tsInit & vbCrLf & "ts.Tabs.Item(1).Caption = """ & NoLF(fltr.FilterFieldGroup.Item(i).Caption) & """"
                tsInit = tsInit & vbCrLf & "ts.Tabs.Item(1).key = """ & fltr.FilterFieldGroup.Item(i).Name & """"
            Else
                tsInit = tsInit & vbCrLf & "call ts.Tabs.Add(, """ & fltr.FilterFieldGroup.Item(i).Name & """, """ & NoLF(fltr.FilterFieldGroup.Item(i).Caption) & """)"
            End If

            tsInit = tsInit & vbCrLf & pctlName & "Init"


            If tsClick = "" Then
                tsClick = tsClick & vbCrLf & "   Select Case ts.SelectedItem.Key"
            End If

            tsClick = "  " & pctlName & ".Visible = False" & vbCrLf & tsClick
            tsClick = tsClick & vbCrLf & "   Case """ & fltr.FilterFieldGroup.Item(i).Name & """"
            tsClick = tsClick & vbCrLf & "     With " & pctlName
            tsClick = tsClick & vbCrLf & "     .Top = ts.ClientTop"
            tsClick = tsClick & vbCrLf & "     .Left = ts.ClientLeft"
            tsClick = tsClick & vbCrLf & "     .Width = ts.ClientWidth"
            tsClick = tsClick & vbCrLf & "     .Height = ts.ClientHeight"
            tsClick = tsClick & vbCrLf & "     .Visible = True"
            tsClick = tsClick & vbCrLf & "     .ZOrder 0"
            'tsClick = tsClick & vbCrLf & "     " & pctlName & "Init"
            tsClick = tsClick & vbCrLf & "     End With"
        Next

        If tsClick <> "" Then
            tsClick = tsClick & vbCrLf & "     End select"
            body = body & vbCrLf & "private sub ts_click()"
            body = body & vbCrLf & "  on error resume next"

            body = body & vbCrLf & tsClick
            body = body & vbCrLf & "end sub"
        End If

        body = body & vbCrLf & "private sub TInit()"
        body = body & vbCrLf & "  on error resume next"
        body = body & vbCrLf & "  Dim ff As Long, buf As String"
        body = body & vbCrLf & tsInit
        body = body & vbCrLf & "  Set TSCustom = New MTZ_CUSTOMTAB.TabStripCustomizer"
        body = body & vbCrLf & "  TSCustom.Init ts, """ & fltr.Filters.Item(1).Name & """, ""fctl" & fltr.Filters.Item(1).Name & """"
        body = body & vbCrLf & "  TSCustom.SetupFromRegistry ts"
        body = body & vbCrLf & " ts_click"
        body = body & vbCrLf & "end sub"



        '  body = body & vbCrLf & "public function IsChanged() as boolean"
        '  body = body & vbCrLf & "  dim m_IsChanged as boolean"
        '  body = body & vbCrLf & "  on error resume next"
        '  For i = 1 To fltr.FilterFieldGroup.Count
        '      body = body & vbCrLf & "m_IsChanged = m_IsChanged or pnl" & fltr.FilterFieldGroup.Item(i).name & ".IsChanged"
        '  Next
        '  body = body & vbCrLf & "  IsChanged = m_IsChanged"
        '  body = body & vbCrLf & "end function"
        '
        '  body = body & vbCrLf & "private sub UserControl_Resize()"
        '  body = body & vbCrLf & " on error resume next"
        '  body = body & vbCrLf & "ts.Top = 0"
        '  body = body & vbCrLf & "ts.Left = 0"
        '  body = body & vbCrLf & "ts.Width = usercontrol.Width"
        '  body = body & vbCrLf & "ts.Height = usercontrol.Height"
        '  body = body & vbCrLf & "ts_Click"
        '  body = body & vbCrLf & "end sub"



        SaveModule("frm" & ot.Filters.Item(1).Name, "form", decl, body)


        CreateFilterPanels(fd, ot)

        'UPGRADE_NOTE: Object fd may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        fd = Nothing
        Exit Sub
bye:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
        Stop
        Resume
    End Sub


    Private Sub MakeUtil()
        Dim i, mode As Integer
        Dim body, decl, frm As String
        On Error GoTo bye

        decl = ""
        body = ""


        body = body & vbCrLf & "public sub LoadFromSkin( frm as form )"
        body = body & vbCrLf & "  on error resume next"
        body = body & vbCrLf & "  Dim s As String, arr() as string"
        body = body & vbCrLf & "  s = GetSetting(""MTZ"", ""CONFIG"", ""LAYOUTS"", """")"
        body = body & vbCrLf & "  If s = """" Then Exit Sub"
        body = body & vbCrLf & "  Dim ff As Long, buf As String"
        body = body & vbCrLf & "  ff = FreeFile"
        body = body & vbCrLf & "  Open s & frm.name For Input As #ff"
        body = body & vbCrLf & "  buf = Input(LOF(ff), ff)"
        body = body & vbCrLf & "  Close #ff"
        body = body & vbCrLf & "  arr = split(buf, vbcrlf)"
        body = body & vbCrLf & "  Dim arr2() As String, i as long"
        body = body & vbCrLf & "For i = 0 To UBound(arr)"
        body = body & vbCrLf & "  arr2 = Split(arr(i), "":"")"
        body = body & vbCrLf & "  Select Case arr2(0)"
        body = body & vbCrLf & "  case ""FormTag"""
        body = body & vbCrLf & "    frm.Tag = arr2(1)"
        body = body & vbCrLf & "  Case ""FormTop"""
        body = body & vbCrLf & "    frm.Top = arr2(1)"
        body = body & vbCrLf & "  Case ""FormLeft"""
        body = body & vbCrLf & "    frm.left = arr2(1)"
        body = body & vbCrLf & "  Case ""FormWidth"""
        body = body & vbCrLf & "    frm.Width = arr2(1)"
        body = body & vbCrLf & "  Case ""FormHeight"""
        body = body & vbCrLf & "    frm.Height = arr2(1)"
        body = body & vbCrLf & "  Case Else"
        body = body & vbCrLf & "    frm.Controls(arr2(0)).tag = Val(arr2(1))"
        body = body & vbCrLf & "  End Select"
        body = body & vbCrLf & "Next"
        body = body & vbCrLf & "  s ="""" "
        body = body & vbCrLf & "  s = GetSetting(""MTZ"", ""CONFIG"", ""IMAGEPATH"", """")"
        body = body & vbCrLf & "  If s = """" Then Exit Sub"
        body = body & vbCrLf & "  set frm.icon = LoadPicture(s & frm.tag)"
        body = body & vbCrLf & "end sub"
        body = body & vbCrLf & ""

        body = body & vbCrLf & "public sub SaveToSkin( frm as form )"
        body = body & vbCrLf & "  on error resume next"
        body = body & vbCrLf & "  Dim s As String, buf as string"
        body = body & vbCrLf & "  s = GetSetting(""MTZ"", ""CONFIG"", ""LAYOUTS"", """")"
        body = body & vbCrLf & "  If s = """" Then Exit Sub"
        body = body & vbCrLf & "  frm.WindowState =0 "
        body = body & vbCrLf & "  Dim ff As Long"
        body = body & vbCrLf & "  ff = FreeFile"
        body = body & vbCrLf & "  kill s & frm.name"
        body = body & vbCrLf & "  Open s & frm.name For output As #ff"
        body = body & vbCrLf & "  buf =  ""FormTag:"" & frm.Tag "
        body = body & vbCrLf & "  buf = buf & vbcrlf & ""FormTop:"" & frm.Top "
        body = body & vbCrLf & "  buf = buf & vbCrLf & ""FormLeft:"" & frm.Left"
        body = body & vbCrLf & "  buf = buf & vbCrLf & ""FormWidth:"" & frm.Width"
        body = body & vbCrLf & "  buf = buf & vbCrLf & ""FormHeight:"" & frm.Height"


        body = body & vbCrLf & "  print #ff, buf"
        body = body & vbCrLf & "  Close #ff"
        body = body & vbCrLf & "end sub"
        body = body & vbCrLf & ""


        Dim o_module As String
        o_module = "Util"
        o.Project.Modules.Item((o_module)).Attributes.Add("Instancing").Value = "private"

        SaveModule("Util", "module", decl, body)
bye:

    End Sub
End Class