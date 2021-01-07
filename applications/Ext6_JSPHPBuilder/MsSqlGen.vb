Option Strict Off
Option Explicit On
Imports MTZMetaModel.MTZMetaModel
Imports System.Text
Public Class MSSQLGenerator
    Dim m As MTZMetaModel.MTZMetaModel.Application
    Dim o As LATIRGenerator.Response
    Dim tid As String
    Dim log As String
    Dim ftmap As Collection

    Private mTables As Boolean = True
    Private mViews As Boolean = True
    Private mRights As Boolean



    Public Map As Collection


    Public Property OptTables() As Boolean
        Get
            OptTables = mTables
        End Get
        Set(ByVal Value As Boolean)
            mTables = Value
        End Set
    End Property



    Public Property OptRights() As Boolean
        Get
            OptRights = mRights
        End Get
        Set(ByVal Value As Boolean)
            mRights = Value
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

    Private mSelectedParts As List(Of String) = New List(Of String)


    Public ReadOnly Property SelectedParts() As List(Of String)
        Get
            Return mSelectedParts
        End Get
    End Property

    Public Sub ClearSelectedParts()
        mSelectedParts = New List(Of String)
    End Sub


    Public Function IsPartSelected(PartName As String) As Boolean
        If mSelectedParts.Count = 0 Then Return True

        If mSelectedParts.Contains(PartName) Then
            Return True
        End If
        Return False
    End Function



    Public Function Run(ByRef Model As Object, ByRef Output As Object, ByRef targetid As String) As String
        m = Model
        o = Output
        tid = targetid
        log = ""

        'read settings


        o.ModuleName = "--Tables"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--Tables"
        o.Block = "--ForeignKey"
        o.OutNL(" ")

        o.ModuleName = "--Tables"
        o.Block = "--Index"
        o.OutNL(" ")


        o.ModuleName = "--FunctionsHeader"
        o.Block = "--TableProc"
        o.OutNL(" ")

        o.ModuleName = "--Functions"
        o.Block = "--TableProc"
        o.OutNL(" ")



        o.ModuleName = "--Views--"
        o.Block = "--Views--"
        o.OutNL(" ")


        Dim j, i, k As Integer
        Dim os As MTZMetaModel.MTZMetaModel.PART

        On Error GoTo bye

        For i = 1 To m.OBJECTTYPE.Count
            log = log & vbCrLf & "Create code for type " & m.OBJECTTYPE.Item(i).Name
            o.ModuleName = "--Tables"
            o.Block = "--body"
            o.OutNL("/* TYPE=" & m.OBJECTTYPE.Item(i).Name & " (" & m.OBJECTTYPE.Item(i).the_Comment & ") */")
            o.OutNL("GO")

            For j = 1 To m.OBJECTTYPE.Item(i).PART.Count
                os = m.OBJECTTYPE.Item(i).PART.Item(j)
                If IsPartSelected(os.Name) Then
                    If OptTables Then CreateStruct(os)
                    If OptViews Then
                        'MakeAllViews(os)
                        MakeSimpleViews(os)
                    End If
                End If
            Next

            o.Status(m.OBJECTTYPE.Item(i).the_Comment & " done", i)
        Next


        Run = log
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-" & Err.Description & "<--ERROR"

        Run = log

    End Function



    Private Sub CreateStruct(ByRef os As MTZMetaModel.MTZMetaModel.PART)

        If os.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
            Exit Sub
        End If

        Dim pos As MTZMetaModel.MTZMetaModel.PART

        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os

        CreateBriefFunc(os)
        CreateMultirefFunc(os)

        System.Windows.Forms.Application.DoEvents()
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i As Short
        Dim s As StringBuilder
        s = New StringBuilder
        Dim collist As String

        'Строка
        'Колекция
        'Дерево
        'Граф
        'CheckPartMLF(st, log)

        log = log & vbCrLf & "-CreateStruct " & os.Name


        On Error GoTo bye
        s.AppendLine("/*" & os.Caption & "*/")

        s.AppendLine("if not exists (select * from sysobjects where id = object_id(N'" & os.Name & "') and OBJECTPROPERTY(id, N'IsUserTable') = 1)")
        s.AppendLine("BEGIN")
        s.AppendLine("create table " & os.Name & "/*" & os.the_Comment & "*/ (")
        collist = ""
        If TypeName(os.Parent.Parent) <> "OBJECTTYPE" Then
            pos = os.Parent.Parent
            s.AppendLine(pos.Name & "ID uniqueidentifier not null,")
            collist = collist & "'" & pos.Name & "ID'"

            s.AppendLine(os.Name & "id uniqueidentifier not null rowguidcol default ( newid())  ")
            collist = collist & ",'" & os.Name & "ID'"

        Else

            s.AppendLine(os.Name & "id uniqueidentifier not null rowguidcol default ( newid())  ")
            collist = collist & "'" & os.Name & "ID'"
            pos = FindRootPart(os)
            If pos IsNot Nothing Then
                s.AppendLine("," & pos.Name & "ID uniqueidentifier not null")
                collist = collist & ",'" & pos.Name & "ID'"
            End If


        End If


        ' дерево
        If os.PartType = 2 Then
            s.AppendLine(",ParentRowid uniqueidentifier ")
            collist = collist & ",'ParentRowid'"
        End If

        s.AppendLine(")")
        s.AppendLine("END")
        s.AppendLine("go")

        If (OptRights) Then
            s.AppendLine("revoke all on [dbo].[" & os.Name & "] to [public]")
            s.AppendLine("go")
            s.AppendLine("grant select on [dbo].[" & os.Name & "] to [public]")
            s.AppendLine("go")
        End If
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            ft = st.FIELD.Item(i).FieldType

            If (ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy) Then
                'If i > 1 Then

                's.AppendLine ","
                s.AppendLine("if  not exists(select * from syscolumns where name='" & st.FIELD.Item(i).Name & "' and id=object_id(N'" & st.Name & "'))")
                s.AppendLine("alter table " & st.Name & " add ")
                s.AppendLine(FieldForCreate(st.FIELD.Item(i)))

                'support extention field if file type used
                'UPGRADE_WARNING: Couldn't resolve default property of object st.FIELD.Item().FIELDTYPE.Name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If UCase(ft.Name) = "FILE" Then
                    s.AppendLine("if  not exists(select * from syscolumns where name='" & st.FIELD.Item(i).Name & "_EXT' and id=object_id(N'" & st.Name & "'))")
                    s.AppendLine("alter table " & st.Name & " add ")
                    s.AppendLine(" " & st.FIELD.Item(i).Name & "_EXT nvarchar(4) null")
                    collist = collist & ",'" & st.FIELD.Item(i).Name & "_EXT'"
                End If

                collist = collist & ",'" & st.FIELD.Item(i).Name & "'"
                s.AppendLine("go")
            End If
        Next

        s.AppendLine(ColumnDropSQL((st.Name), collist))

        o.ModuleName = "--Tables"
        o.Block = "--body"
        o.OutNL(s.ToString())

        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        s = New StringBuilder
        s.AppendLine(PkeyDropSQL((os.Name), "pk_" & os.Name))
        s.AppendLine("alter table " & os.Name & " add constraint pk_" & os.Name & " primary key (" & os.Name & "ID)")
        o.ModuleName = "--Tables"
        o.Block = "--body"
        o.OutNL(s.ToString())
        o.OutNL("GO")




        If TypeName(os.Parent.Parent) <> "OBJECTTYPE" Then
            s = Nothing
            s = New StringBuilder
            s.AppendLine(keyDropSQL((os.Name), "fk_" & MakeName(os.ID.ToString())))

            s.AppendLine("alter table " & os.Name & " add constraint fk_" & MakeName(os.ID.ToString()) & " foreign key(" & pos.Name & "ID) references " & pos.Name & " (" & pos.Name & "ID)")
            o.ModuleName = "--Tables"
            o.Block = "--ForeignKey"
            o.OutNL(s.ToString())
            o.OutNL("GO")

            s = Nothing
            s = New StringBuilder
            s.AppendLine(indexDropSQL((os.Name), "parent_" & os.Name))
            s.AppendLine("create index parent_" & os.Name & " on " & os.Name & "(" & pos.Name & "ID)")
            o.ModuleName = "--Tables"
            o.Block = "--Index"
            o.OutNL(s.ToString())
            o.OutNL("GO")

        End If


        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            If IsPartSelected(chos.Name) Then
                CreateStruct(chos)
            End If

        Next

        s = Nothing

        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-" & Err.Description & "<--ERROR"
        s = Nothing

    End Sub























    Private Function FieldForCreate(ByRef f As MTZMetaModel.MTZMetaModel.FIELD) As String

        On Error Resume Next

        log = log & vbCrLf & "-FieldForCreate " & f.Name

        Dim s As String
        Dim ftm As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        s = f.Name
        ft = f.FieldType
        'UPGRADE_WARNING: Couldn't resolve default property of object f.FIELDTYPE.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ftm = MapFTObj(ft.ID.ToString())
        If ftm.FixedSize <> 0 Then
            s = s & " " & ftm.StoageType & "(" & ftm.FixedSize & ")"
        Else

            s = s & vbCrLf & " " & ftm.StoageType
            'UPGRADE_WARNING: Couldn't resolve default property of object f.FIELDTYPE.AllowSize. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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

            s = s & vbCrLf & " check (" & f.Name & " >= " & ft.Minimum & " and " & f.Name & " <= " & ft.Maximum & ")"
        End If


        Dim e As Object
        If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

            If ft.ENUMITEM.Count > 0 Then
                s = s & vbCrLf & " check (" & f.Name & " in ( "

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
        '     s = s & vbCrLf & "," & F.Name & "_EXT nvarchar(4) null"
        '   End If

        FieldForCreate = s

        Exit Function
