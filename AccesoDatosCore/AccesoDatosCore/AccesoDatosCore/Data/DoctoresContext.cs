using AccesoDatosCore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Data
{
    public class DoctoresContext
    {
        String cadenaconexion;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public DoctoresContext(String cadenaconexion)
        {
            this.cadenaconexion = cadenaconexion;
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public List<Doctor> GetDoctoresHospital(int codigo)
        {
            String sql = "SELECT * FROM DOCTOR WHERE HOSPITAL_COD = @CODIGO";
            this.com.CommandText = sql;
            SqlParameter parametro = new SqlParameter("@CODIGO", codigo);
            this.com.Parameters.Add(parametro);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doc = new Doctor();
                doc.Apellido = this.reader["APELLIDO"].ToString();
                doc.Doctor_no = this.reader["DOCTOR_NO"].ToString();
                doc.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doc.Hospital_Cod = (int)this.reader["HOSPITAL_COD"];
                doc.Salario = (int)this.reader["SALARIO"];
                doctores.Add(doc);
            }

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return doctores;
        }
    }
}
