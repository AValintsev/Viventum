using System.ComponentModel.DataAnnotations;

namespace Viventum.Models
{
    public class ContactModel
    {
        [Required]
        [RegularExpression(@"^[A-Za-z0-9 ]+$")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"^[A-Za-z0-9 ]+$")]
        public string Company { get; set; }

        [RegularExpression(@"^[A-Za-z0-9 ]+$")]
        public string Subject { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9 ]+$")]
        public string Message { get; set; }

    }
}
