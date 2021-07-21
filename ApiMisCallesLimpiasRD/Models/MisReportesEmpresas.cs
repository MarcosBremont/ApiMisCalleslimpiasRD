using ApiMisCallesLimpiasRD.Models.Entidad;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Models
{
  public class MisReportesEmpresas : Conexion
  {
    //MetodoControl metodoControl = new MetodoControl();
    public List<Models.Entidad.Emisreportes> lista_de_misreportes_Empresas()
    {
      List<Models.Entidad.Emisreportes> lista_de_misreportes_Empresas = new List<Models.Entidad.Emisreportes>();

      DataTable dt = new DataTable();
      MySqlCommand cmd = new MySqlCommand("SListaMisReportesEmpresas", GetCon());
      cmd.CommandType = CommandType.StoredProcedure;
      MySqlDataAdapter da = new MySqlDataAdapter();
      da.SelectCommand = cmd;
      da.Fill(dt);

      if (dt.Rows.Count > 0)
      {
        var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_de_misreportes_Empresas = JsonConvert.DeserializeObject<List<Models.Entidad.Emisreportes>>(result, new JsonSerializerSettings()
        {
          NullValueHandling = NullValueHandling.Ignore
        });
      }

      return lista_de_misreportes_Empresas;
    }


        public List<Models.Entidad.Emisreportes> Eliminar_Reporte(int cod_reporte)
        {
           

                List<Models.Entidad.Emisreportes> lista_eliminar_reportes = new List<Models.Entidad.Emisreportes>();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("eliminarReporte", GetCon());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("prm_cod_reporte", MySqlDbType.Int32).Value = cod_reporte;
            da.Fill(dt);


            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_eliminar_reportes = JsonConvert.DeserializeObject<List<Models.Entidad.Emisreportes>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            return lista_eliminar_reportes;
        }



            public Emisreportes obtenerFotos(int cod_reporte)
    {
      Emisreportes emisreportes1 = new Emisreportes();
      try
      {

        DataTable dt = new DataTable();
        MySqlCommand cmd = new MySqlCommand("SListaFotos", GetCon());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("prm_cod_reporte", MySqlDbType.Int32).Value = cod_reporte;
        MySqlDataAdapter da = new MySqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
          var result = JsonConvert.SerializeObject(dt, Formatting.Indented).Replace("[", "").Replace("]", "");
          emisreportes1 = JsonConvert.DeserializeObject<Emisreportes>(result, new JsonSerializerSettings()
          {
            NullValueHandling = NullValueHandling.Ignore
          });

          emisreportes1.respuesta = "OK";
        }
        else
        {
          emisreportes1.respuesta = "NO";
          emisreportes1.mensaje = "¡No se pudo registrar el usuario!";
        }
      }
      catch (Exception ex)
      {
        emisreportes1.respuesta = "NO";
        emisreportes1.mensaje = "Error. no se pudo realizar la tarea solicitada.";
      }
      return emisreportes1;
    }




  }
}
