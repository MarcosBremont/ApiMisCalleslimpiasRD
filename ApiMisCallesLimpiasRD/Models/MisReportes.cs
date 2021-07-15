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
  public class Misreportes : Conexion
  {
    //MetodoControl metodoControl = new MetodoControl();
    public List<Models.Entidad.Emisreportes> lista_de_misreportes(int cod_usuario)
    {
      List<Models.Entidad.Emisreportes> lista_de_misreportes = new List<Models.Entidad.Emisreportes>();

      DataTable dt = new DataTable();
      MySqlCommand cmd = new MySqlCommand("SListaMisReportesPorCod_usuario", GetCon());
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.Add("prm_cod_usuario", MySqlDbType.Int32).Value = cod_usuario;
      MySqlDataAdapter da = new MySqlDataAdapter();
      da.SelectCommand = cmd;
      da.Fill(dt);

      if (dt.Rows.Count > 0)
      {
        var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
        lista_de_misreportes = JsonConvert.DeserializeObject<List<Models.Entidad.Emisreportes>>(result, new JsonSerializerSettings()
        {
          NullValueHandling = NullValueHandling.Ignore
        });
      }

      return lista_de_misreportes;
    }


    public Emisreportes RegistrarReporte(Emisreportes emisreportes)
    {
      Emisreportes emisreportes1 = new Emisreportes();
      try
      {

        DataTable dt = new DataTable();
        MySqlCommand cmd = new MySqlCommand("RegistroReporte", GetCon());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("prm_ubicacion", MySqlDbType.Text).Value = emisreportes.ubicacion;
        cmd.Parameters.Add("prm_lat", MySqlDbType.Text).Value = emisreportes.lat;
        cmd.Parameters.Add("prm_lng", MySqlDbType.Text).Value = emisreportes.lng;
        cmd.Parameters.Add("prm_fotos", MySqlDbType.Text).Value = emisreportes.fotos;
        cmd.Parameters.Add("prm_cod_usuario", MySqlDbType.Int16).Value = emisreportes.cod_usuario;
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


    //public List<Models.Entidad.Emisreportes> lista_imagenes(int cod_reporte)
    //{
    //  Emisreportes emisreportes = new Emisreportes();
    //  List<Models.Entidad.Emisreportes> lista_imagenes = new List<Models.Entidad.Emisreportes>();

    //  DataTable dt = new DataTable();
    //  MySqlCommand cmd = new MySqlCommand("SListaFotos", GetCon());
    //  cmd.CommandType = CommandType.StoredProcedure;
    //  cmd.Parameters.Add("prm_cod_reporte", MySqlDbType.Int32).Value = cod_reporte;
    //  MySqlDataAdapter da = new MySqlDataAdapter();
    //  da.SelectCommand = cmd;
    //  da.Fill(dt);

    //  if (dt.Rows.Count > 0)
    //  {
    //    var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
    //    lista_imagenes = JsonConvert.DeserializeObject<List<Models.Entidad.Emisreportes>>(result, new JsonSerializerSettings()
    //    {
    //      NullValueHandling = NullValueHandling.Ignore
    //    });
       

    //  }
    //  else
    //  {
    //  }

    //  return lista_imagenes;
    //}

    //public List<Models.Entidad.EProducto> Lista_de_productos_por_sector(int id_sector, string estado, string serviciotecnico)
    //{

    //    List<Models.Entidad.EProducto> Lista_de_productos_por_sector = new List<Models.Entidad.EProducto>();

    //    DataTable dt = new DataTable();
    //    MySqlDataAdapter da = new MySqlDataAdapter("SListaProductosPorSector", GetCon());
    //    da.SelectCommand.CommandType = CommandType.StoredProcedure;
    //    da.SelectCommand.Parameters.Add("prm_id_sector", MySqlDbType.Int32).Value = id_sector;
    //    da.SelectCommand.Parameters.Add("prm_estado", MySqlDbType.VarChar).Value = estado;
    //    da.SelectCommand.Parameters.Add("prm_serviciotecnico", MySqlDbType.VarChar).Value = serviciotecnico;
    //    da.Fill(dt);
    //    if (dt.Rows.Count > 0)
    //    {
    //        Lista_de_productos_por_sector = metodoControl.ConvertirTablaEnLista<Models.Entidad.EProducto>(dt);
    //    }
    //    return Lista_de_productos_por_sector;
    //}

  }
}
