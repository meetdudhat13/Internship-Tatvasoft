--CREATE OPERATION:-

--customer table
CREATE TABLE customer (
   customer_id SERIAL PRIMARY KEY,  
   first_name VARCHAR(100) NOT NULL,  
   last_name VARCHAR(100) NOT NULL,  
   email VARCHAR(255) UNIQUE NOT NULL,  
   created_date TIMESTAMPTZ NOT NULL DEFAULT NOW(),  
   updated_date TIMESTAMPTZ
);

--order table
CREATE TABLE orders (
    order_id SERIAL PRIMARY KEY,
    customer_id INTEGER NOT NULL REFERENCES customer(customer_id),
    order_date TIMESTAMPTZ NOT NULL DEFAULT NOW(),
    order_number VARCHAR(50) NOT NULL,
    order_amount DECIMAL(10,2) NOT NULL
);


--INSERT VALUES TO TABLE:-

--customer data
INSERT INTO customer (first_name, last_name, email, created_date, updated_date, isAvailable) VALUES
  ('John', 'Doe', 'johndoe@example.com', NOW(), NULL, true),
  ('Alice', 'Smith', 'alicesmith@example.com', NOW(), NULL, true),
  ('Bob', 'Johnson', 'bjohnson@example.com', NOW(), NULL, true),
  ('Emma', 'Brown', 'emmabrown@example.com', NOW(), NULL, true),
  ('Michael', 'Lee', 'michaellee@example.com', NOW(), NULL, false),
  ('Sarah', 'Wilson', 'sarahwilson@example.com', NOW(), NULL, true),
  ('David', 'Clark', 'davidclark@example.com', NOW(), NULL, true),
  ('Olivia', 'Martinez', 'oliviamartinez@example.com', NOW(), NULL, true),
  ('James', 'Garcia', 'jamesgarcia@example.com', NOW(), NULL, false),
  ('Sophia', 'Lopez', 'sophialopez@example.com', NOW(), NULL, false),
  ('Jennifer', 'Davis', 'jennifer.davis@example.com', NOW(), NULL, true),
  ('Jennie', 'Terry', 'jennie.terry@example.com', NOW(), NULL, true),
  ('JENNY', 'SMITH', 'jenny.smith@example.com', NOW(), NULL, false),
  ('Hiren', 'Patel', 'hirenpatel@example.com', NOW(), NULL, false);

--order data  
INSERT INTO orders (customer_id, order_date, order_number, order_amount) VALUES
  (1, '2024-01-01', 'ORD001', 50.00),
  (2, '2024-01-01', 'ORD002', 35.75),
  (3, '2024-01-01', 'ORD003', 100.00),
  (4, '2024-01-01', 'ORD004', 30.25),
  (5, '2024-01-01', 'ORD005', 90.75),
  (6, '2024-01-01', 'ORD006', 25.50),
  (7, '2024-01-01', 'ORD007', 60.00),
  (8, '2024-01-01', 'ORD008', 42.00),
  (9, '2024-01-01', 'ORD009', 120.25),
  (10,'2024-01-01', 'ORD010', 85.00),
  (1, '2024-01-02', 'ORD011', 55.00),
  (1, '2024-01-03', 'ORD012', 80.25),
  (2, '2024-01-03', 'ORD013', 70.00),
  (3, '2024-01-04', 'ORD014', 45.00),
  (1, '2024-01-05', 'ORD015', 95.50),
  (2, '2024-01-05', 'ORD016', 27.50),
  (2, '2024-01-07', 'ORD017', 65.75),
  (2, '2024-01-10', 'ORD018', 75.50);


--UPDATE TABLE AND DATA:-
UPDATE customer
SET first_name = 'meet', last_name = 'dudhat', email = 'meetdudhat@gmail.com'
WHERE customer_id = 1;
  
ALTER TABLE customer ADD COLUMN isAvailable BOOLEAN; 	   --add column
ALTER TABLE customer RENAME COLUMN email TO email_address; --rename column
ALTER TABLE customer RENAME COLUMN email_address TO email; --rename column
ALTER TABLE customer RENAME TO users; --rename table
ALTER TABLE users RENAME TO customer; --rename table

--DELETE DATA:-
DELETE FROM customer WHERE customer_id = 11; --delete rows of data


--SELECT DATA:-
SELECT first_name FROM customer; --select firstname
SELECT first_name, last_name, email FROM customer; --select firstname, lastname and email
SELECT * FROM customer; -- select all data
  
--SORTING THE DATA:-
SELECT first_name, last_name FROM customer ORDER BY first_name ASC; --sort data by firstname(ascending order)
SELECT first_name, last_name FROM customer ORDER BY last_name DESC; --sort data by lastname(descending order)
SELECT customer_id, first_name, last_name FROM customer ORDER BY first_name ASC, last_name DESC;--firstname by ascending and lastname by descending order
  
--DATA SELECTION WITH CONDITION AND PATTERNS:- 
SELECT last_name, first_name FROM customer WHERE first_name = 'Hiren'; --where condition satisfied
SELECT customer_id, first_name, last_name FROM customer WHERE first_name = 'Hiren' AND last_name = 'Parejiya';--use logical operator
SELECT customer_id, first_name, last_name FROM customer WHERE first_name IN ('John', 'David', 'James'); --if firstname is any one of the list 
SELECT first_name, last_name FROM customer WHERE first_name LIKE '%en%'; --check string pattern(case sensitive)
SELECT first_name, last_name FROM customer WHERE first_name ILIKE '%EN%'; --check string pattern(case insensitive)
  
--COMBINE TABLE BY JOINS:-
SELECT * FROM orders AS a INNER JOIN customer AS b ON a.customer_id = b.customer_id; --inner join(intersection of both table)
SELECT * FROM customer AS a LEFT JOIN orders AS b ON a.customer_id = b.customer_id; -- left join(all data from customer and match data from order)

--DATA AGGREGATION WITH GROUP BY:-
SELECT c.customer_id, c.first_name, c.last_name, c.email,
       COUNT(o.order_id) AS NoOrders,--count total number of orders
       SUM(o.order_amount) AS Total --sum of amount of all orders
FROM customer AS c
INNER JOIN orders AS o ON c.customer_id = o.customer_id
GROUP BY c.customer_id;  
  
--GROUP BY WITH HAVING:-
SELECT c.customer_id, c.first_name, c.last_name, c.email,
       COUNT(o.order_id) AS No_Orders,
       SUM(o.order_amount) AS Total
FROM customer AS c
INNER JOIN orders AS o ON c.customer_id = o.customer_id
GROUP BY c.customer_id
HAVING COUNT(o.order_id) > 1; --select data which satisfied given condition

--SUBQUERIES:-
SELECT * FROM orders WHERE customer_id IN (
  SELECT customer_id FROM customer WHERE isAvailable = true
);

--EXIST CLAUSE:-
SELECT customer_id, first_name, last_name, email
FROM customer
WHERE EXISTS (
  SELECT * FROM orders WHERE orders.customer_id = customer.customer_id
);

 
   