using MediatR;
using SupleNet.Application.Responses.Common;

namespace SupleNet.Application.UseCases.Brand.Queries.GetBrands
{
    public record GetBrandsQuery(string Name = "", bool OrderByDate = false) : IRequest<Result<GetBrandsQueryResponse[]>>;
}
