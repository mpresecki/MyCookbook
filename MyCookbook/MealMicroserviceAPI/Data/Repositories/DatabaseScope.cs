using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealMicroserviceAPI.Data.Repositories
{
    public class DatabaseScope : IDatabaseScope
    {
        private readonly MealContext _context;

        public DatabaseScope(MealContext context)
        {
            _context = context;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
