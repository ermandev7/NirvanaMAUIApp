using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NirvanaMAUIApp.Models
{
    public class LoginApiResponse
    {
        public string title { get; set; }
        public DateTime timestamp { get; set; }
        public string status { get; set; }
        public List<string> messages { get; set; }
        public LoginResponse result { get; set; }
    }
}
