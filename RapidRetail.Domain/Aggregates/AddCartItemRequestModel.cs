using RapidRetail.Domain.Entities;

namespace RapidRetail.Domain.Aggregates
{
    public class AddCartItemRequestModel
    {
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
