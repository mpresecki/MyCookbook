using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Business.Models
{
    public class RecipeIngredientModel
    {
        public string Ingredient { get; set; }

        public string Unit { get; set; }

        public decimal Quantity { get; set; }
    }

    public class RecipeIngredientInsertModel
    {
        public long IngredientId { get; set; }

        public long UnitId { get; set; }

        public decimal Quantity { get; set; }
    }
}
