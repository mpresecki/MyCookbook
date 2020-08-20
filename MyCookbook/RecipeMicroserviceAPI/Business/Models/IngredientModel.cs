using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Business.Models
{
    public class IngredientModel : IngredientInsertModel
    {
        public long Id { get; set; }
    }

    public class IngredientInsertModel
    {
        public string Name { get; set; }
    }
}
