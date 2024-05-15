using GameStore.Api.Data;
using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        RouteGroupBuilder gamesGroup = app.MapGroup("games");
        // Get Games
        gamesGroup.MapGet("", async (GameStoreContext dbContext) => 
            await dbContext.Games
                .Include(game => game.Genre)
                .Select(game => game.ToGameDto())
                .AsNoTracking()
                .ToListAsync()
        );

        // Get Single Game
        gamesGroup.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
            {

                Game? game = await dbContext.Games.FindAsync(id);
                if (game == null)
                {
                    return Results.NotFound();
                }
                else return Results.Ok(game.ToGameDetailsDto());
            }
        ).WithName("GetGame");

        // Add Game
        gamesGroup.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
            {
                Game game = newGame.ToEntity();

                
                dbContext.Games.Add(game);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game.ToGameDetailsDto());
            }
        ).WithParameterValidation();

        // Update Game
        gamesGroup.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
            {
                var existingGame = await dbContext.Games.FindAsync(id);
                if (existingGame is null)
                {
                    return Results.NotFound();
                }
                
                dbContext.Entry(existingGame)
                    .CurrentValues
                    .SetValues(updatedGame.ToEntity(id));

                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            }
        ).WithParameterValidation();

        gamesGroup.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
            {
                await dbContext.Games
                    .Where(game => game.Id == id)
                    .ExecuteDeleteAsync();
            }
        );

        return gamesGroup;
    }
}
