Option Strict Off
Option Explicit On
Imports MTZMetaModel
Imports LATIR2

<System.Runtime.InteropServices.ProgId("Generator_NET.Generator")> Public Class Generator
    Dim m As MTZMetaModel.MTZMetaModel.Application
    'UPGRADE_WARNING: Arrays in structure o may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Dim o As LATIRGenerator.Response
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
    Private gencnt As Integer

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




    Public Function Run(ByRef Model As Object, ByRef out As Object, ByRef targetid As String) As String
        Dim j, i, k As Integer
        Dim os As MTZMetaModel.MTZMetaModel.PART

        m = Model
        o = out
        tid = targetid
        log = ""
        System.Diagnostics.Debug.Print("POSTGRESGEN.Run:start")
        LoadMap()
        LoadFKMap()

        'read settings


        OptInit = CDbl(GetSetting(My.Application.Info.Title, "POSTGRESGEN", "INIT", CStr(System.Windows.Forms.CheckState.Checked))) = 1
        OptKernel = CDbl(GetSetting(My.Application.Info.Title, "POSTGRESGEN", "KERNEL", CStr(System.Windows.Forms.CheckState.Checked))) = 1
        OptMethod = CDbl(GetSetting(My.Application.Info.Title, "POSTGRESGEN", "METHODS", CStr(System.Windows.Forms.CheckState.Checked))) = 1
        OptProcs = CDbl(GetSetting(My.Application.Info.Title, "POSTGRESGEN", "PROCS", CStr(System.Windows.Forms.CheckState.Checked))) = 1
        OptTables = CDbl(GetSetting(My.Application.Info.Title, "POSTGRESGEN", "TABLES", CStr(System.Windows.Forms.CheckState.Checked))) = 1
        OptViews = CDbl(GetSetting(My.Application.Info.Title, "POSTGRESGEN", "VIEW", CStr(System.Windows.Forms.CheckState.Checked))) = 1
        OptManual = CDbl(GetSetting(My.Application.Info.Title, "POSTGRESGEN", "MANUAL", CStr(System.Windows.Forms.CheckState.Checked))) = 1

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

        o.ModuleName = "--functions.Header"
        o.Block = "--body"
        o.OutNL(" ")


        o.ModuleName = "--functions.Type.Header"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--functions.Methods"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--Custom"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--Functions.Body"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--functions.Body"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--functions.Type.Body"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--Init"
        o.Block = "--body"
        o.OutNL(" ")

        System.Diagnostics.Debug.Print("POSTGRESGEN.Run:Kernel")
        LoadWords()
        On Error GoTo bye

        Dim mk As New MakeKernel
        If OptKernel Then
            mk.Init(Me, m, o, tid)
            mk.Run()
        End If

        System.Diagnostics.Debug.Print("POSTGRESGEN.Run:Schema")
        Dim msc As MakeSchema
        If OptTables Then
            msc = New MakeSchema
            msc.Init(Me, m, o, tid)
            msc.Run()
        End If

        Dim mf As New MakeFunc
        If OptViews Then
            mf.Init(Me, m, o, tid)
            mf.Run()
        End If


        System.Diagnostics.Debug.Print("POSTGRESGEN.Run:Views")
        Dim mv As New MakeView
        If OptViews Then
            mv.Init(Me, m, o, tid)
            mv.Run()
        End If


        System.Diagnostics.Debug.Print("POSTGRESGEN.Run:Types")
        Dim mt As MakeType
#If TIRAL = 1 Then
		'UPGRADE_NOTE: #If #EndIf block was not upgraded because the expression TIRAL = 1 did not evaluate to True or was not evaluated. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"'
		If Date < DateSerial(2010, 9, 20) Then
		If OptProcs Then
		For i = 1 To m.OBJECTTYPE.Count
		Set mt = New MakeType
		mt.Init Me, m, o, tid
		mt.Run m.OBJECTTYPE.Item(i)
		o.Status "Type procs " & m.OBJECTTYPE.Item(i).Name, i
		Next
		End If
		End If
