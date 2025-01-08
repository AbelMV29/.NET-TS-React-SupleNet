using MediatR;
using SupleNet.Application.Responses.Common;
using SupleNet.Application.UseCases.Common;

namespace SupleNet.Application.UseCases.Category.Queries.GetCategories
{
    public record GetCategoriesQuery : GetItemsQueryBase, IRequest<Result<GetCategoriesQueryResponse[]>>
    {
    }
}
