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
    public interface IUsuarioRepo
    {
        public UsuarioResponse AddUsuario(UsuarioReq objUsuario);
        public UsuarioResponse UpdateUsuario(UsuarioReq objUsuario);
        public List<UsuarioReq> GetUsuarios();
        public UsuarioResponse Delete(UsuarioReq objUsuario);
        public Usuario GetUsuarioCuit(string cuit);
        public UsuarioResponse ValidarUsuario(string user, string pass);
    }
}
