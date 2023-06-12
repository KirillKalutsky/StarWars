using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api.Models.Character
{
    public class SearchCharacterResultViewModel
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public IEnumerable<SearchCharacterViewModel> Characters { get; set; }
    }
}
