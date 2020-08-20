using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Data.Entities
{
    public class PreparationStep : BaseEntity
    {
        [Required]
        public int StepNumber { get; set; }

        [Required]
        [StringLength(550)]
        public string StepText { get; set; }

        [Required]
        public long RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}
