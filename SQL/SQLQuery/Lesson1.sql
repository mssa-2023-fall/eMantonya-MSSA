SELECT CONCAT(CustomerName, WebsiteURL) as "Customer Name And Web Site"
FROM Sales.Customers;

--Comment
SELECT LEFT(CustomerName,1) "CustomerInitial", Count(CustomerID) as COUNT
FROM Sales.Customers
Group by LEFT(CustomerName,1)

SELECT 
    DATEPART(ww, o.OrderDate) as "Week",
    DATEPART(dw, o.OrderDate) as "DayofWeek",
    COUNT(OrderID) as "NumberOfOrders"
FROM Sales.Orders o
GROUP BY DATEPART(ww, o.OrderDate),DATEPART(dw, o.OrderDate)
ORDER BY 1, 2