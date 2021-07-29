namespace Ecom.Domain.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
    }
}
