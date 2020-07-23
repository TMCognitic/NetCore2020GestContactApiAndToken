using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestContact.MVC.Models.Forms
{
    public class RegisterForm
    {
        [Required]
        [StringLength(50, MinimumLength=2)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&=])[A-Za-z\d@$!%*#?&=]{8,20}$")]
        [DisplayName("Password")]
        public string Passwd { get; set; }
        [Compare(nameof(Passwd))]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        public string Confirm { get; set; }
    }
}