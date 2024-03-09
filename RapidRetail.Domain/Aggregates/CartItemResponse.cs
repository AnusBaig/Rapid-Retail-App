using RapidRetail.Domain.Entities;

namespace RapidRetail.Domain.Aggregates
{
    public class CartItemResponse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
