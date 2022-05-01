using Xunit;
using Moq;
using UrlShortner.Service.Database;
using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortner.Models;

namespace UrlShortner.Service.Tests
{
    public class ControllerTests
    {
        private readonly Mock<IContextTest> _mockMongoDB;
        private readonly UrlShortner.Service.Controllers.UriController _controller;
        private List<UrlShortner.Models.ShortenedUrl> _fakedata;

        public ControllerTests()
        {
            _mockMongoDB = new Mock<IContextTest>();
            _controller = new Controllers.UriController(_mockMongoDB.Object);
            _fakedata = new List<UrlShortner.Models.ShortenedUrl>();

            _mockMongoDB.Setup((x) => x.InsertAsync(It.IsAny<UrlShortner.Models.ShortenedUrl>()))
               .Callback((UrlShortner.Models.ShortenedUrl Uri) => _fakedata.Add(Uri)).Returns(Task.CompletedTask);

            _mockMongoDB.Setup((x) => x.GetAsync(It.IsAny<string>()))
              .Returns<string>((x) =>Task.FromResult (_fakedata.FindLast((y) => y.token == x)));
        }

        [Theory]
        [InlineData("https://www.mydummywebsite.com/myapi?=greengrass")]
        public void Shorten_AddsURIToCollection( string Uri)
        {
            
            //Arrange
            _fakedata.Clear();

            //Act 
            var asyncResult =  _controller.ShortenUrl(Uri);
            asyncResult.Wait();

            //Assert
            Assert.True(_fakedata.FindAll((x) => x.url == Uri).Count > 0);
        }

        [Theory]
        [InlineData("https://www.mydummywebsite.com/myapi?=greengrass")]
        [InlineData("http://www.bbc.co.uk")]
        [InlineData("www.reddit.com")]
        public void Get_RetrievesSameURIAsInserted( string inputUri)
        {

            //Arrange
            _fakedata.Clear();


            //Act 
            var asyncToken = _controller.ShortenUrl(inputUri);
            asyncToken.Wait();
            string token = asyncToken.Result;

            var asyncUristring = _controller.GetRedirectUri(token);
            asyncUristring.Wait();
            string redirectUri = asyncUristring.Result.Value??"";

            System.Console.WriteLine(redirectUri);

            string cleanedInput = inputUri;
            if (inputUri.StartsWith("http")==false)
            {
                cleanedInput = $"http://{inputUri}";
            }

            //Assert
            Assert.StartsWith("http", redirectUri.ToLowerInvariant());
            Assert.Equal(cleanedInput.ToLowerInvariant(), redirectUri.ToLowerInvariant());
        }
    }
}