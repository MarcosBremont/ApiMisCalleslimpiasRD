using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using ApiMisCallesLimpiasRD.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using ApiMisCallesLimpiasRD;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Cors;
using ApiMisCallesLimpiasRD.Models.Entidad;
using MySqlX.XDevAPI.Common;
using System.Web.Http.Cors;

namespace ApiMisCallesLimpiasRD.Controllers
{
  [System.Web.Http.Cors.EnableCors(origins: "http://api.miscalleslimpiasrd.tecnolora.com/", headers: "*", methods: "*")]
  [Route("api/[controller]")]
  [ApiController]
  public class MisCallesLimpiasRDController
  {
    string respuestamensaje = "";
    //Sesion sesion = new Sesion();
    Eusuario eusuario = new Eusuario();
    [HttpGet("IniciarSesion/{usuario}/{clave}")]
    public ActionResult<Models.Entidad.Eusuario> IniciarSesion(string usuario, string clave)
    {
      Models.Usuario usuarios = new Models.Usuario();
      var response = usuarios.IniciarSesion(usuario, clave);

      if (response.respuesta == "OK")
      {
        
      } 

      return response;
    }

    //[HttpGet("RegistrarUsuario/{cod_usuario}/{usuario}/{email}/{clave}/{cedula}/{telefono}")]
    //public string RegistrarUsuario([FromBody] string content)
    //{
    //  List<Models.Entidad.Eusuario> ListaUsuario = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.Entidad.Eusuario>>(content);
    //  try
    //  {
    //    foreach (Models.Entidad.Eusuario eusuario in ListaUsuario)
    //    {
    //     new Usuario().RegistrarUsuario(eusuario);
    //    }
    //    return "True";
    //  }
    //  catch (Exception ex)
    //  {
    //    return ex.Message;
    //  }
    //}

    [HttpGet("RegistrarUsuario/{usuario}/{correo_Usuario}/{cedula_usuario}/{clave}/{telefono_Usuario}")]
    public ActionResult<Models.Entidad.Eusuario> RegistrarUsuario(
        string usuario,
        string correo_Usuario,
        string cedula_usuario,
        string clave,
        string telefono_Usuario
        )
    {
      
        Eusuario eusuario = new Eusuario();
        eusuario.usuario = usuario;
        eusuario.correo_Usuario = correo_Usuario;
        eusuario.cedula_usuario = cedula_usuario;
        eusuario.clave = clave;
        eusuario.telefono_Usuario = telefono_Usuario;
        //eusuario.estado = estado;
        Usuario usuario1 = new Usuario();
        var response = usuario1.RegistrarUsuario(eusuario);

        if (response.respuesta == "OK")
        {

        }

      
      return response;
    }

    [HttpGet("UContrasenaOlvidada/{correo_Usuario}/{clave_nueva}")]

    public ActionResult<Models.Entidad.Eusuario> UContrasenaOlvidada(string correo_Usuario, string clave_nueva)
    {
      Models.Usuario usuarios = new Models.Usuario();
      var response = usuarios.UContrasenaOlvidada(correo_Usuario, clave_nueva);

      if (response.respuesta == "OK")
      {

      }

      return response;
    }



    // CONSULTAR DE PRODUCTOS
    [HttpGet("ConsultarListadoDeReportes/{cod_usuario}")]
    public ActionResult<IEnumerable<Models.Entidad.Emisreportes>> ConsultarListadoDeMisReportes(int cod_usuario)
    {
      Models.Misreportes misreportes = new Models.Misreportes();

      List<Models.Entidad.Emisreportes> lista_de_misreportes = misreportes.lista_de_misreportes(cod_usuario);

      return lista_de_misreportes;
    }

    [HttpGet("ConsultarListadodeRecompensas")]
    public ActionResult<IEnumerable<Models.Entidad.Erecompensas>> ConsultarListadodeRecompensas()
    {
      Models.Recompensas recompensas = new Models.Recompensas();

      List<Models.Entidad.Erecompensas> lista_recompensas = recompensas.lista_recompensas();

      return lista_recompensas;
    }

