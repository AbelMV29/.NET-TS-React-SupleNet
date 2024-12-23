using SupleNet.Domain.Entities.Common;

namespace SupleNet.Domain.Entities
{
    public class Product : CommonEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
