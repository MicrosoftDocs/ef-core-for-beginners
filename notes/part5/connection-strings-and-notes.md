# Connection strings and notes for Part 5


```
Customer = await _context.Customers
    .FromSqlInterpolated($"SELECT * FROM Customers WHERE Id = {CustomerId}")
    .FirstOrDefaultAsync();
```