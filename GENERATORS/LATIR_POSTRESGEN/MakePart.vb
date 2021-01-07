Imports MTZMetaModel.MTZMetaModel
Imports LATIRGenerator

Friend Class MakePart
	
    Dim m As Application
    Dim o As Response
    Dim tid As String
    Dim parent As Generator
    Dim ot As OBJECTTYPE

    Public Sub Init(ByRef atype As MTZMetaModel.MTZMetaModel.OBJECTTYPE, ByRef ap As Generator, ByRef am As MTZMetaModel.MTZMetaModel.Application, ByRef ao As LatirGenerator.Response, ByVal atid As String)
        ot = atype
        parent = ap
        m = am
        o = ao
        tid = atid
    End Sub

    Public Sub Run(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        CreateProcHdr(os)
        CreateBriefProc(os)
        CreateDelProc(os)
        CreateProc(os)
        CreateV2Proc(os)

        Dim cos As MTZMetaModel.MTZMetaModel.PART
        Dim mp As MakePart
        Dim j As Integer
        For j = 1 To os.PART.Count
            cos = os.PART.Item(j)
            mp = New MakePart
            mp.Init(ot, parent, m, o, tid)
            mp.Run(cos)
        Next
    End Sub

    Private Sub CreateProcHdr(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As Writer
        s = New Writer

        On Error GoTo bye
        s.putBuf(" create or replace function  " & VF(os.Name) & "_BRIEF  (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" a" & VF(os.Name) & "id uuid")
        s.putBuf(") returns varchar as $$ begin end; $$ language 'plpgsql';")
        s.putBuf("GO")

        s.putBuf(" create or replace function  " & VF(os.Name) & "_DELETE  (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" a" & VF(os.Name) & "id uuid,")
        s.putBuf(" ainstanceid uuid")
        s.putBuf(") returns void as $$ begin end; $$ language 'plpgsql'; ")
        s.putBuf("GO")

        s.putBuf(" create or replace function  " & VF(os.Name) & "_SAVE (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" a" & VF(os.Name) & "id uuid,")
        s.putBuf("ainstanceid uuid ")
        If TypeName(os.Parent.Parent) <> "OBJECTTYPE" Then
            s.putBuf(", aParentStructRowID uuid ")
        End If

        ' дерево - родительская связь
        If os.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            s.putBuf(", aParentRowid uuid ")
        End If

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            s.putBuf("," & parent.FieldForParam(st.FIELD.Item(i)))
        Next
        s.putBuf(")returns void  as $$ begin end; $$ language 'plpgsql'; ")
        s.putBuf("GO")

        s.putBuf(" create or replace function  " & VF(os.Name) & "_PARENT_ID  (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid ")
        s.putBuf(") returns uuid as $$ begin end; $$ language 'plpgsql';")
        s.putBuf("GO")

        s.putBuf(" create or replace function  " & VF(os.Name) & "_PARENT_T  (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid ")
        s.putBuf(") returns varchar as $$ begin end; $$ language 'plpgsql';")
        s.putBuf("GO")

        s.putBuf(" create or replace function  " & VF(os.Name) & "_ISLOCKED  (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid ")
        s.putBuf(") returns integer as $$ begin end; $$ language 'plpgsql';")
        s.putBuf("GO")

        s.putBuf(" create or replace function  " & VF(os.Name) & "_LOCK  (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid ,")
        s.putBuf(" aLockMode integer ")
        s.putBuf(") returns void as $$ begin end; $$ language 'plpgsql';")
        s.putBuf("GO")

        s.putBuf(" create or replace function  " & VF(os.Name) & "_HCL(")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid")
        s.putBuf(") returns integer as $$ begin  return 0 ; end; $$ language 'plpgsql'")
        s.putBuf("GO")

        s.putBuf(" create or replace function  " & VF(os.Name) & "_UNLOCK (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid ")
        s.putBuf(") returns void as $$ begin end; $$ language 'plpgsql';")
        s.putBuf("GO")

        s.putBuf(" create or replace function  " & VF(os.Name) & "_SINIT  (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid ,")
        s.putBuf(" aSecurityStyleID uuid")
        s.putBuf(") returns void as $$ begin end; $$ language 'plpgsql';")
        s.putBuf("GO")

        s.putBuf(" create or replace function  " & VF(os.Name) & "_propagate(")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid")
        s.putBuf(")  returns void as $$ begin end; $$ language 'plpgsql';")
        s.putBuf("GO")


        o.ModuleName = "--functions.Type.Header"
        o.Block = "--" & ot.Name
        o.OutNL(s.getBuf)
        s = Nothing
        Exit Sub
bye:
        'Resume
        s = Nothing
    End Sub






    Private Sub CreateBriefProc(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        System.Diagnostics.Debug.Print("POSTGRESGEN.CreateBriefProc:start ")
        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As Writer
        s = New Writer
        On Error GoTo bye
        s.putBuf("")
        s.putBuf(" create or replace function  " & VF(os.Name) & "_BRIEF  (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" a" & VF(os.Name) & "id uuid")
        s.putBuf(") returns varchar as $$")
        s.putBuf("declare")
        s.putBuf(" aBRIEF varchar(255);")
        s.putBuf(" aaccess integer;")
        s.putBuf(" atmpStr varchar(255);")
        s.putBuf(" atmpID uuid;")
        s.putBuf(" existsCnt integer;")
        s.putBuf("begin")
        s.putBuf(" -- checking the_session  --")
        s.putBuf(" select count(*) into existsCnt from the_session where the_sessionid=acursession and closed=0 ;")
        s.putBuf("if existsCnt=0")
        s.putBuf("  then")
        s.putBuf("     perform  raise_application_error(-20000,'Сессия уже завершена.');")
        s.putBuf("    return '';")
        s.putBuf("  end if;")

        s.putBuf("if a" & VF(os.Name) & "id is null then aBRIEF:=''; return aBrief; end if;")

        s.putBuf(" -- Brief body -- ")
        s.putBuf("select count(*)into existsCnt from " & VF(os.Name) & " where " & VF(os.Name) & "ID=a" & VF(os.Name) & "ID;")
        s.putBuf("if existsCnt >0")
        s.putBuf(" then")
        's.putBuf " --  verify access  --"
        's.putBuf " select  SecurityStyleID into atmpid from " & VF(os.Name) & " where " & VF(os.Name) & "id=a" & VF(os.Name) & "ID;"
        's.putBuf " CheckVerbRight (acursession,atmpID,'BRIEF',aaccess); "
        's.putBuf " if aaccess=0 "
        's.putBuf "  then"
        's.putBuf "     perform  raise_application_error(-20000,'No access for BRIEF Structure=" & VF(os.Name) & "');"
        's.putBuf "    return;"
        's.putBuf "  end if;"
        s.putBuf("  aBRIEF:= " & VF(os.Name) & "_BRIEF_F(a" & VF(os.Name) & "id);")
        s.putBuf("else")
        s.putBuf("  aBRIEF:= 'неверный идентификатор';")
        s.putBuf("end if;")
        s.putBuf(" aBRIEF:=substr(aBRIEF,1,255);")
        s.putBuf("return aBrief;")
        s.putBuf("end;  $$ language 'plpgsql';")
        s.putBuf("GO")

        o.ModuleName = "--functions.Type.Body"
        o.Block = "--" & ot.Name
        o.OutNL(s.getBuf)
        System.Diagnostics.Debug.Print("POSTGRESGEN.CreateBriefProc:done ")
        s = Nothing
        Exit Sub
bye:
        'Resume
        s = Nothing
    End Sub

    Private Sub CreateDelProc(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        System.Diagnostics.Debug.Print("POSTGRESGEN.CreateDelProc:start " & os.Caption)
        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i As Short
        Dim s As Writer
        s = New Writer



        On Error GoTo bye



        s.putBuf(" create or replace function  " & VF(os.Name) & "_DELETE /*" & os.the_Comment & "*/ (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" a" & VF(os.Name) & "id uuid,")
        s.putBuf(" ainstanceid uuid")
        s.putBuf(") returns void as $$ ")
        s.putBuf(" declare ")
        s.putBuf(" aCurs refcursor;")
        If Not os.NoLog Then s.putBuf(" aSysLogID uuid;")
        s.putBuf(" aaccess integer;")
        s.putBuf(" aSysInstID uuid;")
        s.putBuf(" atmpID uuid;")
        s.putBuf(" aID uuid;")
        s.putBuf(" existsCnt integer;")
        s.putBuf(" aChildListid uuid;")
        s.putBuf("  begin  ")
        s.putBuf(" select  Instanceid into aSysInstID from instance where objtype='MTZSYSTEM';")

        s.putBuf(" select count(*) into existsCnt from the_session where the_sessionid=acursession and closed=0 ;")
        s.putBuf("if existsCnt=0 then")
        s.putBuf("     perform  raise_application_error(-20000,'Сессия уже завершена.');")
        s.putBuf("    return;")
        s.putBuf("end if;")

        s.putBuf(" -- Delete body -- ")
        s.putBuf("select count(*) into existsCnt from " & VF(os.Name) & " where " & VF(os.Name) & "ID=a" & VF(os.Name) & "ID;")
        s.putBuf("if existsCnt >0 then")

        '  s.putBuf " --  verify access  --"
        '  s.putBuf " select   SecurityStyleID into atmpID from " & VF(os.Name) & " where " & VF(os.Name) & "id=a" & VF(os.Name) & "ID;"
        '  s.putBuf " CheckVerbRight (acursession,atmpID,'DELETEROW',aaccess ) ;"
        '  s.putBuf " if aaccess=0 then "
        '  s.putBuf "    CheckVerbRight (acursession,atmpID,'DELETEROW:" & VF(os.Name) & "',aaccess); "
        '  s.putBuf "    if aaccess=0 then"
        '  s.putBuf "       perform  raise_application_error(-20000,'Нет прав на удаление. Раздел=" & VF(os.Name) & "');"
        '  s.putBuf "      return;"
        '  s.putBuf "    end if;"
        '  s.putBuf "  end if;"

        s.putBuf(" --  verify lock  --")
        s.putBuf(" aaccess:=  " & VF(os.Name) & "_ISLOCKED( acursession,a" & VF(os.Name) & "id); ")
        s.putBuf(" if aaccess>2 ")
        s.putBuf("  then")
        s.putBuf("     perform  raise_application_error(-20000,'Строка заблокирована другим пользователем. Раздел=" & VF(os.Name) & "');")
        s.putBuf("    return;")
        s.putBuf("  end if;")


        s.putBuf("  --begin tran--  ")

        s.putBuf(" -- erase child items --")

        If os.PART.Count > 0 Then
            s.putBuf("-- delete in-struct child")
        End If


        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)


            s.putBuf("Open aCurs for select " & VF(chos.Name) & "." & VF(chos.Name) & "id ID from " & VF(chos.Name) & " where  " & VF(chos.Name) & ".ParentStructRowID = a" & VF(os.Name) & "id;")
            s.putBuf("loop")

            s.putBuf("FETCH aCurs INTO aID;")
            s.putBuf("If Not FOUND Then")
            s.putBuf("    EXIT;  -- exit loop")
            s.putBuf(" END IF;")
            s.putBuf(" PERFORM  " & VF(chos.Name) & "_DELETE (acursession,aID,aInstanceID);")
            s.putBuf("END LOOP;")


            s.putBuf("close aCurs;")


        Next



        If Not os.NoLog Then
            s.putBuf("select  newid() into aSysLogid;")
            s.putBuf(" PERFORM  SysLog_SAVE (acursession , aSysLogid, aSysInstID, acursession,  '" & VF(os.Name) & "',")
            s.putBuf("  cast( a" & VF(os.Name) & "id as varchar), 'DELETEROW', aInstanceID);")
        End If

        ' Удаляем зависимые документы!!!
        s.putBuf("open aCurs for select  instanceid ID from instance where OwnerPartName ='" & VF(os.Name) & "' and OwnerRowID=a" & VF(os.Name) & "id;")
        s.putBuf("loop")

        s.putBuf("FETCH aCurs INTO aID;")
        s.putBuf("If Not FOUND Then")
        s.putBuf("    EXIT;  -- exit loop")
        s.putBuf(" END IF;")
        s.putBuf(" PERFORM  INSTANCE_OWNER (acursession,aid,null,null);")
        s.putBuf(" PERFORM  INSTANCE_DELETE (acursession,aid);")
        s.putBuf("END LOOP;")

        s.putBuf("close aCurs;")


        s.putBuf("  delete from  " & VF(os.Name) & " ")
        s.putBuf("  where  " & VF(os.Name) & "ID = a" & VF(os.Name) & "ID; ")

        s.putBuf(" end if;")
        s.putBuf(" -- close transaction --")

        s.putBuf(" existsCnt:=0;")
        s.putBuf("end; $$ language 'plpgsql';")
        s.putBuf("GO")
        o.ModuleName = "--functions.Type.Body"
        o.Block = "--" & ot.Name
        o.OutNL(s.getBuf)

        s = Nothing
        System.Diagnostics.Debug.Print("POSTGRESGEN.CreateDelProc:done " & os.Caption)
        Exit Sub
bye:

        'Resume
        s = Nothing
    End Sub



    Private Sub CreateProc(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i As Short
        Dim s As Writer
        s = New Writer



        On Error GoTo bye

        s.putBuf("/*" & os.Caption & "*/")

        s.putBuf(" create or replace function  " & VF(os.Name) & "_SAVE /*" & os.the_Comment & "*/ (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" a" & VF(os.Name) & "id uuid,")
        s.putBuf("ainstanceid uuid ")

        If TypeName(os.Parent.Parent) <> "OBJECTTYPE" Then
            s.putBuf(", aParentStructRowID uuid ")
        End If

        ' дерево - родительская связь
        If os.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            s.putBuf(", aParentRowid uuid ")
        End If

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            s.putBuf("," & parent.FieldForParam(st.FIELD.Item(i)))
        Next

        s.putBuf(")  returns void as $$")
        s.putBuf(" declare ")
        If Not os.NoLog Then s.putBuf("aSysLogid uuid;")
        s.putBuf(" aUniqueRowCount integer;")
        s.putBuf(" atmpStr varchar(255);")
        s.putBuf(" atmpID uuid;")
        s.putBuf(" aaccess int;")
        s.putBuf(" aSysInstID uuid;")
        s.putBuf(" existsCnt integer;")
        s.putBuf(" begin  ")
        s.putBuf(" select Instanceid into aSysInstID from instance where objtype='MTZSYSTEM';")

        s.putBuf(" -- checking the_session  --")
        s.putBuf(" select count(*) into existsCnt from " & VF("the_session") & " where " & VF("the_session") & "id=acursession and closed=0 ;")
        s.putBuf("if existsCnt =0 ")
        s.putBuf("  then")
        s.putBuf("     perform  raise_application_error(-20000,'Сессия уже завершена.');")
        s.putBuf("    return;")
        s.putBuf("  end if;")

        's.putbuf " -- checking references  --" & vbCrLf
        'For i = 1 To st.FIELD.Count
        '  s = s & ReferenceCheck(os, st.FIELD.Item(i)) & vbCrLf
        'Next

        s.putBuf(" -- Insert / Update body -- ")

        s.putBuf("select count(*) into existsCnt from " & VF(os.Name) & " where " & VF(os.Name) & "ID=a" & VF(os.Name) & "ID;")
        s.putBuf("if existsCnt >0")
        s.putBuf(" then")

        s.putBuf(" --  UPDATE  --")

        's.putBuf " --  verify access  --"
        '
        's.putBuf " select SecurityStyleID into atmpID from " & VF(os.Name) & " where " & VF(os.Name) & "id=a" & VF(os.Name) & "ID;"
        's.putBuf " CheckVerbRight( acursession,atmpID,'EDITROW',aaccess); "
        's.putBuf " if aaccess=0 "
        's.putBuf "  then"
        's.putBuf "    CheckVerbRight (acursession,atmpID,'EDITROW:" & VF(os.Name) & "',aaccess ); "
        's.putBuf "    if aaccess=0 "
        's.putBuf "    then"
        's.putBuf "       perform  raise_application_error(-20000,'Нет прав на модификацию. Раздел=" & VF(os.Name) & "');"
        's.putBuf "      return;"
        's.putBuf "    end if;"
        's.putBuf "  end if;"

        s.putBuf(" --  verify lock  --")

        s.putBuf(" aaccess:=  " & VF(os.Name) & "_ISLOCKED( acursession,a" & VF(os.Name) & "id); ")
        s.putBuf(" if aaccess>2 ")
        s.putBuf("  then")
        s.putBuf("     perform  raise_application_error(-20000,'Строка заблокирована другим пльзователем. Раздел=" & VF(os.Name) & "');")
        s.putBuf("    return;")
        s.putBuf("  end if;")


        's.putBuf " begin tran  "

        s.putBuf(" -- update row  --")


        If Not os.NoLog Then
            s.putBuf("select newid() into asyslogid;")
            s.putBuf(" PERFORM SysLog_SAVE( acursession, aSysLogid, aSysInstID, acursession,  '" & VF(os.Name) & "',")
            s.putBuf(" cast(a" & VF(os.Name) & "id as varchar),'EDITROW',  aInstanceID);")
        End If
        s.putBuf(" update  " & VF(os.Name) & " set ChangeStamp=localtimestamp")

        ' дерево модификация связи
        If os.PartType = 2 Then
            s.putBuf(",ParentRowid= aParentRowid")
        End If
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            ft = st.FIELD.Item(i).FieldType
            s.putBuf(",")
            s.putBuf("  " & VF(st.FIELD.Item(i).Name) & "=a" & VF(st.FIELD.Item(i).Name))

            'support extention field if file type used
            If UCase(ft.Name) = "FILE" Then
                s.putBuf("," & VF(st.FIELD.Item(i).Name) & "_EXT=")
                s.putBuf("a" & VF(st.FIELD.Item(i).Name) & "_EXT ")
            End If
        Next

        s.putBuf("  where  " & VF(os.Name) & "ID = a" & VF(os.Name) & "ID; ")

        s.putBuf(" -- checking unique constraints  --")
        s.putBuf(parent.UniqueCheck(os) & vbCrLf)


        s.putBuf(" else")

        s.putBuf(" --  INSERT  --")


        s.putBuf(" --  verify access  --")




        'If TypeName(os.parent.parent) = "OBJECTTYPE" Then
        '    s.putBuf " select  SecurityStyleID into atmpID from instance where instanceid=ainstanceid;"
        'Else
        '    s.putBuf " select  SecurityStyleID into atmpID from " & Ctype(os.parent.parent,Part).Name & " where " & Ctype(os.parent.parent,Part).Name & "id=aParentStructRowID;"
        'End If
        '
        's.putBuf " CheckVerbRight (acursession,atmpID,'CREATEROW',aaccess );"
        's.putBuf " if aaccess=0 "
        's.putBuf "  then"
        's.putBuf "    CheckVerbRight (acursession,atmpID,'CREATEROW:" & VF(os.Name) & "',aaccess); "
        's.putBuf "    if aaccess=0 "
        's.putBuf "    then"
        's.putBuf "       perform  raise_application_error(-20000,'Нет прав на создание строк. Раздел=" & VF(os.Name) & "');"
        's.putBuf "      return;"
        's.putBuf "    end if;"
        's.putBuf " end if;"

        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s.putBuf("aaccess:= instance_ISLOCKED( acursession,aInstanceID); ")
        Else
            s.putBuf(" aaccess:= " & CType(os.Parent.Parent, PART).Name & "_ISLOCKED (acursession,aParentStructRowID); ")
        End If


        s.putBuf(" if aaccess>2 ")
        s.putBuf("  then")
        s.putBuf("     perform  raise_application_error(-20000,'Строка заблокирована другим пльзователем. Раздел=" & VF(os.Name) & "');")
        s.putBuf("    return;")
        s.putBuf("  end if;")



        ' check for single row part
        If os.PartType = 0 Then

            s.putBuf("select Count(*) into existsCnt from " & VF(os.Name) & " where ")

            If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
                s.putBuf("InstanceID=aInstanceID;")
            Else
                s.putBuf("ParentStructRowID=aParentStructRowID;")
            End If
            s.putBuf("if existsCnt >0 ")
            s.putBuf(" then")
            s.putBuf("     perform  raise_application_error(-20000,'Невозможно создать вторую строку в однострочной сессии. Раздел: <" & VF(os.Name) & ">');")
            s.putBuf("    return;")
            s.putBuf(" End if;")
        End If

        's.putBuf " begin tran  "

        If Not os.NoLog Then
            s.putBuf("select newid() into aSysLogID;")
            s.putBuf(" PERFORM SysLog_SAVE( acursession, aSysLogid, aSysInstID,acursession,   '" & VF(os.Name) & "',")
            s.putBuf(" cast(a" & VF(os.Name) & "id as varchar),'CREATEROW',  aInstanceID);")
        End If

        s.putBuf(" insert into   " & VF(os.Name) & vbCrLf & " (  " & VF(os.Name) & "ID ")


        ' дерево  - поле
        If os.PartType = 2 Then
            s.putBuf(",ParentRowid")
        End If

        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s.putBuf(",InstanceID")
        Else
            s.putBuf(",ParentStructRowID")
        End If


        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            s.putBuf("," & VF(st.FIELD.Item(i).Name) & vbCrLf)
            ft = st.FIELD.Item(i).FieldType
            'support extention field if file type used
            If UCase(ft.Name) = "FILE" Then
                s.putBuf("," & VF(st.FIELD.Item(i).Name) & "_EXT")
            End If
        Next

        s.putBuf(" ) values " & "( a" & VF(os.Name) & "ID ")


        ' дерево  - значение поля
        If os.PartType = 2 Then
            s.putBuf(",aParentRowid")
        End If


        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s.putBuf(",aInstanceID")
        Else
            s.putBuf(",aParentStructRowID")
        End If

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            s.putBuf(",a" & VF(st.FIELD.Item(i).Name) & vbCrLf)
            ft = st.FIELD.Item(i).FieldType
            'support extention field if file type used
            If UCase(ft.Name) = "FILE" Then
                s.putBuf(",a" & VF(st.FIELD.Item(i).Name) & "_EXT")
            End If

        Next

        s.putBuf(" ); ")


        s.putBuf(" PERFORM " & VF(os.Name) & "_SINIT( aCURSESSION,a" & VF(os.Name) & "id,atmpid);")

        s.putBuf(" -- checking unique constraints  --")
        s.putBuf(parent.UniqueCheck(os) & vbCrLf)

        s.putBuf(" end if;")


        s.putBuf(" -- close transaction --")

        's.putBuf " if aaerror <>0  if aatrancount>0 rollback tran  "
        's.putBuf " if aatrancount>0 commit tran  "

        s.putBuf(" end; $$ language 'plpgsql'; ")
        s.putBuf("GO")
        o.ModuleName = "--functions.Type.Body"
        o.Block = "--" & ot.Name
        o.OutNL(s.getBuf)

        'System.Diagnostics.Debug.Print "POSTGRESGEN.CreateProc:children " & os.Caption
        'For i = 1 To os.PART.Count
        '  Set chos = os.PART.Item(i)
        '  CreateProc chos
        'Next
        s = Nothing
        System.Diagnostics.Debug.Print("POSTGRESGEN.CreateProc:done " & os.Caption)
        Exit Sub
bye:

        'Resume
        s = Nothing
    End Sub

    Private Sub CreateV2Proc(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        System.Diagnostics.Debug.Print("POSTGRESGEN.CreateV2Proc:start " & os.Caption)
        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i As Short
        Dim s As Writer
        s = New Writer

        System.Windows.Forms.Application.DoEvents()


        On Error GoTo bye


        s.putBuf(" create or replace function  " & VF(os.Name) & "_PARENT_T /*" & os.the_Comment & "*/ (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid ")


        s.putBuf(") returns varchar as $$")
        s.putBuf(" declare ")
        s.putBuf("existsCnt integer;")
        s.putBuf("aParentTable varchar(255);")
        s.putBuf(" begin  ")
        s.putBuf(" -- checking the_session  --")
        s.putBuf("select count(*)into existsCnt from the_session where the_sessionid=acursession and closed=0 ;")
        s.putBuf("if existsCnt=0")
        s.putBuf("  then")
        s.putBuf("     perform  raise_application_error(-20000,'Сессия уже завершена.');")
        s.putBuf("    return '';")
        s.putBuf("  end if;")


        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s.putBuf("  aParentTable := 'INSTANCE';")
            's.putBuf "  select  INSTANCEID into aParentID from " & VF(os.Name) & " where  " & VF(os.Name) & "id=aRowID;"
        Else

            's.putBuf "  select ParentStructRowID into aParentID  from " & VF(os.Name) & " where  " & VF(os.Name) & "id=aRowID;"
            s.putBuf("  aParentTable := '" & CType(os.Parent.Parent, PART).Name & "';")
        End If
        ' End If
        s.putBuf("    return aParentTable;")
        s.putBuf(" end; $$ language 'plpgsql';")
        s.putBuf("GO")


        s.putBuf(" create or replace function  " & VF(os.Name) & "_PARENT_ID /*" & os.the_Comment & "*/ (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid ")
        s.putBuf(") returns uuid as $$")
        s.putBuf(" declare ")
        s.putBuf(" aParentID  uuid ;")
        s.putBuf("existsCnt integer;")
        s.putBuf(" begin  ")
        s.putBuf(" -- checking the_session  --")
        s.putBuf("select count(*)into existsCnt from the_session where the_sessionid=acursession and closed=0 ;")
        s.putBuf("if existsCnt=0")
        s.putBuf("  then")
        s.putBuf("     perform  raise_application_error(-20000,'Сессия уже завершена.');")
        s.putBuf("    return null;")
        s.putBuf("  end if;")


        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            ' s.putBuf "  aParentTable := 'INSTANCE';"
            s.putBuf("  select  INSTANCEID into aParentID from " & VF(os.Name) & " where  " & VF(os.Name) & "id=aRowID;")
        Else

            s.putBuf("  select ParentStructRowID into aParentID  from " & VF(os.Name) & " where  " & VF(os.Name) & "id=aRowID;")
            ' s.putBuf "  aParentTable := '" & Ctype(os.parent.parent,Part).Name & "';"
        End If
        ' End If
        s.putBuf(" return aParentID;")
        s.putBuf(" end; $$ language 'plpgsql';")
        s.putBuf("GO")



        o.ModuleName = "--functions.Type.Body"
        o.Block = "--" & ot.Name
        o.OutNL(s.getBuf)



        '------------------------------- IsLockED ----------------------------------------------
        s = Nothing
        s = New Writer

        s.putBuf(" create or replace function  " & VF(os.Name) & "_ISLOCKED /*" & os.the_Comment & "*/ (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid ")
        s.putBuf(") returns integer as $$ ")
        s.putBuf(" declare ")
        s.putBuf(" aIsLocked  integer;")
        s.putBuf(" aParentID uuid;")
        s.putBuf(" aUserID uuid;")
        s.putBuf(" aLockUserID uuid;")
        s.putBuf(" aLockSessionID uuid;")
        s.putBuf(" aParentTable varchar(255); ")
        s.putBuf(" existsCnt integer; ")
        s.putBuf("  astr varchar(4000);")
        s.putBuf("begin")

        s.putBuf(" aisLocked := 0;")
        s.putBuf(" -- checking the_session  --")
        s.putBuf("select count(*) into existsCnt from the_session where the_sessionid=acursession and closed=0;")
        s.putBuf("if existsCnt=0")
        s.putBuf("  then")
        s.putBuf("     perform  raise_application_error(-20000,'Сессия уже завершена.');")
        s.putBuf("    return 0;")
        s.putBuf("  end if;")

        s.putBuf(" select usersid into auserID from the_session where the_sessionid=acursession;")
        s.putBuf(" select  LockUserID,LockSessionID into aLockUserID, aLockSessionID from " & VF(os.Name) & " where " & VF(os.Name) & "id=aRowID;")
        s.putBuf(" /* verify this row */")
        s.putBuf(" if not aLockUserID is null  ")
        s.putBuf(" then   ")
        s.putBuf("   if  aLockUserID <> auserID  ")
        s.putBuf("   then   ")
        s.putBuf("     aisLocked := 4; /* CheckOut by another user */")
        s.putBuf("     return aisLocked;")
        s.putBuf("   else ")
        s.putBuf("     aisLocked := 2; /* CheckOut by caller */")
        s.putBuf("     return aisLocked;")
        s.putBuf("   end  if; ")
        s.putBuf(" end if;  ")

        s.putBuf(" if not aLockSessionID is null  ")
        s.putBuf(" then   ")
        s.putBuf("   if  aLockSessionID <> aCURSESSION  ")
        s.putBuf("   then   ")
        s.putBuf("     aisLocked := 3; /* Lockes by another user */")
        s.putBuf("     return aisLocked;")
        s.putBuf("   else ")
        s.putBuf("     aisLocked := 1; /* Locked by caller */")
        s.putBuf("     return aisLocked;")
        s.putBuf("   end if;  ")
        s.putBuf(" end if;  ")

        s.putBuf(" aisLocked := 0; ")
        s.putBuf(" return aisLocked; ")
        's.putBuf " select " & VF(os.Name) & "_parent (aCURSESSION,aROWID,aParentID,aParentTable);"
        's.putBuf "  if aparenttable='INSTANCE' then"
        's.putBuf "      astr := 'begin select ' || aPARENTTABLE || '_islocked ($1,$2,$3); end;';"
        's.putBuf "    Else"
        's.putBuf "      astr := 'begin select " & ot.Name & ".' || aPARENTTABLE || '_islocked ($1,$2,$3); end;';"
        's.putBuf "    end if;"
        's.putBuf "  execute   astr using aCURSESSION,aParentID ,out aISLocked;"
        s.putBuf(" end; $$ language 'plpgsql';")
        s.putBuf("GO")


        o.ModuleName = "--functions.Type.Body"
        o.Block = "--" & ot.Name
        o.OutNL(s.getBuf)


        '--------------------------- Блокируем запись
        s = Nothing
        s = New Writer
        s.putBuf(" create or replace function  " & VF(os.Name) & "_LOCK /*" & os.the_Comment & "*/ (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid ,")
        s.putBuf(" aLockMode integer ")
        s.putBuf(") returns void as  $$")
        s.putBuf(" declare ")
        s.putBuf(" aParentID uuid;")
        s.putBuf(" aUserID uuid;")
        s.putBuf(" atmpID uuid;")
        s.putBuf(" aaccess integer;")
        s.putBuf(" aIsLocked integer;")
        s.putBuf(" aParentTable varchar(255); ")
        s.putBuf(" existsCnt integer; ")
        s.putBuf(" begin  ")
        s.putBuf(" select count(*) into existsCnt from the_session where the_sessionid=acursession and closed=0;")
        s.putBuf(" -- checking the_session  --")
        s.putBuf("if existsCnt=0")
        s.putBuf("  then")
        s.putBuf("     perform  raise_application_error(-20000,'Сессия уже завершена.');")
        s.putBuf("    return;")
        s.putBuf("  end if;")

        s.putBuf(" select usersid into auserid from  the_session where the_sessionid=acursession;")
        s.putBuf(" aISLocked:= " & VF(os.Name) & "_ISLOCKED (aCURSESSION,aROWID );")
        s.putBuf(" if aIsLocked >=3  ")
        s.putBuf("  then")
        s.putBuf("     perform  raise_application_error(-20000,'Строка заблокирована другим пользователем');")
        s.putBuf("    return;")
        s.putBuf("  end if;")

        s.putBuf(" if aIsLocked =0  ")
        s.putBuf(" then")
        s.putBuf("  aisLocked:= " & VF(os.Name) & "_HCL (acursession,aRowID);")
        s.putBuf("  if aIsLocked >=3  ")
        s.putBuf("  then")
        s.putBuf("      perform  raise_application_error(-20000,'У данной строки имеются дочерние строки, которые заблокированы другим пользователем');")
        s.putBuf("     return;")
        s.putBuf("   end if;")
        s.putBuf(" end if;")

        's.putBuf " select  SecurityStyleID into atmpID from " & VF(os.Name) & " where " & VF(os.Name) & "id=aROWID;"
        's.putBuf " CheckVerbRight (acursession,atmpID,'LOCKROW',aaccess); "
        's.putBuf " if aaccess=0 "
        's.putBuf " then"
        's.putBuf "     perform  raise_application_error(-20000,'Нет прав на блокировку строк. Раздел=" & VF(os.Name) & "');"
        's.putBuf "    return;"
        's.putBuf "  end if;"

        s.putBuf("   if  aLockMode =2  ")
        s.putBuf("   then   ")
        s.putBuf("    update " & VF(os.Name) & " set LockUserID =auserID ,LockSessionID =null where " & VF(os.Name) & "id=aRowID;")
        s.putBuf("     return;")
        s.putBuf("   end if;")

        s.putBuf("   if  aLockMode =1  ")
        s.putBuf("   then   ")
        s.putBuf("    update " & VF(os.Name) & " set LockUserID =null,LockSessionID =aCURSESSION  where " & VF(os.Name) & "id=aRowID;")
        s.putBuf("     return;")
        s.putBuf("   end if;")

        s.putBuf(" end ; $$ language 'plpgsql';")
        s.putBuf("GO")


        o.ModuleName = "--functions.Type.Body"
        o.Block = "--" & ot.Name
        o.OutNL(s.getBuf)



        '--------------------------- HCL - Has Children Locked

        s = Nothing
        s = New Writer
        s.putBuf(" create or replace function  " & VF(os.Name) & "_HCL /*" & os.the_Comment & "*/ (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid ")
        s.putBuf(") returns integer as $$")
        s.putBuf(" declare ")
        s.putBuf(" aIsLocked integer;")
        '---- проверяем, что нет заблокированных записей в  дочерних разделах
        s.putBuf("achildlistid uuid;")
        s.putBuf(" aUserID uuid;")
        s.putBuf(" aLockUserID uuid;")
        s.putBuf(" aID uuid;")
        s.putBuf(" aCurs refcursor;")
        s.putBuf(" aLockSessionID uuid;")
        s.putBuf(" begin  ")
        s.putBuf(" select usersid into auserID from the_session where the_sessionid=acursession;")

        If os.PART.Count > 0 Then
            s.putBuf("-- verify child locks")
        End If

        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            s.putBuf("open aCurs for select " & VF(chos.Name) & "." & VF(chos.Name) & "id ID from " & VF(chos.Name) & " where  " & VF(chos.Name) & ".ParentStructRowID = aRowid;")

            s.putBuf("loop")
            s.putBuf("FETCH aCurs INTO aID;")
            s.putBuf("If Not FOUND Then")
            s.putBuf("    EXIT;  -- exit loop")
            s.putBuf(" END IF;")

            ' если в дочернем разделе есть заблокированная строка
            s.putBuf(" select  LockUserID, LockSessionID into aLockUserID,aLockSessionID from " & VF(chos.Name) & " where " & VF(chos.Name) & "id=row_" & VF(chos.Name) & ".id;")
            s.putBuf(" /* verify this row */")
            s.putBuf(" if not aLockUserID is null  ")
            s.putBuf(" then   ")
            s.putBuf("   if  aLockUserID <> auserID  ")
            s.putBuf("   then   ")
            s.putBuf("     aisLocked := 4; /* CheckOut by another user */")
            s.putBuf("     close aCurs;")
            s.putBuf("     return aislocked;")
            s.putBuf("   end if;  ")
            s.putBuf(" end if;  ")
            s.putBuf(" if not aLockSessionID is null  ")
            s.putBuf(" then   ")
            s.putBuf("   if  aLockSessionID <> aCURSESSION  ")
            s.putBuf("   then   ")
            s.putBuf("     aisLocked := 3; /* Lockes by another user */")
            s.putBuf("     close aCurs;")
            s.putBuf("     return  aislocked;")
            s.putBuf("   end if; ")
            s.putBuf(" end if;  ")

            ' или еще глубже

            s.putBuf(" aisLocked:= " & VF(chos.Name) & "_HCL (acursession,row_" & VF(chos.Name) & ".id);")
            s.putBuf(" if aisLocked >2 then")
            s.putBuf("   close aCurs;")
            s.putBuf("   return  aislocked;")
            s.putBuf(" end if;")

            s.putBuf("end loop;")
            s.putBuf("close aCurs;")

        Next
        s.putBuf("aIsLocked :=0;")
        s.putBuf("   return  aislocked;")
        s.putBuf("end;$$ language 'plpgsql';")
        s.putBuf("GO")


        o.ModuleName = "--functions.Type.Body"
        o.Block = "--" & ot.Name
        o.OutNL(s.getBuf)



        '--------------------------- Разблокируем запись
        s = Nothing
        s = New Writer
        s.putBuf(" create or replace function  " & VF(os.Name) & "_UNLOCK /*" & os.the_Comment & "*/ (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid ")
        s.putBuf(") returns void as $$ ")
        s.putBuf(" declare")
        s.putBuf(" aParentID uuid;")
        s.putBuf(" aUserID uuid;")
        s.putBuf(" aIsLocked integer;")
        s.putBuf(" aParentTable varchar(255); ")
        s.putBuf(" existsCnt integer;")
        s.putBuf(" begin  ")
        s.putBuf(" -- checking the_session  --")
        s.putBuf("select count(*) into existsCnt from the_session where the_sessionid=acursession and closed=0 ;")
        s.putBuf("if  existsCnt=0")
        s.putBuf("  then")
        s.putBuf("     perform  raise_application_error(-20000,'Сессия уже завершена.');")
        s.putBuf("    return;")
        s.putBuf("  end if;")

        s.putBuf(" select usersid into auserID from the_session where the_sessionid=acursession;")
        s.putBuf(" aISLocked:= " & VF(os.Name) & "_ISLOCKED( aCURSESSION,aROWID);")
        s.putBuf(" if aIsLocked >=3  ")
        s.putBuf("  then")
        s.putBuf("     perform  raise_application_error(-20000,'Строка заблоирована другим пользователем');")
        s.putBuf("    return;")
        s.putBuf("  end if;")

        s.putBuf("   if  aIsLocked =2  ")
        s.putBuf("   then   ")
        s.putBuf("    update " & VF(os.Name) & " set LockUserID =null  where " & VF(os.Name) & "id=aRowID;")
        s.putBuf("     return;")
        s.putBuf("   end if;")

        s.putBuf("   if  aIsLocked =1  ")
        s.putBuf("   then   ")
        s.putBuf("    update " & VF(os.Name) & " set LockSessionID =null  where " & VF(os.Name) & "id=aRowID;")
        s.putBuf("     return;")
        s.putBuf("   end if;")

        s.putBuf(" end; $$ language 'plpgsql';")
        s.putBuf("GO")

        o.ModuleName = "--functions.Type.Body"
        o.Block = "--" & ot.Name
        o.OutNL(s.getBuf)




        '--------------------------- Наследуем установки Security
        s = Nothing
        s = New Writer

        s.putBuf(" create or replace function  " & VF(os.Name) & "_SINIT /*" & os.the_Comment & "*/ (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid ,")
        s.putBuf(" aSecurityStyleID uuid")
        s.putBuf(") returns void as $$")
        s.putBuf(" declare ")
        s.putBuf(" aParentID uuid;")
        s.putBuf(" aParentTable varchar(255); ")
        s.putBuf(" aStr varchar(4000);")
        s.putBuf(" aStyleID uuid;")


        s.putBuf(" atmpID uuid;")
        s.putBuf(" aaccess integer; " & vbCrLf & "begin")

        's.putBuf " select  SecurityStyleID into atmpID from " & VF(os.Name) & " where " & VF(os.Name) & "id=aROWID;"
        's.putBuf "  CheckVerbRight (acursession,atmpID,'SECURE',aaccess); "
        's.putBuf " if aaccess=0 "
        's.putBuf "  then"
        's.putBuf "     perform  raise_application_error(-20000,'Нет прав на управление защитой. Раздел =" & VF(os.Name) & "');"
        's.putBuf "    return;"
        's.putBuf "  end if;"

        s.putBuf("if aSecurityStyleID is null then")

        s.putBuf(" aParentTable:=" & VF(os.Name) & "_parent_T( aCURSESSION,aROWID);")
        s.putBuf(" aParentID:= " & VF(os.Name) & "_parent_ID( aCURSESSION,aROWID);")
        s.putBuf("  astr:= 'select SecurityStyleID  from ' || aParentTable || ' where ' ||aParentTable || 'id=$1' ;")
        s.putBuf("  execute  astr into aStyleID using aParentid;")
        s.putBuf(" update " & VF(os.Name) & " set securitystyleid =aStyleID where " & VF(os.Name) & "id = aRowID;")
        s.putBuf("else ")
        s.putBuf(" update " & VF(os.Name) & " set securitystyleid =aSecurityStyleID where " & VF(os.Name) & "id = aRowID;")
        s.putBuf("end if; ")
        s.putBuf("end ; $$ language 'plpgsql';")
        s.putBuf("GO")

        o.ModuleName = "--functions.Type.Body"
        o.Block = "--" & ot.Name
        o.OutNL(s.getBuf)


        '--------------------------- распространение прав на дочерние объекты
        s = Nothing
        s = New Writer

        s.putBuf(" create or replace function  " & VF(os.Name) & "_propagate /*" & os.the_Comment & "*/ (")
        s.putBuf(" aCURSESSION uuid,")
        s.putBuf(" aRowID uuid")
        s.putBuf(") returns void as $$")
        s.putBuf(" declare ")
        s.putBuf("achildlistid uuid;")
        s.putBuf("aSSID uuid;")
        s.putBuf("aID uuid;")
        s.putBuf("aCurs refcursor;")
        s.putBuf("begin")
        s.putBuf("select securityStyleid into aSSID from " & VF(os.Name) & " where " & VF(os.Name) & "id=aRowid;")

        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            s.putBuf("open aCurs for select " & VF(chos.Name) & "." & VF(chos.Name) & "id ID from " & VF(chos.Name) & " where  " & VF(chos.Name) & ".ParentStructRowID = aRowid;")

            s.putBuf("loop")

            s.putBuf("FETCH aCurs INTO aID;")
            s.putBuf("If Not FOUND Then")
            s.putBuf("    EXIT;  -- exit loop")
            s.putBuf(" END IF;")
            s.putBuf(" PERFORM  " & VF(chos.Name) & "_SINIT( acursession,aid,assid);")
            s.putBuf(" PERFORM  " & VF(chos.Name) & "_propagate( acursession,aid);")
            s.putBuf("END LOOP;")


            s.putBuf("close aCurs;")


        Next
        s.putBuf("end; $$ language 'plpgsql';")
        s.putBuf("GO")

        o.ModuleName = "--functions.Type.Body"
        o.Block = "--" & ot.Name
        o.OutNL(s.getBuf)

        s = Nothing

        Exit Sub
bye:

        'Resume
        s = Nothing
    End Sub


    ' make
    Private Function ReferenceCheck(ByRef os As MTZMetaModel.MTZMetaModel.PART, ByRef f As MTZMetaModel.MTZMetaModel.FIELD) As String
        System.Diagnostics.Debug.Print("POSTGRESGEN.ReferenceCheck:start " & os.Caption & " Filed:" & f.Caption)
        On Error GoTo bye
        Dim s As Writer
        s = New Writer


        'не ссылка
        'объект
        'строка

        'RAISERROR   ('The current database ID is:%d, the database name is: %s.',    16, 1, aDBID, aDBNAME)


        If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Skalyrnoe_pole_OPN_ne_ssilkaCLS Then
            s.putBuf("")
        End If

        If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
            s.putBuf("if(not exists( select  1 from instance where instanceid=a" & VF(f.Name) & " )) ")
            s.putBuf("  then")
            s.putBuf("     perform  raise_application_error(-20000,'Не обнаружен объект, на который установлена ссылка. Раздел=" & VF(os.Name) & " field=" & VF(f.Name) & "');")
            s.putBuf("    if aatrancount>0 rollback tran")
            s.putBuf("    return")
            s.putBuf("  end")
        End If


        If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
            s.putBuf("if(not a" & VF(f.Name) & " is null ) ")

            s.putBuf("if(not exists( select  1 from " & VF(CType(f.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name) & " where " & VF(CType(f.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name) & "id=a" & VF(f.Name) & " )) ")
            s.putBuf("  then")

            s.putBuf("     perform  raise_application_error(-20000,'Отсутствует строка в таблице (" & VF(CType(f.RefToPart, MTZMetaModel.MTZMetaModel.PART).Name) & "), на которую установлена ссылка.  Раздел=" & VF(os.Name) & " поле=" & VF(f.Name) & "');")
            s.putBuf("    if aatrancount>0 rollback tran")
            s.putBuf("    return")
            s.putBuf("  end")
        End If

        ReferenceCheck = s.getBuf
        System.Diagnostics.Debug.Print("POSTGRESGEN.ReferenceCheck:done " & os.Caption & " Filed:" & f.Caption)
        s = Nothing
        Exit Function
bye:

        s = Nothing
    End Function
End Class