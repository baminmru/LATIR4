Option Explicit On
Imports MTZMetaModel.MTZMetaModel
Imports LATIRGenerator
Public Class Generator

    Dim m As Application
    Dim o As Response
    Dim tid As String
    Dim log As String
    Dim ftmap As Collection

    Private mTables As Boolean
    Private mKernel As Boolean
    Private mViews As Boolean
    Private mFullText As Boolean
    Private mInit As Boolean
    Private mProcs As Boolean
    Private mMethod As Boolean
    Private mManual As Boolean
    Private mMaintein As Boolean
    Private gencnt As Long

    Public Map As Collection
    Public aFKMap As Collection

    Public Sub Setup()
        Dim f As frmOptions
        f = New frmOptions
        f.ShowDialog()
    End Sub


    Public Property OptTables() As Boolean
        Get
            OptTables = mTables
        End Get
        Set(ByVal Value As Boolean)
            mTables = Value
        End Set
    End Property


    Public Property OptMaintein() As Boolean
        Get
            OptMaintein = mMaintein
        End Get
        Set(ByVal Value As Boolean)
            mMaintein = Value
        End Set
    End Property


    Public Property OptManual() As Boolean
        Get
            OptManual = mManual
        End Get
        Set(ByVal Value As Boolean)
            mManual = Value
        End Set
    End Property



    Public Property OptMethod() As Boolean
        Get
            OptMethod = mMethod
        End Get
        Set(ByVal Value As Boolean)
            mMethod = Value
        End Set
    End Property


    Public Property OptProcs() As Boolean
        Get
            OptProcs = mProcs
        End Get
        Set(ByVal Value As Boolean)
            mProcs = Value
        End Set
    End Property



    Public Property OptInit() As Boolean
        Get
            OptInit = mInit
        End Get
        Set(ByVal Value As Boolean)
            mInit = Value
        End Set
    End Property

    Public Property OptFullText() As Boolean
        Get
            OptFullText = mFullText
        End Get
        Set(ByVal Value As Boolean)
            mFullText = Value
        End Set
    End Property


    Public Property OptViews() As Boolean
        Get
            OptViews = mViews
        End Get
        Set(ByVal Value As Boolean)
            mViews = Value
        End Set
    End Property


    Public Property OptKernel() As Boolean
        Get
            OptKernel = mKernel
        End Get
        Set(ByVal Value As Boolean)
            mKernel = Value
        End Set
    End Property




    Public Function Run(ByVal Model As Object, ByVal out As Object, ByVal targetid As String) As String
        Dim i As Long, j As Long, k As Long
        Dim os As PART

        m = Model
        o = out
        tid = targetid
        log = ""
        System.Diagnostics.Debug.Print("ORAGEN.Run:start")
        LoadMap()
        LoadFKMap()

        'read settings


        OptInit = GetSetting("LATIR2", "ORAGEN", "INIT", 1) = 1
        OptKernel = GetSetting("LATIR2", "ORAGEN", "KERNEL", 1) = 1
        OptMethod = GetSetting("LATIR2", "ORAGEN", "METHODS", 1) = 1
        OptProcs = GetSetting("LATIR2", "ORAGEN", "PROCS", 1) = 1
        OptTables = GetSetting("LATIR2", "ORAGEN", "TABLES", 1) = 1
        OptViews = GetSetting("LATIR2", "ORAGEN", "VIEW", 1) = 1
        OptManual = GetSetting("LATIR2", "ORAGEN", "MANUAL", 1) = 1

        o.ModuleName = "--PreInstall"
        o.Block = "--body"
        o.OutNL("")


        o.ModuleName = "--Tables"
        o.Block = "--kernel"
        o.OutNL(" ")

        o.ModuleName = "--Tables"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--Tables"
        o.Block = "--ForeignKey"
        o.OutNL(" ")

        o.ModuleName = "--Tables"
        o.Block = "--index"
        o.OutNL(" ")


        o.ModuleName = "--Functions.Header"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--Views"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--Procedures.Kernel.Header"
        o.Block = "--body"
        o.OutNL(" ")


        o.ModuleName = "--Procedures.Type.Header"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--Procedures.Methods"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--Custom"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--Functions.Body"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--Procedures.Kernel.Body"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--Procedures.Type.Body"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--Init"
        o.Block = "--body"
        o.OutNL(" ")

        System.Diagnostics.Debug.Print("ORAGEN.Run:Kernel")
        LoadWords()
        On Error GoTo bye

        If OptKernel Then
            Dim mk As New MakeKernel
            mk.Init(Me, m, o, tid)
            mk.Run()
        End If

        System.Diagnostics.Debug.Print("ORAGEN.Run:Schema")
        Dim msc As MakeSchema
        If OptTables Then
            msc = New MakeSchema
            msc.Init(Me, m, o, tid)
            msc.Run()
        End If

        If OptViews Then
            Dim mf As New MakeFunc
            mf.Init(Me, m, o, tid)
            mf.Run()
        End If


        System.Diagnostics.Debug.Print("ORAGEN.Run:Views")
        If OptViews Then
            Dim mv As New MakeView
            mv.Init(Me, m, o, tid)
            mv.Run()
        End If


        System.Diagnostics.Debug.Print("ORAGEN.Run:Types")
        Dim mt As MakeType

        If OptProcs Then
            For i = 1 To m.OBJECTTYPE.Count
                mt = New MakeType
                mt.Init(Me, m, o, tid)
                mt.Run(m.OBJECTTYPE.Item(i))
                o.Status("Type procs " & m.OBJECTTYPE.Item(i).Name, i)
            Next
        End If


        System.Diagnostics.Debug.Print("ORAGEN.Run:Methods")
        If OptMethod Then
            Dim mc As MakeCustom
            mc = New MakeCustom
            mc.Init(Me, m, o, tid)
            mc.Run()
        End If


        System.Diagnostics.Debug.Print("ORAGEN.Run:LoadOptions")
        If OptInit Then
            Dim mi As New MakeInit
            mi.Init(Me, m, o, tid)
            mi.Run()
        End If


        Run = log
        System.Diagnostics.Debug.Print("ORAGEN.Run:done")
        SaveMap()
        SaveFKMap()
        Exit Function
