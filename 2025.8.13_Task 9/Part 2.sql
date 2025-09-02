--Part 02
use AdventureWorks2012

--1. SalesOrders between ‘7/28/2002’ and ‘7/29/2014’
select SalesOrderID,ShipDate from Sales.SalesOrderHeader
WHERE OrderDate BETWEEN '7/28/2002' AND '7/29/2014'

--2. Products with StandardCost below $110
SELECT ProductID, Name
FROM Production.Product
WHERE StandardCost < 110.00;

--3. Products with unknown weight
SELECT ProductID, Name
FROM Production.Product
WHERE Weight IS NULL;

--4. Products with Silver, Black, or Red Color
SELECT ProductID, Name, Color
FROM Production.Product
WHERE Color IN ('Silver', 'Black', 'Red');


--5. Products starting with ‘B’
SELECT ProductID, Name
FROM Production.Product
WHERE Name LIKE 'B%';

--6. Update & find descriptions with underscores
UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3;
--
SELECT ProductDescriptionID, Description
FROM Production.ProductDescription
WHERE Description LIKE '%\_%' ESCAPE '\';

--7. Unique Employee HireDates
SELECT DISTINCT HireDate
FROM HumanResources.Employee
ORDER BY HireDate;

--8. Product name & price between 100 and 120 (formatted)
SELECT 'The ' + Name + ' is only! ' + CAST(ListPrice AS VARCHAR) AS ProductInfo
FROM Production.Product
WHERE ListPrice BETWEEN 100 AND 120
ORDER BY ListPrice;