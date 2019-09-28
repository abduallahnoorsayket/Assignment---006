

CREATE DATABASE CoffeeShop

USE CoffeeShop

CREATE TABLE Customer(
	ID INT IDENTITY(1,1),
	name VARCHAR(30) UNIQUE,
  contact VARCHAR(20),
addreess VARCHAR(30),
orderr VARCHAR(30),
quantity int

)


CREATE TABLE Item(
	ID INT IDENTITY(1,1),
	name VARCHAR(30) UNIQUE,
    price int
)

CREATE TABLE orderr(
	ID INT IDENTITY(1,1),
	name VARCHAR(30),
	item VARCHAR(20) UNIQUE,
	quantity int,
    unitprice int
)


DROP TABLE Customer


SELECT * FROM Customer

SELECT * FROM Item
  
SELECT * FROM orderr  



SELECT * FROM Customer WHERE name='sonia' 
SELECT * FROM Item WHERE name='balck' 

DELETE FROM Item WHERE ID = 18

DELETE FROM Customer WHERE name = 'asik'

UPDATE Item SET  name =  'capachinno' , price = 90 WHERE ID = 17

UPDATE Customer SET  contact =  '01555555555' , addreess ='barisal', orderr='white' WHERE name = 'asik'

UPDATE orderr SET  item =  'yellow' , quantity =5, unitprice=50 WHERE name = 'tania'

INSERT INTO Customer (name,contact,addreess,orderr, quantity)VALUES ('asik','01777777','dhaka','black',2)
INSERT INTO Customer (name,contact,addreess,orderr, quantity)VALUES ('sayket','0188888888','Feni','HOt',3)

INSERT INTO Customer (name,contact,addreess)VALUES ('sayket','018888888','Feni')
INSERT INTO Customer (name,contact,addreess)VALUES ('rakib','0155555555','barisal')
INSERT INTO Customer (name,contact,addreess)VALUES ('tania','013333333','narayangnj')
INSERT INTO Customer (name,contact,addreess)VALUES ('sonia','012222222','manikgonj')

INSERT INTO orderr (name,item,quantity,unitprice)VALUES ('sonia','black',3,120)
INSERT INTO orderr (name,item,quantity,unitprice)VALUES ('tania','cold',2,80)
INSERT INTO orderr (name,item,quantity,unitprice)VALUES ('afsana','Hot',5,90)


INSERT INTO Item (name,price)VALUES ('white',120)
INSERT INTO Item (name,price)VALUES ('IrrRegular',80)
INSERT INTO Item (name,price)VALUES ('Capachinno',150)

INSERT INTO Item VALUES ('kOT',90)
INSERT INTO Item VALUES ('padgCapachino',70)
INSERT INTO Item VALUES ('lame',60)