bye:

        'MsgBox Err.Description
        'Resume
        System.Diagnostics.Debug.Print("ORAGEN.Run:" & Err.Description)
        Run = log
        SaveMap()
        SaveFKMap()
    End Function











    Friend Function FieldForCreate(ByVal f As FIELD) As String
        System.Diagnostics.Debug.Print("ORAGEN.FieldForCreate:start")
        On Error Resume Next



        Dim s As String, ftm As FIELDTYPEMAP
        Dim ft As FIELDTYPE
        s = VF(f.Name)
        ft = f.FieldType
        ftm = MapFTObj(ft.ID.ToString())
        If ftm.FixedSize <> 0 Then
            s = s & " " & ftm.StoageType & "(" & ftm.FixedSize & ")"
        Else

            s = s & vbCrLf & " " & ftm.StoageType
            If ft.AllowSize Then
                If f.DataSize <> 0 Then
                    s = s & " (" & f.DataSize & ")"
                Else
                    s = s & " (1)"
                End If
            End If
        End If
        ' If F.AllowNull Then
        s = s & " null "
        ' Else
        '  s = s & " not null "
        ' End If


        If ft.TypeStyle = enumTypeStyle.TypeStyle_Interval Then
            s = s & vbCrLf & " check (" & VF(f.Name) & " >= " & ft.Minimum & " and " & VF(f.Name) & " <= " & ft.Maximum & ")"
        End If

        If ft.TypeStyle = enumTypeStyle.TypeStyle_Perecislenie Then
            If ft.ENUMITEM.Count > 0 Then
                s = s & vbCrLf & " check (" & VF(f.Name) & " in ( "
                Dim e
                For e = 1 To ft.ENUMITEM.Count
                    If e > 1 Then s = s & vbCrLf & ", "
                    s = s & ft.ENUMITEM.Item(e).NameValue & "/* " & ft.ENUMITEM.Item(e).Name & " */"
                Next
                s = s & " )) "
            End If
        End If

        s = s & "/* " & f.Caption & " */"

        '   'support extention field if file type used
        '   If UCase(F.FIELDTYPE.Name) = "FILE" Then
        '     s = s & vbCrLf & "," & vf(f.Name) & "_EXT varchar2(4) null"
        '   End If

        FieldForCreate = s
        System.Diagnostics.Debug.Print("ORAGEN.FieldForCreate:done")
        Exit Function
