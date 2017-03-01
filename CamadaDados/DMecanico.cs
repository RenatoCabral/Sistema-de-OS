using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DMecanico
    {
        private int _Idmecanico;
        private string _Nome;
        private decimal _Comissao;
        private decimal _Salario;
        private string _Acesso;
        private string _Usuario;
        private string _Senha;
        private string _TextoBuscar;

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

        public decimal Comissao
        {
            get
            {
                return _Comissao;
            }

            set
            {
                _Comissao = value;
            }
        }

        public decimal Salario
        {
            get
            {
                return _Salario;
            }

            set
            {
                _Salario = value;
            }
        }

        public string Acesso
        {
            get
            {
                return _Acesso;
            }

            set
            {
                _Acesso = value;
            }
        }

        public string Usuario
        {
            get
            {
                return _Usuario;
            }

            set
            {
                _Usuario = value;
            }
        }

        public string Senha
        {
            get
            {
                return _Senha;
            }

            set
            {
                _Senha = value;
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
        public DMecanico()
        {

        }

        /*Construtor com parametros*/
        public DMecanico(int idmecanico, string nome, decimal comissao, decimal salario, string acesso, string usuario, string senha, string textbuscar)
        {
            this.Idmecanico = idmecanico;
            this.Nome = nome;
            this.Comissao = comissao;
            this.Salario = salario;
            this.Acesso = acesso;
            this.Usuario = usuario;
            this.Senha = senha;
            this.TextoBuscar = textbuscar;
        }


        /****************Métodos**************************/

        /*Método Inserir*/
        public string Inserir(DMecanico Mecanico)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_mecanico";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdmecanico = new SqlParameter();
                ParIdmecanico.ParameterName = "@idmecanico";
                ParIdmecanico.SqlDbType = SqlDbType.Int;
                ParIdmecanico.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdmecanico);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 80;
                ParNome.Value = Mecanico.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParComissao = new SqlParameter();
                ParComissao.ParameterName = "@comissao";
                ParComissao.SqlDbType = SqlDbType.Decimal;
                //ParComissao.Size = 80;
                ParComissao.Value = Mecanico.Comissao;
                SqlCmd.Parameters.Add(ParComissao);

                SqlParameter ParSalario = new SqlParameter();
                ParSalario.ParameterName = "@salario";
                ParSalario.SqlDbType = SqlDbType.Decimal;
                //ParComissao.Size = 80;
                ParSalario.Value = Mecanico.Salario;
                SqlCmd.Parameters.Add(ParSalario);

                SqlParameter ParAcesso = new SqlParameter();
                ParAcesso.ParameterName = "@acesso";
                ParAcesso.SqlDbType = SqlDbType.VarChar;
                ParAcesso.Size = 20;
                ParAcesso.Value = Mecanico.Acesso;
                SqlCmd.Parameters.Add(ParAcesso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Mecanico.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParSenha = new SqlParameter();
                ParSenha.ParameterName = "@senha";
                ParSenha.SqlDbType = SqlDbType.VarChar;
                ParSenha.Size = 20;
                ParSenha.Value = Mecanico.Senha;
                SqlCmd.Parameters.Add(ParSenha);

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

        /*Método Editar*/
        public string Editar(DMecanico Mecanico)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_mecanico";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdmecanico = new SqlParameter();
                ParIdmecanico.ParameterName = "@idmecanico";
                ParIdmecanico.SqlDbType = SqlDbType.Int;
                ParIdmecanico.Value = Mecanico.Idmecanico;
                SqlCmd.Parameters.Add(ParIdmecanico);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 80;
                ParNome.Value = Mecanico.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParComissao = new SqlParameter();
                ParComissao.ParameterName = "@comissao";
                ParComissao.SqlDbType = SqlDbType.Decimal;
                //ParComissao.Size = 80;
                ParComissao.Value = Mecanico.Comissao;
                SqlCmd.Parameters.Add(ParComissao);

                SqlParameter ParSalario = new SqlParameter();
                ParSalario.ParameterName = "@salario";
                ParSalario.SqlDbType = SqlDbType.Decimal;
                //ParComissao.Size = 80;
                ParSalario.Value = Mecanico.Salario;
                SqlCmd.Parameters.Add(ParSalario);

                SqlParameter ParAcesso = new SqlParameter();
                ParAcesso.ParameterName = "@acesso";
                ParAcesso.SqlDbType = SqlDbType.VarChar;
                ParAcesso.Size = 20;
                ParAcesso.Value = Mecanico.Acesso;
                SqlCmd.Parameters.Add(ParAcesso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Mecanico.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParSenha = new SqlParameter();
                ParSenha.ParameterName = "@senha";
                ParSenha.SqlDbType = SqlDbType.VarChar;
                ParSenha.Size = 20;
                ParSenha.Value = Mecanico.Senha;
                SqlCmd.Parameters.Add(ParSenha);

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

        /*Método Excluir*/
        public string Excluir(DMecanico Mecanico)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdeletar_mecanico";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdmecanico = new SqlParameter();
                ParIdmecanico.ParameterName = "@idmecanico";
                ParIdmecanico.SqlDbType = SqlDbType.Int;
                ParIdmecanico.Value = Mecanico.Idmecanico;
                SqlCmd.Parameters.Add(ParIdmecanico);

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
            DataTable DtResultado = new DataTable("mecanico");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_mecanico";
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
        public DataTable BuscarNome(DMecanico Mecanico)
        {
            DataTable DtResultado = new DataTable("mecanico");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_nome_mecanico";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Mecanico.TextoBuscar;
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
