# Connection strings for Part 1

## If you are using SQL Server Express LocalDB

```text
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ContosoPizza;Integrated Security=True;
```

The full `Scaffold-DbContext` command is:

```powershell
Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ContosoPizza;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -ContextDir Data -OutputDir Models
```

## If you are using SQL Server in the dev container

```text
Data Source=localhost;Database=ContosoPizza;Integrated Security=false;User ID=sa;Password=P@ssw0rd;
```

The full `dotnet ef` command is:

```dotnet-cli
dotnet ef dbcontext scaffold "Data Source=localhost;Database=ContosoPizza;Integrated Security=false;User ID=sa;Password=P@ssw0rd;" Microsoft.EntityFrameworkCore.SqlServer --context-dir Data --output-dir Models
```