using SupleNet.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupleNet.Domain.Entities
{
    public class SaleDetail : CommonEntity
    {
        public Guid ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        public Guid SaleId { get; set; }
        [ForeignKey(nameof(SaleId))]
        public Sale Sale { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
