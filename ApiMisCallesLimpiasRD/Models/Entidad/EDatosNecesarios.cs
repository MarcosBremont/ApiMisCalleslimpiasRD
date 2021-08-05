using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Models.Entidad
{
  public class EDatosNecesarios
  {
    public int cod_usuario { get; set; } = 0;
    public string usuario { get; set; } = "";
    public string correo_Usuario { get; set; } = "";
    public string cedula_usuario { get; set; } = "";
    public string clave { get; set; } = "";
    public string telefono_Usuario { get; set; } = "";
    public int cod_nivel { get; set; } = 0;

        public float puntosacumulados { get; set; } = 0;
        public int cantidadreportes { get; set; } = 0;
        public int reportesenespera { get; set; } = 0;
        public int cantidadrecibo { get; set; } = 0;

    }
}
