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
    public class DesactivarRecompensa : Conexion
    {
        public ERecompensa Desactivar_Recompensa(int cod_recompensa)
        {
            ERecompensa resultado = new ERecompensa();
            try
            {
                MySqlCommand cmd = new MySqlCommand("ActualizarDesactivarRecompensas", GetCon());
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
