using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using StarWars.Api.Models;
using System.Linq;

namespace StarWars.Api.DataLayer.Entities
{
    public class Character : IStarWarsEntity
    {
        //имя, дата рождения, планета происхождения, пол, раса, рост, цвет волос, цвет глаз, описание, фильмы в которых задействован.
        [Key]
        public Guid Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string OriginalName { get; set; }

        [Index]
        public int BirthYearBBY { get; set; }

        [Index]
        public Gender Gender { get; set; }

        [MaxLength(255)]
        public string Race{ get; set; }
        public float HeightMeters { get; set; }

        [MaxLength(255)]
        public string HairColor { get; set; }

        [MaxLength(255)]
        public string EyeColor { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Index]
        [MaxLength(255)]
        public string OriginPlanetName { get; set; }

        public virtual IEnumerable<FilmCharacterLink> FilmLinks { get; set; }
    }

    public static class CharacterExtensions
    {
        public static IQueryable<Character> ById(this IQueryable<Character> characters, Guid characterId) =>
            characters.Where(character => character.Id == characterId);

        public static IQueryable<Character> ByFilmIds(this IQueryable<Character> characters, bool flag, IEnumerable<Guid> filmIds) =>
            flag ? characters.ByFilmIds(filmIds) : characters;
        public static IQueryable<Character> ByFilmIds(this IQueryable<Character> characters, IEnumerable<Guid> filmIds) =>
            characters.Where(character => character.FilmLinks.Any(link => filmIds.Contains(link.FilmId)));

        public static IQueryable<Character> ByGender(this IQueryable<Character> characters, bool flag, Gender? gender) =>
            flag ? characters.ByGender(gender.Value) : characters;
        public static IQueryable<Character> ByGender(this IQueryable<Character> characters, Gender gender) =>
            characters.Where(character => character.Gender == gender);

        public static IQueryable<Character> ByOriginPlanetName(this IQueryable<Character> characters, bool flag, string planetName) =>
            flag ? characters.ByOriginPlanetName(planetName) : characters;
        public static IQueryable<Character> ByOriginPlanetName(this IQueryable<Character> characters, string planetName) =>
            characters.Where(character => character.OriginPlanetName.Contains(planetName));
    }
}
