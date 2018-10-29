namespace PharmacyPurchase.Tests.Application.Orders
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Moq;
    using PharmancyPurchase.Application.Orders;
    using PharmancyPurchase.Communication;
    using PharmancyPurchase.Core;
    using PharmancyPurchase.Core.Domain.Entities;
    using PharmancyPurchase.Crosscutting;
    using Xunit;

    public class OrdersServiceTest
    {
        [Fact]
        public async Task Test()
        {
            // Arrange
            var expected = new OrderDto()
            {
                Id = 5
            };
            var repoMock = new Mock<IRepository<Medicament>>();
            repoMock.Setup(a => a.GetAllListAsync()).Returns(Task.FromResult<List<Medicament>>(new List<Medicament>()));
            var mappingMock = new Mock<IMappingService>();
            mappingMock.Setup(a => a.Map<IEnumerable<OrderDto>>(It.IsAny<IEnumerable<Medicament>>())).Returns(new List<OrderDto>(){ expected });
            var service = new OrdersAppService(repoMock.Object, mappingMock.Object);

            // Act
            var result = await service.GetPossibleOrdersAsync();

            // Assert
            Assert.Contains(expected, result);
        }
    }
}