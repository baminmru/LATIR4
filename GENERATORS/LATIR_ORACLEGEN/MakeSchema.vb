Imports MTZMetaModel.MTZMetaModel
Imports LATIRGenerator


Public Class MakeSchema

    Dim m As MTZMetaModel.MTZMetaModel.Application
    Dim o As LatirGenerator.Response
    Dim tid As String
    Dim parent As Generator

    Public Sub Init(ByVal ap As Generator, ByVal am As MTZMetaModel.MTZMetaModel.Application, ByVal ao As LatirGenerator.Response, ByVal atid As String)
        parent = ap
        m = am
        o = ao
        tid = atid
    End Sub


    Public Sub Run()
        Dim ot As OBJECTTYPE
        Dim j As Long, i As Long
        Dim os As PART
        ' Dim mp As MakePart
        KernelTables()
        For i = 1 To m.OBJECTTYPE.Count
            ot = m.OBJECTTYPE.Item(i)
            For j = 1 To ot.PART.Count
                os = ot.PART.Item(j)
                CreateStruct(os)
            Next
            o.Status("Schema " & ot.Name, i)
        Next
    End Sub




    Private Sub KernelTables()
        Dim SQL As Writer
        SQL = New Writer

        ' DoEvents()
        On Error GoTo bye
        System.Diagnostics.Debug.Print("ORAGEN.KERNEL:start")


        SQL.putBuf("-- Kernel Tables --")

        SQL.putBuf("drop table " + SchemaName + ".sysoptions")
        SQL.putBuf("/")
        SQL.putBuf("create table " + SchemaName + ".sysoptions(")
        SQL.putBuf("sysoptionsID CHAR(38) primary key,")
        SQL.putBuf("Name varchar2(255) null,")
        SQL.putBuf("TheValue varchar2(255) null,")
        SQL.putBuf("OptionType VarChar2(255) null")
        SQL.putBuf(")")
        SQL.putBuf("/")


        SQL.putBuf("drop table " + SchemaName + ".typelist")
        SQL.putBuf("/")
        SQL.putBuf("create  table " + SchemaName + ".typelist(")
        SQL.putBuf("typelistID CHAR(38) primary key  ,")
        SQL.putBuf("Name varchar2(255) not null,")
        SQL.putBuf("SecurityStyleID CHAR(38) null, ")
        SQL.putBuf("RegisterProc varchar2(255) null,")
        SQL.putBuf("DeleteProc varchar2(255) null,")
        SQL.putBuf("HCLProc varchar2(255) null ,")
        SQL.putBuf("PropagateProc varchar2(255) null ")
        SQL.putBuf(")")
        SQL.putBuf("/")


        SQL.putBuf("drop table " + SchemaName + ".Instance")
        SQL.putBuf("/")
        SQL.putBuf("create table " + SchemaName + ".Instance(")
        SQL.putBuf("InstanceID CHAR(38) not null primary key,")
        SQL.putBuf("LockUserID CHAR(38) null, ")
        SQL.putBuf("LockSessionID CHAR(38) null, ")
        SQL.putBuf("SecurityStyleID CHAR(38) null, ")
        SQL.putBuf("Name varchar2(255) null,")
        SQL.putBuf("ObjType varchar2(255) null")
        SQL.putBuf(")")
        SQL.putBuf("/")

        SQL.putBuf("alter table instance add OwnerPartName varchar2(255) null")
        SQL.putBuf("/")

        SQL.putBuf("alter table instance add OwnerRowID CHAR(38) null")
        SQL.putBuf("/")

        SQL.putBuf("alter  table instance add status CHAR(38) null")
        SQL.putBuf("/")

        SQL.putBuf("alter  table instance add archived NUMBER null")
        SQL.putBuf("/")

        SQL.putBuf("drop table " + SchemaName + ".QueryResult")
        SQL.putBuf("/")
        SQL.putBuf("CREATE TABLE " + SchemaName + ".QueryResult (")
        SQL.putBuf("  QueryResultid CHAR(38) NOT NULL ,")
        SQL.putBuf("  result CHAR(38) NULL ")
        SQL.putBuf(")")
        SQL.putBuf("/")

        SQL.putBuf("drop table " + SchemaName + ".RPRESULT")
        SQL.putBuf("/")
        SQL.putBuf("CREATE TABLE " + SchemaName + ".RPRESULT (")
        SQL.putBuf("  RPRESULTID CHAR(38) NOT NULL ,")
        SQL.putBuf("  PARENTLEVEL NUMBER NOT NULL ,")
        SQL.putBuf("  PARTNAME varchar2 (255) NULL ,")
        SQL.putBuf("  THEROWID CHAR(38) NULL ")
        '   sql.putBuf "  ,CONSTRAINT PRIMARY KEY  "
        '   sql.putBuf "  ("
        '   sql.putBuf "    RPRESULTID,"
        '   sql.putBuf "    PARENTLEVEL"
        '   sql.putBuf "  )"
        SQL.putBuf(")")
        SQL.putBuf("/")


        o.ModuleName = "--Tables"
        o.Block = "--kernel"
        o.OutNL(SQL.getBuf)




        System.Diagnostics.Debug.Print("ORAGEN.KERNEL:done")
        Exit Sub
