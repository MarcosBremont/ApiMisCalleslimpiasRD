using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Models.Entidad
{
  public class Emisreportes
  {
        public int cod_reporte { get; set; } = 0;
        public string ubicacion { get; set; } = "";
        public string lat { get; set; } = "";
        public string lng { get; set; } = "";
        public string fotos { get; set; } = "";
        public int cod_usuario { get; set; } = 0;
        public int cod_ayuntamiento { get; set; } = 0;
        public string usuario { get; set; } = "";
        public string correo_Usuario { get; set; } = "";
        public string cedula_usuario { get; set; } = ""; 
        public string telefono_Usuario { get; set; } = "";
        public string respuesta { get; set; }
     public string mensaje { get; set; }
  }
}
