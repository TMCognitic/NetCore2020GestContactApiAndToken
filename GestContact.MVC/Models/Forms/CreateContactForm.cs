using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestContact.MVC.Models.Forms
{
    public class CreateContactForm
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(320)]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}