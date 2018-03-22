Imports LATIRGenerator
Imports MTZMetaModel.MTZMetaModel

Public Class MakeKernel
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

    Private Sub CreateKernelPackage()
        o.ModuleName = "--Procedures.Kernel.Header"
        o.Block = "--body"
        o.OutNL(" create or replace package Kernel as")

        o.ModuleName = "--Procedures.Kernel.Body"
        o.Block = "--body"
        o.OutNL(" create or replace package body Kernel as")


    End Sub

    Private Sub CloseKernelPackage()
        o.ModuleName = "--Procedures.Kernel.Header"
        o.Block = "--body"
        o.OutNL(" end Kernel;")
        o.OutNL("/")

        o.ModuleName = "--Procedures.Kernel.Body"
        o.Block = "--body"
        o.OutNL(" end Kernel;")
        o.OutNL("/")
    End Sub




    Private Sub KernelProcsHeader()

        Dim SQL As Writer
        SQL = New Writer

        ' DoEvents()
        On Error GoTo bye


        SQL.putBuf("procedure INSTANCE_OWNER   (")
        SQL.putBuf("    acursession CHAR ,ainstanceid CHAR,")
        SQL.putBuf(" aOwnerPartName varchar2, aOwnerRowID CHAR); ")


        SQL.putBuf("procedure SYSOPTIONS_SAVE    (")
        SQL.putBuf(" aSysOptionsid CHAR,")
        SQL.putBuf(" aName varchar2,")
        SQL.putBuf(" aValue varchar2 ,")
        SQL.putBuf(" aOptionType varchar2);")


        SQL.putBuf("procedure INSTANCE_SAVE      (")
        SQL.putBuf("aCURSESSION CHAR,")
        SQL.putBuf("aInstanceID CHAR,")
        SQL.putBuf("aObjType varchar2,")
        SQL.putBuf("aName varchar2")
        SQL.putBuf(");")

        SQL.putBuf("  procedure INSTANCE_DELETE    (")
        SQL.putBuf("aCURSESSION CHAR,")
        SQL.putBuf("aInstanceID Char")
        SQL.putBuf(");")
        SQL.putBuf("  procedure INSTANCE_HCL   (")
        SQL.putBuf("aCURSESSION CHAR,")
        SQL.putBuf("aRowID CHAR,")
        SQL.putBuf("aIsLocked out NUMBER")
        SQL.putBuf(");")

        SQL.putBuf("  procedure INSTANCE_PROPAGATE   (")
        SQL.putBuf("aCURSESSION CHAR,")
        SQL.putBuf("aRowID Char")
        SQL.putBuf(");")

        SQL.putBuf("  procedure INSTANCE_ISLOCKED   (")
        SQL.putBuf(" aCURSESSION CHAR,")
        SQL.putBuf(" aRowID CHAR ,")
        SQL.putBuf(" aIsLocked out integer")
        SQL.putBuf(");")

        SQL.putBuf("  procedure INSTANCE_SINIT    (")
        SQL.putBuf("aCURSESSION CHAR,")
        SQL.putBuf("aRowID CHAR ,")
        SQL.putBuf(" aSecurityStyleID Char")
        SQL.putBuf(");")
        SQL.putBuf("  procedure INSTANCE_LOCK     (")
        SQL.putBuf(" aCURSESSION CHAR,")
        SQL.putBuf(" aRowID CHAR ,")
        SQL.putBuf(" aLockMode integer")
        SQL.putBuf(") ;")
        SQL.putBuf("  procedure INSTANCE_UNLOCK (")
        SQL.putBuf(" aCURSESSION CHAR,")
        SQL.putBuf(" aROWID Char")
        SQL.putBuf(");")


        SQL.putBuf("    procedure INSTANCE_BRIEF    (")
        SQL.putBuf(" aCURSESSION CHAR,")
        SQL.putBuf(" ainstanceid CHAR,")
        SQL.putBuf(" aBRIEF out varchar2")
        SQL.putBuf(") ;")
        SQL.putBuf("    procedure QR_AND_QR  ( aid1 CHAR, aid2")
        SQL.putBuf("    CHAR,aidout CHAR,acnt out integer );")

        SQL.putBuf("    procedure QR_OR_QR  ( aid1 CHAR, aid2 ")
        SQL.putBuf("    CHAR,aidout CHAR,acnt out integer);")

        SQL.putBuf("  procedure ROWPARENTS")
        SQL.putBuf("(aQueryID   CHAR")
        SQL.putBuf(",aRowID CHAR/* Row */")
        SQL.putBuf(",aTable varchar2 /* Part Table Name */")
        SQL.putBuf(",aCURSESSION CHAR/* the_session */")
        SQL.putBuf(");")

        SQL.putBuf("    procedure INSTANCE_STATUS    (")
        SQL.putBuf("  acursession CHAR,")
        SQL.putBuf("  ainstanceid CHAR,")
        SQL.putBuf("  astatusid CHAR);")

        o.ModuleName = "--Procedures.Kernel.Header"
        o.Block = "--body"
        o.OutNL(SQL.getBuf)

        SQL = Nothing

        System.Diagnostics.Debug.Print("ORAGEN.KERNELPROC:done")
        Exit Sub
