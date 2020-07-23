using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestContact.MVC.Models.Forms
{
    public class UpdateContactForm
    {
        [HiddenInput]
        public int Id { get; set; }
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