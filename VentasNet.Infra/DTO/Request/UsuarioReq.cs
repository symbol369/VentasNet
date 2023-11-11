using System.ComponentModel;
using System.Globalization;

namespace VentasNet.Infra.DTO.Request
{
    public class UsuarioReq
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Cuit { get; set; }
        public bool Estado { get; set; }
        public int? IdTipoUsuario { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public bool? Login { get; set; }
    }
}