bye:

        System.Diagnostics.Debug.Print("ORAGEN.KERNELPROC:" & Err.Description)
        'Resume
        'Stop
        SQL = Nothing
    End Sub

    Private Sub PreInstall()
        Dim s As String = ""
        Dim SQL As Writer
        SQL = New Writer

        ' DoEvents()
        On Error GoTo bye

        s += vbCrLf + "/*NEWID (NEWID)*/"
        s += vbCrLf + "create or replace function NEWID return varchar2 as"
        s += vbCrLf + "  Result varchar2(38);"
        s += vbCrLf + "  lguid raw(128);"
        s += vbCrLf + "  sTempString varchar2(38);"
        s += vbCrLf + "begin"
        s += vbCrLf + "  select sys_guid() into lguid from dual;"
        s += vbCrLf + "  sTempString:=to_char(lguid);"
        s += vbCrLf + "  Result:='{' || "
        s += vbCrLf + "              Substr(sTempString, 1, 8) "
        s += vbCrLf + "              || '-' ||"
        s += vbCrLf + "              Substr(sTempString, 9, 4) "
        s += vbCrLf + "              || '-' ||"
        s += vbCrLf + "              Substr(sTempString, 13, 4) "
        s += vbCrLf + "              || '-' ||"
        s += vbCrLf + "              Substr(sTempString, 17, 4) "
        s += vbCrLf + "              || '-' ||"
        s += vbCrLf + "              Substr(sTempString, 21, 12) "
        s += vbCrLf + "              || '}';"
        s += vbCrLf + "  return(Result);"
        s += vbCrLf + "end NEWID;"
        s += vbCrLf + "/"

        SQL.putBuf(s)

        o.ModuleName = "--PreInstall"
        o.Block = "--body"
        o.OutNL(SQL.getBuf)

        SQL = Nothing

        Exit Sub
