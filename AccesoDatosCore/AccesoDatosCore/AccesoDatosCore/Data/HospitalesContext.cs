using AccesoDatosCore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Data
{
    public class HospitalesContext
    {
        String cadenaconexion;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public HospitalesContext(String cadenaconexion)
        {
            this.cadenaconexion = cadenaconexion;
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }
        public List<Hospital> GetHospital(String nombre)
        {
            String sql = "SELECT * FROM HOSPITAL WHERE NOMBRE = @NOMBRE";
            this.com.CommandText = sql;
            SqlParameter parametro = new SqlParameter("@NOMBRE", nombre);
            this.com.Parameters.Add(parametro);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Hospital> hospital = new List<Hospital>();
            while (this.reader.Read())
            {
                Hospital hosp = new Hospital();
                hosp.Direccion = this.reader["DIRECCION"].ToString();
                hosp.Hospital_cod = (int)reader["HOSPITAL_COD"];
                hosp.Telefono = this.reader["TELEFONO"].ToString();
                hosp.Num_cama = this.reader["NUM_CAMA"].ToString();
                hosp.Nombre = this.reader["NOMBRE"].ToString();
                hospital.Add(hosp);
            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return hospital;
        }

    }
}
