using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StarWars.Api.Client;
using StarWars.Models;
using System.Collections.Generic;

namespace StarWars.Controllers
{
    public class StarWarsController : Controller
    {
        private readonly string baseUrl = "https://localhost:7105";
        private readonly IHttpClientFactory httpClientFactory;
        private readonly StarWarsApiClient starWarsClient;

        public StarWarsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            starWarsClient = new StarWarsApiClient(baseUrl, httpClientFactory.CreateClient());

        }

        [HttpGet("StarWars")]
        public async Task<ActionResult> Index()
        {
            var characters = await starWarsClient.SearchStarWarsCharacterAsync(new SearchCharacterForm());

            var searchData = await starWarsClient.GetSearchStarWarsCharacterDataAsync();

            return View("Catalog", (characters, searchData));
        }

        [HttpPost("StarWars/Character")]
        public async Task<ActionResult> CreateCharacter([FromForm] CreateCharacterViewModel createForm)
        {

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("StarWars/Character/{id}")]
        public async Task<ActionResult> Details(Guid id)
        {
            var character = await starWarsClient.GetStarWarsCharacterAsync(id);

            return View("CharacterPage", character);
        }

        [HttpGet("StarWars/Character/Create")]
        public async Task<ActionResult> GetCreatePage()
        {
            var films = await starWarsClient.GetFilmsAsync();

            return View("CreateCharacterPage", 
                new CreateCharacterViewModel()
            {
                CreateCharacterForm = new CreateCharacterForm(),
                Films = new SelectList(films.Films.Select(film => new SelectListItem { Text = film.FilmName, Value = film.FilmId.ToString()}), "Value", "Text")
            });
        }

        // GET: StarWarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StarWarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StarWarsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StarWarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StarWarsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StarWarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
