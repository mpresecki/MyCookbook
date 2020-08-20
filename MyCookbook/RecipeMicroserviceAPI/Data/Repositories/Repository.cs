using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeMicroserviceAPI.Data.Entities;

namespace RecipeMicroserviceAPI.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly RecipeContext context;

        private DbSet<T> entities;

        public Repository(RecipeContext context)
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
            context.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            if (id < 0) throw new ArgumentNullException();

            T entity = await entities.FirstOrDefaultAsync(s => s.Id == id);
            entity.RejectNotFound();
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
