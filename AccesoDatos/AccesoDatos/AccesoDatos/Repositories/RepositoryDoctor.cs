using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using AccesoDatos.Models;

namespace AccesoDatos.Repositories
{
    public class RepositoryDoctor
    {
        //Declaramos las propiedades del objetos, no hace falta geter/seter porque no las vamos a usar desde fuera
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;
        private String cadenaconexion;

        //Constructor de la clase, Iniciamos la conexion cuando instaciamos el objeto
        public RepositoryDoctor()
        {
            this.cadenaconexion = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=azure";
            this.cn = new SqlConnection(cadenaconexion);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.com.CommandType = System.Data.CommandType.Text;
        }
        public int InsertarDoctor(int hospital_cod, int doctor_no, String apellido, String especialidad, int salario)
        {
            String sqlinsert = "INSERT INTO DOCTOR VALUES (@HOSPITAL_COD, @DOCTOR_NO, @APELLIDO, @ESPECIALIDAD, @SALARIO)";
            this.com.CommandText = sqlinsert;
            SqlParameter parahospital = new SqlParameter("@HOSPITAL_COD", hospital_cod);
            SqlParameter paradoctor = new SqlParameter("@DOCTOR_NO",doctor_no);
            SqlParameter paraapellido = new SqlParameter("@APELLIDO", apellido);
            SqlParameter paraespecialidad = new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter parasalario = new SqlParameter("@SALARIO", salario);
            this.cn.Open();
            this.com.Parameters.Add(parahospital);
            this.com.Parameters.Add(paradoctor);
            this.com.Parameters.Add(paraapellido);
            this.com.Parameters.Add(paraespecialidad);
            this.com.Parameters.Add(parasalario);
            int resultado = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return resultado;
        }
        public int EliminarDoctor(int doctor_no)
        {
            String sqldelete = "DELETE FROM DOCTOR WHERE DOCTOR_NO = @DOCTOR_NO";
            this.com.CommandText = sqldelete;
            SqlParameter parametrodoctor = new SqlParameter("@DOCTOR_NO", doctor_no);
            this.cn.Open();
            this.com.Parameters.Add(parametrodoctor);
            int resultado = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return resultado;
        }
        public int ModificarDoctor(int hospital_cod, int doctor_no, String apellido, string especialidad, int salario)
        {
            String sqlupdate = "UPDATE DOCTOR SET HOSPITAL_COD=@HOSPITAL, APELLIDO=@APELLIDO, ESPECIALIDAD=@ESPECIALIDAD, SALARIO=@SALARIO WHERE DOCTOR_NO=@DOCTOR_NO";
            this.com.CommandText = sqlupdate;
            SqlParameter parametrohospital = new SqlParameter("@HOSPITAL", hospital_cod);
            SqlParameter parametroapellido = new SqlParameter("@APELLIDO", apellido);
            SqlParameter parametroespecialidad = new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter parametrosalario = new SqlParameter("@SALARIO", salario);
            SqlParameter parametrodoctor = new SqlParameter("@DOCTOR_NO", doctor_no);
            this.com.Parameters.Add(parametrohospital);
            this.com.Parameters.Add(parametroapellido);
            this.com.Parameters.Add(parametroespecialidad);
            this.com.Parameters.Add(parametrosalario);
            this.com.Parameters.Add(parametrodoctor);
            this.cn.Open();
            int resultado = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return resultado;
        }
        public Doctor BuscarDoctor(int doctor_no)
        {
            String sql = "SELECT * FROM DOCTOR WHERE DOCTOR_NO = @DOCTOR";
            this.com.CommandText = sql;
            SqlParameter parametro = new SqlParameter("@DOCTOR", doctor_no);
            this.cn.Open();
            this.com.Parameters.Add(parametro);
            this.reader = this.com.ExecuteReader();
            if (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.apellido = this.reader["APELLIDO"].ToString();
                doctor.doctor_no = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.hospital_cod = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctor.salario = int.Parse(this.reader["SALARIO"].ToString());
                this.reader.Close();
                this.cn.Close();
                this.com.Parameters.Clear();
                return doctor;
            }
            else
            {
                return null;
            }
        }
        public List<Doctor> GetDoctores()
        {
            String sql = "SELECT * FROM DOCTOR";
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.apellido = this.reader["APELLIDO"].ToString();
                doctor.doctor_no = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.salario = int.Parse(this.reader["SALARIO"].ToString());
                doctor.hospital_cod = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctores.Add(doctor);
            }
            this.reader.Close();
            this.cn.Close();
            return doctores;
        }
    }
}
