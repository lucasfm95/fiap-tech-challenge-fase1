# Fiap Tech Challenge

This is a .NET 8 project that provides a RESTful API for managing contacts. The project is written in C# and uses several technologies and frameworks.

[![Build](https://github.com/lucasfm95/fiap-tech-challenge-fase1/actions/workflows/dotnet.yml/badge.svg)](https://github.com/lucasfm95/fiap-tech-challenge-fase1/actions/workflows/dotnet.yml)

## Technologies Used

- **.NET 8**: The latest version of the .NET framework, used for building high-performance, cross-platform applications.
- **C#**: The primary programming language used in this project.
- **ASP.NET Core**: A framework for building web applications.
- **Entity Framework Core**: An object-relational mapper (ORM) that simplifies data access by letting you work with relational data using domain-specific objects.
- **PostgreSQL**: The database used for persisting data.
- **FluentValidation**: A library for building strongly-typed validation rules.

## Project Structure

- `src/Fiap.TechChallenge.Domain`: This project contains the domain entities and repositories interfaces.
- `src/Fiap.TechChallenge.Application`: This project contains the application services and DTOs.
- `src/Fiap.TechChallenge.Api`: This project is the API layer that exposes endpoints to interact with the application.
- `src/Fiap.TechChallenge.Infrastructue`: This project contains the implementation of the repositories and the database context.
- `src/Fiap.TechChallenge.Tests`: This project contains the unit tests for the application services.

## Getting Started

1. Clone the repository.
2. Navigate to the `src/Fiap.TechChallenge.Api` directory.
3. Run `dotnet restore` to restore the NuGet packages.
4. Update the connection string in the `launchSettings.json` file.
5. Run `dotnet run` to start the application.

The API will be available at `http://localhost:5010` and `https://localhost:7010`.

## Running With Docker
1. Navigate to the root directory.
2. Run `docker build -t tech-challenge-api .` to start the application.
3. Run `docker run --name tech-challenge-api -p 5010:80 -d tech-challenge-api` to start the container.
4. The API will be available at `http://localhost:5010`.

## Running Migrations
1. Navigate to the `src/Fiap.TechChallenge.Api` directory.
2. Run `dotnet ef database update` to create the database and run the migrations.
3. The database will be created and the tables will be created.
4. The API will be available at `http://localhost:5010` and `https://localhost:7010`.

## Running the Tests
1. Navigate to the `src/Fiap.TechChallenge.Tests` directory.
2. Run `dotnet test` to run the tests.
3. The test results will be displayed in the console.

## API Endpoints

- `GET /api/contact`: Get all contacts.
- `GET /api/contact/{id}`: Get a contact by ID.
- `GET /api/contact/ddd/{dddNumber}`: Get all contacts by DDD number.
- `POST /api/contact`: Create a new contact.
- `DELETE /api/contact/{id}`: Delete a contact by ID.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
