using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Models.Entidad
{
    public class Epost
    {
        public int cod_post { get; set; } = 0;
        public string titulo { get; set; } = "";
        public string descripcion { get; set; } = "";
        public string imagen { get; set; } = "";
        public string fecha { get; set; } = "";
    }
}
