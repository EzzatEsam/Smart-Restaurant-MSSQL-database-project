﻿delete from ORDER_;
delete from CONTACTREQUEST;
delete from ORDER_MENUITEMS
DBCC CHECKIDENT ('ORDER_', RESEED, 1) 
DBCC CHECKIDENT ('CONTACTREQUEST', RESEED, 0) 
insert into ORDER_(ORDER_.CID ,TNUMBER ,STATUS_ ,OTIME ) values (1,1,0,(CONVERT(time, GETDATE()))),
(2,2,0,(CONVERT(time, GETDATE()))),
(3,3,1,(CONVERT(time, GETDATE()))),
(4,4,0,(CONVERT(time, GETDATE())));

insert into CONTACTREQUEST(CID ,TNUMBER,STATUS_,CHECKOUT ,TIME_ ) values (1,1,0,0,(CONVERT(time, GETDATE()))),
(2,2,0,0,(CONVERT(time, GETDATE()))),
(3,3,0,1,(CONVERT(time, GETDATE()))),
(4,4,2,0,(CONVERT(time, GETDATE())));

insert into ORDER_MENUITEMS (ORDERID ,ITEMNUMBER) values (4,1),(4,2),(4,3),(4,4);