using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamadaApresentacao
{
    public partial class frmPrincipal : Form
    {
        public string IdUsuario = "";
        public string Nome = "";
        public string Acesso = "";


        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Application.Exit();
        }

        private void categoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCategoria f = new frmCategoria();
            f.ShowDialog();
            f.Dispose();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorioCategoria f = new frmRelatorioCategoria();
            f.ShowDialog();
            f.Dispose();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString();
            toolStripStatusLabel3.Text = DateTime.Now.ToShortTimeString();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente f = new frmCliente();
            f.ShowDialog();
            f.Dispose();
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRelatorioCliente f = new frmRelatorioCliente();
            f.ShowDialog();
            f.Dispose();
        }

        private void serviçoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServico f = new frmServico();
            f.ShowDialog();
            f.Dispose();
        }

        private void serviçoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRelatorioServico f = new frmRelatorioServico();
            f.ShowDialog();
            f.Dispose();
        }

        private void mecânicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMecanico f = new frmMecanico();
            f.ShowDialog();
            f.Dispose();
        }

        private void mecânicoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRelatorioMecanico f = new frmRelatorioMecanico();
            f.ShowDialog();
            f.Dispose();
        }

        private void usuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario f = new frmUsuario();
            f.ShowDialog();
            f.Dispose();
        }

        private void usuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRelatorioUsuario f = new frmRelatorioUsuario();
            f.ShowDialog();
            f.Dispose();

        }

        private void GestaoUsuario()
        {
            if(Acesso == "Administrador")
            {
                cadastros.Enabled = true;
                ordemDeServico.Enabled = true;
                relatorios.Enabled = true;
                sair.Enabled = true;
            }else
            {
                cadastros.Enabled = false;
                ordemDeServico.Enabled = false;
                relatorios.Enabled = true;
                sair.Enabled = true;
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            GestaoUsuario();
            lblNome.Text = Nome;
            lblAcesso.Text = Acesso;
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAjuda f = new frmAjuda();
            f.ShowDialog();
            f.Dispose();
        }

        /*atalhos*/
        private void frmPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                /*cad.cliente*/
                case Keys.F1:
                    clienteToolStripMenuItem_Click(sender, e);
                    break;

                /*cad. mecanico*/
                case Keys.F2:
                    mecânicoToolStripMenuItem_Click(sender, e);
                    break;

                /*cad. servico*/
                case Keys.F3:
                    serviçoToolStripMenuItem_Click(sender, e);
                    break;

                /*cad. usuário*/
                case Keys.F4:
                    usuárioToolStripMenuItem_Click(sender, e);
                    break;

                    /*****relatórios*******/

                /*rel. cliente*/
                case Keys.F5:
                    clienteToolStripMenuItem1_Click(sender, e);
                    break;

                /*rel. mecanico*/
                case Keys.F6:
                    mecânicoToolStripMenuItem1_Click(sender, e);
                    break;

                /*rel. servico*/
                case Keys.F7:
                    serviçoToolStripMenuItem1_Click(sender, e);
                    break;

                /*rel. usuario*/
                case Keys.F8:
                    usuárioToolStripMenuItem1_Click(sender, e);
                    break;

                /****Ajuda*****/
                case Keys.F9:
                    ajudaToolStripMenuItem_Click(sender, e);
                    break;

                /*******Sair********/
                case Keys.F10:
                    sairToolStripMenuItem_Click(sender, e);
                    break;
            }
        }
    }
}
