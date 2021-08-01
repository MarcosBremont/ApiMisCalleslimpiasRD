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
    public class ActualizarRecibosProcesar : Conexion
    {
        public ERecibos Actualizar_Recibos(int cod_recibo)
        {
            ERecibos resultado = new ERecibos();
            try
            {
                MySqlCommand cmd = new MySqlCommand("ActualizarReciboProcesar", GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prm_cod_recibo", MySqlDbType.Int32).Value = cod_recibo;

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
