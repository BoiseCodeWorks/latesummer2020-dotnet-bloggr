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
    public class CommentsController : ControllerBase
    {
        private readonly CommentsService _commentsService;

        public CommentsController(CommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Comment>> Get()
        {
            try
            {
                return Ok(_commentsService.Get());
            }
            catch (System.Exception err)
            {

                return BadRequest(err);
            }
        }

        [HttpPost]
        public ActionResult<Comment> Create([FromBody] Comment newComment)
        {
            try
            {
                return Ok(_commentsService.Create(newComment));
            }
            catch (System.Exception err)
            {

                return BadRequest(err);
            }
        }
    }
}