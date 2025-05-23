using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Dtos.AuthDto
{
    public class LoginResponseDto:ResponseDto
    {
        public string? Token { get; set; }
    }
}
