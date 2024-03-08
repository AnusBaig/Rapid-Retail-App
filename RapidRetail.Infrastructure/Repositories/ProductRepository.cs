using RapidRetail.Domain.Entities;
using RapidRetail.Domain.Repositories;

namespace RapidRetail.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new() {Id = 1, Name = "Organic Avocado", Category = "Fresh Produce", Price = 299, Description = "Fresh, ripe, and creamy organic avocados. Packed with nutrients and perfect for salads, sandwiches, or guacamole"},
                new() {Id = 2, Name = "Whole Grain Quinoa", Category = "Grains & Legumes", Price = 449, Description = "Nutrient-rich whole grain quinoa, a versatile and healthy addition to your pantry. Great for salads, side dishes, or as a base for protein-packed meals."},
                new() {Id = 3, Name = "Organic Chicken Breast", Category = "Meat & Poultry", Price = 899, Description = "Premium quality, organic chicken breasts. Raised without antibiotics or hormones. Ideal for lean and protein-rich meals"},
                new() {Id = 4, Name = "Fresh Strawberries", Category = "Fresh Produce", Price = 399, Description = "Juicy and sweet fresh strawberries. Picked at peak ripeness for a burst of natural flavor. Perfect for snacking, desserts, or smoothies"},
                new() {Id = 5, Name = "Extra Virgin Olive Oil", Category = "Cooking Oils", Price = 999, Description = "Cold-pressed extra virgin olive oil, rich in flavor and antioxidants. Ideal for cooking, salad dressings, or drizzling over dishes"},
                new() {Id = 6, Name = "Organic Spinach", Category = "Fresh Produce", Price = 249, Description = "Fresh and nutrient-packed organic spinach. Great for salads, sautéed dishes, or adding a healthy touch to smoothies"},
                new() {Id = 7, Name = "Whole Wheat Bread", Category = "Bakery", Price = 329, Description = "Wholesome whole wheat bread, baked fresh daily. A nutritious choice for sandwiches or toasting for breakfast"},
                new() {Id = 8, Name = "Greek Yogurt", Category = "Dairy", Price = 299, Description = "Creamy and tangy Greek yogurt. Packed with probiotics and perfect for breakfast, snacks, or as a base for sauces and dips"},
            };

            return products;
        }
    }
}
