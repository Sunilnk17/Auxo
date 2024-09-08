# Auxo Project

## Prerequisites

- **.NET SDK 8**: Make sure you have the latest version of the .NET SDK installed. You can download it from [here](https://dotnet.microsoft.com/download/dotnet/8.0).
- **Entity Framework Core 8**: This project uses EF Core 8 for data access.
- A **local database** running (e.g., SQL Server, PostgreSQL, MySQL, etc.).

## Getting Started

1. **Clone the repository**:

   ```bash
   git clone https://github.com/your-username/Auxo.git
   cd Auxo
   ```

2. **Restore dependencies**:

   ```bash
   dotnet restore
   ```

3. **Update the database**:

   If you use docker,

   ```
   docker pull mcr.microsoft.com/mssql/server:2022-latest
   ```

   Ensure you have your database running locally and configured in your `appsettings.json`. Then run the following command to apply the database migrations:

   ```bash
   dotnet ef database update
   ```

4. **Build the project**:

   Compile the project by running the build command:

   ```bash
   dotnet build
   ```

5. **Run the project**:

   To start the application, use:

   ```bash
   dotnet run
   ```

6. **Run the testcases**:

   To run the testcases, use:

   ```bash
   dotnet test
   ```

## Additional Commands

- To apply future database migrations, use:
  ```bash
  dotnet ef migrations add <MigrationName>
  dotnet ef database update
  ```
