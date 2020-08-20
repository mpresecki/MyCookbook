using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Data.Entities
{
    public class Recipe : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public long CookingTime { get; set; }

        [Required]
        public long Servings { get; set; }

        public bool IsPublic { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public long UserId { get; set; }

        [Required]
        public long RecipeCategoryId { get; set; }

        public RecipeCategory RecipeCategory { get; set; }

        public long SkillLevelId { get; set; }

        [Required]
        public SkillLevel SkillLevel { get; set; }

        public ICollection<PreparationStep> PreparationSteps { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
