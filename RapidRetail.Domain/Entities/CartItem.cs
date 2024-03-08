using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRetail.Domain.Entities
{
    internal class CartItem
    {
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
