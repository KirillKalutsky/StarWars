using StarWars.Api.Models;
using StarWars.Api.Models.Character;
using Common.DataLayer;
using Microsoft.EntityFrameworkCore;
using StarWars.Api.DataLayer;
using StarWars.Api.DataLayer.Entities;
using Common;

namespace StarWars.Api.Services
{
    public static class CharacterService
    {
        public static async Task<CharacterViewModel> FindStarWarsCharacterAsync(
            this IHave<IReadDbContext<IStarWarsEntity>> context,
            Guid characterId)
        {
            var character = await context.Get<Character>()
                .ById(characterId)
                .FirstOrDefaultAsync();

            if (character == null)
                return null;

            return new CharacterViewModel
            {
                Name = character.Name,
                OriginalName = character.OriginalName,
                EyeColor = character.EyeColor,
                Films = character.FilmLinks?.Select(link => link.Film.Name),
                Gender = character.Gender.ConvertToReadable(),
                HairColor = character.HairColor,
                Height = $"{character.HeightMeters}",
                OriginPlanetName = character.OriginPlanetName,
                Race = character.Race,
                BirthYear = $"{character.BirthYearBBY}",
                Description = character.Description,
            };
        }

        public static CreateCharacterResultViewModel CreateStarWarsCharacter(
            this IHave<IWriteDbContext<IStarWarsEntity>> context,
            CreateCharacterForm createForm)
        {
            var character = new Character()
            {
                Id = Guid.NewGuid(),
                Name = createForm.Name,
                OriginalName = createForm.OriginalName,
                Description = createForm.Description,
                EyeColor = createForm.EyeColor,
                Gender = createForm.Gender.Value,
                HairColor= createForm.HairColor,
                HeightMeters = createForm.HeightMeters.Value,
                OriginPlanetName = createForm.OriginPlanetName,
                Race = createForm.Race,
                BirthYearBBY = createForm.BirthYearBBY.Value,
            };

            context.Add(character);

            foreach(var filmId in createForm.FilmIds)
            {
                context.Add(new FilmCharacterLink { CharacterId = character.Id, FilmId = filmId });
            }

            return new CreateCharacterResultViewModel
            {
                CharacterId = character.Id
            };
        }

        public static async Task<ValidationResult> ValidateCreateStarWarsCharacterFormAsync(
            this IHave<IReadDbContext<IStarWarsEntity>> context,
            CreateCharacterForm createForm)
        {
            var filmIds = createForm.FilmIds.ToHashSet();

            var films = await context.Get<Film>().ByIds(filmIds)
                .ToListAsync();

            var findFilmIds = films.Select(film => film.Id).ToHashSet();

            if (films.Count == filmIds.Count)
                return new ValidationResult { IsValid = true };

            return new ValidationResult
            {
                ErrorMessage = $"Не существует фильмов с id: {string.Join(", ",filmIds.Where(id => !findFilmIds.Contains(id)))}"
            };
        }

        public static async Task<SearchCharacterResultViewModel> SearchStarWarsCharacterAsync(
            this IHave<IReadDbContext<IStarWarsEntity>> context, SearchCharacterForm searchForm)
        {
            var pageSize = searchForm.PageSize ?? 20;
            var pageNumber = searchForm.PageNumber ?? 1;

            var characterQuery = context.Get<Character>()
                .ByGender(searchForm.Gender.HasValue, searchForm.Gender)
                .ByOriginPlanetName(!string.IsNullOrWhiteSpace(searchForm.PlanetName), searchForm.PlanetName)
                .ByFilmIds(searchForm.Films != null, searchForm.Films);

            if (searchForm.ToBirthYearBBY.HasValue)
                characterQuery = characterQuery.Where(character => character.BirthYearBBY <= searchForm.ToBirthYearBBY.Value);

            if (searchForm.FromBirthYearBBY.HasValue)
                characterQuery = characterQuery.Where(character => character.BirthYearBBY >= searchForm.FromBirthYearBBY.Value);
           
            var characters = await characterQuery.Skip(pageSize * (pageNumber - 1))
                .OrderBy(character => character.Name)
                .Take(pageSize)
                .ToListAsync();

            return new SearchCharacterResultViewModel()
            {
                TotalCount = characterQuery.Count(),
                PageSize = pageSize,
                PageNumber = pageNumber,
                Characters = characters.Select(character => new SearchCharacterViewModel()
                {
                    CharacterId = character.Id,
                    Name = character.Name,
                    OriginName = character.OriginalName
                })
            };
        }

