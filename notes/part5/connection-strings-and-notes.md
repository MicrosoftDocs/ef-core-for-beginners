# Connection strings and notes for Part 5

Make sure you add your connection string to Secrets Manager! See part 3 if you need a refresher.

## SQL query string for `FromSqlInterpolated`

```csharp
$"SELECT * FROM Customers WHERE Id = {CustomerId}"
```