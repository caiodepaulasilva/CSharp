using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Agenda
{
    class Program
    {
        static void Main(string[] args)
        {
            Contatos contatos = new Contatos();
            contatos.Controle();
        }
    }

    public class Contatos
    {

        List<Usuário> usuarios = new List<Usuário>();
        Usuário usuário = new Usuário();

        public struct Usuário
        {
            public string name { get; set; }
            public string number { get; set; }
            public string email { get; set; }
            public string group { get; set; }

            public bool Contains(string filtro)
            {
                if (name == filtro || number == filtro || email == filtro || group == filtro) { return true; }
                else { return false; }
            }

            public void NovoContato()
            { Console.WriteLine($"Nome: {name} | Tel: {number} | E-mail: {email} | Grupo: {group}"); }
        }

        public void ApresentarMenu()
        {
            Console.WriteLine("=============== AGENDA ==============");
            Console.WriteLine("\nMENU\n");
            Console.WriteLine("1 - Buscar um contato");
            Console.WriteLine("2 - Adicionar um contato");
            Console.WriteLine("3 - Editar um contato");
            Console.WriteLine("4 - Remover um contato");
            Console.WriteLine("5 - Sair");
        }

        public void Controle()
        {
            while (true)
            {
                Console.Clear();
                ApresentarMenu();

                Console.Write("\nDigite: ");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Buscar();
                        break;
                    case 2:
                        Adicionar();
                        break;
                    case 3:
                        Editar();
                        break;
                    case 4:

                        Remover();
                        break;
                    case 5:
                        Sair();
                        break;

                    default:
                        Console.WriteLine("Serviço Inválido");
                        break;
                }
            }
        }

        public void Buscar()
        {
            Console.WriteLine("\n======================================");
            Console.Write("                Buscar");
            Console.WriteLine("\n======================================");
            Console.Write("Buscar: ");

            string filtro = Console.ReadLine();
            Console.WriteLine("");

            try
            {
                usuário = usuarios[usuarios.FindIndex(usuário => usuário.Contains(filtro))];
                Console.WriteLine($"Nome: {usuário.name}\n" +
                                  $"Telefone: {usuário.number}\n" +
                                  $"E-mail: {usuário.email}\n" +
                                  $"Grupo: {usuário.group}");
            }
            catch { Console.WriteLine("nenhum contato foi encontrado"); }

            Console.WriteLine("======================================\n\n\n");
            Console.Write("Pressione qualquer tecla para continuar");
            Console.ReadLine();
        }

        private void Adicionar()
        {
            Console.WriteLine("\n======================================");
            Console.Write("          Novo Registro");
            Console.WriteLine("\n======================================");
            Console.Write("Nome: ");

            usuário.name = Console.ReadLine();

            Console.Write("Número: ");
            usuário.number = Console.ReadLine();

            Console.Write("E-mail: ");
            usuário.email = Console.ReadLine();

            Console.Write("Grupo: ");
            usuário.group = Console.ReadLine();

            Console.WriteLine("======================================\n\n\n");
            Console.Write("Pressione qualquer tecla para continuar");
            Console.ReadLine();

            usuarios.Add(usuário);
        }

        private void Remover()
        {
            Console.WriteLine("\n======================================");
            Console.Write("                Remover");
            Console.WriteLine("\n======================================");
            Console.Write("Remover: ");

            string filtro = Console.ReadLine();

            try
            {
                usuário = usuarios[usuarios.FindIndex(usuário => usuário.Contains(filtro))];
                Console.WriteLine($"nome: {usuário.name} | tel: {usuário.number} | e-mail: {usuário.email} | grupo: {usuário.group}");
                usuarios.Remove(usuário);
                Console.WriteLine("O contato foi removido!");
            }
            catch { Console.WriteLine("nenhum contato foi encontrado"); }

            Console.WriteLine("======================================\n\n\n");
            Console.Write("Pressione qualquer tecla para continuar");
            Console.ReadLine();
        }

        private void Editar() { Console.WriteLine("Editar Contatos"); }

        private int Sair() { return 0; }
    }
}
