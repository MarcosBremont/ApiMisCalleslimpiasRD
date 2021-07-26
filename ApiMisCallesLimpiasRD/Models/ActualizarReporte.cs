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
    public class ActualizarReporte : Conexion
    {
        public Emisreportes Actualizar_Reportes(int cod_reporte)
        {
            Emisreportes resultado = new Emisreportes();
            try
            {
                MySqlCommand cmd = new MySqlCommand("ActualizarReportes", GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prm_cod_reporte", MySqlDbType.Int32).Value = cod_reporte;


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
