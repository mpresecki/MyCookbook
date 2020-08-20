using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UserMicroserviceAPI.Business.Models
{
    public class UserListModel
    {
        [JsonIgnore]
        public long Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }
    }

    public class UserModel : UserListModel
    {
        public UserRoleModel Role { get; set; }
    }

    public class UserInsertModel : UserListModel
    {
        [Required]
        [StringLength(255)]
        public string Password { get; set; }
    }
}