        public static async Task<SearchCharacterDataViewModel> GetStarWarsCharacterSearchData(
            this IHave<IReadDbContext<IStarWarsEntity>> context)
        {
            var characterFilms = await context.Get<FilmCharacterLink>()
                .Select(link => new {FilmName = link.Film.Name, FilmId = link.FilmId})
                .ToListAsync();

            var planetNames = await context.Get<Character>()
                .Select(character => character.OriginPlanetName)
                .Distinct()
                .ToListAsync();

            return new SearchCharacterDataViewModel()
            {
                Films = characterFilms.Select(film => new SelectItem<Guid> { Text = film.FilmName, Value = film.FilmId }),
                Planets = planetNames,
                Genders = Enum.GetValues(typeof(Gender)).Cast<Gender>()
                    .Select(gender => new SelectItem<Gender> { Text = gender.ConvertToReadable(), Value = gender })
            };
        }

        public static async Task EditStarWarsCharacterAsync<TContext>(this TContext context, Character character, EditCharacterForm editForm)
            where TContext:
            IHave<IWriteDbContext<IStarWarsEntity>>,
            IHave<IReadDbContext<IStarWarsEntity>>
        {
            context.Attach(character);

            character.Option(editForm.Gender.HasValue, c => c.Gender = editForm.Gender.Value)
                .Option(editForm.HeightMeters.HasValue, c => c.HeightMeters = editForm.HeightMeters.Value)
                .Option(editForm.BirthYearBBY.HasValue, c => c.BirthYearBBY = editForm.BirthYearBBY.Value)
                .Option(!string.IsNullOrWhiteSpace(editForm.EyeColor), c => c.EyeColor = editForm.EyeColor)
                .Option(!string.IsNullOrWhiteSpace(editForm.Description), c => c.Description = editForm.Description)
                .Option(!string.IsNullOrWhiteSpace(editForm.HairColor), c => c.HairColor = editForm.HairColor)
                .Option(!string.IsNullOrWhiteSpace(editForm.Name), c => c.Name = editForm.Name)
                .Option(!string.IsNullOrWhiteSpace(editForm.OriginalName), c => c.OriginalName = editForm.OriginPlanetName)
                .Option(!string.IsNullOrWhiteSpace(editForm.OriginPlanetName), c => c.OriginPlanetName = editForm.OriginPlanetName)
                .Option(!string.IsNullOrWhiteSpace(editForm.Race), c => c.Race = editForm.Race);


            if (editForm.FilmIds != null)
            {
                var newFilmIds = editForm.FilmIds.ToHashSet();
                var currentFilmIds = character.FilmLinks.Select(link => link.FilmId).ToHashSet();

                var deleteFilmIds = currentFilmIds.Where(id => !newFilmIds.Contains(id));
                var createFilmIds = newFilmIds.Where(id => !currentFilmIds.Contains(id));

                foreach (var deleteFilm in await context.Get<Film>().ByIds(deleteFilmIds).ToListAsync())
                    context.Delete(deleteFilm);

                foreach (var createFilmId in createFilmIds)
                    context.Add(new FilmCharacterLink
                    {
                        CharacterId = character.Id,
                        FilmId = createFilmId
                    });
            }
        }

        private static T Option<T>(this T value, bool flag, Action<T> edit)
            where T : class
        {
            if (flag)
                edit(value);
            return value;
        }
    }
}
