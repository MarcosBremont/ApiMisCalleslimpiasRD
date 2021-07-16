using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace ApiMisCallesLimpiasRD.Controllers
{
    public class CustomControllerBase : ControllerBase
    {
        public JsonResult CustomJsonResult(object my_object)
        {
            //return new JsonResult(Newtonsoft.Json.JsonConvert.SerializeObject(my_object));
            return new JsonResult(my_object);
        }

        public JsonResult CustomJsonResult(List<object> my_object_list)
        {
            return new JsonResult(Newtonsoft.Json.JsonConvert.SerializeObject(my_object_list));
        }

        public object DerializeObject<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        public T DataTableToObject<T>(DataTable dt)
        {
            if (dt.Rows.Count > 0)
                return DataRowToObject<T>(dt.Rows[0], dt.Columns);
            else
                return (T)Activator.CreateInstance(typeof(T));
        }

        public T DataRowToObject<T>(DataRow row, DataColumnCollection columns)
        {
            var obj = (T)Activator.CreateInstance(typeof(T));
            var properties = obj.GetType().GetProperties();
            string temporal_value;

            foreach (DataColumn dc in columns)
            {
                foreach (var prop in properties)
                {
                    if (prop.Name == dc.ColumnName)
                    {
                        if (prop.PropertyType.Name.Contains("String"))
                        {
                            temporal_value = row[dc.ColumnName].ToString();
                            prop.SetValue(obj, temporal_value);
                        }
                        else if (prop.PropertyType.Name.ToLower().Contains("int"))
                        {
                            temporal_value = row[dc.ColumnName].ToString();
                            temporal_value = string.IsNullOrEmpty(temporal_value) ? "0" : temporal_value;
                            prop.SetValue(obj, Convert.ToInt32(temporal_value));
                        }
                        else if (prop.PropertyType.Name.ToLower().Contains("double"))
                        {
                            temporal_value = row[dc.ColumnName].ToString();
                            temporal_value = string.IsNullOrEmpty(temporal_value) ? "0.00" : temporal_value;
                            prop.SetValue(obj, Convert.ToDouble(temporal_value));
                        }
                        else
                        {
                            if (row[dc.ColumnName] != null && !string.IsNullOrEmpty(row[dc.ColumnName].ToString()))
                            {
                                prop.SetValue(obj, Convert.ToDateTime(row[dc.ColumnName].ToString()));
                            }
                        }
                    }
                }
            }

            return obj;
        }

        public List<T> DataTableToObjectList<T>(DataTable dt)
        {
            List<T> lista = new List<T>();

            foreach (DataRow row in dt.Rows)
                lista.Add(DataRowToObject<T>(row, dt.Columns));

            return lista;
        }

        public int OnlyIntegerNumbers(string texto)
        {
            string new_int = "";

            for (int i = 0; i < texto.Length; i++)
            {
                if (Char.IsDigit(Convert.ToChar(texto.Substring(i, 1))))
                    new_int += texto.Substring(i, 1);
            }

            return Convert.ToInt32(new_int);
        }
    }
}
