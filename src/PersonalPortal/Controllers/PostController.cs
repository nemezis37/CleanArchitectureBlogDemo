using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CleanArchitecture.Application.Posts.Commands.CreatePost;
using CleanArchitecture.Application.Posts.Commands.DeletePost;
using CleanArchitecture.Application.Posts.Queries;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace PersonalPortal.Controllers
{
    [Route("api/[controller]")]
    public class PostController : ApiController
    {
        [Route("page")]
		[HttpGet]
        public async Task<ActionResult<PostsVm>> GetPosts()
        {
			return await Mediator.Send(new GetPostsQuery());
        }

        [HttpGet("{id}")]
		public async Task<ActionResult<PostDto>> GetPost(int id)
		{
			return await Mediator.Send(new GetPostQuery{ Id = id});
		}
        
		[HttpPost]
		public async Task<ActionResult<int>> Create(CreatePostCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
	    public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeletePostCommand {Id = id});
            return NoContent();
        }
	}
}
