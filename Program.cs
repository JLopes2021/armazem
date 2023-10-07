using System;
using System.Collections.Generic;
using System.Linq;

namespace Armazem
{
    internal class Item
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public Item(string nome, int quantidade)
        {
            Nome = nome;
            Quantidade = quantidade;
        }
    }

    internal class Program
    {
        static List<Item> itens = new List<Item>
        {
            new Item("Escova de Dentes", 100),
            new Item("Creme Dental", 50),
            new Item("Fio Dental", 200),
            new Item("Enxaguante Bucal", 30),
            new Item("Creme para Aftas", 20),
            new Item("Escova Interdental", 40),
            new Item("Fita Dental", 150),
            new Item("Enxaguante com Flúor", 60),
            new Item("Escova Elétrica", 10),
            new Item("Pasta Dental Sensível", 25)
        };

        static DateTime horaAbertura;
        static string senhaPadrao = "padrao";

        static void MostrarItens()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==== Itens no armazém ====");
            foreach (var item in itens)
            {
                Console.WriteLine($"{item.Nome}: {item.Quantidade} unidades");
            }
            Console.ResetColor();
        }
        static void SairSistema()
        {
            Console.WriteLine("Deseja realmente sair do sistema? (s/n)");

            string escolha = Console.ReadLine();

            if (escolha.ToLower() == "s")
            {
                Console.Clear();
                Console.WriteLine("Sistema encerrado. Obrigado!");
                Environment.Exit(0);
            }
            else
            {
                MostrarItens();
            }
        }

        // ...

        static void AdicionarItem()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Digite o nome do item que deseja adicionar: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a quantidade a adicionar: ");
            int quantidade = 0;

            if (!int.TryParse(Console.ReadLine(), out quantidade))
            {
                Console.WriteLine("Quantidade inválida. Tente novamente.");
                Console.ResetColor();
                return;
            }

            foreach (var item in itens)
            {
                if (item.Nome == nome)
                {
                    item.Quantidade += quantidade;
                    return;
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            itens.Add(new Item(nome, quantidade));
            Console.WriteLine($"Item '{nome}' adicionado.");
            Console.ResetColor();

            // Ordena os itens por nome em ordem alfabética
            itens = itens.OrderBy(i => i.Nome).ToList();
        }

        // ...

        static void RemoverItem()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            MostrarItens();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Digite o nome do item que deseja remover: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a quantidade a remover: ");
            int quantidade = 0;

            if (!int.TryParse(Console.ReadLine(), out quantidade))
            {
                Console.WriteLine("Quantidade inválida. Tente novamente.");
                Console.ResetColor();
                return;
            }

            foreach (var item in itens)
            {
                if (item.Nome == nome)
                {
                    if (quantidade <= item.Quantidade)
                    {
                        item.Quantidade -= quantidade;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Quantidade insuficiente.");
                        return;
                    }
                }
            }

            Console.WriteLine("Item não encontrado.");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            horaAbertura = DateTime.Now;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Bem-vindo ao sistema de gerenciamento de estoque. Hora de abertura: {horaAbertura}");
            Console.ResetColor();

            Console.Write("Digite seu nome de usuário: ");
            string username = Console.ReadLine();

            int tentativas = 3;

            while (tentativas > 0)
            {
                Console.Write("Digite sua senha: ");
                string password = Console.ReadLine();

                if (password == senhaPadrao)
                {
                    break;
                }
                else
                {
                    tentativas--;
                    if (tentativas == 0)
                    {
                        Console.WriteLine("Número máximo de tentativas atingido. O programa será encerrado.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"Senha incorreta. Restam {tentativas} tentativas.");
                    }
                }
            }

            while (true)
            {
                Console.WriteLine("\nOpções:");
                Console.WriteLine("1 - Mostrar Itens");
                Console.WriteLine("2 - Adicionar Item");
                Console.WriteLine("3 - Remover Item");
                Console.WriteLine("0 - Sair");

                int escolha = 0;

                if (!int.TryParse(Console.ReadLine(), out escolha))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }

                switch (escolha)
                {
                    case 1:
                        MostrarItens();
                        break;
                    case 2:
                        AdicionarItem();
                        break;
                    case 3:
                        RemoverItem();
                        break;
                    case 0:
                        SairSistema();
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}
