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
    public class TipoServices
    {
        private readonly TipoRepository tipoRepository;

        public TipoServices(ApplicationContext dbContext)
        {
            tipoRepository = new(dbContext);
        }

        //-----------------Metodo para Agregar----------------//

        public async Task Add(SaveTipoViewModels manda)
        {
            Tipos tipos = new();
            tipos.Tipo = manda.Tipo;

            await tipoRepository.AddAsync(tipos);
        }

        //-----------------Metodo para Actualizar----------------//

        public async Task Update(SaveTipoViewModels trae)
        {
            Tipos tipos = new();
            tipos.Id = trae.Id;
            tipos.Tipo = trae.Tipo;

            await tipoRepository.UpdateAsync(tipos);
        }

        //-----------------Metodo para Eliminar----------------//

        public async Task Delete(int id)
        {
            var tipos = await tipoRepository.GetByIdAsync(id);
            await tipoRepository.DeleteAsync(tipos);
        }

        //----------------------------------------------------------------------//

        public async Task<SaveTipoViewModels> GetByIdSaveViewModels(int id)
        {
            var tipo = await tipoRepository.GetByIdAsync(id);

            SaveTipoViewModels vm = new();
            vm.Id = tipo.Id;
            vm.Tipo = tipo.Tipo;

            return vm;
        }


        public async Task<List<TipoViewModels>> GetAllViewNodel()
        {
            var tipoList = await tipoRepository.GetAllAsync();
            return tipoList.Select(tipos => new TipoViewModels
            {
                Id = tipos.Id,
                Tipo = tipos.Tipo,

            }).ToList();
        }
    }
}
