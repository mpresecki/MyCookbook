using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Data.Repositories
{
    public class DatabaseScope : IDatabaseScope
    {
        private readonly RecipeContext _context;

        public DatabaseScope(RecipeContext context)
        {
            _context = context;
            DataSeeder.SeedData(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