    [HttpGet("ConsultarListadodePost")]
    public ActionResult<IEnumerable<Models.Entidad.Epost>> ConsultarListadodePost()
    {
      Models.Post post = new Models.Post();

      List<Models.Entidad.Epost> lista_de_post = post.lista_de_post();

      return lista_de_post;
    }

    [HttpGet("ConsultarInfSobreNosotros")]
    public ActionResult<IEnumerable<Models.Entidad.ESobreNosotros>> ConsultarInfSobreNosotros()
    {
      Models.SobreNosotros sobrenosotros = new Models.SobreNosotros();

      List<Models.Entidad.ESobreNosotros> lista_datos_sobre_nosotros = sobrenosotros.lista_datos_sobre_nosotros();

      return lista_datos_sobre_nosotros;
    }

    [HttpGet("ConsultarInfMisPuntos/{cod_usuario}")]
    public ActionResult<IEnumerable<Models.Entidad.EMisPuntos>> ConsultarInfMisPuntos(int cod_usuario)
    {
      Models.MisPuntos misPuntos = new Models.MisPuntos();

      List<Models.Entidad.EMisPuntos> lista_de_mis_puntos = misPuntos.lista_de_mis_puntos(cod_usuario);

      return lista_de_mis_puntos;
    }

    [HttpGet("VerificarCorreoElectronico/{correo_Usuario}")]
    public ActionResult<Models.Entidad.Eusuario> VerificarCorreoElectronico(string correo_Usuario)
    {
      Models.Usuario usuarios = new Models.Usuario();
      var response = usuarios.VerificarCorreoElectronico(correo_Usuario);

      if (response.respuesta == "OK")
      {

      }

      return response;
    }

     // Actualizar Orden
    //[HttpGet("ActualizarOrden")]
    [HttpGet("ActualizarOrden/{cod_puntos}/{puntosacumulados}/{cod_usuario}")]
    public ActionResult<Models.Entidad.EActualizarMisPuntos> ActualizarOrden(int cod_puntos, double puntosacumulados, int cod_usuario)
    {
      Models.ActualizarMisPuntos actualizarmispuntos = new Models.ActualizarMisPuntos();
      return actualizarmispuntos.Actualizar(cod_puntos, puntosacumulados, cod_usuario);
    }

    [HttpGet("ConsultarListadodeDatosNecesarios/{usuario}")]
    public ActionResult<IEnumerable<Models.Entidad.EDatosNecesarios>> ConsultarListadodeDatosNecesarios(string usuario)
    {
      Models.DatosNecesarios datosnecesarios = new Models.DatosNecesarios();

      List<Models.Entidad.EDatosNecesarios> lista_de_datos_necesarios = datosnecesarios.lista_de_datos_necesarios(usuario);

      return lista_de_datos_necesarios;
    }


    //Consultar los recibos por ID de usuario
    [HttpGet("obtenerFoto/{cod_reporte}")]
    public ActionResult<Models.Entidad.Emisreportes> obtenerFotos(int cod_reporte)
    {
      Models.Misreportes misreportes = new Models.Misreportes();
      var response = misreportes.obtenerFotos(cod_reporte);

      if (response.respuesta == "OK")
      {

      }

      return response;
    }

    [HttpGet("UDatosPerfilUsuario/{usuario}/{correo_Usuario}/{cedula_usuario}/{clave}/{telefono_Usuario}")]

    public ActionResult<Models.Entidad.Eusuario> UDatosPerfilUsuario(string usuario, string correo_Usuario, string cedula_usuario, string clave, string telefono_Usuario)
    {
      Models.Usuario usuarios = new Models.Usuario();
      var response = usuarios.UDatosPerfilUsuario(usuario, correo_Usuario, cedula_usuario, clave, telefono_Usuario);

      if (response.respuesta == "OK")
      {

      }

      return response;
    }

    
    [HttpGet("ConsultarRecibos/{cod_recibo}")]
    public ActionResult<IEnumerable<Models.Entidad.ERecibos>> ConsultarRecibos(int cod_recibo)
    {
      Models.Recibos recibos = new Models.Recibos();

      List<Models.Entidad.ERecibos> lista_de_recibos = recibos.lista_de_recibos(cod_recibo);

      return lista_de_recibos;
    }







