using SupleNet.Domain.Entities.Common;
using SupleNet.Domain.Utils;

namespace SupleNet.Domain.Entities
{
    public class Sale : CommonEntity
    {
        public decimal TotalPrice { get; set; }
        public StatePay State { get; set; }
    }
}
