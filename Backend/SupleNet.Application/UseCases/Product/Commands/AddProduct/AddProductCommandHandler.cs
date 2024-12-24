using MediatR;
using Microsoft.AspNetCore.Http;
using SupleNet.Application.Interfaces.Persistence.Identity;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Application.Interfaces.Persistence.UnitOfWork;
using SupleNet.Application.Responses.Common;
using SupleNet.Domain.Entities;
using System.Net;
using System.Security.Claims;

namespace SupleNet.Application.UseCases.Product.Commands.AddProduct
{
    internal sealed class AddProductCommandHandler : IRequestHandler<AddProductCommand, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContext;
        public async Task<Result<Unit>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var productToAdd = new Domain.Entities.Product
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                CreatedBy = new Guid(currentUserId!),
                CreatedDate = DateTime.UtcNow.AddHours(-3)
            };

            List<ProductCategory> productCategories = new List<ProductCategory>();
            foreach(var id in request.categoriesId)
            {
                productCategories.Add(new ProductCategory
                {
                    CategoryId = id,
                    ProductId = productToAdd.Id,
                    CreatedBy = new Guid(currentUserId!),
                    CreatedDate = DateTime.UtcNow.AddHours(-3),
                });
            }

            
        }
    }
}
