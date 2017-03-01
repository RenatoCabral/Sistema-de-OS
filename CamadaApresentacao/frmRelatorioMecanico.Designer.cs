namespace CamadaApresentacao
{
    partial class frmRelatorioMecanico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SysOSDataSet3 = new CamadaApresentacao.SysOSDataSet3();
            this.mecanicoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mecanicoTableAdapter = new CamadaApresentacao.SysOSDataSet3TableAdapters.mecanicoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SysOSDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mecanicoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.mecanicoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CamadaApresentacao.rptRelatorioMecanico.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(838, 496);
            this.reportViewer1.TabIndex = 0;
            // 
            // SysOSDataSet3
            // 
            this.SysOSDataSet3.DataSetName = "SysOSDataSet3";
            this.SysOSDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mecanicoBindingSource
            // 
            this.mecanicoBindingSource.DataMember = "mecanico";
            this.mecanicoBindingSource.DataSource = this.SysOSDataSet3;
            // 
            // mecanicoTableAdapter
            // 
            this.mecanicoTableAdapter.ClearBeforeFill = true;
            // 
            // frmRelatorioMecanico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 496);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmRelatorioMecanico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Mecânicos";
            this.Load += new System.EventHandler(this.frmRelatorioMecanico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SysOSDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mecanicoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource mecanicoBindingSource;
        private SysOSDataSet3 SysOSDataSet3;
        private SysOSDataSet3TableAdapters.mecanicoTableAdapter mecanicoTableAdapter;
    }
}