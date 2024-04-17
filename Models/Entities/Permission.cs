using System.ComponentModel.DataAnnotations;

namespace TaskList.Models.Entities
{
    public class Permission
    {
        // Task permissions
        [Key]
        public int PermissionId { get; set; }
        public string Description { get; set; }

        public ICollection<Role_Permission> RolePermissions { get; set; } // Correction: Many-to-many relationship with Role_Permission

    }
}
