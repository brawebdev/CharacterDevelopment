using System;
using System.Web.Http;
using CharacterDevelopment.Contracts;
using CharacterDevelopment.Models.Skill;
using CharacterDevelopment.Services;
using Microsoft.AspNet.Identity;

namespace CharacterDevelopment.API.Controllers
{
    [Authorize]
    public class SkillController : ApiController
    {
        private ISkillService service;

        public SkillController(ISkillService mockService)
        {
            service = mockService;
        }

        public IHttpActionResult GetAll()
        {
            CreateSkillService();
            var skill = service.GetSkills();

            return Ok(skill);
        }

        public IHttpActionResult Get(int id)
        {
            CreateSkillService();
            var skill = service.GetSkillById(id);

            return Ok(skill);
        }

        public IHttpActionResult Post(SkillCreate skill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CreateSkillService();

            if (!service.CreateSkill(skill))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(SkillEdit skill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CreateSkillService();

            if (!service.UpdateSkill(skill))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            CreateSkillService();

            if (!service.DeleteSkill(id))
                return InternalServerError();

            return Ok();
        }

        public void CreateSkillService()
        {
            if (service == null)
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                service = new SkillService(userId);
            }
        }
    }
}
