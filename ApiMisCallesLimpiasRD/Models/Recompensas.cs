using MySql.Data.MySqlClient;
using ApiMisCallesLimpiasRD.Models.Entidad;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Models
{
    public class Recompensas : Conexion
    {
        public List<Models.Entidad.Erecompensas> lista_recompensas()
        {
            List<Models.Entidad.Erecompensas> lista_recompensas = new List<Models.Entidad.Erecompensas>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SListaRecompensas", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_recompensas = JsonConvert.DeserializeObject<List<Models.Entidad.Erecompensas>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_recompensas;
        }
    }
}
