using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Models.Entidad
{
    public class EConsultarRecibos
    {
        public int cod_recibo { get; set; } = 0;
        public int cod_usuario { get; set; } = 0;
        public int cod_recompensa { get; set; } = 0;
        public string fecha { get; set; } = "";
        public string imagen { get; set; } = "";
        public string nombre { get; set; } = "";
        public string respuesta { get; set; }
        public string mensaje { get; set; }

        public string fechaCompleta { get; set; }
        public int cod_usuarioreporte { get; set; } = 0;
        public string usuario { get; set; } = "";
        public string correo_Usuario { get; set; } = "";
        public string cedula_usuario { get; set; } = "";
        public string clave { get; set; } = "";
        public string telefono_Usuario { get; set; } = "";



    }
}