    //Modificaciones 29/06/2021
    //Registro de recibos

    [HttpGet("RegistrarRecibos/{cod_usuario}/{cod_recompensa}")]
    public ActionResult<Models.Entidad.ERecibo> RegistrarRecibos(
        int cod_usuario,
        int cod_recompensa
        )
    {

      ERecibo erecibo = new ERecibo();
      erecibo.cod_usuario = cod_usuario;
      erecibo.cod_recompensa = cod_recompensa;

      Recibo recibo1 = new Recibo();
      var response = recibo1.RegistrarRecibos(erecibo);

      if (response.respuesta == "OK")
      {

      }
      return response;
    }


        //Hola
    //Consultar los recibos por ID de usuario
    [HttpGet("consultarrecibosporid/{cod_usuario}")]
    public ActionResult<IEnumerable<Models.Entidad.EConsultarRecibos>> consultaRecibo(int cod_usuario)
    {
      Models.ConsultarRecibo consultaNecesaria = new Models.ConsultarRecibo();

      List<Models.Entidad.EConsultarRecibos> listado_de_recibos = consultaNecesaria.listado_de_recibos(cod_usuario);

      return listado_de_recibos;
    } 

    [HttpGet("RegistrarReporte/{ubicacion}/{lat}/{lng}/{fotos}/{cod_usuario}")]
    public ActionResult<Models.Entidad.Emisreportes> RegistrarReporte(
       string ubicacion,
       string lat,
       string lng,
       string fotos,
       int cod_usuario
       ) //aqui mandas 4 parametros
    {

      Emisreportes emisreportes = new Emisreportes();
      emisreportes.ubicacion = ubicacion;
      emisreportes.lat = lat;
      emisreportes.lng = lng;
      emisreportes.fotos = fotos;
      emisreportes.cod_usuario = cod_usuario;
      Misreportes misreportes = new Misreportes();
      var response = misreportes.RegistrarReporte(emisreportes);

      if (response.respuesta == "OK")
      {

      }


      return response;
    }


    [HttpPost("GuardarFotosOrden")]
    public string GuardarFotosOrden([FromBody] Emisreportes content)
    {
      string msj = "true";

      try
      {
        var response = new Misreportes().RegistrarReporte(content);

        if (response.respuesta == "OK")
        {

        }


        //string ruta_fisica = "C://images";
        //string foto = "";
        //int secuencia = 1;

        //foto = ruta_fisica + 1 + ".jpg";
        //if (System.IO.File.Exists(foto))
        //  System.IO.File.Delete(foto);

        ////Crear la carpeta de imágenes si no existe
        //if (!System.IO.Directory.Exists(ruta_fisica))
        //  System.IO.Directory.CreateDirectory(ruta_fisica);

        //foreach (string foto_en_base64 in lista_de_imagenes)
        //{
        //  foto = ruta_fisica + "" + secuencia + ".jpg";
        //  System.IO.File.WriteAllBytes(foto, Convert.FromBase64String(foto_en_base64));
        //  secuencia++;
        //}
      }
      catch (Exception ex)
      {
        msj = "Error:" + ex.Message;
      }

      return msj;
    }





    //Consultar los recibos por ID de usuario
    [HttpGet("nivelUsuario/{cod_usuario}")]
    public ActionResult<IEnumerable<Models.Entidad.EConsultarNivelUsuario>> consultarNivelUsuario(int cod_usuario)
    {
      Models.ConsultarNivelUsuario consultaNecesaria = new Models.ConsultarNivelUsuario();

      List<Models.Entidad.EConsultarNivelUsuario> listado_nivel_usuario = consultaNecesaria.listado_nivel_usuario(cod_usuario);

      return listado_nivel_usuario;


    }



    //// CONSULTAR ORDENES DE UN TECNICO
    //[HttpGet("ConsultarListadoDeOrdenesPorTecnico/{id_tecnico},{progreso_orden}")]
    //public ActionResult<IEnumerable<Models.Entidad.EOrdenServi>> ConsultarListadoDeOrdenesPorTecnico(int id_tecnico, string progreso_orden)
    //{
    //    Models.OrdenServicio ordenservi = new Models.OrdenServicio();

