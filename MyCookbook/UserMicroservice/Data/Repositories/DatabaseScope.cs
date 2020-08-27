using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroserviceAPI.Data.Repositories
{
    public class DatabaseScope : IDatabaseScope
    {
        private readonly UserContext _context;

        public DatabaseScope(UserContext context)
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
