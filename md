
dotnet ef migrations add --project KontactPortal.Repository\KontactPortal.Repository.csproj --startup-project KontactPortal.API\KontackPortal.Api.csproj --context KontackPortal.Repository.Helpers.ContactContext --configuration Debug --output-dir Migrations

dotnet ef database update --project .\KontackPortal.Repository\KontackPortal.Repository.csproj --startup-project .\KontackPortal.API\KontackPortal.API.csproj --context ContactContext --configuration Debug
