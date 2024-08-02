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
    public class Exame
    {
        // Propriedades do Construtor Exame
        public int Id { get; set; }
        public string NomeExame { get; set; }
        public int Dias { get; set; }

        //Conexão com o BD
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\Desktop\WS\WS\WS\DbHospital.mdf;Integrated Security=True");

        //Método para Listar os Exames no DataGridView
        public List<Exame> ListarExame()
        {
            List<Exame> li = new List<Exame>();
            string sql = "SELECT * From Exame";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Exame exame = new Exame();
                exame.Id = (int)dr["Id"];
                exame.NomeExame = dr["NomeExame"].ToString();
                exame.Dias = (int)dr["Dias"];
                li.Add(exame);
            }
            conn.Close();
            return li;
        }
        //Método para Cadastrar os Exames
        public void Cadastrar(string nome, int dias)
        {
            try
            {

                string sql = "INSERT INTO Exame(NomeExame,Dias) VALUES('" + nome + "','" + dias + "')";
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
