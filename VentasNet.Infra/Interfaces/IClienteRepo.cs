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
    public interface IClienteRepo
    {
        public ClienteResponse AgregarCliente(ClienteReq objCliente);
        public Cliente MapeoCliente(ClienteReq objCliente);
        public ClienteResponse UpdateCliente(ClienteReq objCliente);
        public ClienteResponse Delete(ClienteReq objCliente);
        public Cliente GetClienteCuit(string cuit);
        public List<ClienteReq> GetClientes();
    }
}
