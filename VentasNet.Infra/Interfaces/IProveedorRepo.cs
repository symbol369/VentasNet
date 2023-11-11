using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;

namespace VentasNet.Infra.Interfaces
{
    public interface IProveedorRepo
    {
        public ProveedorResponse AgregarProveedor(ProveedorReq objProveedor);
        public ProveedorResponse UpdateProveedor(ProveedorReq proveedor);
        public ProveedorResponse Delete(ProveedorReq proveedor);
        public List<ProveedorReq> ListadoProveedores();
        public Proveedor GetProveedorCuit(string cuit);
    }
}
