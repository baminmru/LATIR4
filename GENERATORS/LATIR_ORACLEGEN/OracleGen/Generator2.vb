Imports MTZMetaModel.MTZMetaModel
Imports LATIRGenerator



Public Class Generator2

    Dim m As Application
    Dim o As LATIRGenerator.Response
    Dim tid As String
    Dim log As String

    Dim pre As Preprocessor


    Private Sub Kernel()
        Dim sql As String
        sql = "-- Kernel Tables --"
        sql = sql & vbCrLf & "create table sysoptions("
        sql = sql & vbCrLf & "sysoptionsID uniqueidentifier primary key rowguidcol default (newid()),"
        sql = sql & vbCrLf & "Name varchar(255) null,"
        sql = sql & vbCrLf & "Value varchar(255) null,"
        sql = sql & vbCrLf & "OptionType VarChar(255) null"
        sql = sql & vbCrLf & ")"
        sql = sql & vbCrLf & "go"

        sql = sql & vbCrLf & "create table typelist("
        sql = sql & vbCrLf & "typelistID uniqueidentifier primary key rowguidcol default (newid()),"
        sql = sql & vbCrLf & "Name varchar(255) not null,"
        sql = sql & vbCrLf & "RegisterProc varchar(255) null,"
        sql = sql & vbCrLf & "DeleteProc VarChar(255) null"
        sql = sql & vbCrLf & ")"
        sql = sql & vbCrLf & "go"


        sql = sql & vbCrLf & "create table Instance("
        sql = sql & vbCrLf & "InstanceID uniqueidentifier primary key  rowguidcol default (newid()),"
        sql = sql & vbCrLf & "Name varchar(255) null,"
        sql = sql & vbCrLf & "ObjType VarChar(255)"
        sql = sql & vbCrLf & ")"
        sql = sql & vbCrLf & "go"



        sql = sql & vbCrLf & "CREATE TABLE [QueryResult] ("
        sql = sql & vbCrLf & "[QueryResultid] [uniqueidentifier] NOT NULL ,"
        sql = sql & vbCrLf & "  [result] [uniqueidentifier] NULL ,"
        sql = sql & vbCrLf & ")"
        sql = sql & vbCrLf & "GO"

        o.ModuleName = "--Kernel tables"
        o.Block = "--body"
        o.OutNL(sql)


        sql = ""
        sql = sql & vbCrLf & "create proc SysOptions_Save ( @SysOptionsid uniqueidentifier, @Name varchar(255),@Value varchar (255), @OptionType varchar(255)) as"
        sql = sql & vbCrLf & "begin"
        sql = sql & vbCrLf & "if exists( select 1 from sysoptions where sysoptionsid=@sysoptionsid)"
        sql = sql & vbCrLf & "update sysoptions set Name=@Name, Value=@Value, OptionType=@OptionType where sysoptionsid=@sysoptionsid"
        sql = sql & vbCrLf & "Else"
        sql = sql & vbCrLf & "insert into sysoptions (sysoptionsid, Name, Value, OptionType)values(@sysoptionsid,@Name,@Value,@OptionType)"
        sql = sql & vbCrLf & "End"
        sql = sql & vbCrLf & "go"
        sql = sql & vbCrLf & ""
        sql = sql & vbCrLf & "create proc Instance_Save ("
        sql = sql & vbCrLf & "@CURSESSION uniqueidentifier,"
        sql = sql & vbCrLf & "@InstanceID uniqueidentifier,"
        sql = sql & vbCrLf & "@ObjType varchar(255),"
        sql = sql & vbCrLf & "@Name varchar(255)"
        sql = sql & vbCrLf & ") as"
        sql = sql & vbCrLf & "begin"
        sql = sql & vbCrLf & "declare @tmpStr varchar(255)"
        sql = sql & vbCrLf & "if exists( select 1 from instance where instanceid=@instanceid )"
        sql = sql & vbCrLf & "  update instance set name = @name where  instanceid=@instanceid"
        sql = sql & vbCrLf & "Else"
        sql = sql & vbCrLf & "  begin"
        sql = sql & vbCrLf & "    if exists( select 1 from typelist where name = @objtype)"
        sql = sql & vbCrLf & "    begin"
        sql = sql & vbCrLf & "      begin tran"
        sql = sql & vbCrLf & "      insert into instance(instanceid,name,objtype) values(@instanceid,@name,@objtype)"
        '  sql = sql & vbCrLf & "      set @tmpStr = 'TYPE=' + @objtype"
        '  sql = sql & vbCrLf & "      exec RegisterResource @cursession=@cursession,@parent=@tmpStr,@resource=@instanceid"
        '  sql = sql & vbCrLf & "      select @tmpstr =RegisterProc from typelist where name = @objtype"
        '  sql = sql & vbCrLf & "      if not @tmpstr is null"
        '  sql = sql & vbCrLf & "        exec @tmpstr @cursession = @cursession, @instanceid =@instanceid"
        sql = sql & vbCrLf & "      if @@trancount >0 commit tran"
        sql = sql & vbCrLf & "    End"
        sql = sql & vbCrLf & "  End"
        sql = sql & vbCrLf & "End"
        sql = sql & vbCrLf & "go"
        sql = sql & vbCrLf & "create proc Instance_DELETE ("
        sql = sql & vbCrLf & "@CURSESSION uniqueidentifier,"
        sql = sql & vbCrLf & "@InstanceID uniqueidentifier"
        sql = sql & vbCrLf & ") as"
        sql = sql & vbCrLf & "begin"
        sql = sql & vbCrLf & "declare @tmpStr varchar(255)"
        sql = sql & vbCrLf & "declare @ObjType varchar(255)"
        sql = sql & vbCrLf & "if exists( select 1 from instance where instanceid=@instanceid )"
        sql = sql & vbCrLf & "    begin"
        sql = sql & vbCrLf & "      select @objtype = objtype from instance where instanceid=@instanceid"
        sql = sql & vbCrLf & "      select @tmpstr =DeleteProc from typelist where name = @objtype"
        sql = sql & vbCrLf & "      begin tran"
        sql = sql & vbCrLf & "      if not @tmpstr is null"
        sql = sql & vbCrLf & "        exec @tmpstr @cursession = @cursession, @instanceid =@instanceid"
        sql = sql & vbCrLf & "      if @@trancount =0 return"
        'sql = sql & vbCrLf & "      exec UnRegisterResource @cursession=@cursession,@resource=@instanceid"
        sql = sql & vbCrLf & "      delete from instance where instanceid=@instanceid"
        sql = sql & vbCrLf & "      if @@trancount >0 commit tran"
        sql = sql & vbCrLf & "    End"
        sql = sql & vbCrLf & "End"
        sql = sql & vbCrLf & "go"


        sql = sql & vbCrLf & "  create function instance_BRIEF_F  ("
        sql = sql & vbCrLf & " @instanceid uniqueidentifier"
        sql = sql & vbCrLf & ")returns varchar(4000) as  begin"
        sql = sql & vbCrLf & " declare @BRIEF varchar(4000)"
        sql = sql & vbCrLf & "if @instanceid is null begin set @BRIEF='' return (@BRIEF) end"
        sql = sql & vbCrLf & " -- Brief body --"
        sql = sql & vbCrLf & "if exists(select 1 from instance where instanceID=@instanceID)"
        sql = sql & vbCrLf & " begin"
        sql = sql & vbCrLf & "  set @BRIEF=''"
        sql = sql & vbCrLf & "  set @BRIEF= @BRIEF + '��������='"
        sql = sql & vbCrLf & "  select @BRIEF= @BRIEF"
        sql = sql & vbCrLf & "  +  isnull(Name,'???')+'; '"
        sql = sql & vbCrLf & "  from instance  where  instanceID = @instanceID"
        sql = sql & vbCrLf & "  set @BRIEF= @BRIEF + '���='"
        sql = sql & vbCrLf & "  select @BRIEF= @BRIEF"
        sql = sql & vbCrLf & "  +  isnull(objtype,'???')+'; '"
        sql = sql & vbCrLf & "  from instance  where  instanceID = @instanceID"
        sql = sql & vbCrLf & "end else begin"
        sql = sql & vbCrLf & "  set @BRIEF= '�������� �������������'"
        sql = sql & vbCrLf & "End"
        sql = sql & vbCrLf & "set @BRIEF=left(@BRIEF,4000)"
        sql = sql & vbCrLf & "  return (@BRIEF)"
        sql = sql & vbCrLf & "End"
        sql = sql & vbCrLf & ""
        sql = sql & vbCrLf & "GO"



        sql = sql & vbCrLf & "  create proc instance_BRIEF  ("
        sql = sql & vbCrLf & " @CURSESSION uniqueidentifier,"
        sql = sql & vbCrLf & " @instanceid uniqueidentifier,"
        sql = sql & vbCrLf & " @BRIEF varchar(4000) output"
        sql = sql & vbCrLf & ") as  begin"
        sql = sql & vbCrLf & "set nocount on"
        sql = sql & vbCrLf & " declare @tmpStr varchar(255)"
        sql = sql & vbCrLf & " declare @access int"
        sql = sql & vbCrLf & " declare @tmpBrief varchar(4000)"
        sql = sql & vbCrLf & " declare @tmpID uniqueidentifier"

        sql = sql & vbCrLf & "if @instanceid is null begin set @BRIEF='' return end"
        sql = sql & vbCrLf & " -- Brief body --"
        sql = sql & vbCrLf & "if exists(select 1 from instance where instanceID=@instanceID)"
        sql = sql & vbCrLf & " begin"
        sql = sql & vbCrLf & "  set @BRIEF=''"
        sql = sql & vbCrLf & "  set @BRIEF= @BRIEF + '��������='"
        sql = sql & vbCrLf & "  select @BRIEF= @BRIEF"
        sql = sql & vbCrLf & "  +  isnull(Name,'???')+'; '"
        sql = sql & vbCrLf & "  from instance  where  instanceID = @instanceID"
        sql = sql & vbCrLf & "  set @BRIEF= @BRIEF + '���='"
        sql = sql & vbCrLf & "  select @BRIEF= @BRIEF"
        sql = sql & vbCrLf & "  +  isnull(objtype,'???')+'; '"
        sql = sql & vbCrLf & "  from instance  where  instanceID = @instanceID"
        sql = sql & vbCrLf & "end else begin"
        sql = sql & vbCrLf & "  set @BRIEF= '�������� �������������'"
        sql = sql & vbCrLf & "End"
        sql = sql & vbCrLf & "set @BRIEF=left(@BRIEF,4000)"
        sql = sql & vbCrLf & "End"
        sql = sql & vbCrLf & ""
        sql = sql & vbCrLf & "GO"

        sql = sql & vbCrLf & "create proc QR_and_QR( @id1 uniqueidentifier, @id2 uniqueidentifier,@idout uniqueidentifier,@cnt integer out)"
        sql = sql & vbCrLf & "as"
        sql = sql & vbCrLf & "delete from QueryResult where QueryResultid=@idout"
        sql = sql & vbCrLf & "insert into QueryResult(QueryResultid,result)"
        sql = sql & vbCrLf & "select distinct @idout, a.result"
        sql = sql & vbCrLf & "from QueryResult a"
        sql = sql & vbCrLf & "join QueryResult b on b.QueryResultid=@id2 and a.result=b.result"
        sql = sql & vbCrLf & "where a.QueryResultid=@id1"
        sql = sql & vbCrLf & "select @cnt=count(*) from QueryResult where QueryResultid=@idout"
        sql = sql & vbCrLf & "go"
        sql = sql & vbCrLf & ""
        sql = sql & vbCrLf & "create proc QR_or_QR( @id1 uniqueidentifier, @id2 uniqueidentifier,@idout uniqueidentifier,@cnt integer out)"
        sql = sql & vbCrLf & "as"
        sql = sql & vbCrLf & "delete from QueryResult where QueryResultid=@idout"
        sql = sql & vbCrLf & ""
        sql = sql & vbCrLf & "insert into QueryResult(QueryResultid,result)"
        sql = sql & vbCrLf & "select distinct @idout, result from QueryResult where QueryResultid in (@id1,@id2)"
        sql = sql & vbCrLf & ""
        sql = sql & vbCrLf & "select @cnt=count(*) from QueryResult where QueryResultid=@idout"
        sql = sql & vbCrLf & "GO"

        o.ModuleName = "--Kernel procs"
        o.Block = "--body"
        o.OutNL(sql)

    End Sub


    Public Function Run(ByVal Model As Object, ByVal Output As Object, ByVal targetid As String) As String
        m = Model
        o = Output
        tid = targetid
        log = ""

        'InitHost()


        Kernel()

        Dim i As Long, j As Long
        Dim os As PART


        On Error GoTo bye
        For i = 1 To m.OBJECTTYPE.Count
            log = log & vbCrLf & "Create code for type " & m.OBJECTTYPE.Item(i).Name
            o.ModuleName = "--Tables"
            o.Block = "--body"
            o.OutNL("/* TYPE=" & m.OBJECTTYPE.Item(i).Name & " (" & m.OBJECTTYPE.Item(i).the_Comment & ") */")
            o.OutNL("GO")

            For j = 1 To m.OBJECTTYPE.Item(i).PART.Count
                os = m.OBJECTTYPE.Item(i).PART.Item(j)
                CreateStruct(os)
                CreateProc(os)
            Next
            CreateTypeProcs(m.OBJECTTYPE.Item(i))

        Next



        For i = 1 To m.SHAREDMETHOD.Count
            CreateMethod(m.SHAREDMETHOD.Item(i))
        Next

        ' MakeJournals


        LoadOptions()
        Run = log

        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'MsgBox Err.Description
        Run = log

    End Function

    Private Sub CreateStruct(ByVal os As PART)
        Dim st As PART
        st = os
        Dim chos As PART, i As Integer
        Dim s As String

        '������
        '��������
        '������
        '����
        log = log & vbCrLf & "-->CreateStruct " & os.Name


        On Error GoTo bye
        s = "/*" & os.Caption & "*/"
        s = s & vbCrLf & "create table " & os.Name & "/*" & os.the_Comment & "*/ ("

        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s = s & vbCrLf & "InstanceID uniqueidentifier ,"
        Else
            s = s & vbCrLf & "ParentStructRowID uniqueidentifier not null,"
        End If

        s = s & os.Name & "id uniqueidentifier not null rowguidcol default ( newid()) primary key "
        s = s & vbCrLf & ",ChangeStamp datetime not null default ( getdate()) /* ����� ���������� ��������� */"

        s = s & vbCrLf & ",LockSessionID uniqueidentifier null  /* temporary lock */"
        s = s & vbCrLf & ",LockUserID uniqueidentifier null /* checkout lock */"
        s = s & vbCrLf & ",SecurityStyleID uniqueidentifier null /* security formula */"

        ' ������
        If os.PartType = 2 Then
            s = s & vbCrLf & ",ParentRowid uniqueidentifier "
        End If

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            'If i > 1 Then
            s = s & vbCrLf & ","
            s = s & FieldForCreate(st.FIELD.Item(i))
        Next

        s = s & vbCrLf & ")"
        o.ModuleName = "--Tables"
        o.Block = "--body"
        o.OutNL(s)
        o.OutNL("GO")


        If TypeName(os.Parent.Parent) <> "OBJECTTYPE" Then
            s = ""
            s = s & vbCrLf & "alter table " & os.Name & " add constraint fk_" & MakeName(os.ID.ToString) & " foreign key(ParentStructRowID) references " & CType(os.Parent.Parent, PART).Name & " (" & CType(os.Parent.Parent, PART).Name & "ID)"
            o.ModuleName = "--Tables"
            o.Block = "--ForeignKey"
            o.OutNL(s)
            o.OutNL("GO")

            s = ""
            s = s & vbCrLf & "create index parent_" & os.Name & " on " & os.Name & "(ParentStructRowID)"
            o.ModuleName = "--Tables"
            o.Block = "--Index"
            o.OutNL(s)
            o.OutNL("GO")
        Else
            s = ""
            s = s & vbCrLf & "alter table " & os.Name & " add constraint fk_" & MakeName(os.ID.ToString) & " foreign key(INSTANCEID) references INSTANCE (INSTANCEID)"
            o.ModuleName = "--Tables"
            o.Block = "--ForeignKey"
            o.OutNL(s)
            o.OutNL("GO")

            s = ""
            s = s & vbCrLf & "create index parent_" & os.Name & " on " & os.Name & "(INSTANCEID)"
            o.ModuleName = "--Tables"
            o.Block = "--Index"
            o.OutNL(s)
            o.OutNL("GO")
        End If




        For i = 1 To os.PARTVIEW.Count
            MakeViews(os.PARTVIEW.Item(i))
        Next

        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            CreateStruct(chos)
        Next


        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
    End Sub


    Private Sub CreateDelProc(ByVal os As PART)
        Dim st As PART
        st = os
        Dim chos As PART, i As Integer
        Dim s As String


        log = log & vbCrLf & "-->CreateDelProc " & os.Name

        On Error GoTo bye

        s = vbCrLf
        s = s & vbCrLf & "create proc " & os.Name & "_DELETE /*" & os.the_Comment & "*/ ("
        s = s & vbCrLf & " @CURSESSION uniqueidentifier,"
        s = s & vbCrLf & " @" & os.Name & "id uniqueidentifier"
        s = s & vbCrLf & ") as " & " begin  "
        s = s & vbCrLf & "set nocount on"

        If Not os.NoLog Then s = s & vbCrLf & " declare @SysLogID uniqueidentifier"
        s = s & vbCrLf & " declare @access int"
        s = s & vbCrLf & " declare @SysInstID uniqueidentifier"
        s = s & vbCrLf & " select @SysInstID =Instanceid from instance where objtype='SYSTEM'"



        s = s & vbCrLf & " -- Delete body -- "
        s = s & vbCrLf & "if exists(select 1 from " & os.Name & " where " & os.Name & "ID=@" & os.Name & "ID)"
        s = s & vbCrLf & " begin"



        s = s & vbCrLf & "  begin tran  "

        s = s & vbCrLf & " -- erase child items --"
        s = s & vbCrLf & "declare @childlistid uniqueidentifier"




        If os.PART.Count > 0 Then
            s = s & vbCrLf & "-- delete in-struct child"
        End If

        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            s = s & vbCrLf & "declare childlist_" & chos.Name & " cursor for select " & chos.Name & "." & chos.Name & "id from " & chos.Name & " where  " & chos.Name & ".ParentStructRowID = @" & os.Name & "id"
            s = s & vbCrLf & "open childlist_" & chos.Name & ""
            s = s & vbCrLf & "fetch next from childlist_" & chos.Name & " into @childlistid"
            s = s & vbCrLf & "while @@fetch_status >=0 "
            s = s & vbCrLf & "begin"
            s = s & vbCrLf & " exec " & chos.Name & "_DELETE @cursession,@childlistid"
            s = s & vbCrLf & " if @@error >0 begin"
            s = s & vbCrLf & "   close childlist_" & chos.Name & ""
            s = s & vbCrLf & "   deallocate childlist_" & chos.Name & " "
            s = s & vbCrLf & "   goto del_error"
            s = s & vbCrLf & " end"
            s = s & vbCrLf & " fetch next from childlist_" & chos.Name & " into @childlistid"
            s = s & vbCrLf & "end"
            s = s & vbCrLf & "close childlist_" & chos.Name & ""
            s = s & vbCrLf & "deallocate childlist_" & chos.Name & " "
        Next

        s = s & vbCrLf

        s = s & vbCrLf & "  delete from  " & os.Name & " "
        s = s & vbCrLf & "  where  " & os.Name & "ID = @" & os.Name & "ID "

        s = s & vbCrLf & " end"
        s = s & vbCrLf & " -- close transaction --"
        s = s & vbCrLf & " del_error:"
        s = s & vbCrLf & " if @@error <>0  if @@trancount>0 rollback tran  "
        s = s & vbCrLf & " if @@trancount>0 commit tran  "

        s = s & vbCrLf & " end "
        o.ModuleName = "--Procedures"
        o.Block = "--TableProc"
        o.OutNL(s)
        o.OutNL("GO")
        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume

    End Sub



    Private Sub CreateProc(ByVal os As PART)
        Dim st As PART
        st = os
        Dim chos As PART, i As Integer
        Dim ft As FIELDTYPE
        Dim s As String


        log = log & vbCrLf & "-->CreateProc " & os.Name

        On Error GoTo bye

        s = "/*" & os.Caption & "*/"
        s = s & vbCrLf & "create proc " & os.Name & "_SAVE /*" & os.the_Comment & "*/ ("
        s = s & vbCrLf & " @CURSESSION uniqueidentifier,"

        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s = s & vbCrLf & "@InstanceID uniqueidentifier ,"
        Else
            s = s & vbCrLf & " @ParentStructRowID uniqueidentifier =null,"
        End If

        s = s & vbCrLf & " @" & os.Name & "id uniqueidentifier"

        ' ������ - ������������ �����
        If os.PartType = 2 Then
            s = s & vbCrLf & ",@ParentRowid uniqueidentifier = null "
        End If

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            s = s & vbCrLf & "," & FieldForParam(st.FIELD.Item(i))
        Next

        s = s & vbCrLf & ") as " & " begin  "

        s = s & vbCrLf & "set nocount on"


        If Not os.NoLog Then s = s & vbCrLf & "DECLARE @SysLogid uniqueidentifier"
        s = s & vbCrLf & " declare @UniqueRowCount integer"
        s = s & vbCrLf & " declare @tmpStr varchar(255)"
        s = s & vbCrLf & " declare @access int"
        s = s & vbCrLf & " declare @SysInstID uniqueidentifier"
        s = s & vbCrLf & " select @SysInstID =Instanceid from instance where objtype='SYSTEM'"


        's = s & vbCrLf & " -- checking references  --" & vbCrLf
        'For i = 1 To st.FIELD.Count
        '  s = s & ReferenceCheck(os, st.FIELD.Item(i)) & vbCrLf
        'Next

        s = s & vbCrLf & " -- Insert / Update body -- "

        s = s & vbCrLf & "if exists(select 1 from " & os.Name & " where " & os.Name & "ID=@" & os.Name & "ID)"
        s = s & vbCrLf & " begin"

        s = s & vbCrLf & " --  UPDATE  --"
        s = s & vbCrLf & " begin tran  "
        s = s & vbCrLf & " -- update row  --"
        If Not os.NoLog Then
            s = s & vbCrLf & "set @SysLogid=newid()"
            s = s & vbCrLf & "EXEC SysLog_SAVE @TheSession=@cursession,@CURSESSION=@cursession, @InstanceID=@sysinstid, @SysLogid=@SysLogid, @LogStructID = '" & os.Name & "',"
            s = s & vbCrLf & " @VERB='EDIT',  @Resource=@" & os.Name & "id"
        End If
        s = s & vbCrLf & " update  " & os.Name & " set ChangeStamp=GetDate()"

        ' ������ ����������� �����
        If os.PartType = 2 Then
            s = s & vbCrLf & ",ParentRowid= @ParentRowid"
        End If

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            s = s & vbCrLf & ","
            s = s & vbCrLf & "  " & st.FIELD.Item(i).Name & "=@" & st.FIELD.Item(i).Name
            ft = st.FIELD.Item(i).FieldType
            'support extention field if file type used
            If UCase(ft.Name) = "FILE" Then
                s = s & vbCrLf & "," & st.FIELD.Item(i).Name & "_EXT="
                s = s & "@" & st.FIELD.Item(i).Name & "_EXT "
            End If
        Next

        s = s & vbCrLf & "  where  " & os.Name & "ID = @" & os.Name & "ID "

        s = s & vbCrLf & " -- checking unique constraints  --"
        s = s & UniqueCheck(os) & vbCrLf


        s = s & vbCrLf & "  end"

        s = s & vbCrLf & " else"

        s = s & vbCrLf & " --  INSERT  --"
        s = s & vbCrLf & "  begin"


        ' check for single row part
        If os.PartType = 0 Then
            s = s & vbCrLf & "if exists (select 1 from " & os.Name & " where "
            If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
                s = s & vbCrLf & "InstanceID=@InstanceID)"
            Else
                s = s & vbCrLf & "ParentStructRowID=@ParentStructRowID)"
            End If
            s = s & vbCrLf & " begin"
            s = s & vbCrLf & "    raiserror('Can not create second row in single row struct: <" & os.Name & ">',16,1)"
            s = s & vbCrLf & "    if @@trancount>0 rollback tran"
            s = s & vbCrLf & "    return"
            s = s & vbCrLf & " End"
        End If

        s = s & vbCrLf & " begin tran  "
        s = s & vbCrLf & " insert into   " & os.Name & vbCrLf & " (  " & os.Name & "ID "

        ' ������  - ����
        If os.PartType = 2 Then
            s = s & vbCrLf & ",ParentRowid"
        End If

        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s = s & vbCrLf & ",InstanceID"
        Else
            s = s & vbCrLf & ",ParentStructRowID"
        End If


        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            s = s & vbCrLf & "," & st.FIELD.Item(i).Name & vbCrLf
            ft = st.FIELD.Item(i).FieldType
            'support extention field if file type used
            If UCase(ft.Name) = "FILE" Then
                s = s & vbCrLf & "," & st.FIELD.Item(i).Name & "_EXT"
            End If
        Next

        s = s & vbCrLf & " ) values " & "( @" & os.Name & "ID "


        ' ������  - �������� ����
        If os.PartType = 2 Then
            s = s & vbCrLf & ",@ParentRowid"
        End If


        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s = s & vbCrLf & ",@InstanceID"
        Else
            s = s & vbCrLf & ",@ParentStructRowID"
        End If

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            s = s & vbCrLf & ",@" & st.FIELD.Item(i).Name & vbCrLf
            ft = st.FIELD.Item(i).FieldType
            'support extention field if file type used
            If UCase(ft.Name) = "FILE" Then
                s = s & vbCrLf & ",@" & st.FIELD.Item(i).Name & "_EXT"
            End If

        Next

        s = s & vbCrLf & " ) "

        s = s & vbCrLf & " -- checking unique constraints  --"
        s = s & UniqueCheck(os) & vbCrLf

        s = s & vbCrLf & " end"




        s = s & vbCrLf & " -- close transaction --"

        s = s & vbCrLf & " if @@error <>0  if @@trancount>0 rollback tran  "
        s = s & vbCrLf & " if @@trancount>0 commit tran  "

        s = s & vbCrLf & " end "
        o.ModuleName = "--Procedures"
        o.Block = "--TableProc"
        o.OutNL(s)
        o.OutNL("GO")

        CreateBriefProc(os)
        CreateDelProc(os)


        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            CreateProc(chos)
        Next
        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
    End Sub









    ' make
    Private Function ReferenceCheck(ByVal os As PART, ByVal F As FIELD) As String
        On Error GoTo bye
        Dim s As String = ""
        log = log & vbCrLf & "-->ReferenceCheck " & F.Name

        '�� ������
        '������
        '������

        If F.ReferenceType = enumReferenceType.ReferenceType_Skalyrnoe_pole_OPN_ne_ssilkaCLS Then
            s = ""
        End If

        If F.ReferenceType = enumReferenceType.ReferenceType_Na_ob_ekt_ Then
            s = "if(not exists( select  1 from instance where instanceid=@" & F.Name & " )) "
            s = s & vbCrLf & "  begin"
            s = s & vbCrLf & "    raiserror('Instance of object not exists Structure=" & os.Name & " field=" & F.Name & "',16,1)"
            s = s & vbCrLf & "    if @@trancount>0 rollback tran"
            s = s & vbCrLf & "    return"
            s = s & vbCrLf & "  end"
        End If


        If F.ReferenceType = enumReferenceType.ReferenceType_Na_stroku_razdela Then
            s = "if(not @" & F.Name & " is null ) "
            s = s & vbCrLf & "if(not exists( select  1 from " & CType(F.RefToPart, PART).Name & " where " & CType(F.RefToPart, PART).Name & "id=@" & F.Name & " )) "
            s = s & vbCrLf & "  begin"
            s = s & vbCrLf & "    raiserror('Row specified in table " & CType(F.RefToPart, PART).Name & " not exists Structure=" & os.Name & " field=" & F.Name & "',16,1)"
            s = s & vbCrLf & "    if @@trancount>0 rollback tran"
            s = s & vbCrLf & "    return"
            s = s & vbCrLf & "  end"
        End If

        ReferenceCheck = s

        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"

    End Function




    Private Sub CreateMethod(ByVal m As SHAREDMETHOD)

        On Error GoTo bye

        Dim p As PARAMETERS
        Dim i As Long
        Dim s As String, s1 As String
        Dim ftm As FIELDTYPEMAP
        Dim Parameters As PARAMETERS_col

        s1 = GetScript(m.SCRIPT)
        If s1 = "" Then Exit Sub
        log = log & vbCrLf & "-->CreateMethod " & m.Name
        Parameters = GetParameters(m.SCRIPT)
        s = "/* " & m.Name & "  " & m.the_Comment & "*/"
        If m.ReturnType Is Nothing Then
            s = s & vbCrLf & "create proc " & m.Name & vbCrLf

            If Parameters.Count > 0 Then
                s = s & vbCrLf & "("
            End If
        Else
            s = "create function " & m.Name & vbCrLf
        End If




        For i = 1 To Parameters.Count
            p = Parameters.Item(i)
            If i > 1 Then s = s & vbCrLf & ","
            s = s & MethodParam(p) & vbCrLf
        Next


        If Not m.ReturnType Is Nothing Then
            s = s & vbCrLf & ") "
            s = s & vbCrLf & " returns " & MapFTObj(m.ReturnType.ID.ToString).StoageType & vbCrLf
        Else
            If Parameters.Count > 0 Then
                s = s & vbCrLf & ")"
            End If
        End If


        s = s & vbCrLf & " as "

        s = s & vbCrLf & "begin"
        s = s & vbCrLf & "set nocount on"
        s = s & vbCrLf & "--------- script body ------------"


        o.ModuleName = "--Procedures"
        o.Block = "--Methods"
        o.OutNL(s)

        s = ""

        s1 = GetScript(m.SCRIPT)

        If s1 = "" Then
            s1 = "print 'to do'"
            'Else
            '    Exec(s1)
            '    s1 = ""
        End If

        s = s & s1 & vbCrLf

        s = s & vbCrLf & "--------- script body end---------"
        s = s & vbCrLf & "end"
        s = s & vbCrLf & "GO"

        o.ModuleName = "--Procedures"
        o.Block = "--Methods"
        o.OutNL(s)
        o.OutNL("GO")


        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
    End Sub



    Private Function FieldForCreate(ByVal F As FIELD) As String
        On Error Resume Next

        log = log & vbCrLf & "-->FieldForCreate " & F.Name

        Dim s As String, ftm As FIELDTYPEMAP
        Dim ft As FIELDTYPE
        s = F.Name
        ft = F.FieldType
        ftm = MapFTObj(ft.ID.ToString)
        If ftm.FixedSize <> 0 Then
            s = s & " " & ftm.StoageType & "(" & ftm.FixedSize & ")"
        Else

            s = s & vbCrLf & " " & ftm.StoageType
            ft = F.FieldType

            If ft.AllowSize Then
                If F.DataSize <> 0 Then
                    s = s & " (" & F.DataSize & ")"
                Else
                    s = s & " (1)"
                End If
            End If
        End If
        If F.AllowNull Then
            s = s & " null "
        Else
            s = s & " not null "
        End If


        If ft.TypeStyle = enumTypeStyle.TypeStyle_Interval Then
            s = s & vbCrLf & " check (" & F.Name & " >= " & ft.Minimum & " and " & F.Name & " >= " & ft.Maximum & ")"
        End If

        If ft.TypeStyle = enumTypeStyle.TypeStyle_Perecislenie Then
            If ft.ENUMITEM.Count > 0 Then
                s = s & vbCrLf & " check (" & F.Name & " in ( "
                Dim e
                For e = 1 To ft.ENUMITEM.Count
                    If e > 1 Then s = s & vbCrLf & ", "
                    s = s & ft.ENUMITEM.Item(e).NameValue & "/* " & ft.ENUMITEM.Item(e).Name & " */"
                Next
                s = s & " )) "
            End If
        End If

        s = s & "/* " & F.Caption & " */"

        'support extention field if file type used
        If UCase(ft.Name) = "FILE" Then
            s = s & vbCrLf & "," & F.Name & "_EXT char(10) null"
        End If

        FieldForCreate = s
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"

    End Function


    Private Function FieldForParam(ByVal F As FIELD) As String
        On Error GoTo bye


        log = log & vbCrLf & "-->FieldForParam " & F.Name
        Dim s As String, ftm As FIELDTYPEMAP
        Dim ft As FIELDTYPE
        ft = F.FieldType
        s = "@" & F.Name

        ftm = MapFTObj(ft.ID.ToString)
        If ftm.FixedSize <> 0 Then
            s = s & " " & ftm.StoageType & "(" & ftm.FixedSize & ")"
        Else
            s = s & vbCrLf & " " & ftm.StoageType
            If ft.AllowSize Then
                If F.DataSize <> 0 Then
                    s = s & " (" & F.DataSize & ")"
                Else
                    s = s & " (1)"
                End If
            End If
        End If

        If F.AllowNull Then
            s = s & " = null "
        End If

        s = s & "/* " & F.Caption & " */"

        'support extention field if file type used
        If UCase(ft.Name) = "FILE" Then
            s = s & vbCrLf & ",@" & F.Name & "_EXT char(10) = null"
        End If

        FieldForParam = s & "/* " & F.Caption & " */"
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
    End Function




    Private Function MethodParam(ByVal F As PARAMETERS) As String
        On Error GoTo bye
        log = log & vbCrLf & "-->MethodParam " & F.Name
        Dim s As String, ftm As FIELDTYPEMAP
        Dim ft As FIELDTYPE
        ft = F.TypeOfParm
        s = "@" & F.Name
        ftm = MapFTObj(ft.ID.ToString())
        If ftm.FixedSize <> 0 Then
            s = s & " " & ftm.StoageType & "(" & ftm.FixedSize & ")"
        Else
            s = s & " " & ftm.StoageType
            If ft.AllowSize Then
                If F.DataSize <> 0 Then
                    s = s & " (" & F.DataSize & ")"
                Else
                    s = s & " (1)"
                End If
            End If
        End If

        If F.AllowNull Then
            s = s & " = null "
        End If
        If F.OutParam Then
            s = s & " output "
        End If


        MethodParam = s & "/* " & F.Caption & " */"
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
    End Function


    Private Function UniqueCheck(ByVal os As PART) As String


        log = log & vbCrLf & "-->UniqueCheck for " & os.Name
        On Error GoTo bye
        Dim s As String
        Dim st As PART
        Dim uc As UNIQUECONSTRAINT
        Dim cf As CONSTRAINTFIELD
        Dim fld As FIELD
        Dim i As Long, j As Long
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
                        fld = cf.TheField
                        z = z & vbCrLf & " and " & fld.Name & "=@" & fld.Name
                    Else
                        log = log & vbCrLf & "WARNING-->Field not defined in unique constraint Table=" & st.Name & " <--WARNING"
                    End If
                Next

                If uc.PerParent Then
                    If os.PartType = enumPartType.PartType_Derevo Then
                        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
                            s = s & vbCrLf & " if @ParentRowID is null"
                            s = s & vbCrLf & "   select @UniqueRowCount=Count(*) from " & os.Name & " where InstanceID=@InstanceID and ParentRowID is null " & z
                            s = s & vbCrLf & " else "
                            s = s & vbCrLf & "   select @UniqueRowCount=Count(*) from " & os.Name & " where InstanceID=@InstanceID and ParentRowID=@ParentRowID " & z
                        Else
                            s = s & vbCrLf & " if @ParentRowID is null"
                            s = s & vbCrLf & "   select @UniqueRowCount=Count(*) from " & os.Name & " where ParentStructRowID=@ParentStructRowID and ParentRowID is null " & z
                            s = s & vbCrLf & " else "
                            s = s & vbCrLf & "   select @UniqueRowCount=Count(*) from " & os.Name & " where ParentStructRowID=@ParentStructRowID and ParentRowID =@ParentRowID " & z
                        End If
                    Else
                        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
                            s = s & vbCrLf & " select @UniqueRowCount=Count(*) from " & os.Name & " where InstanceID=@InstanceID " & z
                        Else
                            s = s & vbCrLf & "select @UniqueRowCount=Count(*) from " & os.Name & " where ParentStructRowID=@ParentStructRowID " & z
                        End If
                    End If
                Else
                    s = s & vbCrLf & "select @UniqueRowCount=Count(*) from " & os.Name & " where 1=1  " & z
                End If



            End If
            s = s & vbCrLf & "if @UniqueRowCount>=2"
            s = s & vbCrLf & "begin"
            s = s & vbCrLf & " raiserror('Unique check error Struct=" & os.Name & "',16,1)"
            s = s & vbCrLf & " if @@trancount>0 rollback tran"
            s = s & vbCrLf & " return"
            s = s & vbCrLf & "end"
        Next
        UniqueCheck = s
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
    End Function




    Private Function MapAndParent(ByVal os As PART) As String
        Dim s As String = ""
        Dim tn As String
        tn = TypeForStruct(os).Name

        s = s & vbCrLf & "set @id = newid()"
        s = s & vbCrLf & "EXEC SysOptions_SAVE  @SysOptionsid=@id, @Name='" & os.Name & "', @Value='" & tn & "', @OptionType='STRUCT_TYPE'"


        s = s & vbCrLf & "set @id = newid()"
        s = s & vbCrLf & "EXEC SysOptions_SAVE  @SysOptionsid=@id, @Name='" & os.ID.ToString & "', @Value='" & os.Name & "', @OptionType='MAP'"



        If TypeName(os.Parent.Parent) <> "OBJECTTYPE" Then
            s = s & vbCrLf & "set @id = newid()"
            s = s & vbCrLf & "EXEC SysOptions_SAVE  @SysOptionsid=@id, @Name='" & os.Name & "', @Value='" & CType(os.Parent.Parent, PART).Name & "', @OptionType='PARENT'"
        End If

        ' Dim chos As PART
        Dim i As Long
        For i = 1 To os.PARTVIEW.Count
            s = s & vbCrLf & MapViews(os.PARTVIEW.Item(i))
        Next


        For i = 1 To os.PART.Count
            s = s & vbCrLf & MapAndParent(os.PART.Item(i))
        Next

        MapAndParent = s
    End Function


    Private Function MapViews(ByVal pv As PARTVIEW) As String
        Dim s As String
        s = ""
        s = s & vbCrLf & "set @id = newid()"
        s = s & vbCrLf & "EXEC SysOptions_SAVE  @SysOptionsid=@id, @Name='" & pv.ID.ToString() & "', @Value='V_" & pv.the_Alias & "', @OptionType='MAP'"
        MapViews = s
    End Function


    Private Function TypeForStruct(ByVal s As PART) As OBJECTTYPE
        'Dim i As Long
        Dim obj As Object
        obj = s.Parent.Parent

        ' ���� ��� �� ��� �������
        While TypeName(obj) <> "OBJECTTYPE"
            obj = obj.Parent.Parent
        End While

        TypeForStruct = obj


    End Function


    Private Sub LoadOptions()
        Dim s As String = ""

        'Dim os As PART
        Dim i As Long
        Dim j As Long

        s = s & vbCrLf & "declare @id uniqueidentifier"
        s = s & vbCrLf & "declare @instid uniqueidentifier"
        s = s & vbCrLf & "declare @uid uniqueidentifier"
        s = s & vbCrLf & "declare @SESSION uniqueidentifier"
        s = s & vbCrLf & "declare @cid uniqueidentifier"
        s = s & vbCrLf & "declare @secid uniqueidentifier"
        s = s & vbCrLf & "declare @hid uniqueidentifier"
        s = s & vbCrLf & "declare @tmpstr varchar(255)"


        s = s & vbCrLf & "set @id = newid()"
        s = s & vbCrLf & "set @instid = newid()"
        s = s & vbCrLf & "set @uid = newid() "
        s = s & vbCrLf & "set @secid = newid() --user security instance "
        s = s & vbCrLf & "set @cid = newid() -- check option id"
        s = s & vbCrLf & "set @hid = newid() -- helper id"
        s = s & vbCrLf & "insert into users(usersid,instanceid,login,password) values(@uid,null,'init','init')"

        s = s & vbCrLf & "insert into sysoptions(sysoptionsid,optiontype,name,value) values(@cid,'OPTION','Check Mode','SKIP')"

        s = s & vbCrLf & "exec Login @SESSION=@session OUTPUT , @PWD='init', @USR='init'"
        s = s & vbCrLf & "set @id = newid()"
        s = s & vbCrLf & "exec ResourceTree_SAVE @CURSESSION=@session,@InstanceID=null,@resourcetreeid=@id,@hier='00000',@RID='SYSTEM'"
        s = s & vbCrLf & "EXEC Instance_SAVE @CURSESSION=@session, @InstanceID=@instid, @ObjType='SYSTEM',@Name='SYSTEM'"

        For i = 1 To m.OBJECTTYPE.Count
            s = s & vbCrLf & "set @id = newid()"
            s = s & vbCrLf & "insert into typelist( name,RegisterProc,DeleteProc) values('" & m.OBJECTTYPE.Item(i).Name & "', '" & m.OBJECTTYPE.Item(i).Name & "_REGISTER', '" & m.OBJECTTYPE.Item(i).Name & "_DELETE')"
            s = s & vbCrLf & "set @tmpstr = 'TYPE='+'" & m.OBJECTTYPE.Item(i).Name & "'"
            s = s & vbCrLf & "exec RegisterResource @cursession=@session,@parent='SYSTEM',@resource=@tmpStr"
        Next

        s = s & vbCrLf & " delete from Instance"
        s = s & vbCrLf & "EXEC Instance_SAVE @CURSESSION=@session, @InstanceID=@instid, @ObjType='SYSTEM',@Name='SYSTEM'"

        s = s & vbCrLf & "EXEC Instance_SAVE @CURSESSION=@session, @InstanceID=@secid, @ObjType='UserSecurity',@Name='UserSecurity'"

        For i = 1 To m.OBJECTTYPE.Count
            For j = 1 To m.OBJECTTYPE.Item(i).PART.Count
                s = s & vbCrLf & MapAndParent(m.OBJECTTYPE.Item(i).PART.Item(j))
            Next
        Next

        For i = 1 To m.SHAREDMETHOD.Count
            s = s & vbCrLf & "set @id = newid()"
            s = s & vbCrLf & "EXEC SysOptions_SAVE  @SysOptionsid=@id, @Name='" & m.SHAREDMETHOD.Item(i).ID.ToString & "', @Value='" & m.SHAREDMETHOD.Item(i).Name & "', @OptionType='METHODNAME'"
        Next


        s = s & vbCrLf & "DECLARE @Groupid uniqueidentifier"
        s = s & vbCrLf & "DECLARE @GroupUserid uniqueidentifier"


        ' create new user
        s = s & vbCrLf & "set @uid=newid()"
        s = s & vbCrLf & "EXEC Users_SAVE @CURSESSION=@session, @InstanceID=@secid, @Usersid=@uid, "
        s = s & vbCrLf & " @Password='bami',  @Login='supervisor', @name='BAMI'"

        '--- GROUP Administrtors
        s = s & vbCrLf & "set @Groupid =newid()"
        s = s & vbCrLf & "EXEC Groups_SAVE @CURSESSION=@SESSION, @InstanceID=@secid, @Groupsid=@Groupid, @Name='Administrators'"

        s = s & vbCrLf & "set @GroupUserid=newid()"
        s = s & vbCrLf & "EXEC GroupUser_SAVE @CURSESSION=@SESSION, @ParentStructRowID=@Groupid, @GroupUserid = @GroupUserid,  @TheUser=@uid"

        s = s & vbCrLf & "EXEC GrantResource @VERB='CREATEROW', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=1"
        s = s & vbCrLf & "EXEC GrantResource @VERB='EDIT', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=1"
        s = s & vbCrLf & "EXEC GrantResource @VERB='DELETE', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=1"
        s = s & vbCrLf & "EXEC GrantResource @VERB='LOCK', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=1"
        s = s & vbCrLf & "EXEC GrantResource @VERB='CHECKOUT', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=1"
        s = s & vbCrLf & "EXEC GrantResource @VERB='BRIEF', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=1"
        s = s & vbCrLf & "EXEC GrantResource @VERB='RETRIVE', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=1"
        s = s & vbCrLf & "EXEC GrantResource @VERB='RETRIVECHILDREN', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=1"
        s = s & vbCrLf & "EXEC GrantResource @VERB='CLOSESESSION', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=1"

        '--- GROUP Users
        s = s & vbCrLf & "set @Groupid =newid()"
        s = s & vbCrLf & "EXEC Groups_SAVE @CURSESSION=@SESSION, @InstanceID=@secid, @Groupsid=@Groupid, @Name='Users'"

        ' add supervisor
        s = s & vbCrLf & "set @GroupUserid=newid()"
        s = s & vbCrLf & "EXEC GroupUser_SAVE @CURSESSION=@SESSION, @ParentStructRowID=@Groupid, @GroupUserid = @GroupUserid,  @TheUser=@uid"

        ' create new user - user
        s = s & vbCrLf & "set @uid=newid()"
        s = s & vbCrLf & "EXEC Users_SAVE @CURSESSION=@session, @InstanceID=@secid, @Usersid=@uid, "
        s = s & vbCrLf & " @Password='user',  @Login='user', @name='user'"

        'add user to Users
        s = s & vbCrLf & "set @GroupUserid=newid()"
        s = s & vbCrLf & "EXEC GroupUser_SAVE @CURSESSION=@SESSION, @ParentStructRowID=@Groupid, @GroupUserid = @GroupUserid,  @TheUser=@uid"


        s = s & vbCrLf & "EXEC GrantResource @VERB='CREATEROW', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=0"
        s = s & vbCrLf & "EXEC GrantResource @VERB='EDIT', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=0"
        s = s & vbCrLf & "EXEC GrantResource @VERB='DELETE', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=0"
        s = s & vbCrLf & "EXEC GrantResource @VERB='LOCK', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=0"
        s = s & vbCrLf & "EXEC GrantResource @VERB='CHECKOUT', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=0"
        s = s & vbCrLf & "EXEC GrantResource @VERB='BRIEF', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=1"
        s = s & vbCrLf & "EXEC GrantResource @VERB='RETRIVE', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=1"
        s = s & vbCrLf & "EXEC GrantResource @VERB='RETRIVECHILDREN', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=1"


        '--- GROUP GUESTS
        s = s & vbCrLf & "set @Groupid =newid()"
        s = s & vbCrLf & "EXEC Groups_SAVE @CURSESSION=@SESSION, @InstanceID=@secid, @Groupsid=@Groupid, @Name='GUESTS'"

        ' add user -user
        s = s & vbCrLf & "set @GroupUserid=newid()"
        s = s & vbCrLf & "EXEC GroupUser_SAVE @CURSESSION=@SESSION, @ParentStructRowID=@Groupid, @GroupUserid = @GroupUserid,  @TheUser=@uid"

        ' new user - guest
        s = s & vbCrLf & "set @uid=newid()"
        s = s & vbCrLf & "EXEC Users_SAVE @CURSESSION=@session, @InstanceID=@secid, @Usersid=@uid, "
        s = s & vbCrLf & " @Password='guest',  @Login='guest', @name='guest'"

        ' add user -guest
        s = s & vbCrLf & "set @GroupUserid=newid()"
        s = s & vbCrLf & "EXEC GroupUser_SAVE @CURSESSION=@SESSION, @ParentStructRowID=@Groupid, @GroupUserid = @GroupUserid,  @TheUser=@uid"

        s = s & vbCrLf & "EXEC GrantResource @VERB='CREATEROW', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=0"
        s = s & vbCrLf & "EXEC GrantResource @VERB='EDIT', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=0"
        s = s & vbCrLf & "EXEC GrantResource @VERB='DELETE', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=0"
        s = s & vbCrLf & "EXEC GrantResource @VERB='LOCK', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=0"
        s = s & vbCrLf & "EXEC GrantResource @VERB='CHECKOUT', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=0"
        s = s & vbCrLf & "EXEC GrantResource @VERB='RETRIVE', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=0"
        s = s & vbCrLf & "EXEC GrantResource @VERB='RETRIVECHILDREN', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=0"
        s = s & vbCrLf & "EXEC GrantResource @VERB='BRIEF', @CURSESSION=@SESSION, @RESOURCE='SYSTEM', @GROUPID=@GROUPID, @ACCESS=1"

        s = s & vbCrLf & "EXEC SysOptions_SAVE   @SysOptionsid=@cid, @Name='Check Mode', @Value='CHECK', @OptionType='OPTION'"

        s = s & vbCrLf & "exec Logout  @cursession=@session"

        s = s & vbCrLf & "delete from users where login = 'init'"
        s = s & vbCrLf & "delete from session"
        s = s & vbCrLf & "declare @systemid uniqueidentifier"
        s = s & vbCrLf & "select  @systemid=instanceid from instance where objtype='SYSTEM'"
        s = s & vbCrLf & "update resourcetree set instanceid =@systemid"

        s = s & vbCrLf & "print 'Test resource tree'"
        s = s & vbCrLf & "select REPLICATE ( ' ' , len(hier)/5  ) +rid from resourcetree order by hier"

        s = s & vbCrLf & "go"

        o.ModuleName = "--Options"
        o.Block = "--Load"
        o.OutNL(s)

    End Sub




    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' UTILS
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' return phisical type for FIELDTYPE
    Private Function MapFT(ByVal typeID As String) As String
        On Error GoTo bye

        Dim i As Integer, s As String = ""
        Dim ft As FIELDTYPE
        MapFT = "INTEGER"
        ft = m.FIELDTYPE.Item(typeID)
        If ft Is Nothing Then Exit Function
        For i = 1 To ft.FIELDTYPEMAP.Count
            If ft.FIELDTYPEMAP.Item(i).Target.ID.Equals(New Guid(tid)) Then
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
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"

    End Function


    Private Function MapFTObj(ByVal typeID As String) As FIELDTYPEMAP
        On Error GoTo bye

        Dim i, s
        Dim ft As FIELDTYPE
        ft = m.FIELDTYPE.Item(typeID)
        If ft Is Nothing Then Return Nothing
        For i = 1 To ft.FIELDTYPEMAP.Count
            If ft.FIELDTYPEMAP.Item(i).Target.ID.Equals(New Guid(tid)) Then
                Return ft.FIELDTYPEMAP.Item(i)

            End If
        Next
        Return Nothing
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        Return Nothing
    End Function




    Private Function GetScript(ByVal scol As SCRIPT_col) As String
        Dim i As Long

        On Error GoTo bye
        For i = 1 To scol.Count
            If scol.Item(i).Target.ID.Equals(New Guid(tid)) Then
                Return scol.Item(i).Code

            End If
        Next
        Return Nothing
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"

        Return Nothing
    End Function


    Private Function GetParameters(ByVal scol As SCRIPT_col) As PARAMETERS_col
        Dim i As Long

        On Error GoTo bye
        For i = 1 To scol.Count
            If scol.Item(i).Target.ID.Equals(New Guid(tid)) Then
                Return scol.Item(i).PARAMETERS

            End If
        Next
        Return Nothing
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        Return Nothing
    End Function


   
    '    Private Sub Exec(ByVal st As String)
    '        Dim s As String

    '        Dim pre As LATIRGenerator.Preprocessor
    '        pre = New LATIRGenerator.Preprocessor
    '        s = pre.Convert(st)
    '        Debug.Print(s)
    '        On Error GoTo host_err
    '        s = "dim targetID " & vbCrLf & "TargetID = """ & tid & """" & vbCrLf & s
    '        host.ExecuteStatement(s)

    '        On Error Resume Next
    '        pre = Nothing
    '        Exit Sub
    'host_err:
    '        log = log & vbCrLf & "ERROR-->"
    '        log = log & "Executing:" & s & vbCrLf
    '        log = log & host.Error.Description & vbCrLf & "at line = " & host.Error.Line & " column=" & host.Error.Column & vbCrLf & host.Error.Text & vbCrLf
    '        log = log & vbCrLf & "<--ERROR"
    '        pre = Nothing
    '    End Sub

    Private Function MakeName(ByVal s As String) As String
        Dim tt As String
        tt = s
        tt = Replace(tt, "-", "")
        tt = Replace(tt, "{", "")
        tt = Replace(tt, "}", "")
        tt = Replace(tt, " ", "_")
        MakeName = tt
    End Function




    Private Sub CreateBriefProc(ByVal os As PART)
        Dim st As PART
        st = os
        Dim chos As PART, i As Long, j As Long, F As FIELD
        Dim s As String
        CreateBriefFunc(os)
        log = log & vbCrLf & "-->CreateBriefProc " & os.Name
        On Error GoTo bye
        s = ""
        s = s & vbCrLf & "create proc " & os.Name & "_BRIEF  ("
        s = s & vbCrLf & " @CURSESSION uniqueidentifier,"
        s = s & vbCrLf & " @" & os.Name & "id uniqueidentifier,"
        s = s & vbCrLf & " @BRIEF varchar(4000) output"
        s = s & vbCrLf & ") as " & " begin  "
        s = s & vbCrLf & "set nocount on"
        s = s & vbCrLf & " declare @access int"
        s = s & vbCrLf & " declare @tmpStr varchar(255)"
        's = s & vbCrLf & " -- checking session  --"
        's = s & vbCrLf & "if not exists( select 1 from session where sessionid=@cursession and closed=0 )"
        's = s & vbCrLf & "  begin"
        's = s & vbCrLf & "    raiserror('Session expired',16,1)"
        's = s & vbCrLf & "    return"
        's = s & vbCrLf & "  end"

        s = s & vbCrLf & "if @" & os.Name & "id is null begin set @BRIEF='' return end"

        s = s & vbCrLf & " -- Brief body -- "

        s = s & vbCrLf & "if exists(select 1 from " & os.Name & " where " & os.Name & "ID=@" & os.Name & "ID)"
        s = s & vbCrLf & " begin"
        's = s & vbCrLf & " --  verify access  --"
        's = s & vbCrLf & " set  @tmpStr =isnull(convert(varchar(40),@" & os.Name & "ID),'???')"
        's = s & vbCrLf & " exec CheckVerbRight @cursession=@cursession,@resource=@tmpStr,@verb='BRIEF',@access=@access out "
        's = s & vbCrLf & " if @access=0 "
        's = s & vbCrLf & "  begin"
        's = s & vbCrLf & "    raiserror('No access for BRIEF Structure=" & os.Name & "',16,1)"
        's = s & vbCrLf & "    return"
        's = s & vbCrLf & "  end"
        s = s & vbCrLf & "  select @BRIEF=dbo." & os.Name & "_BRIEF_F(@" & os.Name & "id)"
        s = s & vbCrLf & "end else begin"
        s = s & vbCrLf & "  set @BRIEF= '�������� �������������'"
        s = s & vbCrLf & "end"
        s = s & vbCrLf & "set @BRIEF=left(@BRIEF,4000)"
        s = s & vbCrLf & "end "


        o.ModuleName = "--Procedures"
        o.Block = "--TableProc"
        o.OutNL(s)
        o.OutNL("GO")
        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume

    End Sub



    Private Sub CreateBriefFunc(ByVal os As PART)
        Dim st As PART
        st = os
        Dim chos As PART, i As Long, j As Long, F As FIELD
        Dim s As String
        Dim ft As FIELDTYPE


        log = log & vbCrLf & "-->CreateBriefFunc " & os.Name

        On Error GoTo bye

        s = ""
        s = s & vbCrLf & "create function " & os.Name & "_BRIEF_F  ("
        s = s & vbCrLf & " @" & os.Name & "id uniqueidentifier"
        s = s & vbCrLf & ") returns varchar(4000) as " & " begin  "
        s = s & vbCrLf & " declare @BRIEF varchar(4000)"
        s = s & vbCrLf & " declare @tmpStr varchar(255)"
        s = s & vbCrLf & " declare @tmpBrief varchar(4000)"
        s = s & vbCrLf & " declare @tmpID uniqueidentifier"


        s = s & vbCrLf & "if @" & os.Name & "id is null begin set @BRIEF='�� ������' return (@BRIEF) end"
        s = s & vbCrLf & " -- Brief body -- "
        s = s & vbCrLf & "if exists(select 1 from " & os.Name & " where " & os.Name & "ID=@" & os.Name & "ID)"
        s = s & vbCrLf & " begin"
        s = s & vbCrLf & "  set @BRIEF=''"

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            If st.FIELD.Item(i).IsBrief Then
                F = st.FIELD.Item(i)
                s = s & vbCrLf & "  set @BRIEF= @BRIEF + '" & F.Caption & "='"
                ft = F.FieldType
                'enum
                If ft.TypeStyle = enumTypeStyle.TypeStyle_Perecislenie Then

                    s = s & vbCrLf & "  select @BRIEF= @BRIEF +"
                    s = s & vbCrLf & "  case " & F.Name & " "
                    For j = 1 To ft.ENUMITEM.Count
                        s = s & vbCrLf & "when " & ft.ENUMITEM.Item(j).NameValue & " then "
                        s = s & " '" & ft.ENUMITEM.Item(j).Name & "; '"
                    Next
                    s = s & vbCrLf & "  end  from " & st.Name & " where " & os.Name & "ID=@" & os.Name & "ID"

                ElseIf ft.TypeStyle = enumTypeStyle.TypeStyle_Ssilka Then
                    s = s & vbCrLf & "select @tmpID =  " & F.Name
                    s = s & vbCrLf & "  from " & os.Name & "  where  " & os.Name & "ID = @" & os.Name & "ID "
                    If F.ReferenceType = enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                        s = s & vbCrLf & " select @tmpBrief= dbo.Instance_BRIEF_F( @tmpID)"
                    End If
                    If F.ReferenceType = enumReferenceType.ReferenceType_Na_stroku_razdela Then
                        s = s & vbCrLf & " select @tmpBrief= dbo." & CType(CType(F.RefToPart, PART), PART).Name & "_BRIEF_F(@tmpID)"
                    End If
                    s = s & vbCrLf & "  set @BRIEF= @BRIEF + '{' + isnull(@tmpbrief,'???') + '}; '"

                Else
                    s = s & vbCrLf & "  select @BRIEF= @BRIEF "
                    s = s & vbCrLf & "  +  isnull(Convert(varchar(1000), " & st.FIELD.Item(i).Name & "),'???')+'; '"
                    s = s & vbCrLf & "  from " & os.Name & "  where  " & os.Name & "ID = @" & os.Name & "ID "
                End If
            End If
        Next
        s = s & vbCrLf & "end else begin"
        s = s & vbCrLf & "  set @BRIEF= '�������� �������������'"
        s = s & vbCrLf & "end"
        s = s & vbCrLf & "set @BRIEF=left(@BRIEF,4000)"
        s = s & vbCrLf & "return(@BRIEF)"
        s = s & vbCrLf & "end "


        o.ModuleName = "--Functions"
        o.Block = "--TableProc"
        o.OutNL(s)
        o.OutNL("GO")


        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume

    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' ���� ������� ������ ��������� ��� ���������� ������ ����
    ' ��������� ������ 110 ������� �� ������ 239*21 - ������������������� ��������
    ' ��������� ����� ������ SQL �������� ������� 80 ������ !
    ' ������� ��������� �� �������� ��������� ����� � ����������� ���������� ��������!
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Private Sub CreateResourceSet()
    'Dim st As PART
    'Dim os As PART
    'Dim ot As OBJECTTYPE
    'Dim r As RESOURCESET
    'Dim cd As COLUMNDEF
    '
    'Dim pros As PART, i As Long, j As Long, f As FIELD
    'Dim s As String
    'On Error GoTo bye
    'For i = 1 To m.RESOURCESET.Count
    '  Set r = m.RESOURCESET.Item(i)
    '  log = log & vbCrLf & "-->CreateResourceSet " & r.Name
    '  Set ot = r.ForType
    '
    '
    '  s = s & vbCrLf & "create proc " & ot.Name & "_RS_" & r.Name & "(@InstID uniqueidentifier,@Alias varchar(255), @Value varchar(255) output) as "
    '  s = s & vbCrLf & "begin"
    '  s = s & vbCrLf & "set @value = null"
    '
    '
    '
    '  For j = 1 To r.COLUMNDEF.Count
    '    Set cd = r.COLUMNDEF.Item(j)
    '    s = s & vbCrLf & "if @Alias ='" & cd.Alias & "'"
    '    s = s & vbCrLf & "begin"
    '
    '    If cd.STRUCT Is Nothing Then
    '      log = log & vbCrLf & "ERROR-->STRUCT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " NOT DEFINED<--ERROR"
    '      GoTo nxt_field
    '    End If
    '    If Not TypeForStruct(cd.STRUCT) Is ot Then
    '      log = log & vbCrLf & "ERROR-->STRUCT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " GIVEN FROM ANOTHER OBJECTTYPE<--ERROR"
    '      GoTo nxt_field
    '    End If
    '    Set os = cd.STRUCT
    '    If os.PartType <> 0 And cd.Aggregation = 0 Then
    '      log = log & vbCrLf & "ERROR-->AGGREGATION FUNCTION FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " NOT DEFINED<--ERROR"
    '      GoTo nxt_field
    '    End If
    '    If Not os Is cd.FIELD.Parent.Parent Then
    '      log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " STRUCT AND FIELD FROM DIFERENT OBJECTS<--ERROR"
    '      GoTo nxt_field
    '    End If
    '
    '    ' �������� ������ ��� �������� �������
    '    If cd.STRUCT.PartType = 0 And TypeForStruct(cd.STRUCT) Is r.ForType Then
    '      If cd.FIELD.FIELDTYPE.ISREFERENCE Then
    '        If Not cd.RefExpandPart Is Nothing And cd.RefExpandField <> "" Then
    '          '0-��������� ���� ( �� ������)
    '          '1-�� ������
    '          '2-�� ����� �������
    '
    '
    '          If cd.FIELD.ReferenceType = 2 Then
    '            If Not cd.FIELD.RefToPart Is cd.RefExpandPart Then
    '              log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " WRONG REFERENCE EXPANDING<--ERROR"
    '              GoTo nxt_field
    '            End If
    '          End If
    '
    '
    '          If cd.FIELD.ReferenceType = 1 Then
    '            If cd.FIELD.RefToType Is Nothing Then
    '              log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " TYPE FOR REFERENCE EXPANDING UNKNOWN<--ERROR"
    '              GoTo nxt_field
    '            Else
    '              If Not TypeForStruct(cd.RefExpandPart) Is cd.FIELD.RefToType Then
    '                log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " TYPE FOR REFERENCE EXPANDING DIFFERENT<--ERROR"
    '                GoTo nxt_field
    '              End If
    '              If cd.RefExpandPart.PartType <> 0 Then
    '                log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " FOR REFERENCE EXPANDING - EXPAND FROM COLLECTION PART<--ERROR"
    '                GoTo nxt_field
    '              End If
    '              If Not cd.RefExpandPart.Parent.Parent Is TypeForStruct(cd.RefExpandPart) Then
    '                log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " FOR REFERENCE EXPANDING - EXPAND INTERNAL PART<--ERROR"
    '                GoTo nxt_field
    '              End If
    '            End If
    '          End If
    '        Else
    '          log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " WRONG REFERENCE DEFINITION<--ERROR"
    '          GoTo nxt_field
    '        End If
    '
    '        If cd.FIELD.ReferenceType = 2 Then
    '          s = s & vbCrLf & "select @" & cd.alias & "]=convert( varchar(255), " & cd.RefExpandField & ")   from  " & cd.RefExpandPart.Name
    '          s = s & vbCrLf & " join " & os.Name & " on "
    '          s = s & vbCrLf & " " & cd.RefExpandPart.Name & "." & cd.RefExpandPart.Name & "id=" & os.Name & "." & cd.FIELD.Name & " "
    '        End If
    '
    '        If cd.FIELD.ReferenceType = 1 Then
    '          s = s & vbCrLf & "select @" & cd.alias & "]=convert( varchar(255), " & cd.RefExpandField & ")   from  " & cd.RefExpandPart.Name
    '          s = s & vbCrLf & " join " & os.Name & " on "
    '          s = s & vbCrLf & " " & cd.RefExpandPart.Name & ".INSTANCEID=" & os.Name & "." & cd.FIELD.Name & " "
    '        End If
    '      Else
    '        s = s & vbCrLf & "select @" & cd.alias & "]=convert( varchar(255), "
    '        s = s & vbCrLf & "(" & cd.FIELD.Name & "))  from "
    '        s = s & vbCrLf & cd.STRUCT.Name
    '      End If ' �� ������
    '    Else
    '        ' ��������� - ���������� ������� ���������
    '        Select Case cd.Aggregation
    '        Case 0
    '          log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " WRONG REFERENCE DEFINITION - NO AGGREGATION<--ERROR"
    '          GoTo nxt_field
    '        Case 1 'Avg
    '          s = s & vbCrLf & "select @" & cd.alias & "]=convert( varchar(255), Avg"
    '        Case 2 'Count
    '          s = s & vbCrLf & "select @" & cd.alias & "]=convert( varchar(255), COUNT"
    '        Case 3 'Sum
    '          s = s & vbCrLf & "select @" & cd.alias & "]=convert( varchar(255), SUM"
    '        Case 4 'Min
    '          s = s & vbCrLf & "select @" & cd.alias & "]=convert( varchar(255), Min"
    '        Case 5 'Max
    '          s = s & vbCrLf & "select @" & cd.alias & "]=convert( varchar(255), Max"
    '        Case 6 'CUSTOM
    '          s = s & vbCrLf & "select @" & cd.alias & "]=convert( varchar(255), " & cd.CustomFormula
    '        End Select
    '
    '        s = s & vbCrLf & "(" & cd.FIELD.Name & "))  from "
    '        s = s & vbCrLf & cd.STRUCT.Name
    '    End If ' �� ������� ( ��� �������, �� �� � ������ ������)
    '
    '
    '
    '    ' ���� ��� �� ������ �������
    '    Set pros = os
    '    While Not pros.Parent.Parent Is ot
    '      s = s & vbCrLf & " join " & pros.Parent.Parent.Name & " on " & pros.Name & ".ParentStructRowID=" & pros.Parent.Parent.Name & "ID"
    '      Set pros = pros.Parent.Parent
    '    Wend
    '    s = s & vbCrLf & " where " & pros.Name & ".InstanceID=@InstID "
    '
    '
    '    ' ���� ���� �������������� ������� �� ����
    '    Select Case cd.Condition
    '    Case 1 '=
    '      s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & "=" & cd.ConditionValue
    '    Case 2 '<>
    '      s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & "<>" & cd.ConditionValue
    '    Case 3 '>
    '      s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & ">" & cd.ConditionValue
    '    Case 4 '>=
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & ">=" & cd.ConditionValue
    '    Case 5 '<
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & "<" & cd.ConditionValue
    '    Case 6 '<=
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & "<=" & cd.ConditionValue
    '    Case 7 'like
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & " like " & cd.ConditionValue
    '    Case 8 'is null
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & " is null"
    '    Case 9 'is not null
    '     s = s & vbCrLf & " and not " & os.Name & "." & cd.ConditionField.Name & " is null"
    '    End Select
    '
    'nxt_field:
    '  s = s & vbCrLf & "  end  -- end of column: " & cd.Alias
    '  Next
    '  s = s & vbCrLf & "end -- end of proc"
    '  s = s & vbCrLf & "go"
    '
    'nxt_set:
    'Next
    '
    '
    'o.ModuleName = "--Procedures"
    'o.Block = "--ResourceSet proc"
    'o.OutNL s
    '
    '
    '
    'Exit Sub
    'bye:
    'log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
    'Stop
    'Resume
    'End Sub



    ' �������  - ��������� �� ������ ���� �� ����������� ��� ����� ����� ���������� ������
    ' ��������� �������������� 59 ������ �� ��� �� ��������� ��������
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Private Sub CreateResourceSet()
    'Dim st As PART
    'Dim os As PART
    'Dim ot As OBJECTTYPE
    'Dim r As RESOURCESET
    'Dim cd As COLUMNDEF
    '
    'Dim pros As PART, i As Long, j As Long, f As FIELD
    'Dim s As String
    'On Error GoTo bye
    'For i = 1 To m.RESOURCESET.Count
    '  Set r = m.RESOURCESET.Item(i)
    '  log = log & vbCrLf & "-->CreateResourceSet " & r.Name
    '  Set ot = r.ForType
    '
    '
    '  s = s & vbCrLf & "create proc " & ot.Name & "_RS_" & r.Name & "(@InstID uniqueidentifier "
    '  ' ��������� ���������
    '  For j = 1 To r.COLUMNDEF.Count
    '  Set cd = r.COLUMNDEF.Item(j)
    '  s = s & vbCrLf & ", @" & MakeName(cd.Alias) & " varchar(255) =NULL output"
    '  Next
    '  s = s & vbCrLf & ") as -- proc start"
    '  s = s & vbCrLf & "begin"
    '  For j = 1 To r.COLUMNDEF.Count
    '  Set cd = r.COLUMNDEF.Item(j)
    '  s = s & vbCrLf & "set @" & MakeName(cd.Alias) & "=null"
    '  Next
    '
    '
    '
    '  For j = 1 To r.COLUMNDEF.Count
    '    Set cd = r.COLUMNDEF.Item(j)
    '    s = s & vbCrLf & "  begin  -- begin of column: " & cd.Alias
    '
    '    If cd.STRUCT Is Nothing Then
    '      log = log & vbCrLf & "ERROR-->STRUCT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " NOT DEFINED<--ERROR"
    '      GoTo nxt_field
    '    End If
    '    If Not TypeForStruct(cd.STRUCT) Is ot Then
    '      log = log & vbCrLf & "ERROR-->STRUCT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " GIVEN FROM ANOTHER OBJECTTYPE<--ERROR"
    '      GoTo nxt_field
    '    End If
    '    Set os = cd.STRUCT
    '    If os.PartType <> 0 And cd.Aggregation = 0 Then
    '      log = log & vbCrLf & "ERROR-->AGGREGATION FUNCTION FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " NOT DEFINED<--ERROR"
    '      GoTo nxt_field
    '    End If
    '    If Not os Is cd.FIELD.Parent.Parent Then
    '      log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " STRUCT AND FIELD FROM DIFERENT OBJECTS<--ERROR"
    '      GoTo nxt_field
    '    End If
    '
    '    ' �������� ������ ��� �������� �������
    '    If cd.STRUCT.PartType = 0 And TypeForStruct(cd.STRUCT) Is r.ForType Then
    '      If cd.FIELD.FIELDTYPE.ISREFERENCE Then
    '        If Not cd.RefExpandPart Is Nothing And cd.RefExpandField <> "" Then
    '          '0-��������� ���� ( �� ������)
    '          '1-�� ������
    '          '2-�� ����� �������
    '
    '
    '          If cd.FIELD.ReferenceType = 2 Then
    '            If Not cd.FIELD.RefToPart Is cd.RefExpandPart Then
    '              log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " WRONG REFERENCE EXPANDING<--ERROR"
    '              GoTo nxt_field
    '            End If
    '          End If
    '
    '
    '          If cd.FIELD.ReferenceType = 1 Then
    '            If cd.FIELD.RefToType Is Nothing Then
    '              log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " TYPE FOR REFERENCE EXPANDING UNKNOWN<--ERROR"
    '              GoTo nxt_field
    '            Else
    '              If Not TypeForStruct(cd.RefExpandPart) Is cd.FIELD.RefToType Then
    '                log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " TYPE FOR REFERENCE EXPANDING DIFFERENT<--ERROR"
    '                GoTo nxt_field
    '              End If
    '              If cd.RefExpandPart.PartType <> 0 Then
    '                log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " FOR REFERENCE EXPANDING - EXPAND FROM COLLECTION PART<--ERROR"
    '                GoTo nxt_field
    '              End If
    '              If Not cd.RefExpandPart.Parent.Parent Is TypeForStruct(cd.RefExpandPart) Then
    '                log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " FOR REFERENCE EXPANDING - EXPAND INTERNAL PART<--ERROR"
    '                GoTo nxt_field
    '              End If
    '            End If
    '          End If
    '        Else
    '          log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " WRONG REFERENCE DEFINITION<--ERROR"
    '          GoTo nxt_field
    '        End If
    '
    '        If cd.FIELD.ReferenceType = 2 Then
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), " & cd.RefExpandField & ")   from  " & cd.RefExpandPart.Name
    '          s = s & vbCrLf & " join " & os.Name & " on "
    '          s = s & vbCrLf & " " & cd.RefExpandPart.Name & "." & cd.RefExpandPart.Name & "id=" & os.Name & "." & cd.FIELD.Name & " "
    '        End If
    '
    '        If cd.FIELD.ReferenceType = 1 Then
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), " & cd.RefExpandField & ")   from  " & cd.RefExpandPart.Name
    '          s = s & vbCrLf & " join " & os.Name & " on "
    '          s = s & vbCrLf & " " & cd.RefExpandPart.Name & ".INSTANCEID=" & os.Name & "." & cd.FIELD.Name & " "
    '        End If
    '      Else
    '        s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "="
    '        s = s & vbCrLf & "convert( varchar(255)," & cd.FIELD.Name & ")  from "
    '        s = s & vbCrLf & cd.STRUCT.Name
    '
    '      End If ' �� ������
    '    Else
    '        ' ��������� - ���������� ������� ���������
    '        Select Case cd.Aggregation
    '        Case 0
    '          log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " WRONG REFERENCE DEFINITION - NO AGGREGATION<--ERROR"
    '          GoTo nxt_field
    '        Case 1 'Avg
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), Avg"
    '        Case 2 'Count
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), COUNT"
    '        Case 3 'Sum
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), SUM"
    '        Case 4 'Min
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), Min"
    '        Case 5 'Max
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), Max"
    '        Case 6 'CUSTOM
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), " & cd.CustomFormula
    '        End Select
    '
    '        s = s & vbCrLf & "(" & cd.FIELD.Name & "))  from "
    '        s = s & vbCrLf & cd.STRUCT.Name
    '    End If ' �� ������� ( ��� �������, �� �� � ������ ������)
    '
    '
    '
    '    ' ���� ��� �� ������ �������
    '    Set pros = os
    '    While Not pros.Parent.Parent Is ot
    '      s = s & vbCrLf & " join " & pros.Parent.Parent.Name & " on " & pros.Name & ".ParentStructRowID=" & pros.Parent.Parent.Name & "ID"
    '      Set pros = pros.Parent.Parent
    '    Wend
    '    s = s & vbCrLf & " where " & pros.Name & ".InstanceID=@InstID "
    '
    '
    '    ' ���� ���� �������������� ������� �� ����
    '    Select Case cd.Condition
    '    Case 1 '=
    '      s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & "=" & cd.ConditionValue
    '    Case 2 '<>
    '      s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & "<>" & cd.ConditionValue
    '    Case 3 '>
    '      s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & ">" & cd.ConditionValue
    '    Case 4 '>=
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & ">=" & cd.ConditionValue
    '    Case 5 '<
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & "<" & cd.ConditionValue
    '    Case 6 '<=
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & "<=" & cd.ConditionValue
    '    Case 7 'like
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & " like " & cd.ConditionValue
    '    Case 8 'is null
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & " is null"
    '    Case 9 'is not null
    '     s = s & vbCrLf & " and not " & os.Name & "." & cd.ConditionField.Name & " is null"
    '    End Select
    '
    'nxt_field:
    '  s = s & vbCrLf & "  end  -- end of column: " & cd.Alias
    '  Next
    '  s = s & vbCrLf & "end -- end of proc"
    '  s = s & vbCrLf & "go"
    '
    'nxt_set:
    'Next
    '
    '
    'o.ModuleName = "--Procedures"
    'o.Block = "--ResourceSet proc"
    'o.OutNL s
    '
    '
    '
    'Exit Sub
    'bye:
    'log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
    'Stop
    'Resume
    'End Sub


    '' ������� � �������� ����������� �������� ������
    '' ��������� ��������� ���� ����������� ������ ������� ! � ������������� ������, ���� ���� �� ���������
    '' ��������� ��������������
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'Private Sub CreateResourceSet()
    'Dim st As PART
    'Dim os As PART
    'Dim ot As OBJECTTYPE
    '
    '
    '
    'Dim pros As PART, i As Long, j As Long, f As FIELD
    'Dim s As String
    'On Error GoTo bye
    'For i = 1 To m.RESOURCESET.Count
    '  Set r = m.RESOURCESET.Item(i)
    '  log = log & vbCrLf & "-->CreateResourceSet " & r.Name
    '  Set ot = r.ForType
    '
    '  ' ������ �������
    '  s = s & vbCrLf & " create table RS_" & r.Name & "("
    '  s = s & vbCrLf & " RS_" & r.Name & "ID uniqueidentifier not null"
    '  s = s & vbCrLf & " ,ChangeStamp datetime not null default (getdate())"
    '
    '  For j = 1 To r.COLUMNDEF.Count
    '    Set cd = r.COLUMNDEF.Item(j)
    '    s = s & vbCrLf & ", " & MakeName(cd.Alias) & " varchar(255) NULL"
    '  Next
    '
    '  s = s & vbCrLf & ")"
    '  s = s & vbCrLf & "go"
    '
    '
    '
    '  s = s & vbCrLf & "create index PK_RS_" & r.Name & " on rs_" & r.Name & "(RS_" & r.Name & "ID)"
    '  s = s & vbCrLf & "go"
    '
    '
    '  ' ������� ���������
    '  s = s & vbCrLf & "create proc " & ot.Name & "_RS_" & r.Name & "(@InstID uniqueidentifier "
    '  ' ��������� ���������
    '  For j = 1 To r.COLUMNDEF.Count
    '  Set cd = r.COLUMNDEF.Item(j)
    '  s = s & vbCrLf & ", @" & MakeName(cd.Alias) & " varchar(255) =NULL output"
    '  Next
    '  s = s & vbCrLf & ") as -- proc start"
    '  s = s & vbCrLf & "begin"
    '  For j = 1 To r.COLUMNDEF.Count
    '  Set cd = r.COLUMNDEF.Item(j)
    '  s = s & vbCrLf & "set @" & MakeName(cd.Alias) & "=null"
    '  Next
    '
    '
    '  s = s & vbCrLf & "if exists(select 1 from Instance join  RS_" & r.Name & " on"
    '  s = s & vbCrLf & "   Instance.instanceid = RS_" & r.Name & ".RS_" & r.Name & "id And Instance.ChangeStamp <= RS_" & r.Name & ".ChangeStamp"
    '  s = s & vbCrLf & "   and Instance.instanceid=@instid)"
    '  s = s & vbCrLf & "begin"
    '  s = s & vbCrLf & "  select"
    '  For j = 1 To r.COLUMNDEF.Count
    '    Set cd = r.COLUMNDEF.Item(j)
    '    If j > 1 Then s = s & ","
    '    s = s & vbCrLf & "      @" & MakeName(cd.Alias) & "=[" & MakeName(cd.Alias) & "]"
    '  Next
    '  s = s & vbCrLf & "  from RS_" & r.Name & " where RS_" & r.Name & "ID=@InstID"
    '  s = s & vbCrLf & "   Return"
    '  s = s & vbCrLf & " End"
    '
    '
    '
    '  For j = 1 To r.COLUMNDEF.Count
    '    Set cd = r.COLUMNDEF.Item(j)
    '    s = s & vbCrLf & "  begin  -- begin of column: " & cd.Alias
    '
    '    If cd.STRUCT Is Nothing Then
    '      log = log & vbCrLf & "ERROR-->STRUCT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " NOT DEFINED<--ERROR"
    '      GoTo nxt_field
    '    End If
    '    If Not TypeForStruct(cd.STRUCT) Is ot Then
    '      log = log & vbCrLf & "ERROR-->STRUCT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " GIVEN FROM ANOTHER OBJECTTYPE<--ERROR"
    '      GoTo nxt_field
    '    End If
    '    Set os = cd.STRUCT
    '    If os.PartType <> 0 And cd.Aggregation = 0 Then
    '      log = log & vbCrLf & "ERROR-->AGGREGATION FUNCTION FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " NOT DEFINED<--ERROR"
    '      GoTo nxt_field
    '    End If
    '    If Not os Is cd.FIELD.Parent.Parent Then
    '      log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " STRUCT AND FIELD FROM DIFERENT OBJECTS<--ERROR"
    '      GoTo nxt_field
    '    End If
    '
    '    ' �������� ������ ��� �������� �������
    '    If cd.STRUCT.PartType = 0 And TypeForStruct(cd.STRUCT) Is r.ForType Then
    '      If cd.FIELD.FIELDTYPE.ISREFERENCE Then
    '        If Not cd.RefExpandPart Is Nothing And cd.RefExpandField <> "" Then
    '          '0-��������� ���� ( �� ������)
    '          '1-�� ������
    '          '2-�� ����� �������
    '
    '
    '          If cd.FIELD.ReferenceType = 2 Then
    '            If Not cd.FIELD.RefToPart Is cd.RefExpandPart Then
    '              log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " WRONG REFERENCE EXPANDING<--ERROR"
    '              GoTo nxt_field
    '            End If
    '          End If
    '
    '
    '          If cd.FIELD.ReferenceType = 1 Then
    '            If cd.FIELD.RefToType Is Nothing Then
    '              log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " TYPE FOR REFERENCE EXPANDING UNKNOWN<--ERROR"
    '              GoTo nxt_field
    '            Else
    '              If Not TypeForStruct(cd.RefExpandPart) Is cd.FIELD.RefToType Then
    '                log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " TYPE FOR REFERENCE EXPANDING DIFFERENT<--ERROR"
    '                GoTo nxt_field
    '              End If
    '              If cd.RefExpandPart.PartType <> 0 Then
    '                log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " FOR REFERENCE EXPANDING - EXPAND FROM COLLECTION PART<--ERROR"
    '                GoTo nxt_field
    '              End If
    '              If Not cd.RefExpandPart.Parent.Parent Is TypeForStruct(cd.RefExpandPart) Then
    '                log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " FOR REFERENCE EXPANDING - EXPAND INTERNAL PART<--ERROR"
    '                GoTo nxt_field
    '              End If
    '            End If
    '          End If
    '        Else
    '          log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " WRONG REFERENCE DEFINITION<--ERROR"
    '          GoTo nxt_field
    '        End If
    '
    '        If cd.FIELD.ReferenceType = 2 Then
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), " & cd.RefExpandField & ")   from  " & cd.RefExpandPart.Name
    '          s = s & vbCrLf & " join " & os.Name & " on "
    '          s = s & vbCrLf & " " & cd.RefExpandPart.Name & "." & cd.RefExpandPart.Name & "id=" & os.Name & "." & cd.FIELD.Name & " "
    '        End If
    '
    '        If cd.FIELD.ReferenceType = 1 Then
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), " & cd.RefExpandField & ")   from  " & cd.RefExpandPart.Name
    '          s = s & vbCrLf & " join " & os.Name & " on "
    '          s = s & vbCrLf & " " & cd.RefExpandPart.Name & ".INSTANCEID=" & os.Name & "." & cd.FIELD.Name & " "
    '        End If
    '      Else
    '        s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "="
    '        s = s & vbCrLf & "convert( varchar(255)," & cd.FIELD.Name & ")  from "
    '        s = s & vbCrLf & cd.STRUCT.Name
    '
    '      End If ' �� ������
    '    Else
    '        ' ��������� - ���������� ������� ���������
    '        Select Case cd.Aggregation
    '        Case 0
    '          log = log & vbCrLf & "ERROR-->DATA CONFLICT FOR COLUMN " & cd.Alias & " IN RESOURCESET " & r.Name & " WRONG REFERENCE DEFINITION - NO AGGREGATION<--ERROR"
    '          GoTo nxt_field
    '        Case 1 'Avg
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), Avg"
    '        Case 2 'Count
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), COUNT"
    '        Case 3 'Sum
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), SUM"
    '        Case 4 'Min
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), Min"
    '        Case 5 'Max
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), Max"
    '        Case 6 'CUSTOM
    '          s = s & vbCrLf & "select @" & MakeName(cd.Alias) & "=convert( varchar(255), " & cd.CustomFormula
    '        End Select
    '
    '        s = s & vbCrLf & "(" & cd.FIELD.Name & "))  from "
    '        s = s & vbCrLf & cd.STRUCT.Name
    '    End If ' �� ������� ( ��� �������, �� �� � ������ ������)
    '
    '
    '
    '    ' ���� ��� �� ������ �������
    '    Set pros = os
    '    While Not pros.Parent.Parent Is ot
    '      s = s & vbCrLf & " join " & pros.Parent.Parent.Name & " on " & pros.Name & ".ParentStructRowID=" & pros.Parent.Parent.Name & "ID"
    '      Set pros = pros.Parent.Parent
    '    Wend
    '    s = s & vbCrLf & " where " & pros.Name & ".InstanceID=@InstID "
    '
    '
    '    ' ���� ���� �������������� ������� �� ����
    '    Select Case cd.Condition
    '    Case 1 '=
    '      s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & "=" & cd.ConditionValue
    '    Case 2 '<>
    '      s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & "<>" & cd.ConditionValue
    '    Case 3 '>
    '      s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & ">" & cd.ConditionValue
    '    Case 4 '>=
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & ">=" & cd.ConditionValue
    '    Case 5 '<
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & "<" & cd.ConditionValue
    '    Case 6 '<=
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & "<=" & cd.ConditionValue
    '    Case 7 'like
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & " like " & cd.ConditionValue
    '    Case 8 'is null
    '     s = s & vbCrLf & " and " & os.Name & "." & cd.ConditionField.Name & " is null"
    '    Case 9 'is not null
    '     s = s & vbCrLf & " and not " & os.Name & "." & cd.ConditionField.Name & " is null"
    '    End Select
    '
    'nxt_field:
    '  s = s & vbCrLf & "  end  -- end of column: " & cd.Alias
    '  Next
    '
    '
    '  s = s & vbCrLf & "-- save"
    '  s = s & vbCrLf & "      Print 'save'"
    '  s = s & vbCrLf & "begin tran"
    '  s = s & vbCrLf & "      delete from RS_" & r.Name & " where RS_" & r.Name & "ID=@InstID"
    '  s = s & vbCrLf & "insert into RS_" & r.Name & "("
    '  s = s & vbCrLf & "RS_" & r.Name & "ID,"
    '  s = s & vbCrLf & "ChangeStamp"
    '
    '
    '  For j = 1 To r.COLUMNDEF.Count
    '    Set cd = r.COLUMNDEF.Item(j)
    '    s = s & vbCrLf & ", [" & MakeName(cd.Alias) & "]"
    '  Next
    '  s = s & vbCrLf & ") Values("
    '  s = s & vbCrLf & "@InstID,"
    '  s = s & vbCrLf & "getdate()"
    '
    '  For j = 1 To r.COLUMNDEF.Count
    '    Set cd = r.COLUMNDEF.Item(j)
    '    s = s & vbCrLf & ", @" & MakeName(cd.Alias)
    '  Next
    '  s = s & vbCrLf & ")"
    '  s = s & vbCrLf & "commit"
    '
    '  s = s & vbCrLf & "end -- end of proc"
    '  s = s & vbCrLf & "go"
    '
    'nxt_set:
    'Next
    '
    '
    'o.ModuleName = "--Procedures"
    'o.Block = "--ResourceSet proc"
    'o.OutNL s
    '
    '
    '
    'Exit Sub
    'bye:
    'log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
    'Stop
    'Resume
    'End Sub


    Private Sub CreateTypeProcs(ByVal obt As OBJECTTYPE)
        Dim chos As PART
        Dim s As String
        s = "create proc " & obt.Name & "_DELETE(@cursession uniqueidentifier, @InstanceID uniqueidentifier) as  "
        ' delete from root structure of object  - child of instance
        Dim tos As Integer
        s = s & vbCrLf & "declare @ObjType as varchar(255), @childlistid uniqueidentifier"
        s = s & vbCrLf & "select  @ObjType =objtype from instance where instanceid=@instanceid"
        s = s & vbCrLf & "if  @ObjType ='" & obt.Name & "'"
        s = s & vbCrLf & "begin"
        If obt.PART.Count > 0 Then
            For tos = 1 To obt.PART.Count
                chos = obt.PART.Item(tos)
                s = s & vbCrLf & "declare childlist_" & chos.Name & " cursor for select " & chos.Name & "." & chos.Name & "id from " & chos.Name & " where  " & chos.Name & ".InstanceID = @instanceid"
                s = s & vbCrLf & "open childlist_" & chos.Name & ""
                s = s & vbCrLf & "fetch next from childlist_" & chos.Name & " into @childlistid"
                s = s & vbCrLf & "while @@fetch_status >=0 "
                s = s & vbCrLf & "begin"
                s = s & vbCrLf & " exec " & chos.Name & "_DELETE @cursession,@childlistid"
                s = s & vbCrLf & " if @@error >0 begin"
                s = s & vbCrLf & "   close childlist_" & chos.Name & ""
                s = s & vbCrLf & "   deallocate childlist_" & chos.Name & " "
                s = s & vbCrLf & "   goto del_error"
                s = s & vbCrLf & " end"
                s = s & vbCrLf & " fetch next from childlist_" & chos.Name & " into @childlistid"
                s = s & vbCrLf & "end"
                s = s & vbCrLf & "close childlist_" & chos.Name & ""
                s = s & vbCrLf & "deallocate childlist_" & chos.Name & " "
            Next
        End If
        s = s & vbCrLf & "return"
        s = s & vbCrLf & "del_error:"
        s = s & vbCrLf & "if @@trancount>0 rollback tran"
        s = s & vbCrLf & "end"
        s = s & vbCrLf & "go"



        log = log & vbCrLf & "Create common procs for type " & obt.Name
        o.ModuleName = "--Procs"
        o.Block = "--body"
        o.OutNL(s)
        o.OutNL("GO")

    End Sub



    Private Sub MakeViews(ByVal pv As PARTVIEW)
        Dim s As String
        Dim ot As OBJECTTYPE
        Dim BP As PART
        Dim p As PART
        Dim refp As PART
        Dim F As FIELD
        Dim ft As FIELDTYPE
        Dim root As PART
        Dim vc As ViewColumn
        Dim i As Long, j As Long
        Dim from As String, group As String
        Dim noagg As Long
        On Error GoTo bye

        BP = pv.Parent.Parent

        ' ����� ������ ������� ������
        root = BP
        from = " from " & BP.Name
        While TypeName(root.Parent.Parent) <> "OBJECTTYPE"
            from = from & vbCrLf & " join " & CType(root.Parent.Parent, PART).Name & " on " & CType(root.Parent.Parent, PART).Name & "." & CType(root.Parent.Parent, PART).Name & "ID=" & root.Name & ".ParentStructRowID "
            root = root.Parent.Parent
        End While

        group = " group by " & root.Name & ".InstanceID, " & BP.Name & "." & BP.Name & "ID "

        s = "create view V_" & pv.the_Alias & " as "
        s = s & vbCrLf & " select "
        For i = 1 To pv.ViewColumn.Count
            vc = pv.ViewColumn.Item(i)
            p = vc.FromPart
            F = vc.Field
            If i > 1 Then
                s = s & vbCrLf & ", "
            Else
                s = s & vbCrLf & " "
            End If
            If vc.Aggregation = enumAggregationType.AggregationType_none Then
                ft = F.FieldType
                If ft.TypeStyle = enumTypeStyle.TypeStyle_Perecislenie Then
                    s = s & vbCrLf & " case " & p.Name & "." & F.Name & " "
                    For j = 1 To ft.ENUMITEM.Count
                        s = s & vbCrLf & "when " & ft.ENUMITEM.Item(j).NameValue & " then '" & ft.ENUMITEM.Item(j).Name & "'"
                    Next
                    s = s & vbCrLf & " end "
                ElseIf ft.TypeStyle = enumTypeStyle.TypeStyle_Ssilka Then
                    If F.ReferenceType = enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                        s = s & vbCrLf & " dbo.INSTANCE_BRIEF_F(" & p.Name & "." & F.Name & ") "
                    ElseIf F.ReferenceType = enumReferenceType.ReferenceType_Na_stroku_razdela Then
                        refp = CType(F.RefToPart, PART)
                        s = s & vbCrLf & " dbo." & refp.Name & "_BRIEF_F(" & p.Name & "." & F.Name & ") "
                    Else
                        s = s & vbCrLf & p.Name & "." & F.Name & " "
                    End If
                Else

                    s = s & vbCrLf & p.Name & "." & F.Name & " "
                End If


                noagg = noagg + 1
                group = group & vbCrLf & "," & p.Name & "." & F.Name & " "
            ElseIf vc.Aggregation = enumAggregationType.AggregationType_MAX Then
                s = s & vbCrLf & "MAX(" & p.Name & "." & F.Name & ") "
            ElseIf vc.Aggregation = enumAggregationType.AggregationType_MIN Then
                s = s & vbCrLf & "MIN(" & p.Name & "." & F.Name & ") "
            ElseIf vc.Aggregation = enumAggregationType.AggregationType_AVG Then
                s = s & vbCrLf & "AVG(" & p.Name & "." & F.Name & ") "
            ElseIf vc.Aggregation = enumAggregationType.AggregationType_SUM Then
                s = s & vbCrLf & "SUM(" & p.Name & "." & F.Name & ") "
            ElseIf vc.Aggregation = enumAggregationType.AggregationType_COUNT Then
                s = s & vbCrLf & "COUNT(" & p.Name & "." & F.Name & ") "
            End If
            s = s & vc.the_Alias & " "
            Dim isOK As Boolean
            If BP.ID = p.Parent.Parent.ID Then
                isOK = False
                For j = 1 To i - 1
                    If pv.ViewColumn.Item(j).FromPart.ID = p.ID Then
                        isOK = True
                        Exit For
                    End If
                Next
                If Not isOK Then
                    from = from & vbCrLf & " left join " & p.Name & " on " & BP.Name & "." & BP.Name & "ID = " & p.Name & ".ParentStructRowID"
                End If
            End If


            If TypeName(p.Parent.Parent) = "OBJECTTYPE" And (p.ID <> root.ID) Then
                isOK = False
                For j = 1 To i - 1
                    If pv.ViewColumn.Item(j).FromPart.ID = p.ID Then
                        isOK = True
                        Exit For
                    End If
                Next
                If Not isOK Then
                    from = from & vbCrLf & " left join " & p.Name & " ON " & p.Name & ".InstanceID=" & root.Name & ".InstanceID"
                End If
            End If

        Next
        If pv.ViewColumn.Count > 0 Then
            s = s & vbCrLf & ", " & root.Name & ".InstanceID InstanceID "
        Else
            s = s & vbCrLf & " " & root.Name & ".InstanceID InstanceID "
        End If

        s = s & vbCrLf & ", " & BP.Name & "." & BP.Name & "ID ID "
        s = s & vbCrLf & ", '" & BP.Name & "' VIEWBASE "

        ' if no aggregations - no group by
        If noagg = pv.ViewColumn.Count Then group = ""

        o.ModuleName = "--Views--"
        o.Block = "--Views--"
        o.OutNL(s & vbCrLf & from & vbCrLf & group)
        o.OutNL("GO")
        Exit Sub
