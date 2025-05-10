Install .NET 6 SDK
Install Docker
Install PostgreSQL
Download NuGet packets:
```
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Design
Microsoft.VisualStudio.Azure.Containers.Tools.Targets
Npgsql.EntityFrameworkCore.PostgreSQL
Swashbuckle.AspNetCore
```
Via Swagger UI:
Clone the repository and checkout the dev branch:
```
git clone https://github.com/DEMOCRATIC59/C-Trainee.git
cd C-Trainee
git checkout dev
cd Application
```
Restore dependencies:
```
dotnet restore .\Trainee.sln
```
Configure the database connection string in appsettings.json:
```
"ConnectionStrings": {
    "DefaultConnection": "Host=postgres_db;Port=5432;Database=mydatabase;Username=admin;Password=Admin123!;"
  }
```
Apply database migrations:
```
dotnet ef database update
```
Run the application:
```
dotnet run
```
Access Swagger UI in your browser:
```
http://localhost:5042/swagger
```
Via Docker:
Ensure Docker is running
Build the Docker image from the dev branch:
```
docker build -t c-trainee-app .
```
Run the container:
```
docker-compose up -d
```
Open PgAdmin:
```
http://localhost:5050
```