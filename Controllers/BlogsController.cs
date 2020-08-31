using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using latesummer2020_dotnet_bloggr.Models;
using latesummer2020_dotnet_bloggr.Services;
using Microsoft.AspNetCore.Mvc;
namespace latesummer2020_dotnet_bloggr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogsService _blogsService;
        private readonly CommentsService _commentsService;

        public BlogsController(BlogsService blogsService, CommentsService commentsService)
        {
            _blogsService = blogsService;
            _commentsService = commentsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Blog>> Get()
        {
            try
            {
                return Ok(_blogsService.Get());
            }
            catch (System.Exception err)
            {

                return BadRequest(err);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Blog> GetById(int id)
        {
            try
            {
                return Ok(_blogsService.GetById(id));
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}/comments")]
        public ActionResult<IEnumerable<Comment>> GetCommentsByBlogId(int id)
        {
            try
            {
                return Ok(_commentsService.GetCommentsByBlogId(id));
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpPost]
        public ActionResult<Blog> Create([FromBody] Blog newBlog)
        {
            try
            {
                return Ok(_blogsService.Create(newBlog));
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Blog> Update(int id, [FromBody] Blog updatedBlog)
        {
            try
            {
                return Ok(_blogsService.Update(id, updatedBlog));
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                return Ok(_blogsService.Delete(id));
            }
            catch (System.Exception err)
            {

                return BadRequest(err.Message);
            }
        }
    }
}