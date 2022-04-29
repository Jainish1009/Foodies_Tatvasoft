using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Models
{
    public class RestMenu
    {
        [Key]
        public int FoodId { get; set; }

        public bool HasSelect { get; set; }
        [Required]
        public string RestId { get; set; }

        [Required]
        [StringLength(50)]
        public string FoodName { get; set; }
        
        public string FilePath { get; set; }
        [Required]
        public decimal Price { get; set; }

        public int Quantity { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
    }
}