#Else
        If OptProcs Then
            For i = 1 To m.OBJECTTYPE.Count
                mt = New MakeType
                mt.Init(Me, m, o, tid)
                mt.Run(m.OBJECTTYPE.Item(i))
                o.Status("Type procs " & m.OBJECTTYPE.Item(i).Name, i)
            Next
        End If
#End If

        System.Diagnostics.Debug.Print("POSTGRESGEN.Run:Methods")
        Dim mc As MakeCustom
        If OptMethod Then
            mc = New MakeCustom
            mc.Init(Me, m, o, tid)
            mc.Run()
        End If


        System.Diagnostics.Debug.Print("POSTGRESGEN.Run:LoadOptions")
        Dim mi As New MakeInit
        If OptInit Then
            mi.Init(Me, m, o, tid)
            mi.Run()
        End If


        Run = log
        System.Diagnostics.Debug.Print("POSTGRESGEN.Run:done")
        SaveMap()
        SaveFKMap()
        Exit Function
bye:

        'MsgBox Err.Description
        'Resume
        System.Diagnostics.Debug.Print("POSTGRESGEN.Run:" & Err.Description)
        Run = log
        SaveMap()
        SaveFKMap()
    End Function











    Friend Function FieldForCreate(ByRef f As MTZMetaModel.MTZMetaModel.FIELD) As String
        System.Diagnostics.Debug.Print("POSTGRESGEN.FieldForCreate:start")
        On Error Resume Next



        Dim s As String
        Dim ftm As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        s = VF(f.Name)
        ft = f.FieldType
        'UPGRADE_WARNING: Couldn't resolve default property of object ft.ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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



        If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then
            s = s & vbCrLf & " check (" & VF(f.Name) & " >= " & ft.Minimum & " and " & VF(f.Name) & " <= " & ft.Maximum & ")"
        End If

        'UPGRADE_WARNING: Couldn't resolve default property of object ft.TypeStyle. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Dim e As Object
        If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
            'UPGRADE_WARNING: Couldn't resolve default property of object ft.ENUMITEM. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If ft.ENUMITEM.Count > 0 Then
                s = s & vbCrLf & " check (" & VF(f.Name) & " in ( "
                'UPGRADE_WARNING: Couldn't resolve default property of object ft.ENUMITEM. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                For e = 1 To ft.ENUMITEM.Count
                    'UPGRADE_WARNING: Couldn't resolve default property of object e. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If e > 1 Then s = s & vbCrLf & ", "
                    'UPGRADE_WARNING: Couldn't resolve default property of object ft.ENUMITEM. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    s = s & ft.ENUMITEM.Item(e).NameValue & "/* " & ft.ENUMITEM.Item(e).Name & " */"
                Next
                s = s & " )) "
            End If
        End If

        s = s & "/* " & f.Caption & " */"

        '   'support extention field if file type used
        '   If UCase(ft.Name) = "FILE" Then
        '     s = s & vbCrLf & "," & vf(f.Name) & "_EXT varchar(4) null"
        '   End If

        FieldForCreate = s
        System.Diagnostics.Debug.Print("POSTGRESGEN.FieldForCreate:done")
        Exit Function
bye:


    End Function


    Friend Function FieldForParam(ByRef f As MTZMetaModel.MTZMetaModel.FIELD) As String
        System.Diagnostics.Debug.Print("POSTGRESGEN.FieldForParam:start")
        On Error GoTo bye



        Dim s As String
        Dim ftm As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        ft = f.FieldType
        s = "a" & VF(f.Name)
        'UPGRADE_WARNING: Couldn't resolve default property of object ft.ID. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ftm = MapFTObj(ft.ID.ToString)
        If ftm.FixedSize <> 0 Then
            s = s & " " & ftm.StoageType ' & "(" & ftm.FixedSize & ")"
        Else
            s = s & vbCrLf & " " & ftm.StoageType
            'UPGRADE_WARNING: Couldn't resolve default property of object ft.AllowSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If ft.AllowSize Then
                If f.DataSize <> 0 Then
                    s = s ' & " (" & f.DataSize & ")"
                Else
                    s = s ' & " (1)"
                End If
            End If
        End If

        If f.AllowNull Then
            s = s ' & " := null "
        End If

        s = s & "/* " & f.Caption & " */"

        'support extention field if file type used
        'UPGRADE_WARNING: Couldn't resolve default property of object ft.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If UCase(ft.Name) = "FILE" Then
            s = s & vbCrLf & ",a" & VF(f.Name) & "_EXT varchar "
        End If

        FieldForParam = s & "/* " & f.Caption & " */"
        System.Diagnostics.Debug.Print("POSTGRESGEN.FieldForParam:done")
        Exit Function
