using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AccesoDatosCore.Models;

namespace AccesoDatosCore.Data
{
    public class EmpleadosContext
    {
        String cadenaconexion;
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public EmpleadosContext(String cadenaconexion)
        {
            this.cadenaconexion = cadenaconexion;
            this.cn = new SqlConnection(this.cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        public List<Empleado> GetEmpleados()
        {
            String sql = "SELECT * FROM EMP";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();

            List<Empleado> empleados = new List<Empleado>();
            while (this.reader.Read())
            {
                Empleado emp = new Empleado();
                emp.Apellido = this.reader["APELLIDO"].ToString();
                emp.IdEmpleado = (int)this.reader["EMP_NO"];
                emp.Oficio = this.reader["OFICIO"].ToString();
                emp.Salario = (int)this.reader["SALARIO"];
                empleados.Add(emp);
            }
            this.reader.Close();
            this.cn.Close();
            return empleados;
        }
        public Empleado BuscarEmpleado(int idempleado)
        {
            String sql = "SELECT * FROM EMP WHERE EMP_NO=@empno";
            this.com.CommandText = sql;
            this.cn.Open();
            SqlParameter paremp = new SqlParameter("@empno", idempleado);
            this.com.Parameters.Add(paremp);
            this.reader = this.com.ExecuteReader();

            Empleado empleado;
            if (this.reader.Read())
            {
                empleado = new Empleado();
                empleado.IdEmpleado = (int)this.reader["EMP_NO"];
                empleado.Apellido = this.reader["APELLIDO"].ToString();
                empleado.Oficio = this.reader["OFICIO"].ToString();
                empleado.Salario = (int)this.reader["SALARIO"];
            }
            else
            {
                empleado = null;
            }
            this.cn.Close();
            this.reader.Close();
            this.com.Parameters.Clear();
            return empleado;
        }
        public List<Empleado> GetEmpleadosSalario(int salario)
        {
            List<Empleado> listaempleados = new List<Empleado>();
            String sql = "SELECT * FROM EMP WHERE SALARIO > @SALARIO";
            this.com.CommandText = sql;
            SqlParameter parametro = new SqlParameter("@SALARIO", salario);
            this.com.Parameters.Add(parametro);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            while (this.reader.Read())
            {
                Empleado emp = new Empleado();
                emp.Apellido = this.reader["APELLIDO"].ToString();
                emp.Salario = (int)this.reader["SALARIO"];
                emp.Oficio = this.reader["OFICIO"].ToString();
                listaempleados.Add(emp);
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            if(listaempleados.Count == 0)
            {
                return null;
            }else
            {
                return listaempleados;
            }
        }
        public List<String> GetOficio()
        {
            String sql = "SELECT distinct OFICIO FROM EMP";
            this.cn.Open();
            this.com.CommandText = sql;
            this.reader = this.com.ExecuteReader();
            List<String> oficios = new List<string>();
            while (this.reader.Read())
            {
                String oficio = this.reader["OFICIO"].ToString();
                oficios.Add(oficio);
            }
            this.reader.Close();
            this.cn.Close();
            return oficios;
        }
        public List<Empleado> GetEmpleadosOficio(String oficio)
        {
            String sql = "SELECT * FROM EMP where OFICIO = @oficio";
            this.com.CommandText = sql;
            SqlParameter parametro = new SqlParameter("OFICIO", oficio);
            this.com.Parameters.Add(parametro);
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Empleado> empleadosoficio = new List<Empleado>();
            while (this.reader.Read())
            {
                Empleado emp = new Empleado();
                emp.Apellido = this.reader["APELLIDO"].ToString();
                emp.Oficio = this.reader["OFICIO"].ToString();
                emp.Salario = (int)this.reader["SALARIO"];
                empleadosoficio.Add(emp);
            }
            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return empleadosoficio;
        }
        public int IncrementarSalarioEmpleado(int idempleado, int incremento)
        {
            String sql = "UPDATE EMP SET SALARIO = SALARIO + @INCREMENTO WHERE EMP_NO = @IDEMPLEADO";
            this.com.CommandText = sql;
            this.cn.Open();
            SqlParameter salario = new SqlParameter("@INCREMENTO", incremento);
            SqlParameter empleado = new SqlParameter("@IDEMPLEADO", idempleado);
            this.com.Parameters.Add(salario);
            this.com.Parameters.Add(empleado);
            this.cn.Open();
            int resultado = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return resultado;
        }

    }
}
