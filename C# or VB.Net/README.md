ID Generation in database system was always a pain in the ass to deal with as you will have a chance to repeat the ID in respective database that you created
if there's a sudden unexpected deletion of records in PK tables... You will need to update the PK and make sure that the PK doesn't get repeated..
This will less likely to happen if you can really ensure that there's no sudden deletion of records.... But if it does... make sure to use pseudo-random
String ID generator