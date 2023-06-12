using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Api.Models.Character
{
    public class SearchCharacterViewModel
    {
        public Guid CharacterId { get; set; }
        public string Name { get; set; }
        public string OriginName { get; set; }
    }
}
