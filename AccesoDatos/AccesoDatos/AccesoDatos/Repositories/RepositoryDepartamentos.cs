using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using AccesoDatos.Models;

namespace AccesoDatos.Repositories
{
    public class RepositoryDepartamentos
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;
        private String cadenaconexion;

        //constructor
        public RepositoryDepartamentos()
        {
            //Instaciamos todas las herramientas de la clase
            this.cadenaconexion = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=azure";
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }

        //Creamos los metodos de accion
        public int InsertarDepartamento(int numero, string nombre, string localidad)
        {
            String sqlinsert = "INSERT INTO DEPT VALUES (@NUMERO, @NOMBRE, @LOCALIDAD)";
            SqlParameter parametronumero = new SqlParameter("@NUMERO", numero);
            SqlParameter parametronombre = new SqlParameter("@NOMBRE", nombre);
            SqlParameter parametrolocalidad = new SqlParameter("@LOCALIDAD", localidad);
            //Añadimos los parametros al comando
            this.com.Parameters.Add(parametronumero);
            this.com.Parameters.Add(parametronombre);
            this.com.Parameters.Add(parametrolocalidad);
            //Indicamos al comando su consulta SQL
            this.com.CommandText = sqlinsert;
            //Abrimos la conexion
            this.cn.Open();
            //Ejecutamos la accion
            int resultado = this.com.ExecuteNonQuery();
            //Cerramos la conexion
            this.cn.Close();
            this.com.Parameters.Clear();
            return resultado;
        }
        public int EliminarDepartamento(int deptno)
        {
            String sqldelete = "DELETE FROM DEPT WHERE DEPT_NO=@DEPTNO";
            //CREAMOS EL PARAMETRO
            SqlParameter parametrodeptno = new SqlParameter("DEPTNO", deptno);
            this.com.Parameters.Add(parametrodeptno);
            this.com.CommandText = sqldelete;
            this.cn.Open();
            int result = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return result;
        }
        public int ModificarDepartamento(int deptno, String nombre, string localidad)
        {
            String sqlupdate = "UPDATE DEPT SET DNOMBRE=@DNOMBRE, LOC=@LOC WHERE DEPT_NO=@DEPTNO";
            this.com.CommandText = sqlupdate;
            SqlParameter parametronombre = new SqlParameter("dnombre", nombre);
            SqlParameter parametrodeptno = new SqlParameter("deptno", deptno);
            SqlParameter parametrolocal = new SqlParameter("loc", localidad);
            this.com.Parameters.Add(parametrolocal);
            this.com.Parameters.Add(parametrodeptno);
            this.com.Parameters.Add(parametronombre);
            this.cn.Open();
            int result = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return result;
        }
        //Metodo para buscar por id
        public Departamento BuscarDepartamento(int id)
        {
            String sqlselect = "SELECT * FROM DEPT WHERE DEPT_NO = @DEPTNO";
            this.com.CommandText = sqlselect;
            SqlParameter parametroid = new SqlParameter("DEPTNO", id);
            this.com.Parameters.Add(parametroid);
            this.cn.Open();
            //Ejecutamos la consulta select con el reader
            this.reader = this.com.ExecuteReader();
            //Comprobamos si tiene datos(Si el usuario ha introducido mal las cosas)
            if(this.reader.Read())
            {
                //Creamos un departamento para devolver los datos
                Departamento departamento = new Departamento();
                //Guardamos los datos del reader en nuestro objeto
                departamento.Numero = int.Parse(this.reader["DEPT_NO"].ToString());
                departamento.Nombre = this.reader["DNOMBRE"].ToString();
                departamento.Localidad = this.reader["LOC"].ToString();
                //Cerramos todo
                this.reader.Close();
                this.cn.Close();
                this.com.Parameters.Clear();
                //Devolvermos el objeto en vez de un solo numero, por eso es necesaria la clase de departamento
                return departamento;
            }else
            {
                //Devolvemos un objeto vacio
                return null;
            }
        }
        public List<Departamento> GetDepartamentos()
        {
            String sql = "SELECT * FROM DEPT";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            //Tenemos que devolver una coleccion
            List<Departamento> departamentos = new List<Departamento>();
            while (this.reader.Read())
            {
                //Creamos un objeto por cada fila del read
                Departamento departamento = new Departamento();
                departamento.Numero = (int)this.reader["DEPT_NO"];
                departamento.Nombre = this.reader["DNOMBRE"].ToString();
                departamento.Localidad = this.reader["LOC"].ToString();
                departamentos.Add(departamento);
            }
            this.reader.Close();
            this.cn.Close();
            return departamentos;
        }
    }
}
