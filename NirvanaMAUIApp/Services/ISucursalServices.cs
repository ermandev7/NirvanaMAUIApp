using NirvanaMAUIApp.Generic;
using NirvanaMAUIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NirvanaMAUIApp.Services
{
    internal interface ISucursalServices 
    {
        Task<List<SucursalModels>> All();
        Task<bool> RegistrarNuevo (SucursalModels sucursal);
        Task<bool> DeleteSucursal(int iten);
        Task<bool> Update(SucursalModels sucursal);
    }
}
