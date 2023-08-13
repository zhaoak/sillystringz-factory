# Dr. Sillystringz's Factory

### By Allie Zhao

## Description

Simple C#/ASP.NET web application built for use with a MySQL (or otherwise 
compatible) database. Allows user to add, edit, and track a list of factory machines
and engineers for those machines, along with information on which engineers are licensed
to repair which machines to the database and update that information through the web app.

## Technologies Used

- C#
- ASP.NET
- Entity Framework Core
- MySQL (or other client-compatible RMDBS)

## Setup/Installation Requirements

### Database setup

- set up a MySQL (or otherwise client protocol compatible) database instance
- create a new database `[your_db_name]`, using a name of your choice
    - to do this, enter `CREATE DATABASE [your_db_name];` in your DB shell
    - you may also use a GUI database tool like MySQL Workbench
- in the `Factory` directory, create the file `appsettings.json`, containing the following

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=[your_database_address];Port=3306;database=[your_db_name];uid=[your_db_login];pwd=[your_db_password];"
  }
}
```

- substitute fields in square brackets with your own database information
- also change port value if your database is not configured to use 3306
- from the `Factory` directory, apply the included database migration
    - the command for this is `dotnet ef database update`
    - ensure your database instance is running first

### Web application setup

- clone repository to location of your choice
- ensure .NET 6 SDK is installed and correctly configured
- ensure proper .NET dependencies are retrieved
    - this should happen automatically with `dotnet run`
- navigate to `Factory` directory
- in your terminal, enter `dotnet run`
- in your browser, open `http://localhost:5001`


## Known Bugs

None yet! 

## License

MIT

Copyright (c) 2023 Allie Zhao
