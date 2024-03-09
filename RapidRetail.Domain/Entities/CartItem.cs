using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidRetail.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
