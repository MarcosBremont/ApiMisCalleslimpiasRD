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
  public class ConsultarNivelUsuario : Conexion
  {
    

    public List<Models.Entidad.EConsultarNivelUsuario> listado_nivel_usuario(int cod_usuario)
    {

      List<Models.Entidad.EConsultarNivelUsuario> listado_nivel_usuario = new List<Models.Entidad.EConsultarNivelUsuario>();

      DataTable dt = new DataTable();
      MySqlDataAdapter da = new MySqlDataAdapter("NivelUsuario", GetCon());
      da.SelectCommand.CommandType = CommandType.StoredProcedure;
      da.SelectCommand.Parameters.Add("prm_cod_usuario_nivel", MySqlDbType.Int32).Value = cod_usuario;
      da.Fill(dt);


      if (dt.Rows.Count > 0)
      {
        var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
        listado_nivel_usuario = JsonConvert.DeserializeObject<List<Models.Entidad.EConsultarNivelUsuario>>(result, new JsonSerializerSettings()
        {
          NullValueHandling = NullValueHandling.Ignore
        });
      }
      return listado_nivel_usuario;
    }

  }
}
