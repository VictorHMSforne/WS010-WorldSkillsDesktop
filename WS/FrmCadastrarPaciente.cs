using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WS
{
    public partial class FrmCadastrarPaciente : Form
    {
        public FrmCadastrarPaciente()
        {
            InitializeComponent();
        }
        //Método que carrega o DataGridView
        private void FrmCadastrarPaciente_Load(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente();
            List<Paciente> pacientes = paciente.ListarPaciente();

            dgvPaciente.DataSource = pacientes;

            Exame exame = new Exame();

            foreach (var exames in exame.ListarExame())
            {
                cbxExame.Items.Add(exames.NomeExame);
                cbxExame.DisplayMember = exames.NomeExame;
                cbxExame.ValueMember = exames.Id.ToString();
            }

        }
        //Fecha o Form
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Se os campos estiverem vazios irá exibir uma mensagem de erro!
                if (string.IsNullOrEmpty(txtNome.Text) == true || string.IsNullOrEmpty(cbxExame.Text) == true)
                {
                    MessageBox.Show("Por favor preencha os Campos Vazios", "Campos Vazios!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //Se não o botão irá cadastrar o Paciente
                else
                {
                    Paciente paciente = new Paciente();
                    paciente.Cadastrar(txtNome.Text, Convert.ToInt32(cbxExame.ValueMember),dtpRealizarExame.Value.ToString(), dtpExamePronto.Value.ToString());
                    MessageBox.Show("Paciente Cadastrado", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    List<Paciente> pacientes = paciente.ListarPaciente();

                    dgvPaciente.DataSource = pacientes;
                }
            }
            //Caso ocorra um erro que não foi captado durante o try, irá exibir uma mensagem de Erro
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Evento para Calcular a Data no outro DatePicker

        private void dtpRealizarExame_Leave(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Aluno\Desktop\WS\WS\WS\DbHospital.mdf;Integrated Security=True");
            conn.Open();

            string sql = "SELECT Dias From Exame";
            SqlCommand cmd = new SqlCommand(sql, conn);

            var dias = cmd.ExecuteScalar();
            
            conn.Close();
            dtpExamePronto.Value = dtpRealizarExame.Value.AddDays(Convert.ToDouble(dias));
        }
    }
}
