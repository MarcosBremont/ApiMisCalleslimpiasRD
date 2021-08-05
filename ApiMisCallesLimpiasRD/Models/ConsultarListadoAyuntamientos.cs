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
  public class ConsultarListadoAyuntamientos : Conexion
  {
    

    public List<Models.Entidad.EAyuntamientos> lista_de_ayuntamientos()
    {

      List<Models.Entidad.EAyuntamientos> lista_de_ayuntamientos = new List<Models.Entidad.EAyuntamientos>();

      DataTable dt = new DataTable();
      MySqlCommand cmd = new MySqlCommand("SlistaAyuntamientos", GetCon());
      MySqlDataAdapter da = new MySqlDataAdapter();
      da.SelectCommand = cmd;

      da.SelectCommand.CommandType = CommandType.StoredProcedure;
      da.Fill(dt);
      if (dt.Rows.Count > 0)
      {
        var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_de_ayuntamientos = JsonConvert.DeserializeObject<List<Models.Entidad.EAyuntamientos>>(result, new JsonSerializerSettings()
        {
          NullValueHandling = NullValueHandling.Ignore
        });
      }
      return lista_de_ayuntamientos;
    }

  }
}
