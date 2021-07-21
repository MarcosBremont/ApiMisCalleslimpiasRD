using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Models.Entidad
{
    public class EusuarioEmpresa
    {
        public int cod_usuario { get; set; } = 0;
        public string usuario { get; set; } = "";
        public string correo_Usuario { get; set; } = "";
        public string rnc_usuario { get; set; } = "";
        public string clave { get; set; } = "";
        public string telefono_Usuario { get; set; } = "";
        public string respuesta { get; set; }
        public string mensaje { get; set; }
        public int estado { get; set; } = 1;
  }
}
