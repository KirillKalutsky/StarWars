using StarWars.Api.Models.Character;
using StarWars.Api.Models.Film;
using Microsoft.AspNetCore.Mvc;
using StarWars.Api.Contexts;
using StarWars.Api.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StarWars.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly AppRequestContext context;
        public FilmController(AppRequestContext context)
        {
            this.context = context;
        }

        [HttpPost(Name = "CreateFilm")]
        [Produces(typeof(FilmCreateResultViewModel))]
        public async Task<IActionResult> CreateFilm([FromBody] FilmCreateForm form)
        {
            var filmCreateResult = context.CreateFilm(form);

            await context.SaveChangesAsync();

            return Ok(filmCreateResult);
        }

        [HttpGet(Name = "GetFilms")]
        [Produces(typeof(FilmListViewModel))]
        public async Task<IActionResult> GetFilms()
        {
            return Ok(await context.GetFilms());
        }
    }
}
