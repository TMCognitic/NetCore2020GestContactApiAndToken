using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GestContact.MVC.Models.Forms
{
    public class LoginForm
    {
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
    }
}