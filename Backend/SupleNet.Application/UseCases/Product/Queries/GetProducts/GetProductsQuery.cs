using MediatR;
using SupleNet.Application.Responses.Common;
using SupleNet.Domain.Utils;

namespace SupleNet.Application.UseCases.Product.Queries.GetProducts
{
    public record GetProductsQuery(int Page = 1, string Name = "",
        FilterProducts FilterProducts = FilterProducts.Feature,
        Guid? CategoryId = null, Guid? BrandId = null) : IRequest<Result<GetProductsQueryResponse>>;

}
