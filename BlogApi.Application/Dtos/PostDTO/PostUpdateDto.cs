using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Dtos.PostDTO
{
    public class PostUpdateDto
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
