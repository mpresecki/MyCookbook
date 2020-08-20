using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Business.Models
{
    public class CookbookModel
    {
        public long Id { get; set; }

        public RecipeListModel Recipe { get; set; }

        public string UserName { get; set; }

        public DateTime SavedAt { get; set; }
    }

    public class CookbookInsertModel
    {
        public long RecipeId { get; set; }

        public long UserId { get; set; }

        public DateTime SavedAt { get; set; } = DateTime.Now;
    }
}
