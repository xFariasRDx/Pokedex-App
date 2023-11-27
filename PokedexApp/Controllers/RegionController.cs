using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace PokedexApp.Controllers
{
    public class RegionController : Controller
    {
        private readonly RegionServices _services;

        public RegionController(ApplicationContext applicationContext)
        {
            _services = new(applicationContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _services.GetAllViewNodel());
        }

        /*----------------------Create de Regiones--------------------*/

        public IActionResult Create()
        {
            return View("SaveRegion", new SaveRegionViewModels());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveRegionViewModels spvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", spvm);
            }
            await _services.Add(spvm);
            return RedirectToRoute(new { Controller = "Region", Action = "Index" });
        }

        /*----------------------Edit de Regiones--------------------*/

        public async Task<IActionResult> Edit(int Id)
        {
            return View("SaveRegion", await _services.GetByIdSaveViewModels(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveRegionViewModels spvm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveRegion", spvm);
            }
            await _services.Update(spvm);
            return RedirectToRoute(new { Controller = "Region", Action = "Index" });
        }

        /*----------------------Delete de Region--------------------*/

        public async Task<IActionResult> Delete(int Id)
        {
            return View(await _services.GetByIdSaveViewModels(Id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
            await _services.Delete(Id);
            return RedirectToRoute(new { Controller = "Region", Action = "Index" });
        }

    }

}