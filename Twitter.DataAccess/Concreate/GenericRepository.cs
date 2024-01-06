using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.DataAccess.Abstractions.Repositories;
using Twitter.Core.Entities;
using Twitter.DataAccess.DbContexts;

namespace Twitter.DataAccess.Concreate
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private ApplicationDbContext _dbContext { get; init; }

        private DbSet<T> Table => _dbContext.Set<T>();

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Table.AsNoTracking().ToListAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task DeleteAsync(int Id)
        {
            var entity = await GetByIdAsync(Id);
            if (entity is not null)
                Table.Remove(entity);
        }

        public void UpdateAsync(T entity)
        {
            Table.Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
