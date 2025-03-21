using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


class Program
{
    // Lista de Usuarios cadastrados.
    static List<Usuario> usuarios = new List<Usuario>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== Menu =====");
            Console.WriteLine("1 - Cadastrar Usuário");
            Console.WriteLine("2 - Listar Usuários");
            Console.WriteLine("3 - Buscar Usuário");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarUsuario();
                    break;
                case "2":
                    ListarUsuarios();
                    break;
                case "3":
                    BuscarUsuario();
                    break;
                case "4":
                    Console.WriteLine("Saindo do programa...");
                   return;
                default:
                    Console.WriteLine("Opção inválida! Tente novamente.");
                    break;
            }
        }
    }
 
    // Cadastramento de Usuario
    static void CadastrarUsuario()
    {
        String regex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine() ?? "";

        Console.Write("Digite seu e-mail: ");
        string email = Console.ReadLine() ?? "";

        // Validação para checar se o email estar na formataçao certa.
        if (!Regex.IsMatch(email, regex )){
            Console.Write("Email invalido");
            return;
        }

        Console.Write("Digite sua idade: ");
        if (int.TryParse(Console.ReadLine(), out int idade))
        {
            usuarios.Add(new Usuario(nome, email, idade));
            Console.WriteLine("Usuário cadastrado com sucesso!");
        }
        else
        {
            Console.WriteLine("Idade inválida, cadastro cancelado.");
        }
    }

     // retorna a lista de usuarios
    static void ListarUsuarios()
    {
        if (usuarios.Count == 0)
        {
            Console.WriteLine("Nenhum usuário cadastrado.");
            return;
        }

        Console.WriteLine("======== Lista de Usuários ========");

        foreach (var usuario in usuarios)
        {
            Console.WriteLine($"Nome: {usuario.GetNome()}, E-mail: {usuario.GetEmail()}, Idade: {usuario.GetIdade()}");
        }
    }
     // faz a busca de usuarios na Lista
    static void BuscarUsuario()
    {
        Console.Write("\nDigite o nome do usuário a ser buscado: ");
        string nomeBusca = Console.ReadLine() ?.ToLower();

        var usuarioEncontrado = usuarios.FirstOrDefault(u => u.GetNome().Equals(nomeBusca, StringComparison.OrdinalIgnoreCase));

        if (usuarioEncontrado != null)
        {
            Console.WriteLine($"\nUsuário encontrado: Nome: {usuarioEncontrado.GetNome()}, E-mail: {usuarioEncontrado.GetEmail()}, Idade: {usuarioEncontrado.GetIdade()}");
        }
        else
        {
            Console.WriteLine("Usuário não encontrado.");
        }
    }
}