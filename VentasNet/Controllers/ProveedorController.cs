

using Microsoft.AspNetCore.Mvc;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Repositories;

namespace Venta.NET.Controllers
{
    public class ProveedorController : Controller
    {


        IProveedorRepo proveedorRepo;

        public ProveedorController(IProveedorRepo _proveedorRepo)
        {
            proveedorRepo = _proveedorRepo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AgregarProveedor(ProveedorReq proveedor)
        {
            var proveedorResponse = proveedorRepo.AgregarProveedor(proveedor);

            if (proveedorResponse.Guardar)
            {
                return RedirectToAction("ListadoProveedores");
            }

            return View();
        }

        public IActionResult ModificarProveedor(ProveedorReq proveedor)
        {
            ViewBag.Cliente = proveedorRepo.GetProveedorCuit(proveedor.Cuit);

            return View();
        }
        public IActionResult Editar(ProveedorReq proveedor)
        {
            var proveedorResponse = proveedorRepo.UpdateProveedor(proveedor);

            return RedirectToAction("ListadoProveedores", proveedorResponse);
        }

        public IActionResult ListadoProveedores()
        {
            ViewBag.Proveedores = proveedorRepo.ListadoProveedores();

            return View();
        }

        public IActionResult Delete(ProveedorReq proveedor)
        {
            var result = proveedorRepo.Delete(proveedor);

            return RedirectToAction("ListadoProveedores");
        }
    }
}
