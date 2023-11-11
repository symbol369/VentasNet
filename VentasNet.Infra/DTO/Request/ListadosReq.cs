using VentasNet.Infra.DTO.Request;

namespace VentasNet.Models
{
    public static class ListadosReq
    {
        public static List<ClienteReq> ListadoClientes { get; set; } = new List<ClienteReq>();
        public static List<ProveedorReq> ListadoProveedores { get; set; } = new List<ProveedorReq>();
        public static List<ProductoReq> ListadoProductos { get; set; } = new List<ProductoReq>();
        public static List<UsuarioReq> ListadoUsuarios { get; set; } = new List<UsuarioReq>();
    }
}
