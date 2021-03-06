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

        public List<Models.Entidad.Epost> lista_de_post( int cod_ayuntamiento)
        {
            List<Models.Entidad.Epost> lista_de_post = new List<Models.Entidad.Epost>();

            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("SListaDePost", GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("prm_cod_ayuntamiento", MySqlDbType.Int32).Value = cod_ayuntamiento;
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

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
