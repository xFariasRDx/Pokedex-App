using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PokedexApp.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonServices _services;
        private readonly RegionServices _regionServices;
        private readonly TipoServices _tipoServices;


        public PokemonController(ApplicationContext applicationContext)
        {
            _services = new(applicationContext);
            _regionServices = new(applicationContext);
            _tipoServices = new(applicationContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _services.GetAllViewNodel());
        }

        /*----------------------Create de Pokemones--------------------*/

        public async Task<IActionResult> Create()
        {
            ViewBag.Regiones = new SelectList(await _regionServices.GetAllViewNodel(), "Id", "Name");
            ViewBag.Tipos = new SelectList(await _tipoServices.GetAllViewNodel(), "Id", "Tipo");
            return View("SavePokemon", new SavePokemonViewModels());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SavePokemonViewModels spvm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Regiones = new SelectList(await _regionServices.GetAllViewNodel(), "Id", "Name");
                ViewBag.Tipos = new SelectList(await _tipoServices.GetAllViewNodel(), "Id", "Tipo");
                return View("SavePokemon", spvm);
            }

            await _services.Add(spvm);
            return RedirectToRoute(new { Controller = "Pokemon", Action = "Index" });

        }

        /*----------------------Edit de Pokemones--------------------*/

        public async Task<IActionResult> Edit(int Id)
        {
            ViewBag.Regiones = new SelectList(await _regionServices.GetAllViewNodel(), "Id", "Name");
            ViewBag.Tipos = new SelectList(await _tipoServices.GetAllViewNodel(), "Id", "Tipo");
            return View("SavePokemon", await _services.GetByIdSaveViewModels (Id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SavePokemonViewModels spvm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Regiones = new SelectList(await _regionServices.GetAllViewNodel(), "Id", "Name");
                ViewBag.Tipos = new SelectList(await _tipoServices.GetAllViewNodel(), "Id", "Tipo");
                return View("SavePokemon", spvm);
            }
            await _services.Update(spvm);
            return RedirectToRoute(new { Controller = "Pokemon", Action = "Index" });
        }

        /*----------------------Delete de Pokemones--------------------*/

        public async Task<IActionResult> Delete(int Id)
        {
            return View(await _services.GetByIdSaveViewModels(Id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            await _services.Delete(Id);
            return RedirectToRoute(new { Controller = "Pokemon", Action = "Index" });
        }

    }

}
