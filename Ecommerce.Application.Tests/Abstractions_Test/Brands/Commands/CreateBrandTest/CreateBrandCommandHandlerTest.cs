using Ecommerce.Application.Abstractions.Brands.Commands.CreateBrand;
using Ecommerce.Application.DTOs.Brands;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Base;
using FluentAssertions;
using Moq;

namespace Ecommerce.Application.Tests.Abstractions_Test.Brands.Commands.CreateBrandTest
{
   
    public class CreateBrandCommandHandlerTest
    {
        private readonly Mock<IBaseRepository<Brand>> _brandRepositoryMock;
        public CreateBrandCommandHandlerTest()
        {
            _brandRepositoryMock = new();
        }
        [Fact]
        public async Task Handle_Should_ReturnFailureResult_WhenBrandNameIsEmpty()
        {
            //Arrange
            var command = new CreateBrandCommand(new BrandDto { Name = string.Empty });

            var handler = new CreateBrandCommandHandler(_brandRepositoryMock.Object);

            //Act
            var result = await handler.Handle(command, default);

            //Asssert
            result.IsFailure.Should().BeTrue();
            result.IsSucess.Should().BeFalse();

        }

    }
}
