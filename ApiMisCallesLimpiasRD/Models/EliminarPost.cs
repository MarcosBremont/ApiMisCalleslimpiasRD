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
  public class EliminarPost : Conexion
  {
      public Epost eliminarPost(int cod_post)
      {
        Epost resultado = new Epost();
        try
        {
          MySqlCommand cmd = new MySqlCommand("EliminarPost", GetCon());
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Parameters.Add("prm_cod_post", MySqlDbType.Int32).Value = cod_post;
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
