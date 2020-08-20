using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroserviceAPI.Data.Entities
{
    [Table("UserRole")]
    public class UserRole : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
