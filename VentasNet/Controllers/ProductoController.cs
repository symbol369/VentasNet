using Microsoft.AspNetCore.Mvc;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Repositories;

namespace Venta.NET.Controllers
{
    public class ProductoController : Controller
    {
        IProductoRepo productoRepo;

        public ProductoController(IProductoRepo _productoRepo)
        {
            productoRepo = _productoRepo;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AgregarProducto(ProductoReq prod)
        {
            var productoResponse = productoRepo.AgregarProducto(prod);

            if (productoResponse.Guardar)
            {
                return RedirectToAction("ListadoProductos");
            }

            return View();
        }

        public IActionResult ModificarProducto(ProductoReq prod)
        {
            ViewBag.Producto = productoRepo.GetProductoCodigo(prod.CodigoProducto);

            return View();
        }

        public IActionResult Editar(ProductoReq prod)
        {

            var productoResponse = productoRepo.UpdateProducto(prod);

            return RedirectToAction("ListadoProductos", productoResponse);
        }

        public IActionResult Delete(ProductoReq prod)
        {
            var result = productoRepo.Delete(prod);

            return RedirectToAction("ListadoProductos");
        }
        public IActionResult ListadoProductos(ProductoReq prod)
        {
            ViewBag.Producto = productoRepo.GetProductos();
            return View();
        }


    }
}