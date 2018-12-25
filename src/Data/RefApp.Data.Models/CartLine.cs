using RefApp.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace RefApp.Data.Models
{
    public class CartLine:BaseModel<int>
    {
        [Required]
        [RegularExpression(@"^\d*[0-9]\d*$",ErrorMessage = "Quantity should be possitive!")]
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
