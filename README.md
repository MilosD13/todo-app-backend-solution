# TodoApp Backend

This backend is part of the TodoApp project, which includes a front-end Angular application and this backend web API application.
The backend provides functionality for creating and managing todo tasks for individual users and authenticates users using JWT tokens.

## Table of Contents

- [Project Description](#project-description)
- [Technologies Used](#technologies-used)
- [Installation Instructions](#installation-instructions)
- [Running the Project](#running-the-project)
- [API Endpoints](#api-endpoints)
- [Authentication](#authentication)
- [Configuration](#configuration)
- [Troubleshooting](#troubleshooting)

## Project Description

The TodoApp backend provides a RESTful API to manage todo tasks for individual users.
It includes user authentication(as an example as it has manually added 2 users for testing pourpases) using JWT tokens and supports CRUD operations on todo tasks.
The backend is built with ASP.NET Core and utilizes a SQL Server database.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger/OpenAPI
- Health Checks

## Installation Instructions

### Prerequisites

- .NET 8 SDK or later
- SQL Server
- Visual Studio or Visual Studio Code

### Steps

1. **Clone the repository**:
   git clone `link to the repo`

2. Navigate to the backend project directory:
   cd `TodoApp`

3. Install dependencies:
   `dotnet restore`

4. Set up the database:

- Update the connection string in appsettings.json to point to your SQL Server instance.
- Run the SQL scripts in the TodoDb/dbo/StoredProcedures directory to create the necessary stored procedures and tables.
  Or in Visual Studio just right click on the db and `publish` and point it to your local SQL server instance.

## Running the Project

1. Start the backend server:
   `dotnet run` or just run it with Visual Studio code, making sure that the api project is selected as a startup project.

2. Access the API:
   Open your browser and navigate to `https://localhost:7035/swagger` to view the Swagger UI and test the API endpoints.

## API Endpoints

Please run the project and view Swagger as it has all the necesary information.

## Authentication

The application uses JWT (JSON Web Tokens) for authentication.
The token is stored in the browser's local storage upon successful login and is included in the Authorization header for subsequent API requests.
This is just a demo of my capabilities and NOT a production ready auth.

## Configuration

Configuration settings are managed in the appsettings.json file. Key settings include:

1. Connection Strings:

```
"ConnectionStrings": {
  "Default": "YourConnectionStringHere"
}
```

2. Authentication:

```
"Authentication": {
"Issuer": "your-issuer",
"Audience": "your-audience",
"SecretKey": "your-secret-key"
}
```

## Troubleshooting

### Common Issues

1. Database Connection Issues:
   Ensure your connection string in appsettings.json is correct and the SQL Server instance is running.

2. Authentication Errors:
   Verify that the JWT token is correctly configured and passed in the Authorization header.
