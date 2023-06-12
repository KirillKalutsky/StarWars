using StarWars.Api.Models.Character;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWars.Api.Contexts;
using StarWars.Api.DataLayer;
using StarWars.Api.DataLayer.Entities;
using StarWars.Api.Services;

namespace StarWars.Api.Controllers
{
    [ApiController]
    public class StarWarsCharactersController : ControllerBase
    {
        private readonly AppRequestContext context;
        public StarWarsCharactersController(AppRequestContext context)
        {
            this.context = context;
        }

        [Produces(typeof(CharacterViewModel))]
        [HttpGet("StarWars/Characters/{characterId}", Name = "GetStarWarsCharacter")]
        public async Task<IActionResult> GetCharacter(Guid characterId)
        {
            var character = await context.FindStarWarsCharacterAsync(characterId);

            if(character == null)
                return NotFound();

            return Ok(character);
        }

        [HttpPatch("StarWars/Characters/{characterId}", Name = "EditStarWarsCharacter")]
        public async Task<IActionResult> EditCharacter(Guid characterId, [FromBody] EditCharacterForm editForm)
        {
            var character = await context.Get<Character>().ById(characterId).FirstOrDefaultAsync();

            if (character == null)
                return NotFound();



            await context.EditStarWarsCharacterAsync(character, editForm);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [Produces(typeof(SearchCharacterResultViewModel))]
        [HttpPost("StarWars/Characters/Search", Name = "SearchStarWarsCharacter")]
        public async Task<IActionResult> SearchCharacters(SearchCharacterForm searchForm)
        {
            return Ok(await context.SearchStarWarsCharacterAsync(searchForm));
        }

        [Produces(typeof(SearchCharacterDataViewModel))]
        [HttpGet("StarWars/Characters/Search/Data", Name = "GetSearchStarWarsCharacterData")]
        public async Task<IActionResult> GetSearchCharacterData()
        {
            return Ok(await context.GetStarWarsCharacterSearchData());
        }

        [Produces(typeof(CreateCharacterResultViewModel))]
        [HttpPost("StarWars/Characters", Name = "CreateStarWarsCharacter")]
        public async Task<IActionResult> CreateCharacter(CreateCharacterForm createForm)
        {
            var validationResult = await context.ValidateCreateStarWarsCharacterFormAsync(createForm);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.ErrorMessage);

            var createResult = context.CreateStarWarsCharacter(createForm);

            await context.SaveChangesAsync();

            return Ok(createResult);
        }

        [HttpDelete("StarWars/Characters/{characterId}", Name = "DeleteStarWarsCharacter")]
        public async Task<IActionResult> DeleteCharacter(Guid characterId)
        {
            var character = await context.Get<Character>()
                .ById(characterId).FirstOrDefaultAsync();

            if (character == null)
                return NotFound();

            context.Delete(character);

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
