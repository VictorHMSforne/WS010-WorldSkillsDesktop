using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WS
{
    public partial class FrmCadastroExame : Form
    {
        public FrmCadastroExame()
        {
            InitializeComponent();

        }

        
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Se os campos estiverem vazios irá exibir uma mensagem de erro!
                if (string.IsNullOrEmpty(txtNome.Text) == true || string.IsNullOrEmpty(txtDias.Text) == true)
                {
                    MessageBox.Show("Por favor preencha os Campos Vazios", "Campos Vazios!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //Se não o botão irá cadastrar o Exame
                else
                {
                    Exame exame = new Exame();
                    exame.Cadastrar(txtNome.Text, Convert.ToInt32(txtDias.Text));
                    MessageBox.Show("Exame Cadastrado", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    List<Exame> exames = exame.ListarExame();
                    dgvExames.DataSource = exames;
                }
            }
            //Caso ocorra um erro que não foi captado durante o try, irá exibir uma mensagem de Erro
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Quando o usuário abre o Formulário, irá exibir carregar os dados do banco no DataGridView
        private void FrmCadastroExame_Load(object sender, EventArgs e)
        {
            Exame exame = new Exame();
            List<Exame> exames = exame.ListarExame();

            dgvExames.DataSource = exames;
        }
        // Fecha o Form
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
