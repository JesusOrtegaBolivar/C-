using System;
using System.Data.SqlClient;

namespace AccesoDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            MostrarDatosEmpleados();
        }
        static void LeerRegistros() {
            string cadenaConexion = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=azure";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            SqlCommand com = new SqlCommand();
            SqlDataReader reader;
            String consulta = "SELECT * FROM DEPT";
            com.Connection = cn;
            com.CommandText = consulta;
            com.CommandType = System.Data.CommandType.Text;
            cn.Open();
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                String nombre = reader["DNOMBRE"].ToString();
                Console.WriteLine(nombre);
            }
            reader.Close();
            cn.Close();
        }
        static void AccionRegistros()
        {
            string cadenaConexion = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=azure";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            SqlCommand com = new SqlCommand();
            string sql = "InSERT INTO DEPT VALUES (66, 'INFORMATICA', 'MARACENA')";
            com.Connection = cn;
            com.CommandText = sql;
            com.CommandType = System.Data.CommandType.Text;
            cn.Open();
            int insertados = com.ExecuteNonQuery();
            cn.Close();
            Console.WriteLine("Insertados: " + insertados);
        }
        static void EliminarDepartamento()
        {
            string cadenaConexion = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=azure";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            SqlCommand com = new SqlCommand();
            String sql = "DELETE FROM DEPT WHERE DEPT_NO=@NUMERO";
            Console.WriteLine("Numero departmaneto a eliminar");
            int numero = int.Parse(Console.ReadLine());
            SqlParameter pamnumero = new SqlParameter("@NUMERO", numero);
            com.Connection = cn;
            com.CommandText = sql;
            com.CommandType = System.Data.CommandType.Text;
            //Incluimos los parametros dentro del comando
            com.Parameters.Add(pamnumero);
            cn.Open();
            int eliminados = com.ExecuteNonQuery();
            cn.Close();
            //liberamos los parametros del comando
            com.Parameters.Clear();
        }
        static void MostrarDatosEmpleados()
        {
            string cadenaConexion = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=azure";
            SqlConnection conexcion = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            String sql = "SELECT APELLIDO, OFICIO, SALARIO FROM EMP WHERE DEPT_NO=@NUMERO";
            Console.WriteLine("Introduce un numero de departamento");
            int numero = int.Parse(Console.ReadLine());
            SqlParameter parametro = new SqlParameter("@NUMERO", numero);
            comando.Connection = conexcion;
            comando.CommandText = sql;
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.Add(parametro);
            conexcion.Open();
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                String nombre = reader["APELLIDO"].ToString();
                String oficio = reader["OFICIO"].ToString();
                String salario = reader["SALARIO"].ToString();
                Console.WriteLine("Nombre: " + nombre + " Oficio: " + oficio + " Salario: " + salario);

            }
            reader.Close();
            conexcion.Close();
            comando.Parameters.Clear();
        }
    }
}
