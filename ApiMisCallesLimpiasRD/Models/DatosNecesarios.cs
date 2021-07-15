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
  public class DatosNecesarios : Conexion
  {
    //public List<Models.Entidad.EDatosNecesarios> lista_de_datos_necesarios(string usuario)
    //{
    //  List<Models.Entidad.EDatosNecesarios> lista_de_datos_necesarios = new List<Models.Entidad.EDatosNecesarios>();

    //  DataTable dt = new DataTable();
    //  MySqlCommand cmd = new MySqlCommand("SListaDatosNecesarios", GetCon());
    //  cmd.Parameters.Add("prm_usuario", MySqlDbType.Text).Value = usuario;
    //  MySqlDataAdapter da = new MySqlDataAdapter();
    //  da.SelectCommand = cmd;
    //  da.Fill(dt);

    //  if (dt.Rows.Count > 0)
    //  {
    //    var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
    //    lista_de_datos_necesarios = JsonConvert.DeserializeObject<List<Models.Entidad.EDatosNecesarios>>(result, new JsonSerializerSettings()
    //    {
    //      NullValueHandling = NullValueHandling.Ignore
    //    });
    //  }

    //  return lista_de_datos_necesarios;
    //}

    public List<Models.Entidad.EDatosNecesarios> lista_de_datos_necesarios(string usuario)
    {

      List<Models.Entidad.EDatosNecesarios> lista_de_datos_necesarios = new List<Models.Entidad.EDatosNecesarios>();

      DataTable dt = new DataTable();
      MySqlDataAdapter da = new MySqlDataAdapter("SListaDatosNecesarios", GetCon());
      da.SelectCommand.CommandType = CommandType.StoredProcedure;
      da.SelectCommand.Parameters.Add("prm_usuario", MySqlDbType.VarChar).Value = usuario;
      da.Fill(dt);
      if (dt.Rows.Count > 0)
      {
        var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
        lista_de_datos_necesarios = JsonConvert.DeserializeObject<List<Models.Entidad.EDatosNecesarios>>(result, new JsonSerializerSettings()
        {
          NullValueHandling = NullValueHandling.Ignore
        });
      }
      return lista_de_datos_necesarios;
    }

  }
}
