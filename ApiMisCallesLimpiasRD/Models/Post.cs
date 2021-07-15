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
    public class Post : Conexion
    {
        public List<Models.Entidad.Epost> lista_de_post()
        {
            List<Models.Entidad.Epost> lista_de_post = new List<Models.Entidad.Epost>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SListaDePost", GetCon());
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_de_post = JsonConvert.DeserializeObject<List<Models.Entidad.Epost>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_de_post;
        }
    }
}
