using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealMicroserviceAPI.Data.Repositories
{
    public interface IDatabaseScope
    {
        Task SaveChangesAsync();
    }
}
