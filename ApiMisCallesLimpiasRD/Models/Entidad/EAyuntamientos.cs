using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Models.Entidad
{
    public class EAyuntamientos
    {
        public int cod_ayuntamiento { get; set; } = 0;
        public string nombre { get; set; } = "";
        public string comentario { get; set; } = "";
        public int estado { get; set; } = 0;
        public string fecha { get; set; } = "";
        public string respuesta { get; set; }
        public string mensaje { get; set; }
    }
}
