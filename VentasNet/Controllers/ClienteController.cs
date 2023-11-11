using Microsoft.AspNetCore.Mvc;
using VentasNet.Models;
using VentasNet.Infra.Repositories;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;

namespace VentasNet.Controllers
{
    public class ClienteController : Controller
    {
        IClienteRepo clienteRepo;

        public ClienteController(IClienteRepo _clienteRepo)
        {
            clienteRepo = _clienteRepo;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListadoClientes()
        {
            ViewBag.Cliente = clienteRepo.GetClientes();

            return View();
        }


        public IActionResult AgregarCliente (ClienteReq cli)
        {
            var clienteResponse = clienteRepo.AgregarCliente(cli);
            if (clienteResponse.Guardar)
            {
                return RedirectToAction("ListadoClientes");
            }


            return View();
        }
        public IActionResult UpdateCliente(ClienteReq cli)
        {
            var clienteResponse = clienteRepo.UpdateCliente(cli);



            return RedirectToAction("ListadoClientes");
        }
        public IActionResult ModificarCliente (ClienteReq cli)
        {
            var cliente = clienteRepo.GetClienteCuit(cli.Cuit);


            return RedirectToPage("ModificarCliente",cliente);
        }
        public IActionResult Delete(ClienteReq cli)
        {
            var clienteResponse = clienteRepo.Delete(cli);

            return RedirectToAction("ListadoClientes");
        }
    }
}
