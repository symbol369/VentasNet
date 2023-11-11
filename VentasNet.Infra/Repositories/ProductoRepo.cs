



using VentasNet.Entity.Data;
using VentasNet.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;

namespace VentasNet.Infra.Repositories
{
    public class ProductoRepo : IProductoRepo
    {
        private readonly VentasNetContext _context;
        public ProductoRepo(VentasNetContext context)
        {
            _context = context;


        }

        public ProductoResponse AgregarProducto(ProductoReq prod)
        {


            ProductoResponse productoResponse = new ProductoResponse();


            if (prod.CodigoProducto != null)
            {
                var existeProducto = GetProductoCodigo(prod.CodigoProducto);


                if (existeProducto == null)
                {
                    try
                    {
                        var productoNew = MapeoProductoNuevo(prod);

                        productoNew.Estado = true;


                        _context.Add(productoNew);
                        _context.SaveChanges();
                        productoResponse.Guardar = true;
                        productoResponse.Nombre = productoNew.NombreProducto;

                    }
                    catch (Exception ex)
                    {
                        productoResponse.Mensaje = "Error al agregar Producto.";
                    }

                }
            }
            return productoResponse;



        }

        public ProductoResponse UpdateProducto(ProductoReq prod)
        {
            ProductoResponse productoResponse = new ProductoResponse();

            var existeProducto = GetProductoCodigo(prod.CodigoProducto);

            if (existeProducto != null)
            {
                try
                {
                    var productoUp = MapeoProducto(prod, existeProducto);


                    _context.Update(productoUp);
                    _context.SaveChanges();
                    productoResponse.Guardar = true;
                    productoResponse.Nombre = productoUp.NombreProducto;
                }
                catch (Exception ex)
                {
                    productoResponse.Mensaje = "Error al modificar Cliente.";
                    productoResponse.Guardar = false;
                }

            }

            return productoResponse;
        }

        public ProductoResponse Delete(ProductoReq prod)
        {
            ProductoResponse productoResponse = new ProductoResponse();

            var existeProducto = GetProductoCodigo(prod.CodigoProducto);

            if (existeProducto != null)
            {
                try
                {

                    existeProducto.Estado = false;

                    _context.Update(existeProducto);
                    _context.SaveChanges();

                }
                catch (Exception ex)
                {
                    productoResponse.Mensaje = "Error al eliminar Cliente.";
                    productoResponse.Guardar = false;
                }

            }

            return productoResponse;
        }

        public List<ProductoReq> GetProductos()
        {
            List<ProductoReq> listadoProductos = new List<ProductoReq>();

            var lista = _context.Producto.Where(x => x.Estado == true).ToList();

            foreach (var item in lista)
            {
                ProductoReq productoReq = new ProductoReq();

                productoReq.IdProducto = item.IdProducto;
                productoReq.NombreProducto = item.NombreProducto;
                productoReq.Descripcion = item.Descripcion;
                productoReq.CodigoProducto = item.CodigoProducto;
                productoReq.ImporteProducto = item.ImporteProducto;
                productoReq.Estado = item.Estado;
                productoReq.FechaAlta=item.FechaAlta;



        listadoProductos.Add(productoReq);
            }

            return listadoProductos;
        }


        public Producto GetProductoCodigo(int codigo)
        {
            var producto = _context.Producto.Where(x => x.CodigoProducto == codigo).FirstOrDefault();

            return producto;
        }


        public Producto MapeoProducto(ProductoReq prod, Producto existeProducto)
        {
            existeProducto.NombreProducto = prod.NombreProducto != null ? prod.NombreProducto : existeProducto.NombreProducto;
            existeProducto.Descripcion = prod.Descripcion != null ? prod.Descripcion : existeProducto.Descripcion;
            existeProducto.ImporteProducto = prod.ImporteProducto != null ? prod.ImporteProducto : existeProducto.ImporteProducto;
            existeProducto.CodigoProducto = prod.CodigoProducto != null ? prod.CodigoProducto : existeProducto.CodigoProducto;
            existeProducto.IdProducto = prod.IdProducto != null ? prod.IdProducto : existeProducto.IdProducto;




            return existeProducto;
        }

        public Producto MapeoProductoNuevo(ProductoReq prod)
        {
            Producto prodMapeado = new Producto()
            {
                NombreProducto = prod.NombreProducto,
                CodigoProducto = prod.CodigoProducto,
                Descripcion = prod.Descripcion,
                ImporteProducto = prod.ImporteProducto,
                IdProducto = prod.IdProducto,
                Estado = prod.Estado

            };

            return prodMapeado;
        }
    }
}
