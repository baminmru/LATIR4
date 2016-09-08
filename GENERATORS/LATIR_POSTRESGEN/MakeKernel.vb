Option Strict Off
Option Explicit On
Friend Class MakeKernel
	
    Dim m As MTZMetaModel.MTZMetaModel.Application
    'UPGRADE_WARNING: Arrays in structure o may need to be initialized before they can be used. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="814DF224-76BD-4BB4-BFFB-EA359CB9FC48"'
    Dim o As LatirGenerator.Response
    Dim tid As String
    Dim parent As Generator

    Public Sub Init(ByRef ap As Generator, ByRef am As MTZMetaModel.MTZMetaModel.Application, ByRef ao As LatirGenerator.Response, ByVal atid As String)
        parent = ap
        m = am
        o = ao
        tid = atid
    End Sub
	
	Private Sub CreateKernelPackage()
        o.ModuleName = "--functions.Header"
        o.Block = "--body"
        'o.OutNL " create or replace package Kernel as"

        o.ModuleName = "--functions.Body"
        o.Block = "--body"
        'o.OutNL " create or replace package body Kernel as"


    End Sub

    Private Sub CloseKernelPackage()
        o.ModuleName = "--functions.Header"
        o.Block = "--body"
        'o.OutNL " end Kernel;"
        o.OutNL(";")

        o.ModuleName = "--functions.Body"
        o.Block = "--body"
        'o.OutNL " end Kernel;"
        o.OutNL(";")
    End Sub




    Private Sub KernelProcsHeader()

        Dim SQL As Writer
        SQL = New Writer

        System.Windows.Forms.Application.DoEvents()
        On Error GoTo bye


        SQL.putBuf(" create or replace function  INSTANCE_OWNER   (")
        SQL.putBuf("    aCURSESSION uuid ,ainstanceid uuid,")
        SQL.putBuf(" aOwnerPartName varchar, aOwnerRowID uuid) returns void as $$ begin end; $$ language 'plpgsql';")
        SQL.putBuf("GO")


        SQL.putBuf(" create or replace function  SYSOPTIONS_SAVE    (")
        SQL.putBuf(" aSysOptionsid uuid,")
        SQL.putBuf(" aName varchar,")
        SQL.putBuf(" aValue varchar ,")
        SQL.putBuf(" aOptionType varchar) returns void as $$ begin end; $$ language 'plpgsql';")
        SQL.putBuf("GO")

        SQL.putBuf(" create or replace function  INSTANCE_SAVE      (")
        SQL.putBuf("aCURSESSION uuid,")
        SQL.putBuf("ainstanceid uuid,")
        SQL.putBuf("aObjType varchar,")
        SQL.putBuf("aName varchar")
        SQL.putBuf(") returns void as $$ begin end; $$ language 'plpgsql';")
        SQL.putBuf("GO")
        SQL.putBuf("create or replace function  INSTANCE_DELETE    (")
        SQL.putBuf("aCURSESSION uuid,")
        SQL.putBuf("ainstanceid uuid")
        SQL.putBuf(")returns void as $$ begin end; $$ language 'plpgsql';")
        SQL.putBuf("GO")
        SQL.putBuf("create or replace function  INSTANCE_HCL   (")
        SQL.putBuf("aCURSESSION uuid,")
        SQL.putBuf("aRowID uuid")
        SQL.putBuf(")returns integer as $$ begin return 0; end; $$ language 'plpgsql';")
        SQL.putBuf("GO")

        SQL.putBuf("create or replace function  INSTANCE_PROPAGATE   (")
        SQL.putBuf("aCURSESSION uuid,")
        SQL.putBuf("aRowID uuid")
        SQL.putBuf(")returns void as $$ begin end; $$ language 'plpgsql';")
        SQL.putBuf("GO")

        SQL.putBuf("create or replace function  INSTANCE_ISLOCKED   (")
        SQL.putBuf(" aCURSESSION uuid,")
        SQL.putBuf(" aRowID uuid ")
        SQL.putBuf(")returns integer as $$ begin return 0; end; $$ language 'plpgsql';")
        SQL.putBuf("GO")

        SQL.putBuf("create or replace function  INSTANCE_SINIT    (")
        SQL.putBuf("aCURSESSION uuid,")
        SQL.putBuf("aRowID uuid ,")
        SQL.putBuf(" aSecurityStyleID uuid")
        SQL.putBuf(")returns void as $$ begin end; $$ language 'plpgsql';")
        SQL.putBuf("GO")


        SQL.putBuf("create or replace function  INSTANCE_LOCK     (")
        SQL.putBuf(" aCURSESSION uuid,")
        SQL.putBuf(" aRowID uuid ,")
        SQL.putBuf(" aLockMode integer")
        SQL.putBuf(") returns void as $$ begin end; $$ language 'plpgsql';")
        SQL.putBuf("GO")
        SQL.putBuf("create or replace function  INSTANCE_UNLOCK (")
        SQL.putBuf(" aCURSESSION uuid,")
        SQL.putBuf(" aRowID uuid")
        SQL.putBuf(")returns void as $$ begin end; $$ language 'plpgsql';")
        SQL.putBuf("GO")


        SQL.putBuf("  create or replace function  INSTANCE_BRIEF    (")
        SQL.putBuf(" aCURSESSION uuid,")
        SQL.putBuf(" ainstanceid uuid")
        SQL.putBuf(") returns varchar as $$ begin end; $$ language 'plpgsql';")
        SQL.putBuf("GO")
        SQL.putBuf("  create or replace function  QR_AND_QR  ( aid1 uuid, aid2")
        SQL.putBuf("    uuid,aidout uuid )returns integer as $$ begin end; $$ language 'plpgsql';")
        SQL.putBuf("GO")

        SQL.putBuf("  create or replace function  QR_OR_QR  ( aid1 uuid, aid2 ")
        SQL.putBuf("    uuid,aidout uuid)returns integer as $$ begin end; $$ language 'plpgsql';")
        SQL.putBuf("GO")

        SQL.putBuf("create or replace function  ROWPARENTS")
        SQL.putBuf("(aQueryID   uuid")
        SQL.putBuf(",aRowID uuid/* Row */")
        SQL.putBuf(",aTable varchar /* Part Table Name */")
        SQL.putBuf(",aCURSESSION uuid/* the_session */")
        SQL.putBuf(")returns void as $$ begin end; $$ language 'plpgsql';")
        SQL.putBuf("GO")

        SQL.putBuf("  create or replace function  INSTANCE_STATUS    (")
        SQL.putBuf("  aCURSESSION uuid,")
        SQL.putBuf("  ainstanceid uuid,")
        SQL.putBuf("  astatusid uuid)returns void as $$ begin end; $$ language 'plpgsql';")
        SQL.putBuf("GO")

        o.ModuleName = "--functions.Header"
        o.Block = "--body"
        o.OutNL(SQL.getBuf)
        SQL = Nothing
        Exit Sub
