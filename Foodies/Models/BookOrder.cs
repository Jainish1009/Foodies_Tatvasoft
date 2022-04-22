using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Models
{
    public class BookOrder
    {
        [Key]
        public int OrderId { get; set; }

        public string FoodName { get; set; }

        public int BasePrice { get; set; }

        public int Quantity { get; set; }

        public int TotalPrice { get; set; }
    }
}
