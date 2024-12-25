using FluentValidation;
using MediatR;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Application.Responses.Common;

namespace SupleNet.Application.UseCases.Category.Queries.GetCategories
{
    internal class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, Result<GetCategoriesQueryResponse[]>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result<GetCategoriesQueryResponse[]>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categoriesQuery = _categoryRepository.GetAllReadOnly();

            if (!string.IsNullOrEmpty(request.Name))
                categoriesQuery = categoriesQuery.Where(b => b.Name.ToLower().Contains(request.Name.ToLower()));

            var categories = request.OrderByDate ? categoriesQuery.OrderBy(b => b.CreatedDate).ToArray() : categoriesQuery.OrderByDescending(b => b.CreatedDate).ToArray();

            var result = categories.Select(b =>
            {
                return new GetCategoriesQueryResponse(b.Id, b.Name, b.CreatedDate);
            }).ToArray();

            return Result<GetCategoriesQueryResponse[]>.Success(result, null, System.Net.HttpStatusCode.OK);
        }
    }
}
