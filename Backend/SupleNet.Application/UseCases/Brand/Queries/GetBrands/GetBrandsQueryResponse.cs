using SupleNet.Application.UseCases.Common;

namespace SupleNet.Application.UseCases.Brand.Queries.GetBrands
{
    public record GetBrandsQueryResponse(Guid Id, string Name, DateTime CreatedDate) : GetItemsQueryBaseResponse(Id, Name, CreatedDate);
}
