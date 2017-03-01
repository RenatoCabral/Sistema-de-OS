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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            lblHoras.Text = DateTime.Now.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHoras.Text = DateTime.Now.ToString();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            DataTable Dados = CamadaNegocio.NUsuario.Login(txtUser.Text, txtSenha.Text);
            if(Dados.Rows.Count == 0)
            {
                MessageBox.Show("Usuário não existe ou senha incorreto(os).", "Sistema OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                frmPrincipal frp = new frmPrincipal();
                frp.IdUsuario = Dados.Rows[0][0].ToString();
                frp.Nome = Dados.Rows[0][1].ToString();
                frp.Acesso = Dados.Rows[0][2].ToString();
                frp.Show();
                this.Hide();        
            }
        }
    }
}
