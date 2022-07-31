using System.ComponentModel.DataAnnotations;

namespace VirtualCarHustler.Models
{
    public class UserRegistrationModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Login { get; set; }
    }
}
