# CodeBase_API

## Overview
CodeBase_API is a .NET Core-based API architecture designed to demonstrate the use of Dapper for data access and JWT (JSON Web Tokens) for authentication. This project follows a modular architecture with clearly separated layers, making it easier to maintain and extend.

## Project Structure
The project is organized into the following folders:

- **Ginilytics.Api**: Contains the API controllers and middleware setup.
- **Ginilytics.Common**: Includes shared code, utilities, and constants used across the solution.
- **Ginilytics.Model**: Defines the data models used throughout the application.
- **Ginilytics.Repository**: Implements the repository pattern using Dapper to interact with the database.
- **Ginilytics.Service**: Contains business logic and services that are consumed by the API.
- **Ginilytics.UnitTest**: Unit tests for the services and repository layers.

## Key Features
- **Dapper for Data Access**: Dapper is used as a micro ORM to efficiently execute SQL queries and map the results to C# objects.
- **JWT Authentication**: Implements JWT token-based authentication for securing the API endpoints.
- **Modular Structure**: Follows a clean architecture with separated concerns for API, data access, business logic, and models.

## Technologies Used
- .NET Core
- Dapper
- SQL Server
- JWT (JSON Web Tokens)
- Unit Testing with NUnit

## Setup Instructions

### Prerequisites
- .NET SDK
- SQL Server
- Visual Studio or any preferred IDE

### JWT Token Usage
- To authenticate, you will need to generate a JWT token. A sample authentication endpoint is provided to issue tokens after validating user credentials.
- Include the token in the `Authorization` header of your API requests.
    

### Unit Testing
Run the unit tests by executing:
```bash
dotnet test
