using System.ComponentModel.DataAnnotations;

namespace OnlineSales.Domain
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
