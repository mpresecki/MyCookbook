using MealMicroserviceAPI.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MealMicroserviceAPI.Business.Models
{
    public class MealModel
    {
        public long Id { get; set; }

        public long RecipeId { get; set; }

        public string RecipeName { get; set; }

        public MealTypes MealType { get; set; }

        public DateTime MealDay { get; set; }
    }

    public class MealsByDayModel
    {
        public DateTime Day { get; set; }

        public List<MealModel> Meals { get; set; }
    }

    public class MealInsertModel 
    {
        [Required]
        public long UserId { get; set; }

        [Required]
        public long RecipeId { get; set; }

        [Required]
        public MealTypes MealType { get; set; }

        [Required]
        public DateTime MealDay { get; set; }
    }

    public class MealUpdateModel : MealInsertModel
    {
        [Required]
        public long Id { get; set; }
    }
}
