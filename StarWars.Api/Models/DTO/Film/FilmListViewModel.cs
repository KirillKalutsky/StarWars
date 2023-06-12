using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api.Models.Film
{
    public class FilmListViewModel
    {
        public IEnumerable<FilmViewModel> Films { get; set; }
    }
}
