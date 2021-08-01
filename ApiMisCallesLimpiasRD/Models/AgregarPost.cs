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
    public class AgregarPost : Conexion
    {
        public Epost agregarPost( string titulo,string descripcion, string imagen)
        {
            Epost resultado = new Epost();
            try
            {
                MySqlCommand cmd = new MySqlCommand("RegistrarPostEducacional", GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prm_titulo", MySqlDbType.String).Value = titulo;
                cmd.Parameters.Add("prm_descripcion", MySqlDbType.String).Value = descripcion;                
                cmd.Parameters.Add("prm_imagen", MySqlDbType.String).Value = imagen;

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
