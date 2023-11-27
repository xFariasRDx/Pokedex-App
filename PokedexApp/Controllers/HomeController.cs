using Application.Repository;
using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokedexApp.Models;
using System.Diagnostics;

namespace PokedexApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly PokemonServices _services;
        private readonly RegionServices _regionservices;

        public HomeController(ApplicationContext applicationContext)
        {
            _services = new(applicationContext);
            _regionservices= new(applicationContext);
        }

        public async Task<IActionResult> Index(FilterRegionViewModels vm)
        {
            ViewBag.Region = await _regionservices.GetAllViewNodel();
            return View(await _services.GetAllViewNodelWithFilters(vm));
        }

        public async Task<IActionResult> Buscar(String name)
        {
            ViewBag.Region = await _regionservices.GetAllViewNodel();
            return View("Index",await _services.GetAllViewNodelWithBuscar(name));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}