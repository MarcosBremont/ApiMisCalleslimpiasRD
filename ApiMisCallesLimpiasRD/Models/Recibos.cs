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
    public class Recibos : Conexion
    {
        public List<Models.Entidad.ERecibos > lista_de_recibos(int cod_recibo)
        {
            List<Models.Entidad.ERecibos> lista_de_recibos = new List<Models.Entidad.ERecibos>();
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand("MostrarRecibos", GetCon());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("prm_cod_usuario_recibo", MySqlDbType.Int32).Value = cod_recibo;
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_de_recibos = JsonConvert.DeserializeObject<List<Models.Entidad.ERecibos>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return lista_de_recibos;
        }
    }
}