bye:

        System.Diagnostics.Debug.Print("ORAGEN.KERNEL:" & Err.Description)
        'Resume
        'Stop
        SQL = Nothing

    End Sub

    Private Sub CreateStruct(ByVal os As PART)
        System.Diagnostics.Debug.Print("ORAGEN.CreateStruct:start " & os.Caption)
        Dim st As PART
        st = os
        ' DoEvents()
        Dim chos As PART, i As Integer
        Dim s As Writer
        s = New Writer
        Dim collist As String

        'Строка
        'Колекция
        'Дерево


        On Error GoTo bye
        s.putBuf("/*" & os.Caption & "*/")

        's.putBuf "if not exists (select * from sysobjects where id = object_id('" & vf(os.name) & "') and OBJECTPROPERTY(id, 'IsUserTable') = 1)"
        's.putBuf "BEGIN"
        s.putBuf("drop table " + SchemaName + "." & VF(os.Name) & "/*" & os.the_Comment & "*/ ")
        s.putBuf("/")
        s.putBuf("create table " + SchemaName + "." & VF(os.Name) & "/*" & os.the_Comment & "*/ (")
        collist = ""
        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s.putBuf("InstanceID CHAR(38) ,")
            collist = collist & "'InstanceID'"
        Else
            s.putBuf("ParentStructRowID CHAR(38) not null,")
            collist = collist & "'ParentStructRowID'"
        End If

        s.putBuf(VF(os.Name) & "id CHAR(38) not null primary key  ")
        collist = collist & ",'" & VF(os.Name) & "ID' "

        s.putBuf(",ChangeStamp date default (sysdate)  /* Время последнего изменения */")
        collist = collist & ",'ChangeStamp'"


        s.putBuf(",LockSessionID CHAR(38) null  /* temporary lock */")
        collist = collist & ",'LockSessionID'"
        s.putBuf(",LockUserID CHAR(38) null /* checkout lock */")
        collist = collist & ",'LockUserID'"
        s.putBuf(",SecurityStyleID CHAR(38) null /* security formula */")
        collist = collist & ",'SecurityStyleID'"

        ' дерево
        If os.PartType = 2 Then
            s.putBuf(",ParentRowid CHAR(38) ")
            collist = collist & ",'ParentRowid'"
        End If

        s.putBuf(")")
        's.putBuf "END"
        s.putBuf("/")

        st.FIELD.Sort = "sequence"
        Dim ft As FIELDTYPE
        For i = 1 To st.FIELD.Count
            'If i > 1 Then

            's.putbuf ","
            's.putBuf "if  not exists(select * from syscolumns where name='" & vf(st.FIELD.Item(i).Name) & "' and id=object_id('" & st.Name & "'))"
            s.putBuf("alter  table " + SchemaName + "." & VF(st.Name) & " add ")
            s.putBuf(parent.FieldForCreate(st.FIELD.Item(i)))
            s.putBuf("/")
            collist = collist & ",'" & VF(st.FIELD.Item(i).Name) & "'"
            ft = st.FIELD.Item(i).FieldType
            'support extention field if file type used
            If UCase(ft.Name) = "FILE" Then
                's.putBuf "if  not exists(select * from syscolumns where name='" & vf(st.FIELD.Item(i).Name) & "_EXT' and id=object_id('" & st.Name & "'))"
                s.putBuf("alter  table " + SchemaName + "." & VF(st.Name) & " add ")
                s.putBuf(" " & VF(st.FIELD.Item(i).Name) & "_EXT varchar2(4) null")
                collist = collist & ",'" & VF(st.FIELD.Item(i).Name) & "_EXT'"
                s.putBuf("/")
            End If

        Next

        o.ModuleName = "--Tables"
        o.Block = "--body"
        o.OutNL(s.getBuf)



        If TypeName(os.Parent.Parent) <> "OBJECTTYPE" Then
            s = Nothing
            s = New Writer
            s.putBuf(parent.keyDropSQL(os.Name, "fk_" & parent.FKMap(os.ID.ToString())))
            s.putBuf("alter  table " + SchemaName + "." & VF(os.Name) & " add constraint fk_" & parent.FKMap(os.ID.ToString()) & " foreign key(ParentStructRowID) references " + SchemaName + "." & VF(CType(os.Parent.Parent, PART).Name) & " (" & VF(CType(os.Parent.Parent, PART).Name) & "ID)")
            s.putBuf("/")
            o.ModuleName = "--Tables"
            o.Block = "--ForeignKey"
            o.OutNL(s.getBuf)


            s = Nothing
            s = New Writer
            s.putBuf(parent.indexDropSQL(os.Name, "parent_" & VF(os.Name)))
            s.putBuf("create index " + SchemaName + ".parent_" & VF(os.Name) & " on " + SchemaName + "." & VF(os.Name) & "(ParentStructRowID)")
            s.putBuf("/")
            o.ModuleName = "--Tables"
            o.Block = "--Index"
            o.OutNL(s.getBuf)

        Else
            s = Nothing
            s = New Writer
            s.putBuf(parent.keyDropSQL(os.Name, "fk_" & parent.FKMap(os.ID.ToString)))
            s.putBuf("alter  table " + SchemaName + "." & VF(os.Name) & " add constraint fk_" & parent.FKMap(os.ID.ToString) & " foreign key(INSTANCEID) references " + SchemaName + ".INSTANCE (INSTANCEID)")
            s.putBuf("/")
            o.ModuleName = "--Tables"
            o.Block = "--ForeignKey"
            o.OutNL(s.getBuf)



            s = Nothing
            s = New Writer
            s.putBuf(parent.indexDropSQL(os.Name, "parent_" & VF(os.Name)))
            s.putBuf("create index " + SchemaName + ".parent_" & VF(os.Name) & " on " + SchemaName + "." & VF(os.Name) & "(""INSTANCEID"")")
            s.putBuf("/")
            o.ModuleName = "--Tables"
            o.Block = "--Index"
            o.OutNL(s.getBuf)

        End If


        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            CreateStruct(chos)
        Next

        s = Nothing

        Exit Sub
