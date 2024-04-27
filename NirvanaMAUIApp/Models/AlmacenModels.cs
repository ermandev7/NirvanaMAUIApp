using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NirvanaMAUIApp.Models
{
    public class AlmacenModels
    {
        public int almacenId { get; set; }
        [Required]
        public string? nombre { get; set; }
        public string? descripcion { get; set; }
        public int sucursalId { get; set; }
        public int estado { get; set; }
    }


    public class Data
    {
        public string? title { get; set; }
        public DateTime fechaHora { get; set; }
        public string? status { get; set; }
        public List<object>? messages { get; set; }
        public List<AlmacenModels>? result { get; set; }
    }
}