bye:


    End Function


    Friend Function FieldForParam(ByVal f As FIELD) As String
        System.Diagnostics.Debug.Print("ORAGEN.FieldForParam:start")
        On Error GoTo bye



        Dim s As String, ftm As FIELDTYPEMAP
        Dim ft As FIELDTYPE
        s = "a" & VF(f.Name)
        ft = f.FieldType
        ftm = MapFTObj(ft.ID.ToString)
        If ftm.FixedSize <> 0 Then
            s = s & " " & ftm.StoageType  ' & "(" & ftm.FixedSize & ")"
        Else
            s = s & vbCrLf & " " & ftm.StoageType
            If ft.AllowSize Then
                If f.DataSize <> 0 Then
                    s = s  ' & " (" & f.DataSize & ")"
                Else
                    s = s ' & " (1)"
                End If
            End If
        End If

        If f.AllowNull Then
            s = s & " := null "
        End If

        s = s & "/* " & f.Caption & " */"

        'support extention field if file type used
        If UCase(ft.Name) = "FILE" Then
            s = s & vbCrLf & ",a" & VF(f.Name) & "_EXT varchar2 "
        End If

        FieldForParam = s & "/* " & f.Caption & " */"
        System.Diagnostics.Debug.Print("ORAGEN.FieldForParam:done")
        Exit Function
bye:

        'Resume
    End Function







    Friend Function UniqueCheck(ByVal os As PART) As String
        ' DoEvents()
        System.Diagnostics.Debug.Print("ORAGEN.UniqueCheck:start " & os.Caption)

        On Error GoTo bye
        Dim s As String
        Dim st As PART
        Dim uc As UniqueConstraint
        Dim cf As CONSTRAINTFIELD
        Dim i As Long, j As Long
        st = os
        s = ""
        Dim z As String
        Dim fld As FIELD
        For i = 1 To st.UNIQUECONSTRAINT.Count
            uc = st.UNIQUECONSTRAINT.Item(i)
            z = ""
            If uc.CONSTRAINTFIELD.Count > 0 Then

                For j = 1 To uc.CONSTRAINTFIELD.Count
                    cf = uc.CONSTRAINTFIELD.Item(j)
                    fld = cf.TheField
                    If Not cf.TheField Is Nothing Then
                        z = z & vbCrLf & " and " & VF(fld.Name) & "=a" & VF(fld.Name)

                    End If
                Next

                If uc.PerParent Then
                    If os.PartType = enumPartType.PartType_Derevo Then
                        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
                            s = s & vbCrLf & " if aParentRowID is null then"
                            s = s & vbCrLf & "   select Count(*) into aUniqueRowCount from " & VF(os.Name) & " where InstanceID=aInstanceID and ParentRowID is null " & z & ";"
                            s = s & vbCrLf & " else "
                            s = s & vbCrLf & "   select Count(*) into aUniqueRowCount from " & VF(os.Name) & " where InstanceID=aInstanceID and ParentRowID=aParentRowID " & z & ";"
                            s = s & vbCrLf & " end if;"
                        Else
                            s = s & vbCrLf & " if aParentRowID is null then"
                            s = s & vbCrLf & "   select Count(*) into aUniqueRowCount from " & VF(os.Name) & " where ParentStructRowID=aParentStructRowID and ParentRowID is null " & z & ";"
                            s = s & vbCrLf & " else "
                            s = s & vbCrLf & "   select Count(*) into aUniqueRowCount from " & VF(os.Name) & " where ParentStructRowID=aParentStructRowID and ParentRowID =aParentRowID " & z & ";"
                            s = s & vbCrLf & " end if;"
                        End If
                    Else
                        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
                            s = s & vbCrLf & " select Count(*) into aUniqueRowCount from " & VF(os.Name) & " where InstanceID=aInstanceID " & z & ";"
                        Else
                            s = s & vbCrLf & "select Count(*) into aUniqueRowCount from " & VF(os.Name) & " where ParentStructRowID=aParentStructRowID " & z & ";"
                        End If
                    End If
                Else
                    s = s & vbCrLf & "select Count(*) into aUniqueRowCount from " & VF(os.Name) & " where 1=1  " & z & ";"
                End If



            End If
            s = s & vbCrLf & "if aUniqueRowCount>=2"
            s = s & vbCrLf & "then"
            s = s & vbCrLf & " raise_application_error(-20000,'Нарущение уникальности сочетания полей. Раздел=" & VF(os.Name) & "');"
            s = s & vbCrLf & " return;"
            s = s & vbCrLf & "end if;"
        Next
        UniqueCheck = s
        System.Diagnostics.Debug.Print("ORAGEN.UniqueCheck:done " & os.Caption)
        Exit Function
