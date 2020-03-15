# Software Architecture:
[ ] 4-Tier (UI, BLL, BOL, DAL)
[x] 3-Tier (UI, BLL, DAL)
[ ] Clean Architecture

# Database
[x] MSSQL

# Database ORM
[x] Entity Framework
[ ] Dapper
[ ] NHibernate


# MSSQL
Start MSSQL with Docker
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=MyPass@word" -e "MSSQL_PID=Express" -p 1433:1433 -d --name=sql microsoft/mssql-server-linux:latest
```

# Migration
Install EF
```
dotnet tool install --global dotnet-ef
```

Create initial
```
dotnet ef migrations add InitialCreate
```

Update the database
```
dotnet ef database update
```