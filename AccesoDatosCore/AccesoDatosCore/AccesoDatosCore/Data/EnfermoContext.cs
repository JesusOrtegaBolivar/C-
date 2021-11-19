using AccesoDatosCore.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore.Data
{
    public class EnfermoContext
    {
        String cadenaconexion;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public EnfermoContext(String cadenaconexion)
        {
            this.cadenaconexion = cadenaconexion;
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }
        public List<Enfermo> GetEnfermos()
        {
            String sql = "select * from ENFERMO";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Enfermo> listaenfermos = new List<Enfermo>();
            while (this.reader.Read())
            {
                Enfermo enf = new Enfermo();
                enf.Inscripcion = this.reader["INSCRIPCION"].ToString();
                enf.Apellido = this.reader["APELLIDO"].ToString();
                enf.Direccion = this.reader["DIRECCION"].ToString();
                listaenfermos.Add(enf);
            }
            this.reader.Close();
            this.cn.Close();
            return listaenfermos;
        }
        public int DeleteEnfermos(int inscripcion)
        {
            String sql = "DELETE FROM ENFERMO WHERE INSCRIPCION = @INSCRIPCION";
            this.com.CommandText = sql;
            SqlParameter parametro = new SqlParameter("@INSCRIPCION", inscripcion);
            this.com.Parameters.Add(parametro);
            this.cn.Open();
            int resultado = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return resultado;
        }
    }
}
