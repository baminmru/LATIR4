Imports MTZMetaModel.MTZMetaModel
Imports LATIRGenerator

Public Class MakeSchema

    Dim m As MTZMetaModel.MTZMetaModel.Application
    Dim o As LATIRGenerator.Response
    Dim tid As String
    Dim parent As Generator

    Public Sub Init(ByRef ap As Generator, ByRef am As MTZMetaModel.MTZMetaModel.Application, ByRef ao As LATIRGenerator.Response, ByVal atid As String)
        parent = ap
        m = am
        o = ao
        tid = atid
    End Sub


    Public Sub Run()
        Dim ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Dim j, i As Integer
        Dim os As MTZMetaModel.MTZMetaModel.PART
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

        System.Windows.Forms.Application.DoEvents()
        On Error GoTo bye
        System.Diagnostics.Debug.Print("POSTGRESGEN.KERNEL:start")


        SQL.putBuf("-- Kernel Tables --")

        SQL.putBuf("drop table sysoptions")
        SQL.putBuf(";")
        SQL.putBuf("GO")
        SQL.putBuf("create table sysoptions(")
        SQL.putBuf("sysoptionsID uuid primary key,")
        SQL.putBuf("Name varchar(255) null,")
        SQL.putBuf("TheValue varchar(255) null,")
        SQL.putBuf("OptionType varchar(255) null")
        SQL.putBuf(")")
        SQL.putBuf(";")
        SQL.putBuf("GO")


        SQL.putBuf("drop table typelist")
        SQL.putBuf(";")
        SQL.putBuf("GO")
        SQL.putBuf("create  table typelist(")
        SQL.putBuf("typelistID uuid primary key  ,")
        SQL.putBuf("Name varchar(255) not null,")
        SQL.putBuf("SecurityStyleID uuid null, ")
        SQL.putBuf("RegisterProc varchar(255) null,")
        SQL.putBuf("DeleteProc varchar(255) null,")
        SQL.putBuf("HCLProc varchar(255) null ,")
        SQL.putBuf("PropagateProc varchar(255) null ")
        SQL.putBuf(")")
        SQL.putBuf(";")
        SQL.putBuf("GO")


        SQL.putBuf("drop table Instance")
        SQL.putBuf(";")
        SQL.putBuf("GO")
        SQL.putBuf("create table Instance(")
        SQL.putBuf("InstanceID uuid not null primary key,")
        SQL.putBuf("LockUserID uuid null, ")
        SQL.putBuf("LockSessionID uuid null, ")
        SQL.putBuf("SecurityStyleID uuid null, ")
        SQL.putBuf("Name varchar(255) null,")
        SQL.putBuf("ObjType varchar(255) null")
        SQL.putBuf(")")
        SQL.putBuf(";")
        SQL.putBuf("GO")

        SQL.putBuf("alter table instance add OwnerPartName varchar(255) null")
        SQL.putBuf(";")
        SQL.putBuf("GO")

        SQL.putBuf("alter table instance add OwnerRowID uuid null")
        SQL.putBuf(";")
        SQL.putBuf("GO")

        SQL.putBuf("alter  table instance add status uuid null")
        SQL.putBuf(";")
        SQL.putBuf("GO")

        SQL.putBuf("alter  table instance add archived numeric null")
        SQL.putBuf(";")
        SQL.putBuf("GO")

        SQL.putBuf("drop table QueryResult")
        SQL.putBuf(";")
        SQL.putBuf("GO")
        SQL.putBuf("CREATE TABLE QueryResult (")
        SQL.putBuf("  QueryResultid uuid NOT NULL ,")
        SQL.putBuf("  result uuid NULL ")
        SQL.putBuf(")")
        SQL.putBuf(";")
        SQL.putBuf("GO")

        SQL.putBuf("drop table RPRESULT")
        SQL.putBuf(";")
        SQL.putBuf("GO")
        SQL.putBuf("CREATE TABLE RPRESULT (")
        SQL.putBuf("  RPRESULTID uuid NOT NULL ,")
        SQL.putBuf("  PARENTLEVEL numeric NOT NULL ,")
        SQL.putBuf("  PARTNAME varchar (255) NULL ,")
        SQL.putBuf("  THEROWID uuid NULL ")
        '   sql.putBuf "  ,CONSTRAINT PRIMARY KEY  "
        '   sql.putBuf "  ("
        '   sql.putBuf "    RPRESULTID,"
        '   sql.putBuf "    PARENTLEVEL"
        '   sql.putBuf "  )"
        SQL.putBuf(")")
        SQL.putBuf(";")
        SQL.putBuf("GO")

        SQL.putBuf("drop table PG_Pager")
        SQL.putBuf(";")
        SQL.putBuf("GO")
        SQL.putBuf("   CREATE TABLE PG_Pager (")
        SQL.putBuf("              PagerID uuid NOT NULL ,")
        SQL.putBuf("              ViewID uuid NOT NULL ,")
        SQL.putBuf("              Sequence serial  NOT NULL ,")
        SQL.putBuf("              SessionID uuid NULL ,")
        SQL.putBuf("              Primary key")
        SQL.putBuf("              (  PagerID, ViewID, Sequence  )")
        SQL.putBuf("           );")
        SQL.putBuf("GO")

        o.ModuleName = "--Tables"
        o.Block = "--kernel"
        o.OutNL(SQL.getBuf)




        System.Diagnostics.Debug.Print("POSTGRESGEN.KERNEL:done")
        Exit Sub
