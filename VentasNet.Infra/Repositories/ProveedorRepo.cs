
using VentasNet.Infra.Repositories;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;
using VentasNet.Entity.Data;
using VentasNet.Infra.DTO.Response;
using VentasNet.Entity.Models;

namespace VentasNet.Infra.Repositories
{
    public class ProveedorRepo : IProveedorRepo
    {
        private readonly VentasNetContext _context;

        public ProveedorRepo(VentasNetContext context)
        {
            _context = context;


        }


        public ProveedorResponse AgregarProveedor(ProveedorReq proveedor)
        {
            ProveedorResponse proveedorResponse = new ProveedorResponse();

            if (proveedor.Cuit != null)
            {
                var existeProveedor = GetProveedorCuit(proveedor.Cuit);


                if (existeProveedor == null)
                {
                    try
                    {
                        var proveedorNew = MapeoProveedorNuevo(proveedor);

                        proveedorNew.Estado = true;
                        proveedorNew.FechaAlta = DateTime.Now.Date;

                        _context.Add(proveedorNew);
                        _context.SaveChanges();
                        proveedorResponse.Guardar = true;
                        proveedorResponse.RazonSocial = proveedorNew.RazonSocial;

                    }
                    catch (Exception ex)
                    {
                        proveedorResponse.Mensaje = "Error al agregar Cliente.";
                        proveedorResponse.Guardar = false;
                    }

                }
            }


            return proveedorResponse;
        }

        public ProveedorResponse UpdateProveedor(ProveedorReq proveedor)
        {
            ProveedorResponse proveedorResponse = new ProveedorResponse();

            var existeProveedor = GetProveedorCuit(proveedor.Cuit);

            if (existeProveedor != null)
            {
                try
                {
                    var proveedorUp = MapeoProveedor(proveedor, existeProveedor);


                    _context.Update(proveedorUp);
                    _context.SaveChanges();
                    proveedorResponse.Guardar = true;
                    proveedorResponse.RazonSocial = proveedorUp.RazonSocial;
                }
                catch (Exception ex)
                {
                    proveedorResponse.Mensaje = "Error al modificar Cliente.";
                    proveedorResponse.Guardar = false;
                }

            }

            return proveedorResponse;
        }

        public List<ProveedorReq> ListadoProveedores()
        {
            List<ProveedorReq> listadoProveedores = new List<ProveedorReq>();

            var lista = _context.Proveedor.Where(x => x.Estado == true).ToList();

            foreach (var item in lista)
            {
                ProveedorReq proveedoreReq = new ProveedorReq();

                proveedoreReq.IdProveedor = item.IdProveedor;
                proveedoreReq.RazonSocial = item.RazonSocial;
                proveedoreReq.Cuit = item.Cuit;
                proveedoreReq.Email = item.Email;
                proveedoreReq.Telefono = item.Telefono;
                proveedoreReq.Domicilio = item.Domicilio;
                proveedoreReq.Estado = item.Estado;
                proveedoreReq.FechaBaja = item.FechaBaja;

                listadoProveedores.Add(proveedoreReq);
            }

            return listadoProveedores;
        }

        public ProveedorResponse Delete(ProveedorReq proveedor)
        {
            ProveedorResponse proveedorResponse = new ProveedorResponse();

            var existeProveedor = GetProveedorCuit(proveedor.Cuit);

            if (existeProveedor != null)
            {
                try
                {
                    existeProveedor.FechaBaja = DateTime.Now.Date;
                    existeProveedor.Estado = false;

                    _context.Update(existeProveedor);
                    _context.SaveChanges();

                }
                catch (Exception ex)
                {
                    proveedorResponse.Mensaje = "Error al eliminar Proveedor.";
                    proveedorResponse.Guardar = false;
                }

            }

            return proveedorResponse;
        }

        public Proveedor MapeoProveedorNuevo(ProveedorReq proveedor)
        {
            Proveedor proveedorMapeado = new Proveedor()
            {

                RazonSocial = proveedor.RazonSocial,
                Cuit = proveedor.Cuit,
                Email = proveedor.Email,
                Telefono = proveedor.Telefono,
                Domicilio = proveedor.Domicilio

            };

            return proveedorMapeado;
        }

        public Proveedor MapeoProveedor(ProveedorReq proveedor, Proveedor existeProveedor)
        {
            existeProveedor.RazonSocial = proveedor.RazonSocial != null ? proveedor.RazonSocial : existeProveedor.RazonSocial;
            existeProveedor.Cuit = proveedor.Cuit != null ? proveedor.Cuit : existeProveedor.Cuit;
            existeProveedor.Domicilio = proveedor.Domicilio != null ? proveedor.Domicilio : existeProveedor.Domicilio;
            existeProveedor.Email = proveedor.Email != null ? proveedor.Email : existeProveedor.Email;
            existeProveedor.Telefono = proveedor.Telefono != null ? proveedor.Telefono : existeProveedor.Telefono;




            return existeProveedor;
        }

        public Proveedor GetProveedorCuit(string cuit)
        {
            var proveedor = _context.Proveedor.Where(x => x.Cuit == cuit).FirstOrDefault();

            return proveedor;
        }




    }
}