using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand: IRequest
    {
        public int Id { get; set; }
    }


    public class DeletePostCommandHandler : IRequestHandler<DeleteCommentCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePostCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(comment == null)
                throw new NotFoundException(nameof(Comment), request.Id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
