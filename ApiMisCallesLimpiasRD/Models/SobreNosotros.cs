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
  public class SobreNosotros : Conexion
  {
    public List<Models.Entidad.ESobreNosotros> lista_datos_sobre_nosotros()
    {
      List<Models.Entidad.ESobreNosotros> lista_datos_sobre_nosotros = new List<Models.Entidad.ESobreNosotros>();

      DataTable dt = new DataTable();
      MySqlCommand cmd = new MySqlCommand("db_a26410_micalle.SListaDeDatosSobreNosotros(); ", GetCon()); 
      MySqlDataAdapter da = new MySqlDataAdapter();
      da.SelectCommand = cmd;
      da.Fill(dt);

      if (dt.Rows.Count > 0)
      {
        var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
        lista_datos_sobre_nosotros = JsonConvert.DeserializeObject<List<Models.Entidad.ESobreNosotros>>(result, new JsonSerializerSettings()
        {
          NullValueHandling = NullValueHandling.Ignore
        });
      }

      return lista_datos_sobre_nosotros;
    }
  }
}