bye:

        'Resume
    End Function






    Friend Function TypeForStruct(ByVal s As PART) As OBJECTTYPE
        System.Diagnostics.Debug.Print("ORAGEN.TypeForStruct:start " & s.Caption)
        'Dim i As Long
        Dim obj As Object
        obj = s.parent.parent

        ' ищем что за тип объекта
        While TypeName(obj) <> "OBJECTTYPE"
            obj = obj.parent.parent
        End While

        TypeForStruct = obj

        System.Diagnostics.Debug.Print("ORAGEN.TypeForStruct:done " & s.Caption)
    End Function






    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' UTILS
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' return phisical type for FIELDTYPE
    Friend Function MapFT(ByVal typeID As String) As String
        Dim i As Integer, s As String = ""
        Dim ft As FIELDTYPE

        On Error Resume Next

        If ftmap Is Nothing Then ftmap = New Collection
        If ftmap.Item(typeID) Is Nothing Then
        Else
            s = ftmap.Item(typeID).StoageType
            If ftmap.Item(typeID).FixedSize <> 0 Then
                s = s & vbCrLf & " (" & ftmap.Item(typeID).FixedSize & ")"
            End If
            MapFT = s
            Exit Function
        End If

        On Error GoTo bye

        MapFT = "INTEGER"
        ft = m.FIELDTYPE.Item(typeID)
        If ft Is Nothing Then Exit Function
        For i = 1 To ft.FIELDTYPEMAP.Count
            If ft.FIELDTYPEMAP.Item(i).Target.ID.Equals(New Guid(tid)) Then
                ftmap.Add(ft.FIELDTYPEMAP.Item(i), typeID)
                s = ft.FIELDTYPEMAP.Item(i).StoageType
                If ft.FIELDTYPEMAP.Item(i).FixedSize <> 0 Then
                    s = s & vbCrLf & " (" & ft.FIELDTYPEMAP.Item(i).FixedSize & ")"
                End If
                Exit For
            End If
        Next
        MapFT = s
        Exit Function
bye:


    End Function


    Friend Function MapFTObj(ByVal typeID As String) As FIELDTYPEMAP
        On Error Resume Next

        If ftmap Is Nothing Then ftmap = New Collection
        If ftmap.Item(typeID) Is Nothing Then
        Else
            MapFTObj = ftmap.Item(typeID)
            Exit Function
        End If

        On Error GoTo bye
        Dim i, s
        Dim ft As FIELDTYPE
        ft = m.FIELDTYPE.Item(typeID)
        If ft Is Nothing Then Return Nothing
        For i = 1 To ft.FIELDTYPEMAP.Count
            If ft.FIELDTYPEMAP.Item(i).Target.ID.Equals(New Guid(tid)) Then
                ftmap.Add(ft.FIELDTYPEMAP.Item(i), typeID)
                Return ft.FIELDTYPEMAP.Item(i)
            End If
        Next

