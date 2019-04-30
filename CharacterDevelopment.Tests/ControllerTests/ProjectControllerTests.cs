using System.Collections.Generic;
using System.Web.Http.Results;
using CharacterDevelopment.API.Controllers;
using CharacterDevelopment.Contracts;
using CharacterDevelopment.Models.Project;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CharacterDevelopment.Tests.ControllerTests
{
    [TestClass]
    public class ProjectControllerTests
    {
        private Mock<IProjectService> service;
        private ProjectController controller;

        [TestInitialize]
        public void Setup()
        {
            service = new Mock<IProjectService>();
            controller = new ProjectController(service.Object);
        }

        [TestMethod]
        public void GetAllShouldReturnOkOnSuccess()
        {
            var result = controller.GetAll();

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<ProjectListItem>>));
        }

        [TestMethod]
        public void PostShouldReturnOkOnSuccess()
        {
            service.Setup(e => e.CreateProject(It.IsAny<ProjectCreate>()))
                .Returns(true);

            var result = controller.Post(It.IsAny<ProjectCreate>());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void PostWithInvalidModelShouldReturnInternalServerError()
        {
            var result = controller.Post(null);

            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }

        [TestMethod]
        public void PutShouldReturnOkOnSuccess()
        {
            service.Setup(e => e.UpdateProject(It.IsAny<ProjectEdit>()))
                .Returns(true);

            var result = controller.Put(It.IsAny<ProjectEdit>());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void PutWithInvalidModelShouldReturnInternalServerError()
        {
            var result = controller.Put(null);

            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }

        [TestMethod]
        public void DeleteShouldReturnOkOnSuccess()
        {
            service.Setup(e => e.DeleteProject(It.IsAny<int>()))
                .Returns(true);

            var result = controller.Delete(It.IsAny<int>());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void DeleteWithInvalidIdShouldReturnInternalServerError()
        {
            var result = controller.Delete(It.IsAny<int>());

            Assert.IsInstanceOfType(result, typeof(InternalServerErrorResult));
        }
    }
}
