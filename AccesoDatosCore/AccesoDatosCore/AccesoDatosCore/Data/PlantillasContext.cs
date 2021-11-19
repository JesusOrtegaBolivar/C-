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
                plantilla.Salario = (int)reader["SALARIO"];
                plantilla.Funcion = this.reader["FUNCION"].ToString();
                plantilla.Turno = this.reader["T"].ToString();
                datosplantilla.Add(plantilla);
            }
            this.cn.Close();
            this.reader.Close();
            return datosplantilla;
        }
        public List<Plantilla> GetPlantillaTurno(String turno)
        {
            String sql = "select * from PLANTILLA where T = @T";
            this.com.CommandText = sql;
            SqlParameter parametro = new SqlParameter("@T", turno);
            this.com.Parameters.Add(parametro);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Plantilla> listaplantilla = new List<Plantilla>();
            while (this.reader.Read())
            {
                Plantilla plant = new Plantilla();
                plant.Apellido = this.reader["APELLIDO"].ToString();
                plant.Funcion = this.reader["FUNCION"].ToString();
                plant.Turno = this.reader["T"].ToString();
                listaplantilla.Add(plant);
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            if (listaplantilla.Count == 0)
            {
                return null;
            }
            else
            {
                return listaplantilla;
            }
        }
        public List<String> GetFunciones()
        {
            String sql = "SELECT DISTINCT FUNCION FROM PLANTILLA";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<String> listafunciones = new List<string>();
            while (this.reader.Read())
            {
                String funciones = this.reader["FUNCION"].ToString();
                listafunciones.Add(funciones);
            }
            this.reader.Close();
            this.cn.Close();
            return listafunciones;
        }
        public List<Plantilla> GetPlantillaFunciones(String funcion)
        {
            String sql = "SELECT * FROM PLANTILLA WHERE FUNCION = @FUNCION";
            this.com.CommandText = sql;
            SqlParameter fun = new SqlParameter("@FUNCION", funcion);
            this.com.Parameters.Add(fun);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Plantilla> plantilla = new List<Plantilla>();
            while (this.reader.Read())
            {
                Plantilla plant = new Plantilla();
                plant.Apellido = this.reader["APELLIDO"].ToString();
                plant.Funcion = this.reader["FUNCION"].ToString();
                plant.Salario = (int)this.reader["SALARIO"];
                plantilla.Add(plant);
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return plantilla;
        }
        public int UpdatePlantillaFuncion(string funcion, int incremento)
        {
            String sql = "UPDATE PLANTILLA SET SALARIO = SALARIO + @INCREMENTO WHERE FUNCION = @FUNCION";
            this.com.CommandText = sql;
            SqlParameter fun = new SqlParameter("@FUNCION", funcion);
            SqlParameter inc = new SqlParameter("@INCREMENTO", incremento);
            this.com.Parameters.Add(fun);
            this.com.Parameters.Add(inc);
            this.cn.Open();
            int resultado = this.com.ExecuteNonQuery();
            this.com.Parameters.Clear();
            this.cn.Close();
            return resultado;
        }
    }
}
