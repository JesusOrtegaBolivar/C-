using DepartamentosCoreCrud.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DepartamentosCoreCrud.Data
{
    public class DepartamentosContext
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public DepartamentosContext(String cadenaconexion)
        {
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public List<Departamento> GetDepartamentos()
        {
            String sql = "SELECT * FROM DEPT";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Departamento> listadepartamentos = new List<Departamento>();
            while (this.reader.Read())
            {
                Departamento depar = new Departamento();
                depar.Localidad = this.reader["LOC"].ToString();
                depar.Nombre = this.reader["DNOMBRE"].ToString();
                depar.Numero = int.Parse(this.reader["DEPT_NO"].ToString());
                listadepartamentos.Add(depar);
            }
            this.reader.Close();
            this.cn.Close();
            return listadepartamentos;
        }

        public Departamento FindDepartamento (int iddepartamento)
        {
            String sql = "Select * from dept where dept_no = @NUMERO";
            this.com.CommandText = sql;
            SqlParameter parametronumero = new SqlParameter("@NUMERO", iddepartamento);
            this.com.Parameters.Add(parametronumero);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            Departamento depar = new Departamento();
            this.reader.Read();
            depar.Localidad = this.reader["LOC"].ToString();
            depar.Nombre = this.reader["DNOMBRE"].ToString();
            depar.Numero = int.Parse(this.reader["DEPT_NO"].ToString());
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return depar;
        }

        public int InsertDepartamento(int iddepartamento, String nombre, String localidad)
        {
            String sql = "INSERT INTO DEPT VALUES (@ID, @DNOMBRE, @LOC)";
            this.com.CommandText = sql;
            SqlParameter pamid = new SqlParameter("@ID", iddepartamento);
            SqlParameter pamnombre = new SqlParameter("@DNOMBRE", nombre);
            SqlParameter pamlocal = new SqlParameter("@LOC", localidad);
            this.com.Parameters.Add(pamid);
            this.com.Parameters.Add(pamnombre);
            this.com.Parameters.Add(pamlocal);
            this.cn.Open();
            int insertados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return insertados;
        }

        public int DeleteDepartamento(int iddepartamento)
        {
            String sql = "DELETE FROM DEPT WHERE DEPT_NO = @ID";
            this.com.CommandText = sql;
            SqlParameter pamid = new SqlParameter("@ID", iddepartamento);
            this.com.Parameters.Add(pamid);
            this.cn.Open();
            int eliminados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return eliminados;
        }

        public int UpdateDepartamento(int iddepartamento, String nombre, String localidad)
        {
            String sql = "UPDATE DEPT SET DNOMBRE=@NOMBRE, LOC=@LOCALIDAD WHERE DEPT_NO=@ID";
            this.com.CommandText = sql;
            SqlParameter pamid = new SqlParameter("@ID", iddepartamento);
            SqlParameter pamnombre = new SqlParameter("@NOMBRE", nombre);
            SqlParameter pamlocal = new SqlParameter("@LOCALIDAD", localidad);
            this.com.Parameters.Add(pamid);
            this.com.Parameters.Add(pamnombre);
            this.com.Parameters.Add(pamlocal);
            this.cn.Open();
            int modificados = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return modificados;
        }
    }
}
