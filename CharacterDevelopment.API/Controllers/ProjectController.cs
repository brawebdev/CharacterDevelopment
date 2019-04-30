using System;
using System.Web.Http;
using CharacterDevelopment.Contracts;
using CharacterDevelopment.Models.Project;
using CharacterDevelopment.Services;
using Microsoft.AspNet.Identity;

namespace CharacterDevelopment.API.Controllers
{
    [Authorize]
    public class ProjectController : ApiController
    {
        private IProjectService service;

        public ProjectController(IProjectService mockService)
        {
            service = mockService;
        }

        public IHttpActionResult GetAll()
        {
            CreateProjectService();
            var project = service.GetProjects();
            return Ok(project);
        }

        public IHttpActionResult Get(int id)
        {
            CreateProjectService();
            var project = service.GetProjectById(id);
            return Ok(project);
        }

        public IHttpActionResult Post(ProjectCreate project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CreateProjectService();

            if (!service.CreateProject(project))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(ProjectEdit project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CreateProjectService();

            if (!service.UpdateProject(project))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            CreateProjectService();

            if (!service.DeleteProject(id))
                return InternalServerError();

            return Ok();
        }

        private void CreateProjectService()
        {
            if (service == null)
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                service = new ProjectService(userId);
            }
        }
    }
}
