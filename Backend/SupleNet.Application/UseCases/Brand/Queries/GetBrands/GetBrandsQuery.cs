using MediatR;
using SupleNet.Application.Responses.Common;
using SupleNet.Application.UseCases.Common;

namespace SupleNet.Application.UseCases.Brand.Queries.GetBrands
{
    public record GetBrandsQuery : GetItemsQueryBase, IRequest<Result<GetBrandsQueryResponse[]>>;
}
