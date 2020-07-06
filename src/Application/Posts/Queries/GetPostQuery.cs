using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Posts.Queries
{
    public class GetPostQuery : IRequest<PostDto>
    {
        public int Id { get; set; }
    }

    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, PostDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPostQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PostDto> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if(post == null)
                throw new NotFoundException(nameof(Post), request.Id);
            return _mapper.Map<PostDto>(_mapper.ConfigurationProvider);
        }
    }
}
