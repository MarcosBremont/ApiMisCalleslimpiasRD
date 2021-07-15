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
  public class ConsultarRecibo : Conexion
  {
    

    public List<Models.Entidad.EConsultarRecibos> listado_de_recibos(int cod_usuario)
    {

      List<Models.Entidad.EConsultarRecibos> listado_de_recibos = new List<Models.Entidad.EConsultarRecibos>();

      DataTable dt = new DataTable();
      MySqlCommand cmd = new MySqlCommand("MostrarRecibos", GetCon());
      MySqlDataAdapter da = new MySqlDataAdapter();
      da.SelectCommand = cmd;

      da.SelectCommand.CommandType = CommandType.StoredProcedure;
      da.SelectCommand.Parameters.Add("prm_cod_usuario_recibo", MySqlDbType.Int32).Value = cod_usuario;
      da.Fill(dt);
      if (dt.Rows.Count > 0)
      {
        var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
        listado_de_recibos = JsonConvert.DeserializeObject<List<Models.Entidad.EConsultarRecibos>>(result, new JsonSerializerSettings()
        {
          NullValueHandling = NullValueHandling.Ignore
        });
      }
      return listado_de_recibos;
    }

  }
}
