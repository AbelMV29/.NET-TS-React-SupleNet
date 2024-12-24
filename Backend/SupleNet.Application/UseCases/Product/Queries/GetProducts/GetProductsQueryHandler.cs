using MediatR;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Application.Responses.Common;
using SupleNet.Domain.Utils;
using System.Net;

namespace SupleNet.Application.UseCases.Product.Queries.GetProducts
{
    internal sealed class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<GetProductsQueryResponse>>
    {
        private readonly IProductRepository _productRepository;
        public async Task<Result<GetProductsQueryResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var productsQuery = _productRepository.GetAllReadOnlyIncludeSaleDetailsAsync();

            if(request.BrandId is not null)
                productsQuery = productsQuery.Where(p=>p.BrandId == request.BrandId);

            if(request.CategoryId is not null)
                productsQuery = productsQuery.Where(p=>p.CategoryId ==  request.CategoryId);

            if (string.IsNullOrEmpty(request.Name))
                productsQuery = productsQuery.Where(p => p.Name.ToLower().Contains(request.Name.ToLower()));

            productsQuery = request.FilterProducts switch
            {
                FilterProducts.Lower => productsQuery.OrderBy(p => p.Price),
                FilterProducts.Upper => productsQuery.OrderByDescending(p => p.Price),
                FilterProducts.Feature => productsQuery.OrderBy(p => p.SaleDetails.Count)
            };

            var totalItems = productsQuery.Count();
            var totalPages = Convert.ToInt32(Math.Ceiling(totalItems / 9d));
            var productsPaged = productsQuery.Skip(request.Page - 1)
                .Take(9)
                .Select(p =>new GetProductsQueryResponse.GetProductsItemQueryResponse(p.Id, p.Name, p.Price, p.Image))
                .ToArray();

            var result = new GetProductsQueryResponse(request.Page, totalPages, productsPaged);

            return Result<GetProductsQueryResponse>.Success(result, null, HttpStatusCode.OK);
        }
    }

}
