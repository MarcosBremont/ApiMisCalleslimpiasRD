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
    public class Usuario : Conexion
    {
        public Eusuario IniciarSesion(string usuario, string clave)
        {
            Eusuario usuarios = new Eusuario();
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("IniciarSesion", GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prm_usuario", MySqlDbType.Text).Value = usuario;
                cmd.Parameters.Add("prm_clave", MySqlDbType.Text).Value = clave;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    var result = JsonConvert.SerializeObject(dt, Formatting.Indented).Replace("[", "").Replace("]", "");
                    usuarios = JsonConvert.DeserializeObject<Eusuario>(result, new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    usuarios.respuesta = "OK";
                }
                else
                {
                    usuarios.respuesta = "NO";
                    usuarios.mensaje = "¡Usuario o contraseña incorrectos!";
                }
            }
            catch (Exception ex)
            {
                usuarios.respuesta = "NO";
                usuarios.mensaje = "Error. no se pudo realizar la tarea solicitada.";
            }
            return usuarios;
        }

        public Eusuario RegistrarUsuario(Eusuario eusuario)
        {
            Eusuario usuarios = new Eusuario();
            try
            {

                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("RegistrarUsuario", GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prm_usuario", MySqlDbType.Text).Value = eusuario.usuario;
                cmd.Parameters.Add("prm_correo_Usuario", MySqlDbType.Text).Value = eusuario.correo_Usuario;
                cmd.Parameters.Add("prm_clave", MySqlDbType.Text).Value = eusuario.clave;
                cmd.Parameters.Add("prm_cedula_usuario", MySqlDbType.Text).Value = eusuario.cedula_usuario;
                cmd.Parameters.Add("prm_telefono_Usuario", MySqlDbType.Text).Value = eusuario.telefono_Usuario;
                cmd.Parameters.Add("prm_cod_ayuntamiento", MySqlDbType.Int32).Value = eusuario.cod_ayuntamiento;

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    var result = JsonConvert.SerializeObject(dt, Formatting.Indented).Replace("[", "").Replace("]", "");
                    usuarios = JsonConvert.DeserializeObject<Eusuario>(result, new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    usuarios.respuesta = "OK";
                }
                else
                {
                    usuarios.respuesta = "NO";
                    usuarios.mensaje = "¡No se pudo registrar el usuario!";
                }
            }
            catch (Exception ex)
            {
                usuarios.respuesta = "NO";
                usuarios.mensaje = "Error. no se pudo realizar la tarea solicitada.";
            }
            return usuarios;
        }
        // Este es el error: Cannot add or update a child row: a foreign key constraint fails // estoy investigando en mi pc a ver que es Dejame abrir sql de un pronto
        public Eusuario UContrasenaOlvidada(string correo_Usuario, string clave_nueva)
        {
            Eusuario usuarios = new Eusuario();
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("UContrasenaOlvidada", GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prm_correo_Usuario", MySqlDbType.String).Value = correo_Usuario;
                cmd.Parameters.Add("prm_clave_nueva", MySqlDbType.String).Value = clave_nueva;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    var result = JsonConvert.SerializeObject(dt, Formatting.Indented).Replace("[", "").Replace("]", "");
                    usuarios = JsonConvert.DeserializeObject<Eusuario>(result, new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    usuarios.respuesta = "OK";
                }
                else
                {
                    usuarios.respuesta = "NO";
                    usuarios.mensaje = "¡No se pudo cambiar la contraseña!";
                }
            }
            catch (Exception ex)
            {
                usuarios.respuesta = "NO";
                usuarios.mensaje = "Error. no se pudo realizar la tarea solicitada.";
            }
            return usuarios;
        }


        public Eusuario VerificarCorreoElectronico(string email)
        {
            Eusuario usuarios = new Eusuario();
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("VerificarCorreoElectronico", GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prm_correo_Usuario", MySqlDbType.Text).Value = email;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    var result = JsonConvert.SerializeObject(dt, Formatting.Indented).Replace("[", "").Replace("]", "");
                    usuarios = JsonConvert.DeserializeObject<Eusuario>(result, new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    usuarios.respuesta = "OK";
                    usuarios.mensaje = "¡Ya existe ese correo electronico!";
                }
                else
                {
                    usuarios.respuesta = "NO";
                    usuarios.mensaje = "¡Ese correo no existe!";
                }
            }
            catch (Exception ex)
            {
                usuarios.respuesta = "NO";
                usuarios.mensaje = "Error. no se pudo realizar la tarea solicitada.";
            }
            return usuarios;
        }

        public Eusuario UDatosPerfilUsuario(Eusuario eusuario)
        {
            try
            {
                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("UDatosPerfilUsuario", GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prm_cod_usuario", MySqlDbType.Int32).Value = eusuario.cod_usuario;
                cmd.Parameters.Add("prm_correo_Usuario", MySqlDbType.String).Value = eusuario.correo_Usuario;
                cmd.Parameters.Add("prm_cedula_usuario", MySqlDbType.String).Value = eusuario.cedula_usuario;
                cmd.Parameters.Add("prm_clave", MySqlDbType.String).Value = eusuario.clave;
                cmd.Parameters.Add("prm_telefono_Usuario", MySqlDbType.String).Value = eusuario.telefono_Usuario;
                cmd.Parameters.Add("prm_foto_usuario", MySqlDbType.String).Value = eusuario.foto_usuario;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

                    if (dt.Rows.Count > 0)
                {
                    var result = JsonConvert.SerializeObject(dt, Formatting.Indented).Replace("[", "").Replace("]", "");
                    eusuario = JsonConvert.DeserializeObject<Eusuario>(result, new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    eusuario.respuesta = "OK";
                }
                else
                {
                    eusuario.respuesta = "NO";
                    eusuario.mensaje = "¡No se pudo cambiar la contraseña!";
                }
            }
            catch (Exception ex)
            {
                eusuario.respuesta = "NO";
                eusuario.mensaje = "Error. no se pudo realizar la tarea solicitada.";
            }
            return eusuario;
        }

        public Eusuario obtenerFotoPerfil(int cod_usuario)
        {
            Eusuario eusuario = new Eusuario();
            try
            {

                DataTable dt = new DataTable();
                MySqlCommand cmd = new MySqlCommand("SListaFotoPerfil", GetCon());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("prm_cod_usuario", MySqlDbType.Int32).Value = cod_usuario;
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    var result = JsonConvert.SerializeObject(dt, Formatting.Indented).Replace("[", "").Replace("]", "");
                    eusuario = JsonConvert.DeserializeObject<Eusuario>(result, new JsonSerializerSettings()
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    eusuario.respuesta = "OK";
                }
                else
                {
                    eusuario.respuesta = "NO";
                    eusuario.mensaje = "¡No se pudo registrar el usuario!";
                }
            }
            catch (Exception ex)
            {
                eusuario.respuesta = "NO";
                eusuario.mensaje = "Error. no se pudo realizar la tarea solicitada.";
            }
            return eusuario;
        }


        //public Eusuario UDatosPerfilUsuario(string foto_usuario, int cod_usuario)
        //{
        //    Eusuario usuarios = new Eusuario();
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        MySqlCommand cmd = new MySqlCommand("UFotoPerfil", GetCon());
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("prm_foto_usuario", MySqlDbType.String).Value = foto_usuario;
        //        cmd.Parameters.Add("prm_cod_usuario", MySqlDbType.String).Value = cod_usuario;
        //        MySqlDataAdapter da = new MySqlDataAdapter();
        //        da.SelectCommand = cmd;
        //        da.Fill(dt);

        //        if (dt.Rows.Count > 0)
        //        {
        //            var result = JsonConvert.SerializeObject(dt, Formatting.Indented).Replace("[", "").Replace("]", "");
        //            usuarios = JsonConvert.DeserializeObject<Eusuario>(result, new JsonSerializerSettings()
        //            {
        //                NullValueHandling = NullValueHandling.Ignore
        //            });

        //            usuarios.respuesta = "OK";
        //        }
        //        else
        //        {
        //            usuarios.respuesta = "NO";
        //            usuarios.mensaje = "¡No se pudo cambiar la contraseña!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        usuarios.respuesta = "NO";
        //        usuarios.mensaje = "Error. no se pudo realizar la tarea solicitada.";
        //    }
        //    return usuarios;
        //}




    }






}

