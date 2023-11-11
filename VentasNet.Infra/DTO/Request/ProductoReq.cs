using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace VentasNet.Infra.DTO.Request
{
    public class ProductoReq
    {
        public int IdProducto { get; set; }
        public int? IdProveedor { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string? ImporteProducto { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdUsuario { get; set; }
        public int CodigoProducto { get;set; }
    }
}
