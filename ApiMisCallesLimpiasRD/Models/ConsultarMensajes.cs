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
  public class ConsultarMensajes : Conexion
  {
    

    public List<Models.Entidad.EMensajes> listado_mensjaes(int cod_usuario)
    {

      List<Models.Entidad.EMensajes> listado_de_mensajes = new List<Models.Entidad.EMensajes>();

      DataTable dt = new DataTable();
      MySqlCommand cmd = new MySqlCommand("MostrarDatosMensajeria", GetCon());
      MySqlDataAdapter da = new MySqlDataAdapter();
      da.SelectCommand = cmd;

      da.SelectCommand.CommandType = CommandType.StoredProcedure;
      da.SelectCommand.Parameters.Add("prm_cod_usuario", MySqlDbType.Int32).Value = cod_usuario;
      da.Fill(dt);
      if (dt.Rows.Count > 0)
      {
        var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
        listado_de_mensajes = JsonConvert.DeserializeObject<List<Models.Entidad.EMensajes>>(result, new JsonSerializerSettings()
        {
          NullValueHandling = NullValueHandling.Ignore
        });
      }
      return listado_de_mensajes;
    }

  }
}
