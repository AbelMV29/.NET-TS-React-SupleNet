using MediatR;
using Microsoft.AspNetCore.Http;
using SupleNet.Application.Interfaces.CloudMedia;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Application.Interfaces.Persistence.UnitOfWork;
using SupleNet.Application.Responses.CloudMedia;
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
        private readonly IGalleryRepository _galleryRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ICloudMediaService _cloudMediaService;

        public AddProductCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository,
            ICategoryRepository categoryRepository, IGalleryRepository galleryRepository, 
            IHttpContextAccessor httpContext, ICloudMediaService cloudMediaService, IBrandRepository brandRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _galleryRepository = galleryRepository;
            _httpContext = httpContext;
            _cloudMediaService = cloudMediaService;
            _brandRepository = brandRepository;
        }

        public async Task<Result<Unit>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = new Guid(_httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var productToAdd = new Domain.Entities.Product
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                CategoryId = request.CategoryId,
                BrandId = request.BrandId,
                CreatedBy = currentUserId,
                CreatedDate = DateTime.UtcNow.AddHours(-3)
            };

            if (await _brandRepository.GetReadOnlyAsync(request.BrandId) is null)
                return Result<Unit>.Failed($"La marca con el id: {request.BrandId} no existe", HttpStatusCode.BadRequest);

            if (await _categoryRepository.GetReadOnlyAsync(request.CategoryId) is null)
                return Result<Unit>.Failed($"La categoría con el id: {request.CategoryId} no existe", HttpStatusCode.BadRequest);

            var imageTask = _cloudMediaService.UploadImage(request.Image);

            List<Task<CloudMediaResponse?>> tasks = new List<Task<CloudMediaResponse>>();
            foreach (var file in request.Files)
            {
                tasks.Add(IsImage(file) ?
                    _cloudMediaService.UploadImage(file) :
                    _cloudMediaService.UploadVideo(file));
            }

            

            var cloudResponses = await Task.WhenAll(tasks);
            var imageResponse = await imageTask;
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                productToAdd.Image = imageResponse.Url;
                var productAddedTask = _productRepository.AddAsync(productToAdd);

                List<Gallery> galleries = new List<Gallery>();
                

                foreach (var cloudResponse in cloudResponses)
                {
                    galleries.Add(new Gallery
                    {
                        CreatedBy = currentUserId,
                        ProductId = productToAdd.Id,
                        ImageId = cloudResponse.Id,
                        ImageURL = cloudResponse.Url,
                        CreatedDate = DateTime.UtcNow.AddHours(-3),
                    });
                }
                await Task.WhenAll(productAddedTask);
                await _galleryRepository.AddRangeAsync(galleries);

                await _unitOfWork.CommitTransactionAsync();
                return Result<Unit>.Success(Unit.Value, $"Producto: {productToAdd.Name} agregado exitosamente", HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                _cloudMediaService.DeleteMedia(imageResponse.Id);
                foreach(var response in cloudResponses)
                {
                    _cloudMediaService.DeleteMedia(response.Id);
                }
                return Result<Unit>.Failed(ex.Message, HttpStatusCode.InternalServerError);
            }
            
        }

        private bool IsImage(IFormFile file)
        {
            return file.ContentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase);
        }
    }
}
