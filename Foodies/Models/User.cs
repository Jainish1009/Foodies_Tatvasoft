using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        [DataType(DataType.Text)]
        [StringLength(300)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Select a gender")]
        public int Gender { get; set; }

        [Required(ErrorMessage = "Fill the address")]
        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Choose Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Select a UserType")]
        public int UserType { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        
        [DataType(DataType.PhoneNumber)]
        public double Contact { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [StringLength(300)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm Password should be same as password")]
        public string ConfirmPassword { get; set; }
    }
}
