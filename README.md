# GameStore API

This is a .NET 8.0 project that provides a RESTful API for a game store. The API allows you to manage games and genres in the store.

## Project Structure

The project is structured into several directories:

- `Data`: Contains the database context and extensions.
- `Dtos`: Contains the data transfer objects used for requests and responses.
- `Endpoints`: Contains the implementation of the API endpoints.
- `Entities`: Contains the entity classes.
- `Mapping`: Contains the mapping configurations between entities and DTOs.

## Endpoints

The API provides the following endpoints:

- `GET /games`: Fetches all games.
- `GET /games/{id}`: Fetches a specific game by its ID.
- `POST /games`: Creates a new game. The request body should be a JSON object that includes `Name`, `GenreId`, `Price`, and `ReleaseDate`.
- `PUT /games/{id}`: Updates a specific game by its ID. The request body should be a JSON object that includes `Name`, `GenreId`, `Price`, and `ReleaseDate`.
- `DELETE /games/{id}`: Deletes a specific game by its ID.
- `GET /genres`: Fetches all genres.

## Running the Project

To run the project, follow these steps:

1. Ensure you have .NET 8.0 installed.
2. Open a terminal in the [``GameStore.Api``](command:_github.copilot.openRelativePath?%5B%7B%22scheme%22%3A%22file%22%2C%22authority%22%3A%22%22%2C%22path%22%3A%22%2Fhome%2Fduttts%2Fdotnet%2FGamestore%2FGameStore.Api%22%2C%22query%22%3A%22%22%2C%22fragment%22%3A%22%22%7D%5D "/home/duttts/dotnet/Gamestore/GameStore.Api") directory.
3. Run the command `dotnet run`.

The API will start and listen on `http://localhost:5174`.

## Database

The project uses SQLite as its database. The connection string is configured in `appsettings.json`. The database is automatically migrated to the latest version when the application starts.
