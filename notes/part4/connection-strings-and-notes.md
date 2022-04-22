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

## Create a Cosmos DB resource

Azure subscription required. Get one here.

```az-cli
az login
az group 
az cosmos
```
