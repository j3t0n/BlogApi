using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Dtos.PostDTO
{
    public class PostCreateDto
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public Guid AuthorId { get; set; }
    }
}
