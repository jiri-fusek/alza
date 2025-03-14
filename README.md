# Products API

This project is a RESTful API for managing e-shop products, built with ASP.NET Core and following best practices for REST API design and application architecture.

## Table of Contents

- [Features](#features)
- [Architecture](#architecture)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [API Documentation](#api-documentation)
- [Running Tests](#running-tests)
- [Technologies Used](#technologies-used)

## Features

- List all products
- Retrieve a specific product by ID
- Update a product's description
- API versioning with v2 endpoint supporting pagination
- Swagger documentation
- Unit tests covering all endpoints
- Clean Architecture design
- SOLID principles

## Architecture

The solution follows Clean Architecture principles and is structured into the following projects:

- **Api**: ASP.NET Core Web API project containing controllers and configuration
- **Core**: Class library containing business logic, entities, interfaces, and services
- **Infrastructure**: Class library containing data access and persistence
- **Tests**: xUnit test project containing unit tests for controllers and services

## Prerequisites

- .NET 8.0 SDK or later
- Visual Studio 2022 or Visual Studio Code
- SQL Server LocalDB (included with Visual Studio) or SQL Server Express

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/jiri-fusek/alza
cd eshop-products-api
```

### Build the Solution

```bash
dotnet build
```

### Set Up the Database

The application is configured to use LocalDB by default. The database will be created automatically when the application runs.

If you want to use a different SQL Server instance, update the connection string in `appsettings.json`.

### Run the Application

```bash
cd Api
dotnet run
```

The API will be available at `http://localhost:5211`.

## API Documentation

Swagger UI is available at `/swagger` when the application is running:

- http://localhost:5211/swagger

### API Endpoints

#### V1 Endpoints

- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get a product by ID
- `PATCH /api/products/{id}/description` - Update a product's description

#### V2 Endpoints

- `GET /api/v2/products?pageNumber=1&pageSize=10` - Get paginated products
- `GET /api/v2/products/{id}` - Get a product by ID
- `PATCH /api/v2/products/{id}/description` - Update a product's description

## Running Tests

```bash
dotnet test
```

## Technologies Used

- ASP.NET Core 8.0
- Entity Framework Core
- xUnit for testing
- Swagger / OpenAPI
- SQL Server
