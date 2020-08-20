using MealMicroserviceAPI.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealMicroserviceAPI.Data.Entities
{
    public class Meal : BaseEntity
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public long RecipeId { get; set; }

        [Required]
        public MealTypes MealType { get; set; }

        [Required]
        public DateTime MealDay { get; set; }

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
