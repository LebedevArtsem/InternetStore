using InternetStore.Controllers;
using MongoDB.Driver;
using Moq;
using Microsoft.AspNetCore.Mvc;

namespace InternetStore.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            //arange
            var mock = new Mock<IMongoDatabase>();

            HomeController controller = new HomeController(mock.Object);
            
            //act
            var result = controller.Index();

            //assert

            
        }
    }
}
