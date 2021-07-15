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
  public class ActualizarMisPuntos : Conexion
  {
      public EActualizarMisPuntos Actualizar(int cod_puntos, double puntosacumulados, int cod_usuario)
      {
        EActualizarMisPuntos resultado = new EActualizarMisPuntos();
        try
        {
          MySqlCommand cmd = new MySqlCommand("ActualizarPuntos", GetCon());
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add("prm_cod_puntos", MySqlDbType.Int32).Value = cod_puntos;
          cmd.Parameters.Add("prm_puntosacumulado", MySqlDbType.Double).Value = puntosacumulados;
          cmd.Parameters.Add("prm_cod_usuario", MySqlDbType.Text).Value = cod_usuario;

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
