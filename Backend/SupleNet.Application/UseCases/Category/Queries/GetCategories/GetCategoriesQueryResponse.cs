using SupleNet.Application.UseCases.Common;

namespace SupleNet.Application.UseCases.Category.Queries.GetCategories
{
    public record GetCategoriesQueryResponse(Guid Id, string Name, DateTime CreatedDate) : GetItemsQueryBaseResponse(Id, Name, CreatedDate);
}
