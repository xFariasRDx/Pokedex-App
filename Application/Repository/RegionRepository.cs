using Database.Models;
using Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class RegionRepository
    {

        private readonly ApplicationContext _dbContext;

        public RegionRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Regiones regiones)
        {
            await _dbContext.Set<Regiones>().AddAsync(regiones);
            await _dbContext.SaveChangesAsync();

        }
        public async Task UpdateAsync(Regiones regiones)
        {
            _dbContext.Entry(regiones).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }
        public async Task DeleteAsync(Regiones regiones)
        {
            _dbContext.Set<Regiones>().Remove(regiones);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Regiones>> GetAllAsync()
        {
            return await _dbContext.Set<Regiones>().ToListAsync();
        }
        public async Task<Regiones> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<Regiones>().FindAsync(Id);
        }

    }
}
