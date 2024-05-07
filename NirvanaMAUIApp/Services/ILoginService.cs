using NirvanaMAUIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NirvanaMAUIApp.Services
{
    public interface ILoginService
    {
        Task<bool> Login(LoginRequest loginRequest);
    }
}
