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
    public class AgregarRecompensa : Conexion
    {
        public ERecompensa agregar_Recompensa( string nombre,double puntos, string imagen, string descripcion)
        {
            ERecompensa resultado = new ERecompensa();
            try
            {
                MySqlCommand cmd = new MySqlCommand("RegistrarRecompensa", GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prm_nombre", MySqlDbType.Text).Value = nombre;
                cmd.Parameters.Add("prm_puntos", MySqlDbType.Double).Value = puntos;                
                cmd.Parameters.Add("prm_imagen", MySqlDbType.Text).Value = imagen;
                cmd.Parameters.Add("prm_descripcion", MySqlDbType.Text).Value = descripcion;

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
