using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DDetalhe_Ordem_Servico
    {
        private int _Iddetalhe_ordem_servico;
        private int _Idordem_servico;
        private int _Idservico;
        private int _Idmecanico;
        private decimal _Total;
        private decimal _Desconto;
        private decimal _Taxa_entrega;
        private string _TextoBuscar;

        public int Iddetalhe_ordem_servico
        {
            get
            {
                return _Iddetalhe_ordem_servico;
            }

            set
            {
                _Iddetalhe_ordem_servico = value;
            }
        }

        public int Idordem_servico
        {
            get
            {
                return _Idordem_servico;
            }

            set
            {
                _Idordem_servico = value;
            }
        }

        public int Idservico
        {
            get
            {
                return _Idservico;
            }

            set
            {
                _Idservico = value;
            }
        }

        public int Idmecanico
        {
            get
            {
                return _Idmecanico;
            }

            set
            {
                _Idmecanico = value;
            }
        }

        public decimal Total
        {
            get
            {
                return _Total;
            }

            set
            {
                _Total = value;
            }
        }

        public decimal Desconto
        {
            get
            {
                return _Desconto;
            }

            set
            {
                _Desconto = value;
            }
        }

        public decimal Taxa_entrega
        {
            get
            {
                return _Taxa_entrega;
            }

            set
            {
                _Taxa_entrega = value;
            }
        }

        public string TextoBuscar
        {
            get
            {
                return _TextoBuscar;
            }

            set
            {
                _TextoBuscar = value;
            }
        }

        /*construtor vazio*/
        public DDetalhe_Ordem_Servico()
        {

        }

        /*construtor com parametros*/
        public DDetalhe_Ordem_Servico(int iddetalhe_ordem_servico, int idordem_servico, int idservico, int idmecanico, decimal total, decimal desconto, decimal taxa_entrega, string textobuscar)
        {
            this.Iddetalhe_ordem_servico = iddetalhe_ordem_servico;
            this.Idordem_servico = idordem_servico;
            this.Idservico = idservico;
            this.Idmecanico = idmecanico;
            this.Total = total;
            this.Desconto = desconto;
            this.Taxa_entrega = taxa_entrega;
            this.TextoBuscar = textobuscar;
        }

        /**************Métodos**********************/

        /*Método Inserir*/
        public string Inserir(DDetalhe_Ordem_Servico Detalhe_Ordem_Servico, ref SqlConnection SqlCon, SqlTransaction SqlTra)
        {
            string resp = "";
            // SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_detalhe_entrada";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIddetalhe_ordem_servico = new SqlParameter();
                ParIddetalhe_ordem_servico.ParameterName = "@iddetalhe_ordem_servico";
                ParIddetalhe_ordem_servico.SqlDbType = SqlDbType.Int;
                ParIddetalhe_ordem_servico.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIddetalhe_ordem_servico);

                SqlParameter ParIdordem_servico = new SqlParameter();
                ParIdordem_servico.ParameterName = "@idordem_servico";
                ParIdordem_servico.SqlDbType = SqlDbType.Int;
                //ParIdordem_servico.Size = 50;
                ParIdordem_servico.Value = Detalhe_Ordem_Servico.Idordem_servico;
                SqlCmd.Parameters.Add(ParIdordem_servico);

                SqlParameter ParIdservico = new SqlParameter();
                ParIdservico.ParameterName = "@idservico";
                ParIdservico.SqlDbType = SqlDbType.Int;
                // ParSenha.Size = 20;
                ParIdservico.Value = Detalhe_Ordem_Servico.Idservico; ;
                SqlCmd.Parameters.Add(ParIdservico);

                SqlParameter ParIdmecanico = new SqlParameter();
                ParIdmecanico.ParameterName = "@idmecanico";
                ParIdmecanico.SqlDbType = SqlDbType.Int;
                // ParSenha.Size = 20;
                ParIdmecanico.Value = Detalhe_Ordem_Servico.Idmecanico; ;
                SqlCmd.Parameters.Add(ParIdmecanico);

                SqlParameter ParTotal = new SqlParameter();
                ParTotal.ParameterName = "@total";
                ParTotal.SqlDbType = SqlDbType.VarChar;
                // ParTotal.Size = 20;
                ParTotal.Value = Detalhe_Ordem_Servico.Total;
                SqlCmd.Parameters.Add(ParTotal);

                SqlParameter ParDesconto = new SqlParameter();
                ParDesconto.ParameterName = "@desconto";
                ParDesconto.SqlDbType = SqlDbType.VarChar;
                // ParTotal.Size = 20;
                ParDesconto.Value = Detalhe_Ordem_Servico.Desconto;
                SqlCmd.Parameters.Add(ParDesconto);

                SqlParameter ParTaxaEntrega = new SqlParameter();
                ParTaxaEntrega.ParameterName = "@taxa_entrega";
                ParTaxaEntrega.SqlDbType = SqlDbType.VarChar;
                // ParTotal.Size = 20;
                ParTaxaEntrega.Value = Detalhe_Ordem_Servico.Taxa_entrega;
                SqlCmd.Parameters.Add(ParTaxaEntrega);

                /*executar o comando*/
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi inserido";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            /*
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            */
            return resp;
        }
    }
}
