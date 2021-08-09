using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Models.Entidad
{
  public class EDatosNecesariosAyuntamientos
  {
    public int cod_usuario { get; set; } = 0;
    public string usuario { get; set; } = "";
    public string correo_Usuario { get; set; } = "";
    public string Rnc_usuario { get; set; } = "";
    public string clave { get; set; } = "";
    public string telefono_Usuario { get; set; } = "";
    public int cod_nivel { get; set; } = 0;
    public int cod_ayuntamiento { get; set; } = 0;


    }
}
