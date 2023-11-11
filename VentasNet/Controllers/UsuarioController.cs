using Microsoft.AspNetCore.Mvc;
using VentasNet.Models;
using VentasNet.Infra.Repositories;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.DTO.Common;

namespace VentasNet.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioRepo usuarioRepo;

        public UsuarioController(IUsuarioRepo _usuarioRepo)
        {
            usuarioRepo = _usuarioRepo;
        }


        public IActionResult Index()
        {
            return View();                                                                                                                                                                                               
        }
    
        public IActionResult Inicio(UsuarioReq user) 
        {
            return View(user);
        }
        public IActionResult AgregarUsuario(UsuarioReq user)
        {

            var usuarioResponse = usuarioRepo.AddUsuario(user);

            if (usuarioResponse.Guardar)
            {
                return RedirectToAction("ListadoUsuarios");
            }

            return View();
        }
        public IActionResult Edit(UsuarioReq objUsuario)
        {

            var usuarioResponse = usuarioRepo.UpdateUsuario(objUsuario);

            return RedirectToAction("ListadoUsuarios", usuarioResponse);
        }
        public IActionResult ModificarUsuario(UsuarioReq usuario)
        {
            ViewBag.Usuario = usuarioRepo.GetUsuarioCuit(usuario.Cuit);

            return View();
        }

        public IActionResult Delete(UsuarioReq objUsuario)
        {
            var usuarioResponse = usuarioRepo.Delete(objUsuario);

            return RedirectToAction("ListadoUsuarios");
        }
        public IActionResult ListadoUsuarios()
        {
            ViewBag.Usuario = usuarioRepo.GetUsuarios();

            return View();
        }

        public IActionResult IngresoUsuario(string usuario, string clave)
        {

            var usuarioResponse = usuarioRepo.ValidarUsuario(usuario, clave);

            if (usuarioResponse.login)
            {
                return RedirectToAction("ListadoUsuarios");
            }




            return RedirectToAction("Inicio");
        }


    }
}
