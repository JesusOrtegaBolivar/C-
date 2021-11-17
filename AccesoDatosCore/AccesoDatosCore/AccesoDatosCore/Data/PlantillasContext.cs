using AccesoDatosCore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Data
{
    public class PlantillasContext
    {
        String cadenaconexion;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public PlantillasContext(String cadenaconexion)
        {
            this.cadenaconexion = cadenaconexion;
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }
        public List<Plantilla> GetPlantillas()
        {
            List<Plantilla> datosplantilla = new List<Plantilla>();
            String sql = "SELECT * FROM PLANTILLA";
            this.cn.Open();
            this.com.CommandText = sql;
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                Plantilla plantilla = new Plantilla();
                plantilla.Apellido = this.reader["APELLIDO"].ToString();
                plantilla.Salario = this.reader["SALARIO"].ToString();
                plantilla.Funcion = this.reader["FUNCION"].ToString();
                plantilla.Turno = this.reader["T"].ToString();
                datosplantilla.Add(plantilla);
            }
            this.cn.Close();
            this.reader.Close();
            return datosplantilla;
        }
    }
}
