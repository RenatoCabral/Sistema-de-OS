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
    public partial class frmRelatorioUsuario : Form
    {
        public frmRelatorioUsuario()
        {
            InitializeComponent();
        }

        private void frmRelatorioUsuario_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'SysOSDataSet4.usuario' table. You can move, or remove it, as needed.
            this.usuarioTableAdapter.Fill(this.SysOSDataSet4.usuario);

            this.reportViewer1.RefreshReport();
        }
    }
}