bye:

        System.Diagnostics.Debug.Print("POSTGRESGEN.KERNEL:" & Err.Description)
        'Resume
        'Stop
        SQL = Nothing

    End Sub

    Private Sub CreateStruct(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        System.Diagnostics.Debug.Print("POSTGRESGEN.CreateStruct:start " & os.Caption)
        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        System.Windows.Forms.Application.DoEvents()
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim i As Short
        Dim s As Writer
        s = New Writer
        Dim collist As String

        'Строка
        'Колекция
        'Дерево
       

        On Error GoTo bye
        s.putBuf("/*" & os.Caption & "*/")

        
        s.putBuf("drop table " & VF(os.Name) & "/*" & os.the_Comment & "*/ ")
        s.putBuf(";")
        s.putBuf("GO")
        s.putBuf("create table " & VF(os.Name) & "/*" & os.the_Comment & "*/ (")
        collist = ""
        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s.putBuf("InstanceID uuid ,")
            collist = collist & "'InstanceID'"
        Else
            s.putBuf("ParentStructRowID uuid not null,")
            collist = collist & "'ParentStructRowID'"
        End If

        s.putBuf(VF(os.Name) & "id uuid not null default (uuid_generate_v4()) primary key  ")
        collist = collist & ",'" & VF(os.Name) & "ID' "

        s.putBuf(",ChangeStamp timestamp null default(LOCALTIMESTAMP)  /* Время последнего изменения */")
        collist = collist & ",'ChangeStamp'"


        s.putBuf(",LockSessionID uuid null  /* temporary lock */")
        collist = collist & ",'LockSessionID'"
        s.putBuf(",LockUserID uuid null /* checkout lock */")
        collist = collist & ",'LockUserID'"
        s.putBuf(",SecurityStyleID uuid null /* security formula */")
        collist = collist & ",'SecurityStyleID'"

        ' дерево
        If os.PartType = 2 Then
            s.putBuf(",ParentRowid uuid ")
            collist = collist & ",'ParentRowid'"
        End If

        s.putBuf(")")
        's.putBuf "END"
        s.putBuf(";")
        s.putBuf("GO")

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            ft = st.FIELD.Item(i).FieldType
            s.putBuf("alter  table " & VF(st.Name) & " add ")
            s.putBuf(parent.FieldForCreate(st.FIELD.Item(i)))
            s.putBuf(";")
            s.putBuf("GO")
            collist = collist & ",'" & VF(st.FIELD.Item(i).Name) & "'"

            'support extention field if file type used
            If UCase(ft.Name) = "FILE" Then
                s.putBuf("alter  table " & VF(st.Name) & " add ")
                s.putBuf(" " & VF(st.FIELD.Item(i).Name) & "_EXT char(4) null")
                collist = collist & ",'" & VF(st.FIELD.Item(i).Name) & "_EXT'"
                s.putBuf(";")
                s.putBuf("GO")
            End If

        Next

        o.ModuleName = "--Tables"
        o.Block = "--body"
        o.OutNL(s.getBuf)



        If TypeName(os.Parent.Parent) <> "OBJECTTYPE" Then
            s = Nothing
            s = New Writer
            s.putBuf(parent.keyDropSQL((os.Name), "fk_" & parent.FKMap((os.ID.ToString))))
            s.putBuf("GO")
            s.putBuf("alter  table " & VF(os.Name) & " add constraint fk_" & parent.FKMap((os.ID.ToString)) & " foreign key(ParentStructRowID) references " & VF(CType(os.Parent.Parent, PART).Name) & " (" & VF(CType(os.Parent.Parent, PART).Name) & "ID)")
            s.putBuf(";")
            s.putBuf("GO")
            o.ModuleName = "--Tables"
            o.Block = "--ForeignKey"
            o.OutNL(s.getBuf)


            s = Nothing
            s = New Writer
            s.putBuf(parent.indexDropSQL((os.Name), "parent_" & VF(os.Name)))
            s.putBuf("GO")
            s.putBuf("create index parent_" & VF(os.Name) & " on " & VF(os.Name) & "(ParentStructRowID)")
            s.putBuf(";")
            s.putBuf("GO")
            o.ModuleName = "--Tables"
            o.Block = "--Index"
            o.OutNL(s.getBuf)

        Else
            s = Nothing
            s = New Writer
            s.putBuf(parent.keyDropSQL((os.Name), "fk_" & parent.FKMap((os.ID.ToString))))
            s.putBuf("GO")
            s.putBuf("alter  table " & VF(os.Name) & " add constraint fk_" & parent.FKMap((os.ID.ToString)) & " foreign key(INSTANCEID) references INSTANCE (INSTANCEID)")
            s.putBuf(";")
            s.putBuf("GO")
            o.ModuleName = "--Tables"
            o.Block = "--ForeignKey"
            o.OutNL(s.getBuf)



            s = Nothing
            s = New Writer
            s.putBuf(parent.indexDropSQL((os.Name), "parent_" & VF(os.Name)))
            s.putBuf("GO")
            s.putBuf("create index parent_" & VF(os.Name) & " on " & VF(os.Name) & "(INSTANCEID)")
            s.putBuf(";")
            s.putBuf("GO")
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
        System.Diagnostics.Debug.Print("POSTGRESGEN.CreateStruct: " & os.Caption & " " & Err.Description)
        s = Nothing

    End Sub


    Friend Function ColumnDropSQL(ByRef t As String, ByRef collist As String) As String
        Dim s As String
        s = " "
        '    s = s & vbCrLf & "-- drop extra columns from generated table: " & t
        '    s = s & vbCrLf & "an varchar(255)"
        '    s = s & vbCrLf & "ae_str varchar(4000)"
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