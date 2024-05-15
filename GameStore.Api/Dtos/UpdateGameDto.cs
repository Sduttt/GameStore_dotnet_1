
using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;
public record class UpdateGameDto
(
    [Required] [StringLength(55)] string Name,
    int GenreId,
    [Required] [Range(1, 999)] decimal Price,
    DateOnly ReleaseDate
);
