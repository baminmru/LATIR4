use b2;

insert  instance(instanceid,name,objtype) values(b2.G2B(UUID()),'test4','test');


select INSTANCE_BRIEF_F(instanceid,null)  brief from instance;


select B2G(Instanceid) id,name,objtype from instance;

/*delete from instance where objtype='test';*/