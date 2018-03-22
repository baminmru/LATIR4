DELIMITER ;

select * from viewcolumn where field not in 
(select fieldid from field);

select * from fieldrestriction where 
theField not in (select fieldid from field);

select * from fieldrestriction where 
thePart not in (select partid from part);

select * from structrestriction where 
struct not in (select partid from part);

select *  from fieldtypemap where target not in 
(select generator_targetid from generator_target);


select * from objecttype where 
chooseview not in (select partviewid from partview);

update objecttype set chooseview = null 
where 
chooseview not in (select partviewid from partview);
delete from fieldtypemap where target not in (select generator_targetid from generator_target);


delete from viewcolumn where field not in 
(select fieldid from field);

delete from fieldrestriction where 
theField not in (select fieldid from field);

delete from fieldrestriction where 
thePart not in (select partid from part);

delete from structrestriction where 
struct not in (select partid from part);

delete from partview where partviewid not in (select parentstructrowid from viewcolumn);


select * from partview where partviewid not in (select parentstructrowid from viewcolumn);

-- print 'checking part unique'
select name from part group by name having count(*) >1;

-- print 'checking field unique'
select name from field group by parentstructrowid,name having count(*) >1;

-- print 'checking object and part name eql'
select part.name from part join objecttype on part.parentstructrowid=objecttype.objecttypeid 
where part.name=objecttype.name;

commit;