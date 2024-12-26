using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task DeleteAsync(T entity);
        Task UpdateAsync(int id, T entity);
    }
}
