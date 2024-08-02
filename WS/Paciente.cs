using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Adicionado a biblioteca que usamos para fazer as strings de conexão e as querys
using System.Data;
using System.Data.SqlClient;

namespace WS
{
    public class Paciente
    {
        // Propriedades do Construtor Paciente
        public int Id { get; set; }
        public string NomePaciente { get; set; }

        public int ExameId { get; set; }
        public string DataRealizarExame { get; set; }
        public string DataExamePronto { get; set; }

        //Conexão com o BD
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\Desktop\WS\WS\WS\DbHospital.mdf;Integrated Security=True");

        //Método para Listar alguns dados dos Pacientes no DataGridView
        public List<Paciente> ListarPaciente()
        {
            List<Paciente> li = new List<Paciente>();
            string sql = "SELECT * From Paciente";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Paciente paciente = new Paciente(); 
                paciente.Id = (int)dr["Id"];
                paciente.NomePaciente = dr["NomePaciente"].ToString();
                paciente.ExameId = (int)dr["ExameId"];
                paciente.DataRealizarExame = dr["DataRealizarExame"].ToString();
                paciente.DataExamePronto = dr["DataExamePronto"].ToString();
                li.Add(paciente);
            }
            conn.Close();
            return li;
        }
        //Método para Cadastrar os pacientes
        public void Cadastrar(string nome, int ExameId, string realizarExame, string ExamePronto)
        {
            try
            {

                string sql = "INSERT INTO Paciente(NomePaciente,ExameId,DataRealizarExame,DataExamePronto) VALUES('" + nome + "','" + ExameId + "','" + realizarExame + "','" + ExamePronto + "')";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception er)
            {
                throw new Exception(er.Message);
            }
            

        }
    }
}
