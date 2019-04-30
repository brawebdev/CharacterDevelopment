using System.Collections.Generic;
using System.Web.Http.Results;
using CharacterDevelopment.API.Controllers;
using CharacterDevelopment.Contracts;
using CharacterDevelopment.Models.Skill;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CharacterDevelopment.Tests.ControllerTests
{
    [TestClass]
    public class SkillControllerTests
    {
        private Mock<ISkillService> service;
        private SkillController controller;

        [TestInitialize]
        public void Setup()
        {
            service = new Mock<ISkillService>();
            controller = new SkillController(service.Object);
        }

        [TestMethod]
        public void GetAllShouldReturnOkOnSuccess()
        {
            var result = controller.GetAll();

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<SkillListItem>>));
        }

        [TestMethod]
        public void GetShouldReturnOkOnSuccess()
        {
            service.Setup(e => e.GetSkillById(It.IsAny<int>()))
                .Returns(It.IsAny<SkillDetail>());

            var result = controller.Get(It.IsAny<int>());

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<SkillDetail>));
        }

        [TestMethod]
        public void PostShouldReturnOkOnSuccess()
        {
            service.Setup(e => e.CreateSkill(It.IsAny<SkillCreate>()))
                .Returns(true);

            var result = controller.Post(It.IsAny<SkillCreate>());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void PutShouldReturnOkOnSuccess()
        {
            service.Setup(e => e.UpdateSkill(It.IsAny<SkillEdit>()))
                .Returns(true);

            var result = controller.Put(It.IsAny<SkillEdit>());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void DeleteShouldReturnOkOnSuccess()
        {
            service.Setup(e => e.DeleteSkill(It.IsAny<int>()))
                .Returns(true);

            var result = controller.Delete(It.IsAny<int>());

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
