Option Strict Off
Option Explicit On
Public Class oldGenerator
    Dim m As MTZMetaModel.MTZMetaModel.Application
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


    Public Map As Collection

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



    Private Sub Kernel()
        Dim sql As Writer
        sql = New Writer

        System.Windows.Forms.Application.DoEvents()
        On Error GoTo bye
        Debug.Print("SQLGEN.KERNEL:start")
        Debug.Print("SQLGEN.KERNEL:start")


        sql.putBuf("-- Kernel Tables --")

        sql.putBuf("if not exists (select * from sysobjects where id = object_id(N'sysoptions') and OBJECTPROPERTY(id, N'IsUserTable') = 1)")
        sql.putBuf("BEGIN")
        sql.putBuf("create table sysoptions(")
        sql.putBuf("sysoptionsID uniqueidentifier primary key rowguidcol default (newid()),")
        sql.putBuf("Name varchar(255) null,")
        sql.putBuf("Value varchar(255) null,")
        sql.putBuf("OptionType VarChar(255) null")
        sql.putBuf(")")
        sql.putBuf("END ")
        sql.putBuf("go")


        sql.putBuf("if not exists (select * from sysobjects where id = object_id(N'typelist') and OBJECTPROPERTY(id, N'IsUserTable') = 1)")
        sql.putBuf("BEGIN")
        sql.putBuf("create table typelist(")
        sql.putBuf("typelistID uniqueidentifier primary key rowguidcol default (newid()),")
        sql.putBuf("Name varchar(255) not null,")
        sql.putBuf("SecurityStyleID uniqueidentifier null, /* default security style for type */")
        sql.putBuf("RegisterProc varchar(255) null,")
        sql.putBuf("DeleteProc VarChar(255) null,")
        sql.putBuf("HCLProc varchar(255) null /* has children locked */,")
        sql.putBuf("PropagateProc varchar(255) null /* propagate secrity styleto children */")
        sql.putBuf(")")
        sql.putBuf("END ")
        sql.putBuf("go")

        sql.putBuf("if not exists (select * from sysobjects where id = object_id(N'instance') and OBJECTPROPERTY(id, N'IsUserTable') = 1)")
        sql.putBuf("BEGIN")
        sql.putBuf("create table Instance(")
        sql.putBuf("InstanceID uniqueidentifier rowguidcol default (newid()) not null,")
        sql.putBuf("LockUserID uniqueidentifier null, ")
        sql.putBuf("LockSessionID uniqueidentifier null, ")
        sql.putBuf("SecurityStyleID uniqueidentifier null, /* default security style for document */")
        sql.putBuf("Name varchar(255) null,")
        sql.putBuf("ObjType VarChar(255) null,")
        sql.putBuf(")")
        sql.putBuf("ALTER TABLE Instance ADD constraint PK_INSTANCE  PRIMARY KEY  CLUSTERED  (    InstanceID  )")
        sql.putBuf("END ")
        sql.putBuf("go")

        sql.putBuf("if  not exists(select * from syscolumns where name='OwnerPartName' and id=object_id(N'INSTANCE'))")
        sql.putBuf("alter table instance add OwnerPartName varchar(255) null")
        sql.putBuf("go")

        sql.putBuf("if  not exists(select * from syscolumns where name='OwnerROwID' and id=object_id(N'INSTANCE'))")
        sql.putBuf("alter table instance add OwnerRowID uniqueidentifier null")
        sql.putBuf("go")

        sql.putBuf("if  not exists(select * from syscolumns where name='status' and id=object_id(N'INSTANCE'))")
        sql.putBuf("alter table instance add status uniqueidentifier null")
        sql.putBuf("go")

        sql.putBuf("if  not exists(select * from syscolumns where name='arcihved' and id=object_id(N'INSTANCE'))")
        sql.putBuf("alter table instance add archived int null default (0)")
        sql.putBuf("go")

        sql.putBuf("if not exists (select * from sysobjects where id = object_id(N'QueryResult') and OBJECTPROPERTY(id, N'IsUserTable') = 1)")
        sql.putBuf("BEGIN")
        sql.putBuf("CREATE TABLE QueryResult (")
        sql.putBuf("  QueryResultid uniqueidentifier NOT NULL ,")
        sql.putBuf("  result uniqueidentifier NULL ,")
        sql.putBuf(")")
        sql.putBuf("END ")
        sql.putBuf("GO")

        sql.putBuf("if not exists (select * from sysobjects where id = object_id(N'RPRESULT') and OBJECTPROPERTY(id, N'IsUserTable') = 1)")
        sql.putBuf(" BEGIN")
        sql.putBuf("CREATE TABLE RPRESULT (")
        sql.putBuf("  RPRESULTID uniqueidentifier NOT NULL ,")
        sql.putBuf("  PARENTLEVEL int NOT NULL ,")
        sql.putBuf("  PARTNAME varchar (255) NULL ,")
        sql.putBuf("  ROWID uniqueidentifier NULL ,")
        sql.putBuf("  CONSTRAINT pk_PRRESULT PRIMARY KEY  CLUSTERED")
        sql.putBuf("  (")
        sql.putBuf("    RPRESULTID,")
        sql.putBuf("    PARENTLEVEL")
        sql.putBuf("  )")
        sql.putBuf(")")
        sql.putBuf("End")
        sql.putBuf("GO")


        o.ModuleName = "--Kernel tables"
        o.Block = "--body"
        o.OutNL(sql.getBuf)

        ' создаем первую табличку в индексе
        'UPGRADE_NOTE: Object sql may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        sql = Nothing
        sql = New Writer

        sql.putBuf("exec sp_fulltext_table 'INSTANCE','Create', 'fulltext_catalog','pk_INSTANCE'")
        sql.putBuf("go")
        sql.putBuf("exec sp_fulltext_column 'INSTANCE','NAME','add',1049")
        sql.putBuf("go")
        o.ModuleName = "--FullText"
        o.Block = "--create"
        o.OutNL(sql.getBuf)


        'UPGRADE_NOTE: Object sql may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        sql = Nothing
        sql = New Writer
        sql.putBuf(funcDropSQL("instance_BRIEF_F"))
        sql.putBuf("  create function instance_BRIEF_F  (")
        sql.putBuf(" @instanceid uniqueidentifier")
        sql.putBuf(")returns varchar(4000) as  begin")
        sql.putBuf(" declare @BRIEF varchar(4000)")
        sql.putBuf("  set @BRIEF=' to do'")
        sql.putBuf("  return (@BRIEF)")
        sql.putBuf("End")
        sql.putBuf("GO")

        o.ModuleName = "--FunctionsHeader"
        o.Block = "--TableProc"
        o.OutNL(sql.getBuf)


        'UPGRADE_NOTE: Object sql may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        sql = Nothing
        sql = New Writer
        sql.putBuf("  alter function instance_BRIEF_F  (")
        sql.putBuf(" @instanceid uniqueidentifier")
        sql.putBuf(")returns varchar(4000) as  begin")
        sql.putBuf(" declare @BRIEF varchar(4000)")
        sql.putBuf("if @instanceid is null begin set @BRIEF='' return (@BRIEF) end")
        sql.putBuf(" -- Brief body --")
        sql.putBuf("if exists(select 1 from instance where instanceID=@instanceID)")
        sql.putBuf(" begin")
        sql.putBuf("  set @BRIEF=''")
        sql.putBuf("  select @BRIEF= @BRIEF")
        sql.putBuf("  +  isnull(Name,' ')+'; '")
        sql.putBuf("  from instance  where  instanceID = @instanceID")
        sql.putBuf("end else begin")
        sql.putBuf("  set @BRIEF= 'неверный идентификатор'")
        sql.putBuf("End")
        sql.putBuf("set @BRIEF=left(@BRIEF,4000)")
        sql.putBuf("  return (@BRIEF)")
        sql.putBuf("End")
        sql.putBuf("")
        sql.putBuf("GO")


        sql.putBuf(procDropSQL("INSTANCE_OWNER"))
        sql.putBuf("create proc INSTANCE_OWNER (  @cursession uniqueidentifier ,@instanceid uniqueidentifier, @OwnerPartName varchar(255), @OwnerRowID uniqueidentifier) as")
        sql.putBuf("begin")
        sql.putBuf("if exists( select 1 from instance where instanceid=@instanceid)")
        sql.putBuf("  if @OwnerPartName is null or @ownerRowID is null")
        sql.putBuf("  begin")
        sql.putBuf("     update instance set OwnerPartName=null, OwnerRowid = null where instanceid=@instanceid")
        sql.putBuf("  end Else begin")
        sql.putBuf("     update instance set OwnerPartName=@OwnerPartName, OwnerRowid = @OwnerRowID where instanceid=@instanceid")
        sql.putBuf("  End")
        sql.putBuf("End")
        sql.putBuf("go")
        sql.putBuf("")


        sql.putBuf(procDropSQL("SysOptions_Save"))
        sql.putBuf("create proc SysOptions_Save ( @SysOptionsid uniqueidentifier, @Name varchar(255),@Value varchar (255), @OptionType varchar(255)) as")
        sql.putBuf("begin")
        sql.putBuf("if exists( select 1 from sysoptions where sysoptionsid=@sysoptionsid)")
        sql.putBuf("update sysoptions set Name=@Name, Value=@Value, OptionType=@OptionType where sysoptionsid=@sysoptionsid")
        sql.putBuf("Else")
        sql.putBuf("insert into sysoptions (sysoptionsid, Name, Value, OptionType)values(@sysoptionsid,@Name,@Value,@OptionType)")
        sql.putBuf("End")
        sql.putBuf("go")
        sql.putBuf("")


        sql.putBuf(procDropSQL("Instance_Save"))
        sql.putBuf("create proc Instance_Save (")
        sql.putBuf("@CURSESSION uniqueidentifier,")
        sql.putBuf("@InstanceID uniqueidentifier,")
        sql.putBuf("@ObjType varchar(255),")
        sql.putBuf("@Name varchar(255)")
        sql.putBuf(") as")
        sql.putBuf("begin")
        sql.putBuf(" declare @tmpStr varchar(255)")
        sql.putBuf(" declare @SSID uniqueidentifier")
        sql.putBuf(" declare @tmpID uniqueidentifier")
        sql.putBuf(" declare @SysLogID uniqueidentifier")
        sql.putBuf(" declare @access integer")
        sql.putBuf(" declare @SysInstID uniqueidentifier")
        sql.putBuf(" declare @StatusID uniqueidentifier")
        sql.putBuf(" select @SysInstID =Instanceid from instance where objtype='MTZSYSTEM'")


        sql.putBuf("if exists( select 1 from instance where instanceid=@instanceid )")
        sql.putBuf("  begin")
        sql.putBuf("   select  @tmpID =SecurityStyleID from INSTANCE where INSTANCEid=@INSTANCEid")
        sql.putBuf("   exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='EDIT',@access=@access out ")
        sql.putBuf("   if @access=0 ")
        sql.putBuf("   begin")
        sql.putBuf("    raiserror('Нет прав на изменение названия объекта.',16,1)")
        sql.putBuf("    if @@trancount>0 rollback tran")
        sql.putBuf("    return")
        sql.putBuf("   end")

        sql.putBuf("   exec instance_ISLOCKED @cursession=@cursession,@ROWID=@instanceid,@IsLocked=@access out ")
        sql.putBuf("   if @access>2 ")
        sql.putBuf("   begin")
        sql.putBuf("     raiserror('Документ заблокирован другим пльзователем.',16,1)")
        sql.putBuf("     if @@trancount>0 rollback tran")
        sql.putBuf("     return")
        sql.putBuf("   end")

        sql.putBuf("   select @ObjType=objtype from instance  where  instanceid=@instanceid")
        sql.putBuf("   update instance set name = @name where  instanceid=@instanceid")
        sql.putBuf("   set @SysLogid=newid()")
        sql.putBuf("   EXEC SysLog_SAVE @CURSESSION=@cursession ,@TheSession=@cursession, @InstanceID=@SysInstID, @SysLogid=@SysLogid, @LogStructID = @OBJTYPE ,")
        sql.putBuf("   @VERB='EDIT',  @the_Resource=@InstanceID,@LogInstanceID=@InstanceID")



        sql.putBuf("  End")
        sql.putBuf("Else")
        sql.putBuf("  begin")
        sql.putBuf("    if exists( select 1 from typelist where name = @objtype)")
        sql.putBuf("    begin")
        sql.putBuf("      begin tran")
        sql.putBuf("      select @SSID=SecurityStyleid,@tmpstr =RegisterProc from typelist where name = @objtype")
        sql.putBuf("      exec CheckVerbRight @cursession=@cursession,@Resource=@SSID,@verb='CREATE',@access=@access out ")
        sql.putBuf("      if @access=0 ")
        sql.putBuf("      begin")
        sql.putBuf("       raiserror('Нет прав на создание.',16,1)")
        sql.putBuf("       if @@trancount>0 rollback tran")
        sql.putBuf("       return")
        sql.putBuf("      end")
        sql.putBuf("      set @statusid=null")
        sql.putBuf("      select @statusid=objstatusid from objstatus join objecttype on")
        sql.putBuf("      objecttype.objecttypeid=objstatus.parentstructrowid and objecttype.name=@objtype and isStartup<>0")
        sql.putBuf("      if not @statusid is null")
        sql.putBuf("        insert into instance(instanceid,name,objtype,SecurityStyleID,STATUS) values(@instanceid,@name,@objtype,@SSID,@STATUSID)")
        sql.putBuf("      else ")
        sql.putBuf("        insert into instance(instanceid,name,objtype,SecurityStyleID) values(@instanceid,@name,@objtype,@SSID)")
        sql.putBuf("      if not @tmpstr is null")
        sql.putBuf("        exec @tmpstr @cursession = @cursession, @instanceid =@instanceid")
        sql.putBuf("         set @SysLogid=newid()")
        sql.putBuf("         EXEC SysLog_SAVE @CURSESSION=@cursession ,@TheSession=@cursession, @InstanceID=@SysInstID, @SysLogid=@SysLogid, @LogStructID = @OBJTYPE ,")
        sql.putBuf("         @VERB='CREATE',  @the_Resource=@InstanceID,@LogInstanceID=@InstanceID")
        sql.putBuf("      if @@trancount >0 commit tran")
        sql.putBuf("    End")
        sql.putBuf("  End")
        sql.putBuf("End")
        sql.putBuf("go")

        sql.putBuf(procDropSQL("Instance_DELETE"))
        sql.putBuf("create proc Instance_DELETE (")
        sql.putBuf("@CURSESSION uniqueidentifier,")
        sql.putBuf("@InstanceID uniqueidentifier")
        sql.putBuf(") as")
        sql.putBuf("begin")

        sql.putBuf("  declare @tmpStr varchar(255)")
        sql.putBuf("  declare @Str Nvarchar(4000)")
        sql.putBuf("  declare @ObjType varchar(255)")
        sql.putBuf(" declare @SysInstID uniqueidentifier")
        sql.putBuf(" select @SysInstID =Instanceid from instance where objtype='MTZSYSTEM'")
        sql.putBuf("  if exists( select 1 from instance where instanceid=@instanceid )")
        sql.putBuf("      begin")
        sql.putBuf("   declare @tmpID uniqueidentifier")
        sql.putBuf("   declare @access integer")
        sql.putBuf("   declare @OwnerPartName varchar(255)")
        sql.putBuf("   declare @OwnerRowID uniqueidentifier")
        sql.putBuf("   declare @SysLogid uniqueidentifier")
        sql.putBuf("   select  @tmpID =SecurityStyleID,@OwnerPartName = OwnerPartName,@OwnerRowID =OWnerRowID from INSTANCE where INSTANCEid=@INSTANCEid")
        sql.putBuf("   exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='DELETE',@access=@access out")
        sql.putBuf("   if @access=0")
        sql.putBuf("    begin")
        sql.putBuf("      raiserror('Нет прав на удаление.',16,1)")
        sql.putBuf("      if @@trancount>0 rollback tran")
        sql.putBuf("      Return")
        sql.putBuf("    End")
        sql.putBuf("       if @Ownerpartname is null or @OwnerRowID is null begin")
        sql.putBuf("        select @objtype = objtype from instance where instanceid=@instanceid")
        sql.putBuf("        select @tmpstr =DeleteProc from typelist where name = @objtype")
        sql.putBuf("        begin tran")

        sql.putBuf("        if not @tmpstr is null")
        sql.putBuf("          exec @tmpstr @cursession = @cursession, @instanceid =@instanceid")
        sql.putBuf("        if @@trancount =0 return")
        sql.putBuf("        delete from instance where instanceid=@instanceid")
        sql.putBuf("        set @SysLogid=newid()")
        sql.putBuf("        EXEC SysLog_SAVE @CURSESSION=@cursession ,@TheSession=@cursession, @InstanceID=@SysInstID, @SysLogid=@SysLogid, @LogStructID = @objtype ,")
        sql.putBuf("        @VERB='DELETE',  @the_Resource=@InstanceID,@LogInstanceID=@InstanceID")
        sql.putBuf("        if @@trancount >0 commit tran")
        sql.putBuf("")
        sql.putBuf("        end else begin")
        sql.putBuf("        -- Owner exists")
        sql.putBuf("")
        sql.putBuf("         set @str =N'select @tmpid='+@ownerpartname +'id from ' + @ownerpartname + ' where ' + @ownerpartname +'id=@ownerrowid'")
        sql.putBuf("         exec sp_executesql @str,N'@tmpid uniqueidentifier out, @ownerRowID uniqueidentifier',@tmpid=@tmpid out,@ownerrowid=@ownerrowid")
        sql.putBuf("         if @tmpid=@ownerrowid begin")
        sql.putBuf("        raiserror('Этот документ принадлежит другому документу и не может быть удален отдельно.',16,1)")
        sql.putBuf("        if @@trancount>0 rollback tran")
        sql.putBuf("        Return")
        sql.putBuf("         End")
        sql.putBuf("         select @objtype = objtype from instance where instanceid=@instanceid")
        sql.putBuf("         select @tmpstr =DeleteProc from typelist where name = @objtype")
        sql.putBuf("         begin tran")
        sql.putBuf("         if not @tmpstr is null")
        sql.putBuf("           exec @tmpstr @cursession = @cursession, @instanceid =@instanceid")
        sql.putBuf("         if @@trancount =0 return")
        sql.putBuf("         delete from instance where instanceid=@instanceid")


        sql.putBuf("         set @SysLogid=newid()")
        sql.putBuf("         EXEC SysLog_SAVE @CURSESSION=@cursession ,@TheSession=@cursession, @InstanceID=@SysInstID, @SysLogid=@SysLogid, @LogStructID = @objtype ,")
        sql.putBuf("         @VERB='DELETE',  @the_Resource=@InstanceID,@LogInstanceID=@InstanceID")


        sql.putBuf("         if @@trancount >0 commit tran")
        sql.putBuf("        End")
        sql.putBuf("     End")

        '  sql.putbuf "declare @tmpStr varchar(255)"
        '  sql.putbuf "declare @ObjType varchar(255)"
        '  sql.putbuf "if exists( select 1 from instance where instanceid=@instanceid )"
        '  sql.putbuf "    begin"
        '  sql.putbuf " declare @tmpID uniqueidentifier"
        '  sql.putbuf " declare @access integer"
        '  sql.putbuf " select  @tmpID =SecurityStyleID from INSTANCE where INSTANCEid=@INSTANCEid"
        '  sql.putbuf " exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='DELETE',@access=@access out "
        '  sql.putbuf " if @access=0 "
        '  sql.putbuf "  begin"
        '  sql.putbuf "    raiserror('Нет прав на удаление.',16,1)"
        '  sql.putbuf "    if @@trancount>0 rollback tran"
        '  sql.putbuf "    return"
        '  sql.putbuf "  end"
        '  sql.putbuf "      select @objtype = objtype from instance where instanceid=@instanceid"
        '  sql.putbuf "      select @tmpstr =DeleteProc from typelist where name = @objtype"
        '  sql.putbuf "      begin tran"
        '  sql.putbuf "      if not @tmpstr is null"
        '  sql.putbuf "        exec @tmpstr @cursession = @cursession, @instanceid =@instanceid"
        '  sql.putbuf "      if @@trancount =0 return"
        '  sql.putbuf "      delete from instance where instanceid=@instanceid"
        '  sql.putbuf "      if @@trancount >0 commit tran"
        '  sql.putbuf "    End"

        sql.putBuf("End")
        sql.putBuf("go")

        sql.putBuf(procDropSQL("Instance_HCL"))
        sql.putBuf("create proc Instance_HCL (")
        sql.putBuf("@CURSESSION uniqueidentifier,")
        sql.putBuf("@RowID uniqueidentifier,")
        sql.putBuf("@IsLocked int out")
        sql.putBuf(") as")
        sql.putBuf("begin")
        sql.putBuf("declare @tmpStr varchar(255)")
        sql.putBuf("declare @ObjType varchar(255)")
        sql.putBuf("if exists( select 1 from instance where instanceid=@rowid )")
        sql.putBuf("    begin")
        sql.putBuf("      select @objtype = objtype from instance where instanceid=@rowid")
        sql.putBuf("      select @tmpstr =HCLProc from typelist where name = @objtype")
        sql.putBuf("      if not @tmpstr is null")
        sql.putBuf("        exec @tmpstr @cursession = @cursession, @ROWid =@rowid,@IsLocked=@IsLocked out")
        sql.putBuf("    End")
        sql.putBuf("End")
        sql.putBuf("go")


        sql.putBuf(procDropSQL("Instance_propagate"))
        sql.putBuf("create proc Instance_propagate (")
        sql.putBuf("@CURSESSION uniqueidentifier,")
        sql.putBuf("@RowID uniqueidentifier")
        sql.putBuf(") as")
        sql.putBuf("begin")
        sql.putBuf("declare @tmpStr varchar(255)")
        sql.putBuf("declare @ObjType varchar(255)")
        sql.putBuf("if exists( select 1 from instance where instanceid=@rowid )")
        sql.putBuf("    begin")
        sql.putBuf("      select @objtype = objtype from instance where instanceid=@rowid")
        sql.putBuf("      select @tmpstr =propagateProc from typelist where name = @objtype")
        sql.putBuf("      if not @tmpstr is null")
        sql.putBuf("        exec @tmpstr @cursession = @cursession, @ROWid =@rowid")
        sql.putBuf("    End")
        sql.putBuf("End")
        sql.putBuf("go")


        sql.putBuf(procDropSQL("INSTANCE_ISLOCKED"))
        sql.putBuf(" create  proc INSTANCE_ISLOCKED (")
        sql.putBuf(" @CURSESSION uniqueidentifier,")
        sql.putBuf(" @RowID uniqueidentifier ,")
        sql.putBuf(" @IsLocked integer output")
        sql.putBuf(") as  begin")
        sql.putBuf("set nocount on")
        sql.putBuf(" declare @UserID uniqueidentifier")
        sql.putBuf(" declare @LockUserID uniqueidentifier")
        sql.putBuf(" declare @LockSessionID uniqueidentifier")
        sql.putBuf(" set @isLocked = 0")
        sql.putBuf(" -- checking session  --")
        sql.putBuf("if not exists( select 1 from the_session where the_sessionid=@cursession and closed=0 )")
        sql.putBuf("  begin")
        sql.putBuf("    raiserror('Сессия уже завершена',16,1)")
        sql.putBuf("    Return")
        sql.putBuf("  End")
        sql.putBuf(" select @userID = usersid  from the_session where the_sessionid=@cursession")
        sql.putBuf(" select @LockUserID = LockUserID,@LockSessionID = LockSessionID from INSTANCE where INSTANCEid=@RowID")
        sql.putBuf(" /* verify this row */")
        sql.putBuf(" if not @LockUserID is null")
        sql.putBuf(" begin")
        sql.putBuf("   if  @LockUserID <> @userID")
        sql.putBuf("   begin")
        sql.putBuf("     set @isLocked = 4 /* CheckOut by another user */")
        sql.putBuf("     Return")
        sql.putBuf("   end   else")
        sql.putBuf("   begin")
        sql.putBuf("     set @isLocked = 2 /* CheckOut by caller */")
        sql.putBuf("     Return")
        sql.putBuf("   End")
        sql.putBuf(" End")
        sql.putBuf(" if not @LockSessionID is null")
        sql.putBuf(" begin")
        sql.putBuf("   if  @LockSessionID <> @CURSESSION")
        sql.putBuf("   begin")
        sql.putBuf("     set @isLocked = 3 /* Lockes by another user */")
        sql.putBuf("     Return")
        sql.putBuf("   end   else")
        sql.putBuf("   begin")
        sql.putBuf("     set @isLocked = 1 /* Locked by caller */")
        sql.putBuf("     Return")
        sql.putBuf("   End")
        sql.putBuf(" End")
        sql.putBuf(" set @isLocked = 0")
        sql.putBuf(" End")
        sql.putBuf("GO")


        sql.putBuf(procDropSQL("INSTANCE_SINIT"))
        sql.putBuf("create  proc Instance_SINIT  (")
        sql.putBuf("@CURSESSION uniqueidentifier,")
        sql.putBuf("@RowID uniqueidentifier ,")
        sql.putBuf(" @SecurityStyleID uniqueidentifier=null")
        sql.putBuf(")as  begin")
        sql.putBuf(" set nocount on")
        sql.putBuf(" declare @ParentTable varchar(255)")
        sql.putBuf(" declare @StyleID uniqueidentifier")

        sql.putBuf(" declare @tmpID uniqueidentifier")
        sql.putBuf(" declare @access integer")
        sql.putBuf(" select  @tmpID =SecurityStyleID from INSTANCE where INSTANCEid=@ROWID")
        sql.putBuf(" exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='SECURE',@access=@access out ")
        sql.putBuf(" if @access=0 ")
        sql.putBuf("  begin")
        sql.putBuf("    raiserror('Нет прав на управление защитой.',16,1)")
        sql.putBuf("    if @@trancount>0 rollback tran")
        sql.putBuf("    return")
        sql.putBuf("  end")

        sql.putBuf("  if @SecurityStyleID is null begin")
        sql.putBuf("    select @ParentTable = objtype from instance where instanceid=@RowID")
        sql.putBuf("    select @StyleID =SecurityStyleID from typelist where name =@ParentTable")
        sql.putBuf("    update Instance set securitystyleid =@StyleID where Instanceid = @RowID")
        sql.putBuf("  end else begin")
        sql.putBuf("    update Instance set securitystyleid =@SecurityStyleID where Instanceid = @RowID")
        sql.putBuf("  End")
        sql.putBuf("End")
        sql.putBuf("GO")

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        sql.putBuf(procDropSQL("Instance_LOCK"))
        sql.putBuf("create  proc Instance_LOCK  (")
        sql.putBuf(" @CURSESSION uniqueidentifier,")
        sql.putBuf(" @RowID uniqueidentifier ,")
        sql.putBuf(" @LockMode integer")
        sql.putBuf(") as  begin")
        sql.putBuf("set nocount on")
        sql.putBuf(" declare @UserID uniqueidentifier")
        sql.putBuf(" declare @tmpID uniqueidentifier")
        sql.putBuf(" declare @access integer")
        sql.putBuf(" declare @IsLocked integer")
        sql.putBuf(" -- checking session  --")
        sql.putBuf("if not exists( select 1 from the_session where the_sessionid=@cursession and closed=0 )")
        sql.putBuf("  begin")
        sql.putBuf("    raiserror('Сессия уже завершена.',16,1)")
        sql.putBuf("    Return")
        sql.putBuf("  End")
        sql.putBuf(" select @userID = usersid  from the_session where the_sessionid=@cursession")
        sql.putBuf(" exec Instance_ISLOCKED @CURSESSION,@ROWID,@ISLocked out")
        sql.putBuf(" if @IsLocked >=3")
        sql.putBuf("  begin")
        sql.putBuf("    raiserror('Объект заблокирован другим пользователем',16,1)")
        sql.putBuf("    Return")
        sql.putBuf("  End")
        sql.putBuf(" if @IsLocked =0")
        sql.putBuf(" begin")
        sql.putBuf("  exec Instance_HCL @cursession,@RowID,@isLocked out")
        sql.putBuf("  if @IsLocked >=3")
        sql.putBuf("   begin")
        sql.putBuf("     raiserror('У данного объекта имеются дочерние строки, которые заблокированы другим пользователем',16,1)")
        sql.putBuf("     Return")
        sql.putBuf("   End")
        sql.putBuf(" End")

        sql.putBuf(" select  @tmpID =SecurityStyleID from INSTANCE where INSTANCEid=@ROWID")
        sql.putBuf(" exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='LOCKINSTANCE',@access=@access out ")
        sql.putBuf(" if @access=0 ")
        sql.putBuf("  begin")
        sql.putBuf("    raiserror('Нет прав на блокировку объекта.',16,1)")
        sql.putBuf("    if @@trancount>0 rollback tran")
        sql.putBuf("    return")
        sql.putBuf("  end")

        sql.putBuf("   if  @LockMode =2")
        sql.putBuf("   begin")
        sql.putBuf("    update INSTANCE  set LockUserID =@userID ,LockSessionID =null where Instanceid=@RowID")
        sql.putBuf("     Return")
        sql.putBuf("   End")
        sql.putBuf("   if  @LockMode =1")
        sql.putBuf("   begin")
        sql.putBuf("    update INSTANCE  set LockUserID =null,LockSessionID =@CURSESSION  where Instanceid=@RowID")
        sql.putBuf("     Return")
        sql.putBuf("   End")
        sql.putBuf(" End")
        sql.putBuf("")
        sql.putBuf("GO")


        sql.putBuf(procDropSQL("Instance_UNLOCK"))
        sql.putBuf("create  proc Instance_UNLOCK /*Пользователи системы*/ (")
        sql.putBuf(" @CURSESSION uniqueidentifier,")
        sql.putBuf(" @RowID uniqueidentifier")
        sql.putBuf(") as  begin")
        sql.putBuf("set nocount on")
        sql.putBuf(" declare @ParentID uniqueidentifier")
        sql.putBuf(" declare @UserID uniqueidentifier")
        sql.putBuf(" declare @IsLocked integer")
        sql.putBuf(" declare @ParentTable varchar(255)")
        sql.putBuf(" -- checking session  --")
        sql.putBuf("if not exists( select 1 from the_session where the_sessionid=@cursession and closed=0 )")
        sql.putBuf("  begin")
        sql.putBuf("    raiserror('Сессия уже завершена.',16,1)")
        sql.putBuf("    Return")
        sql.putBuf("  End")
        sql.putBuf(" exec Instance_ISLOCKED @CURSESSION,@ROWID,@ISLocked out")
        sql.putBuf(" if @IsLocked >=3")
        sql.putBuf("  begin")
        sql.putBuf("    raiserror('Объект заблокирован другим пользователем',16,1)")
        sql.putBuf("    Return")
        sql.putBuf("  End")
        sql.putBuf("   if  @IsLocked =2")
        sql.putBuf("   begin")
        sql.putBuf("    update INSTANCE set LockUserID =null  where Instanceid=@RowID")
        sql.putBuf("     Return")
        sql.putBuf("   End")
        sql.putBuf("   if  @IsLocked =1")
        sql.putBuf("   begin")
        sql.putBuf("    update INSTANCE set LockSessionID =null  where Instanceid=@RowID")
        sql.putBuf("     Return")
        sql.putBuf("   End")
        sql.putBuf(" End")
        sql.putBuf("")
        sql.putBuf("GO")

        sql.putBuf(procDropSQL("instance_BRIEF"))
        sql.putBuf("  create proc instance_BRIEF  (")
        sql.putBuf(" @CURSESSION uniqueidentifier,")
        sql.putBuf(" @instanceid uniqueidentifier,")
        sql.putBuf(" @BRIEF varchar(4000) output")
        sql.putBuf(") as  begin")
        sql.putBuf("set nocount on")
        sql.putBuf(" declare @tmpStr varchar(255)")
        sql.putBuf(" declare @access int")
        sql.putBuf(" declare @tmpBrief varchar(4000)")
        sql.putBuf(" declare @tmpID uniqueidentifier")
        sql.putBuf(" -- checking session  --")
        sql.putBuf("if not exists( select 1 from the_session where the_sessionid=@cursession and closed=0 )")
        sql.putBuf("  begin")
        sql.putBuf("    raiserror('Сессия уже завершена.',16,1)")
        sql.putBuf("    Return")
        sql.putBuf("  End")
        sql.putBuf("if @instanceid is null begin set @BRIEF='' return end")
        sql.putBuf(" -- Brief body --")
        sql.putBuf("if exists(select 1 from instance where instanceID=@instanceID)")
        sql.putBuf(" begin")
        sql.putBuf(" --  verify access  --")

        sql.putBuf(" select  @tmpID =SecurityStyleID from instance where instanceid=@instanceID")
        sql.putBuf(" exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='BRIEF',@access=@access out")
        sql.putBuf(" if @access=0")
        sql.putBuf("  begin")
        sql.putBuf("    raiserror('Нет прав на получение краткого наименования. Раздел=instance',16,1)")
        sql.putBuf("    Return")
        sql.putBuf("  End ")
        sql.putBuf("  set @BRIEF=''")
        sql.putBuf("  select @BRIEF= @BRIEF ")
        sql.putBuf("  +  isnull(Name,' ')+'; '")
        sql.putBuf("  from instance  where  instanceID = @instanceID")
        '  sql.putBuf "  set @BRIEF= @BRIEF + 'Тип='"
        sql.putBuf("  select @BRIEF= @BRIEF ")
        sql.putBuf("  +  isnull(objtype,' ')+'; '")
        sql.putBuf("  from instance  where  instanceID = @instanceID")
        sql.putBuf("end else begin")
        sql.putBuf("  set @BRIEF= 'неверный идентификатор'")
        sql.putBuf("End")
        sql.putBuf("set @BRIEF=left(@BRIEF,4000)")
        sql.putBuf("End")
        sql.putBuf("")
        sql.putBuf("GO")

        sql.putBuf(procDropSQL("QR_and_QR"))
        sql.putBuf("create proc QR_and_QR( @id1 uniqueidentifier, @id2 uniqueidentifier,@idout uniqueidentifier,@cnt integer out)")
        sql.putBuf("as")
        sql.putBuf("delete from QueryResult where QueryResultid=@idout")
        sql.putBuf("insert into QueryResult(QueryResultid,result)")
        sql.putBuf("select distinct @idout, a.result")
        sql.putBuf("from QueryResult a")
        sql.putBuf("join QueryResult b on b.QueryResultid=@id2 and a.result=b.result")
        sql.putBuf("where a.QueryResultid=@id1")
        sql.putBuf("select @cnt=count(*) from QueryResult where QueryResultid=@idout")
        sql.putBuf("go")
        sql.putBuf("")


        sql.putBuf(procDropSQL("QR_or_QR"))
        sql.putBuf("create proc QR_or_QR( @id1 uniqueidentifier, @id2 uniqueidentifier,@idout uniqueidentifier,@cnt integer out)")
        sql.putBuf("as")
        sql.putBuf("delete from QueryResult where QueryResultid=@idout")
        sql.putBuf("insert into QueryResult(QueryResultid,result)")
        sql.putBuf("select distinct @idout, result from QueryResult where QueryResultid in (@id1,@id2)")
        sql.putBuf("select @cnt=count(*) from QueryResult where QueryResultid=@idout")
        sql.putBuf("GO")

        sql.putBuf(procDropSQL("RowParents"))
        sql.putBuf("create  proc RowParents")
        sql.putBuf("(@QueryID uniqueidentifier")
        sql.putBuf(",@RowID uniqueidentifier/* Row */")
        sql.putBuf(",@Table VARCHAR (255)/* Part Table Name */")
        sql.putBuf(",@CURSESSION uniqueidentifier/* Session */")
        sql.putBuf(")")
        sql.putBuf(" as")
        sql.putBuf("begin")
        sql.putBuf("set nocount on")
        sql.putBuf("declare @plevel integer")
        sql.putBuf("declare @parent varchar(255)")
        sql.putBuf("declare @prev varchar(255)")
        sql.putBuf("declare @tmpID  uniqueidentifier")
        sql.putBuf("declare @tmpRowID  uniqueidentifier")
        sql.putBuf("declare @s nvarchar(4000)")
        sql.putBuf(" -- checking session  --")
        sql.putBuf("if not exists( select 1 from the_session where the_sessionid=@cursession and closed=0 )")
        sql.putBuf("  begin")
        sql.putBuf("    raiserror('Session expired',16,1)")
        sql.putBuf("    if @@trancount>0 rollback tran")
        sql.putBuf("    Return")
        sql.putBuf("  End")
        sql.putBuf("set @parent =@table")
        sql.putBuf("set @tmpID = @ROWID")
        sql.putBuf("set @plevel =0")
        sql.putBuf("delete from RPRESULT where RPRESULTID")
        sql.putBuf("  =@QUERYID")
        sql.putBuf("insert into RPRESULT(RPRESULTID,PARENTLEVEL,PARTNAME,ROWID)")
        sql.putBuf("   values(@QUERYID,@PLEVEL,@table,@RowID)")
        sql.putBuf("")
        sql.putBuf("again:")
        sql.putBuf("set @plevel =@plevel + 1")
        sql.putBuf("set @prev = @parent")
        sql.putBuf("set @parent = null")
        sql.putBuf("select @parent =value from sysoptions where optiontype ='parent' and  name=@prev")
        sql.putBuf("")
        sql.putBuf(" if @parent is null")
        sql.putBuf(" begin")
        sql.putBuf("    set @s = N'select @root=InstanceID from ' + @prev + N' where ' +@prev + N'id=@id'")
        sql.putBuf("    exec sp_executesql @s,N'@root uniqueidentifier out,@id uniqueidentifier',@tmpRowID out,@tmpid")
        sql.putBuf("")
        sql.putBuf("   insert into RPRESULT(RPRESULTID,PARENTLEVEL,PARTNAME,ROWID)")
        sql.putBuf("   values(@QUERYID,@PLEVEL,'INSTANCE',@tmpRowID)")
        sql.putBuf(" End")
        sql.putBuf(" Else")
        sql.putBuf(" begin")
        sql.putBuf("    set @s = N'select @parent=ParentStructRowID from ' + @prev+ ' where ' +@prev + 'id=@id'")
        sql.putBuf("    exec sp_executesql @s,N'@parent uniqueidentifier out,@id uniqueidentifier',@tmpRowID out,@tmpid")
        sql.putBuf("    set @tmpID = @tmpROWID")
        sql.putBuf("   insert into RPRESULT(RPRESULTID,PARENTLEVEL,PARTNAME,ROWID)")
        sql.putBuf("   values(@QUERYID,@PLEVEL,@parent,@tmpRowID)")
        sql.putBuf("    GoTo again")
        sql.putBuf(" End")
        sql.putBuf("End")
        sql.putBuf("GO")

        sql.putBuf(procDropSQL("Instance_Status"))
        sql.putBuf("  create proc Instance_Status(")
        sql.putBuf("  @cursession uniqueidentifier,")
        sql.putBuf("  @instanceid uniqueidentifier,")
        sql.putBuf("  @statusid uniqueidentifier)")
        sql.putBuf("as")
        sql.putBuf("begin")
        sql.putBuf("   declare @SSID uniqueidentifier")
        sql.putBuf("   declare @tmpID uniqueidentifier")
        sql.putBuf("   declare @SysLogID uniqueidentifier")
        sql.putBuf("   declare @access integer")
        sql.putBuf("   declare @SysInstID uniqueidentifier")
        sql.putBuf("   declare @ObjType varchar(255)")
        sql.putBuf("   select @SysInstID =Instanceid from instance where objtype='MTZSYSTEM'")
        sql.putBuf("")
        sql.putBuf(" if exists( select 1 from instance where instanceid=@instanceid )")
        sql.putBuf("  begin")
        sql.putBuf("   select  @tmpID =SecurityStyleID from INSTANCE where INSTANCEid=@INSTANCEid")
        sql.putBuf("   exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='STATUS',@access=@access out")
        sql.putBuf("   if @access=0")
        sql.putBuf("   begin")
        sql.putBuf("    raiserror('Нет прав на изменение состояния объекта.',16,1)")
        sql.putBuf("    if @@trancount>0 rollback tran")
        sql.putBuf("    Return")
        sql.putBuf("   End")
        sql.putBuf("   exec instance_ISLOCKED @cursession=@cursession,@ROWID=@instanceid,@IsLocked=@access out")
        sql.putBuf("   if @access>2")
        sql.putBuf("   begin")
        sql.putBuf("     raiserror('Документ заблокирован другим пльзователем.',16,1)")
        sql.putBuf("     if @@trancount>0 rollback tran")
        sql.putBuf("     Return")
        sql.putBuf("   End")
        sql.putBuf("   select @ObjType=objtype from instance  where  instanceid=@instanceid")
        sql.putBuf("   if exists(")
        sql.putBuf("  select 1 from objstatus")
        sql.putBuf("  join objecttype on objstatus.parentstructrowid=objecttype.objecttypeid")
        sql.putBuf("  where objecttype.name=@objtype and objstatusid=@statusid")
        sql.putBuf("   )begin")
        sql.putBuf("     begin tran")
        sql.putBuf("     update instance set status = @statusid where  instanceid=@instanceid")
        sql.putBuf("     set @SysLogid=newid()")
        sql.putBuf("     EXEC SysLog_SAVE @CURSESSION=@cursession ,@TheSession=@cursession, @InstanceID=@SysInstID, @SysLogid=@SysLogid, @LogStructID = @STATUSID ,")
        sql.putBuf("     @VERB='STATUS',  @the_Resource=@InstanceID,@LogInstanceID=@InstanceID")
        sql.putBuf("     commit tran")
        sql.putBuf("   End")
        sql.putBuf(" End")
        sql.putBuf("End")
        sql.putBuf("GO")

        sql.putBuf(viewDropSQL("v_INSTANCE"))
        sql.putBuf("create view v_INSTANCE as")
        sql.putBuf("select instance.*,objstatus.name statusname,objstatus.IsArchive")
        sql.putBuf("from instance left join objstatus on instance.status=objstatus.objstatusid")
        sql.putBuf("GO")


        o.ModuleName = "--Kernel procs"
        o.Block = "--body"
        o.OutNL(sql.getBuf)

        'UPGRADE_NOTE: Object sql may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        sql = Nothing

        Debug.Print("SQLGEN.KERNEL:done")
        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        Debug.Print("SQLGEN.KERNEL:" & Err.Description)
        'Resume
        'Stop
        'UPGRADE_NOTE: Object sql may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        sql = Nothing
    End Sub


    Public Function Run(ByRef Model As Object, ByRef Output As Object, ByRef targetid As String) As String
        m = Model
        o = Output
        tid = targetid
        log = ""
        Debug.Print("SQLGEN.Run:start")

        'read settings
        OptFullText = My.Settings.FULLTEXT
        OptInit = My.Settings.INIT
        OptKernel = My.Settings.KERNEL
        OptMethod = My.Settings.METHODS
        OptProcs = My.Settings.PROCS
        OptTables = My.Settings.TABLES
        OptViews = My.Settings.VIEW
        OptMaintein = My.Settings.MAINTEIN
        OptManual = My.Settings.MANUAL



        o.ModuleName = "--FullTextClean"
        o.Block = "--clean"
        o.OutNL(" ")

        o.ModuleName = "--Kernel tables"
        o.Block = "--body"
        o.OutNL(" ")

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

        o.ModuleName = "--Kernel procs"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--Procedures"
        o.Block = "--TableProc"
        o.OutNL(" ")

        o.ModuleName = "--FullText"
        o.Block = "--create"
        o.OutNL(" ")

        o.ModuleName = "--FullTextSearch"
        o.Block = "--body"
        o.OutNL(" ")


        o.ModuleName = "--Procedures"
        o.Block = "--Methods"
        o.OutNL(" ")

        o.ModuleName = "--Views--"
        o.Block = "--Views--"
        o.OutNL(" ")

        o.ModuleName = "--Procs"
        o.Block = "--body"
        o.OutNL(" ")


        o.ModuleName = "--ManualCode"
        o.Block = "--body"
        o.OutNL(" ")

        o.ModuleName = "--FullTextStart"
        o.Block = "--create"
        o.OutNL(" ")

        o.ModuleName = "--Maintains"
        o.Block = "--create"
        o.OutNL(" ")


        o.ModuleName = "--Options"
        o.Block = "--Load"
        o.OutNL(" ")

        ' clean full text catalog first
        o.ModuleName = "--FullTextClean"
        o.Block = "--clean"
        If OptFullText Then o.OutNL(FullTextClean)

        Debug.Print("SQLGEN.Run:Kernel")

        If OptKernel Then Kernel()


        Dim j, i, k As Integer
        Dim os As MTZMetaModel.MTZMetaModel.PART

        On Error GoTo bye
        Debug.Print("SQLGEN.Run:Types")
        For i = 1 To m.OBJECTTYPE.Count
            Debug.Print("SQLGEN.Run:Type " & m.OBJECTTYPE.Item(i).the_Comment)
            log = log & vbCrLf & "Create code for type " & m.OBJECTTYPE.Item(i).Name
            o.ModuleName = "--Tables"
            o.Block = "--body"
            o.OutNL("/* TYPE=" & m.OBJECTTYPE.Item(i).Name & " (" & m.OBJECTTYPE.Item(i).the_Comment & ") */")
            o.OutNL("GO")


            For j = 1 To m.OBJECTTYPE.Item(i).PART.Count

                os = m.OBJECTTYPE.Item(i).PART.Item(j)
                Debug.Print("SQLGEN.Run:Type " & m.OBJECTTYPE.Item(i).the_Comment & " Part:" & os.Caption)
                If OptTables Then CreateStruct(os)

                If OptFullText Then FullTextTable(os)
