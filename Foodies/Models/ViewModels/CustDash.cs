using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Models.ViewModels
{
    public class CustDash
    {
        [Key]
        public int CustId { get; set; }

        [Required(ErrorMessage = "FullName is required")]
        [DataType(DataType.Text)]
        [StringLength(300)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Fill the address")]
        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        public string Address { get; set; }
    }
}
