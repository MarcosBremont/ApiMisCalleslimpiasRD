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
    public class ConsultarReciboEmpresas : Conexion
    {


        public List<Models.Entidad.EConsultarRecibos> listado_de_recibos_Empresas(int cod_ayuntamiento)
        {

            List<Models.Entidad.EConsultarRecibos> listado_de_recibos_por_empresas = new List<Models.Entidad.EConsultarRecibos>();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("MostrarRecibosEmpresas", GetCon());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("prm_cod_ayuntamiento", MySqlDbType.Int32).Value = cod_ayuntamiento;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                listado_de_recibos_por_empresas = JsonConvert.DeserializeObject<List<Models.Entidad.EConsultarRecibos>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            return listado_de_recibos_por_empresas;
        }

    }
}
