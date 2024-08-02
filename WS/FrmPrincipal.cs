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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCadastrarPaciente_Click(object sender, EventArgs e)
        {
            FrmCadastrarPaciente paciente = new FrmCadastrarPaciente();
            paciente.ShowDialog();
        }

        private void btnCadastrarExame_Click(object sender, EventArgs e)
        {
            FrmCadastroExame exame = new FrmCadastroExame();
            exame.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
