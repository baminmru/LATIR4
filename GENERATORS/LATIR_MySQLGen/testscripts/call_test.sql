delimiter $$ 

drop procedure if exists Test ;
$$
create procedure Test()

begin

declare a_id binary(16);

call Login(a_id,'init','init');

select B2G(a_id);
call Instance_Save(a_id,G2B(UUID()),'MTZUsers','Пользователи');
call Logout(a_id);
end
$$
call Test();

