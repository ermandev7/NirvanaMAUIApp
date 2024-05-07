using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NirvanaMAUIApp.Models
{
    public class LoginResponse
    {
        public string username { get; set; }
        public string tokenId { get; set; }
        public string refreshToken { get; set; }
        public string accessToken { get; set; }
    }
}
