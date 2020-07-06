using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Posts.Queries
{
    public class CommentDto: IMapFrom<Comment>
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
    }
}
