using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api.Models.Character
{
    public class SearchCharacterDataViewModel
    {
        public IEnumerable<SelectItem<Guid>> Films { get; set; }
        public IEnumerable<string> Planets { get; set; }
        public IEnumerable<SelectItem<Gender>> Genders { get; set; }
    }
}
