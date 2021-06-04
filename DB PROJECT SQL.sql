-------------Database creation-------------
USE master;
GO
IF DB_ID('RESTDB') IS NOT NULL 
begin
alter database [RESTDB] set single_user with rollback immediate
DROP database RESTDB;
end
-----------------
Create database RESTDB;

GO
use RESTDB

--------------TABLE CREATION-------------------

CREATE TABLE ACCOUNT
(
ACCID int unique not null IDENTITY(1,1),
USERNAME CHAR(100) PRIMARY KEY ,
PASSWORD_ VARCHAR(20) NOT NULL,
TYPE_ smallINT not null,
check (type_ >=0 and type_ <=2) -- 0 admin  1 chef 2 waiter
);

Create Table LOGO
(
PIC VARBINARY(max)  not null
)

CREATE TABLE MENUITEMS
(
ITMNUMBER INT PRIMARY KEY IDENTITY(1,1) ,
INAME VARCHAR(100) NOT NULL UNIQUE,
PRICE FLOAT NOT NULL ,

CATEGORY VARCHAR(100) NOT NULL,
Picture  varbinary(max) ,
);
CREATE TABLE TABLE_
(
TNUMBER INT PRIMARY KEY IDENTITY(1,1) ,
IsOCCUPIED bit not null default 0,
);
create table Client
(
CID int PRIMARY KEY IDENTITY(1,1),
TNUMBER INT not null,
CNAME VARCHAR(200) NOT NULL ,

FOREIGN KEY (TNUMBER) REFERENCES TABLE_,

);
CREATE TABLE CONTACTREQUEST
(
NUMBER INT  IDENTITY(1,1),
CID INT NOT NULL FOREIGN KEY REFERENCES Client    ON DELETE CASCADE,
TNUMBER INT NOT NULL FOREIGN KEY REFERENCES TABLE_ ,
TIME_ TIME(2),
CHECKOUT bit default 0,
STATUS_ tinyint default 0 not null,  
PRIMARY KEY(NUMBER),
);

CREATE TABLE ORDER_
(
   ORDERID INT  IDENTITY(1,1),
   CID INT FOREIGN KEY REFERENCES CLIENT  ON DELETE CASCADE,
   STATUS_ int,    -- 0 pending  1 on it   2  ready   3 delivered
   --CHECKOUT BIT NOT NULL,     
   TNUMBER INT FOREIGN KEY REFERENCES TABLE_ ,
   OTIME TIME,
   PRIMARY KEY(ORDERID),
);

CREATE TABLE CHEF
(
CHID INT unique IDENTITY(1,1),
CHNAME VARCHAR(200) NOT NULL,
USERNAME CHAR(100) UNIQUE,
ISFREE BIT not NULL DEFAULT 1,
PRIMARY KEY (CHID , USERNAME),
FOREIGN KEY(USERNAME) REFERENCES ACCOUNT ON DELETE CASCADE,
C_SERVING INT FOREIGN KEY REFERENCES ORDER_ ON DELETE SET NULL,
);


CREATE TABLE WAITER
(
WID INT unique IDENTITY(1,1),
WNAME VARCHAR(200) NOT NULL,
USERNAME CHAR(100) UNIQUE,
ISFREE BIT not NULL DEFAULT 1,
PRIMARY KEY (WID , USERNAME),
FOREIGN KEY(USERNAME) REFERENCES ACCOUNT ,
C_SERVING INT FOREIGN KEY REFERENCES ORDER_ ,
C_RESPONSE INT FOREIGN KEY REFERENCES CONTACTREQUEST ,
);

CREATE TABLE ORDER_MENUITEMS
(
ORDERID INT NOT NULL  ,
ITEMNUMBER INT NOT NULL FOREIGN KEY REFERENCES MENUITEMS on delete cascade ,
FOREIGN KEY(ORDERID) REFERENCES ORDER_  ON DELETE CASCADE

);


CREATE TABLE ITEM_RATING
(
ITMNUMBER INT NOT NULL FOREIGN KEY REFERENCES MENUITEMS ON DELETE CASCADE 
ON UPDATE CASCADE ,
RATE SMALLINT NOT NULL,
CHECK (RATE >0 AND RATE <6),
CID int NOT NULL FOREIGN KEY REFERENCES Client ON DELETE CASCADE ,

);
-- Triggers
go
create trigger MoreThanOneAdmin on account
for UPDATE , INSERT
AS
IF (SELECT COUNT(*) FROM ACCOUNT where ACCOUNT.TYPE_ =0) > 1
begin
print 'Admin already exists'
ROLLBACK TRANSACTION
END