bye:
        log = log & vbCrLf & "ERROR-" & Err.Description & "<--ERROR"

    End Function

    Private Function FieldForParam2(ByRef f As MTZMetaModel.MTZMetaModel.FIELD) As String

        On Error GoTo bye


        log = log & vbCrLf & "-FieldForParam " & f.Name
        Dim s As String
        Dim ftm As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        s = "@" & f.Name
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

        If f.AllowNull Then
            s = s & " = null "
        End If

        's = s & "/* " & f.Caption & " */"

        'support extention field if file type used

        If UCase(ft.Name) = "FILE" Then
            s = s & vbCrLf & ",@" & f.Name & "_EXT nvarchar(4) = null"
        End If

        FieldForParam2 = s '& "/* " & f.Caption & " */"

        Exit Function
bye:
        log = log & vbCrLf & "ERROR-" & Err.Description & "-ERROR"
        'Resume
    End Function

    Private Function FieldForParam(ByRef f As MTZMetaModel.MTZMetaModel.FIELD) As String
        'MTZUtilUtility_definst.DebugOutput("SQLGEN.FieldForParam:start")
        On Error GoTo bye


        log = log & vbCrLf & "-FieldForParam " & f.Name
        Dim s As String
        Dim ftm As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        ft = f.FieldType
        s = "@" & f.Name
        'UPGRADE_WARNING: Couldn't resolve default property of object ft.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ftm = MapFTObj(ft.ID.ToString())
        If ftm.FixedSize <> 0 Then
            s = s & " " & ftm.StoageType & "(" & ftm.FixedSize & ")"
        Else
            s = s & vbCrLf & " " & ftm.StoageType
            'UPGRADE_WARNING: Couldn't resolve default property of object ft.AllowSize. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If ft.AllowSize Then
                If f.DataSize <> 0 Then
                    s = s & " (" & f.DataSize & ")"
                Else
                    s = s & " (1)"
                End If
            End If
        End If

        If f.AllowNull Then
            s = s & " = null "
        End If

        s = s & "/* " & f.Caption & " */"

        'support extention field if file type used
        'UPGRADE_WARNING: Couldn't resolve default property of object ft.Name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If UCase(ft.Name) = "FILE" Then
            s = s & vbCrLf & ",@" & f.Name & "_EXT nvarchar(4) = null"
        End If

        FieldForParam = s & "/* " & f.Caption & " */"
        'MTZUtilUtility_definst.DebugOutput("SQLGEN.FieldForParam:done")
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-" & Err.Description & "<--ERROR"
        'Resume
    End Function




    Private Function MethodParam(ByRef f As MTZMetaModel.MTZMetaModel.PARAMETERS) As String
        'MTZUtilUtility_definst.DebugOutput("SQLGEN.MethodParam:start")
        On Error GoTo bye
        log = log & vbCrLf & "-MethodParam " & f.Name
        Dim s As String
        Dim ftm As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        s = "@" & f.Name
        ft = f.TypeOfParm
        'UPGRADE_WARNING: Couldn't resolve default property of object f.TypeOfParm.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        ftm = MapFTObj(f.TypeOfParm.ID.ToString())
        If ftm.FixedSize <> 0 Then
            s = s & " " & ftm.StoageType & "(" & ftm.FixedSize & ")"
        Else
            s = s & " " & ftm.StoageType
            'UPGRADE_WARNING: Couldn't resolve default property of object f.TypeOfParm.AllowSize. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If ft.AllowSize Then
                If f.DataSize <> 0 Then
                    s = s & " (" & f.DataSize & ")"
                Else
                    s = s & " (1)"
                End If
            End If
        End If

        If f.AllowNull Then
            s = s & " = null "
        End If
        If f.OutParam Then
            s = s & " output "
        End If


        MethodParam = s & "/* " & f.Caption & " */"
        'MTZUtilUtility_definst.DebugOutput("SQLGEN.MethodParam:done")
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-" & Err.Description & "<--ERROR"
        'Resume
    End Function




    'FindRootPart



    Private Function FindRootPart(ByVal s As MTZMetaModel.MTZMetaModel.PART) As MTZMetaModel.MTZMetaModel.PART
        Dim i As Integer
        Dim p As PART
        Dim obj As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        If TypeName(s.Parent.Parent) <> "OBJECTTYPE" Then
            Return Nothing
        End If

        obj = s.Parent.Parent

        For i = 1 To obj.PART.Count
            p = obj.PART.Item(i)
            If p.Sequence = 0 Then
                If Not p.ID.Equals(s.ID) Then
                    Return p
                Else
                    Return Nothing
                End If
            End If

        Next

        Return Nothing


    End Function







    Private Function TypeForStruct(ByVal s As MTZMetaModel.MTZMetaModel.PART) As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim i As Integer
        Dim obj As Object
        obj = s.Parent.Parent

        ' ищем что за тип объекта
        While TypeName(obj) <> "OBJECTTYPE"
            obj = obj.Parent.Parent
        End While

        TypeForStruct = obj


    End Function







    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' UTILS
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' return phisical type for FIELDTYPE
    Private Function MapFT(ByVal typeID As String) As String
        Dim i, s As Object
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

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
            '         End If
        Next
        MapFT = s
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-" & Err.Description & "<--ERROR"

    End Function


    Private Function MapFTObj(ByVal typeID As String) As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        On Error Resume Next

        If ftmap Is Nothing Then ftmap = New Collection
        ''''   If ftmap.Item(typeID) Is Nothing Then
        Dim obj As Object
        obj = ftmap.Item(typeID)
        If obj Is Nothing Then
            obj = Nothing
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
            If (Not ft.FIELDTYPEMAP.Item(i).Target Is Nothing) Then
                'UPGRADE_WARNING: Couldn't resolve default property of object ft.FIELDTYPEMAP.Item(i).Target.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If ft.FIELDTYPEMAP.Item(i).Target.ID.Equals(New Guid(tid)) Then
                    ftmap.Add(ft.FIELDTYPEMAP.Item(i), typeID)
                    MapFTObj = ft.FIELDTYPEMAP.Item(i)
                    Exit For
                End If
            End If
        Next
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-" & Err.Description & "<--ERROR"

    End Function








    Private Function MakeName(ByVal s As String) As String
        Dim tt As String
        tt = s
        tt = Replace(tt, "-", "")
        tt = Replace(tt, "{", "")
        tt = Replace(tt, "}", "")
        tt = Replace(tt, " ", "_")
        MakeName = tt
    End Function


    Private Sub CreateBriefFunc(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        If os.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
            Exit Sub
        End If

        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As StringBuilder
        s = New StringBuilder

        ' делаем отдельно заголовки функций
        CreateBriefFuncHdr(os)


        log = log & vbCrLf & "-CreateBriefFunc " & os.Name

        On Error GoTo bye

        s.AppendLine("")
        s.AppendLine("alter function " & os.Name & "_BRIEF_F  (")
        s.AppendLine(" @" & os.Name & "id uniqueidentifier")
        'MLF
        s.AppendLine(" ,@Lang varchar(25)=NULL")
        'EMLF
        s.AppendLine(") returns varchar(255) as " & " begin  ")
        s.AppendLine(" declare @BRIEF varchar(255)")
        s.AppendLine(" declare @tmpStr varchar(255)")
        s.AppendLine(" declare @tmpBrief varchar(2000)")
        s.AppendLine(" declare @tmpID uniqueidentifier")
        s.AppendLine(" declare @tmpMR varchar(4000) -- multiref only")
        'MLF
        s.AppendLine(" declare @MLFTemp varchar(2000)")
        s.AppendLine(" declare @MLFBrief varchar(2000)")
        's.AppendLine(" declare @Lang2 varchar(25)")
        'EMLF

        s.AppendLine("if @" & os.Name & "id is null begin set @BRIEF='' return (@BRIEF) end")
        s.AppendLine(" -- Brief body -- ")
        s.AppendLine("if exists(select 1 from " & os.Name & " where " & os.Name & "ID=@" & os.Name & "ID)")
        s.AppendLine(" begin")
        s.AppendLine(" --  verify access  --")
        s.AppendLine("  set @BRIEF=''")

        st.FIELD.Sort = "sequence"
        Dim arr() As String
        Dim sh As String
        Dim ft As FIELDTYPE
        For i = 1 To st.FIELD.Count
            ft = st.FIELD.Item(i).FieldType
            If (ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy) Then
                If st.FIELD.Item(i).IsBrief = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                    f = st.FIELD.Item(i)

                    ''''     's.AppendLine "  set @BRIEF= @BRIEF + '" & F.Caption & "='"
                    On Error Resume Next
                    sh = f.shablonBrief
                    If sh = "" Then
                        ReDim arr(1)
                    Else
                        sh = Replace(sh, "'", "")
                        arr = Split(sh, "%%")
                        ReDim Preserve arr(1)
                    End If

                    'enum

                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                        s.AppendLine("  select @BRIEF= @BRIEF +")
                        s.AppendLine("  case " & f.Name & " ")

                        For j = 1 To ft.ENUMITEM.Count

                            s.AppendLine("when " & ft.ENUMITEM.Item(j).NameValue & " then ")


                            s.AppendLine(" '" & arr(0) & ft.ENUMITEM.Item(j).Name & arr(1) & "; '")
                        Next
                        s.AppendLine("  end  from " & st.Name & " where " & os.Name & "ID=@" & os.Name & "ID")


                    ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                        If ft.Name = "MULTIREF" Then



                            If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                                s.AppendLine("select @tmpMR  =  " & f.Name)
                                s.AppendLine("  from " & os.Name & "  where  " & os.Name & "ID = @" & os.Name & "ID ")

                                s.AppendLine("declare multiref_cursor cursor for")
                                s.AppendLine("select dbo." & CType(f.RefToPart, PART).Name & "_BRIEF_F(" + CType(f.RefToPart, PART).Name + "ID, @Lang)  from " + CType(f.RefToPart, PART).Name)
                                s.AppendLine("where @tmpMR like '%'+convert(varchar(38)," + CType(f.RefToPart, PART).Name + "ID)+'%'")
                                s.AppendLine("set @tmpMR=''")
                                s.AppendLine("open multiref_cursor")
                                s.AppendLine("fetch next from multiref_cursor into @tmpBrief")
                                s.AppendLine("while @@fetch_status>=0")
                                s.AppendLine("begin")
                                s.AppendLine("    if @tmpMR<>''")
                                s.AppendLine("        set @tmpMR=@tmpMR+'; '")
                                s.AppendLine("    set @tmpMR=@tmpMR+@tmpBrief")
                                s.AppendLine("    fetch next from multiref_cursor into @tmpBrief")
                                s.AppendLine("End")
                                s.AppendLine("")
                                s.AppendLine("Close multiref_cursor")
                                s.AppendLine("deallocate multiref_cursor")

                                s.AppendLine("  set @BRIEF= @BRIEF + '{" & arr(0) & "' + isnull(@tmpbrief,'') + '" & arr(1) & "}; '")
                            End If

                        Else
                            s.AppendLine("select @tmpID =  " & f.Name)
                            s.AppendLine("  from " & os.Name & "  where  " & os.Name & "ID = @" & os.Name & "ID ")

                            If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                                'MLF
                                s.AppendLine(" select @tmpBrief= ' не поддерживается '")
                            End If


                            If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                                'MLF
                                s.AppendLine(" select @tmpBrief= dbo." & CType(f.RefToPart, PART).Name & "_BRIEF_F(@tmpID, @Lang)")
                            End If

                            If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_istocnik_dannih Then
                                s.AppendLine("select @tmpBrief=substring(" & f.Name & ",PATINDEX('%<Brief>%'," & f.Name & ")+7, PATINDEX('%</Brief>%'," & f.Name & ") -PATINDEX('%<Brief>%'," & f.Name & ")-7) from " & st.Name & " where  " & os.Name & "ID=@" & os.Name & "ID")
                            End If

                            s.AppendLine("  set @BRIEF= @BRIEF + '{" & arr(0) & "' + isnull(@tmpbrief,'') + '" & arr(1) & "}; '")
                        End If
                        'MLF
                        'ElseIf IsMLFField(f) Then
                        '    s.AppendLine("set @MLFBrief=null")
                        '    s.AppendLine("if not @Lang is null")
                        '    s.AppendLine("begin")
                        '    s.AppendLine("")
                        '    s.AppendLine("  set @MLFTemp='select @MLFTemp2=" & st.FIELD.Item(i).Name & " from " & os.Name & "_'+@Lang+' where " & os.Name & "ID=@" & os.Name & "ID'")
                        '    s.AppendLine("  exec sp_executesql @MLFTemp,N'@" & os.Name & "ID uniqueidentifier,@MLFBrief varchar(2000) output',@" & os.Name & "ID, @MLFBrief output")
                        '    s.AppendLine("End")

                        '    s.AppendLine("  select @BRIEF= @BRIEF ")
                        '    s.AppendLine("  +  Convert(varchar(255),isnull(@MLFBrief,isnull(Convert(varchar(255), " & st.FIELD.Item(i).Name & "),'')))+'; '")
                        '    s.AppendLine("  from " & os.Name & "  where  " & os.Name & "ID = @" & os.Name & "ID ")
                        '    'EMLF


                    Else
                        s.AppendLine("  select @BRIEF= @BRIEF ")
                        s.AppendLine("  + '" & arr(0) & "' + Convert(varchar(255),isnull(Convert(varchar(255), " & st.FIELD.Item(i).Name & "),'')) + '" & arr(1) & "; '")
                        s.AppendLine("  from " & os.Name & "  where  " & os.Name & "ID = @" & os.Name & "ID ")
                    End If
                End If
            End If
        Next
        s.AppendLine("end else begin")
        s.AppendLine("  set @BRIEF= ''")
        s.AppendLine("end")
        s.AppendLine("set @BRIEF=left(@BRIEF,255)")
        s.AppendLine("return(@BRIEF)")
        s.AppendLine("end ")
        Debug.Print(os.Name)

        o.ModuleName = "--Functions"
        o.Block = "--TableProc"
        o.OutNL(s.ToString())
        o.OutNL("GO")
        'MTZUtilUtility_definst.DebugOutput("SQLGEN.CreateBriefFunc:done " & os.Caption)
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-" & Err.Description & "<--ERROR"
        'Resume
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
    End Sub



    Private Sub CreateMultirefFuncHdr(ByRef os As MTZMetaModel.MTZMetaModel.PART)

        If os.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
            Exit Sub
        End If

        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As String


        log = log & vbCrLf & "-CreateMultirefFuncHdr " & os.Name

        On Error GoTo bye

        s = ""
        s = s & vbCrLf & funcDropSQL(os.Name & "_MREF_F")
        s = s & vbCrLf & "create function " & os.Name & "_MREF_F  ("
        s = s & vbCrLf & " @" & os.Name & "_ref varchar(4000)"
        'MLF
        s = s & vbCrLf & " ,@Lang varchar(25)=NULL"
        'EMLF
        s = s & vbCrLf & ") returns varchar(255) as " & " begin  "
        s = s & vbCrLf & " declare @MREF varchar(255)"
        s = s & vbCrLf & "  set @MREF='to do'"

        s = s & vbCrLf & "return(@MREF)"
        s = s & vbCrLf & "end "
        Debug.Print(os.Name)

        o.ModuleName = "--FunctionsHeader"
        o.Block = "--TableProc"
        o.OutNL(s)
        o.OutNL("GO")


        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-" & Err.Description & "<--ERROR"

    End Sub
    Private Sub CreateMultirefFunc(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        If os.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
            Exit Sub
        End If

        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As StringBuilder
        s = New StringBuilder

        ' делаем отдельно заголовки функций
        CreateMultirefFuncHdr(os)


        log = log & vbCrLf & "-CreateMRefFunc " & os.Name

        s.AppendLine("")
        s.AppendLine("alter function " & os.Name & "_MREF_F  (")
        s.AppendLine(" @" & os.Name & "_ref varchar(4000)")
        'MLF
        s.AppendLine(" ,@Lang varchar(25)=NULL")
        'EMLF
        s.AppendLine(") returns varchar(255) as " & " begin  ")


        s.AppendLine(" declare @MREF varchar(255)")
        s.AppendLine(" declare @tmpBrief varchar(255)")


        s.AppendLine("declare multiref_cursor cursor for")
        s.AppendLine("select dbo." & os.Name & "_BRIEF_F(" + os.Name + "ID, @Lang)  from " + os.Name)
        s.AppendLine("where @" & os.Name & "_ref like '%'+convert(varchar(38)," + os.Name + "ID)+'%'")
        s.AppendLine("set @MREF=''")
        s.AppendLine("open multiref_cursor")
        s.AppendLine("fetch next from multiref_cursor into @tmpBrief")
        s.AppendLine("while @@fetch_status>=0")
        s.AppendLine("begin")
        s.AppendLine("    if @MREF<>''")
        s.AppendLine("        set @MREF=@MREF+', '")
        s.AppendLine("    set @MREF=@MREF+@tmpBrief")
        s.AppendLine("    fetch next from multiref_cursor into @tmpBrief")
        s.AppendLine("End")
        s.AppendLine("")
        s.AppendLine("Close multiref_cursor")
        s.AppendLine("deallocate multiref_cursor")
        s.AppendLine("set @MREF=left(@MREF,255)")
        s.AppendLine("return(@MREF)")
        s.AppendLine("end ")

        o.ModuleName = "--Functions"
        o.Block = "--TableProc"
        o.OutNL(s.ToString())
        o.OutNL("GO")
    End Sub





    Private Sub CreateBriefFuncHdr(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        'MTZUtilUtility_definst.DebugOutput("SQLGEN.CreateBriefFuncHdr:start " & os.Caption)
        '''' If os.PartType = 3 Then
        If os.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
            'MTZUtilUtility_definst.DebugOutput("SQLGEN.CreateBriefFuncHdr:skipped " & os.Caption)
            Exit Sub
        End If

        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As String


        log = log & vbCrLf & "-CreateBriefFuncHdr " & os.Name

        On Error GoTo bye

        s = ""
        s = s & vbCrLf & funcDropSQL(os.Name & "_BRIEF_F")
        s = s & vbCrLf & "create function " & os.Name & "_BRIEF_F  ("
        s = s & vbCrLf & " @" & os.Name & "id uniqueidentifier"
        'MLF
        s = s & vbCrLf & " ,@Lang varchar(25)=NULL"
        'EMLF
        s = s & vbCrLf & ") returns varchar(255) as " & " begin  "
        s = s & vbCrLf & " declare @BRIEF varchar(255)"
        s = s & vbCrLf & "  set @BRIEF='to do'"

        s = s & vbCrLf & "return(@BRIEF)"
        s = s & vbCrLf & "end "
        Debug.Print(os.Name)

        o.ModuleName = "--FunctionsHeader"
        o.Block = "--TableProc"
        o.OutNL(s)
        o.OutNL("GO")


        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-" & Err.Description & "<--ERROR"


    End Sub









    Private Sub MakeAllViews(ByRef ppart As MTZMetaModel.MTZMetaModel.PART)
        If ppart.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
            Exit Sub
        End If
        Dim i As Integer
        Dim j As Integer
        For i = 1 To ppart.PARTVIEW.Count
            MakeViews(ppart.PARTVIEW.Item(i))
        Next

        For i = 1 To ppart.PART.Count
            MakeAllViews(ppart.PART.Item(i))
        Next

    End Sub


    Private Sub MakeSimpleViews(ByRef ppart As MTZMetaModel.MTZMetaModel.PART)
        If ppart.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Rassirenie Then
            Exit Sub
        End If
        Dim i As Integer
        Dim j As Integer

        MakeSimpleView(ppart)


        For i = 1 To ppart.PART.Count
            MakeSimpleViews(ppart.PART.Item(i))
        Next

    End Sub


    Private Sub MakeViews_PutColumns(ByRef pv As MTZMetaModel.MTZMetaModel.PARTVIEW, ByRef fcnt As Integer, ByRef s As StringBuilder, ByRef from As String, ByRef log As String, ByRef noagg As Integer, ByRef group As String, ByRef BP As MTZMetaModel.MTZMetaModel.PART, ByRef root As MTZMetaModel.MTZMetaModel.PART, Optional ByRef NoFirstTable As Boolean = False)
        Dim i As Object
        Dim j As Integer
        Dim vc As MTZMetaModel.MTZMetaModel.ViewColumn
        Dim refp As MTZMetaModel.MTZMetaModel.PART
        Dim p As MTZMetaModel.MTZMetaModel.PART
        Dim pos As MTZMetaModel.MTZMetaModel.PART
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        '
        On Error GoTo bye

        Dim isOK As Boolean
        For i = 1 To pv.ViewColumn.Count
            vc = pv.ViewColumn.Item(i)
            p = vc.FromPart
            If TypeName(p.Parent.Parent) <> "OBJECTTYPE" Then
                pos = p.Parent.Parent
            Else
                pos = FindRootPart(p)

            End If

            f = vc.Field

            ft = f.FieldType

            If Not (p Is Nothing) And Not (f Is Nothing) And ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                '      If fcnt > 1 Then
                s.AppendLine(", ")
                '      End If
                fcnt = fcnt + 1
                If vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_none Then
                    ft = f.FieldType
                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                        ' вписываем значение перечсления
                        s.AppendLine(" " & p.Name & "." & f.Name & "  ")
                        s.AppendLine(vc.the_Alias & "_VAL, ")

                        ' и его расшифровку
                        s.AppendLine(" case " & p.Name & "." & f.Name & " ")
                        For j = 1 To ft.ENUMITEM.Count
                            s.AppendLine("when " & ft.ENUMITEM.Item(j).NameValue & " then '" & ft.ENUMITEM.Item(j).Name & "'")
                        Next
                        s.AppendLine(" end ")

                    ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                        If (ft.Name = "ReferenceSQL") Then
                            s.AppendLine(" dbo.GetBriefFromXML(" & p.Name & "." & f.Name & ") ")
                        Else
                            ' вписываем значение ссылки
                            s.AppendLine(" " & p.Name & "." & f.Name & "  ")
                            s.AppendLine(vc.the_Alias & "_ID, ")

                            If ft.Name.ToLower() = "multiref" Then

                                ' и расшифрованное значение
                                If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then

                                ElseIf f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                                    refp = f.RefToPart
                                    'MLF

                                    s.AppendLine(" dbo." & refp.Name & "_MREF_F(" & p.Name & "." & f.Name & ", NULL) ")

                                    End If

                            Else

                                ' и расшифрованное значение
                                If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                                    'MLF

                                    s.AppendLine(" 'не поддерживается' ")

                                ElseIf f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                                    refp = f.RefToPart

                                    s.AppendLine(" dbo." & refp.Name & "_BRIEF_F(" & p.Name & "." & f.Name & ", NULL) ")

                                    End If


                            End If



                        End If
                    Else
                        s.AppendLine(GetFullFieldName(f, p) & " ")
                    End If

                    noagg = noagg + 1
                    group = group & vbCrLf & "," & p.Name & "." & f.Name & " "
                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_MAX Then

                    s.AppendLine("MAX(" & GetFullFieldName(f, p) & ") ")

                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_MIN Then
                    s.AppendLine("MIN(" & GetFullFieldName(f, p) & ") ")
                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_AVG Then
                    s.AppendLine("AVG(" & GetFullFieldName(f, p) & ") ")
                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_SUM Then
                    s.AppendLine("SUM(" & GetFullFieldName(f, p) & ") ")
                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_COUNT Then
                    s.AppendLine("COUNT(" & GetFullFieldName(f, p) & ") ")
                End If
                s.AppendLine(vc.the_Alias & " ")

                If BP.ID = p.Parent.Parent.ID Then
                    isOK = False

                    ' проверяем поля, которые входят в раздел
                    For j = 1 To i - 1

                        If pv.ViewColumn.Item(j).FromPart.ID = p.ID Then
                            isOK = True
                            Exit For
                        End If
                    Next

                    ' если в разделе есть поля, то включаем его в запрос
                    If Not isOK Then
                        from = from & vbCrLf & " left join " & p.Name & " on " & BP.Name & "." & BP.Name & "ID = " & p.Name & "." & pos.Name & "ID"
                    End If
                End If


                ' проверяем верхние разделы, которые не  являются непосредственными родителями нашего базового раздела
                'If TypeName(p.Parent.Parent) = "OBJECTTYPE" And (p.ID <> root.ID) Then
                '    isOK = False
                '    For j = 1 To i - 1
                '        If pv.ViewColumn.Item(j).FromPart.ID = p.ID Then
                '            isOK = True
                '            Exit For
                '        End If
                '    Next
                '    ' есть поля из верхнего раздела
                '    If Not isOK Then
                '        from = from & vbCrLf & " left join " & p.Name & " ON " & p.Name & ".InstanceID=" & root.Name & ".InstanceID"
                '    End If
                'End If
            Else
                log = log & vbCrLf & "ERROR-Ошибка определения запроса:" & pv.Name & "(" & pv.the_Alias & ")" & " колонка: " & vc.the_Alias & " - не задан раздел, или поле.<--ERROR"
            End If
        Next

        'MLF
        p = pv.Parent.Parent
        'If IsMLFPart(p) Then
        '    from = from & vbCrLf & " left join " & p.Name & "_ ON " & p.Name & "." & p.Name & "ID=" & p.Name & "_." & p.Name & "ID"
        'End If

        Exit Sub
bye:
        MsgBox(Err.Description)
        Stop
        Resume

    End Sub

    'MLF
    Private Function GetFullFieldName(ByRef f As MTZMetaModel.MTZMetaModel.FIELD, ByRef p As MTZMetaModel.MTZMetaModel.PART) As String

        GetFullFieldName = p.Name & "." & f.Name

    End Function


    Private Sub MakeSimpleView(ByRef BP As MTZMetaModel.MTZMetaModel.PART)
        Dim s As StringBuilder
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE

        Dim p As MTZMetaModel.MTZMetaModel.PART
        Dim refp As MTZMetaModel.MTZMetaModel.PART
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim root As MTZMetaModel.MTZMetaModel.PART
        Dim vc As MTZMetaModel.MTZMetaModel.ViewColumn
        Dim i, j As Integer
        Dim from As String

        Dim structfld As String
        Dim pos As MTZMetaModel.MTZMetaModel.PART
        On Error GoTo bye




        s = New StringBuilder

        ' найти раздел первого уровня и построить цепочку прямых join
        root = BP



        from = " from " & BP.Name
        structfld = DeCap(BP.Name) & "Id"





        ' стандартное начало

        s.AppendLine(viewDropSQL("V_" & BP.Name))
        s.AppendLine("create view V_" & BP.Name & " as ")


        s.AppendLine("select   " & BP.Name & "." & structfld)

        Dim fcnt As Integer
        fcnt = 1

        p = BP
        If TypeName(p.Parent.Parent) <> "OBJECTTYPE" Then
            pos = p.Parent.Parent
        Else
            pos = FindRootPart(p)
        End If

        If pos IsNot Nothing Then
            s.AppendLine(", " + DeCap(pos.Name) + "Id ")
        End If

        Dim isOK As Boolean
        For i = 1 To BP.FIELD.Count



            f = BP.FIELD.Item(i)

            ft = f.FieldType

            If Not (p Is Nothing) And Not (f Is Nothing) And ft.TypeStyle <> MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Element_oformleniy Then
                '      If fcnt > 1 Then
                s.AppendLine(", ")
                '      End If
                fcnt = fcnt + 1

                ft = f.FieldType
                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                    ' вписываем значение перечсления
                    s.AppendLine(" " & p.Name & "." & f.Name & "  ")
                    s.AppendLine(DeCap(f.Name) & " ")

                    ' и его расшифровку
                    s.AppendLine(", case " & p.Name & "." & f.Name & " ")
                    For j = 1 To ft.ENUMITEM.Count
                        s.AppendLine("when " & ft.ENUMITEM.Item(j).NameValue & " then '" & ft.ENUMITEM.Item(j).Name & "'")
                    Next
                    s.AppendLine(" end ")
                    s.AppendLine(DeCap(f.Name) & "_name ")

                ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then

                    If (ft.Name = "ReferenceSQL") Then
                        s.AppendLine(" dbo.GetBriefFromXML(" & p.Name & "." & f.Name & ") ")
                        s.AppendLine(f.Name & " ")
                    Else
                        ' вписываем значение ссылки
                        s.AppendLine(" " & p.Name & "." & f.Name & "  ")
                        s.AppendLine(DeCap(f.Name) & " ")

                        If ft.Name.ToLower() = "multiref" Then

                            ' и расшифрованное значение
                            If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then

                                s.AppendLine(", 'не поддерживается' ")
                                s.AppendLine(DeCap(f.Name) & "_name ")

                            ElseIf f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                                refp = f.RefToPart
                                'MLF

                                s.AppendLine(", dbo." & refp.Name & "_MREF_F(" & p.Name & "." & f.Name & ", NULL) ")
                                s.AppendLine(DeCap(f.Name) & "_name ")
                            End If

                        Else

                            ' и расшифрованное значение
                            If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                                'MLF

                                s.AppendLine(", 'не поддерживается' ")
                                s.AppendLine(DeCap(f.Name) & "_name ")

                            ElseIf f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                                refp = f.RefToPart

                                s.AppendLine(", dbo." & refp.Name & "_BRIEF_F(" & p.Name & "." & f.Name & ", NULL) ")
                                s.AppendLine(DeCap(f.Name) & "_name ")
                            End If


                        End If



                    End If
                ElseIf ft.Name.ToLower() = "datetime" Then
                    s.AppendLine("DATEADD(hh, DATEPART(hh, GETDATE() - GETUTCDATE()) ," + GetFullFieldName(f, p) & ") ")
                    s.AppendLine(DeCap(f.Name) & " ")
                Else

                    s.AppendLine(GetFullFieldName(f, p) & " ")
                    s.AppendLine(DeCap(f.Name) & " ")
                End If



            End If
        Next


        s.AppendLine(", " & BP.Name & "." & BP.Name & "ID ID ")
        s.AppendLine(", '" & BP.Name & "' VIEWBASE ")


        o.ModuleName = "--Views--"
        o.Block = "--Views--"
        o.OutNL(s.ToString() & vbCrLf & from)
        o.OutNL("GO")

        If (OptRights) Then
            o.OutNL("revoke all on [dbo].[V_" & p.Name & "] to [public]")
            o.OutNL("go")
            o.OutNL("grant select on [dbo].[V_" & p.Name & "] to [public]")
            o.OutNL("go")
        End If
        s = Nothing
        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-" & Err.Description & "<--ERROR"
        s = Nothing
        Exit Sub
        ' Resume
    End Sub


    Private Sub MakeViews(ByRef pv As MTZMetaModel.MTZMetaModel.PARTVIEW)
        Dim s As StringBuilder
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim BP As MTZMetaModel.MTZMetaModel.PART
        Dim p As MTZMetaModel.MTZMetaModel.PART
        Dim refp As MTZMetaModel.MTZMetaModel.PART
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim root As MTZMetaModel.MTZMetaModel.PART
        Dim vc As MTZMetaModel.MTZMetaModel.ViewColumn
        Dim i, j As Integer
        Dim from, group As String
        Dim noagg As Integer
        Dim structfld As String
        Dim pos As MTZMetaModel.MTZMetaModel.PART
        On Error GoTo bye


        BP = pv.Parent.Parent

        s = New StringBuilder

        ' найти раздел первого уровня и построить цепочку прямых join
        root = BP



        from = " from " & BP.Name
        structfld = BP.Name & "ID"
        While TypeName(root.Parent.Parent) <> "OBJECTTYPE"
            pos = root.Parent.Parent
            from = from & vbCrLf & " join " & pos.Name & " on " & pos.Name & "." & pos.Name & "ID=" & root.Name & "." & pos.Name & "ID "
            structfld = structfld & ", " & pos.Name & "." & pos.Name & "ID"
            root = root.Parent.Parent
        End While
        If root.Sequence <> 0 Then
            pos = FindRootPart(root)
            If pos IsNot Nothing Then
                from = from & vbCrLf & " join " & pos.Name & " on " & pos.Name & "." & pos.Name & "ID=" & root.Name & "." & pos.Name & "ID "
                structfld = structfld & ", " & pos.Name & "." & pos.Name & "ID"
            End If

        End If



        group = " group by " & BP.Name & "." & BP.Name & "ID "

        ' стандартное начало

        s.AppendLine(viewDropSQL("V_" & pv.the_Alias))
        s.AppendLine("create view V_" & pv.the_Alias & " as ")


        s.AppendLine("select   " & BP.Name & "." & structfld)

        Dim fcnt As Integer
        fcnt = 1

        MakeViews_PutColumns(pv, fcnt, s, from, log, noagg, group, BP, root)


        s.AppendLine(", " & BP.Name & "." & BP.Name & "ID ID ")
        s.AppendLine(", '" & BP.Name & "' VIEWBASE ")

        ' if no aggregations - no group by
        If noagg = pv.ViewColumn.Count Then group = ""
        'If isButton Then group = ""

        o.ModuleName = "--Views--"
        o.Block = "--Views--"
        o.OutNL(s.ToString() & vbCrLf & from & vbCrLf & group)
        o.OutNL("GO")

        If (OptRights) Then
            o.OutNL("revoke all on [dbo].[V_" & pv.the_Alias & "] to [public]")
            o.OutNL("go")
            o.OutNL("grant select on [dbo].[V_" & pv.the_Alias & "] to [public]")
            o.OutNL("go")
        End If
        s = Nothing
        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-" & Err.Description & "<--ERROR"
        s = Nothing
        Exit Sub
        ' Resume
    End Sub





    Private Function IsParent(ByRef p As MTZMetaModel.MTZMetaModel.PART, ByRef Parent As String) As Boolean
        Dim o As Object
        o = p
        While TypeName(o) <> "OBJECTTYPE"
            o = o.Parent.Parent
            If o.ID = Parent Then
                IsParent = True
                Exit Function
            End If
        End While
        IsParent = False

    End Function


    Public Sub New()
        MyBase.New()

    End Sub


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


    Private Function procDropSQL(ByRef p As String) As String
        Dim s As String
        s = "if exists (select * from sysobjects where id = object_id(N'" & p & "') and OBJECTPROPERTY(id, N'IsProcedure') = 1)"
        s = s & vbCrLf & "drop procedure " & p & ""
        s = s & vbCrLf & "GO"
        procDropSQL = s
    End Function

    Private Function funcDropSQL(ByRef p As String) As String
        Dim s As String
        s = "if exists (select * from sysobjects where id = object_id(N'" & p & "') and xtype in (N'FN', N'IF', N'TF'))"
        s = s & vbCrLf & "drop function " & p & ""
        s = s & vbCrLf & "GO"
        funcDropSQL = s
    End Function

    Private Function indexDropSQL(ByRef tbl As String, ByRef idx As String) As String
        Dim s As String
        s = "if exists (select * from sysindexes where name = N'" & idx & "' and id = object_id(N'" & tbl & "'))"
        s = s & vbCrLf & "drop index " & tbl & "." & idx
        s = s & vbCrLf & "GO"
        indexDropSQL = s
    End Function

    Private Function keyDropSQL(ByRef tbl As String, ByRef key As String) As String
        Dim s As String
        s = "if exists(select * from sysobjects where id=object_id(N'" & key & "') and type='F')"
        s = s & vbCrLf & "ALTER TABLE " & tbl & " DROP CONSTRAINT " & key
        s = s & vbCrLf & "GO"
        keyDropSQL = s
    End Function

    Private Function PkeyDropSQL(ByRef tbl As String, ByRef key As String) As String
        Dim s As String
        s = "if exists(select * from sysobjects where id=object_id(N'" & key & "') and xtype='PK' and type='K')"
        s = s & vbCrLf & "ALTER TABLE " & tbl & " DROP CONSTRAINT " & key
        s = s & vbCrLf & "GO"
        PkeyDropSQL = s
    End Function


    Private Function viewDropSQL(ByRef p As String) As String
        Dim s As String
        s = "if exists (select * from sysobjects where id = object_id(N'" & p & "') and OBJECTPROPERTY(id, N'IsView') = 1)"
        s = s & vbCrLf & "drop view " & p & ""
        s = s & vbCrLf & "GO"
        viewDropSQL = s
    End Function

    Private Function ColumnDropSQL(ByRef t As String, ByRef collist As String) As String
        Dim s As String
        s = "go"
        s = s & vbCrLf & "-- drop extra columns from generated table: " & t
        s = s & vbCrLf & "declare @n nvarchar(255)"
        s = s & vbCrLf & "declare @e_str nvarchar(4000)"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "declare nnn cursor local for"
        s = s & vbCrLf & "select name from syscolumns where id = object_id('" & t & "')"
        s = s & vbCrLf & "and name not in(" & collist & ")"
        s = s & vbCrLf & "open nnn"
        s = s & vbCrLf & "fetch next from nnn into @n"
        s = s & vbCrLf & "while @@fetch_status >=0"
        s = s & vbCrLf & "begin"
        s = s & vbCrLf & "  set @e_str=N'alter table " & t & " drop column '+@n"
        s = s & vbCrLf & "  exec  sp_sqlexec @e_str"
        s = s & vbCrLf & "  fetch next from nnn into @n"
        s = s & vbCrLf & "End"
        s = s & vbCrLf & "Close nnn"
        s = s & vbCrLf & "deallocate nnn"
        s = s & vbCrLf & "go"
        ColumnDropSQL = s
    End Function


End Class
