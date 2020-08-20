using MealMicroserviceAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealMicroserviceAPI.Data
{
    public class MealContext : DbContext
    {
        public MealContext(DbContextOptions<MealContext> options)
            : base(options)
        {
        }

        public DbSet<Meal> Meals { get; set; }
    }
}
