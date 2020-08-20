using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Data.Entities
{
    public class MyCookbook : BaseEntity
    {
        [Required]
        public long RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        [Required]
        public long UserId { get; set; }

        public DateTime SavedAt { get; set; } = DateTime.Now;
    }
}
