# Notes and snippets for part 3

## Program.cs snippet

```csharp
builder.Services.AddDbContext<ContosoPizzaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ContosoPizza")));
```

## Connection Strings

### SQL Server Express LocalDB

```text
Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ContosoPizza;Integrated Security=True;
```

### Dev Container

```text
Data Source=localhost;Database=ContosoPizza;Integrated Security=false;User ID=sa;Password=P@ssw0rd;
```

## User Secrets

### secrets.json

> **Important!**: Be sure any `\` characters are properly escaped for JSON encoding (e.g., `\` in the connection string is `\\` in *secrets.json*)!

```json
{
  "ConnectionStrings:ContosoPizza": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ContosoPizza;Integrated Security=True;"
}
```

### `dotnet` commands

```dotnet-cli
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:ContosoPizza" "Connection String Here"
```

## Scaffolding with `dotnet`

```dotnet-cli
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet aspnet-codegenerator razorpage --model Product --dataContext ContosoPizzaContext --relativeFolderPath Pages/Products --referenceScriptLibraries
```

dotnet user-secrets set "ConnectionStrings:ContosoPizza" "Data Source=localhost;Database=ContosoPizza;Integrated Security=false;User ID=sa;Password=P@ssw0rd;"