bye:



        SQL = Nothing
    End Sub


    Private Sub KernelProcs()

        Dim SQL As Writer
        SQL = New Writer

        ' DoEvents()
        On Error GoTo bye



        SQL.putBuf("procedure INSTANCE_OWNER   (")
        SQL.putBuf("    acursession Char ,ainstanceid Char,")
        SQL.putBuf(" aOwnerPartName varchar2, aOwnerRowID Char) As")
        SQL.putBuf(" existsCnt Integer;")
        SQL.putBuf("begin")
        SQL.putBuf("Select count(*)into existscnt from instance")
        SQL.putBuf("where instanceid=ainstanceid;")
        SQL.putBuf("If existsCnt > 0 Then")
        SQL.putBuf("  If aOwnerPartName Is null Or aownerRowID Is null")
        SQL.putBuf("  Then")
        SQL.putBuf("     update instance Set OwnerPartName=null, OwnerRowid = null where instanceid=ainstanceid ;")
        SQL.putBuf("  Else")
        SQL.putBuf("     update instance Set OwnerPartName=aOwnerPartName, OwnerRowid = aOwnerRowID where instanceid=ainstanceid ;")
        SQL.putBuf("  End If;")
        SQL.putBuf("End If;")
        SQL.putBuf("End;")



        SQL.putBuf("procedure SYSOPTIONS_SAVE    (")
        SQL.putBuf("   aSysOptionsid Char,")
        SQL.putBuf("aName varchar2,")
        SQL.putBuf("aValue varchar2 ,")
        SQL.putBuf("aOptionType varchar2) As")
        SQL.putBuf("existsCnt numeric;")
        SQL.putBuf("begin")
        SQL.putBuf(" Select count(*) into existsCnt from sysoptions where sysoptionsid=asysoptionsid;")
        SQL.putBuf(" If existsCnt > 0 Then")
        SQL.putBuf("  update sysoptions Set Name=aName, theValue=aValue, OptionType=aOptionType where sysoptionsid=asysoptionsid ;")
        SQL.putBuf(" Else")
        SQL.putBuf("  insert into sysoptions (sysoptionsid, Name, theValue, OptionType)values(asysoptionsid,aName,aValue,aOptionType) ;")
        SQL.putBuf(" End If;")
        SQL.putBuf("End;")


        SQL.putBuf("procedure INSTANCE_SAVE      (")
        SQL.putBuf("aCURSESSION Char,")
        SQL.putBuf("aInstanceID Char,")
        SQL.putBuf("aObjType varchar2,")
        SQL.putBuf("aName varchar2")
        SQL.putBuf(") As")
        SQL.putBuf(" atmpStr varchar2(255) ;")
        SQL.putBuf(" aSSID Char(38) ;")
        SQL.putBuf(" atmpID Char(38) ;")
        SQL.putBuf(" aSysLogID Char(38) ;")
        SQL.putBuf(" aaccess numeric ;")
        SQL.putBuf(" aSysInstID Char(38) ;")
        SQL.putBuf(" aStatusID Char(38) ;")
        SQL.putBuf(" existsCnt numeric;")
        SQL.putBuf(" theObjType varchar2(255);")
        SQL.putBuf("begin")
        SQL.putBuf(" Select  Instanceid into aSysInstID from instance where objtype=lower('MTZSYSTEM');")
        SQL.putBuf(" select  count(*) into existsCnt  from instance where instanceid=ainstanceid;")
        SQL.putBuf(" If existsCnt > 0 Then")
        SQL.putBuf("   select  SecurityStyleID into atmpID from INSTANCE where INSTANCEid=aINSTANCEid ;")
        SQL.putBuf("   CheckVerbRight (acursession=>acursession,athe_resource=>atmpID,averb=>'EDIT',aaccess=>aaccess  );")
        SQL.putBuf("   If aaccess = 0 Then")
        SQL.putBuf("     raise_application_error(-20000,'Нет прав на изменение объекта.') ;")
        SQL.putBuf("     return ;")
        SQL.putBuf("   end if;")
        SQL.putBuf("   " + SchemaName + ".Kernel.instance_ISLOCKED (acursession=>acursession,aROWID=>ainstanceid,aIsLocked=>aaccess  );")
        SQL.putBuf("   If aaccess > 2 Then")
        SQL.putBuf("     raise_application_error(-20000,'Объект заблокирован другим пользователем.') ;")
        SQL.putBuf("     return;")
        SQL.putBuf("   end if;")
        SQL.putBuf("   select objtype into TheObjType from instance  where  instanceid=ainstanceid ;")
        SQL.putBuf("   update instance set name = aname where  instanceid=ainstanceid;")
        SQL.putBuf("   select newid() into aSysLogID from sys.DUAL ;")
        SQL.putBuf("   MTZSystem.SysLog_SAVE (aCURSESSION=>acursession ,aTheSession=>acursession, aInstanceID=>aSysInstID, aSysLogid=>aSysLogid,")
        SQL.putBuf("   aLogStructID => TheOBJTYPE ,")
        SQL.putBuf("   aVERB=>'EDIT',  aThe_Resource=>aInstanceID, aLogInstanceID=>aInstanceID );")
        SQL.putBuf(" Else")
        SQL.putBuf("    select count(*) into existsCnt from typelist where name = aobjtype;")
        SQL.putBuf("    If existsCnt > 0 Then")
        SQL.putBuf("      select SecurityStyleid,RegisterProc into aSSID,atmpstr  from typelist where name = aobjtype;")
        SQL.putBuf("      CheckVerbRight (acursession=>acursession,aThe_Resource=>aSSID,averb=>'CREATE',aaccess=>aaccess  );")
        SQL.putBuf("      If aaccess = 0 Then")
        SQL.putBuf("         raise_application_error(-20000,'Нет прав на создание объекта.') ;")
        SQL.putBuf("         return;")
        SQL.putBuf("      end if;")

        SQL.putBuf("    end if;")
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
        SQL.putBuf("   If Not atmpstr Is Null Then")
        SQL.putBuf("      execute immediate atmpstr using  acursession, ainstanceid;")
        SQL.putBuf("   end if;")
        SQL.putBuf("   select newid() into aSysLogid from sys.dual ;")
        SQL.putBuf("   ")
        SQL.putBuf("   MTZSystem.SysLog_SAVE (")
        SQL.putBuf("     aCURSESSION=>acursession ,aTheSession=>acursession,")
        SQL.putBuf("     aInstanceID=>aSysInstID, aSysLogid=>aSysLogid, aLogStructID => aOBJTYPE ,")
        SQL.putBuf("     aVERB=>'CREATE',  aThe_Resource=>aInstanceID , aLogInstanceID=>aInstanceID);")
        SQL.putBuf(" End  if;")
        SQL.putBuf("End;")



        SQL.putBuf("  procedure INSTANCE_DELETE    (")
        SQL.putBuf("aCURSESSION CHAR,")
        SQL.putBuf("aInstanceID Char")
        SQL.putBuf(") as")
        SQL.putBuf(" atmpStr varchar2(255) ;")
        SQL.putBuf("  aStr varchar2(4000) ;")
        SQL.putBuf("  aObjType varchar2(255) ;")
        SQL.putBuf(" aSysInstID CHAR(38) ;")
        SQL.putBuf("    atmpID CHAR(38) ;")
        SQL.putBuf("   aaccess integer;")
        SQL.putBuf("   aOwnerPartName varchar2(255) ;")
        SQL.putBuf("   aOwnerRowID CHAR(38) ;")
        SQL.putBuf("   aSysLogid CHAR(38) ;")
        SQL.putBuf("    existsCnt integer;")
        SQL.putBuf("begin")
        SQL.putBuf("  select Instanceid into aSysInstID from instance where objtype=lower('MTZSYSTEM') ;")
        SQL.putBuf("  select count(*) into existsCnt from instance where instanceid=ainstanceid;")
        SQL.putBuf("  If existsCnt > 0 Then")
        SQL.putBuf("   select  SecurityStyleID, OwnerPartName,OWnerRowID")
        SQL.putBuf("        Into atmpid, aOwnerpartname, aownerrowid")
        SQL.putBuf("        from INSTANCE where INSTANCEid=aINSTANCEid ;")
        SQL.putBuf("   CheckVerbRight (acursession=>acursession,aThe_Resource=>atmpID,averb=>'DELETE',aaccess=>aaccess);")
        SQL.putBuf("   If aaccess = 0 Then")
        SQL.putBuf("       raise_application_error(-20000,'Нет прав на удаление.');")
        SQL.putBuf("       Return ;")
        SQL.putBuf("   End if;")
        SQL.putBuf("   If aOwnerpartname Is Null Or aownerrowid Is Null Then")
        SQL.putBuf("        select  objtype into aobjtype from instance where instanceid=ainstanceid;")
        SQL.putBuf("        select 'begin " + SchemaName + ".' || aobjtype || '.' || DeleteProc ||'(:1,:2); end;' into atmpstr from typelist where name = aobjtype;")
        SQL.putBuf("        If Not atmpstr Is Null Then")
        SQL.putBuf("            EXECUTE IMMEDIATE atmpstr USING acursession,ainstanceid;")
        SQL.putBuf("        end if;")
        SQL.putBuf("        delete from instance where instanceid=ainstanceid ;")
        SQL.putBuf("        select newid() into aSysLogID from SYS.DUAL;")
        SQL.putBuf("        MTZSystem.SysLog_SAVE( aCURSESSION=>acursession ,aTheSession=>acursession, aInstanceID=>aSysInstID, aSysLogid=>aSysLogid, aLogStructID => aobjtype ,")
        SQL.putBuf("        aVERB=>'DELETE',  aThe_Resource=>aInstanceID, aLogInstanceID=>aInstanceID);")
        SQL.putBuf("        Else")
        SQL.putBuf("        -- Owner exists")
        SQL.putBuf("         astr :='select '|| aownerpartname || 'id  from ' || aownerpartname || ' where ' || aownerpartname ||'id=:1';")
        SQL.putBuf("         execute immediate  astr into atmpid using aownerrowid;")
        SQL.putBuf("         If atmpid = aownerrowid Then")
        SQL.putBuf("           raise_application_error(-20000,'Этот документ принадлежит другому документу и не может быть удален отдельно.');")
        SQL.putBuf("           return;")
        SQL.putBuf("         End if;")
        SQL.putBuf("         select  objtype into aObjType from instance where instanceid=ainstanceid;")
        SQL.putBuf("         select 'begin " + SchemaName + ".' || aobjtype || '.' || DeleteProc ||'(:1,:2); end;' into atmpstr from typelist where name = aobjtype ;")
        SQL.putBuf("         If Not atmpstr Is Null Then")
        SQL.putBuf("           execute immediate atmpstr using acursession, ainstanceid ;")
        SQL.putBuf("           delete from instance where instanceid=ainstanceid ;")
        SQL.putBuf("         select newid() into aSysLogID from SYS.DUAL;")

        SQL.putBuf("         MTZSystem.SysLog_SAVE (aCURSESSION=>acursession ,aTheSession=>acursession,")
        SQL.putBuf("                      aInstanceID=>aSysInstID, aSysLogid=>aSysLogid, aLogStructID => aobjtype ,")
        SQL.putBuf("                      aVERB=>'DELETE',  aThe_Resource=>aInstanceID, aLogInstanceID=>aInstanceID );")
        SQL.putBuf("        End if;")
        SQL.putBuf("     End if;")
        SQL.putBuf("End if;")
        SQL.putBuf("end;")



        SQL.putBuf("  procedure INSTANCE_HCL   (")
        SQL.putBuf("aCURSESSION CHAR,")
        SQL.putBuf("aRowID CHAR,")
        SQL.putBuf("aIsLocked out NUMBER")
        SQL.putBuf(") as")
        SQL.putBuf("atmpStr varchar2(255) ;")
        SQL.putBuf("aObjType varchar2(255) ;")
        SQL.putBuf("existscnt integer;")
        SQL.putBuf("begin")
        SQL.putBuf("select count(*) into existsCnt from instance where instanceid=arowid ;")
        SQL.putBuf("if existscnt=1")
        SQL.putBuf("    then")
        SQL.putBuf("      select objtype into aobjtype  from instance where instanceid=arowid ;")
        SQL.putBuf("      select 'begin " + SchemaName + ".' || aobjtype || '.' || HCLProc || '(:1,:2,:3); end;' into atmpstr from typelist where name = aobjtype;")
        SQL.putBuf("      If Not atmpstr Is Null Then")
        SQL.putBuf("        execute immediate atmpstr using acursession, arowid,out aIsLocked ;")
        SQL.putBuf("      End if;")
        SQL.putBuf("end if;")
        SQL.putBuf("End;")


        SQL.putBuf("  procedure INSTANCE_PROPAGATE   (")
        SQL.putBuf("aCURSESSION CHAR,")
        SQL.putBuf("aRowID Char")
        SQL.putBuf(") as")

        SQL.putBuf("atmpStr varchar2(255) ;")
        SQL.putBuf("aObjType varchar2(255);")
        SQL.putBuf("existsCnt integer;")
        SQL.putBuf("begin")

        SQL.putBuf("select count(*) into existsCnt from instance where instanceid=arowid ;")
        SQL.putBuf("if existsCnt=1")
        SQL.putBuf("    then")
        SQL.putBuf("      select  objtype into aobjtype from instance where instanceid=arowid ;")
        SQL.putBuf("      select  'begin " + SchemaName + ".' || aobjtype || '.' || propagateProc || '(:1,:2); end;' into atmpstr from typelist where name = aobjtype;")
        SQL.putBuf("      If Not atmpstr Is Null Then")
        SQL.putBuf("        execute immediate atmpstr using  acursession, arowid ;")
        SQL.putBuf("    End if;")
        SQL.putBuf("End if;")
        SQL.putBuf("End;")




        SQL.putBuf("  procedure INSTANCE_ISLOCKED   (")
        SQL.putBuf(" aCURSESSION CHAR,")
        SQL.putBuf(" aRowID CHAR ,")
        SQL.putBuf(" aIsLocked out integer")
        SQL.putBuf(") as")
        SQL.putBuf(" aUserID CHAR(38) ;")
        SQL.putBuf(" aLockUserID CHAR(38) ;")
        SQL.putBuf(" aLockSessionID CHAR(38) ;")
        SQL.putBuf(" existsCnt integer;")
        SQL.putBuf(" begin")

        SQL.putBuf(" aisLocked := 0 ;")
        SQL.putBuf(" -- checking the_session  --")
        SQL.putBuf(" select count(*) into existsCnt from  the_session where the_sessionid=acursession and closed=0;")
        SQL.putBuf(" If existsCnt = 0 Then")
        SQL.putBuf("   raise_APPLICATION_Error(-20000,'Сессия уже завершена');")
        SQL.putBuf("   Return ;")
        SQL.putBuf(" End if;")
        SQL.putBuf(" select  usersid into auserID from  the_session where the_sessionid=acursession ;")
        SQL.putBuf(" select LockUserID, LockSessionID")
        SQL.putBuf(" Into aLockUserID, aLockSessionID")
        SQL.putBuf(" from INSTANCE where INSTANCEid=aRowID ;")
        SQL.putBuf(" If Not aLockUserID Is Null Then")
        SQL.putBuf("   If aLockUserID <> auserID Then")
        SQL.putBuf("     aisLocked := 4; /* CheckOut by another user */")
        SQL.putBuf("     Return ;")
        SQL.putBuf("   Else")
        SQL.putBuf("     aisLocked := 2; /* CheckOut by caller */")
        SQL.putBuf("     Return;")
        SQL.putBuf("   end if;")
        SQL.putBuf(" End if;")
        SQL.putBuf(" If Not aLockSessionID Is Null Then")
        SQL.putBuf("   If aLockSessionID <> aCURSESSION Then")

        SQL.putBuf("     aisLocked := 3 ;/* Lockes by another user */")
        SQL.putBuf("     Return ;")
        SQL.putBuf("   Else")
        SQL.putBuf("     aisLocked := 1; /* Locked by caller */")
        SQL.putBuf("     Return ;")
        SQL.putBuf("   end if;")
        SQL.putBuf(" End if;")
        SQL.putBuf(" aisLocked := 0 ;")
        SQL.putBuf(" End;")



        SQL.putBuf("  procedure INSTANCE_SINIT    (")
        SQL.putBuf("aCURSESSION CHAR,")
        SQL.putBuf("aRowID CHAR ,")
        SQL.putBuf(" aSecurityStyleID Char")
        SQL.putBuf(")as")
        SQL.putBuf("aParentTable varchar2(255) ;")
        SQL.putBuf(" aStyleID CHAR(38) ;")
        SQL.putBuf(" atmpID CHAR(38) ;")
        SQL.putBuf(" aaccess integer ;")
        SQL.putBuf(" begin")
        SQL.putBuf("  select  SecurityStyleID into atmpID from INSTANCE where INSTANCEid=aROWID;")
        SQL.putBuf(" CheckVerbRight( acursession=>acursession,aThe_Resource=>atmpID,averb=>'SECURE',aaccess=>aaccess);")
        SQL.putBuf(" if aaccess=0")
        SQL.putBuf("  then")
        SQL.putBuf("    raise_application_error(-20000,'Нет прав на управление защитой.');")
        SQL.putBuf("    return ;")
        SQL.putBuf("  end if;")
        SQL.putBuf("  If aSecurityStyleID Is Null Then")
        SQL.putBuf("    select  objtype into aParentTable from instance where instanceid=aRowID ;")
        SQL.putBuf("    select SecurityStyleID  into aStyleID from typelist where name =aParentTable ;")
        SQL.putBuf("    update Instance set securitystyleid =aStyleID where Instanceid = aRowID;")
        SQL.putBuf("  Else")
        SQL.putBuf("    update Instance set securitystyleid =aSecurityStyleID where Instanceid = aRowID ;")
        SQL.putBuf("  End if;")
        SQL.putBuf("End;")

        SQL.putBuf("  procedure INSTANCE_LOCK     (")
        SQL.putBuf(" aCURSESSION CHAR,")
        SQL.putBuf(" aRowID CHAR ,")
        SQL.putBuf(" aLockMode integer")
        SQL.putBuf(") as")

        SQL.putBuf("aUserID CHAR(38);")
        SQL.putBuf(" atmpID CHAR(38);")
        SQL.putBuf(" aaccess integer ;")
        SQL.putBuf(" aIsLocked integer ;")
        SQL.putBuf(" existsCnt integer;")
        SQL.putBuf("  begin")
        SQL.putBuf(" select count(*) into existsCnt from  the_session where the_sessionid=acursession and closed=0;")
        SQL.putBuf(" -- checking the_session  --")
        SQL.putBuf("If existsCnt = 0 Then")
        SQL.putBuf("    raise_application_error(-20000,'Сессия уже завершена.') ;")
        SQL.putBuf("    Return ;")
        SQL.putBuf("End if;")
        SQL.putBuf(" select  usersid into auserID from  the_session where the_sessionid=acursession;")
        SQL.putBuf(" " + SchemaName + ".Kernel.Instance_ISLOCKED (aCURSESSION,aROWID,aISLocked);")
        SQL.putBuf(" if aIsLocked >=3")
        SQL.putBuf("  then")
        SQL.putBuf("    raise_application_error(-20000,'Объект заблокирован другим пользователем');")
        SQL.putBuf("    Return ;")
        SQL.putBuf("  End if;")
        SQL.putBuf(" if aIsLocked =0")
        SQL.putBuf(" then")
        SQL.putBuf("  " + SchemaName + ".Kernel.Instance_HCL( acursession,aRowID,aisLocked);")
        SQL.putBuf("  if aIsLocked >=3")
        SQL.putBuf("  then")
        SQL.putBuf("     raise_application_error(-20000,'У данного объекта имеются дочерние строки, которые заблокированы другим пользователем');")
        SQL.putBuf("     Return ;")
        SQL.putBuf("  End if;")
        SQL.putBuf(" End if;")
        SQL.putBuf(" select  SecurityStyleID into atmpid from INSTANCE where INSTANCEid=aROWID ;")
        SQL.putBuf(" CheckVerbRight (acursession=>acursession,aThe_Resource=>atmpID,averb=>'LOCKINSTANCE',aaccess=>aaccess);")
        SQL.putBuf(" if aaccess=0")
        SQL.putBuf("  then")
        SQL.putBuf("    raise_application_error(-20000,'Нет прав на блокировку объекта.');")

        SQL.putBuf("    return ;")
        SQL.putBuf("  end if;")
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
        SQL.putBuf(" End;")


        SQL.putBuf("  procedure INSTANCE_UNLOCK (")
        SQL.putBuf(" aCURSESSION CHAR,")
        SQL.putBuf(" aROWID Char")
        SQL.putBuf(") as")
        SQL.putBuf(" aParentID CHAR(38);")
        SQL.putBuf(" aUserID CHAR(38) ;")
        SQL.putBuf(" aIsLocked integer ;")
        SQL.putBuf(" aParentTable varchar2(255);")
        SQL.putBuf(" existsCnt integer;")
        SQL.putBuf(" begin")
        SQL.putBuf(" -- checking the_session  --")
        SQL.putBuf(" select count(*) into existsCnt from  the_session where the_sessionid=acursession and closed=0;")
        SQL.putBuf("if  existsCnt =0")
        SQL.putBuf("  then")
        SQL.putBuf("    raise_application_error(-20000,'Сессия уже завершена.');")
        SQL.putBuf("    Return ;")
        SQL.putBuf("  End if;")
        SQL.putBuf("  " + SchemaName + ".Kernel.Instance_ISLOCKED( aCURSESSION,aROWID,aISLocked  );")
        SQL.putBuf(" if aIsLocked >=3")
        SQL.putBuf("  then")
        SQL.putBuf("    raise_application_error(-20000,'Объект заблокирован другим пользователем');")
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
        SQL.putBuf(" End; ")



        SQL.putBuf("    procedure INSTANCE_BRIEF    (")
        SQL.putBuf(" aCURSESSION CHAR,")
        SQL.putBuf(" ainstanceid CHAR,")
        SQL.putBuf(" aBRIEF out varchar2")
        SQL.putBuf(") as")
        SQL.putBuf(" atmpStr varchar2(255);")
        SQL.putBuf(" aaccess int ;")
        SQL.putBuf(" atmpBrief varchar2(4000) ;")
        SQL.putBuf(" atmpID CHAR(38) ;")
        SQL.putBuf(" existsCnt integer;")
        SQL.putBuf(" begin")
        SQL.putBuf(" -- checking the_session  --")
        SQL.putBuf(" select count(*) into existsCnt  from  the_session where the_sessionid=acursession and closed=0;")
        SQL.putBuf("If existsCnt = 0 Then")
        SQL.putBuf("    raise_application_error(-20000,'Сессия уже завершена.') ;")
        SQL.putBuf("    Return ;")
        SQL.putBuf("  End if;")
        SQL.putBuf("If ainstanceid Is Null Then")
        SQL.putBuf("     aBRIEF:='';")
        SQL.putBuf("    return;")
        SQL.putBuf("end if;")


        SQL.putBuf(" -- Brief body --")
        SQL.putBuf("  select count(*) into existsCnt  from instance where instanceID=ainstanceID;")
        SQL.putBuf("If existsCnt = 1 Then")
        SQL.putBuf(" --  verify access  --")
        SQL.putBuf(" select  SecurityStyleID into atmpID from instance where instanceid=ainstanceID ;")
        SQL.putBuf(" CheckVerbRight( acursession=>acursession,aThe_Resource=>atmpID,")
        SQL.putBuf("     averb=>'BRIEF',aaccess=>aaccess);")
        SQL.putBuf(" If aaccess = 0 Then")
        SQL.putBuf("    raise_application_error(-20000,'Нет прав на получение краткого наименования. Раздел=instance') ;")
        SQL.putBuf("    Return ;")
        SQL.putBuf(" End  if;")

        SQL.putBuf("  select func.instance_brief_F(instanceid) into aBrief from instance where instanceid=ainstanceid;")

        SQL.putBuf(" Else")
        SQL.putBuf("   aBRIEF:= 'неверный идентификатор';")
        SQL.putBuf("End if;")
        SQL.putBuf("    aBRIEF:=substr(aBRIEF,1,255);")
        SQL.putBuf("End;")



        SQL.putBuf("    procedure QR_AND_QR  ( aid1 CHAR, aid2")
        SQL.putBuf("    CHAR,aidout CHAR,acnt out integer )")
        SQL.putBuf("as")
        SQL.putBuf("begin")
        SQL.putBuf("delete from QueryResult where QueryResultid=aidout ;")
        SQL.putBuf("insert into QueryResult(QueryResultid,result)")
        SQL.putBuf("select distinct aidout, a.result")
        SQL.putBuf("from QueryResult a")
        SQL.putBuf("join QueryResult b on b.QueryResultid=aid2 and a.result=b.result")
        SQL.putBuf("where a.QueryResultid=aid1 ;")
        SQL.putBuf("select count(*) into acnt from QueryResult where QueryResultid=aidout;")
        SQL.putBuf("end;")


        SQL.putBuf("    procedure QR_OR_QR  ( aid1 CHAR, aid2 ")
        SQL.putBuf("    CHAR,aidout CHAR,acnt out integer)")
        SQL.putBuf("as")
        SQL.putBuf("begin")
        SQL.putBuf("delete from QueryResult where QueryResultid=aidout ;")
        SQL.putBuf("insert into QueryResult(QueryResultid,result)")
        SQL.putBuf("select distinct aidout, result from QueryResult where QueryResultid in (aid1,aid2);")
        SQL.putBuf("select count(*) into acnt from QueryResult where QueryResultid=aidout;")
        SQL.putBuf("End;")



        SQL.putBuf("  procedure ROWPARENTS")
        SQL.putBuf("(aQueryID   CHAR")
        SQL.putBuf(",aRowID CHAR/* Row */")
        SQL.putBuf(",aTable varchar2 /* Part Table Name */")
        SQL.putBuf(",aCURSESSION CHAR/* the_session */")
        SQL.putBuf(") as")
        SQL.putBuf("astr varchar(4000);")
        SQL.putBuf("aplevel integer ;")
        SQL.putBuf("aparent varchar2(255) ;")
        SQL.putBuf("aprev varchar2(255) ;")
        SQL.putBuf("atmpID  CHAR(38) ;")
        SQL.putBuf("atmpRowID  CHAR(38) ;")
        SQL.putBuf("existsCnt integer;")
        SQL.putBuf("begin")
        SQL.putBuf(" select count(*) into existsCnt from  the_session where the_sessionid=acursession and closed=0;")
        SQL.putBuf(" -- checking the_session  --")
        SQL.putBuf("if existsCnt=0")
        SQL.putBuf("  then")
        SQL.putBuf("    raise_application_error(-20000,'the_session expired') ;")
        SQL.putBuf("    Return ;")
        SQL.putBuf("  End if;")
        SQL.putBuf("aparent :=atable ;")
        SQL.putBuf("atmpID := aROWID ;")
        SQL.putBuf("aplevel :=0 ;")
        SQL.putBuf("delete from RPRESULT where RPRESULTID")
        SQL.putBuf("  =aQUERYID;")
        SQL.putBuf("insert into RPRESULT(RPRESULTID,PARENTLEVEL,PARTNAME,theROWID)")
        SQL.putBuf("   values(aQUERYID,aPLEVEL,atable,aRowID) ;")
        SQL.putBuf("<<again>>")
        SQL.putBuf(" aplevel :=aplevel + 1 ;")
        SQL.putBuf(" aprev := aparent ;")

        SQL.putBuf(" begin")
        SQL.putBuf("   select thevalue into aparent from sysoptions where optiontype ='PARENT' and  name=aprev ;")
        SQL.putBuf(" exception when others then")
        SQL.putBuf("   aparent := null ;")
        SQL.putBuf(" end;")

        SQL.putBuf(" if aparent is null")
        SQL.putBuf(" then")
        SQL.putBuf("     astr := 'select InstanceID  from ' || aprev || ' where ' || aprev || 'id=:1' ;")
        SQL.putBuf("    execute immediate astr into atmpRowID using atmpid ;")
        SQL.putBuf("   insert into RPRESULT(RPRESULTID,PARENTLEVEL,PARTNAME,theROWID)")
        SQL.putBuf("   values(aQUERYID,aPLEVEL,'INSTANCE',atmpRowID);")
        SQL.putBuf(" Else")
        SQL.putBuf("    astr := 'select ParentStructRowID  from ' || aprev || ' where '  || aprev || 'id=:1' ;")
        SQL.putBuf("    execute immediate astr into atmpRowID using atmpid ;")
        SQL.putBuf("    atmpID := atmpROWID ;")
        SQL.putBuf("   insert into RPRESULT(RPRESULTID,PARENTLEVEL,PARTNAME,theROWID)")
        SQL.putBuf("   values(aQUERYID,aPLEVEL,aparent,atmpRowID) ;")
        SQL.putBuf("    GoTo again ;")
        SQL.putBuf(" End if;")
        SQL.putBuf("End;")



        SQL.putBuf("    procedure INSTANCE_STATUS    (")
        SQL.putBuf("  acursession CHAR,")
        SQL.putBuf("  ainstanceid CHAR,")
        SQL.putBuf("  astatusid CHAR)")
        SQL.putBuf("as")
        SQL.putBuf("   aSSID CHAR(38);")
        SQL.putBuf("   atmpID CHAR(38);")
        SQL.putBuf("   aSysLogID CHAR(38) ;")
        SQL.putBuf("   aaccess integer;")
        SQL.putBuf("   aSysInstID CHAR(38) ;")
        SQL.putBuf("   aObjType varchar2(255) ;")
        SQL.putBuf("   existsCnt integer;")
        SQL.putBuf("  begin")
        SQL.putBuf("   select Instanceid into aSysInstID from instance where objtype=lower('MTZSYSTEM') ;")
        SQL.putBuf("   select count(*) into existsCnt from instance where instanceid=ainstanceid;")
        SQL.putBuf(" If existsCnt = 1 Then")
        SQL.putBuf("   select  SecurityStyleID into atmpID from INSTANCE where INSTANCEid=aINSTANCEid ;")
        SQL.putBuf("   CheckVerbRight (acursession=>acursession,aThe_Resource=>atmpID,averb=>'STATUS',aaccess=>aaccess );")
        SQL.putBuf("   If aaccess = 0 Then")
        SQL.putBuf("    raise_application_error(-20000,'Нет прав на изменение состояния объекта.');")
        SQL.putBuf("    Return ;")
        SQL.putBuf("   End if;")
        SQL.putBuf("    " + SchemaName + ".Kernel.instance_ISLOCKED( acursession=>acursession,aROWID=>ainstanceid,aIsLocked=>aaccess);")
        SQL.putBuf("   If aaccess > 2 Then")
        SQL.putBuf("     raise_application_error(-20000,'Документ заблокирован другим пльзователем.') ;")
        SQL.putBuf("     Return ;")
        SQL.putBuf("   End if;")
        SQL.putBuf("   select objtype into aObjType from instance  where  instanceid=ainstanceid ;")
        SQL.putBuf("   select count(*) into existsCnt from objstatus")
        SQL.putBuf("  join objecttype on objstatus.parentstructrowid=objecttype.objecttypeid")
        SQL.putBuf("  where objecttype.name=aobjtype and objstatusid=astatusid ;")
        SQL.putBuf("   If existsCnt = 1 Then")
        SQL.putBuf("     update instance set status = astatusid where  instanceid=ainstanceid ;")
        SQL.putBuf("     select newid() into aSysLogid from sys.dual;")
        SQL.putBuf("     MTZSystem.SysLog_SAVE (aCURSESSION=>acursession ,aTheSession=>acursession, aInstanceID=>aSysInstID, aSysLogid=>aSysLogid, aLogStructID => aSTATUSID ,")
        SQL.putBuf("     aVERB=>'STATUS',  aThe_Resource=>aInstanceID , aLogInstanceID=>aInstanceID); ")
        SQL.putBuf("   End if;")
        SQL.putBuf(" End if;")
        SQL.putBuf("End;")


        o.ModuleName = "--Procedures.Kernel.Body"
        o.Block = "--body"
        o.OutNL(SQL.getBuf)

        SQL = Nothing

        Exit Sub
bye:


        'Resume
        'Stop
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