using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DUsuario
    {
        private int _Idusuario;
        private string _Nome;
        private string _Acesso;
        private string _Senha;
        private string _TextoBuscar;

        public int Idusuario
        {
            get
            {
                return _Idusuario;
            }

            set
            {
                _Idusuario = value;
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
        public DUsuario()
        {

        }

        /*Construtor com parametros*/
        public DUsuario(int idusuario, string nome, string acesso, string senha, string textobuscar)
        {
            this.Idusuario = idusuario;
            this.Nome = nome;
            this.Acesso = acesso;
            this.Senha = senha;
            this.TextoBuscar = textobuscar;

        }


        /**************Métodos**********************/

        /*Método Inserir*/
        public string Inserir(DUsuario Usuario)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdusuario = new SqlParameter();
                ParIdusuario.ParameterName = "@idusuario";
                ParIdusuario.SqlDbType = SqlDbType.Int;
                ParIdusuario.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdusuario);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Usuario.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParSenha = new SqlParameter();
                ParSenha.ParameterName = "@senha";
                ParSenha.SqlDbType = SqlDbType.VarChar;
                ParSenha.Size = 20;
                ParSenha.Value = Usuario.Senha;
                SqlCmd.Parameters.Add(ParSenha);

                SqlParameter ParAcesso = new SqlParameter();
                ParAcesso.ParameterName = "@acesso";
                ParAcesso.SqlDbType = SqlDbType.VarChar;
                ParAcesso.Size = 20;
                ParAcesso.Value = Usuario.Acesso;
                SqlCmd.Parameters.Add(ParAcesso);

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
        public string Editar(DUsuario Usuario)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdusuario = new SqlParameter();
                ParIdusuario.ParameterName = "@idusuario";
                ParIdusuario.SqlDbType = SqlDbType.Int;
                ParIdusuario.Value = Usuario.Idusuario;
                SqlCmd.Parameters.Add(ParIdusuario);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Usuario.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParSenha = new SqlParameter();
                ParSenha.ParameterName = "@senha";
                ParSenha.SqlDbType = SqlDbType.VarChar;
                ParSenha.Size = 20;
                ParSenha.Value = Usuario.Senha;
                SqlCmd.Parameters.Add(ParSenha);

                SqlParameter ParAcesso = new SqlParameter();
                ParAcesso.ParameterName = "@acesso";
                ParAcesso.SqlDbType = SqlDbType.VarChar;
                ParAcesso.Size = 20;
                ParAcesso.Value = Usuario.Acesso;
                SqlCmd.Parameters.Add(ParAcesso);

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
        public string Excluir(DUsuario Usuario)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdeletar_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdusuario = new SqlParameter();
                ParIdusuario.ParameterName = "@idusuario";
                ParIdusuario.SqlDbType = SqlDbType.Int;
                ParIdusuario.Value = Usuario.Idusuario;
                SqlCmd.Parameters.Add(ParIdusuario);

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
            DataTable DtResultado = new DataTable("usuario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_usuario";
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
        public DataTable BuscarNome(DUsuario Usuario)
        {
            DataTable DtResultado = new DataTable("usuario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_nome_usuario";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Usuario.TextoBuscar;
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

        /*Método Login*/
        public DataTable Login(DUsuario Usuario)
        {
            DataTable DtResultado = new DataTable("usuario");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 20;
                ParNome.Value = Usuario.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParSenha = new SqlParameter();
                ParSenha.ParameterName = "@senha";
                ParSenha.SqlDbType = SqlDbType.VarChar;
                ParSenha.Size = 20;
                ParSenha.Value = Usuario.Senha;
                SqlCmd.Parameters.Add(ParSenha);

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
