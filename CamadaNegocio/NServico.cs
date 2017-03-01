using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;
using System.Data;

namespace CamadaNegocio
{
    public class NServico
    {
        /*Método Inserir*/
        public static string Inserir(string nome, decimal preco)
        {
            DServico Obj = new CamadaDados.DServico();
            Obj.Nome = nome;
            Obj.Preco = preco;
            return Obj.Inserir(Obj);
        }

        /*Método Editar*/
        public static string Editar(int idservico, string nome, decimal preco)
        {
            DServico Obj = new CamadaDados.DServico();
            Obj.Idservico = idservico;
            Obj.Nome = nome;
            Obj.Preco = preco;
            return Obj.Editar(Obj);
        }

        /*Método Excluir*/
        public static string Excluir(int idservico)
        {
            DServico Obj = new CamadaDados.DServico();
            Obj.Idservico = idservico;
            return Obj.Excluir(Obj);
        }

        /*Método Mostrar*/
        public static DataTable Mostrar()
        {
            return new DServico().Mostrar();
        }

        /*Método Buscar Nome*/
        public static DataTable BuscarNome(string textobuscar)
        {
            DServico Obj = new DServico();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNome(Obj);
        }
    }
}
