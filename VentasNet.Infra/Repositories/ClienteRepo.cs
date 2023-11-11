using System.Dynamic;
using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using VentasNet.Models;
namespace VentasNet.Infra.Repositories

{
    public class ClienteRepo: IClienteRepo
    {

        private readonly VentasNetContext _context;

        public ClienteRepo(VentasNetContext context)
        {
            _context = context;
        }


        public ClienteResponse AgregarCliente(ClienteReq objCliente)
        {
            ClienteResponse clienteResponse = new ClienteResponse();
            var existeCliente = GetClienteCuit(objCliente.Cuit);
            if (objCliente.Cuit != null)
            {
                if (existeCliente == null)
                {
                    try
                    {
                        var clienteNew = MapeoCliente(objCliente);
                        clienteNew.Estado = true;
                        clienteNew.FechaAlta = DateTime.Now.Date;
                        clienteNew.Telefono = null;




                        //agregar
                        _context.Add(clienteNew);
                        _context.SaveChanges();
                        clienteResponse.Guardar = true;
                        clienteResponse.RazonSocial = clienteNew.RazonSocial;
                    }
                    catch (Exception ex)
                    {
                        clienteResponse.Mensaje = "Error al agregar Cliente";
                        clienteResponse.Guardar = false;
                    }
                }
            }
            return clienteResponse;
        }

        public Cliente MapeoCliente(ClienteReq obj)
        {
            Cliente cliente = new Cliente()
            {
                Apellido = obj.Apellido != null ? obj.Apellido : string.Empty,
                RazonSocial = obj.RazonSocial,
                Nombre = obj.Nombre != null ? obj.Nombre : string.Empty,
                Cuit = obj.Cuit,
                Domicilio = obj.Domicilio,
                Localidad = obj.Localidad,
                Telefono = obj.Telefono != null ? obj.Telefono : string.Empty,
                Provincia = obj.Provincia,
                FechaAlta = obj.FechaAlta,
                FechaBaja = obj.FechaBaja,
                Estado = obj.Estado,
                IdCliente = obj.IdCliente,
                IdUsuario = obj.IdUsuario
            };
            return cliente;


        }

        public void Edit(ClienteReq cli)
        {

            var index = ListadosReq.ListadoClientes.FindIndex(x => x.IdUsuario == cli.IdUsuario);
            ListadosReq.ListadoClientes[index].RazonSocial= cli.RazonSocial;
            ListadosReq.ListadoClientes[index].Cuit = cli.Cuit;
            ListadosReq.ListadoClientes[index].Domicilio= cli.Domicilio;
            ListadosReq.ListadoClientes[index].Provincia=cli.Provincia;
        }

        public ClienteResponse UpdateCliente(ClienteReq obj)
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            //var existeCliente = _context.Cliente.Where(x => x.Cuit == objCliente.Cuit).FirstOrDefault();
            var existeCliente = GetClienteCuit(obj.Cuit);
            
            
            
            if (existeCliente != null)
            {
                try
                {
                    existeCliente.Apellido = obj.Apellido != null ? obj.Apellido : existeCliente.Apellido;
                    existeCliente.RazonSocial = obj.RazonSocial != null ? obj.RazonSocial : existeCliente.RazonSocial;
                    existeCliente.Nombre = obj.Nombre != null ? obj.Nombre : existeCliente.Nombre;
                    existeCliente.Cuit = obj.Cuit != null ? obj.Cuit : existeCliente.Cuit;
                    existeCliente.Domicilio = obj.Domicilio != null ? obj.Domicilio : existeCliente.Domicilio;
                    existeCliente.Localidad = obj.Localidad != null ? obj.Localidad : existeCliente.Localidad;
                    existeCliente.Telefono = obj.Telefono != null ? obj.Telefono : existeCliente.Telefono;
                    existeCliente.Provincia = obj.Provincia != null ? obj.Provincia : existeCliente.Provincia;
                    existeCliente.IdUsuario = obj.IdUsuario != null ? obj.IdUsuario : existeCliente.IdUsuario;


                    _context.Update(existeCliente);
                    _context.SaveChanges();
                    clienteResponse.Guardar = true;
                    clienteResponse.RazonSocial = existeCliente.RazonSocial;
                }
                catch (Exception ex) 
                {
                    clienteResponse.Mensaje = "Error al modificar Cliente";
                    clienteResponse.Guardar = false;
                }
                
            }
            return clienteResponse;
        }

        public ClienteResponse Delete(ClienteReq objCliente)
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            //var existeCliente = _context.Cliente.Where(x => x.Cuit == objCliente.Cuit).FirstOrDefault();
            var existeCliente = GetClienteCuit(objCliente.Cuit);



            if (existeCliente == null)
            {
                try
                {
                    existeCliente.Estado = false;
                    existeCliente.FechaBaja = DateTime.Now;
                    existeCliente.RazonSocial = objCliente.RazonSocial;
                    //agregar
                    _context.Update(objCliente);
                    _context.SaveChanges();
                    clienteResponse.Guardar = true;
                    clienteResponse.RazonSocial = existeCliente.RazonSocial;
                }
                catch (Exception ex)
                {
                    clienteResponse.Mensaje = "Error al eliminar Cliente";
                    clienteResponse.Guardar = false;
                }

            }
            return clienteResponse;
        }

        public Cliente GetClienteCuit(string cuit)
        {
            var cliente = _context.Cliente.Where(x => x.Cuit == cuit).FirstOrDefault();
            return cliente;
        }

        public List<ClienteReq> GetClientes()
        {
            List<ClienteReq> listadoClientes = new List<ClienteReq>();
            var lista = _context.Cliente.Where(x=>x.Estado !=false).ToList();

            foreach(var item in lista)
            {
                ClienteReq clienteReq = new ClienteReq();
                clienteReq.Nombre = item.Nombre;
                clienteReq.Apellido=item.Apellido;
                clienteReq.IdCliente = item.IdCliente;
                clienteReq.Domicilio = item.Domicilio;
                clienteReq.Cuit = item.Cuit;
                clienteReq.RazonSocial = item.RazonSocial;
                clienteReq.Localidad = item.Localidad;
                clienteReq.Provincia = item.Provincia;
                clienteReq.FechaBaja=item.FechaBaja;

                listadoClientes.Add(clienteReq);
            }

            return listadoClientes;
        }
        public Cliente ValidarCliente(ClienteReq obj)
        {
            Cliente cliente = new Cliente()
            {
                Apellido = obj.Apellido != null ? obj.Apellido : string.Empty,
                RazonSocial = obj.RazonSocial != null ? obj.RazonSocial : string.Empty,
                Nombre = obj.Nombre != null ? obj.Nombre : string.Empty,
                Cuit = obj.Cuit != null ? obj.Cuit : string.Empty,
                Domicilio = obj.Domicilio != null ? obj.Domicilio : string.Empty,
                Localidad = obj.Localidad != null ? obj.Localidad : string.Empty,
                Telefono = obj.Telefono != null ? obj.Telefono : string.Empty,
                Provincia = obj.Provincia != null ? obj.Provincia : string.Empty,
                FechaAlta = obj.FechaAlta != null ? obj.FechaAlta : DateTime.Now,
                FechaBaja = obj.FechaBaja,
                Estado = obj.Estado != null ? obj.Estado : true,
                IdCliente = obj.IdCliente,
                IdUsuario = obj.IdUsuario != null ? obj.IdUsuario : 0
            };
            return cliente;


        }

    }
}
