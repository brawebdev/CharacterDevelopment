using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CharacterDevelopment.Models.Skill;
using CharacterDevelopment.Services;
using Microsoft.AspNet.Identity;

namespace CharacterDevelopment.API.Controllers
{
    [Authorize]
    public class SkillController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            SkillService skillService = CreateSkillService();
            var skill = skillService.GetSkills();
            return Ok(skill);
        }

        public IHttpActionResult Get(int id)
        {
            SkillService skillService = CreateSkillService();
            var skill = skillService.GetSkillById(id);
            return Ok(skill);
        }

        public IHttpActionResult Post(SkillCreate skill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSkillService();

            if (!service.CreateSkill(skill))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(SkillEdit skill)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSkillService();

            if (!service.UpdateSkill(skill))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            SkillService skillService = CreateSkillService();

            if (!skillService.DeleteSkill(id))
                return InternalServerError();

            return Ok();
        }

        public SkillService CreateSkillService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var skillService = new SkillService(userId);
            return skillService;
        }
    }
}
