Option Strict Off
Option Explicit On
Friend Class MakeType
	
    Dim m As MTZMetaModel.MTZMetaModel.Application
    Dim o As LATIRGenerator.Response
    Dim tid As String
    Dim parent As Generator

    Public Sub Init(ByRef ap As Generator, ByRef am As MTZMetaModel.MTZMetaModel.Application, ByRef ao As LatirGenerator.Response, ByVal atid As String)
        parent = ap
        m = am
        o = ao
        tid = atid
    End Sub

    Public Sub Run(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        CreateProcPackage(ot)
        CreateTypeProcsHdr(ot)
        CreateTypeProcs(ot)

        Dim j As Integer
        Dim os As MTZMetaModel.MTZMetaModel.PART
        Dim mp As MakePart

        For j = 1 To ot.PART.Count
            os = ot.PART.Item(j)
            mp = New MakePart
            mp.Init(ot, parent, m, o, tid)
            mp.Run(os)
        Next




        CloseProcPackage(ot)
    End Sub

    Private Sub CreateProcPackage(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        o.ModuleName = "--functions.Type.Header"
        o.Block = "--" & ot.Name
        'o.OutNL " create or replace package " & ot.Name & " as"

        o.ModuleName = "--functions.Type.Body"
        o.Block = "--" & ot.Name
        'o.OutNL " create or replace package body " & ot.Name & " as"
    End Sub

    Private Sub CloseProcPackage(ByRef ot As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        o.ModuleName = "--functions.Type.Header"
        o.Block = "--" & ot.Name
        'o.OutNL "end " & ot.Name & ";"
        o.OutNL(";")

        o.ModuleName = "--functions.Type.Body"
        o.Block = "--" & ot.Name
        'o.OutNL "end " & ot.Name & ";"
        o.OutNL(";")
    End Sub

    Private Sub CreateTypeProcs(ByRef obt As MTZMetaModel.MTZMetaModel.OBJECTTYPE)



        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim s As Writer
        s = New Writer
        System.Windows.Forms.Application.DoEvents()


        s.putBuf(" create or replace function  " & obt.Name & "_DELETE(aCURSESSION uuid, ainstanceid uuid) returns void as $$  ")
        Dim tos As Short
        s.putBuf("declare")
        s.putBuf("aObjType  varchar(255);")
        s.putBuf("aCurs refcursor;")
        s.putBuf("aID uuid;")
        s.putBuf("begin")
        s.putBuf("select  objtype into aObjType from instance where instanceid=ainstanceid;")
        s.putBuf("if  aObjType ='" & obt.Name & "'")
        s.putBuf("then")
        If obt.PART.Count > 0 Then
            For tos = 1 To obt.PART.Count
                chos = obt.PART.Item(tos)
                s.putBuf("Open aCurs  for select " & VF(chos.Name) & "." & VF(chos.Name) & "id ID from " & VF(chos.Name) & " where  " & VF(chos.Name) & ".InstanceID = ainstanceid;")
                s.putBuf("loop")

                s.putBuf("FETCH aCurs  INTO aID;")
                s.putBuf("If Not FOUND Then")
                s.putBuf("    EXIT;  -- exit loop")
                s.putBuf(" END IF;")
                s.putBuf(" PERFORM " & VF(chos.Name) & "_DELETE (acursession,aID,aInstanceID);")
                s.putBuf("END LOOP;")


                s.putBuf("close aCurs;")

            Next
        End If
        s.putBuf("return;")

        s.putBuf("end if;")
        s.putBuf("end; $$ language 'plpgsql'; ")
        s.putBuf("GO")


        ' register root structure of object as child of instance
        s.putBuf(" create or replace function  " & obt.Name & "_HCL(aCURSESSION uuid, aRowID uuid) returns integer as $$ ")
        s.putBuf("declare")
        s.putBuf("aObjType  varchar(255);")
        s.putBuf(" aIsLocked integer;")
        s.putBuf("atmpStr  varchar(255);")

        s.putBuf(" aUserID uuid;")
        s.putBuf(" aLockUserID uuid;")
        s.putBuf(" aLockSessionID uuid;")
        s.putBuf("aCurs refcursor;")
        s.putBuf("aID uuid;")
        s.putBuf(" begin")
        s.putBuf("select  objtype into aObjtype from instance where instanceid=aRowid;")
        s.putBuf("if aobjtype = '" & obt.Name & "'")
        s.putBuf(" then")

        Dim i As Integer
        If obt.PART.Count = 0 Then
            s.putBuf(" aIsLocked :=0;")
        Else
            '---- проверяем, что нет заблокированных записей в  дочерних разделах

            s.putBuf(" select usersid into auserID from  the_session where the_sessionid=acursession;")
            For i = 1 To obt.PART.Count
                chos = obt.PART.Item(i)

                s.putBuf("Open aCurs  for select " & VF(chos.Name) & "." & VF(chos.Name) & "id ID from " & VF(chos.Name) & " where  " & VF(chos.Name) & ".InstanceID = ainstanceid;")
                s.putBuf("loop")

                s.putBuf("FETCH aCurs  INTO aID;")
                s.putBuf("If Not FOUND Then")
                s.putBuf("    EXIT;  -- exit loop")
                s.putBuf(" END IF;")
                ' если в дочернем разделе есть заблокированная строка
                s.putBuf(" select LockUserID,LockSessionID into aLockUserID,aLockSessionID from " & VF(chos.Name) & " where " & VF(chos.Name) & "id=aid;")
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
                s.putBuf("     aisLocked:= 3; /* Lockes by another user */")
                s.putBuf("     close aCurs;")
                s.putBuf("     return aislocked;")
                s.putBuf("   end if; ")
                s.putBuf(" end if; ")

                ' или еще глубже
                s.putBuf(" aisLocked:= " & VF(chos.Name) & "_HCL (acursession,aid);")
                s.putBuf(" if aisLocked >2 then")
                s.putBuf("   close aCurs;")
                s.putBuf("     return aislocked;")
                s.putBuf(" end if;")

                s.putBuf("END LOOP;")


                s.putBuf("close aCurs;")


            Next
            s.putBuf(" end if;")
            s.putBuf("aIsLocked:=0;")
            s.putBuf("     return aislocked;")
        End If
        s.putBuf("end; $$ language 'plpgsql'; ")
        s.putBuf("GO")


        ' register root structure of object as child of instance

        s.putBuf(" create or replace function  " & obt.Name & "_propagate(aCURSESSION uuid, aRowID uuid) returns void as  $$ ")
        s.putBuf("declare")
        s.putBuf("aObjType  varchar(255);")
        s.putBuf("atmpStr  varchar(255);")
        s.putBuf("achildlistid uuid;")
        s.putBuf("assid uuid;")
        s.putBuf("aCurs refcursor;")
        s.putBuf("aID uuid;")
        s.putBuf("begin")
        s.putBuf("select  objtype into aObjType from instance where instanceid=aRowid;")
        s.putBuf("if aobjtype = '" & obt.Name & "'")
        s.putBuf(" then")

        If obt.PART.Count = 0 Then
            s.putBuf("   assid:= 'do nothing';")
            s.putBuf(" end if;")
        Else

            s.putBuf(" select securitystyleid into aSSID from instance where instanceid=aRowID;")
            For i = 1 To obt.PART.Count
                chos = obt.PART.Item(i)
                s.putBuf("open aCurs for  select " & VF(chos.Name) & "." & VF(chos.Name) & "id id from " & VF(chos.Name) & " where  " & VF(chos.Name) & ".InstanceID = arowid;")

                s.putBuf("loop")

                s.putBuf("fetch aCurs into aID;")
                s.putBuf("If Not FOUND Then")
                s.putBuf("    EXIT;  -- exit loop")
                s.putBuf(" END IF;")
                s.putBuf(" PERFORM " & VF(chos.Name) & "_SINIT( acursession,aid,assid);")
                s.putBuf(" PERFORM " & VF(chos.Name) & "_propagate( acursession,aid);")

                s.putBuf("end loop;")
                s.putBuf("close aCurs;")

            Next
            s.putBuf(" end if; ")
        End If

        s.putBuf("end; $$ language 'plpgsql'; ")
        s.putBuf("GO")

        o.ModuleName = "--functions.Type.Body"
        o.Block = "--" & obt.Name
        o.OutNL(s.getBuf)
        s = Nothing
    End Sub

    Private Sub CreateTypeProcsHdr(ByRef obt As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        
        Dim s As Writer
        s = New Writer
        System.Windows.Forms.Application.DoEvents()
        s.putBuf(" create or replace function  " & obt.Name & "_DELETE(aCURSESSION uuid, ainstanceid uuid)returns void as $$ begin end; $$ language 'plpgsql';")
        s.putBuf("GO")

        s.putBuf(" create or replace function  " & obt.Name & "_HCL(aCURSESSION uuid, aRowID uuid)returns integer as $$ begin end; $$ language 'plpgsql';")
        s.putBuf("GO")

        s.putBuf(" create or replace function  " & obt.Name & "_propagate(aCURSESSION uuid, aRowID uuid)returns void as $$ begin end; $$ language 'plpgsql';")
        s.putBuf("GO")

        o.ModuleName = "--functions.Type.Header"
        o.Block = "--" & obt.Name
        o.OutNL(s.getBuf)
        s = Nothing
    End Sub
End Class