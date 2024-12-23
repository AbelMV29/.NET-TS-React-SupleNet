namespace SupleNet.Domain.Entities.Common
{
    public abstract class CommonEntity
    {
        public Guid ID { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? LastModifiedBy { get; set; } = null;
        public DateTime? LastModifiedDate { get; set; } = null;
    }
}
