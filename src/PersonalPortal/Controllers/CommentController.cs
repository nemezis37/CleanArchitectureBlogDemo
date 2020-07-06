using System.Threading.Tasks;
using CleanArchitecture.Application.Comments.Commands.CreateComment;
using CleanArchitecture.Application.Comments.Commands.DeleteComment;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PersonalPortal.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCommentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCommentCommand { Id = id });
            return NoContent();
        }
    }
}