    //    List<Models.Entidad.EOrdenServi> lista_de_ordenes_por_tecnico = ordenservi.Lista_de_ordenes_por_tecnico(id_tecnico, progreso_orden);

    //    return lista_de_ordenes_por_tecnico;
    //}

    //[HttpGet("ConsultarListadoDeOrdenes/{tiposervicio}/{id_tecnico}/{progreso_orden}/{sector}")]
    //public ActionResult<IEnumerable<Models.Entidad.EOrdenServi>> ConsultarListadoDeOrdenes(int tiposervicio, int id_tecnico, string progreso_orden, string sector)
    //{
    //    Models.OrdenServicio ordenservi = new Models.OrdenServicio();

    //    List<Models.Entidad.EOrdenServi> lista_de_ordenes_por_tecnico = ordenservi.ListadoDeOrdenes(tiposervicio, id_tecnico, progreso_orden, sector);

    //    return lista_de_ordenes_por_tecnico;
    //}
    //[HttpGet("ConsultarListadoDeOrdenesPorFechas/{tiposervicio}/{id_tecnico}/{progreso_orden}/{desde}/{hasta}")]
    //public ActionResult<IEnumerable<Models.Entidad.EOrdenServi>> ConsultarListadoDeOrdenesPorFechas(int tiposervicio, int id_tecnico, string progreso_orden, DateTime desde, DateTime hasta)
    //{
    //    Models.OrdenServicio ordenservi = new Models.OrdenServicio();

    //    List<Models.Entidad.EOrdenServi> lista_de_ordenes_por_tecnico = ordenservi.ListadoDeOrdenesPorFechas(tiposervicio, id_tecnico, progreso_orden, desde, hasta);

    //    return lista_de_ordenes_por_tecnico;
    //}

    //// Actualizar Orden
    //[HttpGet("ActualizarOrden")]
    ////[HttpGet("ActualizarOrden/{tiposervicio}/{numero}/{progreso_orden}/{reportetecnico}")]
    //public ActionResult<Result> ActualizarOrden(int tiposervicio, int numero, string progreso_orden, string reportetecnico = "", string servicio = "")
    //{
    //    Models.OrdenServicio ordenservi = new Models.OrdenServicio();
    //    return ordenservi.ActualizarOrden(tiposervicio, numero, progreso_orden, reportetecnico, servicio);
    //}

    //[HttpGet("SetHistorialProgresoOrden")]
    //// [HttpGet("SetHistorialProgresoOrden/{numero}/{numero_ordencable}/{numero_ordeninternet}{progreso_orden}/{fecha}/{lat}/{lng}")]
    //public ActionResult<Result> SetHistorialProgresoOrden(int numero, int numero_ordencable, int numero_ordeninternet, string progreso_orden = "", string fecha = "", string lat = "", string lng = "")
    //{
    //    MetodoControl metodoControl = new MetodoControl();
    //    Models.OrdenServicio ordenservi = new Models.OrdenServicio();
    //    return ordenservi.SetHistorialProgresoOrden(numero, numero_ordencable, numero_ordeninternet, progreso_orden, metodoControl.DateTimeParse(fecha), lat, lng);
    //}

    //[HttpGet("ConsultarCantidadOrdenesProgreso/{id_tecnico}")]
    //public ActionResult<IEnumerable<Models.Entidad.ECantidadOrdenProgreso>> ConsultarCantidadOrdenesProgreso(int id_tecnico)
    //{
    //    Models.OrdenServicio ordenservi = new Models.OrdenServicio();
    //    return ordenservi.ListadoCantidadOrdenesProgreso(id_tecnico);
    //}

    //[HttpGet("CambiarClave/{codigo}/{clave}")]
    //public ActionResult<ETecnico> CambiarClave(int codigo, string clave)
    //{
    //    //validar token
    //    if (!sesion.ValidarSesion(Request.Headers["token"]))
    //    {
    //        return new ETecnico()
    //        {
    //            respuesta = "NO",
    //            mensaje = "Token no válido",
    //            respuesta_code = 1000
    //        };
    //    }

