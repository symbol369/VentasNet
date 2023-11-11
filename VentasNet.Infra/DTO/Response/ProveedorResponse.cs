using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Infra.DTO.Common;

namespace VentasNet.Infra.DTO.Response
{
    public class ProveedorResponse : Mensajes
    {
        public string RazonSocial { get; set; }

        public bool Guardar { get; set; } = false;

    }
}
