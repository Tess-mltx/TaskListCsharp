using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TaskList.Models.Entities
{
    public class Role : IdentityRole<int>
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Role_Permission> RolePermissions { get; set; } // Correction: Many-to-many relationship with Role_Permission
    }
}
