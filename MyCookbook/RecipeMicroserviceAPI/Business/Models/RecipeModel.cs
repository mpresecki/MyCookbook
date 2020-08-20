using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Business.Models
{
    public class RecipeBaseModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long CookingTime { get; set; }

        public long Servings { get; set; }

        public bool IsPublic { get; set; }

        public bool IsSaved { get; set; }
    }

    public class RecipeListModel : RecipeBaseModel
    {
        public string UserName { get; set; }

        public string CategoryName { get; set; }

        public string SkillLevel { get; set; }
    }

    public class RecipeModel : RecipeListModel
    {
        public ICollection<PreparationStepModel> PreparationSteps { get; set; }

        public ICollection<RecipeIngredientModel> RecipeIngredients { get; set; }
    }

    public class RecipeInsertModel : RecipeBaseModel
    {
        public long UserId { get; set; }

        public long RecipeCategoryId { get; set; }

        public long SkillLevelId { get; set; }

        public ICollection<PreparationStepModel> PreparationSteps { get; set; }

        public ICollection<RecipeIngredientInsertModel> RecipeIngredients { get; set; }
    }
}
