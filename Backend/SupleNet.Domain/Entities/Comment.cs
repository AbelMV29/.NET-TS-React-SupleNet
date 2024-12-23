using SupleNet.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupleNet.Domain.Entities
{
    public class Comment : CommonEntity
    {
        public Guid ProductId { get; set;}
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        public string Body { get; set; } = string.Empty;
        public bool Bougth { get; set; }
    }
}
