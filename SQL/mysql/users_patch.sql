select * from v_instance where  objtype='mtzusers';
-- insert into instance(instanceid,name,objtype) values(g2b('{993DAAFD-589E-480D-97FF-1F9AB0568800}'),'mtzusers','mtzusers');
update users set instanceid=g2b('{993DAAFD-589E-480D-97FF-1F9AB0568800}');
delete from instance where objtype='mtzusers' and  instanceid <>g2b('{993DAAFD-589E-480D-97FF-1F9AB0568800}');
-- delete from users where login <>'supervisor';
select * from users;