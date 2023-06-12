using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api.Models.Character
{
    public class CreateCharacterForm
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string OriginalName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Год должен быть числом положительным")]
        public int? BirthYearBBY { get; set; }

        [Required]
        public Gender? Gender { get; set; }

        [Required]
        [MaxLength(255)]
        public string Race { get; set; }

        [Required]
        [Range(Single.Epsilon, float.MaxValue, ErrorMessage = "Рост должен быть числом положительным")]
        public float? HeightMeters { get; set; }

        [Required]
        [MaxLength(255)]
        public string HairColor { get; set; }

        [Required]
        [MaxLength(255)]
        public string EyeColor { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(255)]
        public string OriginPlanetName { get; set; }

        [Required]
        public IEnumerable<Guid> FilmIds { get; set; }
    }
}