bye:
        SQL = Nothing
    End Sub

    Private Sub PreInstall()
        Dim SQL As Writer
        SQL = New Writer

        System.Windows.Forms.Application.DoEvents()
        On Error GoTo bye


        SQL.putBuf("  create or replace function  raise_application_error    ( code integer, message varchar(255)) returns void as $$")
        SQL.putBuf("begin")
        SQL.putBuf("RAISE EXCEPTION 'Error-% %',code,message;")
        SQL.putBuf("RETURN;")
        SQL.putBuf("End; $$ language 'plpgsql';")
        SQL.putBuf("GO")

        SQL.putBuf("  CREATE OR REPLACE  FUNCTION NEWID() returns uuid")
        SQL.putBuf("  as $$")
        SQL.putBuf("  begin")
        SQL.putBuf("  return uuid_generate_v1();")
        SQL.putBuf("  end;")
        SQL.putBuf("$$ language 'plpgsql'; ")
        SQL.putBuf("GO")




        o.ModuleName = "--PreInstall"
        o.Block = "--body"
        o.OutNL(SQL.getBuf)

        'UPGRADE_NOTE: Object SQL may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        SQL = Nothing

bye:
    End Sub


    Private Sub KernelProcs()

        Dim SQL As Writer
        SQL = New Writer

        System.Windows.Forms.Application.DoEvents()
        On Error GoTo bye



        SQL.putBuf("create or replace function INSTANCE_OWNER   (")
        SQL.putBuf("    aCURSESSION uuid ,ainstanceid uuid,")
        SQL.putBuf(" aOwnerPartName varchar, aOwnerRowID uuid) returns void as $$")
        SQL.putBuf(" declare ")
        SQL.putBuf(" existsCnt integer;")
        SQL.putBuf("begin")
        SQL.putBuf("select count(*)into existscnt from instance")
        SQL.putBuf("where instanceid=ainstanceid;")
        SQL.putBuf("If existsCnt > 0 Then")
        SQL.putBuf("  if aOwnerPartName is null or aownerRowID is null")
        SQL.putBuf("  then")
        SQL.putBuf("     update instance set OwnerPartName=null, OwnerRowid = null where instanceid=ainstanceid ;")
        SQL.putBuf("  Else")
        SQL.putBuf("     update instance set OwnerPartName=aOwnerPartName, OwnerRowid = aOwnerRowID where instanceid=ainstanceid ;")
        SQL.putBuf("  End if;")
        SQL.putBuf("End if;")
        SQL.putBuf("end; $$ language 'plpgsql';")
        SQL.putBuf("GO")


        SQL.putBuf(" create or replace function  SYSOPTIONS_SAVE    (")
        SQL.putBuf("   aSysOptionsid uuid,")
        SQL.putBuf("aName varchar,")
        SQL.putBuf("aValue varchar ,")
        SQL.putBuf("aOptionType varchar) returns void as $$")
        SQL.putBuf(" declare ")
        SQL.putBuf("existsCnt numeric;")
        SQL.putBuf("begin")
        SQL.putBuf(" select count(*) into existsCnt from sysoptions where sysoptionsid=asysoptionsid;")
        SQL.putBuf(" If existsCnt > 0 Then")
        SQL.putBuf("  update sysoptions set Name=aName, theValue=aValue, OptionType=aOptionType where sysoptionsid=asysoptionsid ;")
        SQL.putBuf(" Else")
        SQL.putBuf("  insert into sysoptions (sysoptionsid, Name, theValue, OptionType)values(asysoptionsid,aName,aValue,aOptionType) ;")
        SQL.putBuf(" End if;")
        SQL.putBuf("end; $$ language 'plpgsql';")
        SQL.putBuf("GO")


        SQL.putBuf(" create or replace function  INSTANCE_SAVE      (")
        SQL.putBuf("aCURSESSION uuid,")
        SQL.putBuf("ainstanceid uuid,")
        SQL.putBuf("aObjType varchar,")
        SQL.putBuf("aName varchar")
        SQL.putBuf(")returns void  as $$")
        SQL.putBuf(" declare ")
        SQL.putBuf(" aSSID uuid ;")
        SQL.putBuf(" atmpID uuid ;")
        SQL.putBuf(" aSysLogID uuid ;")
        SQL.putBuf(" aaccess numeric ;")
        SQL.putBuf(" aSysInstID uuid ;")
        SQL.putBuf(" aStatusID uuid ;")
        SQL.putBuf(" existsCnt numeric;")
        SQL.putBuf(" theObjType varchar(255);")
        SQL.putBuf("begin")
        SQL.putBuf(" select  Instanceid into aSysInstID from instance where objtype='MTZSYSTEM';")
        SQL.putBuf(" select  count(*) into existsCnt  from instance where instanceid=ainstanceid;")
        SQL.putBuf(" If existsCnt > 0 Then")
        '  SQL.putBuf "   select  SecurityStyleID into atmpID from INSTANCE where INSTANCEid=aINSTANCEid ;"
        '  SQL.putBuf "   CheckVerbRight (acursession,atmpID,'EDIT',aaccess  );"
        '  SQL.putBuf "   If aaccess = 0 Then"
        '  SQL.putBuf "      perform  raise_application_error(-20000,'Нет прав на изменение объекта.') ;"
        '  SQL.putBuf "     return ;"
        '  SQL.putBuf "   end if;"
        SQL.putBuf("   aaccess:= instance_ISLOCKED (acursession,ainstanceid  );")
        SQL.putBuf("   If aaccess > 2 Then")
        SQL.putBuf("      perform  raise_application_error(-20000,'Объект заблокирован другим пользователем.') ;")
        SQL.putBuf("     return;")
        SQL.putBuf("   end if;")
        SQL.putBuf("   select objtype into TheObjType from instance  where  instanceid=ainstanceid ;")
        SQL.putBuf("   update instance set name = aname where  instanceid=ainstanceid;")
        SQL.putBuf("   select newid() into aSysLogID  ;")
        SQL.putBuf("   PERFORM SysLog_SAVE (acursession , aSysLogid, aSysInstID,acursession, ")
        SQL.putBuf("    TheOBJTYPE , cast(aInstanceID as varchar),")
        SQL.putBuf("   'EDIT',   aInstanceID );")
        SQL.putBuf(" Else")
        '  SQL.putBuf "    select count(*) into existsCnt from typelist where name = aobjtype;"
        '  SQL.putBuf "    If existsCnt > 0 Then"
        '  SQL.putBuf "      select SecurityStyleid,RegisterProc into aSSID,atmpstr  from typelist where name = aobjtype;"
        '  SQL.putBuf "      CheckVerbRight (acursession,aSSID,'CREATE',aaccess  );"
        '  SQL.putBuf "      If aaccess = 0 Then"
        '  SQL.putBuf "          perform  raise_application_error(-20000,'Нет прав на создание объекта.') ;"
        '  SQL.putBuf "         return;"
        '  SQL.putBuf "      end if;"
        '
        '  SQL.putBuf "    end if;"
        SQL.putBuf("   begin")
        SQL.putBuf("   select objstatusid into astatusid from objstatus join objecttype on")
        SQL.putBuf("         objecttype.objecttypeid=objstatus.parentstructrowid and objecttype.name=aobjtype and isStartup<>0;")
        SQL.putBuf("   exception when others then")
        SQL.putBuf("      astatusid:=null ;")
        SQL.putBuf("    end;")
        SQL.putBuf("   If astatusid Is Null Then")
        SQL.putBuf("     insert into instance(instanceid,name,objtype,SecurityStyleID) values(ainstanceid,aname,aobjtype,aSSID)         ;")
        SQL.putBuf("   Else")
        SQL.putBuf("     insert into instance(instanceid,name,objtype,SecurityStyleID,STATUS) values(ainstanceid,aname,aobjtype,aSSID,aSTATUSID) ;")
        SQL.putBuf("   end if;")
        SQL.putBuf("   select newid() into aSysLogid  ;")
        SQL.putBuf("   ")
        SQL.putBuf("   PERFORM SysLog_SAVE (")
        SQL.putBuf("     acursession ,")
        SQL.putBuf("      aSysLogid,aSysInstID, acursession, aOBJTYPE , cast(aInstanceID as varchar),")
        SQL.putBuf("     'CREATE',   aInstanceID);")
        SQL.putBuf(" End  if;")
        SQL.putBuf("End; $$ language 'plpgsql';")
        SQL.putBuf("GO")



        SQL.putBuf("create or replace function  INSTANCE_DELETE    (")
        SQL.putBuf("aCURSESSION uuid,")
        SQL.putBuf("ainstanceid uuid")
        SQL.putBuf(") returns void as $$")
        SQL.putBuf(" declare ")
        SQL.putBuf(" atmpStr varchar(255) ;")
        SQL.putBuf("  aStr varchar(4000) ;")
        SQL.putBuf("  aObjType varchar(255) ;")
        SQL.putBuf(" aSysInstID uuid ;")
        SQL.putBuf("    atmpID uuid ;")
        SQL.putBuf("   aaccess integer;")
        SQL.putBuf("   aOwnerPartName varchar(255) ;")
        SQL.putBuf("   aOwnerRowID uuid ;")
        SQL.putBuf("   aSysLogid uuid ;")
        SQL.putBuf("    existsCnt integer;")
        SQL.putBuf("begin")
        SQL.putBuf("  select Instanceid into aSysInstID from instance where objtype='MTZSYSTEM' ;")
        SQL.putBuf("  select count(*) into existsCnt from instance where instanceid=ainstanceid;")
        SQL.putBuf("  If existsCnt > 0 Then")
        SQL.putBuf("   select  SecurityStyleID, OwnerPartName,OWnerRowID")
        SQL.putBuf("        Into atmpid, aOwnerpartname, aownerrowid")
        SQL.putBuf("        from INSTANCE where INSTANCEid=aINSTANCEid ;")
        '  SQL.putBuf "   CheckVerbRight (acursession,atmpID,'DELETE',aaccess);"
        '  SQL.putBuf "   If aaccess = 0 Then"
        '  SQL.putBuf "        perform  raise_application_error(-20000,'Нет прав на удаление.');"
        '  SQL.putBuf "       Return ;"
        '  SQL.putBuf "   End if;"
        SQL.putBuf("   If aOwnerpartname Is Null Or aownerrowid Is Null Then")
        SQL.putBuf("        select  objtype into aobjtype from instance where instanceid=ainstanceid;")
        SQL.putBuf("        select 'select ' || DeleteProc ||'($1,$2);' into atmpstr from typelist where name = aobjtype;")
        SQL.putBuf("        If Not atmpstr Is Null Then")
        SQL.putBuf("            EXECUTE  atmpstr  using acursession,ainstanceid;")
        SQL.putBuf("        end if;")
        SQL.putBuf("        delete from instance where instanceid=ainstanceid ;")
        SQL.putBuf("        select newid() into aSysLogID;")
        SQL.putBuf("        PERFORM SysLog_SAVE( acursession , aSysLogid, aSysInstID, acursession,  aobjtype ,  cast(aInstanceID as varchar),")
        SQL.putBuf("        'DELETE',  aInstanceID);")
        SQL.putBuf("        Else")
        SQL.putBuf("        -- Owner exists")
        SQL.putBuf("         astr :='select '|| aownerpartname || 'id  from ' || aownerpartname || ' where ' || aownerpartname ||'id=$1';")
        SQL.putBuf("         execute   astr into atmpid  using aownerrowid;")
        SQL.putBuf("         If atmpid = aownerrowid Then")
        SQL.putBuf("            perform  raise_application_error(-20000,'Этот документ принадлежит другому документу и не может быть удален отдельно.');")
        SQL.putBuf("           return;")
        SQL.putBuf("         End if;")
        SQL.putBuf("         select  objtype into aObjType from instance where instanceid=ainstanceid;")
        SQL.putBuf("         select 'select ' || DeleteProc ||'($1,$2); ' into atmpstr from typelist where name = aobjtype ;")
        SQL.putBuf("         If Not atmpstr Is Null Then")
        SQL.putBuf("           execute  atmpstr using acursession, ainstanceid;")
        SQL.putBuf("           delete from instance where instanceid=ainstanceid ;")
        SQL.putBuf("         select newid() into aSysLogID;")

        SQL.putBuf("         PERFORM SysLog_SAVE (acursession ,")
        SQL.putBuf("                      aSysLogid, aSysInstID, acursession,  aobjtype , cast(aInstanceID as varchar),")
        SQL.putBuf("                      'DELETE',   aInstanceID );")
        SQL.putBuf("        End if;")
        SQL.putBuf("     End if;")
        SQL.putBuf("End if;")
        SQL.putBuf("end; $$ language 'plpgsql';")
        SQL.putBuf("GO")



        SQL.putBuf("create or replace function  INSTANCE_HCL   (")
        SQL.putBuf("aCURSESSION uuid,")
        SQL.putBuf("aRowID uuid")
        SQL.putBuf(")returns integer  as $$")
        SQL.putBuf(" declare ")
        SQL.putBuf("aIsLocked  integer;")
        SQL.putBuf("atmpStr varchar(255) ;")
        SQL.putBuf("aObjType varchar(255) ;")
        SQL.putBuf("existscnt integer;")
        SQL.putBuf("begin")
        SQL.putBuf("aIsLocked:=0;")
        SQL.putBuf(" /* select count(*) into existsCnt from instance where instanceid=arowid ;")
        SQL.putBuf("if existscnt=1")
        SQL.putBuf("    then")
        SQL.putBuf("      select objtype into aobjtype  from instance where instanceid=arowid ;")
        SQL.putBuf("      select 'begin ' || aobjtype || '.' || HCLProc || '(acursession, arowid,aIsLocked); end;' into atmpstr from typelist where name = aobjtype;")
        SQL.putBuf("      If Not atmpstr Is Null Then")
        SQL.putBuf("        execute  atmpstr;")
        SQL.putBuf("      End if;")
        SQL.putBuf("end if; */")
        SQL.putBuf(" return aIsLocked;")
        SQL.putBuf("End; $$ language 'plpgsql';")
        SQL.putBuf("GO")


        SQL.putBuf("create or replace function  INSTANCE_PROPAGATE   (")
        SQL.putBuf("aCURSESSION uuid,")
        SQL.putBuf("aRowID uuid")
        SQL.putBuf(")returns void  as $$")
        SQL.putBuf(" declare ")
        SQL.putBuf("atmpStr varchar(255) ;")
        SQL.putBuf("aObjType varchar(255);")
        SQL.putBuf("existsCnt integer;")
        SQL.putBuf("begin")

        SQL.putBuf("select count(*) into existsCnt from instance where instanceid=arowid ;")
        SQL.putBuf("if existsCnt=1")
        SQL.putBuf("    then")
        SQL.putBuf("      select  objtype into aobjtype from instance where instanceid=arowid ;")
        SQL.putBuf("      select  'begin ' || aobjtype || '.' || propagateProc || '(acursession, arowid); end;' into atmpstr from typelist where name = aobjtype;")
        SQL.putBuf("      If Not atmpstr Is Null Then")
        SQL.putBuf("        execute  atmpstr;")
        SQL.putBuf("    End if;")
        SQL.putBuf("End if;")
        SQL.putBuf("End; $$ language 'plpgsql';")
        SQL.putBuf("GO")




        SQL.putBuf("create or replace function  INSTANCE_ISLOCKED   (")
        SQL.putBuf(" aCURSESSION uuid,")
        SQL.putBuf(" aRowID uuid")
        SQL.putBuf(")returns integer  as $$")
        SQL.putBuf(" declare ")
        SQL.putBuf(" aUserID uuid ;")
        SQL.putBuf(" aLockUserID uuid ;")
        SQL.putBuf(" aLockSessionID uuid ;")
        SQL.putBuf(" existsCnt integer;")
        SQL.putBuf(" aIsLocked  integer;")
        SQL.putBuf(" begin")

        SQL.putBuf(" aisLocked := 0 ;")
        SQL.putBuf(" -- checking the_session  --")
        SQL.putBuf(" select count(*) into existsCnt from  the_session where the_sessionid=acursession and closed=0;")
        SQL.putBuf(" If existsCnt = 0 Then")
        SQL.putBuf("    perform  raise_application_error(-20000,'Сессия уже завершена');")
        SQL.putBuf("   Return 0;")
        SQL.putBuf(" End if;")
        SQL.putBuf(" select  usersid into auserID from  the_session where the_sessionid=acursession ;")
        SQL.putBuf(" select LockUserID, LockSessionID")
        SQL.putBuf(" Into aLockUserID, aLockSessionID")
        SQL.putBuf(" from INSTANCE where INSTANCEid=aRowID ;")
        SQL.putBuf(" If Not aLockUserID Is Null Then")
        SQL.putBuf("   If aLockUserID <> auserID Then")
        SQL.putBuf("     aisLocked := 4; /* CheckOut by another user */")
        SQL.putBuf("     Return aislocked;")
        SQL.putBuf("   Else")
        SQL.putBuf("     aisLocked := 2; /* CheckOut by caller */")
        SQL.putBuf("     Return aislocked;")
        SQL.putBuf("   end if;")
        SQL.putBuf(" End if;")
        SQL.putBuf(" If Not aLockSessionID Is Null Then")
        SQL.putBuf("   If aLockSessionID <> aCURSESSION Then")

        SQL.putBuf("     aisLocked := 3 ;/* Lockes by another user */")
        SQL.putBuf("     Return aislocked ;")
        SQL.putBuf("   Else")
        SQL.putBuf("     aisLocked := 1; /* Locked by caller */")
        SQL.putBuf("     Return aislocked ;")
        SQL.putBuf("   end if;")
        SQL.putBuf(" End if;")
        SQL.putBuf(" aisLocked := 0 ;")
        SQL.putBuf("     Return aislocked ;")
        SQL.putBuf(" End; $$ language 'plpgsql';")
        SQL.putBuf("GO")



        SQL.putBuf("create or replace function  INSTANCE_SINIT    (")
        SQL.putBuf("aCURSESSION uuid,")
        SQL.putBuf("aRowID uuid ,")
        SQL.putBuf(" aSecurityStyleID uuid")
        SQL.putBuf(")returns void as $$")
        SQL.putBuf(" declare ")
        SQL.putBuf("aParentTable varchar(255) ;")
        SQL.putBuf(" aStyleID uuid ;")
        SQL.putBuf(" atmpID uuid ;")
        SQL.putBuf(" aaccess integer ;")
        SQL.putBuf(" begin")
        SQL.putBuf("  select  SecurityStyleID into atmpID from INSTANCE where INSTANCEid=aROWID;")
        '  SQL.putBuf " CheckVerbRight( acursession,atmpID,'SECURE',aaccess);"
        '  SQL.putBuf " if aaccess=0"
        '  SQL.putBuf "  then"
        '  SQL.putBuf "     perform  raise_application_error(-20000,'Нет прав на управление защитой.');"
        '  SQL.putBuf "    return ;"
        '  SQL.putBuf "  end if;"
        SQL.putBuf("  If aSecurityStyleID Is Null Then")
        SQL.putBuf("    select  objtype into aParentTable from instance where instanceid=aRowID ;")
        SQL.putBuf("    select SecurityStyleID  into aStyleID from typelist where name =aParentTable ;")
        SQL.putBuf("    update Instance set securitystyleid =aStyleID where Instanceid = aRowID;")
        SQL.putBuf("  Else")
        SQL.putBuf("    update Instance set securitystyleid =aSecurityStyleID where Instanceid = aRowID ;")
        SQL.putBuf("  End if;")
        SQL.putBuf("End; $$ language 'plpgsql';")
        SQL.putBuf("GO")

        SQL.putBuf("create or replace function  INSTANCE_LOCK     (")
        SQL.putBuf(" aCURSESSION uuid,")
        SQL.putBuf(" aRowID uuid ,")
        SQL.putBuf(" aLockMode integer")
        SQL.putBuf(")returns void  as $$")
        SQL.putBuf(" declare ")
        SQL.putBuf("aUserID uuid;")
        SQL.putBuf(" atmpID uuid;")
        SQL.putBuf(" aaccess integer ;")
        SQL.putBuf(" aIsLocked integer ;")
        SQL.putBuf(" existsCnt integer;")
        SQL.putBuf("  begin")
        SQL.putBuf(" select count(*) into existsCnt from  the_session where the_sessionid=acursession and closed=0;")
        SQL.putBuf(" -- checking the_session  --")
        SQL.putBuf("If existsCnt = 0 Then")
        SQL.putBuf("     perform  raise_application_error(-20000,'Сессия уже завершена.') ;")
        SQL.putBuf("    Return ;")
        SQL.putBuf("End if;")
        SQL.putBuf(" select  usersid into auserID from  the_session where the_sessionid=acursession;")
        SQL.putBuf(" aaccess:= Instance_ISLOCKED (aCURSESSION,aROWID);")
        SQL.putBuf(" if aIsLocked >=3")
        SQL.putBuf("  then")
        SQL.putBuf("     perform  raise_application_error(-20000,'Объект заблокирован другим пользователем');")
        SQL.putBuf("    Return ;")
        SQL.putBuf("  End if;")
        SQL.putBuf(" if aIsLocked =0")
        SQL.putBuf(" then")
        SQL.putBuf("  aisLocked:= Instance_HCL( acursession,aRowID);")
        SQL.putBuf("  if aIsLocked >=3")
        SQL.putBuf("  then")
        SQL.putBuf("      perform  raise_application_error(-20000,'У данного объекта имеются дочерние строки, которые заблокированы другим пользователем');")
        SQL.putBuf("     Return ;")
        SQL.putBuf("  End if;")
        SQL.putBuf(" End if;")
        SQL.putBuf(" select  SecurityStyleID into atmpid from INSTANCE where INSTANCEid=aROWID ;")
        '  SQL.putBuf " CheckVerbRight (acursession,atmpID,'LOCKINSTANCE',aaccess);"
        '  SQL.putBuf " if aaccess=0"
        '  SQL.putBuf "  then"
        '  SQL.putBuf "     perform  raise_application_error(-20000,'Нет прав на блокировку объекта.');"
        '
        '  SQL.putBuf "    return ;"
        '  SQL.putBuf "  end if;"
        SQL.putBuf("   if  aLockMode =2")
        SQL.putBuf("   then")
        SQL.putBuf("    update INSTANCE  set LockUserID =auserID ,LockSessionID =null where Instanceid=aRowID ;")
        SQL.putBuf("     Return ;")
        SQL.putBuf("   End if ;")
        SQL.putBuf("   if  aLockMode =1")
        SQL.putBuf("   then")
        SQL.putBuf("    update INSTANCE  set LockUserID =null,LockSessionID =aCURSESSION  where Instanceid=aRowID ;")
        SQL.putBuf("     Return ;")
        SQL.putBuf("   End if;")
        SQL.putBuf(" End; $$ language 'plpgsql';")
        SQL.putBuf("GO")


        SQL.putBuf("create or replace function  INSTANCE_UNLOCK (")
        SQL.putBuf(" aCURSESSION uuid,")
        SQL.putBuf(" aRowID uuid")
        SQL.putBuf(") returns void as $$")
        SQL.putBuf(" declare ")
        SQL.putBuf(" aParentID uuid;")
        SQL.putBuf(" aUserID uuid ;")
        SQL.putBuf(" aIsLocked integer ;")
        SQL.putBuf(" aParentTable varchar(255);")
        SQL.putBuf(" existsCnt integer;")
        SQL.putBuf(" begin")
        SQL.putBuf(" -- checking the_session  --")
        SQL.putBuf(" select count(*) into existsCnt from  the_session where the_sessionid=acursession and closed=0;")
        SQL.putBuf("if  existsCnt =0")
        SQL.putBuf("  then")
        SQL.putBuf("     perform  raise_application_error(-20000,'Сессия уже завершена.');")
        SQL.putBuf("    Return ;")
        SQL.putBuf("  End if;")
        SQL.putBuf(" aISLocked:= Instance_ISLOCKED( aCURSESSION,aROWID  );")
        SQL.putBuf(" if aIsLocked >=3")
        SQL.putBuf("  then")
        SQL.putBuf("     perform  raise_application_error(-20000,'Объект заблокирован другим пользователем');")
        SQL.putBuf("    Return ;")
        SQL.putBuf("  End if;")
        SQL.putBuf("   if  aIsLocked =2")
        SQL.putBuf("   then")
        SQL.putBuf("    update INSTANCE set LockUserID =null  where Instanceid=aRowID ;")
        SQL.putBuf("     Return ;")
        SQL.putBuf("   End if;")
        SQL.putBuf("   if  aIsLocked =1")
        SQL.putBuf("   then")
        SQL.putBuf("    update INSTANCE set LockSessionID =null  where Instanceid=aRowID;")
        SQL.putBuf("     Return ;")
        SQL.putBuf("   End if;")
        SQL.putBuf(" End; $$ language 'plpgsql';")
        SQL.putBuf("GO")



        SQL.putBuf("  create or replace function  INSTANCE_BRIEF    (")
        SQL.putBuf(" aCURSESSION uuid,")
        SQL.putBuf(" ainstanceid uuid")
        SQL.putBuf(") returns varchar as $$")
        SQL.putBuf(" declare ")
        SQL.putBuf(" aBRIEF  varchar(255);")
        SQL.putBuf(" atmpStr varchar(255);")
        SQL.putBuf(" aaccess int ;")
        SQL.putBuf(" atmpBrief varchar(4000) ;")
        SQL.putBuf(" atmpID uuid ;")
        SQL.putBuf(" existsCnt integer;")
        SQL.putBuf(" begin")
        SQL.putBuf(" -- checking the_session  --")
        SQL.putBuf(" select count(*) into existsCnt  from  the_session where the_sessionid=acursession and closed=0;")
        SQL.putBuf("If existsCnt = 0 Then")
        SQL.putBuf("     perform  raise_application_error(-20000,'Сессия уже завершена.') ;")
        SQL.putBuf("    Return '';")
        SQL.putBuf("  End if;")
        SQL.putBuf("If ainstanceid Is Null Then")
        SQL.putBuf("     aBRIEF:='';")
        SQL.putBuf("    return aBRIEF;")
        SQL.putBuf("end if;")



        SQL.putBuf(" -- Brief body --")
        SQL.putBuf("  select count(*) into existsCnt  from instance where instanceID=ainstanceID;")
        SQL.putBuf("If existsCnt = 1 Then")
        '  SQL.putBuf " --  verify access  --"
        '  SQL.putBuf " select  SecurityStyleID into atmpID from instance where instanceid=ainstanceID ;"
        '  SQL.putBuf " CheckVerbRight( acursession,atmpID,"
        '  SQL.putBuf "     'BRIEF',aaccess);"
        '  SQL.putBuf " If aaccess = 0 Then"
        '  SQL.putBuf "     perform  raise_application_error(-20000,'Нет прав на получение краткого наименования. Раздел=instance') ;"
        '  SQL.putBuf "    Return ;"
        '  SQL.putBuf " End  if;"

        SQL.putBuf("  select  instance_brief_F(instanceid) into aBrief from instance where instanceid=ainstanceid;")

        SQL.putBuf(" Else")
        SQL.putBuf("   aBRIEF:= 'неверный идентификатор';")
        SQL.putBuf("End if;")
        SQL.putBuf("    aBRIEF:=substr(aBRIEF,1,255);")
        SQL.putBuf("    return aBRIEF;")
        SQL.putBuf("End; $$ language 'plpgsql';")
        SQL.putBuf("GO")



        SQL.putBuf("  create or replace function  QR_AND_QR  ( aid1 uuid, aid2")
        SQL.putBuf("    uuid,aidout uuid )returns integer ")
        SQL.putBuf("as $$")
        SQL.putBuf("declare")
        SQL.putBuf("acnt integer;")
        SQL.putBuf("begin")
        SQL.putBuf("delete from QueryResult where QueryResultid=aidout ;")
        SQL.putBuf("insert into QueryResult(QueryResultid,result)")
        SQL.putBuf("select distinct aidout, a.result")
        SQL.putBuf("from QueryResult a")
        SQL.putBuf("join QueryResult b on b.QueryResultid=aid2 and a.result=b.result")
        SQL.putBuf("where a.QueryResultid=aid1 ;")
        SQL.putBuf("select count(*) into acnt from QueryResult where QueryResultid=aidout;")
        SQL.putBuf("return acnt;")
        SQL.putBuf("end; $$ language 'plpgsql';")
        SQL.putBuf("GO")


        SQL.putBuf("  create or replace function  QR_OR_QR  ( aid1 uuid, aid2 ")
        SQL.putBuf("    uuid,aidout uuid) returns integer ")
        SQL.putBuf("as $$")
        SQL.putBuf("declare")
        SQL.putBuf("acnt integer;")
        SQL.putBuf("begin")
        SQL.putBuf("delete from QueryResult where QueryResultid=aidout ;")
        SQL.putBuf("insert into QueryResult(QueryResultid,result)")
        SQL.putBuf("select distinct aidout, result from QueryResult where QueryResultid in (aid1,aid2);")
        SQL.putBuf("select count(*) into acnt from QueryResult where QueryResultid=aidout;")
        SQL.putBuf("return acnt;")
        SQL.putBuf("End; $$ language 'plpgsql';")
        SQL.putBuf("GO")



        SQL.putBuf("create or replace function  ROWPARENTS")
        SQL.putBuf("(aQueryID   uuid")
        SQL.putBuf(",aRowID uuid/* Row */")
        SQL.putBuf(",aTable varchar /* Part Table Name */")
        SQL.putBuf(",aCURSESSION uuid/* the_session */")
        SQL.putBuf(") returns void as $$")
        SQL.putBuf(" declare ")
        SQL.putBuf("astr varchar(4000);")
        SQL.putBuf("aplevel integer ;")
        SQL.putBuf("aparent varchar(255) ;")
        SQL.putBuf("aprev varchar(255) ;")
        SQL.putBuf("atmpID  uuid ;")
        SQL.putBuf("atmpRowID  uuid ;")
        SQL.putBuf("existsCnt integer;")
        SQL.putBuf("begin")
        SQL.putBuf(" select count(*) into existsCnt from  the_session where the_sessionid=acursession and closed=0;")
        SQL.putBuf(" -- checking the_session  --")
        SQL.putBuf("if existsCnt=0")
        SQL.putBuf("  then")
        SQL.putBuf("     perform  raise_application_error(-20000,'the_session expired') ;")
        SQL.putBuf("    Return ;")
        SQL.putBuf("  End if;")
        SQL.putBuf("aparent :=atable ;")
        SQL.putBuf("atmpID := aROWID ;")
        SQL.putBuf("aplevel :=0 ;")
        SQL.putBuf("delete from RPRESULT where RPRESULTID")
        SQL.putBuf("  =aQUERYID;")
        SQL.putBuf("insert into RPRESULT(RPRESULTID,PARENTLEVEL,PARTNAME,theROWID)")
        SQL.putBuf("   values(aQUERYID,aPLEVEL,atable,aRowID) ;")
        SQL.putBuf("LOOP")
        SQL.putBuf(" aplevel :=aplevel + 1 ;")
        SQL.putBuf(" aprev := aparent ;")

        SQL.putBuf(" begin")
        SQL.putBuf("   select thevalue into aparent from sysoptions where optiontype ='PARENT' and  name=aprev ;")
        SQL.putBuf(" exception when others then")
        SQL.putBuf("   aparent := null ;")
        SQL.putBuf(" end;")

        SQL.putBuf(" if aparent is null")
        SQL.putBuf(" then")
        SQL.putBuf("     astr := 'select InstanceID  from ' || aprev || ' where ' || aprev || 'id=$1' ;")
        SQL.putBuf("    execute  astr into atmpRowID using atmpid ;")
        SQL.putBuf("   insert into RPRESULT(RPRESULTID,PARENTLEVEL,PARTNAME,theROWID)")
        SQL.putBuf("   values(aQUERYID,aPLEVEL,'INSTANCE',atmpRowID);")
        SQL.putBuf("   return;")
        SQL.putBuf(" Else")
        SQL.putBuf("    astr := 'select ParentStructRowID  from ' || aprev || ' where '  || aprev || 'id=$1' ;")
        SQL.putBuf("    execute  astr into atmpRowID using atmpid ;")
        SQL.putBuf("    atmpID := atmpROWID ;")
        SQL.putBuf("   insert into RPRESULT(RPRESULTID,PARENTLEVEL,PARTNAME,theROWID)")
        SQL.putBuf("   values(aQUERYID,aPLEVEL,aparent,atmpRowID) ;")
        SQL.putBuf(" End if;")
        SQL.putBuf("End LOOP;")
        SQL.putBuf("End; $$ language 'plpgsql';")
        SQL.putBuf("GO")



        SQL.putBuf("  create or replace function  INSTANCE_STATUS    (")
        SQL.putBuf("  aCURSESSION uuid,")
        SQL.putBuf("  ainstanceid uuid,")
        SQL.putBuf("  astatusid uuid) returns void ")
        SQL.putBuf("as $$")
        SQL.putBuf(" declare ")
        SQL.putBuf("   aSSID uuid;")
        SQL.putBuf("   atmpID uuid;")
        SQL.putBuf("   aSysLogID uuid ;")
        SQL.putBuf("   aaccess integer;")
        SQL.putBuf("   aSysInstID uuid ;")
        SQL.putBuf("   aObjType varchar(255) ;")
        SQL.putBuf("   existsCnt integer;")
        SQL.putBuf("  begin")
        SQL.putBuf("   select Instanceid into aSysInstID from instance where objtype='MTZSYSTEM' ;")
        SQL.putBuf("   select count(*) into existsCnt from instance where instanceid=ainstanceid;")
        SQL.putBuf(" If existsCnt = 1 Then")
        '  SQL.putBuf "   select  SecurityStyleID into atmpID from INSTANCE where INSTANCEid=aINSTANCEid ;"
        '  SQL.putBuf "   CheckVerbRight (acursession,atmpID,'STATUS',aaccess );"
        '  SQL.putBuf "   If aaccess = 0 Then"
        '  SQL.putBuf "     perform  raise_application_error(-20000,'Нет прав на изменение состояния объекта.');"
        '  SQL.putBuf "    Return ;"
        '  SQL.putBuf "   End if;"
        SQL.putBuf("   aaccess:= instance_ISLOCKED( acursession,ainstanceid);")
        SQL.putBuf("   If aaccess > 2 Then")
        SQL.putBuf("      perform  raise_application_error(-20000,'Документ заблокирован другим пльзователем.') ;")
        SQL.putBuf("     Return ;")
        SQL.putBuf("   End if;")
        SQL.putBuf("   select objtype into aObjType from instance  where  instanceid=ainstanceid ;")
        SQL.putBuf("   select count(*) into existsCnt from objstatus")
        SQL.putBuf("  join objecttype on objstatus.parentstructrowid=objecttype.objecttypeid")
        SQL.putBuf("  where objecttype.name=aobjtype and objstatusid=astatusid ;")
        SQL.putBuf("   If existsCnt = 1 Then")
        SQL.putBuf("     update instance set status = astatusid where  instanceid=ainstanceid ;")
        SQL.putBuf("     select newid() into aSysLogid;")
        SQL.putBuf("     PERFORM SysLog_SAVE (acursession , aSysLogid, aSysInstID, acursession,   cast(aSTATUSID as varchar) , cast(aInstanceID as varchar),")
        SQL.putBuf("     'STATUS',   aInstanceID); ")
        SQL.putBuf("   End if;")
        SQL.putBuf(" End if;")
        SQL.putBuf("End; $$ language 'plpgsql';")
        SQL.putBuf("GO")


        o.ModuleName = "--functions.Body"
        o.Block = "--body"
        o.OutNL(SQL.getBuf)

        'UPGRADE_NOTE: Object SQL may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        SQL = Nothing

        Exit Sub
bye:


        'Resume
        'Stop
        'UPGRADE_NOTE: Object SQL may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        SQL = Nothing
    End Sub
	
	Public Sub Run()
		PreInstall()
		
		CreateKernelPackage()
		KernelProcsHeader()
		KernelProcs()
		CloseKernelPackage()
	End Sub
End Class