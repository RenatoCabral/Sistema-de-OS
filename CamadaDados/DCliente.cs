using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DCliente
    {
        private int _Idcliente;
        private string _Nome;
        private string _Rua;
        private string _Numero;
        private string _Setor;
        private string _Celular;
        private string _TextoBuscar;

        public int Idcliente
        {
            get
            {
                return _Idcliente;
            }

            set
            {
                _Idcliente = value;
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

        public string Rua
        {
            get
            {
                return _Rua;
            }

            set
            {
                _Rua = value;
            }
        }

        public string Numero
        {
            get
            {
                return _Numero;
            }

            set
            {
                _Numero = value;
            }
        }

        public string Setor
        {
            get
            {
                return _Setor;
            }

            set
            {
                _Setor = value;
            }
        }

        public string Celular
        {
            get
            {
                return _Celular;
            }

            set
            {
                _Celular = value;
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


        /*Constutor vazio*/
        public DCliente()
        {

        }

        /*Constutor com parametros*/
        public DCliente(int idcliente, string nome, string rua, string numero, string setor, string celular, string textobuscar)
        {
            this.Idcliente = idcliente;
            this.Nome = nome;
            this.Rua = rua;
            this.Numero = numero;
            this.Setor = setor;
            this.Celular = celular;
            this.TextoBuscar = textobuscar;

        }


        /***************Métodos********************/

        /*Método Inserir*/
        public string Inserir(DCliente Cliente)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinserir_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idcliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdcliente);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 100;
                ParNome.Value = Cliente.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParRua = new SqlParameter();
                ParRua.ParameterName = "@rua";
                ParRua.SqlDbType = SqlDbType.VarChar;
                ParRua.Size = 80;
                ParRua.Value = Cliente.Rua;
                SqlCmd.Parameters.Add(ParRua);

                SqlParameter ParNumero = new SqlParameter();
                ParNumero.ParameterName = "@numero";
                ParNumero.SqlDbType = SqlDbType.VarChar;
                ParNumero.Size = 20;
                ParNumero.Value = Cliente.Numero;
                SqlCmd.Parameters.Add(ParNumero);

                SqlParameter ParSetor = new SqlParameter();
                ParSetor.ParameterName = "@setor";
                ParSetor.SqlDbType = SqlDbType.VarChar;
                ParSetor.Size = 50;
                ParSetor.Value = Cliente.Setor;
                SqlCmd.Parameters.Add(ParSetor);

                SqlParameter ParCelular = new SqlParameter();
                ParCelular.ParameterName = "@celular";
                ParCelular.SqlDbType = SqlDbType.VarChar;
                ParCelular.Size = 20;
                ParCelular.Value = Cliente.Celular;
                SqlCmd.Parameters.Add(ParCelular);

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
        public string Editar(DCliente Cliente)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idcliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Cliente.Idcliente;
                SqlCmd.Parameters.Add(ParIdcliente);

                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 100;
                ParNome.Value = Cliente.Nome;
                SqlCmd.Parameters.Add(ParNome);

                SqlParameter ParRua = new SqlParameter();
                ParRua.ParameterName = "@rua";
                ParRua.SqlDbType = SqlDbType.VarChar;
                ParRua.Size = 80;
                ParRua.Value = Cliente.Rua;
                SqlCmd.Parameters.Add(ParRua);

                SqlParameter ParNumero = new SqlParameter();
                ParNumero.ParameterName = "@numero";
                ParNumero.SqlDbType = SqlDbType.VarChar;
                ParNumero.Size = 20;
                ParNumero.Value = Cliente.Numero;
                SqlCmd.Parameters.Add(ParNumero);

                SqlParameter ParSetor = new SqlParameter();
                ParSetor.ParameterName = "@setor";
                ParSetor.SqlDbType = SqlDbType.VarChar;
                ParSetor.Size = 50;
                ParSetor.Value = Cliente.Setor;
                SqlCmd.Parameters.Add(ParSetor);

                SqlParameter ParCelular = new SqlParameter();
                ParCelular.ParameterName = "@celular";
                ParCelular.SqlDbType = SqlDbType.VarChar;
                ParCelular.Size = 20;
                ParCelular.Value = Cliente.Celular;
                SqlCmd.Parameters.Add(ParCelular);

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
        public string Excluir(DCliente Cliente)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();

                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spdeletar_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdcliente = new SqlParameter();
                ParIdcliente.ParameterName = "@idcliente";
                ParIdcliente.SqlDbType = SqlDbType.Int;
                ParIdcliente.Value = Cliente.Idcliente;
                SqlCmd.Parameters.Add(ParIdcliente);

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
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_cliente";
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

        /*Método Buscar*/
        public DataTable BuscarNome(DCliente Cliente)
        {
            DataTable DtResultado = new DataTable("cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_nome_cliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cliente.TextoBuscar;
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
