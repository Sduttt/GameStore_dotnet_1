

using GameStore.Api.Data;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints
{
    public static class GenreEndpoints
    {
        public static RouteGroupBuilder MapGenreEndpoints(this WebApplication app)
        {
            RouteGroupBuilder genreGroup = app.MapGroup("genres");

            genreGroup.MapGet("/", async (GameStoreContext dbContext) => 
                await dbContext.Genre.Select(genre => genre.ToDto()).AsNoTracking().ToListAsync()
            );

            return genreGroup;
        }
    }
}