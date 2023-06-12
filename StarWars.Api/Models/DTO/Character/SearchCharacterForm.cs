using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api.Models.Character
{
    public class SearchCharacterForm
    {
        [Range(1, int.MaxValue, ErrorMessage = "Год должен быть числом положительным")]
        public int? FromBirthYearBBY { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Год должен быть числом положительным")]
        public int? ToBirthYearBBY { get; set; }
        public IEnumerable<Guid>? Films { get; set; }
        public string? PlanetName { get; set; }
        public Gender? Gender { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Номер страницы должен быть числом положительным")]
        public int? PageNumber { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Размер страницы должен быть числом положительным")]
        public int? PageSize { get; set;}
    }
}
