using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Models.Entidad
{
  public class EMensajes
    {
   public int cod_mensaje { get; set; } = 0;
   public int cod_usuario { get; set; } = 0;
    public string mensajes { get; set; } = "";
    public int estado { get; set; } = 0;
    public string fecha { get; set; } = "" ;
        public string respuesta { get; set; }
        public string mensaje { get; set; }

    }
}
