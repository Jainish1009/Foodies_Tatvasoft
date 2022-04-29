using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodies.Models.ViewModels
{
    public class BookOrderViewModel
    {
        public string RestId { get; set; }

        public string FoodName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public List<BookOrderViewModel> listbookorderviewmodel { get; set; }
        //public List<BookOrder> Cart { get; set; }
    }
}

