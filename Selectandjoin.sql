SELECT CustomerId, Name FROM Customers
SELECT * FROM Bookings
INNER JOIN Customers ON Bookings.CustomerID=Customers.CustomerID;