    //    return new Tecnico().CambiarClaveTecnico(codigo, clave);
    //}

    ////METODO PARA INSERTAR EN LA ORDEN

    //[HttpGet("SetFacturaTemporal")]
    //public ActionResult<string> SetUOrdenCableOfitec(
    //    int id_factura_temporal,
    //    int numero_orden_general,
    //    int id_producto,
    //    int cantidad,
    //    string tipo,
    //    double precio
    //    )
    //{
    //    try
    //    {
    //        EFacturaTemporal efacturatemporal = new EFacturaTemporal();
    //        efacturatemporal.id_factura_temporal = id_factura_temporal;
    //        efacturatemporal.numero_orden_general = numero_orden_general;
    //        efacturatemporal.id_producto = id_producto;
    //        efacturatemporal.cantidad = cantidad;
    //        efacturatemporal.tipo_servicio = tipo;
    //        efacturatemporal.precio = precio;

    //        new NFacturaTemporal().SentenciaFacturaTemporal(efacturatemporal);
    //        return "True";
    //    }
    //    catch (Exception ex)
    //    {
    //        return "False";
    //    }
    //}


    //[HttpGet("ListadoDeProductosPorOrdenes/{numero_orden_general}")]
    //public ActionResult<IEnumerable<Models.Entidad.EFacturaTemporall>> ListadoDeProductosPorOrdenes(int numero_orden_general)
    //{
    //    Models.OrdenServicio ordenservi = new Models.OrdenServicio();

    //    List<Models.Entidad.EFacturaTemporall> Listado_Productos = ordenservi.ListadoDeProductosPorOrdenes(numero_orden_general);

    //    return Listado_Productos;
    //}

    //[HttpGet("EliminarProductoProIDFacturaTemporal/{id_factura_temporal}")]
    //public ActionResult<string> EliminarProductoProIDFacturaTemporal(int id_factura_temporal)
    //{
    //    // Eliminar Factura temporal por id_factura_temporal...
    //    // Aquí es donde toda la magia ocurre...
    //    Models.OrdenServicio ordenservi = new Models.OrdenServicio();
    //    List<Models.Entidad.EFacturaTemporall> Listado_Productos = ordenservi.EliminarProductoProIDFacturaTemporal(id_factura_temporal);

    //    return "true"; // Retorna "true" si todo sale bien.
    //}

    //[HttpPost("GuardarDetalleFacturaTemporal")]
    //public string GuardarDetalleFacturaTemporal([FromBody] string content, int id_factura_temporal)
    //{
    //    List<Models.Entidad.EProducto> listadeProductosInventario = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.Entidad.EProducto>>(content);
    //    try
    //    {
    //        EFacturaTemporal efacturatemporal = new EFacturaTemporal();
    //        NFacturaTemporal nFacturaTemporal = new NFacturaTemporal();
    //        foreach (Models.Entidad.EProducto eproducto in listadeProductosInventario)
    //        {
    //            efacturatemporal.id_factura_temporal = eproducto.id_factura_temporal;
    //            efacturatemporal.numero_orden_general = eproducto.numero_orden_general;
    //            efacturatemporal.id_producto = eproducto.cod_prod;
    //            efacturatemporal.cantidad = eproducto.cantidad;
    //            efacturatemporal.tipo_servicio = eproducto.tipo;
    //            efacturatemporal.precio = eproducto.precio;
    //            nFacturaTemporal.SentenciaFacturaTemporal(efacturatemporal);
    //        }
    //        return "True";
    //    }
    //    catch (Exception ex)
    //    {
    //        return ex.Message;
    //    }
    //}

    //[HttpGet("ConsultarListadoDeProductosPorSector/{id_sector}/{estado}/{serviciotecnico}")]
    //public ActionResult<IEnumerable<Models.Entidad.EProducto>> ConsultarListadoDeProductosPorSector(int id_sector, string estado, string serviciotecnico)
    //{
    //    Models.Producto producto = new Models.Producto();
    //    List<Models.Entidad.EProducto> lista_de_productos = producto.Lista_de_productos_por_sector(id_sector, estado, serviciotecnico);
    //    return lista_de_productos;
    //}


