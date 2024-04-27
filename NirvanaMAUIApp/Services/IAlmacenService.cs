using NirvanaMAUIApp.Generic;
using NirvanaMAUIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NirvanaMAUIApp.Services
{
    public interface IAlmacenService 
    {
        Task<List<AlmacenModels>> All();
        Task<bool> UpdateAlmacen(AlmacenModels almacen);
        Task<bool> DeleteAlmacen(int almacenId);
        Task<bool> RegistrarNuevoAlmacen(AlmacenModels almacen);
    }
}
