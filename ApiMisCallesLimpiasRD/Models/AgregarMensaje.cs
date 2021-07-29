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
    public class AgregarMensaje : Conexion
    {
        public EMensajes agregar_Mensaje( int cod_usuario,string mensajes)
        {
            EMensajes resultado = new EMensajes();
            try
            {
                MySqlCommand cmd = new MySqlCommand("RegistrarMensajeErrorReportes", GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prm_cod_usuario", MySqlDbType.Int16).Value = cod_usuario;
                cmd.Parameters.Add("prm_mensaje", MySqlDbType.String).Value = mensajes;

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
