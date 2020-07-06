using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Posts.Queries
{
    public class GetPostsQuery: IRequest<PostsVm>
    {
    }

    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, PostsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPostsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PostsVm> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            return new PostsVm
            {
                Posts = await _context.Posts
                    .ProjectTo<PostDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
