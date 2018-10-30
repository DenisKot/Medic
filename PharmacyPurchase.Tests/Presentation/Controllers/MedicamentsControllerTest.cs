namespace PharmacyPurchase.Tests.Presentation.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Moq;
    using PharmacyPurchase.Presentation.Controllers;
    using PharmancyPurchase.Application.Orders;
    using PharmancyPurchase.Communication;
    using PharmancyPurchase.Communication.Orders;
    using Xunit;

    public class MedicamentsControllerTest
    {
        [Fact]
        public async Task Test()
        {
            // Arrange
            var mock = new Mock<IOrdersAppService>();
            mock.Setup(a => a.GetPossibleOrdersAsync()).Returns(Task.FromResult<IEnumerable<OrderDto>>(new List<OrderDto>()));
            var controller = new OrdersController(mock.Object);

            // Act
            var result = await controller.List();

            // Assert
            Assert.NotNull(result);
        }
    }
}