using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand: IRequest<int>
    {
        public int PostId { get; set; }
        public string Body { get; set; }

        public string Author { get; set; }
    }

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCommentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                Author = request.Author,
                PostId = request.PostId,
                Body = request.Body
            };
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync(cancellationToken);
            return comment.Id;
        }
    }
}
