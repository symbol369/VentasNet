﻿using System.ComponentModel;

namespace VentasNet.Infra.DTO.Request
{
    public class ProveedorReq
    {
        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string Domicilio { get; set; }
        public string? Localidad { get; set; }
        public string? Provincia { get; set; }
        public string? Telefono { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdProducto { get; set; }
        public int? IdUsuario { get; set; }
        public string Email { get; set; } 
    }
}
