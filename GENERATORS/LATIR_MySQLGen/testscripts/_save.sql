delimiter $$

create procedure TGas_SAVE /*TGas*/ (
 a_CURSESSION BINARY(16),
a_InstanceID BINARY(16) ,
 a_TGasid BINARY(16)
,a_NGid
 integer /* Код НГ *//* Код НГ */
,a_ShortName
 VARCHAR (20)/* Краткое название *//* Краткое название */
,a_Name
 VARCHAR (50)  /* Название *//* Название */
,a_ListSortOrder
 integer  /* Порядок вывода *//* Порядок вывода */
)  body: begin  
 declare a_UniqueRowCount integer;
 declare a_tmpStr varchar(255);
 declare a_tmpID BINARY(16);
 declare a_access int;
 declare a_SysInstID BINARY(16);
 declare a_SessUserID BINARY(16);
 declare a_MLF_PartID BINARY(16);
 declare a_SessUserLogin varchar(40);
 declare a_EC int;
 select UsersID into a_SessUserID from the_session where the_sessionid=a_cursession;
 select login into a_SessUserLogin from users where usersid=a_SessUserID;
 select Instanceid into a_SysInstID from instance where objtype='MTZSYSTEM';
 select count(*) into a_EC from the_session where the_sessionid=a_cursession and closed=0 ;
if a_EC=0  then
    leave body;
  end if;
/*if exists */ select  count(*) into a_EC from TGas where TGasID=a_TGasID;
if a_EC >0 then
 start transaction ; 
 update  TGas set ChangeStamp=curdate()
,
  NGid=a_NGid
,
  ShortName=a_ShortName
,
  Name=a_Name
,
  ListSortOrder=a_ListSortOrder
  where  TGasID = a_TGasID ;



 else
 select  SecurityStyleID into a_tmpid  from instance where instanceid=a_instanceid;
 /*call instance_ISLOCKED a_cursession,a_InstanceID,out a_access ;
 if a_access>2  then
    leave body;
  end if;
  */
 start transaction;  
 insert into   TGas
 (  TGasID 
,InstanceID
,NGid

,ShortName

,Name

,ListSortOrder

 ) values ( a_TGasID 
,a_InstanceID
,a_NGid

,a_ShortName

,a_Name

,a_ListSortOrder

 ) ;
 /*call TGas_SINIT a_CURSESSION,a_TGasid,a_tmpid;*/


 end if;
 if a_a_error <>0  then 
 rollback ;   
 else 
 commit ;  
 end if;
 end 
