# Fiap Tech Challenge

This is a .NET 8 project that provides a RESTful API for managing contacts. The project is written in C# and uses several technologies and frameworks.

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

## Getting Started

1. Clone the repository.
2. Navigate to the `src/Fiap.TechChallenge.Api` directory.
3. Run `dotnet restore` to restore the NuGet packages.
4. Update the connection string in the `launchSettings.json` file.
5. Run `dotnet run` to start the application.

The API will be available at `http://localhost:5010` and `https://localhost:7010`.

## API Endpoints

- `GET /api/contact`: Get all contacts.
- `GET /api/contact/{id}`: Get a contact by ID.
- `GET /api/contact/ddd/{dddNumber}`: Get all contacts by DDD number.
- `POST /api/contact`: Create a new contact.
- `DELETE /api/contact/{id}`: Delete a contact by ID.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
