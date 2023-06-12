using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api.Models.Character
{
    public class CharacterViewModel
    {
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Description { get; set; }
        public string OriginPlanetName { get; set; }
        public IEnumerable<string> Films{ get; set; }
    }
}
