using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroserviceAPI.Data.Entities;

namespace UserMicroserviceAPI.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly UserContext context;

        private DbSet<T> entities;

        public Repository(UserContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return entities.AsNoTracking();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await entities.SingleOrDefaultAsync(s => s.Id == id);
        }     

        public async Task InsertAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException();

            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException();
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            if (id < 0) throw new ArgumentNullException();

            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
