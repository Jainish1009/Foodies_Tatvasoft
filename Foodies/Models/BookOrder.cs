using Foodies.Models.ViewModels;
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

        public string RestId { get; set; }

        public string FoodName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public int CreatedBy { get; set; }

        //public List<BookOrder> listbookorder { get; set; }
    }
}
