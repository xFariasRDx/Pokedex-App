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
    public class TipoRepository
    {

        private readonly ApplicationContext _dbContext;

        public TipoRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Tipos tipos)
        {
            await _dbContext.Set<Tipos>().AddAsync(tipos);
            await _dbContext.SaveChangesAsync();

        }
        public async Task UpdateAsync(Tipos tipos)
        {
            _dbContext.Entry(tipos).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }
        public async Task DeleteAsync(Tipos tipos)
        {
            _dbContext.Set<Tipos>().Remove(tipos);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<Tipos>> GetAllAsync()
        {
            return await _dbContext.Set<Tipos>().ToListAsync();
        }
        public async Task<Tipos> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<Tipos>().FindAsync(Id);
        }

    }
}