bye:

        Return Nothing
    End Function

    Friend Function MakeName(ByVal s As String) As String
        Dim tt As String = s
        '  tt = s
        '  tt = Replace(tt, "-", "")
        '  tt = Replace(tt, "{", "")
        '  tt = Replace(tt, "}", "")
        '  tt = Replace(tt, " ", "_")
        '  MakeName = tt
        MakeName = GetMap(tt)
    End Function



    Friend Function IsParent(ByVal p As PART, ByVal parent As String) As Boolean
        Dim o As Object
        o = p
        While TypeName(o) <> "OBJECTTYPE"
            o = o.parent.parent
            If o.ID = parent Then
                IsParent = True
                Exit Function
            End If
        End While
        IsParent = False

    End Function

    ' создаем view для журналов
    Friend Sub MakeJournals()
        '  System.Diagnostics.Debug.Print "ORAGEN.MakeJournals:start "
        '  Dim jr As Jounal
        '  Dim jc As JournalColumn
        '  Dim js As JournalSrc
        '  Dim jcs As JColumnSource
        '  Dim s As String, out As String
        '
        '  Dim i As Long, j As Long, k As Long, l As Long, NoCol As Boolean
        '  For i = 1 To m.Jounal.Count
        '    Set jr = m.Jounal.Item(i)
        '    s = "create view J_" & jr.Name & " as  " & vbCrLf
        '    For j = 1 To jr.JournalSrc.Count
        '      Set js = jr.JournalSrc.Item(j)
        '      If j > 1 Then s = s & vbCrLf & " union all " & vbCrLf
        '      s = s & vbCrLf & " select InstanceID, ID, VIEWBASE "
        '      For k = 1 To jr.JournalColumn.Count
        '        NoCol = True
        '        Set jc = jr.JournalColumn.Item(k)
        '        For l = 1 To jc.JColumnSource.Count
        '          Set jcs = jc.JColumnSource.Item(l)
        '          If jcs.SrcPartView.ID = js.ID Then
        '            s = s & vbCrLf & ", " & jcs.ViewField & " /* " & jc.Name & " */ "
        '            NoCol = False
        '          End If
        '        Next l
        '        If NoCol Then
        '            s = s & vbCrLf & ", null /* " & jc.Name & " */ "
        '        End If
        '      Next k
        '      s = s & vbCrLf & " from V_" & js.PARTVIEW.the_alias
        '
        '    Next j
        '    o.ModuleName = "--Journals--"
        '    o.Block = "--Journals--"
        '    o.OutNL s
        '    o.OutNL ";"
        '  Next i
        '  System.Diagnostics.Debug.Print "ORAGEN.MakeJournals:done "
    End Sub






    Friend Sub LoadMap()
        Dim ff As Short
        Dim ID1S As String = ""
        Dim IDMTZ As String = ""
        Dim idm As IDMAP
        ff = FreeFile
        Map = New Collection
        On Error GoTo bye
        FileOpen(ff, My.Application.Info.DirectoryPath & "\IDMAP.txt", OpenMode.Input)
        While Not EOF(ff)
            Input(ff, ID1S)
            Input(ff, IDMTZ)
            idm = New IDMAP
            If ID1S <> "" Then
                idm.ID1S = ID1S
                idm.IDMTZ = IDMTZ
                On Error Resume Next
                Map.Add(idm, ID1S)
                On Error GoTo bye
            End If
        End While
        FileClose(ff)
bye:

    End Sub


    Friend Sub LoadFKMap()
        Dim ff As Short
        Dim ID1S As String = ""
        Dim IDMTZ As String = ""
        Dim idm As IDMAP
        ff = FreeFile
        aFKMap = New Collection
        On Error GoTo bye
        FileOpen(ff, My.Application.Info.DirectoryPath & "\FKMAP.txt", OpenMode.Input)
        While Not EOF(ff)
            Input(ff, ID1S)
            Input(ff, IDMTZ)
            idm = New IDMAP
            If ID1S <> "" Then
                idm.ID1S = ID1S
                idm.IDMTZ = IDMTZ
                On Error Resume Next
                aFKMap.Add(idm, ID1S)
                On Error GoTo bye
            End If
        End While
        FileClose(ff)
        gencnt = Val(FKMap("GENCNT"))
