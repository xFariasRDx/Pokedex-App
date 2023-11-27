using Application.Repository;
using Application.ViewModels;
using Database.Models;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RegionServices
    {
        
        private readonly RegionRepository regionRepository;

        public RegionServices(ApplicationContext dbContext)
        {
            regionRepository = new(dbContext);
        }

        //-----------------Metodo para Agregar----------------//

        public async Task Add(SaveRegionViewModels manda)
        {
            Regiones regiones = new();
            regiones.Name = manda.Name;
            
            await regionRepository.AddAsync(regiones);
        }

        //-----------------Metodo para Actualizar----------------//

        public async Task Update(SaveRegionViewModels trae)
        {
            Regiones regiones = new();
            regiones.Id = trae.Id;
            regiones.Name = trae.Name;

            await regionRepository.UpdateAsync(regiones);
        }

        //-----------------Metodo para Eliminar----------------//

        public async Task Delete(int id)
        {
            var regiones = await regionRepository.GetByIdAsync(id);
            await regionRepository.DeleteAsync(regiones);
        }
        
        //----------------------------------------------------------------------//

        public async Task<SaveRegionViewModels> GetByIdSaveViewModels(int id)
        {
            var regiones = await regionRepository.GetByIdAsync(id);

            SaveRegionViewModels vm = new();
            vm.Id = regiones.Id;
            vm.Name = regiones.Name;

            return vm;
        }


        public async Task<List<RegionViewModels>> GetAllViewNodel()
        {
            var regionList = await regionRepository.GetAllAsync();
            return regionList.Select(region => new RegionViewModels
            {
                Id = region.Id,
                Name = region.Name,

            }).ToList();
        }

    }
}
