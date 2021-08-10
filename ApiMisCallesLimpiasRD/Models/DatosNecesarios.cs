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
    public class DatosNecesarios : Conexion
    {
        //public List<Models.Entidad.EDatosNecesarios> lista_de_datos_necesarios(string usuario)
        //{
        //  List<Models.Entidad.EDatosNecesarios> lista_de_datos_necesarios = new List<Models.Entidad.EDatosNecesarios>();

        //  DataTable dt = new DataTable();
        //  MySqlCommand cmd = new MySqlCommand("SListaDatosNecesarios", GetCon());
        //  cmd.Parameters.Add("prm_usuario", MySqlDbType.Text).Value = usuario;
        //  MySqlDataAdapter da = new MySqlDataAdapter();
        //  da.SelectCommand = cmd;
        //  da.Fill(dt);

        //  if (dt.Rows.Count > 0)
        //  {
        //    var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
        //    lista_de_datos_necesarios = JsonConvert.DeserializeObject<List<Models.Entidad.EDatosNecesarios>>(result, new JsonSerializerSettings()
        //    {
        //      NullValueHandling = NullValueHandling.Ignore
        //    });
        //  }

        //  return lista_de_datos_necesarios;
        //}

        public List<Models.Entidad.EDatosNecesarios> lista_de_datos_necesarios(string usuario)
        {

            List<Models.Entidad.EDatosNecesarios> lista_de_datos_necesarios = new List<Models.Entidad.EDatosNecesarios>();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SListaDatosNecesarios", GetCon());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("prm_usuario", MySqlDbType.VarChar).Value = usuario;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_de_datos_necesarios = JsonConvert.DeserializeObject<List<Models.Entidad.EDatosNecesarios>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            return lista_de_datos_necesarios;
        }




        public List<Models.Entidad.EDatosNecesarios> lista_de_datos_inicio(int cod_usuario)
        {

            List<Models.Entidad.EDatosNecesarios> lista_de_datos_inicio = new List<Models.Entidad.EDatosNecesarios>();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SlistaDeDatosInicio", GetCon());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("prm_cod_usuario", MySqlDbType.Int32).Value = cod_usuario;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_de_datos_inicio = JsonConvert.DeserializeObject<List<Models.Entidad.EDatosNecesarios>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            return lista_de_datos_inicio;
        }

        public List<Models.Entidad.EDatosNecesarios> lista_de_datos_inicio_ayunta(int cod_ayuntamiento)
        {

            List<Models.Entidad.EDatosNecesarios> lista_de_datos_inicio_ayunta = new List<Models.Entidad.EDatosNecesarios>();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SlistaDeDatosInicioAyuntamientos", GetCon());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("prm_cod_ayuntamiento", MySqlDbType.Int32).Value = cod_ayuntamiento;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_de_datos_inicio_ayunta = JsonConvert.DeserializeObject<List<Models.Entidad.EDatosNecesarios>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            return lista_de_datos_inicio_ayunta;
        }

        public List<Models.Entidad.EDatosNecesariosAyuntamientos> lista_de_datos_necesarios_ayunta(string usuario)
        {

            List<Models.Entidad.EDatosNecesariosAyuntamientos> lista_de_datos_necesarios_ayunta = new List<Models.Entidad.EDatosNecesariosAyuntamientos>();


            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SListaDatosNecesariosAyuntamientos", GetCon());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("prm_usuario", MySqlDbType.String).Value = usuario;
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                var result = JsonConvert.SerializeObject(dt, Formatting.Indented);
                lista_de_datos_necesarios_ayunta = JsonConvert.DeserializeObject<List<Models.Entidad.EDatosNecesariosAyuntamientos>>(result, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            return lista_de_datos_necesarios_ayunta;
        }


    }

}