go
create trigger OnlyOneLogo
on LOGO
after insert
as
    declare @tableCount int
    select @tableCount = Count(*)
    from LOGO

    if @tableCount > 1
    begin
        print 'Logo already exists'
        rollback
    end
go
-- Procedures
go
CREATE PROCEDURE  TryLogin @username char(20) ,@pass char(20)
as 
begin
select * from ACCOUNT where @username = ACCOUNT.USERNAME and @pass = ACCOUNT.PASSWORD_;
end
go
CREATE PROCEDURE GetAllEmps
as
begin
select CHID ,CHNAME ,ISFREE ,C_SERVING,'0' ,'0'         from CHEF 
union select WID ,WNAME ,ISFREE ,C_SERVING ,'1' ,'0'    from WAITER where C_SERVING is not null 
union select WID ,WNAME ,ISFREE ,C_RESPONSE ,'1' ,'1'   from WAITER where C_RESPONSE is not null
union select WID ,WNAME ,ISFREE ,C_RESPONSE,'1'  , '-1'  from WAITER 
;
end
go
create procedure AddEmployee @type int , @name nvarchar(20), @account nvarchar(20) , @pass nvarchar(20) 
as
begin
if exists (select * from ACCOUNT where ACCOUNT.USERNAME = @account)
return -1;
INSERT into ACCOUNT(USERNAME ,PASSWORD_, TYPE_) VALUES (@account ,@pass,@type);
if @type = 1
INSERT INTO CHEF(USERNAME,CHname ) VALUES (@account ,@name);
else if @type = 1
INSERT INTO WAITER(USERNAME,WNAME ) VALUES (@account ,@name);
return 1;
end

go
create procedure SetTablesCount @num tinyint
as
begin
delete from TABLE_ where TABLE_.TNUMBER > @num
DECLARE @cnt INT = (select( count(*)) from TABLE_)
DBCC CHECKIDENT ('Emp', RESEED, @cnt)
WHILE @cnt < @num
begin
   insert into RESTDB.TABLE_ default values
   SET @cnt = @cnt + 1
end

END

go
create procedure UpdateLogo @logo varbinary(max)
as
begin
if (select count(* )from LOGO) >0
update LOGO set LOGO.PIC = @logo;
else
insert into LOGO values (@logo);
end

go
create procedure GetLogo
as
begin
select LOGO.PIC from LOGO;
end

go

create procedure EmpStatus @type smallint , @ID smallint , @free bit
as
begin
if @type =1
UPDATE CHEF set ISFREE = @free where CHID = @ID;
else if @type = 2
update WAITER set ISFREE =@free where WID = @ID;
end
go


create procedure GetClientName @num tinyint
as
begin
select Client.CNAME from Client where Client.CID = @num;
end
go



create procedure GetWorkerName @type smallint , @ID smallint 
as
begin
if @type =1
select CHEF.CHNAME as Name from CHEF where CHEF.CHID = @ID;
else if @type = 2
select WAITER.WNAME as Name from WAITER where WAITER.WID = @ID;
end
go

create procedure GetWorkerNameByAccount   @ACCID smallint 
as
begin

declare @type as smallint , @Name as varchar(60)
select @type = ACCOUNT.TYPE_ , @Name = ACCOUNT.USERNAME from ACCOUNT where ACCOUNT.ACCID = @ACCID
print @type;
print @name;
if @type =1
select CHEF.CHNAME as Name from CHEF where CHEF.USERNAME  = @Name;
else if @type = 2
select WAITER.WNAME as Name from WAITER where WAITER.USERNAME = @Name;
end
go

create procedure GetOrdersByState @state tinyint
as	
begin
select * from ORDER_ where STATUS_ = @state;
end
go

create procedure GetEmployeeStatus @ACCID int
as
begin
declare @type as smallint , @Name as varchar(60)
select @type = ACCOUNT.TYPE_ , @Name = ACCOUNT.USERNAME from ACCOUNT where ACCOUNT.ACCID = @ACCID
print @type;
print @name;
if @type =1
select CHEF.ISFREE as ISFREE from CHEF where CHEF.USERNAME  = @Name;
else if @type = 2
select WAITER.ISFREE as ISFREE from WAITER where WAITER.USERNAME = @Name;
end
go

