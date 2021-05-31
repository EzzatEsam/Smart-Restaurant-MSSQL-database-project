-------------Database creation-------------
USE master;
GO
IF DB_ID('RESTDB') IS NOT NULL 
begin
DROP database RESTDB;

end
-----------------
Create database RESTDB;

GO
use RESTDB

--------------TABLE CREATION-------------------

CREATE TABLE ACCOUNT
(
USERNAME CHAR(100) PRIMARY KEY ,
PASSWORD_ VARCHAR(20) NOT NULL,
TYPE_ smallINT not null,
check (type_ >=0 and type_ <=2) -- 0 admin  1 chef 2 waiter
);


CREATE TABLE MENUITEMS
(
ITMNUMBER INT PRIMARY KEY IDENTITY(1,1),
INAME VARCHAR(100) NOT NULL UNIQUE,
PRICE FLOAT NOT NULL ,
Picture image,
CATEGORY VARCHAR(100) NOT NULL,
);
CREATE TABLE TABLE_
(
TNUMBER INT PRIMARY KEY ,
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
NUMBER INT PRIMARY KEY,
CID INT NOT NULL FOREIGN KEY REFERENCES Client    ON DELETE CASCADE,
TNUMBER INT NOT NULL FOREIGN KEY REFERENCES TABLE_ ,
TIME_ TIME,
TYPE_ VARCHAR(50),
);

CREATE TABLE ORDER_
(
   ORDERID INT PRIMARY KEY,
   CID INT FOREIGN KEY REFERENCES CLIENT  ON DELETE CASCADE,
   STATUS_ CHAR(12),    --pending / ready/ delivered
   CHECKOUT BIT NOT NULL,     
   TNUMBER INT FOREIGN KEY REFERENCES TABLE_ ,
   OTIME TIME,
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
ORDERID INT NOT NULL FOREIGN KEY REFERENCES ORDER_ ON DELETE CASCADE,
ITEMNUMBER INT NOT NULL FOREIGN KEY REFERENCES MENUITEMS ON DELETE CASCADE ,
);


CREATE TABLE ITEM_RATING
(
ITMNUMBER INT NOT NULL FOREIGN KEY REFERENCES MENUITEMS ON DELETE CASCADE 
ON UPDATE CASCADE,
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
ROLLBACK TRANSACTION
END
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
select CHID ,CHNAME ,ISFREE ,C_SERVING from CHEF 
union select WID ,WNAME ,ISFREE ,C_SERVING  from WAITER where C_SERVING is not null 
union select WID ,WNAME ,ISFREE ,C_RESPONSE  from WAITER where C_RESPONSE is not null
union select WID ,WNAME ,ISFREE ,C_RESPONSE  from WAITER 
;
end
go
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
INSERT INTO Waiter (USERNAME,WNAME) VALUES ('Abdo14','Abd-Alrahman Emad Elsayed'),
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



--
