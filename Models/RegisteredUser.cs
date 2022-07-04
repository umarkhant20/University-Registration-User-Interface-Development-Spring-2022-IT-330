using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proj3_Khan.Models
{
    public class RegisteredUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set;  }
       
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }
       
        [Required]
        [Display(Name = "Create Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Create Password")]
        public string Password { get; set; }
       
        [Required]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password doesn't match, please try again.")]
        [NotMapped]
        public string ConfirmPassword  { get; set; }

        [Display(Name = "Degree Program")]
        public string DegreeProgram { get; set; }

        [Required]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100.")]
        public string Age { get; set; }

        [Required]
        [Display(Name = "Have you ever taken any class here before?")]
        public bool FirstTime { get; set; }

        [Required]
        [Display(Name = "Would you like to receive updates and alerts via email?")]
        public string Notification { get; set; }

        public DateTime RegistrationDate { get; internal set; }
    }
}
