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
    public partial class frmRelatorioMecanico : Form
    {
        public frmRelatorioMecanico()
        {
            InitializeComponent();
        }

        private void frmRelatorioMecanico_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'SysOSDataSet3.mecanico' table. You can move, or remove it, as needed.
            this.mecanicoTableAdapter.Fill(this.SysOSDataSet3.mecanico);

            this.reportViewer1.RefreshReport();
        }
    }
}
