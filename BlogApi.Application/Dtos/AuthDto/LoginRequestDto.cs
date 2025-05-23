using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApi.Application.Dtos.AuthDto
{
     public class LoginRequestDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
