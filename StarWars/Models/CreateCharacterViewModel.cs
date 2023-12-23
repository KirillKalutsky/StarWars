using Microsoft.AspNetCore.Mvc.Rendering;
using StarWars.Api.Client;

namespace StarWars.Models
{
    public class CreateCharacterViewModel
    {
        public CreateCharacterForm CreateCharacterForm { get; set; }
        public SelectList /*IEnumerable<SelectListItem> */Films { get; set; }
    }
}
