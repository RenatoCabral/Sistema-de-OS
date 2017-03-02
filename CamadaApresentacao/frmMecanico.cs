using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaNegocio;

namespace CamadaApresentacao
{
    public partial class frmMecanico : Form
    {
        private bool eNovo = false;
        private bool eEditar = false;

        public frmMecanico()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtNome, "Informe o nome do mecanico.");
            this.ttMensagem.SetToolTip(this.txtComissao, "Informe a comissão do mecânico.");
            this.ttMensagem.SetToolTip(this.txtSalario, "Informe o salário do mecânico.");

        }

        /*Mensagem de confirmação*/
        private void MensagemOK(string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema OS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /*Mensagem de erro*/
        private void MensagemErro(string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema OS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*Limpar campos*/
        private void Limpar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtNome.Text = string.Empty;
            this.txtComissao.Text = string.Empty;
            this.txtSalario.Text = string.Empty;
            //this.cbbAcesso.Text = string.Empty;
            //this.txtUsuario.Text = string.Empty;
            //this.txtSenha.Text = string.Empty;
        }

        /*Habilitar os text box*/
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNome.ReadOnly = !valor;
            this.txtComissao.ReadOnly = !valor;
            this.txtSalario.ReadOnly = !valor;
           // this.txtUsuario.ReadOnly = !valor;
            //this.txtSenha.ReadOnly = !valor;
            //this.cbbAcesso.Enabled = valor;
        }

        /*Habilitar os botoes*/
        private void Botoes()
        {
            if (this.eNovo || this.eEditar)
            {
                this.Habilitar(true);
                this.btnNovo.Enabled = false;
                this.btnSalvar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
                this.btnSair.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNovo.Enabled = true;
                this.btnSalvar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
                this.btnSair.Enabled = true;

            }
        }

        /*Ocultar colunas no grid*/
        private void OcultarColunas()
        {
            this.dataLista.Columns[0].Visible = false;
            this.dataLista.Columns[1].Visible = false;
        }

        /*Mostrar no Data grid*/
        private void Mostrar()
        {
            this.dataLista.DataSource = NMecanico.Mostrar();
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataLista.Rows.Count);
        }

        /*Buscar pelo Nome*/
        private void BuscarNome()
        {
            this.dataLista.DataSource = NMecanico.BuscarNome(this.txtBuscar.Text);
            this.OcultarColunas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataLista.Rows.Count);
        }

        private void frmMecanico_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(true);
            this.Botoes();
            //this.cbbAcesso.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.eNovo = true;
            this.eEditar = false;
            this.Botoes();
            this.Limpar();
            this.Habilitar(true);
            this.txtNome.Focus();
            
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = "";
                if (this.txtNome.Text == string.Empty)
                {
                    MensagemErro("Preencha todos os campos");
                    errorIcone.SetError(txtNome, "Informe o nome");
                }
                else
                {
                    if (this.eNovo)
                    {
                        resp = NMecanico.Inserir(this.txtNome.Text.Trim(), Convert.ToDecimal(this.txtComissao.Text), Convert.ToDecimal(this.txtSalario.Text));
                    }
                    else
                    {
                        resp = NMecanico.Editar(Convert.ToInt32(this.txtCodigo.Text), this.txtNome.Text.Trim(), Convert.ToDecimal(this.txtComissao.Text), Convert.ToDecimal(this.txtSalario.Text));
                    }

                    if (resp.Equals("OK"))
                    {
                        if (this.eNovo)
                        {
                            this.MensagemOK("Registro salvo com sucesso");
                        }
                        else
                        {
                            this.MensagemOK("Registro editado com sucesso");
                        }
                    }
                    else
                    {
                        this.MensagemErro(resp);
                    }

                    this.eNovo = false;
                    this.eEditar = false;
                    this.Botoes();
                    this.Limpar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.txtCodigo.Text.Equals(""))
            {
                this.MensagemErro("Nenhum registro foi selecionado");
            }
            else
            {
                this.eEditar = true;
                this.Botoes();
                this.Habilitar(true);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.eNovo = false;
            this.eEditar = false;
            this.Botoes();
            this.Limpar();
            this.Habilitar(false);
        }

        private void chkExcluir_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcluir.Checked)
            {
                this.dataLista.Columns[0].Visible = true;
            }
            else
            {
                this.dataLista.Columns[0].Visible = false;
            }
        }

        private void dataLista_DoubleClick(object sender, EventArgs e)
        {
            this.txtCodigo.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["idmecanico"].Value);
            this.txtNome.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["nome"].Value);
            this.txtComissao.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["comissao"].Value);
            this.txtSalario.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["salario"].Value);
            //this.cbbAcesso.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["acesso"].Value);
            //this.txtUsuario.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["usuario"].Value);
            //this.txtSenha.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["senha"].Value);         
            this.tabControl1.SelectedIndex = 0;
        }

        private void dataLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataLista.Columns["Excluir"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletar = (DataGridViewCheckBoxCell)dataLista.Rows[e.RowIndex].Cells["Excluir"];
                ChkDeletar.Value = !Convert.ToBoolean(ChkDeletar.Value);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcao;
                Opcao = MessageBox.Show("Deseja excluir o registro?", "Sistema OS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcao == DialogResult.OK)
                {
                    string Codigo;
                    string Resp = "";

                    foreach (DataGridViewRow row in dataLista.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Resp = NMecanico.Excluir(Convert.ToInt32(Codigo));

                            if (Resp.Equals("OK"))
                            {
                                this.MensagemOK("Registro excluido com sucesso");
                            }
                            else
                            {
                                this.MensagemErro(Resp);
                            }
                        }
                    }
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
