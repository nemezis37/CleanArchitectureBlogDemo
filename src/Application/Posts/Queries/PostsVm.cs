using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Posts.Queries
{
    public class PostsVm
    {
        public IList<PostDto> Posts { get; set; }
    }
}
