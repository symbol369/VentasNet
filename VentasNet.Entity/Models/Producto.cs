﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace VentasNet.Entity.Models
{
    public partial class Producto
    {
        public int IdProducto { get; set; }
        public int? IdProveedor { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string ImporteProducto { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdUsuario { get; set; }
        public int CodigoProducto { get; set; }
    }
}