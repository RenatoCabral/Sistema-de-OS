using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;
using System.Data;

namespace CamadaNegocio
{
    public class NCliente
    {

        /*Método Inserir*/
        public static string Inserir(string nome, string rua, string numero, string setor, string celular)
        {
            DCliente Obj = new CamadaDados.DCliente();
            Obj.Nome = nome;
            Obj.Rua = rua;
            Obj.Numero = numero;
            Obj.Setor = setor;
            Obj.Celular = celular;
            return Obj.Inserir(Obj);
        }

        /*Método Editar*/
        public static string Editar(int idcliente, string nome, string rua, string numero, string setor, string celular)
        {
            DCliente Obj = new CamadaDados.DCliente();
            Obj.Idcliente = idcliente;
            Obj.Nome = nome;
            Obj.Rua = rua;
            Obj.Numero = numero;
            Obj.Setor = setor;
            Obj.Celular = celular;
            return Obj.Editar(Obj);
        }

        /*Método Excluir*/
        public static string Excluir(int idcliente)
        {
            DCliente Obj = new CamadaDados.DCliente();
            Obj.Idcliente = idcliente;
            return Obj.Excluir(Obj);
        }

        /*Método Mostrar*/
        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        /*Método Buscar Nome*/
        public static DataTable BuscarNome(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNome(Obj);
        }

    }
}
