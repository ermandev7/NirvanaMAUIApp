using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NirvanaMAUIApp.Generic
{
    public class DataResult<T>
    {
        public string? title { get; set; }
        public DateTime fechaHora { get; set; }
        public string? status { get; set; }
        public List<object>? messages { get; set; }
        public List<T>? result { get; set; } // Ahora es una lista genérica
    }

}
