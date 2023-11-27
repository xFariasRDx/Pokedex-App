using Application.Repository;
using Database.Models;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
using System.Windows.Markup;

namespace Application.Services
{
    public class PokemonServices
    {
        private readonly PokemonRepository pokemonRepository;

        public PokemonServices (ApplicationContext dbContext)
        {
            pokemonRepository = new(dbContext);
        }

        //-----------------Metodo para Agregar----------------//

        public async Task Add(SavePokemonViewModels manda)
        {
            Pokemon pokemon = new();
            pokemon.Name = manda.Name;
            pokemon.ImageUrl = manda.ImageUrl;
            pokemon.TipoId1 = manda.TipoId1;
            pokemon.TipoId2 = manda.TipoId2 == null ? manda.TipoId1 : manda.TipoId2;
            pokemon.RegionId = manda.RegionId;

            await pokemonRepository.AddAsync(pokemon);
        }

        //-----------------Metodo para Actualizar----------------//

        public async Task Update(SavePokemonViewModels trae)
        {
            Pokemon pokemon = new();
            pokemon.Id = trae.Id;
            pokemon.Name = trae.Name;
            pokemon.ImageUrl = trae.ImageUrl;
            pokemon.TipoId1 = trae.TipoId1;
            pokemon.TipoId2 = trae.TipoId2 == 0 ? trae.TipoId1 : trae.TipoId2;
            pokemon.RegionId = trae.RegionId;

            await pokemonRepository.UpdateAsync(pokemon);
        }

        //-----------------Metodo para Eliminar----------------//

        public async Task Delete(int id)
        {
            var pokemon = await pokemonRepository.GetByIdAsync(id);
            await pokemonRepository.DeleteAsync(pokemon);
        }


        public async Task<SavePokemonViewModels> GetByIdSaveViewModels(int id)
        {
            var pokemon = await pokemonRepository.GetByIdAsync(id);

            SavePokemonViewModels vm = new();
            vm.Id = pokemon.Id;
            vm.Name = pokemon.Name; 
            vm.ImageUrl = pokemon.ImageUrl;
            vm.TipoId1= pokemon.TipoId1;
            vm.TipoId2= pokemon.TipoId2;
            vm.RegionId= pokemon.RegionId;

            return vm;
        }


        public async Task<List<PokemonsViewModels>> GetAllViewNodel()
        {
            var pokemonList = await pokemonRepository.GetAllAsync();
            return pokemonList.Select(pokemon => new PokemonsViewModels
            {
                Id= pokemon.Id,
                Name = pokemon.Name,
                ImageUrl = pokemon.ImageUrl,
                Tipo1 = pokemon.tipo1.Tipo,
                Tipo2= pokemon.tipo2.Tipo == null? pokemon.tipo1.Tipo : pokemon.tipo2.Tipo,
                Region = pokemon.regiones.Name
               
            }).ToList();
        }

        public async Task<List<PokemonsViewModels>> GetAllViewNodelWithFilters(FilterRegionViewModels filters)
        {
            var pokemonList = await pokemonRepository.GetAllAsync();
            
            var ListViewModels = pokemonList.Select(pokemon => new PokemonsViewModels
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImageUrl = pokemon.ImageUrl,
                Tipo1 = pokemon.tipo1.Tipo,
                Tipo2 = pokemon.tipo2.Tipo == null ? pokemon.tipo1.Tipo : pokemon.tipo2.Tipo,
                Region = pokemon.regiones.Name,
                RegionId = pokemon.regiones.Id

            }).ToList();

            if (filters.RegionId != null)
            { 
               ListViewModels = ListViewModels.Where(pokemon => pokemon.RegionId == filters.RegionId.Value).ToList();
            }

            return ListViewModels;
        }


        public async Task<List<PokemonsViewModels>> GetAllViewNodelWithBuscar(String name)
        {
            var pokemonList = await pokemonRepository.GetAllAsync();

            var ListViewModels = pokemonList.Select(pokemon => new PokemonsViewModels
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                ImageUrl = pokemon.ImageUrl,
                Tipo1 = pokemon.tipo1.Tipo,
                Tipo2 = pokemon.tipo2.Tipo == null ? pokemon.tipo1.Tipo : pokemon.tipo2.Tipo,
                Region = pokemon.regiones.Name,
                RegionId = pokemon.regiones.Id

            }).ToList();

            if (name != null)
            {
                ListViewModels = ListViewModels.Where(pokemon => pokemon.Name == name).ToList();
            }

            return ListViewModels;
        }

    }
    
}
