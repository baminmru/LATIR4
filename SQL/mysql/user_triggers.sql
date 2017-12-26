delimiter $$


drop trigger iu_u_def_inserted
$$
CREATE TRIGGER iu_u_def_inserted AFTER INSERT ON iu_u_def FOR EACH ROW
begin
    declare existsCnt  integer;
    declare ID  binary(16);
    if new.login <> '' then
        select count(*) into existsCnt from users where login=new.login or usersid=new.iu_u_defid;
        if existsCnt = 0 then
         select instanceid into id from instance where objtype='MTZUsers';
         insert into users
         (changestamp,instanceid,usersid,family,name,surname, login,password) 
         values 
         (sysdate(),id,new.iu_u_defid,new.lastname,new.name,new.surname,new.login,md5(new.login));
       else
		 update users
			set family=new.lastname,name=new.name,surname=new.surname, login=new.login where usersid=new.iu_u_defid;
		update users
			set family=new.lastname,name=new.name,surname=new.surname  where login=new.login;
        end if;
    end if;

end
$$
drop trigger iu_u_def_updated
$$


CREATE
TRIGGER `iu_u_def_updated`
AFTER UPDATE ON `iu_u_def`
FOR EACH ROW
begin
    declare existsCnt  integer;
    declare ID  binary(16);
    select instanceid into id from instance where objtype='MTZUsers';

	  if new.login<>old.login then
			
				select count(*) into existsCnt from users where  usersid=new.iu_u_defid;
				if existsCnt = 0 then
				  
				   select count(*) into existsCnt from users where login=old.login ;
					if existsCnt = 0 then
							 insert into users
							 (changestamp,instanceid,usersid,family,name,surname, login,password) 
							 values 
							 (sysdate(),id,new.iu_u_defid,new.lastname,new.name,new.surname,new.login,md5(new.login));
					else
							update users  set login=new.login, password=  md5(new.login) where  login = old.login ;
							update users set family=new.lastname,name=new.name,surname=new.surname where login=new.login ;
					end if;
				else
					update users  set login=new.login, password=  md5(new.login) where  login = old.login ;
					update users  set login=new.login, password=  md5(new.login) where  usersid=new.iu_u_defid;
					update users set family=new.lastname,name=new.name,surname=new.surname where usersid=new.iu_u_defid;
				end if;
	
        else
				update users set family=new.lastname,name=new.name,surname=new.surname where login=new.login  or usersid=new.iu_u_defid;
		end if;

end$$


-- update iu_tmdef set changestamp=now()
$$

-- update iu_u_def set changestamp=now()
$$

-- select * from users

-- select * from iu_u_def

drop procedure setpassword_wiz
$$
create procedure setpassword_wiz(
    acursessionid varchar(38), 
	ainstanceid varchar(38),
    anewpassword varchar(80), 
	acomppassword varchar(80)
    )
body: begin  
     declare ausersid  binary(16);  
	 declare apass  varchar(80);  

	 
     declare IsOK int;
     select 0 into IsOK;
     
      select 1 into IsOK from    the_Session 
        where  (   closed=1) and the_Session.the_Sessionid=g2b(acursessionid) ;
     if IsOK<>0 then
       select 'Session closed'  result;
       leave body;
     end if;

	 if anewpassword<>acomppassword then
		select 'Новый пароль не совпадает с проверочным значением'  result;
        leave body;
	 end if;
	
    select users.usersid into ausersid from  iu_u_def
    join users on   iu_u_def.login=users.login
    where iu_u_def.instanceid=g2b(ainstanceid);
    
	
	 update users set password=md5(anewpassword) where usersid=ausersid; 
    select 'OK'  result;
    end
$$

drop procedure setmypassword_wiz
$$
create procedure setmypassword_wiz( acursessionid varchar(38), aoldpassword varchar(80), anewpassword varchar(80), acomppassword varchar(80))
body: begin  
     declare ausersid  binary(16);  
	 declare apass  varchar(80);  

	 
     declare IsOK int;
     select 0 into IsOK;
     
      select 1 into IsOK from    the_Session 
        where  ( closed=1) and the_Session.the_Sessionid=g2b(acursessionid) ;
     if IsOK<>0 then
       select 'Session closed'  result;
       leave body;
     end if;

	 if anewpassword<>acomppassword then
		select 'Новый пароль не совпадает с проверочным значением'  result;
        leave body;
	 end if;
	
    select users.usersid,users.password into ausersid,apass from  the_Session
    join users on   the_session.usersid = users.usersid
    where the_Session.the_Sessionid=g2b(acursessionid);
	if apass<>md5(aoldpassword) then
		select 'Неверный старый пароль' result;
	else
	 update users set password=md5(anewpassword) where usersid=ausersid;
		select 'OK'  result;
	end if;
    
   
    end
  
$$

-- select * from  instance where objtype='iu_u'
-- select * from v_autoiu_u_def