namespace SupleNet.Application.UseCases.Brand.Queries.GetBrands
{
    public class GetBrandsQueryResponse
    {
        public GetBrandsQueryResponse(Guid id, string name, DateTime createdDate)
        {
            Id = id;
            Name = name;
            CreatedDate = createdDate;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
