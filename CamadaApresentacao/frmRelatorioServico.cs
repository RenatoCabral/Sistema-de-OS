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
    public partial class frmRelatorioServico : Form
    {
        public frmRelatorioServico()
        {
            InitializeComponent();
        }

        private void frmRelatorioServico_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'SysOSDataSet2.servico' table. You can move, or remove it, as needed.
            this.servicoTableAdapter.Fill(this.SysOSDataSet2.servico);

            this.reportViewer1.RefreshReport();
        }
    }
}
