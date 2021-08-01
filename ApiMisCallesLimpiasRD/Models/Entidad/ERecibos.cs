using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Models.Entidad
{
    public class ERecibos
    {
        public int cod_recibo { get; set; } = 0;
        public int cod_usuario { get; set; } = 0;
        public int cod_recompensa { get; set; } = 0;
        public string estado { get; set; } = "";
        public string fecha { get; set; } = "";
        public string respuesta { get; set; }
        public string mensaje { get; set; }
    }
}
