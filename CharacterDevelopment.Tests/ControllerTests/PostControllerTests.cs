using System.Collections.Generic;
using System.Web.Http.Results;
using CharacterDevelopment.API.Controllers;
using CharacterDevelopment.Contracts;
using CharacterDevelopment.Models.Post;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CharacterDevelopment.Tests.ControllerTests
{
    [TestClass]
    public class PostControllerTests
    {
        private Mock<IPostService> mockService;
        private PostController controller;

        [TestInitialize]
        public void Setup()
        {
            mockService = new Mock<IPostService>();
            controller = new PostController(mockService.Object);
        }

        [TestMethod]
        public void GetAllShouldReturnOkOnSuccess()
        {
            var result = controller.GetAll();

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<PostListItem>>));
        }

        [TestMethod]
        public void GetShouldReturnOkOnSuccess()
        {
            mockService.Setup(e => e.GetPostById(It.IsAny<int>()))
                .Returns(It.IsAny<PostDetail>());

            var result = controller.Get(It.IsAny<int>());

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<PostDetail>));
        }

        [TestMethod]
        public void PutShouldReturnOkOnSuccess()
        {
            mockService.Setup(e => e.UpdatePost(It.IsAny<PostEdit>()))
                .Returns(true);

            var updatedPost = new PostEdit
            {
                PostId = It.IsAny<int>(),
                Content = It.IsAny<string>(),
                Title = It.IsAny<string>()
            };

            var result = controller.Put(updatedPost);

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void DeleteShouldReturnOkOnSuccess()
        {
            mockService.Setup(e => e.DeletePost(It.IsAny<int>()))
                .Returns(true);

            var result = controller.Delete(It.IsAny<int>());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
