using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.DataAccess.Abstractions.Repositories
{
    public interface IGenericRepository<T>
    {

        public Task<T> GetByIdAsync(int Id);

        public Task<IEnumerable<T>> GetAllAsync();

        public Task CreateAsync(T entity);

        public Task DeleteAsync(int Id);

        public void UpdateAsync(T entity);

        public Task<int> SaveChangesAsync();

    }
}
