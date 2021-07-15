using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMisCallesLimpiasRD.Models
{
  public class Conexion
  {
    private readonly string conexion = "server=MYSQL5047.site4now.net;user=a26410_micalle;password=2011mic@lle;database=db_a26410_micalle;port=3306;max pool size=1000;SslMode=Required;Convert Zero Datetime=True;";

    private readonly MySqlConnection con;

    public Conexion()
    {
      this.con = new MySqlConnection(conexion);
    }
    public MySqlConnection GetCon()
    {
      return this.con;
    }
    public void Conectar()
    {
      if (this.con.State == System.Data.ConnectionState.Closed)
        this.con.Open();
    }
    public void Desconectar()
    {
      if (this.con.State == System.Data.ConnectionState.Open)
        this.con.Close();
    }

    public bool VerifyConnection()
    {
      MySqlConnection cnn;
      cnn = new MySqlConnection(conexion);
      try
      {
        cnn.Open();
        cnn.Close();
        return true;
      }
      catch
      {
        return false;
      }

    }
  }

}
