using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TaskList.Models.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
        public int RoleId { get; set; } // One-to-one relationship with Role
        public Role Role { get; set; }

    }
}
