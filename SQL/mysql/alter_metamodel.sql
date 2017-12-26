delimiter $$
alter table objecttype add 
usearchiving
 integer null default 0/* архивировать вместо удаления */
$$

alter table objecttype add 
  objiconcls varchar(80) NULL
$$

alter table part add 
usearchiving
 integer null default 0/* архивировать вместо удаления */
$$

alter table objecttype add 
commitfullobject
 integer null  default 0 /* сохранять объект целиком */
$$

alter table field add 
tabname
 varchar(80) null  default '' /* название таба */
$$

--  update objecttype set commitfullobject=0

alter table part add 
integerpkey
 integer null default 0/* целочисленный ключ */
$$

alter table part add 
`particoncls` varchar(80) NULL
$$

