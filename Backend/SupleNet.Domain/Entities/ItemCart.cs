using SupleNet.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupleNet.Domain.Entities
{
    public class ItemCart : CommonEntity
    {
        public Guid ProductId { get; set;}
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
    }
}