#If TRIAL = 1 Then
                If Today < DateSerial(2007, 2, 1) Then
                    If OptProcs Then CreateProc(os)
                    If OptProcs Then CreateV2Proc(os)
                    If OptViews Then MakeAllViews(os)
                End If
#Else
                'UPGRADE_NOTE: #If #EndIf block was not upgraded because the expression Else did not evaluate to True or was not evaluated. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"'
                If OptProcs Then CreateProc(os)
                If OptProcs Then CreateV2Proc(os)
                If OptViews Then MakeAllViews(os)
#End If

            Next

#If TRIAL = 1 Then
            If Today < DateSerial(2007, 2, 1) Then
                If OptProcs Then CreateTypeProcs(m.OBJECTTYPE.Item(i))
            End If
#Else
            'UPGRADE_NOTE: #If #EndIf block was not upgraded because the expression Else did not evaluate to True or was not evaluated. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="27EE2C3C-05AF-4C04-B2AF-657B4FB6B5FC"'
            If OptProcs Then CreateTypeProcs(m.OBJECTTYPE.Item(i))
#End If

            If OptFullText Then FullTextSearch(m.OBJECTTYPE.Item(i))
            o.Status(m.OBJECTTYPE.Item(i).the_Comment & " done", i)
        Next


        Debug.Print("SQLGEN.Run:Methods")
        For i = 1 To m.SHAREDMETHOD.Count
            If OptMethod Then CreateMethod(m.SHAREDMETHOD.Item(i))
        Next

        Dim targ As MTZMetaModel.MTZMetaModel.GENERATOR_TARGET
        Dim mc As MTZMetaModel.MTZMetaModel.GENMANUALCODE
        If OptManual Then

            Debug.Print("SQLGEN.Run:ManualCode")

            'ManualCode
            o.ModuleName = "--ManualCode"
            o.Block = "--body"

            targ = m.FindRowObject("GENERATOR_TARGET", New Guid(tid))
            For i = 1 To targ.GENMANUALCODE.Count
                mc = targ.GENMANUALCODE.Item(i)
                o.OutNL("/*" & mc.Name & " (" & mc.the_Alias & ")*/")
                o.OutNL(mc.Code)
                o.OutNL("GO")
            Next

        End If

        If OptMaintein Then
            Debug.Print("SQLGEN.Run:Maintains")
            o.ModuleName = "--Maintains"
            o.Block = "--create"
            o.OutNL(AutoCloseJob)
        End If


        Debug.Print("SQLGEN.Run:LoadOptions")
        If OptInit Then LoadOptions()

        o.ModuleName = "--FullTextStart"
        o.Block = "--create"
        If OptFullText And OptMaintein Then o.OutNL(FullTextStart)


        Run = log
        Debug.Print("SQLGEN.Run:done")
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'MsgBox Err.Description
        'Resume
        Debug.Print("SQLGEN.Run:" & Err.Description)
        Run = log

    End Function

    Private Sub FullTextTable(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        Debug.Print("SQLGEN.FullTextTable:start " & os.Caption)
        If os.PartType = 3 Then
            Debug.Print("SQLGEN.FullTextTable:skipped " & os.Caption)
            Exit Sub
        End If
        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i As Short
        Dim s As String
        Dim collist As String

        log = log & vbCrLf & "-->full text table " & os.Name

        On Error GoTo bye
        Dim hasFields As Boolean

        hasFields = False
        s = ""
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        If st.ManualRegister = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
            s = s & vbCrLf & "exec sp_fulltext_table '" & os.Name & "','Create', 'fulltext_catalog','pk_" & os.Name & "'"
            s = s & vbCrLf & "go"
            st.FIELD.Sort = "sequence"
            For i = 1 To st.FIELD.Count
                ft = st.FIELD.Item(i).FieldType
                If UCase(ft.Name) = "FILE" Then
                    s = s & vbCrLf & "exec sp_fulltext_column '" & os.Name & "','" & st.FIELD.Item(i).Name & "','add',1049, '" & st.FIELD.Item(i).Name & "_EXT'"
                    s = s & vbCrLf & "go"
                    hasFields = True
                Else
                    If ft.AllowLikeSearch Then
                        s = s & vbCrLf & "exec sp_fulltext_column '" & os.Name & "','" & st.FIELD.Item(i).Name & "','add',1049"
                        s = s & vbCrLf & "go"
                        hasFields = True
                    End If
                End If
            Next
        End If

        If hasFields Then
            o.ModuleName = "--FullText"
            o.Block = "--create"
            o.OutNL(s)
        End If

        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            If Not chos.PartType = 3 Then
                FullTextTable(chos)
            End If
        Next
        Debug.Print("SQLGEN.FullTextTable:done " & os.Caption)
        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        Debug.Print("SQLGEN.FullTextTable " & Err.Description)
        'Resume
    End Sub


    Private Sub CreateStruct(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        Debug.Print("SQLGEN.CreateStruct:start " & os.Caption)
        If os.PartType = 3 Then
            Debug.Print("SQLGEN.CreateStruct:skipped " & os.Caption)
            Exit Sub
        End If
        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        System.Windows.Forms.Application.DoEvents()
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i As Short
        Dim s As Writer
        s = New Writer
        Dim collist As String

        'Строка
        'Колекция
        'Дерево
        'Граф

        CheckPartMLF(st, log)

        log = log & vbCrLf & "-->CreateStruct " & os.Name


        On Error GoTo bye
        s.putBuf("/*" & os.Caption & "*/")

        s.putBuf("if not exists (select * from sysobjects where id = object_id(N'" & os.Name & "') and OBJECTPROPERTY(id, N'IsUserTable') = 1)")
        s.putBuf("BEGIN")
        s.putBuf("create table " & os.Name & "/*" & os.the_Comment & "*/ (")
        collist = ""
        'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s.putBuf("InstanceID uniqueidentifier ,")
            collist = collist & "'InstanceID'"
        Else
            s.putBuf("ParentStructRowID uniqueidentifier not null,")
            collist = collist & "'ParentStructRowID'"
        End If

        s.putBuf(os.Name & "id uniqueidentifier not null rowguidcol default ( newid())  ")
        collist = collist & ",'" & os.Name & "ID'"

        s.putBuf(",ChangeStamp datetime not null default ( getdate()) /* Время последнего изменения */")
        collist = collist & ",'ChangeStamp'"

        s.putBuf(",TimeStamp timestamp not null  /* для организации инкрементального индексирования полнотекстовой информации */")
        collist = collist & ",'TimeStamp'"


        s.putBuf(",LockSessionID uniqueidentifier null  /* temporary lock */")
        collist = collist & ",'LockSessionID'"
        s.putBuf(",LockUserID uniqueidentifier null /* checkout lock */")
        collist = collist & ",'LockUserID'"
        s.putBuf(",SecurityStyleID uniqueidentifier null /* security formula */")
        collist = collist & ",'SecurityStyleID'"



        ' дерево
        If os.PartType = 2 Then
            s.putBuf(",ParentRowid uniqueidentifier ")
            collist = collist & ",'ParentRowid'"
        End If

        s.putBuf(")")
        s.putBuf("END")
        s.putBuf("go")


        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            'If i > 1 Then

            's.putbuf ","
            s.putBuf("if  not exists(select * from syscolumns where name='" & st.FIELD.Item(i).Name & "' and id=object_id(N'" & st.Name & "'))")
            s.putBuf("alter table " & st.Name & " add ")
            s.putBuf(FieldForCreate(st.FIELD.Item(i)))

            'support extention field if file type used
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = st.FIELD.Item(i).FieldType
            If UCase(ft.Name) = "FILE" Then
                s.putBuf("if  not exists(select * from syscolumns where name='" & st.FIELD.Item(i).Name & "_EXT' and id=object_id(N'" & st.Name & "'))")
                s.putBuf("alter table " & st.Name & " add ")
                s.putBuf(" " & st.FIELD.Item(i).Name & "_EXT nvarchar(4) null")
                collist = collist & ",'" & st.FIELD.Item(i).Name & "_EXT'"
            End If

            collist = collist & ",'" & st.FIELD.Item(i).Name & "'"
            s.putBuf("go")
        Next

        s.putBuf(ColumnDropSQL((st.Name), collist))

        o.ModuleName = "--Tables"
        o.Block = "--body"
        o.OutNL(s.getBuf)

        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        s = New Writer
        s.putBuf(PkeyDropSQL((os.Name), "pk_" & os.Name))
        s.putBuf("alter table " & os.Name & " add constraint pk_" & os.Name & " primary key (" & os.Name & "ID)")
        o.ModuleName = "--Tables"
        o.Block = "--body"
        o.OutNL(s.getBuf)
        o.OutNL("GO")




        'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If TypeName(os.Parent.Parent) <> "OBJECTTYPE" Then
            'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            s = Nothing
            s = New Writer
            s.putBuf(keyDropSQL((os.Name), "fk_" & MakeName(os.ID.ToString())))
            'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            s.putBuf("alter table " & os.Name & " add constraint fk_" & MakeName(os.ID.ToString()) & " foreign key(ParentStructRowID) references " & os.Parent.Parent.Name & " (" & os.Parent.Parent.Name & "ID)")
            o.ModuleName = "--Tables"
            o.Block = "--ForeignKey"
            o.OutNL(s.getBuf)
            o.OutNL("GO")

            'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            s = Nothing
            s = New Writer
            s.putBuf(indexDropSQL((os.Name), "parent_" & os.Name))
            s.putBuf("create index parent_" & os.Name & " on " & os.Name & "(ParentStructRowID)")
            o.ModuleName = "--Tables"
            o.Block = "--Index"
            o.OutNL(s.getBuf)
            o.OutNL("GO")
        Else
            'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            s = Nothing
            s = New Writer
            s.putBuf(keyDropSQL((os.Name), "fk_" & MakeName(os.ID.ToString())))
            s.putBuf("alter table " & os.Name & " add constraint fk_" & MakeName(os.ID.ToString()) & " foreign key(INSTANCEID) references INSTANCE (INSTANCEID)")
            o.ModuleName = "--Tables"
            o.Block = "--ForeignKey"
            o.OutNL(s.getBuf)
            o.OutNL("GO")

            'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
            s = Nothing
            s = New Writer
            s.putBuf(indexDropSQL((os.Name), "parent_" & os.Name))
            s.putBuf("create index parent_" & os.Name & " on " & os.Name & "(INSTANCEID)")
            o.ModuleName = "--Tables"
            o.Block = "--Index"
            o.OutNL(s.getBuf)
            o.OutNL("GO")
        End If


        Debug.Print("SQLGEN.CreateStruct:children " & os.Caption)


        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            CreateStruct(chos)
        Next

        Debug.Print("SQLGEN.CreateStruct:done " & os.Caption)
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing

        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        Debug.Print("SQLGEN.CreateStruct: " & os.Caption & " " & Err.Description)
        'Resume
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing

    End Sub


    Private Sub CreateDelProc(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        Debug.Print("SQLGEN.CreateDelProc:start " & os.Caption)
        If os.PartType = 3 Then
            Debug.Print("SQLGEN.CreateDelProc:skipped " & os.Caption)
            Exit Sub
        End If

        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i As Short
        Dim s As Writer
        s = New Writer

        log = log & vbCrLf & "-->CreateDelProc " & os.Name

        On Error GoTo bye


        s.putBuf(procDropSQL(os.Name & "_DELETE"))
        s.putBuf("create proc " & os.Name & "_DELETE /*" & os.the_Comment & "*/ (")
        s.putBuf(" @CURSESSION uniqueidentifier,")
        s.putBuf(" @" & os.Name & "id uniqueidentifier,")
        s.putBuf(" @instanceid uniqueidentifier =null")

        s.putBuf(") as " & " begin  ")
        s.putBuf("set nocount on")
        'pmod'
        s.putBuf(" declare @Lang2 varchar(25)")
        'epmod'
        If Not os.NoLog Then s.putBuf(" declare @SysLogID uniqueidentifier")
        s.putBuf(" declare @access int")
        s.putBuf(" declare @SysInstID uniqueidentifier")
        s.putBuf(" declare @tmpID uniqueidentifier")
        s.putBuf(" select @SysInstID =Instanceid from instance where objtype='MTZSYSTEM'")


        s.putBuf(" -- checking session  --")
        s.putBuf("if not exists( select 1 from the_session where the_sessionid=@cursession and closed=0 )")
        s.putBuf("  begin")
        s.putBuf("    raiserror('Сессия уже завершена.',16,1)")
        s.putBuf("    if @@trancount>0 rollback tran")
        s.putBuf("    return")
        s.putBuf("  end")
        s.putBuf("select @Lang2=Lang from the_session where the_sessionid=@cursession")
        s.putBuf(" -- Delete body -- ")
        s.putBuf("if exists(select 1 from " & os.Name & " where " & os.Name & "ID=@" & os.Name & "ID)")
        s.putBuf(" begin")

        s.putBuf(" --  verify access  --")
        s.putBuf(" select  @tmpID =SecurityStyleID from " & os.Name & " where " & os.Name & "id=@" & os.Name & "ID")
        s.putBuf(" exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='DELETEROW',@access=@access out ")
        s.putBuf(" if @access=0 ")
        s.putBuf("  begin")

        s.putBuf("    exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='DELETEROW:" & os.Name & "',@access=@access out ")
        s.putBuf("    if @access=0 ")
        s.putBuf("    begin")
        s.putBuf("      raiserror('Нет прав на удаление. Раздел=" & os.Name & "',16,1)")
        s.putBuf("      if @@trancount>0 rollback tran")
        s.putBuf("      return")
        s.putBuf("    end")
        s.putBuf("  end")

        s.putBuf(" --  verify lock  --")
        s.putBuf(" exec " & os.Name & "_ISLOCKED @cursession=@cursession,@ROWID=@" & os.Name & "id,@IsLocked=@access out ")
        s.putBuf(" if @access>2 ")
        s.putBuf("  begin")
        s.putBuf("    raiserror('Строка заблокирована другим пользователем. Раздел=" & os.Name & "',16,1)")
        s.putBuf("    if @@trancount>0 rollback tran")
        s.putBuf("    return")
        s.putBuf("  end")


        s.putBuf("  begin tran  ")

        s.putBuf(" -- erase child items --")
        s.putBuf("declare @childlistid uniqueidentifier")



        If os.PART.Count > 0 Then
            s.putBuf("-- delete in-struct child")
        End If

        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            If Not chos.PartType = 3 Then
                s.putBuf("declare childlist_" & chos.Name & " cursor local for select " & chos.Name & "." & chos.Name & "id from " & chos.Name & " where  " & chos.Name & ".ParentStructRowID = @" & os.Name & "id")
                s.putBuf("open childlist_" & chos.Name & "")
                s.putBuf("fetch next from childlist_" & chos.Name & " into @childlistid")
                s.putBuf("while @@fetch_status >=0 ")
                s.putBuf("begin")
                s.putBuf(" exec " & chos.Name & "_DELETE @cursession,@childlistid,@instanceid")
                s.putBuf(" if @@error >0 begin")
                s.putBuf("   close childlist_" & chos.Name & "")
                s.putBuf("   deallocate childlist_" & chos.Name & " ")
                s.putBuf("   goto del_error")
                s.putBuf(" end")
                s.putBuf(" fetch next from childlist_" & chos.Name & " into @childlistid")
                s.putBuf("end")
                s.putBuf("close childlist_" & chos.Name & "")
                s.putBuf("deallocate childlist_" & chos.Name & " ")
            End If
        Next

        s.putBuf("")

        If Not os.NoLog Then
            s.putBuf("set @SysLogid=newid()")
            s.putBuf("EXEC SysLog_SAVE @CURSESSION=@cursession ,@TheSession=@cursession, @InstanceID=@SysInstID, @SysLogid=@SysLogid, @LogStructID = '" & os.Name & "',")
            s.putBuf(" @VERB='DELETEROW',  @the_Resource=@" & os.Name & "id, @LogInstanceID=@InstanceID")
        End If

        ' Удаляем зависимые документы!!!
        s.putBuf("declare child_inst_" & os.Name & " cursor local for select  instanceid from instance where OwnerPartName ='" & os.Name & "' and OwnerRowID=@" & os.Name & "id")
        s.putBuf("open child_inst_" & os.Name & "")
        s.putBuf("fetch next from child_inst_" & os.Name & " into @childlistid")
        s.putBuf("while @@fetch_status >=0 ")
        s.putBuf("begin")
        s.putBuf(" exec INSTANCE_OWNER @cursession,@childlistid,null,null")
        s.putBuf(" exec INSTANCE_DELETE @cursession,@childlistid")
        s.putBuf(" if @@error >0 begin")
        s.putBuf("   close child_inst_" & os.Name & "")
        s.putBuf("   deallocate child_inst_" & os.Name & " ")
        s.putBuf("   goto del_error")
        s.putBuf(" end")
        s.putBuf(" fetch next from child_inst_" & os.Name & " into @childlistid")
        s.putBuf("end")
        s.putBuf("close child_inst_" & os.Name & "")
        s.putBuf("deallocate child_inst_" & os.Name & " ")



        s.putBuf("  delete from  " & os.Name & " ")
        s.putBuf("  where  " & os.Name & "ID = @" & os.Name & "ID ")

        'Проверяем на MLF поля
        Dim j As Integer
        Dim bDetected As Boolean
        bDetected = False
        For j = 1 To os.FIELD.Count
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = os.FIELD.Item(j).FieldType
            If UCase(ft.Name) = UCase("MultiLanguage String") Or UCase(ft.Name) = UCase("MultiLanguage Memo") Then
                bDetected = True
                Exit For
            End If
        Next
        If bDetected Then
            s.putBuf("--MLF support")
            s.putBuf("declare @s nvarchar(4000)")
            s.putBuf("declare " & os.Name & "_LNG cursor local for select LangShort from LocalizeInfo")
            s.putBuf("open " & os.Name & "_LNG")
            s.putBuf("fetch next from " & os.Name & "_LNG into @Lang2")
            s.putBuf(" while @@fetch_status >=0")
            s.putBuf("  begin")
            s.putBuf("    set @s='delete from " & os.Name & "_' + @Lang2 + '")
            s.putBuf("            where M" & os.Name & "ID = @" & os.Name & "ID'")
            s.putBuf("    exec sp_executesql @s,N'@" & os.Name & "ID uniqueidentifier', @" & os.Name & "ID")
            s.putBuf("")
            s.putBuf("    fetch next from " & os.Name & "_LNG into @Lang2")
            s.putBuf("  End")
            s.putBuf("Close " & os.Name & "_LNG")
            s.putBuf("deallocate " & os.Name & "_LNG")
        End If

        s.putBuf("  -- удаляем номера из нумератора")
        s.putBuf("  delete from num_values where OwnerPartName='" & os.Name & "' and OwnerRowID=@" & os.Name & "ID")


        s.putBuf(" end")
        s.putBuf(" -- close transaction --")
        s.putBuf(" del_error:")
        s.putBuf(" if @@error <>0  if @@trancount>0 rollback tran  ")
        s.putBuf(" if @@trancount>0 commit tran  ")

        s.putBuf(" end ")
        o.ModuleName = "--Procedures"
        o.Block = "--TableProc"
        o.OutNL(s.getBuf)
        o.OutNL("GO")

        '  ' граф - еще одна процедура для удаления одного ребра
        '  If os.PartType = 3 Then
        '
        '
        '
        '    s = vbCrLf
        '    s.putbuf "create proc " & os.Name & "_EDGE_DELETE /*" & os.the_comment & "*/ ("
        '    s.putbuf " @CURSESSION uniqueidentifier,"
        '    s.putbuf " @" & os.Name & "_EDGE_id uniqueidentifier  "
        '    s.putbuf ") as " & " begin  "
        '    s.putbuf "set nocount on"
        '
        '    If Not os.NoLog Then s.putbuf " declare @SysLogID uniqueidentifier"
        '
        '    s.putbuf " declare @access int"
        '
        '    s.putbuf " declare @SysInstID uniqueidentifier"
        '    s.putbuf " select @SysInstID =Instanceid from instance where objtype='MTZSYSTEM'"
        '
        '
        '    s.putbuf " -- checking session  --"
        '    s.putbuf "if not exists( select 1 from the_session where the_sessionid=@cursession and closed=0)"
        '    s.putbuf "  begin"
        '    s.putbuf "    raiserror('Сессия уже завершена.',16,1)"
        '    s.putbuf "    if @@trancount>0 rollback tran"
        '    s.putbuf "    return"
        '    s.putbuf "  end"
        '
        '    s.putbuf " if exists(select 1 from " & os.Name & "_EDGE where " & os.Name & "_EDGE_ID=@" & os.Name & "_EDGE_ID)"
        '    s.putbuf " begin"
        '    s.putbuf " -- Delete body -- "
        '
        '    s.putbuf " --  verify access  --"
        '    s.putbuf " select  @tmpID =SecurityStyleID from " & os.Name & " where " & os.Name & "id=@" & os.Name & "ID"
        '    s.putbuf " exec CheckVerbRight @cursession=@cursession,@Resource=@" & os.Name & "_edge_id,@verb='DELETE',@access=@access out "
        '    s.putbuf " if @access=0 "
        '    s.putbuf "  begin"
        '    s.putbuf "    raiserror('Нет прав на удаление. Раздел=" & os.Name & "_EDGE',16,1)"
        '    s.putbuf "    if @@trancount>0 rollback tran"
        '    s.putbuf "    return"
        '    s.putbuf "  end"
        '
        '
        '    s.putbuf " --  verify lock  --"
        '    s.putbuf " exec " & os.Name & "_ISLOCKED @cursession=@cursession,@ROWID=@" & os.Name & "id,@IsLocked=@access out "
        '    s.putbuf " if @access>2 "
        '    s.putbuf "  begin"
        '    s.putbuf "    raiserror('Строка заблокирована другим пользователем. Раздел=" & os.Name & "',16,1)"
        '    s.putbuf "    if @@trancount>0 rollback tran"
        '    s.putbuf "    return"
        '    s.putbuf "  end"
        '
        '
        '    s.putbuf "  begin tran"
        '
        '    If Not os.NoLog Then
        '      s.putbuf "set @SysLogid=newid()"
        '      s.putbuf "EXEC SysLog_SAVE @TheSession=@cursession,@CURSESSION=@cursession, @InstanceID=@sysinstid, @SysLogid=@SysLogid, @LogStructID = '" & os.Name & "_EDGE',"
        '      s.putbuf " @VERB='DELETE',  @the_Resource=@" & os.Name & "_EDGE_id,@LogInstanceID=@instanceID"
        '    End If
        '
        '
        '
        '    s.putbuf "  delete from " & os.Name & "_edge WHERE " & os.Name & "_edge_id = @" & os.Name & "_EDGE_ID"
        '
        '    s.putbuf "  if @@error >0"
        '    s.putbuf "  begin"
        '    s.putbuf "   if @@trancount>0"
        '    s.putbuf "    rollback tran"
        '    s.putbuf "  end"
        '    s.putbuf "  else"
        '    s.putbuf "   commit tran"
        '
        '    s.putbuf " end"
        '
        '
        '    s.putbuf "end"
        '
        '    o.Module = "--Procedures"
        '    o.Block = "--TableProc"
        '    o.OutNL s
        '    o.OutNL "GO"
        '  End If
        '
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        Debug.Print("SQLGEN.CreateDelProc:done " & os.Caption)
        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
    End Sub



    Private Sub CreateProc(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        Debug.Print("SQLGEN.CreateProc:start " & os.Caption)
        If os.PartType = 3 Then
            Debug.Print("SQLGEN.CreateProc:skipped " & os.Caption)
            Exit Sub
        End If

        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i As Short
        Dim s As Writer
        s = New Writer


        log = log & vbCrLf & "-->CreateProc " & os.Name

        On Error GoTo bye

        s.putBuf("/*" & os.Caption & "*/")
        s.putBuf(procDropSQL(os.Name & "_SAVE"))
        s.putBuf("create proc " & os.Name & "_SAVE /*" & os.the_Comment & "*/ (")
        s.putBuf(" @CURSESSION uniqueidentifier,")
        s.putBuf("@InstanceID uniqueidentifier =null,")
        'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If TypeName(os.Parent.Parent) <> "OBJECTTYPE" Then
            s.putBuf(" @ParentStructRowID uniqueidentifier =null,")
        End If

        s.putBuf(" @" & os.Name & "id uniqueidentifier")

        ' дерево - родительская связь
        If os.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
            s.putBuf(",@ParentRowid uniqueidentifier = null ")
        End If

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            s.putBuf("," & FieldForParam(st.FIELD.Item(i)))
        Next

        s.putBuf(") as " & " begin  ")

        s.putBuf("set nocount on")


        If Not os.NoLog Then s.putBuf("DECLARE @SysLogid uniqueidentifier")
        s.putBuf(" declare @UniqueRowCount integer")
        s.putBuf(" declare @tmpStr varchar(255)")
        s.putBuf(" declare @tmpID uniqueidentifier")
        s.putBuf(" declare @access int")
        s.putBuf(" declare @SysInstID uniqueidentifier")
        s.putBuf(" declare @SessUserID uniqueidentifier")
        s.putBuf(" declare @SessUserLogin varchar(40)")

        s.putBuf(" select @SessUserID=UsersID from the_session where the_sessionid=@cursession")
        s.putBuf(" select @SessUserLogin =login from users where usersid=@SessUserID")

        s.putBuf(" select @SysInstID =Instanceid from instance where objtype='MTZSYSTEM'")


        s.putBuf(" -- checking session  --")
        s.putBuf("if not exists( select 1 from the_session where the_sessionid=@cursession and closed=0 )")
        s.putBuf("  begin")
        s.putBuf("    raiserror('Сессия уже завершена.',16,1)")
        s.putBuf("    if @@trancount>0 rollback tran")
        s.putBuf("    return")
        s.putBuf("  end")
        'PMOD
        s.putBuf(" declare @Lang2 varchar(25)")
        s.putBuf(" select @Lang2=Lang from the_session where the_sessionid=@cursession")
        's.putbuf " -- checking references  --" & vbCrLf
        'For i = 1 To st.FIELD.Count
        '  s = s & ReferenceCheck(os, st.FIELD.Item(i)) & vbCrLf
        'Next

        s.putBuf(" -- Insert / Update body -- ")

        s.putBuf("if exists(select 1 from " & os.Name & " where " & os.Name & "ID=@" & os.Name & "ID)")
        s.putBuf(" begin")

        s.putBuf(" --  UPDATE  --")

        s.putBuf(" --  verify access  --")

        s.putBuf(" select  @tmpID =SecurityStyleID from " & os.Name & " where " & os.Name & "id=@" & os.Name & "ID")
        s.putBuf(" exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='EDITROW',@access=@access out ")
        s.putBuf(" if @access=0 ")
        s.putBuf("  begin")
        s.putBuf("    exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='EDITROW:" & os.Name & "',@access=@access out ")
        s.putBuf("    if @access=0 ")
        s.putBuf("    begin")
        s.putBuf("      raiserror('Нет прав на модификацию. Раздел=" & os.Name & "',16,1)")
        s.putBuf("      if @@trancount>0 rollback tran")
        s.putBuf("      return")
        s.putBuf("    end")
        s.putBuf("  end")

        s.putBuf(" --  verify lock  --")

        s.putBuf(" exec " & os.Name & "_ISLOCKED @cursession=@cursession,@ROWID=@" & os.Name & "id,@IsLocked=@access out ")
        s.putBuf(" if @access>2 ")
        s.putBuf("  begin")
        s.putBuf("    raiserror('Строка заблокирована другим пльзователем. Раздел=" & os.Name & "',16,1)")
        s.putBuf("    if @@trancount>0 rollback tran")
        s.putBuf("    return")
        s.putBuf("  end")


        s.putBuf(" begin tran  ")

        s.putBuf(" -- update row  --")


        If Not os.NoLog Then
            s.putBuf("set @SysLogid=newid()")
            s.putBuf("EXEC SysLog_SAVE @TheSession=@cursession,@CURSESSION=@cursession, @InstanceID=@sysinstid, @SysLogid=@SysLogid, @LogStructID = '" & os.Name & "',")
            s.putBuf(" @VERB='EDITROW',  @the_Resource=@" & os.Name & "id, @LogInstanceID=@instanceID")
        End If
        s.putBuf(" update  " & os.Name & " set ChangeStamp=GetDate()")

        ' дерево модификация связи
        If os.PartType = 2 Then
            s.putBuf(",ParentRowid= @ParentRowid")
        End If

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            s.putBuf(",")
            s.putBuf("  " & st.FIELD.Item(i).Name & "=@" & st.FIELD.Item(i).Name)

            'support extention field if file type used
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = st.FIELD.Item(i).FieldType
            If UCase(ft.Name) = "FILE" Then
                s.putBuf("," & st.FIELD.Item(i).Name & "_EXT=")
                s.putBuf("@" & st.FIELD.Item(i).Name & "_EXT ")
            End If
        Next

        s.putBuf("  where  " & os.Name & "ID = @" & os.Name & "ID ")
        'PMOD
        Dim j As Integer
        Dim bDetected As Boolean
        Dim sDeclare As String
        Dim sParam As String
        Dim sParam2 As String
        Dim sInsert As String

        bDetected = False
        For j = 1 To os.FIELD.Count
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = st.FIELD.Item(j).FieldType
            If UCase(ft.Name) = UCase("MultiLanguage String") Or UCase(ft.Name) = UCase("MultiLanguage Memo") Then
                bDetected = True
                Exit For
            End If
        Next
        If bDetected Then
            bDetected = False
            sDeclare = " exec sp_executesql @s,N'@" & os.Name & "ID uniqueidentifier"
            sParam = ", @" & os.Name & "ID"
            s.putBuf("  declare @s nvarchar(4000)")


            s.putBuf("  declare @ls int")
            s.putBuf("  set @ls=0")
            s.putBuf("  set @s='select @LS=1 from " & os.Name & "_' + @Lang2 + ' where " & os.Name & "ID=@" & os.Name & "ID'")
            s.putBuf("  exec sp_executesql @s,N'@" & os.Name & "ID uniqueidentifier,@ls int output',@" & os.Name & "ID, @ls output")
            s.putBuf("if @ls=1")
            s.putBuf(" begin")



            s.putBuf("  set @s='update " & os.Name & "_' + @Lang2 + ' set")
            For j = 1 To os.FIELD.Count
                Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = os.FIELD.Item(j).FieldType
                If UCase(ft.Name) = UCase("MultiLanguage String") Or UCase(ft.Name) = UCase("MultiLanguage Memo") Then
                    If bDetected Then
                        s.putBuf("   ," & os.FIELD.Item(j).Name & "=@" & os.FIELD.Item(j).Name & "")
                    Else
                        s.putBuf("   " & os.FIELD.Item(j).Name & "=@" & os.FIELD.Item(j).Name & "")

                    End If
                    sDeclare = sDeclare & ", " & FieldForParam2(os.FIELD.Item(j)) & ""
                    sParam = sParam & ", @" & os.FIELD.Item(j).Name & ""
                    bDetected = True
                End If
            Next
            sDeclare = sDeclare & "'"
            s.putBuf("  where  " & os.Name & "ID = @" & os.Name & "ID'")
            sDeclare = sDeclare & sParam
            s.putBuf(sDeclare)

            s.putBuf(" end")
            s.putBuf("else")
            s.putBuf(" begin")

            'Next style
            bDetected = False
            sDeclare = " exec sp_executesql @s,N'@" & os.Name & "ID uniqueidentifier"
            sParam = " values(@" & os.Name & "ID"
            sParam2 = ",@" & os.Name & "ID"
            's.putBuf "declare @s nvarchar(4000)"
            s.putBuf("set @s=N'insert into " & os.Name & "_' + @Lang2 + '")
            s.putBuf("(" & os.Name & "ID")

            For j = 1 To os.FIELD.Count
                Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = os.FIELD.Item(j).FieldType
                If UCase(ft.Name) = UCase("MultiLanguage String") Or UCase(ft.Name) = UCase("MultiLanguage Memo") Then

                    s.putBuf("   ," & os.FIELD.Item(j).Name & "")

                    sDeclare = sDeclare & ", " & FieldForParam2(os.FIELD.Item(j)) & ""
                    sParam = sParam & ", @" & os.FIELD.Item(j).Name & ""
                    sParam2 = sParam2 & ", @" & os.FIELD.Item(j).Name & ""
                    bDetected = True
                End If
            Next
            sDeclare = sDeclare & "'"
            s.putBuf(")")
            sParam = sParam & ")'"
            s.putBuf(sParam)

            sDeclare = sDeclare & sParam2
            s.putBuf(sDeclare)
            s.putBuf(" End")
        End If
        'EPMOD
        s.putBuf(" -- checking unique constraints  --")

        s.putBuf(UniqueCheck(os) & vbCrLf)


        s.putBuf("  end")

        s.putBuf(" else")

        s.putBuf(" --  INSERT  --")
        s.putBuf("  begin")

        s.putBuf(" --  verify access  --")




        'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s.putBuf(" select @tmpid = SecurityStyleID from instance where instanceid=@instanceid")
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            s.putBuf(" select  @tmpID =SecurityStyleID from " & os.Parent.Parent.Name & " where " & os.Parent.Parent.Name & "id=@ParentStructRowID")
        End If

        s.putBuf(" exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='CREATEROW',@access=@access out")
        s.putBuf(" if @access=0 ")
        s.putBuf("  begin")
        s.putBuf("    exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='CREATEROW:" & os.Name & "',@access=@access out ")
        s.putBuf("    if @access=0 ")
        s.putBuf("    begin")
        s.putBuf("      raiserror('Нет прав на создание строк. Раздел=" & os.Name & "',16,1)")
        s.putBuf("      if @@trancount>0 rollback tran")
        s.putBuf("      return")
        s.putBuf("    end")
        s.putBuf(" end")

        'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s.putBuf(" exec instance_ISLOCKED @cursession=@cursession,@ROWID=@InstanceID,@IsLocked=@access out ")
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            s.putBuf(" exec " & os.Parent.Parent.Name & "_ISLOCKED @cursession=@cursession,@ROWID=@ParentStructRowID,@IsLocked=@access out ")
        End If


        s.putBuf(" if @access>2 ")
        s.putBuf("  begin")
        s.putBuf("    raiserror('Строка заблокирована другим пльзователем. Раздел=" & os.Name & "',16,1)")
        s.putBuf("    if @@trancount>0 rollback tran")
        s.putBuf("    return")
        s.putBuf("  end")



        ' check for single row part
        If os.PartType = 0 Then
            s.putBuf("if exists (select 1 from " & os.Name & " where ")
            'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
                s.putBuf("InstanceID=@InstanceID)")
            Else
                s.putBuf("ParentStructRowID=@ParentStructRowID)")
            End If
            s.putBuf(" begin")
            s.putBuf("    raiserror('Невозможно создать вторую строку в однострочной сессии. Раздел: <" & os.Name & ">',16,1)")
            s.putBuf("    if @@trancount>0 rollback tran")
            s.putBuf("    return")
            s.putBuf(" End")
        End If

        s.putBuf(" begin tran  ")

        If Not os.NoLog Then
            s.putBuf("set @SysLogid=newid()")
            s.putBuf("EXEC SysLog_SAVE @TheSession=@cursession,@CURSESSION=@cursession, @InstanceID=@sysinstid, @SysLogid=@SysLogid, @LogStructID = '" & os.Name & "',")
            s.putBuf(" @VERB='CREATEROW',  @the_Resource=@" & os.Name & "id, @LogInstanceID=@instanceID")
        End If

        s.putBuf(" insert into   " & os.Name & vbCrLf & " (  " & os.Name & "ID ")


        ' дерево  - поле
        If os.PartType = 2 Then
            s.putBuf(",ParentRowid")
        End If

        'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s.putBuf(",InstanceID")
        Else
            s.putBuf(",ParentStructRowID")
        End If


        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            s.putBuf("," & st.FIELD.Item(i).Name & vbCrLf)

            'support extention field if file type used
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = st.FIELD.Item(i).FieldType
            If UCase(ft.Name) = "FILE" Then
                s.putBuf("," & st.FIELD.Item(i).Name & "_EXT")
            End If
        Next

        s.putBuf(" ) values " & "( @" & os.Name & "ID ")


        ' дерево  - значение поля
        If os.PartType = 2 Then
            s.putBuf(",@ParentRowid")
        End If


        'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s.putBuf(",@InstanceID")
        Else
            s.putBuf(",@ParentStructRowID")
        End If

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            s.putBuf(",@" & st.FIELD.Item(i).Name & vbCrLf)
            'support extention field if file type used
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = st.FIELD.Item(i).FieldType
            If UCase(ft.Name) = "FILE" Then
                s.putBuf(",@" & st.FIELD.Item(i).Name & "_EXT")
            End If

        Next

        s.putBuf(" ) ")

        s.putBuf("--MLF Support")
        bDetected = False

        For j = 1 To os.FIELD.Count
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = os.FIELD.Item(j).FieldType
            If UCase(ft.Name) = UCase("MultiLanguage String") Or UCase(ft.Name) = UCase("MultiLanguage Memo") Then
                bDetected = True
                Exit For
            End If
        Next
        If bDetected Then
            bDetected = False
            sDeclare = " exec sp_executesql @s,N'@" & os.Name & "ID uniqueidentifier"
            sParam = " values(@" & os.Name & "ID"
            sParam2 = ",@" & os.Name & "ID"
            's.putBuf "declare @s nvarchar(4000)"
            s.putBuf("set @s=N'insert into " & os.Name & "_' + @Lang2 + '")
            s.putBuf("(" & os.Name & "ID")

            For j = 1 To os.FIELD.Count
                Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = os.FIELD.Item(j).FieldType
                If UCase(ft.Name) = UCase("MultiLanguage String") Or UCase(ft.Name) = UCase("MultiLanguage Memo") Then

                    s.putBuf("   ," & os.FIELD.Item(j).Name & "")

                    sDeclare = sDeclare & ", " & FieldForParam2(os.FIELD.Item(j)) & ""
                    sParam = sParam & ", @" & os.FIELD.Item(j).Name & ""
                    sParam2 = sParam2 & ", @" & os.FIELD.Item(j).Name & ""
                    bDetected = True
                End If
            Next
            sDeclare = sDeclare & "'"
            s.putBuf(")")
            sParam = sParam & ")'"
            s.putBuf(sParam)

            sDeclare = sDeclare & sParam2
            s.putBuf(sDeclare)

        End If

        s.putBuf(" exec " & os.Name & "_SINIT @CURSESSION,@" & os.Name & "id,@tmpid")

        s.putBuf(" -- checking unique constraints  --")
        s.putBuf(UniqueCheck(os) & vbCrLf)

        s.putBuf(" end")


        s.putBuf(" -- close transaction --")

        s.putBuf(" if @@error <>0  if @@trancount>0 rollback tran  ")
        s.putBuf(" if @@trancount>0 commit tran  ")

        s.putBuf(" end ")
        o.ModuleName = "--Procedures"
        o.Block = "--TableProc"
        o.OutNL(s.getBuf)
        o.OutNL("GO")

        CreateBriefProc(os)
        CreateDelProc(os)

        'If os.PartType = 3 Then EdgeProc os

        Debug.Print("SQLGEN.CreateProc:children " & os.Caption)
        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            CreateProc(chos)
        Next
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        Debug.Print("SQLGEN.CreateProc:done " & os.Caption)
        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
    End Sub






    ' make
    Private Function ReferenceCheck(ByRef os As MTZMetaModel.MTZMetaModel.PART, ByRef f As MTZMetaModel.MTZMetaModel.FIELD) As String
        Debug.Print("SQLGEN.ReferenceCheck:start " & os.Caption & " Filed:" & f.Caption)
        On Error GoTo bye
        Dim s As Writer
        s = New Writer
        log = log & vbCrLf & "-->ReferenceCheck " & f.Name

        'не ссылка
        'объект
        'строка

        'RAISERROR   ('The current database ID is:%d, the database name is: %s.',    16, 1, @DBID, @DBNAME)


        If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Skalyrnoe_pole_OPN_ne_ssilkaCLS Then
            s.putBuf("")
        End If

        If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
            s.putBuf("if(not exists( select  1 from instance where instanceid=@" & f.Name & " )) ")
            s.putBuf("  begin")
            s.putBuf("    raiserror('Не обнаружен объект, на который установлена ссылка. Раздел=" & os.Name & " field=" & f.Name & "',16,1)")
            s.putBuf("    if @@trancount>0 rollback tran")
            s.putBuf("    return")
            s.putBuf("  end")
        End If


        If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
            s.putBuf("if(not @" & f.Name & " is null ) ")
            'UPGRADE_WARNING: Couldn't resolve default property of object f.RefToPart.Name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            Dim part As MTZMetaModel.MTZMetaModel.PART = f.RefToPart
            s.putBuf("if(not exists( select  1 from " & part.Name & " where " & part.Name & "id=@" & f.Name & " )) ")
            s.putBuf("  begin")
            'UPGRADE_WARNING: Couldn't resolve default property of object f.RefToPart.Name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            s.putBuf("    raiserror('Отсутствует строка в таблице (" & part.Name & "), на которую установлена ссылка.  Раздел=" & os.Name & " поле=" & f.Name & "',16,1)")
            s.putBuf("    if @@trancount>0 rollback tran")
            s.putBuf("    return")
            s.putBuf("  end")
        End If

        ReferenceCheck = s.getBuf
        Debug.Print("SQLGEN.ReferenceCheck:done " & os.Caption & " Filed:" & f.Caption)
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
    End Function




    Private Sub CreateMethod(ByRef m As MTZMetaModel.MTZMetaModel.SHAREDMETHOD)
        Debug.Print("SQLGEN.CreateMethod:start")
        On Error GoTo bye
        Dim p As MTZMetaModel.MTZMetaModel.PARAMETERS
        Dim i As Integer
        Dim s, s1 As String
        Dim ftm As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        Dim Parameters As MTZMetaModel.MTZMetaModel.PARAMETERS_col
        s1 = GetScript(m.SCRIPT)

        If s1 = "" Then Exit Sub

        log = log & vbCrLf & "-->CreateMethod " & m.Name
        Parameters = GetParameters(m.SCRIPT)
        s = "/* " & m.Name & "  " & m.the_Comment & "*/"
        If m.ReturnType Is Nothing Then
            s = s & vbCrLf & procDropSQL((m.Name))
            s = s & vbCrLf & "create proc " & m.Name & vbCrLf
            If Parameters.Count > 0 Then
                s = s & vbCrLf & "("
            End If
        Else
            s = s & vbCrLf & funcDropSQL((m.Name))
            s = "create function " & m.Name & vbCrLf
        End If



        Parameters.Sort = "sequence"
        For i = 1 To Parameters.Count
            p = Parameters.Item(i)
            If i > 1 Then s = s & vbCrLf & ","
            s = s & MethodParam(p) & vbCrLf
        Next

        If Not m.ReturnType Is Nothing Then
            s = s & vbCrLf & ") "
            'UPGRADE_WARNING: Couldn't resolve default property of object m.ReturnType.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            s = s & vbCrLf & " returns " & MapFTObj(m.ReturnType.ID.ToString()).StoageType & vbCrLf
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
            '  Else
            '    s1
            '    's1 = ""
        End If

        s = s & s1 & vbCrLf

        s = s & vbCrLf & "--------- script body end---------"
        s = s & vbCrLf & "end"
        s = s & vbCrLf & "GO"

        o.ModuleName = "--Procedures"
        o.Block = "--Methods"
        o.OutNL(s)
        o.OutNL("GO")

        Debug.Print("SQLGEN.CreateMethod:done")
        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
    End Sub



    Private Function FieldForCreate(ByRef f As MTZMetaModel.MTZMetaModel.FIELD) As String
        Debug.Print("SQLGEN.FieldForCreate:start")
        On Error Resume Next

        log = log & vbCrLf & "-->FieldForCreate " & f.Name

        Dim s As String
        Dim ftm As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        s = f.Name
        'UPGRADE_WARNING: Couldn't resolve default property of object f.FIELDTYPE.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = f.FieldType
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


        'UPGRADE_WARNING: Couldn't resolve default property of object f.FIELDTYPE.TypeStyle. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Interval Then
            'UPGRADE_WARNING: Couldn't resolve default property of object f.FIELDTYPE.Maximum. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object f.FIELDTYPE.Minimum. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            s = s & vbCrLf & " check (" & f.Name & " >= " & ft.Minimum & " and " & f.Name & " <= " & ft.Maximum & ")"
        End If

        'UPGRADE_WARNING: Couldn't resolve default property of object f.FIELDTYPE.TypeStyle. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Dim e As Object
        If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
            'UPGRADE_WARNING: Couldn't resolve default property of object f.FIELDTYPE.ENUMITEM. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If ft.ENUMITEM.Count > 0 Then
                s = s & vbCrLf & " check (" & f.Name & " in ( "
                'UPGRADE_WARNING: Couldn't resolve default property of object f.FIELDTYPE.ENUMITEM. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                For e = 1 To ft.ENUMITEM.Count
                    'UPGRADE_WARNING: Couldn't resolve default property of object e. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    If e > 1 Then s = s & vbCrLf & ", "
                    'UPGRADE_WARNING: Couldn't resolve default property of object f.FIELDTYPE.ENUMITEM. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
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
        Debug.Print("SQLGEN.FieldForCreate:done")
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"

    End Function

    Private Function FieldForParam2(ByRef f As MTZMetaModel.MTZMetaModel.FIELD) As String
        Debug.Print("SQLGEN.FieldForParam:start")
        On Error GoTo bye
        log = log & vbCrLf & "-->FieldForParam " & f.Name
        Dim s As String
        s = "@" & f.Name
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = f.FieldType
        Dim ftm As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP = MapFTObj(ft.ID.ToString())
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
        Debug.Print("SQLGEN.FieldForParam:done")
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
    End Function

    Private Function FieldForParam(ByRef f As MTZMetaModel.MTZMetaModel.FIELD) As String
        Debug.Print("SQLGEN.FieldForParam:start")
        On Error GoTo bye


        log = log & vbCrLf & "-->FieldForParam " & f.Name
        Dim s As String
        Dim ftm As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        s = "@" & f.Name
        'UPGRADE_WARNING: Couldn't resolve default property of object f.FIELDTYPE.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = f.FieldType
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

        If f.AllowNull Then
            s = s & " = null "
        End If

        s = s & "/* " & f.Caption & " */"

        'support extention field if file type used
        'UPGRADE_WARNING: Couldn't resolve default property of object f.FIELDTYPE.Name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        If UCase(ft.Name) = "FILE" Then
            s = s & vbCrLf & ",@" & f.Name & "_EXT nvarchar(4) = null"
        End If

        FieldForParam = s & "/* " & f.Caption & " */"
        Debug.Print("SQLGEN.FieldForParam:done")
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
    End Function




    Private Function MethodParam(ByRef f As MTZMetaModel.MTZMetaModel.PARAMETERS) As String
        Debug.Print("SQLGEN.MethodParam:start")
        On Error GoTo bye
        log = log & vbCrLf & "-->MethodParam " & f.Name
        Dim s As String
        Dim ftm As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        s = "@" & f.Name
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = f.TypeOfParm
        ftm = MapFTObj(ft.ID.ToString())
        If ftm.FixedSize <> 0 Then
            s = s & " " & ftm.StoageType & "(" & ftm.FixedSize & ")"
        Else
            s = s & " " & ftm.StoageType
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
        Debug.Print("SQLGEN.MethodParam:done")
        Exit Function
bye:
        Debug.Print(Err.Description)
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
    End Function


    Private Function UniqueCheck(ByRef os As MTZMetaModel.MTZMetaModel.PART) As String
        If os.PartType = 3 Then
            Debug.Print("SQLGEN.UniqueCheck:skipped " & os.Caption)
            Return String.Empty
        End If
        System.Windows.Forms.Application.DoEvents()
        Debug.Print("SQLGEN.UniqueCheck:start " & os.Caption)
        log = log & vbCrLf & "-->UniqueCheck for " & os.Name
        On Error GoTo bye
        Dim s As String
        Dim st As MTZMetaModel.MTZMetaModel.PART
        Dim uc As MTZMetaModel.MTZMetaModel.UNIQUECONSTRAINT
        Dim cf As MTZMetaModel.MTZMetaModel.CONSTRAINTFIELD
        Dim i, j As Integer
        st = os
        s = ""

        Dim z As String

        If st.UNIQUECONSTRAINT.Count > 0 Then
            s = s & "If @SessUserLogin<>'replicator' "
            s = s & vbCrLf & "begin"
            For i = 1 To st.UNIQUECONSTRAINT.Count
                uc = st.UNIQUECONSTRAINT.Item(i)
                z = ""
                If uc.CONSTRAINTFIELD.Count > 0 Then

                    For j = 1 To uc.CONSTRAINTFIELD.Count
                        cf = uc.CONSTRAINTFIELD.Item(j)
                        If Not cf.TheField Is Nothing Then
                            'UPGRADE_WARNING: Couldn't resolve default property of object cf.TheField.Name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            Dim field As MTZMetaModel.MTZMetaModel.FIELD = cf.TheField
                            z = z & vbCrLf & " and " & field.Name & "=@" & field.Name
                        Else
                            log = log & vbCrLf & "WARNING-->Field not defined in unique constraint Table=" & st.Name & " <--WARNING"
                        End If
                    Next

                    If uc.PerParent Then
                        If os.PartType = MTZMetaModel.MTZMetaModel.enumPartType.PartType_Derevo Then
                            'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
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
                            'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                            If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
                                s = s & vbCrLf & " select @UniqueRowCount=Count(*) from " & os.Name & " where InstanceID=@InstanceID " & z
                            Else
                                s = s & vbCrLf & "select @UniqueRowCount=Count(*) from " & os.Name & " where ParentStructRowID=@ParentStructRowID " & z
                            End If
                        End If
                    Else
                        s = s & vbCrLf & "select @UniqueRowCount=Count(*) from " & os.Name & " where 1=1  " & z
                    End If

                    If uc.TheComment <> "" Then
                        s = s & vbCrLf & "if @UniqueRowCount>=2"
                        s = s & vbCrLf & "begin"
                        s = s & vbCrLf & " raiserror('" & uc.TheComment & " Раздел=" & os.Caption & "',16,1)"
                        s = s & vbCrLf & " if @@trancount>0 rollback tran"
                        s = s & vbCrLf & " return"
                        s = s & vbCrLf & "end"
                    ElseIf uc.Name <> "" Then
                        s = s & vbCrLf & "if @UniqueRowCount>=2"
                        s = s & vbCrLf & "begin"
                        s = s & vbCrLf & " raiserror('Нарущение уникальности сочетания полей.  Раздел=" & os.Caption & " Правило=" & uc.Name & "',16,1)"
                        s = s & vbCrLf & " if @@trancount>0 rollback tran"
                        s = s & vbCrLf & " return"
                        s = s & vbCrLf & "end"
                    Else
                        s = s & vbCrLf & "if @UniqueRowCount>=2"
                        s = s & vbCrLf & "begin"
                        s = s & vbCrLf & " raiserror('Нарущение уникальности сочетания полей. Раздел=" & os.Caption & "',16,1)"
                        s = s & vbCrLf & " if @@trancount>0 rollback tran"
                        s = s & vbCrLf & " return"
                        s = s & vbCrLf & "end"
                    End If

                End If
            Next

            s = s & vbCrLf & "end"
        End If

        UniqueCheck = s
        Debug.Print("SQLGEN.UniqueCheck:done " & os.Caption)
        Exit Function
bye:
        Debug.Print(Err.Description)
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
    End Function




    Private Function MapPartView(ByRef os As MTZMetaModel.MTZMetaModel.PART) As String
        If os.PartType = 3 Then
            Debug.Print("SQLGEN.MapPartView:skipped " & os.Caption)
            Return String.Empty
        End If
        Dim s As String = String.Empty
        Dim i As Integer
        For i = 1 To os.PARTVIEW.Count
            If os.PARTVIEW.Item(i).ForChoose = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
                s = s & vbCrLf & "set @id = '" & GetMap(os.Name & "_DEFVIEW") & "'"
                s = s & vbCrLf & "EXEC SysOptions_SAVE  @SysOptionsid=@id, @Name='" & os.Name & "', @Value='" & os.PARTVIEW.Item(i).the_Alias & "', @OptionType='DEFVIEW'"
                Exit For
            End If
        Next
        For i = 1 To os.PART.Count
            If Not os.PART.Item(i).PartType = 3 Then
                s = s & vbCrLf & MapPartView(os.PART.Item(i))
            End If
        Next

        MapPartView = s
        Debug.Print("SQLGEN.MapPartView:done " & os.Caption)
    End Function


    Private Function MapAndParent(ByRef os As MTZMetaModel.MTZMetaModel.PART) As String
        Debug.Print("SQLGEN.MapAndParent:start " & os.Caption)
        If os.PartType = 3 Then
            Debug.Print("SQLGEN.MapAndParent:skipped " & os.Caption)
            Return String.Empty
        End If
        Dim s As String = String.Empty
        Dim tn As String
        tn = TypeForStruct(os).Name

        s = s & vbCrLf & "set @id = '" & GetMap(os.Name & "_structtype") & "'"
        s = s & vbCrLf & "EXEC SysOptions_SAVE  @SysOptionsid=@id, @Name='" & os.Name & "', @Value='" & tn & "', @OptionType='STRUCT_TYPE'"



        'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If TypeName(os.Parent.Parent) <> "OBJECTTYPE" Then
            s = s & vbCrLf & "set @id = '" & GetMap(os.Name & "_PARENT") & "'"
            'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            s = s & vbCrLf & "EXEC SysOptions_SAVE  @SysOptionsid=@id, @Name='" & os.Name & "', @Value='" & os.Parent.Parent.Name & "', @OptionType='PARENT'"
        End If

        Dim i As Integer
        For i = 1 To os.PART.Count
            If Not os.PART.Item(i).PartType = 3 Then
                s = s & vbCrLf & MapAndParent(os.PART.Item(i))
            End If
        Next

        MapAndParent = s
        Debug.Print("SQLGEN.MapAndParent:done " & os.Caption)
    End Function


    'UPGRADE_NOTE: pv was upgraded to pv_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Function MapViews(ByRef pv_Renamed As MTZMetaModel.MTZMetaModel.PARTVIEW) As String
        Dim s As String
        s = ""
        s = s & vbCrLf & "set @id = '" & GetMap(pv_Renamed.the_Alias & "_map") & "'"
        s = s & vbCrLf & "EXEC SysOptions_SAVE  @SysOptionsid=@id, @Name='" & pv_Renamed.ID.ToString() & "', @Value='V_" & pv_Renamed.the_Alias & "', @OptionType='MAP'"
        MapViews = s
    End Function


    Private Function TypeForStruct(ByVal s As MTZMetaModel.MTZMetaModel.PART) As MTZMetaModel.MTZMetaModel.OBJECTTYPE
        Debug.Print("SQLGEN.TypeForStruct:start " & s.Caption)
        Dim obj As Object
        'UPGRADE_WARNING: Couldn't resolve default property of object s.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        obj = s.Parent.Parent

        ' ищем что за тип объекта
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        While TypeName(obj) <> "OBJECTTYPE"
            'UPGRADE_WARNING: Couldn't resolve default property of object obj.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            obj = obj.Parent.Parent
        End While

        TypeForStruct = obj

        Debug.Print("SQLGEN.TypeForStruct:done " & s.Caption)
    End Function


    Private Sub LoadOptions()
        Debug.Print("SQLGEN.LoadOptions:start ")
        Dim s As Writer
        s = New Writer
        System.Windows.Forms.Application.DoEvents()
        Dim os As MTZMetaModel.MTZMetaModel.PART = Nothing
        Dim i As Integer
        Dim j As Integer

        s.putBuf("declare @id uniqueidentifier")
        s.putBuf("declare @instid uniqueidentifier")
        s.putBuf("declare @uid uniqueidentifier")
        s.putBuf("declare @SESSION uniqueidentifier")
        s.putBuf("declare @cid uniqueidentifier")
        s.putBuf("declare @secid uniqueidentifier")
        s.putBuf("declare @hid uniqueidentifier")
        s.putBuf("declare @tmpstr varchar(255)")

        s.putBuf("set @instid = '" & GetMap("MTSYSTEMID") & "'")
        s.putBuf("set @uid = '" & GetMap("inituser") & "' ")
        s.putBuf("set @secid = '" & GetMap("secid") & "' --user security instance ")
        s.putBuf("set @hid = '" & GetMap("helper") & "' -- helper id")
        s.putBuf("if not exists(select 1 from users where usersid=@uid)")
        s.putBuf("insert into users(usersid,instanceid,login,password) values(@uid,null,'init','init')")
        s.putBuf("if not exists(select 1 from instance where instanceid=@instid)")
        s.putBuf("insert into instance(InstanceID,OBJTYPE,Name) values(@instid, 'MTZSYSTEM','Системная информация')")
        For i = 1 To m.OBJECTTYPE.Count
            s.putBuf("if not exists(select 1 from typelist where name='" & m.OBJECTTYPE.Item(i).Name & "')")
            s.putBuf("insert into typelist( name,RegisterProc,DeleteProc, HCLProc, propagateProc) values('" & m.OBJECTTYPE.Item(i).Name & "', '" & m.OBJECTTYPE.Item(i).Name & "_REGISTER', '" & m.OBJECTTYPE.Item(i).Name & "_DELETE', '" & m.OBJECTTYPE.Item(i).Name & "_HCL', '" & m.OBJECTTYPE.Item(i).Name & "_propagate')")
        Next
        s.putBuf("exec Login @the_SESSION=@session OUTPUT , @PWD='init', @USR='init'")

        s.putBuf("EXEC Instance_SAVE @CURSESSION=@session, @InstanceID=@secid, @ObjType='MTZUsers',@Name='Пользователи и группы'")

        For i = 1 To m.OBJECTTYPE.Count

            If Not m.OBJECTTYPE.Item(i).ChooseView Is Nothing Then
                s.putBuf("set @id = '" & GetMap(m.OBJECTTYPE.Item(i).Name & "_TDEFVIEW") & "'")
                'UPGRADE_WARNING: Couldn't resolve default property of object m.OBJECTTYPE.Item(i).ChooseView.the_Alias. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                Dim cv As MTZMetaModel.MTZMetaModel.PARTVIEW = m.OBJECTTYPE.Item(i).ChooseView
                s.putBuf("EXEC SysOptions_SAVE  @SysOptionsid=@id, @Name='" & m.OBJECTTYPE.Item(i).Name & "', @Value='" & cv.the_Alias & "', @OptionType='TDEFVIEW'")
            End If

            For j = 1 To m.OBJECTTYPE.Item(i).PART.Count
                s.putBuf(MapAndParent(m.OBJECTTYPE.Item(i).PART.Item(j)))
                s.putBuf(MapPartView(m.OBJECTTYPE.Item(i).PART.Item(j)))
            Next
        Next

        For i = 1 To m.SHAREDMETHOD.Count
            s.putBuf("set @id = '" & GetMap(m.SHAREDMETHOD.Item(i).Name & "_METHOD") & "'")
            Dim sm As MTZMetaModel.MTZMetaModel.SHAREDMETHOD = m.SHAREDMETHOD.Item(i)
            s.putBuf("EXEC SysOptions_SAVE  @SysOptionsid=@id, @Name='" & sm.ID.ToString() & "', @Value='" & sm.Name & "', @OptionType='METHODNAME'")
        Next

        s.putBuf("DECLARE @Groupid uniqueidentifier")
        s.putBuf("DECLARE @GroupUserid uniqueidentifier")

        ' create new user
        s.putBuf("set @uid='" & GetMap("supervisor") & "'")
        s.putBuf("EXEC Users_SAVE @CURSESSION=@session, @InstanceID=@secid, @Usersid=@uid, ")
        s.putBuf(" @Password='bami',  @Login='supervisor', @name='Администратор'")

        ''--- GROUP Administrtors
        's.putbuf "set @Groupid ='" & GetMap("AdminGroup") & "'"
        's.putbuf "EXEC Groups_SAVE @CURSESSION=@SESSION, @InstanceID=@secid, @Groupsid=@Groupid, @Name='Administrators'"
        '
        's.putbuf "set @GroupUserid='" & GetMap("supervisor_in_group") & "'"
        's.putbuf "EXEC GroupUser_SAVE @CURSESSION=@SESSION, @ParentStructRowID=@Groupid, @GroupUserid = @GroupUserid,  @TheUser=@uid"


        s.putBuf("exec Logout  @cursession=@session")

        s.putBuf("delete from users where login = 'init'")

        'лучшее враг хорошего - репликатор не сможет работать, если удалить сессии
        's.putBuf "delete from the_session"
        s.putBuf("go")

        o.ModuleName = "--Options"
        o.Block = "--Load"
        o.OutNL(s.getBuf)
        Debug.Print("SQLGEN.LoadOptions:done ")
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
    End Sub




    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' UTILS
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ' return phisical type for FIELDTYPE
    Private Function MapFT(ByVal typeID As String) As String
        Dim i As Integer
        Dim s As String = String.Empty
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE

        On Error Resume Next

        If ftmap Is Nothing Then ftmap = New Collection
        If ftmap.Item(typeID) Is Nothing Then
        Else
            'UPGRADE_WARNING: Couldn't resolve default property of object ftmap.Item().StoageType. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            s = ftmap.Item(typeID).StoageType
            'UPGRADE_WARNING: Couldn't resolve default property of object ftmap.Item(typeID).FixedSize. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If ftmap.Item(typeID).FixedSize <> 0 Then
                'UPGRADE_WARNING: Couldn't resolve default property of object ftmap.Item().FixedSize. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                s = s & vbCrLf & " (" & ftmap.Item(typeID).FixedSize & ")"
            End If
            'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            MapFT = s
            Exit Function
        End If

        On Error GoTo bye

        MapFT = "INTEGER"
        ft = m.FIELDTYPE.Item(typeID)
        If ft Is Nothing Then Exit Function
        For i = 1 To ft.FIELDTYPEMAP.Count
            'UPGRADE_WARNING: Couldn't resolve default property of object ft.FIELDTYPEMAP.Item(i).Target.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If ft.FIELDTYPEMAP.Item(i).Target.ID.ToString() = tid Then
                ftmap.Add(ft.FIELDTYPEMAP.Item(i), typeID)
                'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                s = ft.FIELDTYPEMAP.Item(i).StoageType
                If ft.FIELDTYPEMAP.Item(i).FixedSize <> 0 Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    s = s & vbCrLf & " (" & ft.FIELDTYPEMAP.Item(i).FixedSize & ")"
                End If
                Exit For
            End If
        Next
        'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        MapFT = s
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"

    End Function


    Private Function MapFTObj(ByVal typeID As String) As MTZMetaModel.MTZMetaModel.FIELDTYPEMAP
        On Error Resume Next

        If ftmap Is Nothing Then ftmap = New Collection
        If ftmap.Item(typeID) Is Nothing Then
        Else
            Return ftmap.Item(typeID)
        End If

        On Error GoTo bye
        Dim i, s As Object
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        ft = m.FIELDTYPE.Item(typeID)
        If ft Is Nothing Then Return Nothing
        For i = 1 To ft.FIELDTYPEMAP.Count
            'UPGRADE_WARNING: Couldn't resolve default property of object ft.FIELDTYPEMAP.Item(i).Target.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If ft.FIELDTYPEMAP.Item(i).Target.ID.ToString() = tid Then
                ftmap.Add(ft.FIELDTYPEMAP.Item(i), typeID)
                Return ft.FIELDTYPEMAP.Item(i)
            End If
        Next
        Return Nothing
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"

    End Function




    Private Function GetScript(ByRef scol As MTZMetaModel.MTZMetaModel.SCRIPT_col) As String
        Dim i As Integer

        On Error GoTo bye
        For i = 1 To scol.Count
            'UPGRADE_WARNING: Couldn't resolve default property of object scol.Item(i).Target.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If scol.Item(i).Target.ID.ToString() = tid Then
                Return scol.Item(i).Code
            End If
        Next
        Return String.Empty
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"


    End Function


    Private Function GetParameters(ByRef scol As MTZMetaModel.MTZMetaModel.SCRIPT_col) As MTZMetaModel.MTZMetaModel.PARAMETERS_col
        Dim i As Integer

        On Error GoTo bye
        For i = 1 To scol.Count
            'UPGRADE_WARNING: Couldn't resolve default property of object scol.Item(i).Target.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If scol.Item(i).Target.ID.ToString() = tid Then
                Return scol.Item(i).PARAMETERS
            End If
        Next
        Return Nothing
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"

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




    Private Sub CreateBriefProc(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        Debug.Print("SQLGEN.CreateBriefProc:start ")
        If os.PartType = 3 Then
            Debug.Print("SQLGEN.CreateBriefProc:skipped " & os.Caption)
            Exit Sub
        End If

        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As Writer
        s = New Writer
        CreateBriefFunc(os)
        log = log & vbCrLf & "-->CreateBriefProc " & os.Name
        On Error GoTo bye
        s.putBuf("")
        s.putBuf(procDropSQL(os.Name & "_BRIEF"))
        s.putBuf("create proc " & os.Name & "_BRIEF  (")
        s.putBuf(" @CURSESSION uniqueidentifier,")
        s.putBuf(" @" & os.Name & "id uniqueidentifier,")
        s.putBuf(" @BRIEF varchar(4000) output")
        s.putBuf(") as " & " begin  ")
        s.putBuf("set nocount on")
        s.putBuf(" declare @access int")
        s.putBuf(" declare @tmpStr varchar(255)")
        s.putBuf(" declare @tmpID uniqueidentifier")
        s.putBuf(" -- checking session  --")
        s.putBuf("if not exists( select 1 from the_session where the_sessionid=@cursession and closed=0 )")
        s.putBuf("  begin")
        s.putBuf("    raiserror('Сессия уже завершена.',16,1)")
        s.putBuf("    return")
        s.putBuf("  end")
        s.putBuf(" declare @Lang2 varchar(25)")
        s.putBuf(" select @Lang2=Lang from the_session where the_sessionid=@cursession")

        s.putBuf("if @" & os.Name & "id is null begin set @BRIEF='' return end")

        s.putBuf(" -- Brief body -- ")

        s.putBuf("if exists(select 1 from " & os.Name & " where " & os.Name & "ID=@" & os.Name & "ID)")
        s.putBuf(" begin")
        s.putBuf(" --  verify access  --")
        s.putBuf(" select  @tmpID =SecurityStyleID from " & os.Name & " where " & os.Name & "id=@" & os.Name & "ID")
        s.putBuf(" exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='BRIEF',@access=@access out ")
        s.putBuf(" if @access=0 ")
        s.putBuf("  begin")
        s.putBuf("    raiserror('No access for BRIEF Structure=" & os.Name & "',16,1)")
        s.putBuf("    return")
        s.putBuf("  end")
        'MLF
        's.putBuf "  select @BRIEF=dbo." & os.Name & "_BRIEF_F(@" & os.Name & "id)"
        s.putBuf("  select @BRIEF=dbo." & os.Name & "_BRIEF_F(@" & os.Name & "id, @Lang2)")
        s.putBuf("end else begin")
        s.putBuf("  set @BRIEF= 'неверный идентификатор'")
        s.putBuf("end")
        s.putBuf("set @BRIEF=left(@BRIEF,4000)")
        s.putBuf("end ")


        o.ModuleName = "--Procedures"
        o.Block = "--TableProc"
        o.OutNL(s.getBuf)
        o.OutNL("GO")
        Debug.Print("SQLGEN.CreateBriefProc:done ")
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        Debug.Print(Err.Description)
        'Resume
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
    End Sub



    Private Sub CreateBriefFunc(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        If os.PartType = 3 Then
            Debug.Print("SQLGEN.CreateBriefFunc:skipped " & os.Caption)
            Exit Sub
        End If

        Debug.Print("SQLGEN.CreateBriefFunc:start " & os.Caption)
        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As Writer
        s = New Writer

        ' делаем отдельно заголовки функций
        CreateBriefFuncHdr(os)


        log = log & vbCrLf & "-->CreateBriefFunc " & os.Name

        On Error GoTo bye

        s.putBuf("")
        s.putBuf("alter function " & os.Name & "_BRIEF_F  (")
        s.putBuf(" @" & os.Name & "id uniqueidentifier")
        'MLF
        s.putBuf(" ,@Lang varchar(25)=NULL")
        'EMLF
        s.putBuf(") returns varchar(255) as " & " begin  ")
        s.putBuf(" declare @BRIEF varchar(255)")
        s.putBuf(" declare @tmpStr varchar(255)")
        s.putBuf(" declare @tmpBrief varchar(2000)")
        s.putBuf(" declare @tmpID uniqueidentifier")
        s.putBuf(" declare @MLFTemp varchar(2000)")
        s.putBuf(" declare @MLFBrief varchar(2000)")

        s.putBuf("if @" & os.Name & "id is null begin set @BRIEF=' ' return (@BRIEF) end")
        s.putBuf(" -- Brief body -- ")
        s.putBuf("if exists(select 1 from " & os.Name & " where " & os.Name & "ID=@" & os.Name & "ID)")
        s.putBuf(" begin")
        s.putBuf(" --  verify access  --")
        s.putBuf("  set @BRIEF=''")

        st.FIELD.Sort = "sequence"
        For i = 1 To st.FIELD.Count
            If st.FIELD.Item(i).IsBrief Then
                f = st.FIELD.Item(i)
                's.putbuf "  set @BRIEF= @BRIEF + '" & F.Caption & "='"

                'enum
                Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = f.FieldType
                If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then

                    s.putBuf("  select @BRIEF= @BRIEF +")
                    s.putBuf("  case " & f.Name & " ")
                    'UPGRADE_WARNING: Couldn't resolve default property of object st.FIELD.Item(i).FIELDTYPE.ENUMITEM. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    For j = 1 To ft.ENUMITEM.Count
                        'UPGRADE_WARNING: Couldn't resolve default property of object st.FIELD.Item().FIELDTYPE.ENUMITEM. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        s.putBuf("when " & ft.ENUMITEM.Item(j).NameValue & " then ")
                        'UPGRADE_WARNING: Couldn't resolve default property of object st.FIELD.Item().FIELDTYPE.ENUMITEM. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        s.putBuf(" '" & ft.ENUMITEM.Item(j).Name & "; '")
                    Next
                    s.putBuf("  end  from " & st.Name & " where " & os.Name & "ID=@" & os.Name & "ID")

                    'UPGRADE_WARNING: Couldn't resolve default property of object st.FIELD.Item(i).FIELDTYPE.TypeStyle. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                    s.putBuf("select @tmpID =  " & f.Name)
                    s.putBuf("  from " & os.Name & "  where  " & os.Name & "ID = @" & os.Name & "ID ")
                    If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                        'MLF
                        s.putBuf(" select @tmpBrief= dbo.Instance_BRIEF_F( @tmpID)") ', @Lang)"
                    End If
                    If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                        'MLF
                        'UPGRADE_WARNING: Couldn't resolve default property of object f.RefToPart.Name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        Dim part As MTZMetaModel.MTZMetaModel.PART = f.RefToPart
                        s.putBuf(" select @tmpBrief= dbo." & part.Name & "_BRIEF_F(@tmpID, @Lang)")
                    End If
                    s.putBuf("  set @BRIEF= @BRIEF + '{' + isnull(@tmpbrief,' ') + '}; '")
                    'MLF
                ElseIf IsMLFField(f) Then
                    s.putBuf("set @MLFBrief=null")
                    s.putBuf("if not @Lang is null")
                    s.putBuf("begin")
                    s.putBuf("")
                    s.putBuf("  set @MLFTemp='select @MLFTemp2=" & st.FIELD.Item(i).Name & " from " & os.Name & "_'+@Lang+' where " & os.Name & "ID=@" & os.Name & "ID'")
                    s.putBuf("  exec sp_executesql @MLFTemp,N'@" & os.Name & "ID uniqueidentifier,@MLFBrief varchar(2000) output',@" & os.Name & "ID, @MLFBrief output")
                    s.putBuf("End")

                    s.putBuf("  select @BRIEF= @BRIEF ")
                    s.putBuf("  +  isnull(@MLFBrief,isnull(Convert(varchar(255), " & st.FIELD.Item(i).Name & "),' '))+'; '")
                    s.putBuf("  from " & os.Name & "  where  " & os.Name & "ID = @" & os.Name & "ID ")
                    'EMLF
                Else
                    s.putBuf("  select @BRIEF= @BRIEF ")
                    s.putBuf("  +  isnull(Convert(varchar(255), " & st.FIELD.Item(i).Name & "),' ')+'; '")
                    s.putBuf("  from " & os.Name & "  where  " & os.Name & "ID = @" & os.Name & "ID ")
                End If
            End If
        Next
        s.putBuf("end else begin")
        s.putBuf("  set @BRIEF= '-'")
        s.putBuf("end")
        s.putBuf("set @BRIEF=left(@BRIEF,255)")
        s.putBuf("return(@BRIEF)")
        s.putBuf("end ")
        Debug.Print(os.Name)

        o.ModuleName = "--Functions"
        o.Block = "--TableProc"
        o.OutNL(s.getBuf)
        o.OutNL("GO")
        Debug.Print("SQLGEN.CreateBriefFunc:done " & os.Caption)
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        Debug.Print(Err.Description)
        'Resume
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
    End Sub



    Private Sub CreateBriefFuncHdr(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        Debug.Print("SQLGEN.CreateBriefFuncHdr:start " & os.Caption)
        If os.PartType = 3 Then
            Debug.Print("SQLGEN.CreateBriefFuncHdr:skipped " & os.Caption)
            Exit Sub
        End If

        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i, j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim s As String


        log = log & vbCrLf & "-->CreateBriefFuncHdr " & os.Name

        On Error GoTo bye

        s = ""
        s = s & vbCrLf & funcDropSQL(os.Name & "_BRIEF_F")
        s = s & vbCrLf & "create function " & os.Name & "_BRIEF_F  ("
        s = s & vbCrLf & " @" & os.Name & "id uniqueidentifier"
        'MLF
        s = s & vbCrLf & " ,@Lang varchar(25)=NULL"
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

        Debug.Print("SQLGEN.CreateBriefFuncHdr:done " & os.Caption)
        Exit Sub
bye:
        Debug.Print(Err.Description)
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume

    End Sub


    Private Sub FullTextSearch(ByRef obt As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        Debug.Print("SQLGEN.FullTextSearch:start " & obt.the_Comment)
        Dim s As String
        Dim i As Integer



        s = procDropSQL(obt.Name & "_SEARCH")
        s = s & vbCrLf & "create proc " & obt.Name & "_SEARCH(@cursession uniqueidentifier, @QueryResultID uniqueidentifier,@Filter nvarchar(2000)) as  "
        s = s & vbCrLf & "begin"
        s = s & vbCrLf & "declare @tmpID uniqueidentifier"
        s = s & vbCrLf & "declare @tmp2ID uniqueidentifier"
        s = s & vbCrLf & "declare @tmpFilter uniqueidentifier"
        s = s & vbCrLf & "set @tmpID= newid()"
        s = s & vbCrLf & "set @tmp2ID= newid()"

        s = s & vbCrLf & "delete from queryResult where queryResultid=@QueryResultID"

        If obt.AllowSearch = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Da Then
            s = s & vbCrLf & "Insert Into queryResult(queryResultid,result) select @tmp2ID,instanceid from instance where contains(*,@filter) and objtype='" & obt.Name & "'"
            For i = 1 To obt.PART.Count
                If Not obt.PART.Item(i).PartType = 3 Then
                    s = s & vbCrLf & FullTextPartSearch(obt.PART.Item(i))
                End If
            Next
            s = s & vbCrLf & "Insert Into queryResult(queryResultid,result) select distinct @queryResultid,result from queryResult where queryResultid=@tmp2ID"
            s = s & vbCrLf & "delete from queryResult where queryResultid=@tmp2ID"
        End If
        s = s & vbCrLf & "end"
        s = s & vbCrLf & "go"

        o.ModuleName = "--FullTextSearch"
        o.Block = "--body"
        o.OutNL(s)
        Debug.Print("SQLGEN.FullTextSearch:done " & obt.the_Comment)
    End Sub


    Private Sub CreateTypeProcs(ByRef obt As MTZMetaModel.MTZMetaModel.OBJECTTYPE)
        Debug.Print("SQLGEN.CreateTypeProcs:start " & obt.the_Comment)
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim s As Writer
        s = New Writer
        System.Windows.Forms.Application.DoEvents()

        s.putBuf(procDropSQL(obt.Name & "_DELETE"))
        s.putBuf("create proc " & obt.Name & "_DELETE(@cursession uniqueidentifier, @InstanceID uniqueidentifier) as  ")
        ' delete from root structure of object  - child of instance
        Dim tos As Short
        s.putBuf("declare @ObjType as varchar(255), @childlistid uniqueidentifier")
        s.putBuf("select  @ObjType =objtype from instance where instanceid=@instanceid")
        s.putBuf("if  @ObjType ='" & obt.Name & "'")
        s.putBuf("begin")
        If obt.PART.Count > 0 Then
            For tos = 1 To obt.PART.Count
                chos = obt.PART.Item(tos)
                If Not chos.PartType = 3 Then
                    s.putBuf("declare childlist_" & chos.Name & " cursor local for select " & chos.Name & "." & chos.Name & "id from " & chos.Name & " where  " & chos.Name & ".InstanceID = @instanceid")
                    s.putBuf("open childlist_" & chos.Name & "")
                    s.putBuf("fetch next from childlist_" & chos.Name & " into @childlistid")
                    s.putBuf("while @@fetch_status >=0 ")
                    s.putBuf("begin")
                    s.putBuf(" exec " & chos.Name & "_DELETE @cursession,@childlistid,@InstanceID")
                    s.putBuf(" if @@error >0 begin")
                    s.putBuf("   close childlist_" & chos.Name & "")
                    s.putBuf("   deallocate childlist_" & chos.Name & " ")
                    s.putBuf("   goto del_error")
                    s.putBuf(" end")
                    s.putBuf(" fetch next from childlist_" & chos.Name & " into @childlistid")
                    s.putBuf("end")
                    s.putBuf("close childlist_" & chos.Name & "")
                    s.putBuf("deallocate childlist_" & chos.Name & " ")
                End If
            Next
        End If
        s.putBuf("return")
        s.putBuf("del_error:")
        s.putBuf("if @@trancount>0 rollback tran")
        s.putBuf("end")
        s.putBuf("go")


        ' register root structure of object as child of instance
        s.putBuf(procDropSQL(obt.Name & "_REGISTER"))
        s.putBuf("create proc " & obt.Name & "_REGISTER(@cursession uniqueidentifier, @InstanceID uniqueidentifier) as  ")
        s.putBuf("declare @ObjType as varchar(255)")
        s.putBuf("declare @tmpStr as varchar(255)")
        s.putBuf("select  @ObjType =objtype from instance where instanceid=@instanceid")
        s.putBuf("if @objtype = '" & obt.Name & "'")
        s.putBuf(" begin")
        If obt.IsSingleInstance Then
            s.putBuf("if exists(select 1 from instance  where objtype=@objtype and instanceid<>@instanceid  )")
            s.putBuf(" begin")
            s.putBuf("    raiserror('Невозможно создать второй экземпляр документа типа: <%s>',16,1,@ObjType)")
            s.putBuf("    if @@trancount>0 rollback tran")
            s.putBuf("    return")
            s.putBuf(" End")
        End If
        'If obt.PART.Count = 0 Then
        s.putBuf(" select 1 /* do nothing */")
        'Else
        'For tos = 1 To obt.PART.Count
        's.putbuf "  set @tmpStr = convert(varchar(255),@instanceid)+'" & obt.PART.Item(tos).Name & "'"
        's.putbuf "  exec RegisterResource @cursession=@cursession,@parent=@instanceid,@the_Resource=@tmpStr"
        'Next
        'End If
        s.putBuf("end")
        s.putBuf("go")


        ' register root structure of object as child of instance
        s.putBuf(procDropSQL(obt.Name & "_HCL"))
        s.putBuf("create proc " & obt.Name & "_HCL(@cursession uniqueidentifier, @ROWID uniqueidentifier, @IsLocked integer out) as  ")
        s.putBuf("declare @ObjType as varchar(255)")
        s.putBuf("declare @tmpStr as varchar(255)")

        s.putBuf(" declare @UserID uniqueidentifier")
        s.putBuf(" declare @LockUserID uniqueidentifier")
        s.putBuf(" declare @LockSessionID uniqueidentifier")

        s.putBuf("select  @ObjType =objtype from instance where instanceid=@Rowid")
        s.putBuf("if @objtype = '" & obt.Name & "'")
        s.putBuf(" begin")

        Dim i As Integer
        If obt.PART.Count = 0 Then
            s.putBuf(" set @IsLocked =0")
        Else
            s.putBuf("if @@nestlevel < 25  begin")
            '---- проверяем, что нет заблокированных записей в  дочерних разделах
            s.putBuf("declare @childlistid uniqueidentifier")
            s.putBuf(" select @userID = usersid from the_session where the_sessionid=@cursession")
            For i = 1 To obt.PART.Count
                chos = obt.PART.Item(i)
                If Not chos.PartType = 3 Then
                    s.putBuf("declare lockchild_" & chos.Name & " cursor local for select " & chos.Name & "." & chos.Name & "id from " & chos.Name & " where  " & chos.Name & ".InstanceID = @rowid")
                    s.putBuf("open lockchild_" & chos.Name & "")
                    s.putBuf("fetch next from lockchild_" & chos.Name & " into @childlistid")
                    s.putBuf("while @@fetch_status >=0 ")
                    s.putBuf("begin")

                    ' если в дочернем разделе есть заблокированная строка
                    s.putBuf(" select @LockUserID = LockUserID,@LockSessionID = LockSessionID from " & chos.Name & " where " & chos.Name & "id=@childlistid")
                    s.putBuf(" /* verify this row */")
                    s.putBuf(" if not @LockUserID is null  ")
                    s.putBuf(" begin   ")
                    s.putBuf("   if  @LockUserID <> @userID  ")
                    s.putBuf("   begin   ")
                    s.putBuf("     set @isLocked = 4 /* CheckOut by another user */")
                    s.putBuf("     close lockchild_" & chos.Name & "")
                    s.putBuf("     deallocate lockchild_" & chos.Name & " ")
                    s.putBuf("     return")
                    s.putBuf("   end   ")
                    s.putBuf(" end   ")
                    s.putBuf(" if not @LockSessionID is null  ")
                    s.putBuf(" begin   ")
                    s.putBuf("   if  @LockSessionID <> @CURSESSION  ")
                    s.putBuf("   begin   ")
                    s.putBuf("     set @isLocked = 3 /* Lockes by another user */")
                    s.putBuf("     close lockchild_" & chos.Name & "")
                    s.putBuf("     deallocate lockchild_" & chos.Name & " ")
                    s.putBuf("     return")
                    s.putBuf("   end  ")
                    s.putBuf(" end   ")

                    ' или еще глубже
                    s.putBuf(" exec " & chos.Name & "_HCL @cursession,@childlistid,@isLocked out")
                    s.putBuf(" if @isLocked >2 begin")
                    s.putBuf("   close lockchild_" & chos.Name & "")
                    s.putBuf("   deallocate lockchild_" & chos.Name & " ")
                    s.putBuf("   return")
                    s.putBuf(" end")

                    s.putBuf(" fetch next from lockchild_" & chos.Name & " into @childlistid")
                    s.putBuf("end")
                    s.putBuf("close lockchild_" & chos.Name & "")
                    s.putBuf("deallocate lockchild_" & chos.Name & " ")
                End If
            Next
            s.putBuf(" end ")
            s.putBuf("set @IsLocked =0")
        End If
        s.putBuf("end")
        s.putBuf("go")


        ' register root structure of object as child of instance
        s.putBuf(procDropSQL(obt.Name & "_propagate"))
        s.putBuf("create proc " & obt.Name & "_propagate(@cursession uniqueidentifier, @ROWID uniqueidentifier) as  ")
        s.putBuf("declare @ObjType as varchar(255)")
        s.putBuf("declare @tmpStr as varchar(255)")

        s.putBuf("select  @ObjType =objtype from instance where instanceid=@Rowid")
        s.putBuf("if @objtype = '" & obt.Name & "'")
        s.putBuf(" begin")

        If obt.PART.Count = 0 Then
            s.putBuf("   select 1 '  do nothng")
            s.putBuf(" end")
        Else
            s.putBuf("if @@nestlevel < 30  begin")
            s.putBuf("declare @childlistid uniqueidentifier")
            s.putBuf("declare @ssid uniqueidentifier")
            s.putBuf(" select @SSID = securitystyleid from instance where instanceid=@RowID")
            For i = 1 To obt.PART.Count
                chos = obt.PART.Item(i)
                If Not chos.PartType = 3 Then
                    s.putBuf("declare propchild_" & chos.Name & " cursor local for select " & chos.Name & "." & chos.Name & "id from " & chos.Name & " where  " & chos.Name & ".InstanceID = @rowid")
                    s.putBuf("open propchild_" & chos.Name & "")
                    s.putBuf("fetch next from propchild_" & chos.Name & " into @childlistid")
                    s.putBuf("while @@fetch_status >=0 ")
                    s.putBuf("begin")
                    s.putBuf(" exec " & chos.Name & "_SINIT @cursession,@childlistid,@ssid")
                    s.putBuf(" exec " & chos.Name & "_propagate @cursession,@childlistid")
                    s.putBuf(" fetch next from propchild_" & chos.Name & " into @childlistid")
                    s.putBuf("end")
                    s.putBuf("close propchild_" & chos.Name & "")
                    s.putBuf("deallocate propchild_" & chos.Name & " ")
                End If
            Next
            s.putBuf(" end ")
        End If

        s.putBuf("end")
        s.putBuf("go")


        log = log & vbCrLf & "Create common procs for type " & obt.Name
        o.ModuleName = "--Procs"
        o.Block = "--body"
        o.OutNL(s.getBuf)
        o.OutNL("GO")
        Debug.Print("SQLGEN.CreateTypeProcs:done " & obt.the_Comment)
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
    End Sub


    Private Sub MakeAllViews(ByRef ppart As MTZMetaModel.MTZMetaModel.PART)
        Debug.Print("SQLGEN.MakeAllViews:start " & ppart.Caption)
        If ppart.PartType = 3 Then
            Debug.Print("SQLGEN.MakeAllViews:skipped " & ppart.Caption)
            Exit Sub
        End If
        Dim i As Integer
        Dim j As Integer
        For i = 1 To ppart.PARTVIEW.Count
            MakeViews(ppart.PARTVIEW.Item(i), String.Empty)
            Dim parent As MTZMetaModel.MTZMetaModel.Application = ppart.Application
            Dim li_col As MTZMetaModel.MTZMetaModel.LocalizeInfo_col = parent.LocalizeInfo
            For j = 1 To li_col.Count
                MakeViews(ppart.PARTVIEW.Item(i), parent.LocalizeInfo.Item(j).LangShort)
            Next
        Next
        Debug.Print("SQLGEN.MakeAllViews:children " & ppart.Caption)
        For i = 1 To ppart.PART.Count
            MakeAllViews(ppart.PART.Item(i))
        Next
        Debug.Print("SQLGEN.MakeAllViews:done " & ppart.Caption)
    End Sub

    'UPGRADE_NOTE: pv was upgraded to pv_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub MakeViews_PutColumns(ByRef pv_Renamed As MTZMetaModel.MTZMetaModel.PARTVIEW, ByRef fcnt As Integer, ByRef s As Writer, ByRef from As String, ByRef log As String, ByRef noagg As Integer, ByRef group As String, ByRef BP As MTZMetaModel.MTZMetaModel.PART, ByRef root As MTZMetaModel.MTZMetaModel.PART, Optional ByRef NoFirstTable As Boolean = False, Optional ByRef Lang As String = "")
        Dim i As Object
        Dim j As Integer
        Dim vc As MTZMetaModel.MTZMetaModel.ViewColumn
        Dim refp As MTZMetaModel.MTZMetaModel.PART
        Dim p As MTZMetaModel.MTZMetaModel.PART = Nothing
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        Dim f As MTZMetaModel.MTZMetaModel.FIELD

        Dim isOK As Boolean
        For i = 1 To pv_Renamed.ViewColumn.Count
            vc = pv_Renamed.ViewColumn.Item(i)
            p = vc.FromPart
            f = vc.Field
            If Not (p Is Nothing) And Not (f Is Nothing) Then
                fcnt = fcnt + 1
                '      If fcnt > 1 Then
                s.putBuf(", ")
                '      End If
                If vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_none Then
                    ft = f.FieldType
                    If ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Perecislenie Then
                        ' вписываем значение перечсления
                        s.putBuf(" " & p.Name & "." & f.Name & "  ")
                        s.putBuf(vc.the_Alias & "_VAL, ")

                        ' и его расшифровку
                        s.putBuf(" case " & p.Name & "." & f.Name & " ")
                        For j = 1 To ft.ENUMITEM.Count
                            s.putBuf("when " & ft.ENUMITEM.Item(j).NameValue & " then '" & ft.ENUMITEM.Item(j).Name & "'")
                        Next
                        s.putBuf(" end ")

                    ElseIf ft.TypeStyle = MTZMetaModel.MTZMetaModel.enumTypeStyle.TypeStyle_Ssilka Then
                        ' вписываем значение ссылки
                        s.putBuf(" " & p.Name & "." & f.Name & "  ")
                        s.putBuf(vc.the_Alias & "_ID, ")

                        ' и расшифрованное значение
                        If f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_ob_ekt_ Then
                            'MLF
                            If Lang = "" Then
                                s.putBuf(" dbo.INSTANCE_BRIEF_F(" & p.Name & "." & f.Name & ")") ', NULL) "
                            Else
                                s.putBuf(" dbo.INSTANCE_BRIEF_F(" & p.Name & "." & f.Name & ")") ', '" + Lang + "') "
                            End If
                        ElseIf f.ReferenceType = MTZMetaModel.MTZMetaModel.enumReferenceType.ReferenceType_Na_stroku_razdela Then
                            refp = f.RefToPart
                            'MLF
                            If Lang = "" Then
                                s.putBuf(" dbo." & refp.Name & "_BRIEF_F(" & p.Name & "." & f.Name & ", NULL) ")
                            Else
                                s.putBuf(" dbo." & refp.Name & "_BRIEF_F(" & p.Name & "." & f.Name & ", '" & Lang & "') ")
                            End If
                        Else
                            s.putBuf(p.Name & "." & f.Name & " ")
                        End If
                    Else

                        'MLF s.putBuf p.Name & "." & f.Name & " "
                        s.putBuf(GetFullFieldName(f, p, Lang) & " ")
                    End If


                    noagg = noagg + 1
                    group = group & vbCrLf & "," & p.Name & "." & f.Name & " "
                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_MAX Then
                    'MLF s.putBuf "MAX(" & p.Name & "." & f.Name & ") "
                    s.putBuf("MAX(" & GetFullFieldName(f, p, Lang) & ") ")

                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_MIN Then
                    'MLF s.putBuf "MIN(" & p.Name & "." & f.Name & ") "
                    s.putBuf("MIN(" & GetFullFieldName(f, p, Lang) & ") ")
                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_AVG Then
                    'MLF s.putBuf "AVG(" & p.Name & "." & f.Name & ") "
                    s.putBuf("AVG(" & GetFullFieldName(f, p, Lang) & ") ")
                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_SUM Then
                    'MLF s.putBuf "SUM(" & p.Name & "." & f.Name & ") "
                    s.putBuf("SUM(" & GetFullFieldName(f, p, Lang) & ") ")
                ElseIf vc.Aggregation = MTZMetaModel.MTZMetaModel.enumAggregationType.AggregationType_COUNT Then
                    'MLF s.putBuf "COUNT(" & p.Name & "." & f.Name & ") "
                    s.putBuf("COUNT(" & GetFullFieldName(f, p, Lang) & ") ")
                End If
                s.putBuf(vc.the_Alias & " ")

                'UPGRADE_WARNING: Couldn't resolve default property of object p.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If BP.ID = p.Parent.Parent.ID Then
                    isOK = False

                    ' проверяем поля, которые входят в раздел
                    'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    For j = 1 To i - 1

                        'UPGRADE_WARNING: Couldn't resolve default property of object pv_Renamed.ViewColumn.Item(j).FromPart.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        If pv_Renamed.ViewColumn.Item(j).FromPart.ID = p.ID Then
                            isOK = True
                            Exit For
                        End If
                    Next

                    ' если в разделе есть поля, то включаем его в запрос
                    If Not isOK Then
                        from = from & vbCrLf & " left join " & p.Name & " on " & BP.Name & "." & BP.Name & "ID = " & p.Name & ".ParentStructRowID"
                    End If
                End If


                ' проверяем верхние разделы, которые не  являются непосредственными родителями нашего базового раздела
                'UPGRADE_WARNING: Couldn't resolve default property of object p.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                If TypeName(p.Parent.Parent) = "OBJECTTYPE" And (p.ID <> root.ID) Then
                    isOK = False
                    'UPGRADE_WARNING: Couldn't resolve default property of object i. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    For j = 1 To i - 1
                        'UPGRADE_WARNING: Couldn't resolve default property of object pv_Renamed.ViewColumn.Item(j).FromPart.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        If pv_Renamed.ViewColumn.Item(j).FromPart.ID = p.ID Then
                            isOK = True
                            Exit For
                        End If
                    Next
                    ' есть поля из верхнего раздела
                    If Not isOK Then
                        from = from & vbCrLf & " left join " & p.Name & " ON " & p.Name & ".InstanceID=" & root.Name & ".InstanceID"
                    End If
                End If

            Else
                log = log & vbCrLf & "ERROR-->Ошибка определения запроса:" & pv_Renamed.Name & "(" & pv_Renamed.the_Alias & ")" & " колонка: " & vc.the_Alias & " - не задан раздел, или поле.<--ERROR"
            End If
        Next
        'MLF
        If Lang <> "" And IsMLFPart(p) Then
            from = from & vbCrLf & " left join " & p.Name & "_" & Lang & " ON " & p.Name & "." & p.Name & "ID=" & p.Name & "_" & Lang & "." & p.Name & "ID"
        End If

    End Sub

    'MLF
    Private Function GetFullFieldName(ByRef f As MTZMetaModel.MTZMetaModel.FIELD, ByRef p As MTZMetaModel.MTZMetaModel.PART, ByRef Lang As String) As String
        '" & p.Name & "." & f.Name & "
        If IsMLFField(f) And Lang <> "" Then
            GetFullFieldName = p.Name & "_" & Lang & "." & f.Name
        Else
            GetFullFieldName = p.Name & "." & f.Name
        End If
    End Function

    'UPGRADE_NOTE: pv was upgraded to pv_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub MakeViews(ByRef pv_Renamed As MTZMetaModel.MTZMetaModel.PARTVIEW, ByRef Lang As String)
        Debug.Print("SQLGEN.MakeViews:start " & pv_Renamed.Name)
        Dim s As Writer
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
        On Error GoTo bye

        'UPGRADE_WARNING: Couldn't resolve default property of object pv_Renamed.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        BP = pv_Renamed.Parent.Parent

        s = New Writer

        ' найти раздел первого уровня и построить цепочку прямых join
        root = BP
        from = " from " & BP.Name
        structfld = BP.Name & "ID"
        'UPGRADE_WARNING: Couldn't resolve default property of object root.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        While TypeName(root.Parent.Parent) <> "OBJECTTYPE"
            'UPGRADE_WARNING: Couldn't resolve default property of object root.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            from = from & vbCrLf & " join " & root.Parent.Parent.Name & " on " & root.Parent.Parent.Name & "." & root.Parent.Parent.Name & "ID=" & root.Name & ".ParentStructRowID "
            'UPGRADE_WARNING: Couldn't resolve default property of object root.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            structfld = structfld & ", " & root.Parent.Parent.Name & "ID"
            'UPGRADE_WARNING: Couldn't resolve default property of object root.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            root = root.Parent.Parent
        End While

        from = from & vbCrLf & " join INSTANCE on " & root.Name & ".INSTANCEID=INSTANCE.INSTANCEID"
        from = from & vbCrLf & " left join objstatus XXXMYSTATUSXXX on instance.status=XXXMYSTATUSXXX.objstatusid"

        group = " group by " & root.Name & ".InstanceID, " & BP.Name & "." & BP.Name & "ID "

        ' стандартное начало
        If Lang <> "" Then
            s.putBuf(viewDropSQL("V_" & pv_Renamed.the_Alias & "_" & Lang))
            s.putBuf("create view V_" & pv_Renamed.the_Alias & "_" & Lang & " as ")
        Else
            s.putBuf(viewDropSQL("V_" & pv_Renamed.the_Alias))
            s.putBuf("create view V_" & pv_Renamed.the_Alias & " as ")
        End If
        'MLF
        '  If Lang <> "" Then
        '    s.putBuf "select   " & BP.Name & "_" & Lang & "." & structfld
        '  Else
        s.putBuf("select   " & BP.Name & "." & structfld)
        '  End If
        Dim fcnt As Integer
        fcnt = 0
        MakeViews_PutColumns(pv_Renamed, fcnt, s, from, log, noagg, group, BP, root, , Lang)
        '  For i = 1 To pv.ViewColumn.Count
        '    Set vc = pv.ViewColumn.Item(i)
        '    Set p = vc.FromPart
        '    Set f = vc.FIELD
        '    If Not (p Is Nothing) And Not (f Is Nothing) Then
        '      fcnt = fcnt + 1
        ''      If fcnt > 1 Then
        '        s.putBuf ", "
        ''      End If
        '      If vc.Aggregation = AggregationType_none Then
        '        Set ft = f.FIELDTYPE
        '        If ft.TypeStyle = TypeStyle_Perecislenie Then
        '          ' вписываем значение перечсления
        '          s.putBuf " " & p.Name & "." & f.Name & "  "
        '          s.putBuf vc.the_Alias & "_VAL, "
        '
        '          ' и его расшифровку
        '          s.putBuf " case " & p.Name & "." & f.Name & " "
        '          For j = 1 To ft.ENUMITEM.Count
        '            s.putBuf "when " & ft.ENUMITEM.Item(j).NameValue & " then '" & ft.ENUMITEM.Item(j).Name & "'"
        '          Next
        '          s.putBuf " end "
        '
        '        ElseIf ft.TypeStyle = TypeStyle_Ssilka Then
        '          ' вписываем значение ссылки
        '          s.putBuf " " & p.Name & "." & f.Name & "  "
        '          s.putBuf vc.the_Alias & "_ID, "
        '
        '          ' и расшифрованное значение
        '          If f.ReferenceType = ReferenceType_Na_ob_ekt_ Then
        '            s.putBuf " dbo.INSTANCE_BRIEF_F(" & p.Name & "." & f.Name & ") "
        '          ElseIf f.ReferenceType = ReferenceType_Na_stroku_razdela Then
        '            Set refp = f.RefToPart
        '            s.putBuf " dbo." & refp.Name & "_BRIEF_F(" & p.Name & "." & f.Name & ") "
        '          Else
        '            s.putBuf p.Name & "." & f.Name & " "
        '          End If
        '        Else
        '
        '          s.putBuf p.Name & "." & f.Name & " "
        '        End If
        '
        '
        '        noagg = noagg + 1
        '        group = group & vbCrLf & "," & p.Name & "." & f.Name & " "
        '      ElseIf vc.Aggregation = AggregationType_MAX Then
        '         s.putBuf "MAX(" & p.Name & "." & f.Name & ") "
        '      ElseIf vc.Aggregation = AggregationType_MIN Then
        '        s.putBuf "MIN(" & p.Name & "." & f.Name & ") "
        '      ElseIf vc.Aggregation = AggregationType_AVG Then
        '        s.putBuf "AVG(" & p.Name & "." & f.Name & ") "
        '      ElseIf vc.Aggregation = AggregationType_SUM Then
        '        s.putBuf "SUM(" & p.Name & "." & f.Name & ") "
        '      ElseIf vc.Aggregation = AggregationType_COUNT Then
        '        s.putBuf "COUNT(" & p.Name & "." & f.Name & ") "
        '      End If
        '      s.putBuf vc.the_Alias & " "
        '      Dim isOK As Boolean
        '
        '      If BP.ID = p.Parent.Parent.ID Then
        '        isOK = False
        '
        '        ' проверяем поля, которые входят в раздел
        '        For j = 1 To i - 1
        '
        '          If pv.ViewColumn.Item(j).FromPart.ID = p.ID Then
        '            isOK = True
        '            Exit For
        '          End If
        '        Next
        '
        '        ' если в разделе есть поля, то включаем его в запрос
        '        If Not isOK Then
        '          from = from & vbCrLf & " left join " & p.Name & " on " & BP.Name & "." & BP.Name & "ID = " & p.Name & ".ParentStructRowID"
        '        End If
        '      End If
        '
        '
        '      ' проверяем верхние разделы, которые не  являются непосредственными родителями нашего базового раздела
        '      If TypeName(p.Parent.Parent) = "OBJECTTYPE" And (p.ID <> root.ID) Then
        '        isOK = False
        '        For j = 1 To i - 1
        '          If pv.ViewColumn.Item(j).FromPart.ID = p.ID Then
        '            isOK = True
        '            Exit For
        '          End If
        '        Next
        '        ' есть поля из верхнего раздела
        '        If Not isOK Then
        '          from = from & vbCrLf & " left join " & p.Name & " ON " & p.Name & ".InstanceID=" & root.Name & ".InstanceID"
        '        End If
        '      End If
        '    Else
        '    log = log & vbCrLf & "ERROR-->Ошибка определения запроса:" & pv.Name & "(" & pv.the_Alias & ")" & " колонка: " & vc.the_Alias & " - не задан раздел, или поле.<--ERROR"
        '    End If
        '  Next
        'Все поля забиты... Ищем еще поля...

        MakeLinkedView(pv_Renamed, s, from, log, group, Lang)

        If fcnt > 0 Then
            s.putBuf(", " & root.Name & ".InstanceID InstanceID ")
        Else
            s.putBuf(" " & root.Name & ".InstanceID InstanceID ")
        End If

        s.putBuf(", " & BP.Name & "." & BP.Name & "ID ID ")
        s.putBuf(", '" & BP.Name & "' VIEWBASE ")
        s.putBuf(", XXXMYSTATUSXXX.Name StatusName ")
        s.putBuf(", XXXMYSTATUSXXX.objstatusid INTSANCEStatusID")


        ' if no aggregations - no group by
        If noagg = pv_Renamed.ViewColumn.Count Then group = ""

        o.ModuleName = "--Views--"
        o.Block = "--Views--"
        o.OutNL(s.getBuf & vbCrLf & from & vbCrLf & group)
        o.OutNL("GO")
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        Debug.Print("SQLGEN.MakeViews:done " & pv_Renamed.Name)
        Exit Sub
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        Debug.Print(Err.Description)
        ' Stop
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        Exit Sub
        Resume
    End Sub

    'UPGRADE_NOTE: pv was upgraded to pv_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub MakeLinkedView(ByRef pv_Renamed As MTZMetaModel.MTZMetaModel.PARTVIEW, ByRef s As Writer, ByRef from As String, ByRef log As String, ByRef group As String, Optional ByRef Lang As String = "")
        Dim i As Integer

        pv_Renamed.PARTVIEW_LNK.Sort = "SEQ"

        Dim PVD As MTZMetaModel.MTZMetaModel.PARTVIEW
        Dim fcnt2 As Integer
        Dim noagg2 As Integer
        Dim BP2 As MTZMetaModel.MTZMetaModel.PART
        Dim root2 As MTZMetaModel.MTZMetaModel.PART
        Dim fromAddings As String = String.Empty
        Dim structfld2 As String = String.Empty
        For i = 1 To pv_Renamed.PARTVIEW_LNK.Count
            PVD = pv_Renamed.PARTVIEW_LNK.Item(i).TheView
            'UPGRADE_WARNING: Couldn't resolve default property of object PVD.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            BP2 = PVD.Parent.Parent
            ' найти раздел первого уровня и построить цепочку прямых join
            root2 = BP2

            structfld2 = BP2.Name & "ID"
            'UPGRADE_WARNING: Couldn't resolve default property of object root2.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
            While TypeName(root2.Parent.Parent) <> "OBJECTTYPE"
                'UPGRADE_WARNING: Couldn't resolve default property of object root2.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                fromAddings = fromAddings & vbCrLf & " join " & root2.Parent.Parent.Name & " on " & root2.Parent.Parent.Name & "." & root2.Parent.Parent.Name & "ID=" & root2.Name & ".ParentStructRowID "
                'UPGRADE_WARNING: Couldn't resolve default property of object root2.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                structfld2 = structfld2 & ", " & root2.Parent.Parent.Name & "ID"
                'UPGRADE_WARNING: Couldn't resolve default property of object root2.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                root2 = root2.Parent.Parent
            End While

            'MLF
            Dim part As MTZMetaModel.MTZMetaModel.PARTVIEW_LNK = pv_Renamed.PARTVIEW_LNK.Item(i)
            Dim viewcolumn As MTZMetaModel.MTZMetaModel.ViewColumn = part.TheJoinSource
            Dim fld As MTZMetaModel.MTZMetaModel.FIELD = viewcolumn.Field

            If pv_Renamed.PARTVIEW_LNK.Item(i).RefType = MTZMetaModel.MTZMetaModel.enumJournalLinkType.JournalLinkType_Ssilka_na_ob_ekt Then
                from = CStr((from & vbCrLf & " left join ") + PVD.Parent.Parent.Name + (" on ") + (root2.Name) + (".InstanceID=") + pv_Renamed.Parent.Parent.Name + (".") + fld.Name + (" "))
            ElseIf pv_Renamed.PARTVIEW_LNK.Item(i).RefType = MTZMetaModel.MTZMetaModel.enumJournalLinkType.JournalLinkType_Ssilka_na_stroku Then
                from = CStr((from & vbCrLf & " left join ") + PVD.Parent.Parent.Name + (" on ") + (root2.Name) + (".InstanceID=") + pv_Renamed.Parent.Parent.Name + (".") + fld.Name + (" "))
            ElseIf pv_Renamed.PARTVIEW_LNK.Item(i).RefType = MTZMetaModel.MTZMetaModel.enumJournalLinkType.JournalLinkType_Svyzka_InstanceID_OPNv_peredlah_ob_ektaCLS Then
                'UPGRADE_WARNING: Couldn't resolve default property of object PVD.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object pv_Renamed.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                from = CStr((from & vbCrLf & " left join ") + PVD.Parent.Parent.Name + (" on ") + pv_Renamed.Parent.Parent.Name + (".InstanceID=") + PVD.Parent.Parent.Name + (".") + ("InstanceID "))
            ElseIf pv_Renamed.PARTVIEW_LNK.Item(i).RefType = MTZMetaModel.MTZMetaModel.enumJournalLinkType.JournalLinkType_Svyzka_ParentStructRowID__OPNv_peredlah_ob_ektaCLS Then
                'UPGRADE_WARNING: Couldn't resolve default property of object PVD.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: Couldn't resolve default property of object pv_Renamed.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                from = CStr((from & vbCrLf & " left join ") + PVD.Parent.Parent.Name + (" on ") + pv_Renamed.Parent.Parent.Name + (".") + pv_Renamed.Parent.Parent.Name + (".") + ("=") + PVD.Parent.Parent.Name + (".") + ("ParentStructRowID "))
            Else
                Exit For
            End If

            from = from & vbCrLf & fromAddings

            MakeViews_PutColumns(PVD, fcnt2, s, from, log, noagg2, group, BP2, root2, , Lang)
            MakeLinkedView(PVD, s, from, log, group, Lang)
        Next
    End Sub

    Private Function IsParent(ByRef p As MTZMetaModel.MTZMetaModel.PART, ByRef Parent As String) As Boolean
        Dim o As Object
        o = p
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        While TypeName(o) <> "OBJECTTYPE"
            'UPGRADE_WARNING: Couldn't resolve default property of object o.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            o = o.Parent.Parent
            'UPGRADE_WARNING: Couldn't resolve default property of object o.ID. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If o.ID = Parent Then
                IsParent = True
                Exit Function
            End If
        End While
        IsParent = False

    End Function

    ' создаем view для журналов
    Private Sub MakeJournals()
        '  DebugOutput "SQLGEN.MakeJournals:start "
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
        '      s = s & vbCrLf & " from V_" & js.PARTVIEW.the_Alias
        '
        '    Next j
        '    o.Module = "--Journals--"
        '    o.Block = "--Journals--"
        '    o.OutNL s
        '    o.OutNL "GO"
        '  Next i
        '  DebugOutput "SQLGEN.MakeJournals:done "
    End Sub



    Private Sub CreateV2Proc(ByRef os As MTZMetaModel.MTZMetaModel.PART)
        Debug.Print("SQLGEN.CreateV2Proc:start " & os.Caption)
        If os.PartType = 3 Then
            Debug.Print("SQLGEN.CreateV2Proc:skipped " & os.Caption)
            Exit Sub
        End If

        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i As Short
        Dim s As Writer
        s = New Writer

        System.Windows.Forms.Application.DoEvents()
        log = log & vbCrLf & "-->CreateV2Proc " & os.Name

        On Error GoTo bye


        s.putBuf(procDropSQL(os.Name & "_PARENT"))
        s.putBuf("create proc " & os.Name & "_PARENT /*" & os.the_Comment & "*/ (")
        s.putBuf(" @CURSESSION uniqueidentifier,")
        s.putBuf(" @RowID uniqueidentifier ,")
        s.putBuf(" @ParentID uniqueidentifier output,")
        s.putBuf(" @ParentTable varchar(255) output")

        s.putBuf(") as " & " begin  ")

        s.putBuf("set nocount on")


        s.putBuf(" -- checking session  --")
        s.putBuf("if not exists( select 1 from the_session where the_sessionid=@cursession and closed=0 )")
        s.putBuf("  begin")
        s.putBuf("    raiserror('Сессия уже завершена.',16,1)")
        s.putBuf("    return")
        s.putBuf("  end")

        '  If os.PartType = PartType_Derevo Then
        '      ' дерево - родительская связь
        '      s.putbuf "  select @ParentID = ParentRowid from " & os.Name & " where  " & os.Name & "id=@RowID"
        '      s.putbuf "  IF @ParentID IS NULL"
        '      s.putbuf "  BEGIN"
        '
        '      ' переходим границы раздела
        '      If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
        '        s.putbuf "  set @ParentTable = 'INSTANCE'"
        '        s.putbuf "  select @ParentID = INSTANCEID from " & os.Name & " where  " & os.Name & "id=@RowID"
        '      Else
        '        s.putbuf "  select @ParentID = ParentStructRowID from " & os.Name & " where  " & os.Name & "id=@RowID"
        '        s.putbuf "  set @ParentTable = '" & os.Parent.Parent.Name & "'"
        '      End If
        '
        '      s.putbuf "  END"
        '      s.putbuf "  else"
        '      s.putbuf "  BEGIN"
        '      s.putbuf "    set @ParentTable = '" & os.Name & "'"
        '      s.putbuf "  END"
        '  Else
        'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
        If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
            s.putBuf("  set @ParentTable = 'INSTANCE'")
            s.putBuf("  select @ParentID = INSTANCEID from " & os.Name & " where  " & os.Name & "id=@RowID")
        Else

            s.putBuf("  select @ParentID = ParentStructRowID from " & os.Name & " where  " & os.Name & "id=@RowID")
            'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            s.putBuf("  set @ParentTable = '" & os.Parent.Parent.Name & "'")
        End If
        ' End If

        s.putBuf(" end ")




        o.ModuleName = "--Procedures"
        o.Block = "--TableProc"
        o.OutNL(s.getBuf)
        o.OutNL("GO")


        '------------------------------- IsLockED ----------------------------------------------
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        s = New Writer
        s.putBuf(procDropSQL(os.Name & "_ISLOCKED"))
        s.putBuf("create proc " & os.Name & "_ISLOCKED /*" & os.the_Comment & "*/ (")
        s.putBuf(" @CURSESSION uniqueidentifier,")
        s.putBuf(" @RowID uniqueidentifier ,")
        s.putBuf(" @IsLocked integer output")
        s.putBuf(") as " & " begin  ")
        s.putBuf("set nocount on")
        s.putBuf(" declare @ParentID uniqueidentifier")
        s.putBuf(" declare @UserID uniqueidentifier")
        s.putBuf(" declare @LockUserID uniqueidentifier")
        s.putBuf(" declare @LockSessionID uniqueidentifier")
        s.putBuf(" declare @ParentTable varchar(255) ")

        s.putBuf(" set @isLocked = 0")
        s.putBuf(" -- checking session  --")
        s.putBuf("if not exists( select 1 from the_session where the_sessionid=@cursession and closed=0 )")
        s.putBuf("  begin")
        s.putBuf("    raiserror('Сессия уже завершена.',16,1)")
        s.putBuf("    return")
        s.putBuf("  end")

        s.putBuf(" select @userID = usersid  from the_session where the_sessionid=@cursession")
        s.putBuf(" select @LockUserID = LockUserID,@LockSessionID = LockSessionID from " & os.Name & " where " & os.Name & "id=@RowID")
        s.putBuf(" /* verify this row */")
        s.putBuf(" if not @LockUserID is null  ")
        s.putBuf(" begin   ")
        s.putBuf("   if  @LockUserID <> @userID  ")
        s.putBuf("   begin   ")
        s.putBuf("     set @isLocked = 4 /* CheckOut by another user */")
        s.putBuf("     return")
        s.putBuf("   end   else ")
        s.putBuf("   begin   ")
        s.putBuf("     set @isLocked = 2 /* CheckOut by caller */")
        s.putBuf("     return")
        s.putBuf("   end   ")
        s.putBuf(" end   ")

        s.putBuf(" if not @LockSessionID is null  ")
        s.putBuf(" begin   ")
        s.putBuf("   if  @LockSessionID <> @CURSESSION  ")
        s.putBuf("   begin   ")
        s.putBuf("     set @isLocked = 3 /* Lockes by another user */")
        s.putBuf("     return")
        s.putBuf("   end   else ")
        s.putBuf("   begin   ")
        s.putBuf("     set @isLocked = 1 /* Locked by caller */")
        s.putBuf("     return")
        s.putBuf("   end   ")
        s.putBuf(" end   ")

        s.putBuf(" set @isLocked = 0 ")
        s.putBuf("if @@nestlevel <25 begin")
        s.putBuf("  declare @s nvarchar(4000)")
        s.putBuf("  exec " & os.Name & "_parent @CURSESSION,@ROWID,@ParentID output ,@ParentTable output")
        s.putBuf("  set @s = N' exec ' + @PARENTTABLE + N'_islocked @cursession,@rowid,@islocked OUTPUT'")
        s.putBuf("  exec sp_executesql @s,N'@CURSESSION uniqueidentifier ,@RowID uniqueidentifier,@IsLocked int out',@CURSESSION,@ParentID ,@ISLocked output")
        s.putBuf("end")
        s.putBuf(" end ")


        o.ModuleName = "--Procedures"
        o.Block = "--TableProc"
        o.OutNL(s.getBuf)
        o.OutNL("GO")

        '--------------------------- Блокируем запись
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        s = New Writer
        s.putBuf(procDropSQL(os.Name & "_LOCK"))
        s.putBuf("create proc " & os.Name & "_LOCK /*" & os.the_Comment & "*/ (")
        s.putBuf(" @CURSESSION uniqueidentifier,")
        s.putBuf(" @RowID uniqueidentifier ,")
        s.putBuf(" @LockMode integer ")
        s.putBuf(") as " & " begin  ")
        s.putBuf("set nocount on")
        s.putBuf(" declare @ParentID uniqueidentifier")
        s.putBuf(" declare @UserID uniqueidentifier")
        s.putBuf(" declare @tmpID uniqueidentifier")
        s.putBuf(" declare @access integer")
        s.putBuf(" declare @IsLocked integer")
        s.putBuf(" declare @ParentTable varchar(255) ")

        s.putBuf(" -- checking session  --")
        s.putBuf("if not exists( select 1 from the_session where the_sessionid=@cursession and closed=0 )")
        s.putBuf("  begin")
        s.putBuf("    raiserror('Сессия уже завершена.',16,1)")
        s.putBuf("    return")
        s.putBuf("  end")

        s.putBuf(" select @userID = usersid  from the_session where the_sessionid=@cursession")
        s.putBuf(" exec " & os.Name & "_ISLOCKED @CURSESSION,@ROWID,@ISLocked out")
        s.putBuf(" if @IsLocked >=3  ")
        s.putBuf("  begin")
        s.putBuf("    raiserror('Строка заблокирована другим пользователем',16,1)")
        s.putBuf("    return")
        s.putBuf("  end")

        s.putBuf(" if @IsLocked =0  ")
        s.putBuf(" begin")
        s.putBuf("  exec " & os.Name & "_HCL @cursession,@RowID,@isLocked out")
        s.putBuf("  if @IsLocked >=3  ")
        s.putBuf("   begin")
        s.putBuf("     raiserror('У данной строки имеются дочерние строки, которые заблокированы другим пользователем',16,1)")
        s.putBuf("     return")
        s.putBuf("   end")
        s.putBuf(" end")


        s.putBuf(" select  @tmpID =SecurityStyleID from " & os.Name & " where " & os.Name & "id=@ROWID")
        s.putBuf(" exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='LOCKROW',@access=@access out ")
        s.putBuf(" if @access=0 ")
        s.putBuf("  begin")
        s.putBuf("    raiserror('Нет прав на блокировку строк. Раздел=" & os.Name & "',16,1)")
        s.putBuf("    if @@trancount>0 rollback tran")
        s.putBuf("    return")
        s.putBuf("  end")



        s.putBuf("   if  @LockMode =2  ")
        s.putBuf("   begin   ")
        s.putBuf("    update " & os.Name & " set LockUserID =@userID ,LockSessionID =null where " & os.Name & "id=@RowID")
        s.putBuf("     return")
        s.putBuf("   end ")

        s.putBuf("   if  @LockMode =1  ")
        s.putBuf("   begin   ")
        s.putBuf("    update " & os.Name & " set LockUserID =null,LockSessionID =@CURSESSION  where " & os.Name & "id=@RowID")
        s.putBuf("     return")
        s.putBuf("   end ")

        s.putBuf(" end ")


        o.ModuleName = "--Procedures"
        o.Block = "--TableProc"
        o.OutNL(s.getBuf)
        o.OutNL("GO")


        '--------------------------- HCL - Has Children Locked

        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        s = New Writer
        s.putBuf(procDropSQL(os.Name & "_HCL"))
        s.putBuf("create proc " & os.Name & "_HCL /*" & os.the_Comment & "*/ (")
        s.putBuf(" @CURSESSION uniqueidentifier,")
        s.putBuf(" @RowID uniqueidentifier ,")
        s.putBuf(" @IsLocked integer out")
        s.putBuf(") as " & " begin  ")
        s.putBuf("set nocount on")

        '---- проверяем, что нет заблокированных записей в  дочерних разделах
        s.putBuf("declare @childlistid uniqueidentifier")
        s.putBuf(" declare @UserID uniqueidentifier")
        s.putBuf(" declare @LockUserID uniqueidentifier")
        s.putBuf(" declare @LockSessionID uniqueidentifier")
        s.putBuf(" select @userID = usersid  from the_session where the_sessionid=@cursession")

        If os.PART.Count > 0 Then
            s.putBuf("-- verify child locks")
        End If

        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            If Not chos.PartType = 3 Then
                s.putBuf("declare lockchild_" & chos.Name & " cursor local for select " & chos.Name & "." & chos.Name & "id from " & chos.Name & " where  " & chos.Name & ".ParentStructRowID = @Rowid")
                s.putBuf("open lockchild_" & chos.Name & "")
                s.putBuf("fetch next from lockchild_" & chos.Name & " into @childlistid")
                s.putBuf("while @@fetch_status >=0 ")
                s.putBuf("begin")

                ' если в дочернем разделе есть заблокированная строка
                s.putBuf(" select @LockUserID = LockUserID,@LockSessionID = LockSessionID from " & chos.Name & " where " & chos.Name & "id=@childlistid")
                s.putBuf(" /* verify this row */")
                s.putBuf(" if not @LockUserID is null  ")
                s.putBuf(" begin   ")
                s.putBuf("   if  @LockUserID <> @userID  ")
                s.putBuf("   begin   ")
                s.putBuf("     set @isLocked = 4 /* CheckOut by another user */")
                s.putBuf("     close lockchild_" & chos.Name & "")
                s.putBuf("     deallocate lockchild_" & chos.Name & " ")
                s.putBuf("     return")
                s.putBuf("   end   ")
                s.putBuf(" end   ")
                s.putBuf(" if not @LockSessionID is null  ")
                s.putBuf(" begin   ")
                s.putBuf("   if  @LockSessionID <> @CURSESSION  ")
                s.putBuf("   begin   ")
                s.putBuf("     set @isLocked = 3 /* Lockes by another user */")
                s.putBuf("     close lockchild_" & chos.Name & "")
                s.putBuf("     deallocate lockchild_" & chos.Name & " ")
                s.putBuf("     return")
                s.putBuf("   end  ")
                s.putBuf(" end   ")

                ' или еще глубже
                s.putBuf("if @@nestlevel <25 begin")
                s.putBuf(" exec " & chos.Name & "_HCL @cursession,@childlistid,@isLocked out")
                s.putBuf(" if @isLocked >2 begin")
                s.putBuf("   close lockchild_" & chos.Name & "")
                s.putBuf("   deallocate lockchild_" & chos.Name & " ")
                s.putBuf("   return")
                s.putBuf(" end")
                s.putBuf("end")

                s.putBuf(" fetch next from lockchild_" & chos.Name & " into @childlistid")
                s.putBuf("end")
                s.putBuf("close lockchild_" & chos.Name & "")
                s.putBuf("deallocate lockchild_" & chos.Name & " ")
            End If
        Next
        s.putBuf("set @IsLocked =0")
        s.putBuf("end")

        o.ModuleName = "--Procedures"
        o.Block = "--TableProc"
        o.OutNL(s.getBuf)
        o.OutNL("GO")


        '--------------------------- Разблокируем запись
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        s = New Writer
        s.putBuf(procDropSQL(os.Name & "_UNLOCK"))
        s.putBuf("create proc " & os.Name & "_UNLOCK /*" & os.the_Comment & "*/ (")
        s.putBuf(" @CURSESSION uniqueidentifier,")
        s.putBuf(" @RowID uniqueidentifier ")
        s.putBuf(") as " & " begin  ")
        s.putBuf("set nocount on")
        s.putBuf(" declare @ParentID uniqueidentifier")
        s.putBuf(" declare @UserID uniqueidentifier")
        s.putBuf(" declare @IsLocked integer")
        s.putBuf(" declare @ParentTable varchar(255) ")

        s.putBuf(" -- checking session  --")
        s.putBuf("if not exists( select 1 from the_session where the_sessionid=@cursession and closed=0 )")
        s.putBuf("  begin")
        s.putBuf("    raiserror('Сессия уже завершена.',16,1)")
        s.putBuf("    return")
        s.putBuf("  end")

        s.putBuf(" select @userID = usersid  from the_session where the_sessionid=@cursession")
        s.putBuf(" exec " & os.Name & "_ISLOCKED @CURSESSION,@ROWID,@ISLocked out")
        s.putBuf(" if @IsLocked >=3  ")
        s.putBuf("  begin")
        s.putBuf("    raiserror('Строка заблоирована другим пользователем',16,1)")
        s.putBuf("    return")
        s.putBuf("  end")

        s.putBuf("   if  @IsLocked =2  ")
        s.putBuf("   begin   ")
        s.putBuf("    update " & os.Name & " set LockUserID =null  where " & os.Name & "id=@RowID")
        s.putBuf("     return")
        s.putBuf("   end ")

        s.putBuf("   if  @IsLocked =1  ")
        s.putBuf("   begin   ")
        s.putBuf("    update " & os.Name & " set LockSessionID =null  where " & os.Name & "id=@RowID")
        s.putBuf("     return")
        s.putBuf("   end ")

        s.putBuf(" end ")

        o.ModuleName = "--Procedures"
        o.Block = "--TableProc"
        o.OutNL(s.getBuf)
        o.OutNL("GO")



        '--------------------------- Наследуем установки Security
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        s = New Writer
        s.putBuf(procDropSQL(os.Name & "_SINIT"))
        s.putBuf("create proc " & os.Name & "_SINIT /*" & os.the_Comment & "*/ (")
        s.putBuf(" @CURSESSION uniqueidentifier,")
        s.putBuf(" @RowID uniqueidentifier ,")
        s.putBuf(" @SecurityStyleID uniqueidentifier=null")
        s.putBuf(") as " & " begin  ")
        s.putBuf("set nocount on")
        s.putBuf(" declare @ParentID uniqueidentifier")
        s.putBuf(" declare @ParentTable varchar(255) ")
        s.putBuf(" declare @StyleID uniqueidentifier")


        s.putBuf(" declare @tmpID uniqueidentifier")
        s.putBuf(" declare @access integer")
        s.putBuf(" select  @tmpID =SecurityStyleID from " & os.Name & " where " & os.Name & "id=@ROWID")
        s.putBuf(" exec CheckVerbRight @cursession=@cursession,@Resource=@tmpID,@verb='SECURE',@access=@access out ")
        s.putBuf(" if @access=0 ")
        s.putBuf("  begin")
        s.putBuf("    raiserror('Нет прав на управление защитой. Раздел =" & os.Name & "',16,1)")
        s.putBuf("    if @@trancount>0 rollback tran")
        s.putBuf("    return")
        s.putBuf("  end")

        s.putBuf("if @SecurityStyleID is null begin ")



        s.putBuf("/* extract style from parent */")
        s.putBuf("declare @s nvarchar(4000)")
        s.putBuf(" exec " & os.Name & "_parent @CURSESSION,@ROWID,@ParentID output ,@ParentTable output")
        s.putBuf(" set @s = N'select @StyleID =SecurityStyleID from ' +@ParentTable +N' where ' +@ParentTable + N'id=@Parentid'")
        s.putBuf("  exec sp_executesql @s,N'@StyleID uniqueidentifier out,@ParentTable varchar(255),@Parentid uniqueidentifier',@StyleID  out,@ParentTable ,@Parentid")
        s.putBuf(" update " & os.Name & " set securitystyleid =@StyleID where " & os.Name & "id = @RowID")
        s.putBuf("end else begin ")
        s.putBuf(" update " & os.Name & " set securitystyleid =@SecurityStyleID where " & os.Name & "id = @RowID")
        s.putBuf("end  ")
        s.putBuf("end  ")

        o.ModuleName = "--Procedures"
        o.Block = "--TableProc"
        o.OutNL(s.getBuf)
        o.OutNL("GO")


        '--------------------------- распространение прав на дочерние объекты
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
        s = New Writer
        s.putBuf(procDropSQL(os.Name & "_propagate"))
        s.putBuf("create proc " & os.Name & "_propagate /*" & os.the_Comment & "*/ (")
        s.putBuf(" @CURSESSION uniqueidentifier,")
        s.putBuf(" @RowID uniqueidentifier")
        s.putBuf(") as " & " begin  ")
        s.putBuf("set nocount on")
        s.putBuf("declare @childlistid uniqueidentifier")
        s.putBuf("declare @SSID uniqueidentifier")
        s.putBuf("select @SSID = securityStyleid from " & os.Name & " where " & os.Name & "id=@Rowid")

        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            If Not chos.PartType = 3 Then
                s.putBuf("declare propchild_" & chos.Name & " cursor local for select " & chos.Name & "." & chos.Name & "id from " & chos.Name & " where  " & chos.Name & ".ParentStructRowID = @Rowid")
                s.putBuf("open propchild_" & chos.Name & "")
                s.putBuf("fetch next from propchild_" & chos.Name & " into @childlistid")
                s.putBuf("while @@fetch_status >=0 ")
                s.putBuf("begin")
                s.putBuf(" exec " & chos.Name & "_SINIT @cursession,@childlistid,@ssid")
                s.putBuf(" if @@nestlevel <30 ")
                s.putBuf("   exec " & chos.Name & "_propagate @cursession,@childlistid")
                s.putBuf(" fetch next from propchild_" & chos.Name & " into @childlistid")
                s.putBuf("end")
                s.putBuf("close propchild_" & chos.Name & "")
                s.putBuf("deallocate propchild_" & chos.Name & " ")
            End If
        Next
        s.putBuf("end")

        o.ModuleName = "--Procedures"
        o.Block = "--TableProc"
        o.OutNL(s.getBuf)
        o.OutNL("GO")




        Debug.Print("SQLGEN.CreateV2Proc:children " & os.Caption)
        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            CreateV2Proc(chos)
        Next
        Debug.Print("SQLGEN.CreateV2Proc:done " & os.Caption)
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing

        Exit Sub
bye:
        Debug.Print(Err.Description)
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
        'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        s = Nothing
    End Sub




    Private Sub LoadMap()
        Dim ff As Short
        Dim ID1S As String = String.Empty
        Dim IDMTZ As String = String.Empty
        Dim idm As IDMAP
        ff = FreeFile()
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

    Private Sub SaveMap()
        Dim ff As Short
        Dim idm As IDMAP
        ff = FreeFile()

        '  Dim mTempPath As String
        '  mTempPath = GetSetting("MTZ", "CONFIG", "TEMPPATH", "")
        '  If mTempPath = "" Then
        '    ChDir App.Path
        '    On Error Resume Next
        '    MkDir "TMP"
        '    fname = App.Path & "\TMP\" & CreateGUID2 & ".txt"
        '  Else
        '    fname = mTempPath & CreateGUID2 & ".txt"
        '  End If
        '
        FileOpen(ff, My.Application.Info.DirectoryPath & "\IDMAP.txt", OpenMode.Output)
        For Each idm In Map
            WriteLine(ff, idm.ID1S, idm.IDMTZ)
        Next idm
        FileClose(ff)
    End Sub

    Private Function GetMap(ByRef ID1S As String) As String
        Dim idm As IDMAP
        On Error Resume Next
        'UPGRADE_NOTE: Object idm may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        idm = Nothing
        idm = Map.Item(ID1S)
        If idm Is Nothing Then
            idm = New IDMAP
            idm.ID1S = ID1S
            idm.IDMTZ = Guid.NewGuid.ToString()
            idm.IDMTZ = Guid.NewGuid.ToString()

            Map.Add(idm, ID1S)
        End If
        GetMap = idm.IDMTZ
    End Function

    'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Initialize_Renamed()
        LoadMap()
    End Sub
    Public Sub New()
        MyBase.New()
        Class_Initialize_Renamed()
    End Sub

    'UPGRADE_NOTE: Class_Terminate was upgraded to Class_Terminate_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Private Sub Class_Terminate_Renamed()
        SaveMap()
    End Sub
    Protected Overrides Sub Finalize()
        Class_Terminate_Renamed()
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


    Private Function FullTextClean() As String
        Dim s As String
        s = ""
        s = s & vbCrLf & "IF DATABASEPROPERTYEX(DB_NAME() , 'IsFulltextEnabled') <> 1"
        s = s & vbCrLf & "EXECUTE sp_fulltext_database 'enable'"
        s = s & vbCrLf & "go"

        ' есть ли каталог ?
        s = s & vbCrLf & "if not exists  (select name from sysfulltextcatalogs where name ='fulltext_catalog')"
        s = s & vbCrLf & "Exec sp_fulltext_catalog 'fulltext_catalog','Create'"
        s = s & vbCrLf & "go"

        ' грохаем все таблицы из каталога
        s = s & vbCrLf & "DECLARE @TableOwner sysname"
        s = s & vbCrLf & "DECLARE @TableName sysname"
        s = s & vbCrLf & "DECLARE @FullTextTableCursor CURSOR"
        s = s & vbCrLf & "DECLARE @FullTextKeyIndexName sysname"
        s = s & vbCrLf & "DECLARE @FullTextKeyColID  int"
        s = s & vbCrLf & "DECLARE @FullTextIndexActive int"
        s = s & vbCrLf & "DECLARE @FullTextCatalogName sysname"
        s = s & vbCrLf & "EXECUTE sp_help_fulltext_tables_cursor @FullTextTableCursor OUTPUT, @fulltext_catalog_name ='fulltext_catalog'"
        s = s & vbCrLf & "FETCH NEXT FROM @FullTextTableCursor INTO @TableOwner, @TableName, @FullTextKeyIndexName, @FullTextKeyColID, @FullTextIndexActive, @FullTextCatalogName"
        s = s & vbCrLf & "WHILE (@@FETCH_STATUS = 0)"
        s = s & vbCrLf & "BEGIN"
        s = s & vbCrLf & "  EXECUTE sp_fulltext_table @TableName, 'Drop'"
        s = s & vbCrLf & "  FETCH NEXT FROM @FullTextTableCursor INTO @TableOwner, @TableName, @FullTextKeyIndexName, @FullTextKeyColID, @FullTextIndexActive, @FullTextCatalogName"
        s = s & vbCrLf & "End"
        s = s & vbCrLf & "CLOSE @FullTextTableCursor"
        s = s & vbCrLf & "DEALLOCATE @FullTextTableCursor"
        s = s & vbCrLf & "go"

        ' грохаем сам каталог
        s = s & vbCrLf & "if exists  (select name from sysfulltextcatalogs where name ='fulltext_catalog')"
        s = s & vbCrLf & "Exec sp_fulltext_catalog 'fulltext_catalog','Drop'"
        s = s & vbCrLf & "go"

        ' есть ли каталог ?
        s = s & vbCrLf & "if not exists  (select name from sysfulltextcatalogs where name ='fulltext_catalog')"
        s = s & vbCrLf & "Exec sp_fulltext_catalog 'fulltext_catalog','Create'"
        s = s & vbCrLf & "go"




        FullTextClean = s
    End Function


    Private Function FullTextStart() As String
        Dim s As String
        s = ""
        s = s & vbCrLf & "IF DATABASEPROPERTYEX(DB_NAME() , 'IsFulltextEnabled') = 1"
        s = s & vbCrLf & "EXECUTE sp_fulltext_catalog 'fulltext_catalog','start_full'"
        s = s & vbCrLf & "go"

        s = s & vbCrLf & "declare @id BINARY(16)"
        s = s & vbCrLf & "declare @jname nvarchar(255)"
        s = s & vbCrLf & "declare @jcmd nvarchar(4000)"
        s = s & vbCrLf & "declare @dbname nvarchar(4000)"
        s = s & vbCrLf & "set @jname =  N'Start_Incremental on ' + db_name()"
        s = s & vbCrLf & "set @dbname =  db_name()"
        s = s & vbCrLf & "set @jcmd =  N'use [' + db_name() + N'] exec sp_fulltext_catalog N''fulltext_catalog'', N''start_incremental'''"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "exec msdb..sp_add_job"
        s = s & vbCrLf & "@job_name = @jname,"
        s = s & vbCrLf & "@enabled = 1,"
        s = s & vbCrLf & "@start_step_id = 1,"
        s = s & vbCrLf & "@notify_level_eventlog = 2,"
        s = s & vbCrLf & "@notify_level_email = 0,"
        s = s & vbCrLf & "@notify_level_netsend = 0,"
        s = s & vbCrLf & "@notify_level_page = 0,"
        s = s & vbCrLf & "@delete_level = 0,"
        s = s & vbCrLf & "@category_name = N'Full-Text',"
        s = s & vbCrLf & "@job_id = @id OUTPUT"
        s = s & vbCrLf & ""
        s = s & vbCrLf & "exec msdb..sp_add_jobstep"
        s = s & vbCrLf & " @job_id = @id ,"
        s = s & vbCrLf & " @step_id = 1,"
        s = s & vbCrLf & " @cmdexec_success_code = 0,"
        s = s & vbCrLf & " @on_success_action = 1,"
        s = s & vbCrLf & " @on_success_step_id = 0,"
        s = s & vbCrLf & " @on_fail_action = 2,"
        s = s & vbCrLf & " @on_fail_step_id = 0,"
        s = s & vbCrLf & " @retry_attempts = 0,"
        s = s & vbCrLf & " @retry_interval = 0,"
        s = s & vbCrLf & " @os_run_priority = 0,"
        s = s & vbCrLf & " @flags = 0,"
        s = s & vbCrLf & " @step_name = N'Full-Text Indexing',"
        s = s & vbCrLf & " @subsystem = N'TSQL',"
        s = s & vbCrLf & " @command = @jcmd,"
        s = s & vbCrLf & " @database_name = @DBNAME"
        s = s & vbCrLf & ""
        s = s & vbCrLf & " exec msdb..sp_add_jobserver"
        s = s & vbCrLf & " @job_id = @id,"
        s = s & vbCrLf & " @server_name = N'(local)'"

        s = s & vbCrLf & " exec msdb..sp_add_jobschedule"
        s = s & vbCrLf & "@job_id = @id,"
        s = s & vbCrLf & "@name = N'step shedule',"
        s = s & vbCrLf & "@enabled = 1,"
        s = s & vbCrLf & "@freq_type = 4,"
        s = s & vbCrLf & "@freq_interval = 1,"
        s = s & vbCrLf & "@freq_subday_type = 8,"
        s = s & vbCrLf & "@freq_subday_interval = 2,"
        s = s & vbCrLf & "@freq_relative_interval = 0,"
        s = s & vbCrLf & "@freq_recurrence_factor = 1,"
        s = s & vbCrLf & "@active_start_date = 20030122,"
        s = s & vbCrLf & "@active_end_date = 99991231,"
        s = s & vbCrLf & "@active_start_time = 0,"
        s = s & vbCrLf & "@active_end_time = 235959"
        s = s & vbCrLf & "go"
        FullTextStart = s
    End Function




    Private Function AutoCloseJob() As String
        Dim s As Writer
        s = New Writer

        s.putBuf("declare @id BINARY(16)")
        s.putBuf("declare @jname nvarchar(255)")
        s.putBuf("declare @jcmd nvarchar(4000)")
        s.putBuf("declare @dbname nvarchar(4000)")
        s.putBuf("set @jname =  N'AutoCloseSession on ' + db_name()")
        s.putBuf("set @dbname =  db_name()")
        s.putBuf("set @jcmd =  N'use [' + db_name() + N'] exec AutoCloseSession'")
        s.putBuf("")
        s.putBuf("exec msdb..sp_add_job")
        s.putBuf("@job_name = @jname,")
        s.putBuf("@enabled = 1,")
        s.putBuf("@start_step_id = 1,")
        s.putBuf("@notify_level_eventlog = 2,")
        s.putBuf("@notify_level_email = 0,")
        s.putBuf("@notify_level_netsend = 0,")
        s.putBuf("@notify_level_page = 0,")
        s.putBuf("@delete_level = 0,")
        s.putBuf("@category_name = N'Database Maintenance',")
        s.putBuf("@job_id = @id OUTPUT")
        s.putBuf("")
        s.putBuf("exec msdb..sp_add_jobstep")
        s.putBuf(" @job_id = @id ,")
        s.putBuf(" @step_id = 1,")
        s.putBuf(" @cmdexec_success_code = 0,")
        s.putBuf(" @on_success_action = 1,")
        s.putBuf(" @on_success_step_id = 0,")
        s.putBuf(" @on_fail_action = 2,")
        s.putBuf(" @on_fail_step_id = 0,")
        s.putBuf(" @retry_attempts = 0,")
        s.putBuf(" @retry_interval = 0,")
        s.putBuf(" @os_run_priority = 0,")
        s.putBuf(" @flags = 0,")
        s.putBuf(" @step_name = N'Close lost session',")
        s.putBuf(" @subsystem = N'TSQL',")
        s.putBuf(" @command = @jcmd,")
        s.putBuf(" @database_name = @DBNAME")
        s.putBuf("")
        s.putBuf(" exec msdb..sp_add_jobserver")
        s.putBuf(" @job_id = @id,")
        s.putBuf(" @server_name = N'(local)'")

        s.putBuf(" exec msdb..sp_add_jobschedule")
        s.putBuf("@job_id = @id,")
        s.putBuf("@name = N'step shedule',")
        s.putBuf("@enabled = 1,")
        s.putBuf("@freq_type = 4,")
        s.putBuf("@freq_interval = 1,")
        s.putBuf("@freq_subday_type = 4,")
        s.putBuf("@freq_subday_interval = 10,")
        s.putBuf("@freq_relative_interval = 0,")
        s.putBuf("@freq_recurrence_factor = 1,")
        s.putBuf("@active_start_date = 20030122,")
        s.putBuf("@active_end_date = 99991231,")
        s.putBuf("@active_start_time = 0,")
        s.putBuf("@active_end_time = 235959")
        s.putBuf("go")
        AutoCloseJob = s.getBuf
    End Function


    Private Function FullTextPartSearch(ByRef os As MTZMetaModel.MTZMetaModel.PART) As String
        If os.PartType = 3 Then
            Debug.Print("SQLGEN.FullTextPartSearch:skipped " & os.Caption)
            Return String.Empty
        End If
        Dim st As MTZMetaModel.MTZMetaModel.PART
        st = os
        Dim chos As MTZMetaModel.MTZMetaModel.PART
        Dim i As Short
        Dim s As String

        log = log & vbCrLf & "-->full text table " & os.Name

        On Error GoTo bye
        Dim hasFields As Boolean

        hasFields = False
        s = ""
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE
        If st.ManualRegister = MTZMetaModel.MTZMetaModel.enumBoolean.Boolean_Net Then
            st.FIELD.Sort = "sequence"
            For i = 1 To st.FIELD.Count
                ft = st.FIELD.Item(i).FieldType
                If UCase(ft.Name) = "FILE" Then
                    hasFields = True
                Else
                    If ft.AllowLikeSearch Then
                        hasFields = True
                    End If
                End If
            Next
        End If
        If hasFields Then
            s = s & vbCrLf & "Insert Into queryResult(queryResultid,result) select @tmpid," & os.Name & "id from " & os.Name & " where contains(*,@filter)"
            s = s & vbCrLf & "exec RowsToInstances @tmpID, @tmp2ID, '" & os.Name & "', @CURSESSION"
            s = s & vbCrLf & "delete from QueryResult where queryResultid =@tmpid"
        End If

        For i = 1 To os.PART.Count
            chos = os.PART.Item(i)
            If Not chos.PartType = 3 Then
                s = s & vbCrLf & FullTextPartSearch(chos)
            End If
        Next
        FullTextPartSearch = s
        Exit Function
bye:
        log = log & vbCrLf & "ERROR-->" & Err.Description & "<--ERROR"
        'Resume
    End Function


    Public Sub CheckPartMLF(ByRef os As MTZMetaModel.MTZMetaModel.PART, ByRef log As String)
        On Error GoTo Error_Detected
        Dim i As Integer
        Dim j As Integer
        Dim f As MTZMetaModel.MTZMetaModel.FIELD
        Dim bDetected As Boolean
        Dim s As Writer
        s = New Writer
        Dim collist As String
        'Exit Function
        bDetected = False
        For i = 1 To os.FIELD.Count
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = os.FIELD.Item(i).FieldType
            If UCase(ft.Name) = UCase("MultiLanguage String") Or UCase(ft.Name) = UCase("MultiLanguage Memo") Then
                bDetected = True
            End If
        Next

        Dim sTableName As String
        If bDetected Then
            'create table for each cultures
            Dim app As MTZMetaModel.MTZMetaModel.Application = os.Application
            For i = 1 To app.LocalizeInfo.Count
                'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                s = Nothing
                s = New Writer
                'UPGRADE_WARNING: Couldn't resolve default property of object os.Application.LocalizeInfo. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                sTableName = os.Name & "_" & app.LocalizeInfo.Item(i).LangShort
                'UPGRADE_WARNING: Couldn't resolve default property of object os.Application.LocalizeInfo. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                log = log & vbCrLf & "-->MLE CreateStruct " & (os.Name & ":") + app.LocalizeInfo.Item(i).LangFull + (" (") + app.LocalizeInfo.Item(i).LangShort + (")")
                'UPGRADE_WARNING: Couldn't resolve default property of object os.Application.LocalizeInfo. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                s.putBuf("/*" & os.Caption & "_" & app.LocalizeInfo.Item(i).LangShort & "*/")
                s.putBuf("if not exists (select * from sysobjects where id = object_id(N'" & sTableName & "') and OBJECTPROPERTY(id, N'IsUserTable') = 1)")
                s.putBuf("BEGIN")
                s.putBuf("create table " & sTableName & "/*" & os.the_Comment & "*/ (")
                collist = ""
                'UPGRADE_WARNING: Couldn't resolve default property of object os.Parent.Parent. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                'UPGRADE_WARNING: TypeName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="9B7D5ADD-D8FE-4819-A36C-6DEDAF088CC7"'
                If TypeName(os.Parent.Parent) = "OBJECTTYPE" Then
                    s.putBuf("InstanceID uniqueidentifier ,")
                    collist = collist & "'InstanceID'"
                Else
                    s.putBuf("ParentStructRowID uniqueidentifier not null,")
                    collist = collist & "'ParentStructRowID'"
                End If

                s.putBuf(os.Name & "id uniqueidentifier not null rowguidcol default ( newid())  ")
                collist = collist & ",'" & os.Name & "ID'"

                s.putBuf(",ChangeStamp datetime not null default ( getdate()) /* Время последнего изменения */")
                collist = collist & ",'ChangeStamp'"

                s.putBuf(",TimeStamp timestamp not null  /* для организации инкрементального индексирования полнотекстовой информации */")
                collist = collist & ",'TimeStamp'"


                's.putBuf ",LockSessionID uniqueidentifier null  /* temporary lock */"
                'collist = collist & ",'LockSessionID'"
                's.putBuf ",LockUserID uniqueidentifier null /* checkout lock */"
                'collist = collist & ",'LockUserID'"
                's.putBuf ",SecurityStyleID uniqueidentifier null /* security formula */"
                'collist = collist & ",'SecurityStyleID'"



                ' дерево
                If os.PartType = 2 Then
                    s.putBuf(",ParentRowid uniqueidentifier ")
                    collist = collist & ",'ParentRowid'"
                End If

                s.putBuf(")")
                s.putBuf("END")
                s.putBuf("go")


                os.FIELD.Sort = "sequence"
                For j = 1 To os.FIELD.Count
                    'Только ML поля
                    'UPGRADE_WARNING: Couldn't resolve default property of object os.FIELD.Item().FIELDTYPE.Name. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = os.FIELD.Item(j).FieldType
                    If UCase(ft.Name) = UCase("MultiLanguage String") Or UCase(ft.Name) = UCase("MultiLanguage Memo") Then
                        ' Добавляем
                        s.putBuf("if  not exists(select * from syscolumns where name='" & os.FIELD.Item(j).Name & "' and id=object_id(N'" & sTableName & "'))")
                        s.putBuf("alter table " & sTableName & " add ")
                        s.putBuf(FieldForCreate(os.FIELD.Item(j)))
                        collist = collist & ",'" & os.FIELD.Item(j).Name & "'"
                        s.putBuf("go")
                    End If
                Next

                s.putBuf(ColumnDropSQL(sTableName, collist))
                o.ModuleName = "--Tables"
                o.Block = "--body"
                o.OutNL(s.getBuf)

                'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                s = Nothing
                s = New Writer
                s.putBuf(PkeyDropSQL(sTableName, "pk_" & sTableName))
                s.putBuf("alter table " & sTableName & " add constraint pk_" & sTableName & " primary key (" & os.Name & "ID)")
                o.ModuleName = "--Tables"
                o.Block = "--body"
                o.OutNL(s.getBuf)
                o.OutNL("GO")

                'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                s = Nothing
                s = New Writer
                'UPGRADE_WARNING: Couldn't resolve default property of object os.Application.LocalizeInfo. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                s.putBuf(keyDropSQL(sTableName, "fk_" & MakeName(os.ID.ToString() + app.LocalizeInfo.Item(i).LangShort)))
                'UPGRADE_WARNING: Couldn't resolve default property of object os.Application.LocalizeInfo. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                s.putBuf("alter table " & sTableName & " add constraint fk_" & MakeName(os.ID.ToString() + app.LocalizeInfo.Item(i).LangShort) & " foreign key(INSTANCEID) references INSTANCE (INSTANCEID)")
                o.ModuleName = "--Tables"
                o.Block = "--ForeignKey"
                o.OutNL(s.getBuf)
                o.OutNL("GO")

                'UPGRADE_NOTE: Object s may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
                s = Nothing
                s = New Writer
                s.putBuf(indexDropSQL(sTableName, "parent_" & sTableName))
                s.putBuf("create index parent_" & sTableName & " on " & sTableName & "(INSTANCEID)")
                o.ModuleName = "--Tables"
                o.Block = "--Index"
                o.OutNL(s.getBuf)
                o.OutNL("GO")
            Next
        End If
        Exit Sub
Error_Detected:
        MsgBox("CheckPartMLF:" & Err.Description)
    End Sub

    Private Function IsMLFPart(ByRef os As MTZMetaModel.MTZMetaModel.PART) As Boolean
        Dim j As Integer
        IsMLFPart = False
        For j = 1 To os.FIELD.Count
            Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = os.FIELD.Item(j).FieldType
            If UCase(ft.Name) = UCase("MultiLanguage String") Or UCase(ft.Name) = UCase("MultiLanguage Memo") Then
                IsMLFPart = True
                Exit Function
            End If
        Next
    End Function

    Private Function IsMLFField(ByRef f As MTZMetaModel.MTZMetaModel.FIELD) As Boolean
        IsMLFField = False
        Dim ft As MTZMetaModel.MTZMetaModel.FIELDTYPE = f.FieldType
        If UCase(ft.Name) = UCase("MultiLanguage String") Or UCase(ft.Name) = UCase("MultiLanguage Memo") Then
            IsMLFField = True
        End If
    End Function
End Class