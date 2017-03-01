using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DServico
    {
        private int _Idservico;
        private string _Nome;
        private decimal _Preco;
        private string _TextoBuscar;

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

        public string Nome
        {
            get
            {
                return _Nome;
            }

            set
            {
                _Nome = value;
            }
        }

        public decimal Preco
        {
            get
            {
                return _Preco;
            }

            set
            {
                _Preco = value;
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

        /*Construtor vazio*/
        public DServico()
        {

        }

        /*Construtor com parametros*/
        public DServico(int idservico, string nome, decimal preco)
        {
            this.Idservico = idservico;
            this.Nome = nome;
            this.Preco = preco;

        }



        /**************Métodos**********************/

        /*Método Inserir*/
        public string Inserir(DServico Servico)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_servico";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdservico = new SqlParameter();
                ParIdservico.ParameterName = "@idservico";
                ParIdservico.SqlDbType = SqlDbType.Int;
                ParIdservico.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdservico);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 80;
                ParNome.Value = Servico.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParPreco = new SqlParameter();
                ParPreco.ParameterName = "@preco";
                ParPreco.SqlDbType = SqlDbType.Decimal;
                ParPreco.Size = 80;
                ParPreco.Value = Servico.Preco;
                SqlCmd.Parameters.Add(ParPreco);

                /*executar o comando*/
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi inserido";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }

        /*Método Inserir*/
        public string Editar(DServico Servico)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_servico";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdservico = new SqlParameter();
                ParIdservico.ParameterName = "@idservico";
                ParIdservico.SqlDbType = SqlDbType.Int;
                ParIdservico.Value = Servico.Idservico;
                SqlCmd.Parameters.Add(ParIdservico);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 80;
                ParNome.Value = Servico.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParPreco = new SqlParameter();
                ParPreco.ParameterName = "@preco";
                ParPreco.SqlDbType = SqlDbType.Decimal;
                ParPreco.Size = 80;
                ParPreco.Value = Servico.Preco;
                SqlCmd.Parameters.Add(ParPreco);

                /*executar o comando*/
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi editado";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }

        /*Método Inserir*/
        public string Excluir(DServico Servico)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdeletar_servico";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdservico = new SqlParameter();
                ParIdservico.ParameterName = "@idservico";
                ParIdservico.SqlDbType = SqlDbType.Int;
                ParIdservico.Value = Servico.Idservico;
                SqlCmd.Parameters.Add(ParIdservico);

                /*executar o comando*/
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi excluido";
            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }

        /*Método Mostrar*/
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("servico");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_servico";
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        /*Método Buscar pelo Nome*/
        public DataTable BuscarNome(DServico Servico)
        {
            DataTable DtResultado = new DataTable("servico");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_nome_servico";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Servico.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }
    }
}
