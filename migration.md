
dotnet ef migrations add newMigrations --project .\KontackPortal.Repository\KontackPortal.Repository.csproj --startup-project .\KontackPortal.API\KontackPortal.API.csproj --context ContactContext --configuration debug --output-dir Migrations


dotnet ef database update --project .\KontackPortal.Repository\KontackPortal.Repository.csproj --startup-project .\KontackPortal.API\KontackPortal.API.csproj --context ContactContext --configuration Debug
