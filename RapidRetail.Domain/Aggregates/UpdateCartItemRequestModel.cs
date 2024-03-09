using RapidRetail.Domain.Entities;

namespace RapidRetail.Domain.Aggregates
{
    public class UpdateCartItemRequestModel
    {
        public int Quantity { get; set; }
        public int ItemId { get; set; }
    }
}
