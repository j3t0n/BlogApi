using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Dtos
{
   public class ResponseDto
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
    }
}