create procedure SetOrderStatus @status tinyint, @ID int
as
begin
update ORDER_ set STATUS_ = @status where ORDER_.ORDERID = @ID;
end
go

create procedure SetRequest @status tinyint, @ID int
as
begin
update CONTACTREQUEST set STATUS_ = @status where CONTACTREQUEST.NUMBER = @ID;
end
go

create procedure GetRequestsByState @state tinyint
as	
begin
select * from CONTACTREQUEST where CONTACTREQUEST.STATUS_ = @state;
end
go

create procedure AddMenuItem  @name nvarchar(20), @category nvarchar(20) , @price float , @image varbinary(max) 
as
begin
INSERT into MENUITEMS(INAME ,CATEGORY, PRICE,Picture) VALUES (@name ,@category,@price,@image);
end
go

create procedure DeleteMenueItem @num int
as
begin
delete from MENUITEMS where MENUITEMS.ITMNUMBER = @num;
end
go

create procedure DeleteFromEmployees @num int , @type tinyint
as
begin
declare @usr varchar(50);
if @type =1
begin
set @usr = (select CHEF.USERNAME from CHEF where CHEF.CHID = @num)
delete from CHEF where CHEF.CHID = @num;
end
else if @type = 2
begin
set @usr = (select WAITER.USERNAME from WAITER where WAITER.WID = @num)
delete from WAITER  where WAITER.WID = @num;
end
end


go
create PROCEDURE UpdatePass @AccNum int ,@UsrName nvarchar(20) ,@Pass nvarchar(20) ,@OldPass nvarchar(20)  
as
begin
update ACCOUNT
set USERNAME = @UsrName ,PASSWORD_ = @Pass
where ACCOUNT.PASSWORD_ =@OldPass  and ACCOUNT.ACCID =@AccNum; 
end
go

create procedure GetItemsInOrder @ordernum int
as
begin
select * from MENUITEMS where MENUITEMS.ITMNUMBER  in  (select ORDER_MENUITEMS.ITEMNUMBER from ORDER_MENUITEMS where ORDER_MENUITEMS.ORDERID = @ordernum);
end
go 

create procedure GetAllMenu
as 
begin
select * from MENUITEMS;
end
go

create procedure GetTables
as
begin
select *from TABLE_;
end
go

create procedure GetEmptyTablesNums
as
begin
select TABLE_.TNUMBER from TABLE_ where IsOCCUPIED = 0;
end
go

create procedure CheckLastRequestStats @cid int
as
begin
declare @out tinyint =-1
set @out = (select CONTACTREQUEST.STATUS_ from CONTACTREQUEST where CONTACTREQUEST.CID =@cid)
return @out
end
go

Create procedure GetAllClientOrders @ID int
as
begin
select *from ORDER_ where ORDER_.CID = @ID;
end
go

create proc spchecktable
@TNUMBER int
as 
begin
select count(TNUMBER) from TABLE_ where TNUMBER=@TNUMBER;
end
go
create proc spchecktablestatus
@TNUMBER int
as 
begin
select count(TNUMBER) from TABLE_ where TNUMBER=@TNUMBER and IsOCCUPIED=0;
end
go 
create proc spinsertClient
@TNUMBER int,
@Cname varchar(200)
as 
begin
insert into Client (TNUMBER,CNAME)
values (@TNUMBER, @Cname)
SELECT count(*) from  Client
end
go
create proc updatetablestatus
@TNUMBER int,
@status bit
as 
begin
update TABLE_ 
set IsOCCUPIED= @status
where TNUMBER=@TNUMBER;
end
go
create proc spinsertCR
@CID INT,
@TNUMBER INT,
@TIME time,
@CHECK bit
as
begin
insert into CONTACTREQUEST (CID ,TNUMBER ,TIME_ ,CHECKOUT)
values (@CID, @TNUMBER, @TIME, @CHECK)
end
go
create procedure GetMenuWIthRating
as
begin
select MENUITEMS.ITMNUMBER, MENUITEMS.INAME, AVG(ITEM_RATING.RATE) as AvgRate, MENUITEMS.PRICE, MENUITEMS.CATEGORY
from MENUITEMS
left join ITEM_RATING
ON MENUITEMS.ITMNUMBER= ITEM_RATING.ITMNUMBER
group by MENUITEMS.ITMNUMBER, MENUITEMS.INAME, MENUITEMS.PRICE, MENUITEMS.CATEGORY
ORDER BY MENUITEMS.CATEGORY ASC
end
go
create proc spinsertORDER
@CID INT,
@STATUS INT,
@TNUMBER INT,
@TIME time
as
begin
insert into ORDER_ 
values (@CID, @STATUS,@TNUMBER, @TIME)
SELECT  @@IDENTITY
end
GO
create proc spinsertORMI
@ORDERID INT,
@ITEMNUMBER INT
as
begin
insert into ORDER_MENUITEMS 
values (@ORDERID, @ITEMNUMBER)
end
GO
create proc spinsertRATE
@ITEMNUMBER INT,
@RATE float,
@CID INT
as
begin
insert into ITEM_RATING
values (@ITEMNUMBER, @RATE, @CID)
end
GO
-- Data samples