bye:

        System.Diagnostics.Debug.Print("ORAGEN.CreateStruct: " & os.Caption & " " & Err.Description)
        'Resume
        s = Nothing

    End Sub


    Friend Function ColumnDropSQL(ByVal t As String, ByVal collist As String) As String
        Dim s As String
        s = " "
        '    s = s & vbCrLf & "-- drop extra columns from generated table: " & t
        '    s = s & vbCrLf & "an varchar2(255)"
        '    s = s & vbCrLf & "ae_str varchar2(4000)"
        '    s = s & vbCrLf & ""
        '    s = s & vbCrLf & "nnn declare cursor local for"
        '    s = s & vbCrLf & "select name from syscolumns where id = object_id('" & t & "')"
        '    s = s & vbCrLf & "and name not in(" & collist & ")"
        '    s = s & vbCrLf & "--open nnn"
        '    s = s & vbCrLf & "fetch next from nnn into an"
        '    s = s & vbCrLf & "while aafetch_status >=0"
        '    s = s & vbCrLf & "begin"
        '    s = s & vbCrLf & "  set ae_str='create or replace  table " + t + " drop column '+an"
        '    s = s & vbCrLf & "   sp_sqlae_str"
        '    s = s & vbCrLf & "  fetch next from nnn into an"
        '    s = s & vbCrLf & "End"
        '    s = s & vbCrLf & "Close nnn"
        '    s = s & vbCrLf & "deallocate nnn"
        ColumnDropSQL = s
    End Function



End Class