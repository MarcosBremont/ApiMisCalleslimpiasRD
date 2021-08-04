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
  public class DatosUsuariosPorCodigo : Conexion
  {
    

    public List<Models.Entidad.Eusuario> listado_usuarios(int cod_usuario)
    {

      List<Models.Entidad.Eusuario> listado_usuarios = new List<Models.Entidad.Eusuario>();

      DataTable dt = new DataTable();
      MySqlCommand cmd = new MySqlCommand("DatosUsuarios", GetCon());
      MySqlDataAdapter da = new MySqlDataAdapter();
      da.SelectCommand = cmd;

      da.SelectCommand.CommandType = CommandType.StoredProcedure;
      da.SelectCommand.Parameters.Add("prm_cod_usuario", MySqlDbType.Int32).Value = cod_usuario;
      da.Fill(dt);
      if (dt.Rows.Count > 0)
      {
        var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
        listado_usuarios = JsonConvert.DeserializeObject<List<Models.Entidad.Eusuario>>(result, new JsonSerializerSettings()
        {
          NullValueHandling = NullValueHandling.Ignore
        });
      }
      return listado_usuarios;
    }

  }
}
