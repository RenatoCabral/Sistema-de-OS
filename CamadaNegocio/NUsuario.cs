using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;
using System.Data;

namespace CamadaNegocio
{
    public class NUsuario
    {

        /*Método Inserir*/
        public static string Inserir(string nome, string senha, string acesso)
        {
            DUsuario Obj = new CamadaDados.DUsuario();
            Obj.Nome = nome;
            Obj.Senha = senha;
            Obj.Acesso = acesso;
            return Obj.Inserir(Obj);
        }

        /*Método Editar*/
        public static string Editar(int idusuario, string nome, string senha, string acesso)
        {
            DUsuario Obj = new CamadaDados.DUsuario();
            Obj.Idusuario = idusuario;
            Obj.Nome = nome;
            Obj.Senha = senha;
            Obj.Acesso = acesso;
            return Obj.Editar(Obj);
        }

        /*Método Excluir*/
        public static string Excluir(int idusuario)
        {
            DUsuario Obj = new CamadaDados.DUsuario();
            Obj.Idusuario = idusuario;
            return Obj.Excluir(Obj);
        }

        /*Método Mostrar*/
        public static DataTable Mostrar()
        {
            return new DUsuario().Mostrar();
        }

        /*Método Buscar Nome*/
        public static DataTable BuscarNome(string textobuscar)
        {
            DUsuario Obj = new DUsuario();
            Obj.TextoBuscar = textobuscar;
            return Obj.BuscarNome(Obj);
        }

        /*Método Login*/
        public static DataTable Login(string nome, string senha)
        {
            DUsuario Obj = new DUsuario();
            Obj.Nome = nome;
            Obj.Senha = senha;
            return Obj.Login(Obj);
        }
    }
}