bye:

        'Resume
    End Function







    Friend Function UniqueCheck(ByRef os As MTZMetaModel.MTZMetaModel.PART) As String
        System.Windows.Forms.Application.DoEvents()
        System.Diagnostics.Debug.Print("POSTGRESGEN.UniqueCheck:start " & os.Caption)

        On Error GoTo bye
        Dim s As String
        Dim st As MTZMetaModel.MTZMetaModel.PART
        Dim uc As MTZMetaModel.MTZMetaModel.UNIQUECONSTRAINT
        Dim cf As MTZMetaModel.MTZMetaModel.CONSTRAINTFIELD
        Dim i, j As Integer
        st = os
        s = ""
        Dim z As String
        For i = 1 To st.UNIQUECONSTRAINT.Count
            uc = st.UNIQUECONSTRAINT.Item(i)
            z = ""
            If uc.CONSTRAINTFIELD.Count > 0 Then

                For j = 1 To uc.CONSTRAINTFIELD.Count
                    cf = uc.CONSTRAINTFIELD.Item(j)
                    If Not cf.TheField Is Nothing Then
                        'UPGRADE_WARNING: Couldn't resolve default property of object cf.TheField.Name. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        z = z & vbCrLf & " and " & VF(CType(cf.TheField, MTZMetaModel.MTZMetaModel.FIELD).Name) & "=a" & VF(CType(cf.TheField, MTZMetaModel.MTZMetaModel.FIELD).Name)

                    End If
                Next

                If uc.PerParent Then
                    If os.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                        'UPGRADE_WARNING: Couldn't resolve default property of object os.parent.parent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
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
                        'UPGRADE_WARNING: Couldn't resolve default property of object os.parent.parent. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
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
            s = s & vbCrLf & "  perform  raise_application_error(-20000,'Нарущение уникальности сочетания полей. Раздел=" & VF(os.Name) & "');"
            s = s & vbCrLf & " return;"
            s = s & vbCrLf & "end if;"
        Next
        UniqueCheck = s
        System.Diagnostics.Debug.Print("POSTGRESGEN.UniqueCheck:done " & os.Caption)
        Exit Function
bye:

        'Resume
    End Function






    Friend Function TypeForStruct(ByVal s As MTZMetaModel.MTZMetaModel.PART) As MTZMetaModel.MTZMetaModel.OBJECTTYPE
    
        Dim obj As Object
        obj = s.Parent.Parent

        ' ищем что за тип объекта
        While TypeName(obj) <> "OBJECTTYPE"
            obj = obj.parent.parent
        End While

        TypeForStruct = obj

    End Function






    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' UTILS
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' return phisical type for FIELDTYPE
    Friend Function MapFT(ByVal typeID As String) As String
        Dim i, s As Object
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        On Error Resume Next
        s = ""
        If ftmap Is Nothing Then ftmap = New Collection
        If ftmap.Item(typeID) Is Nothing Then
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object ftmap.Item().StoageType. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            s = ftmap.Item(typeID).StoageType
            'UPGRADE_WARNING: Couldn't resolve default property of object ftmap.Item(typeID).FixedSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If ftmap.Item(typeID).FixedSize <> 0 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object ftmap.Item().FixedSize. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                s = s & vbCrLf & " (" & ftmap.Item(typeID).FixedSize & ")"
            End If
            'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MapFT = s
            Exit Function
        End If

        On Error GoTo bye

        MapFT = "INTEGER"
        ft = m.FIELDTYPE.Item(typeID)
        If ft Is Nothing Then Exit Function
        For i = 1 To ft.FIELDTYPEMAP.Count

            If ft.FIELDTYPEMAP.Item(i).Target.ID.ToString = tid.ToString Then
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


    Friend Function MapFTObj(ByVal typeID As String) As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        On Error Resume Next
        MapFTObj = Nothing
        If ftmap Is Nothing Then ftmap = New Collection
        If ftmap.Item(typeID) Is Nothing Then
        Else
            MapFTObj = ftmap.Item(typeID)
            Exit Function
        End If

        On Error GoTo bye
        Dim i, s As Object
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        ft = m.FIELDTYPE.Item(typeID)
        If ft Is Nothing Then Exit Function
        For i = 1 To ft.FIELDTYPEMAP.Count

            If ft.FIELDTYPEMAP.Item(i).Target.ID.ToString = tid.ToString Then
                ftmap.Add(ft.FIELDTYPEMAP.Item(i), typeID)
                MapFTObj = ft.FIELDTYPEMAP.Item(i)
                Exit For
            End If
        Next
        Exit Function
