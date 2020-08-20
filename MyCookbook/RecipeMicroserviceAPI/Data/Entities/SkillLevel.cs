using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Data.Entities
{
    public class SkillLevel : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string LevelName { get; set; }
    }
}
