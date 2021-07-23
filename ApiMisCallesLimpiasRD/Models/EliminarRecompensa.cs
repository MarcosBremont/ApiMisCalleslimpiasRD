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
  public class EliminarRecompensa : Conexion
  {
      public EEliminarRecompensa EliminarRecompensaSeleccionada(int cod_recompensa)
      {
        EEliminarRecompensa resultado = new EEliminarRecompensa();
        try
        {
          MySqlCommand cmd = new MySqlCommand("EliminarRecompensa", GetCon());
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add("prm_cod_recompensa", MySqlDbType.Int32).Value = cod_recompensa;
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
