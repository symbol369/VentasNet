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
    public interface IProductoRepo
    {
        public ProductoResponse AgregarProducto(ProductoReq objProducto);
        public ProductoResponse Delete(ProductoReq prod);
        public Producto GetProductoCodigo(int Codigo);
        public List<ProductoReq> GetProductos();
        public ProductoResponse UpdateProducto(ProductoReq prod);
    }
}
