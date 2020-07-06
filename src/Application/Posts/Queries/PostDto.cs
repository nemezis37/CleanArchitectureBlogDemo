
using System.Collections.Generic;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Posts.Queries
{
    public class PostDto: IMapFrom<Post>
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public virtual IList<CommentDto> Comments { get; set; }
    }
}
