using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api.Models.Film
{
    public class FilmCreateForm
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime? ReleaseDate { get; set; }
    }
}