bye:


    End Function

    Friend Function MakeName(ByVal s As String) As String
        MakeName = GetMap(s)
    End Function



    Friend Function IsParent(ByRef p As MTZMetaModel.MTZMetaModel.PART, ByRef parent As String) As Boolean
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


        For Each idm In Map
            Try
                WriteLine(ff, idm.ID1S, idm.IDMTZ)
            Catch ex As Exception

            End Try

        Next idm
        FileClose(ff)
	End Sub
	
	Friend Sub SaveFKMap()
		Dim ff As Short
		Dim idm As IDMAP
		ff = FreeFile
		FileOpen(ff, My.Application.Info.DirectoryPath & "\FKMAP.txt", OpenMode.Output)

        If (aFKMap.Item("GENCNT") Is Nothing) Then
            idm = New IDMAP
            idm.ID1S = "GENCNT"
            idm.IDMTZ = CStr(gencnt)
            aFKMap.Add(idm, "GENCNT")
        End If
        Try
            aFKMap.Item("GENCNT").IDMTZ = gencnt
        Catch ex As Exception

        End Try


        For	Each idm In aFKMap
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
	
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Friend Sub Class_Initialize_Renamed()
		LoadMap()
		LoadFKMap()
	End Sub
	Public Sub New()
		MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	
	'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Friend Sub Class_Terminate_Renamed()
		SaveMap()
		SaveFKMap()
	End Sub
	Protected Overrides Sub Finalize()
		Class_Terminate_Renamed()
		MyBase.Finalize()
	End Sub
	
	
	Friend Function procDropSQL(ByRef p As String) As String
		Dim s As String
		s = "drop function  if exists " & p & vbCrLf & ";"
		procDropSQL = s
	End Function
	
	Friend Function funcDropSQL(ByRef p As String) As String
        Dim s As String = ""
		'    s = "if exists (select * from sysobjects where id = object_id('" & p & "') and xtype in ('F', 'IF', 'TF'))"
		'    s = s & vbCrLf & "drop function " & p & ""
		'    s = s & vbCrLf & ";"
		funcDropSQL = s
	End Function
	
	Friend Function indexDropSQL(ByRef tbl As String, ByRef idx As String) As String
		Dim s As String
		'    s = "if exists (select * from sysindexes where name = '" & idx & "' and id = object_id('" & tbl & "'))"
		s = "drop index if exists " & idx
		s = s & vbCrLf & ";"
		indexDropSQL = s
	End Function
	
	Friend Function keyDropSQL(ByRef tbl As String, ByRef key As String) As String
		Dim s As String
		'    s = "if exists(select * from sysobjects where id=object_id('" & key & "') and type='F')"
		s = "alter  TABLE " & tbl & " DROP CONSTRAINT " & key
		s = s & vbCrLf & ";"
		keyDropSQL = s
	End Function
	
	Friend Function PkeyDropSQL(ByRef tbl As String, ByRef key As String) As String
        Dim s As String = ""
		'    s = s & vbCrLf & "drop TABLE " & tbl
		'    s = s & vbCrLf & ";"
		PkeyDropSQL = s
	End Function
End Class