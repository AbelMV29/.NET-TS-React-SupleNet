using SupleNet.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupleNet.Domain.Entities
{
    public class Product : CommonEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Guid BrandId { get; set; }
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public string Image { get; set; } = string.Empty;
        public ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
