using BlogApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Domain.Entities
{
    public class Post:BaseEntity<Guid>
    {

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public string Slug { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public User Author { get; set; } = null!;
    }
}
