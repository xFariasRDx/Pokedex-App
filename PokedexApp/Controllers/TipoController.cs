using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace PokedexApp.Controllers
{
    public class TipoController : Controller
    {
        private readonly TipoServices _services;

        public TipoController(ApplicationContext applicationContext)
        {
            _services = new(applicationContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _services.GetAllViewNodel());
        }

        /*----------------------Create de Pokemones--------------------*/

        public IActionResult Create()
        {
            return View("SaveTipo", new SaveTipoViewModels());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveTipoViewModels spvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", spvm);
            }
            await _services.Add(spvm);
            return RedirectToRoute(new { Controller = "Tipo", Action = "Index" });
        }

        /*----------------------Edit de Pokemones--------------------*/

        public async Task<IActionResult> Edit(int Id)
        {
            return View("SaveTipo", await _services.GetByIdSaveViewModels(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveTipoViewModels spvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveTipo", spvm);
            }
            await _services.Update(spvm);
            return RedirectToRoute(new { Controller = "Tipo", Action = "Index" });
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
            return RedirectToRoute(new { Controller = "Tipo", Action = "Index" });
        }


    }
}