bye:
        '  Stop
        '  Resume
    End Sub


    Private Function IsParent(ByVal p As PART, ByVal Parent As String) As Boolean
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

    '' ������� view ��� ��������
    'Private Sub MakeJournals()
    '    Dim jr As MTZJrnl.MTZJrnl.Journal
    '    Dim jc As MTZJrnl.MTZJrnl.JournalColumn
    '    Dim js As MTZJrnl.MTZJrnl.JournalSrc
    '    Dim jcs As MTZJrnl.MTZJrnl.JColumnSource
    '    Dim s As String, out As String

    '    Dim i As Long, j As Long, k As Long, l As Long, NoCol As Boolean
    '    For i = 1 To m.Jounal.Count
    '        jr = m.Jounal.Item(i)
    '        s = "create view J_" & jr.Name & " as  " & vbCrLf
    '        For j = 1 To jr.JournalSrc.Count
    '            js = jr.JournalSrc.Item(j)
    '            If j > 1 Then s = s & vbCrLf & " union all " & vbCrLf
    '            s = s & vbCrLf & " select InstanceID, ID, VIEWBASE "
    '            For k = 1 To jr.JournalColumn.Count
    '                NoCol = True
    '                jc = jr.JournalColumn.Item(k)
    '                For l = 1 To jc.JColumnSource.Count
    '                    jcs = jc.JColumnSource.Item(l)
    '                    If jcs.SrcPartView.ID = js.ID Then
    '                        s = s & vbCrLf & ", " & jcs.ViewField & " /* " & jc.Name & " */ "
    '                        NoCol = False
    '                    End If
    '                Next l
    '                If NoCol Then
    '                    s = s & vbCrLf & ", null /* " & jc.Name & " */ "
    '                End If
    '            Next k
    '            s = s & vbCrLf & " from V_" & js.PARTVIEW.Alias

    '        Next j
    '        o.ModuleName = "--Journals--"
    '        o.Block = "--Journals--"
    '        o.OutNL(s)
    '        o.OutNL("GO")
    '    Next i
    'End Sub
End Class