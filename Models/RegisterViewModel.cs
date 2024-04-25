using System.ComponentModel.DataAnnotations;

namespace TaskList.Models
{
    public class RegisterViewModel
    {
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int RoleId { get; set; }

    }
}
