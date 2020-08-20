using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealMicroserviceAPI.Data.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(long id);

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);
        
        Task DeleteAsync(long id);
    }
}
