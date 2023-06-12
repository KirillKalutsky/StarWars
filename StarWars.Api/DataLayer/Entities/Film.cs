using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StarWars.Api.DataLayer.Entities
{
    public class Film : IStarWarsEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Index]
        [MaxLength(255)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
    }

    public static class FilmExtension
    {
        public static IQueryable<Film> ByIds(this IQueryable<Film> films, IEnumerable<Guid> ids) =>
            films.Where(film => ids.Contains(film.Id));
    }
}
