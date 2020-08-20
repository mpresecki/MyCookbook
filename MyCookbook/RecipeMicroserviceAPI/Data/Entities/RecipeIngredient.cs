using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Data.Entities
{
    public class RecipeIngredient
    {
        [Required]
        public decimal Quantity { get; set; }

        public long UnitId { get; set; }

        public Unit Unit { get; set; }

        public long RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public long IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