INSERT into ACCOUNT(USERNAME ,PASSWORD_, TYPE_) VALUES ('admin' ,'admin',0)   -- the admin
,('Ahmed' ,'password1',1)  --chef
,('Hazem4' ,'12345678',1)  --chef
,('Marwan' ,'145678',1) --chef
,('Abdo14' ,'password',2)  --waiter
,('OmarGamal' ,'valar morghulis',2);  --waiter
INSERT INTO CHEF(USERNAME,CHname ) VALUES
('Ahmed' ,'Ahmed Ali Hussein')
,('Hazem4','Hazem Abd-Alrahman')
,('Marwan','Marawn Mohsen');
INSERT INTO Waiter (USERNAME,WNAME) VALUES
('Abdo14','Abd-Alrahman Emad Elsayed'),
('OmarGamal','Omar Gamal Mohamed');
insert into MENUITEMS(INAME , CATEGORY ,PRICE) values
('Chicken shawarma' ,'Sandwitches' ,25),
('Beef shawarma' ,'Sandwitches' ,30),
('Hot dog' ,'Sandwitches' ,25),
('Beef Burger' ,'Burgers' ,40),
('Crispy burger' ,'Burgers' ,35),
('Hot CHicken Burger' ,'Burgers' ,35),
('Pepperoni pizza' ,'Pizzas' ,30),
('Susages pizza' ,'Pizzas' ,40),
('Grilled beef pizza' ,'Pizzas' ,45),
('Vegetable salad' ,'Salad' ,8),
('Vegetable salad large' ,'Salad' ,12),
('coleslaw' ,'Salad' ,10),
('Ketchup' ,'Sauces' ,7),
('Mayounaise' ,'Sauces' ,45),
('Mustard' ,'Sauces' ,10),
('Lemon juice' ,'Juices' ,15),
('Coke' ,'Juices' ,10),
('Pepsi' ,'Juices' ,10),
('Sprite' ,'Juices' ,10),
('Extra Bread' ,'Extra' ,5),
('Extra Fries' ,'Extra' ,5);
-- test clients
insert into TABLE_(IsOCCUPIED)  values (1) ,(1) ,(1)  ,(1);
--
insert into Client (CNAME , TNUMBER) values ('Ahmed hassan' ,1) ,('Emad Hatem' ,2) ,('Captain maged' ,3) ,('Dont wanna say my name' ,4);

-- test ordres
insert into ORDER_(ORDER_.CID ,TNUMBER ,STATUS_ ,OTIME ) values (1,1,0,(CONVERT(time, GETDATE()))),
(2,2,0,(CONVERT(time, GETDATE()))),
(3,3,2,(CONVERT(time, GETDATE()))),
(4,4,0,(CONVERT(time, GETDATE())));

insert into CONTACTREQUEST(CID ,TNUMBER,STATUS_,CHECKOUT ,TIME_ ) values (1,1,0,0,(CONVERT(time, GETDATE()))),
(2,2,0,0,(CONVERT(time, GETDATE()))),
(3,3,0,1,(CONVERT(time, GETDATE()))),
(4,4,2,0,(CONVERT(time, GETDATE())));

insert into ORDER_MENUITEMS (ORDERID ,ITEMNUMBER) values (3,1),(3,2),(3,3),(3,4)
, (2,1),(2,2),(2,3),(2,4);
insert into ITEM_RATING values
(20,3,1),
(20,4,2);


--
--create some tables
go
declare @tables int = 1;
while @tables < 10
begin
insert into TABLE_ default values;
set @tables = @tables +1;
end
go