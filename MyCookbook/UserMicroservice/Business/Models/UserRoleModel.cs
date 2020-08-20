using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroserviceAPI.Business.Models
{
    public class UserRoleModel
    {
        [StringLength(255)]
        public string Name { get; set; }
    }
}
