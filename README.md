# Clean Architecture App

Demonstration project of Clean Architecture with ASP.NET Core and Lego style programming

This project is a starting point for a ASP.NET Core application using Clean Architecture.
This illustrated high separation of concerns and the use of SOLID principles.

## Development tools

Install SQL Server Developer or use LocalDB
https://www.microsoft.com/en-us/sql-server/sql-server-downloads

Install latest NET 8 SDK from https://dotnet.microsoft.com/download/dotnet-core/8.0

Install EF core tools
```bash
dotnet tool update --global dotnet-ef
```

## Configuration

Create appsettings.local.json file to override selected values from appsettings.json/appsettings.Development.json, without the need to handle changes with GIT

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=CleanArchitecture;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```