bye:

    End Sub

    Friend Sub SaveMap()
        Dim ff As Short
        Dim idm As IDMAP
        ff = FreeFile
        FileOpen(ff, My.Application.Info.DirectoryPath & "\IDMAP.txt", OpenMode.Output)
        On Error Resume Next

        For Each idm In Map
            WriteLine(ff, idm.ID1S, idm.IDMTZ)
        Next idm
        FileClose(ff)
    End Sub

    Friend Sub SaveFKMap()
        Dim ff As Short
        Dim idm As IDMAP
        ff = FreeFile
        FileOpen(ff, My.Application.Info.DirectoryPath & "\FKMAP.txt", OpenMode.Output)
        On Error Resume Next
        If (aFKMap.Item("GENCNT") Is Nothing) Then
            idm = New IDMAP
            idm.ID1S = "GENCNT"
            idm.IDMTZ = CStr(gencnt)
            aFKMap.Add(idm, "GENCNT")
        End If
        'UPGRADE_WARNING: Couldn't resolve default property of object aFKMap.Item().IDMTZ. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        aFKMap.Item("GENCNT").IDMTZ = gencnt

        For Each idm In aFKMap
            WriteLine(ff, idm.ID1S, idm.IDMTZ)
        Next idm
        FileClose(ff)
    End Sub

    Friend Function FKMap(ByRef ID1S As String) As String
        Dim idm As IDMAP
        On Error Resume Next
        'UPGRADE_NOTE: Object idm may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        idm = Nothing
        idm = aFKMap.Item(ID1S)
        If idm Is Nothing Then
            idm = New IDMAP
            idm.ID1S = ID1S
            idm.IDMTZ = CStr(gencnt)
            gencnt = gencnt + 1
            aFKMap.Add(idm, ID1S)
        End If
        FKMap = idm.IDMTZ
    End Function

    Friend Function GetMap(ByRef ID1S As String) As String
        Dim idm As IDMAP
        On Error Resume Next
        'UPGRADE_NOTE: Object idm may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        idm = Nothing
        idm = Map.Item(ID1S)
        If idm Is Nothing Then
            idm = New IDMAP
            idm.ID1S = ID1S
            idm.IDMTZ = Guid.NewGuid().ToString
            Map.Add(idm, ID1S)
        End If
        GetMap = idm.IDMTZ
    End Function

    Public Sub New()
        LoadMap()
        LoadFKMap()
    End Sub

    Protected Overrides Sub Finalize()
        SaveMap()
        SaveFKMap()
    End Sub


    Friend Function procDropSQL(ByVal p As String) As String
        Dim s As String
        s = "drop procedure " & p & vbCrLf & "/"
        procDropSQL = s
    End Function

    Friend Function funcDropSQL(ByVal p As String) As String
        Dim s As String = ""
        '    s = "if exists (select * from sysobjects where id = object_id('" & p & "') and xtype in ('F', 'IF', 'TF'))"
        '    s = s & vbCrLf & "drop function " & p & ""
        '    s = s & vbCrLf & "/"
        funcDropSQL = s
    End Function

    Friend Function indexDropSQL(ByVal tbl As String, ByVal idx As String) As String
        Dim s As String
        '    s = "if exists (select * from sysindexes where name = '" & idx & "' and id = object_id('" & tbl & "'))"
        s = "drop index " & idx
        s = s & vbCrLf & "/"
        indexDropSQL = s
    End Function

    Friend Function keyDropSQL(ByVal tbl As String, ByVal key As String) As String
        Dim s As String
        '    s = "if exists(select * from sysobjects where id=object_id('" & key & "') and type='F')"
        s = "alter  TABLE " & tbl & " DROP CONSTRAINT " & key
        s = s & vbCrLf & "/"
        keyDropSQL = s
    End Function

    Friend Function PkeyDropSQL(ByVal tbl As String, ByVal key As String) As String
        Dim s As String = ""
        '    s = s & vbCrLf & "drop TABLE " & tbl
        '    s = s & vbCrLf & "/"
        PkeyDropSQL = s
    End Function

End Class











