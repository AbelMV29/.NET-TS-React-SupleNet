using FluentValidation;
using MediatR;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Application.Responses.Common;

namespace SupleNet.Application.UseCases.Brand.Queries.GetBrands
{
    internal class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, Result<GetBrandsQueryResponse[]>>
    {
        private readonly IBrandRepository _brandRepository;

        public GetBrandsQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Result<GetBrandsQueryResponse[]>> Handle(GetBrandsQuery request, CancellationToken cancellationToken)
        {
            var brandsQuery = _brandRepository.GetAllReadOnly();   
            
            if(!string.IsNullOrEmpty(request.Name))
                brandsQuery = brandsQuery.Where(b=>b.Name.ToLower().Contains(request.Name.ToLower()));

            var brands =  request.OrderByDate ? brandsQuery.OrderBy(b => b.CreatedDate).ToArray() : brandsQuery.OrderByDescending(b => b.CreatedDate).ToArray();

            var result = brands.Select(b =>
            {
                return new GetBrandsQueryResponse(b.Id, b.Name, b.CreatedDate);
            }).ToArray();

            return Result<GetBrandsQueryResponse[]>.Success(result, null, System.Net.HttpStatusCode.OK);
        }
    }
}
