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
  public class Recibo : Conexion
  {
    

    public ERecibo RegistrarRecibos(ERecibo erecibo)
    {
      ERecibo recibos = new ERecibo();
        try { 

        DataTable dt = new DataTable();
        MySqlCommand cmd = new MySqlCommand("RegistrarRecibos", GetCon());
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("prm_cod_usuario", MySqlDbType.Int32).Value = erecibo.cod_usuario;
        cmd.Parameters.Add("prm_cod_recompensa", MySqlDbType.Int32).Value = erecibo.cod_recompensa;
        cmd.Parameters.Add("prm_cod_ayuntamiento", MySqlDbType.Int32).Value = erecibo.cod_ayuntamiento;

        MySqlDataAdapter da = new MySqlDataAdapter();
        da.SelectCommand = cmd;
        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
          var result = JsonConvert.SerializeObject(dt, Formatting.Indented).Replace("[", "").Replace("]", "");
          recibos = JsonConvert.DeserializeObject<ERecibo>(result, new JsonSerializerSettings()
          {
            NullValueHandling = NullValueHandling.Ignore
          });

          recibos.respuesta = "OK";
        }
        else
        {
          recibos.respuesta = "NO";
          recibos.mensaje = "¡No se pudo completar el registro de bono!";
        }
      }
      catch (Exception ex)
      {
        recibos.respuesta = "NO";
        recibos.mensaje = "Error. no se pudo realizar la tarea solicitada.";
      }
      return recibos;
    }


  }


 



}

