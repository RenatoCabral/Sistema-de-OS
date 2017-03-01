using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;
using System.Data;

namespace CamadaNegocio
{
    public class NMecanico
    {

        /*Método Inserir*/
        public static string Inserir(string nome, decimal comissao, decimal salario, string acesso, string usuario, string senha)
        {
            DMecanico Obj = new CamadaDados.DMecanico();
            Obj.Nome = nome;
            Obj.Comissao = comissao;
            Obj.Salario = salario;
            Obj.Acesso = acesso;
            Obj.Usuario = usuario;
            Obj.Senha = senha;
            return Obj.Inserir(Obj);
        }

        /*Método Editar*/
        public static string Editar(int idmecanico, string nome, decimal comissao, decimal salario, string acesso, string usuario, string senha)
        {
            DMecanico Obj = new CamadaDados.DMecanico();
            Obj.Idmecanico = idmecanico;
            Obj.Nome = nome;
            Obj.Comissao = comissao;
            Obj.Salario = salario;
            Obj.Acesso = acesso;
            Obj.Usuario = usuario;
            Obj.Senha = senha;
            return Obj.Editar(Obj);
        }

        /*Método Excluir*/
        public static string Excluir(int idmecanico)
        {
            DMecanico Obj = new CamadaDados.DMecanico();
            Obj.Idmecanico = idmecanico;
            return Obj.Excluir(Obj);
        }

        /*Método Mostrar*/
        public static DataTable Mostrar()
        {
            return new DMecanico().Mostrar();
        }

        /*Método Buscar Nome*/
        public static DataTable BuscarNome(string textobuscar)
        {
            DMecanico Obj = new DMecanico();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNome(Obj);
        }
    }
}
