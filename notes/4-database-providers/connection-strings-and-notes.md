# Connection strings and notes for Part 4

### ContosoPizza.csproj snippet

```xml
<StartWorkingDirectory>$(MSBuildProjectDirectory)</StartWorkingDirectory>
```

## Postgres in the dev container

Connection string:

```text
User ID=postgres;Password=P@ssw0rd;Host=localhost;Port=5432;Database=ContosoPizza;
```

SELECT:

```sql
SELECT * FROM "Products"
```

## Azure Cosmos DB

You can use an actual Cosmos DB account in the cloud, or you can use the local emulator.

- [Quickstart: Create an Azure Cosmos account, database, container, and items from the Azure portal](https://docs.microsoft.com/azure/cosmos-db/sql/create-cosmosdb-resources-portal)
- [Azure Cosmos DB local emulator](https://docs.microsoft.com/azure/cosmos-db/local-emulator)
- [Free Azure Account](https://azure.microsoft.com/free/dotnet/)
