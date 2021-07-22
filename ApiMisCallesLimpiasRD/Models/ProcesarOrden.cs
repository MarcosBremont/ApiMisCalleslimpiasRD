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
  public class ProcesarOrden : Conexion
  {
      public EActualizarMisPuntos ProcesarPuntos( int cod_usuario,double puntosacumulados)
      {
        EActualizarMisPuntos resultado = new EActualizarMisPuntos();
        try
        {
          MySqlCommand cmd = new MySqlCommand("procesarPuntos", GetCon());
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add("prm_cod_usuario", MySqlDbType.Int32).Value = cod_usuario;
          cmd.Parameters.Add("prm_puntos_reporte", MySqlDbType.Double).Value = puntosacumulados;

          Conectar();
          cmd.ExecuteNonQuery();
          Desconectar();
          resultado.respuesta = "OK";
        }
        catch (Exception ex)
        {
          resultado.respuesta = "ERROR";
          resultado.mensaje = ex.Message;
        }

        return resultado;
      }
    }
  }
