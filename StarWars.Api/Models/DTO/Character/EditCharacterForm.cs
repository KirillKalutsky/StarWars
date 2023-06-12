﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api.Models.Character
{
    public class EditCharacterForm
    {
        [MaxLength(255)]
        public string? Name { get; set; }

        [MaxLength(255)]
        public string? OriginalName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Год должен быть числом положительным")]
        public int? BirthYearBBY { get; set; }
        public Gender? Gender { get; set; }

        [MaxLength(255)]
        public string? Race { get; set; }

        [Range(Single.Epsilon, float.MaxValue, ErrorMessage = "Рост должен быть числом положительным")]
        public float? HeightMeters { get; set; }

        [MaxLength(255)]
        public string? HairColor { get; set; }

        [MaxLength(255)]
        public string? EyeColor { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [MaxLength(255)]
        public string? OriginPlanetName { get; set; }
        public IEnumerable<Guid>? FilmIds { get; set; }
    }
}
