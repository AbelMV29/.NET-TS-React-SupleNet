using MediatR;
using Microsoft.AspNetCore.Http;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Application.Responses.Common;
using System.Net;
using System.Security.Claims;

namespace SupleNet.Application.UseCases.ItemCart.Command.AddItemCart
{
    public class AddItemCartCommandHandler : IRequestHandler<AddItemCartCommand, Result<Unit>>
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IItemCartRepository _itemCartRepository;
        public async Task<Result<Unit>> Handle(AddItemCartCommand request, CancellationToken cancellationToken)
        {
            var currentUserId = new Guid(_httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var existsItemInUserCart = await _itemCartRepository.GetByProductIdUser(request.ProductId, currentUserId);

            if (existsItemInUserCart is null)
            {
                var itemCartToAdd = new Domain.Entities.ItemCart
                {
                    CreatedBy = currentUserId,
                    CreatedDate = DateTime.UtcNow.AddHours(-3),
                    ProductId = request.ProductId,
                    Quantity = 1
                };

                try
                {
                    await _itemCartRepository.AddAsync(itemCartToAdd);
                    await _itemCartRepository.SaveChangesAsync();

                    return Result<Unit>.Success(Unit.Value, "Producto añadido al carrito con éxito", HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return Result<Unit>.Failed(ex.Message, HttpStatusCode.InternalServerError);
                }
                
            }
            else
            {
                existsItemInUserCart.Quantity += 1;

                try
                {
                    await _itemCartRepository.UpdateAsync(existsItemInUserCart);
                    await _itemCartRepository.SaveChangesAsync();
                    return Result<Unit>.Success(Unit.Value, "Producto añadido al carrito con éxito", HttpStatusCode.OK);
                }
                catch (Exception ex)
                {
                    return Result<Unit>.Failed(ex.Message, HttpStatusCode.InternalServerError);
                }
            }
        }
    }
}
