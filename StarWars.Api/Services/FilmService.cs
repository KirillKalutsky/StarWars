using Common;
using StarWars.Api.Models.Film;
using Common.DataLayer;
using Microsoft.EntityFrameworkCore;
using StarWars.Api.DataLayer;
using StarWars.Api.DataLayer.Entities;

namespace StarWars.Api.Services
{
    public static class FilmService
    {
        public static FilmCreateResultViewModel CreateFilm(
            this IHave<IWriteDbContext<IStarWarsEntity>> context, 
            FilmCreateForm createForm)
        {
            var film = new Film()
            {
                Id = Guid.NewGuid(),
                Name = createForm.Name,
                ReleaseDate = createForm.ReleaseDate.Value
            };

            context.Add(film);

            return new FilmCreateResultViewModel { FilmId = film.Id };
        }

        public static async Task<FilmListViewModel> GetFilms(this IHave<IReadDbContext<IStarWarsEntity>> context)
        {
            return new FilmListViewModel() 
            {
                Films = (await context.Get<Film>()
                    .OrderBy(film=>film.ReleaseDate)
                    .ThenBy(film=>film.Name)
                    .ToListAsync())
                    .Select(film => new FilmViewModel 
                    { 
                        FilmId = film.Id, 
                        FilmName = film.Name
                    })
            };
        }

    }
}
