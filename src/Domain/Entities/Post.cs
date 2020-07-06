using System.Collections.Generic;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Post: AuditableEntity
    {      
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
