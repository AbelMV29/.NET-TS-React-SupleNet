using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Moq;
using SupleNet.Application.Interfaces.Persistence.Repositories;
using SupleNet.Application.UseCases.Category.Commands.AddCategory;
using System.Net;
using System.Security.Claims;

namespace SupleNet.Application.Test.UseCases.Category
{
    public class AddCategoryTests
    {
        private readonly AddCategoryCommandHandler _commandHandler;
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly Mock<IHttpContextAccessor> _httpContextMock;
        public AddCategoryTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _httpContextMock = new Mock<IHttpContextAccessor>();
            _commandHandler = new AddCategoryCommandHandler(_categoryRepositoryMock.Object,
                _httpContextMock.Object);
        }
        [Fact]
        public async Task AddCategory_WhenNameAlreadyExists_ShouldReturnResultFailed()
        {
            //Arrange
            AddCategoryCommand request = new AddCategoryCommand("Vitaminas");

            _httpContextMock.Setup(instance => instance.HttpContext)
                .Returns(new DefaultHttpContext());
            _httpContextMock.Object.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(
                new Claim[] { new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()) }
            ));
            _categoryRepositoryMock
                .Setup(instance => instance.ExistByName(request.Name))
                .ReturnsAsync(true);

            //Act
            var response = await _commandHandler.Handle(request, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().Be(false);
            response.Message.Should().Be($"La categoría con el nombre {request.Name} ya existe");
            response.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
            _categoryRepositoryMock.Verify(x => x.ExistByName(request.Name), Times.Once);
        }

        [Fact]
        public async Task AddCategory_WhenAllIsOk_ShouldReturnResultTrue()
        {
            //Arrange
            AddCategoryCommand request = new AddCategoryCommand("Vitaminas");
            string userId = Guid.NewGuid().ToString();
            _httpContextMock.Setup(instance => instance.HttpContext)
                .Returns(new DefaultHttpContext());
            _httpContextMock.Object.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(
                new Claim[] { new Claim(ClaimTypes.NameIdentifier, userId) }
            ));
            _categoryRepositoryMock
                .Setup(instance => instance.ExistByName(request.Name))
                .ReturnsAsync(false);
            _categoryRepositoryMock
                .Setup(instance => instance.AddAsync(It.IsAny<Domain.Entities.Category>()))
                .ReturnsAsync(new Domain.Entities.Category { });
            _categoryRepositoryMock
                .Setup(instance => instance.SaveChangesAsync())
                .Returns(Task.CompletedTask);

            //Act
            var response = await _commandHandler.Handle(request, CancellationToken.None);

            //Assert
            response.Should().NotBeNull();
            response.IsSuccess.Should().Be(true);
            response.Message.Should().Be($"Categoría {request.Name} creada con éxito");
            response.HttpStatusCode.Should().Be(HttpStatusCode.Created);
            _categoryRepositoryMock.Verify(x => x.ExistByName(request.Name), Times.Once);
            _categoryRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Domain.Entities.Category>()), Times.Once);
            _categoryRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}
