using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Models.Entidad
{
  public class EConsultarNivelUsuario
  {

    public int cod_usuario { get; set; } = 0;
    public int cod_nivel { get; set; } = 0;
    public string respuesta { get; set; }
    public string mensaje { get; set; }
  }
}
