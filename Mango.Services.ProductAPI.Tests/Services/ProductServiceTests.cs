using Mango.Services.ProductAPI.Models.DTOs;
using Mango.Web;
using Mango.Web.Services;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Tests.Services
{
    public class ProductServiceTests
    {
        public ProductServiceTests()
        {
        }

        [Fact]
        public async Task GetProductByIdAsync_WhereProductsExist_ReturnsProductDTO()
        {
            //Arrange
            var id = 1;
            SD.ProductAPIBase = "https://Test.com";

            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
            .Protected()
                // Setup the PROTECTED method to mock
                .Setup<Task<HttpResponseMessage>>(
                 "SendAsync", ItExpr.IsAny<HttpRequestMessage>(),ItExpr.IsAny<CancellationToken>())
                // prepare the expected response of the mocked http call
           .ReturnsAsync(new HttpResponseMessage()
           {
               StatusCode = HttpStatusCode.OK,
               Content = new StringContent("{\"isSuccess\":true,\"result\":{\"productId\":1,\"name\":\"Steak\",\"price\":24,\"description\":\"JuicySteakandChunkyChips\",\"categoryName\":\"Mains\",\"imageUrl\":\"https://andrewmmango.blob.core.windows.net/mango/Steak.jpg\"},\"displayMessage\":\"\",\"errorMessages\":null}"),
           })
           .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("http://test.com/"),
            };

            var clientFactory = new Mock<IHttpClientFactory>(MockBehavior.Strict);
            clientFactory
                .Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(httpClient);

            var _sut = new ProductService(clientFactory.Object);

            //Act
            var result = await _sut.GetProductByIdAsync<ProductDto>(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ProductDto>(result);

            var expectedUri = new Uri("http://test.com/api/test/whatever");

            handlerMock.Protected().Verify(
               "SendAsync",
               Times.Exactly(0), // we expected a single external request
               ItExpr.Is<HttpRequestMessage>(req =>
                  req.Method == HttpMethod.Get  // we expected a GET request
                  && req.RequestUri == expectedUri // to this uri
               ),
               ItExpr.IsAny<CancellationToken>()
            );
        }
    }
}
