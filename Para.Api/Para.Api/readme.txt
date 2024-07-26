create migration SQL Server
     dotnet ef migrations add initialCreate -s ../Para.Api/ --context ParaDbContext
create migration PostgreSQL Server
     dotnet ef migrations add InitialCreate -s ../Para.Api/ --context ParaDbContext   
     ef migrations remove 
  
db guncelleme SQL 
     dotnet ef database update --project "./Para.Data" --startup-project "Para.Api/" --context ParaDbContext
db guncelleme Postgre
     dotnet ef database update --project "./Para.Data" --startup-project "Para.Api/" --context ParaDbContext