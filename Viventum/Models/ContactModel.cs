using System.ComponentModel.DataAnnotations;

namespace Viventum.Models
{
    public class ContactModel
    {
        [Required]
        [RegularExpression(@"[a-zA-Z]*[^!@%~?:#$%^&*()'0123456789]*")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"[a-zA-Z]*[^!@%~?:#$%^&*()'0123456789]*")]
        public string Company { get; set; }

        [RegularExpression(@"[a-zA-Z]*[^!@%~?:#$%^&*()'0123456789]*")]
        public string Subject { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]*[^!@%~?:#$%^&*()'0123456789]*")]
        public string Message { get; set; }

    }
}
