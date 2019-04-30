using System;
using System.Web.Http;
using CharacterDevelopment.Contracts;
using CharacterDevelopment.Models.Post;
using CharacterDevelopment.Services;
using Microsoft.AspNet.Identity;

namespace CharacterDevelopment.API.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
        private IPostService service;

        public PostController(IPostService mockService)
        {
            service = mockService;
        }

        public IHttpActionResult GetAll()
        {
            CreatePostService();

            var posts = service.GetPosts();
            return Ok(posts);
        }

        public IHttpActionResult Get(int id)
        {
            CreatePostService();
            var post = service.GetPostById(id);
            return Ok(post);
        }

        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(PostEdit post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CreatePostService();

            if (!service.UpdatePost(post))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            CreatePostService();

            if (!service.DeletePost(id))
                return InternalServerError();

            return Ok();
        }

        private void CreatePostService()
        {
            if (service == null)
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                service = new PostService(userId);
            }
        }
    }
}