    //[HttpGet("ConsultarSectores")]
    //public ActionResult<IEnumerable<Models.Entidad.ESectores>> ConsultarSectores()
    //{
    //    Models.Sectores sectores = new Models.Sectores();

    //    List<Models.Entidad.ESectores> lista_de_sectores = sectores.Lista_de_sectores();

    //    return lista_de_sectores;
    //}


    //[HttpPost("GuardarFotosOrden")]
    //public string GuardarFotosOrden([FromBody] string content, int numeroOrdenGeneral, string tipoServicio)
    //{
    //    string msj = "true";

    //    try
    //    {
    //        List<string> lista_de_imagenes = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(content);
    //        new NEmpresa().SEmpresaLlenarConfiguracion();
    //        string carpetaOrden = tipoServicio.ToLower() == "cable" ? "OrdenCable" : "OrdenInternet";
    //        string ruta_fisica = EConfiguracion.ruta_foto_orden_completa + "/images/" + carpetaOrden;
    //        string ruta_foto = ruta_fisica + "/" + numeroOrdenGeneral + "_";
    //        string foto = "";
    //        int secuencia = 1;

    //        foto = ruta_foto + 1 + ".jpg";
    //        if (System.IO.File.Exists(foto))
    //            System.IO.File.Delete(foto);
    //        foto = ruta_foto + 2 + ".jpg";
    //        if (System.IO.File.Exists(foto))
    //            System.IO.File.Delete(foto);
    //        foto = ruta_foto + 3 + ".jpg";
    //        if (System.IO.File.Exists(foto))
    //            System.IO.File.Delete(foto);

    //        //Crear la carpeta de imágenes si no existe
    //        if (!System.IO.Directory.Exists(ruta_fisica))
    //            System.IO.Directory.CreateDirectory(ruta_fisica);

    //        foreach (string foto_en_base64 in lista_de_imagenes)
    //        {
    //            foto = ruta_foto + "" + secuencia + ".jpg";
    //            System.IO.File.WriteAllBytes(foto, Convert.FromBase64String(foto_en_base64));
    //            secuencia++;
    //        }
    //    }
    //        catch (Exception ex)
    //    {
    //        msj = "Error:" + ex.Message;
    //    }

    //    return msj;
    //}

    //[HttpGet("ObtenerFotosOrden")]
    //public string ObtenerFotosOrden(int numeroOrdenGeneral, string tipoServicio)
    //{
    //    // To-Do Hacer un Select a la base de datos que traiga todas las fotos de una orden
    //    return JsonConvert.SerializeObject((new Models.Foto_orden().SFoto_orden(numeroOrdenGeneral.ToString(), tipoServicio)));
    //}

    //[HttpGet("ActualizarLocalizacion/{codigo_cli}/{lat}/{lng}")]
    //public ActionResult<Result> ActualizarLocalizacion(int codigo_cli, string lat = "", string lng = "")
    //{
    //    Models.OrdenServicio ordenservi = new Models.OrdenServicio();
    //    return ordenservi.ActualizarLocalizacion(codigo_cli, lat, lng);
    //}

    //[HttpGet("IimeiOfitec/{imei}/{fecha_hora}/{aplicacion}")]
    //public ActionResult<ResultValidarImei> IimeiOfitec(string imei, DateTime fecha_hora, string aplicacion = "")
    //{
    //    return new EquiposMoviles().ValidarImei(imei, fecha_hora, aplicacion);
    //}

    //[HttpGet("ActualizarIdentificadorTecnico/{cod_tecnico}/{imei}")]
    //public ActionResult<Result> ActualizarIdentificadorTecnico(int cod_tecnico, string imei)
    //{
    //    Models.OrdenServicio ordenservi = new Models.OrdenServicio();
    //    return ordenservi.ActualizarIdentificadorTecnico(cod_tecnico, imei);
    //}

    //[HttpGet("IsLicenciaValida/{fecha_hora}")]
    //public ActionResult<Result> IsLicenciaValida(DateTime fecha_hora)
    //{
    //    Models.OrdenServicio ordenservi = new Models.OrdenServicio();
    //    return ordenservi.IsLicenciaValida(fecha_hora);
    //}
  }
}
