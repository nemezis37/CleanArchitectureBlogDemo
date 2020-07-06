using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Posts.Commands.DeletePost
{
    public class DeletePostCommand: IRequest
    {
        public int Id { get; set; }
    }


    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePostCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(post == null)
                throw new NotFoundException(nameof(Post), request.Id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
