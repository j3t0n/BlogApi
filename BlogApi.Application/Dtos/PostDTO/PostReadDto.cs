using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Dtos.PostDTO
{
    public class PostReadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public Guid AuthorId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
