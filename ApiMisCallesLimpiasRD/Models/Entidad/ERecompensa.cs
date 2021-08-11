using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Models.Entidad
{
  public class ERecompensa
    {
        public int cod_recompensa { get; set; } = 0;
        public int puntos { get; set; } = 0;
        public string nombre { get; set; } = "";
        public string descripcion { get; set; } = "";
        public string imagen { get; set; } = "";
        public string fecha { get; set; } = "";
        public string estado { get; set; } = "";
        public int existencia { get; set; } = 0;
        public int cod_ayuntamiento { get; set; } = 0;
        public string respuesta { get; set; }
        public string mensaje { get; set; }
    }
}
