# SQL queries
Add the following db queries in the pgadmin to create the db and table accordingly.


## Create the Coupon table
CREATE TABLE Coupon(
	ID SERIAL PRIMARY KEY NOT NULL,
	ProductName VARCHAR(24) NOT NULL,
	Description TEXT,
	Amount INT
);

## Seed the data
INSERT INTO Coupon (ProductName, Description, Amount) VALUES ('NewPhone', 'NewPhone Discount', 150);
INSERT INTO Coupon (ProductName, Description, Amount) VALUES ('IPhone X', 'IPhone X Discount', 100);