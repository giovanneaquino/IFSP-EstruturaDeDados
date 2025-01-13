using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca.Models;

namespace Biblioteca
{
    // Programa Principal
    class Program
    {
        static Livros biblioteca = new Livros();

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Adicionar livro");
                Console.WriteLine("2 - Pesquisar livro (sintético)");
                Console.WriteLine("3 - Pesquisar livro (analítico)");
                Console.WriteLine("4 - Adicionar exemplar");
                Console.WriteLine("5 - Registrar empréstimo");
                Console.WriteLine("6 - Registrar devolução");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        AdicionarLivro();
                        break;
                    case 2:
                        PesquisarLivroSintetico();
                        break;
                    case 3:
                        PesquisarLivroAnalitico();
                        break;
                    case 4:
                        AdicionarExemplar();
                        break;
                    case 5:
                        RegistrarEmprestimo();
                        break;
                    case 6:
                        RegistrarDevolucao();
                        break;
                }

            } while (opcao != 0);
        }

        static void AdicionarLivro()
        {
            Console.Write("ISBN: ");
            int isbn = int.Parse(Console.ReadLine());

            Console.Write("Título: ");
            string titulo = Console.ReadLine();

            Console.Write("Autor: ");
            string autor = Console.ReadLine();

            Console.Write("Editora: ");
            string editora = Console.ReadLine();

            Livro livro = new Livro { Isbn = isbn, Titulo = titulo, Autor = autor, Editora = editora };
            biblioteca.Adicionar(livro);
            Console.WriteLine("Livro adicionado com sucesso!");
        }

        static void PesquisarLivroSintetico()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Editora: {livro.Editora}");
                Console.WriteLine($"Exemplares: {livro.QtdeExemplares()}, Disponíveis: {livro.QtdeDisponiveis()}, Empréstimos: {livro.QtdeEmprestimos()}");
                Console.WriteLine($"Percentual de Disponibilidade: {livro.PercDisponibilidade()}%");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void PesquisarLivroAnalitico()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Editora: {livro.Editora}");
                Console.WriteLine($"Exemplares: {livro.QtdeExemplares()}, Disponíveis: {livro.QtdeDisponiveis()}, Empréstimos: {livro.QtdeEmprestimos()}");
                Console.WriteLine($"Percentual de Disponibilidade: {livro.PercDisponibilidade()}%");

                foreach (var exemplar in livro.Exemplares)
                {
                    Console.WriteLine($"Exemplar Tombo: {exemplar.Tombo}, Disponível: {exemplar.Disponivel()}, Empréstimos: {exemplar.QtdeEmprestimos()}");
                    foreach (var emprestimo in exemplar.Emprestimos)
                    {
                        Console.WriteLine($"  Empréstimo em: {emprestimo.DtEmprestimo}, Devolução: {emprestimo.DtDevolucao}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void AdicionarExemplar()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Console.Write("Informe o tombo do exemplar: ");
                int tombo = int.Parse(Console.ReadLine());

                Exemplar exemplar = new Exemplar { Tombo = tombo };
                livro.AdicionarExemplar(exemplar);
                Console.WriteLine("Exemplar adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void RegistrarEmprestimo()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Exemplar exemplar = livro.Exemplares.FirstOrDefault(e => e.Disponivel());
                if (exemplar != null && exemplar.Emprestar())
                {
                    Console.WriteLine("Empréstimo registrado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Nenhum exemplar disponível para empréstimo.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }

        static void RegistrarDevolucao()
        {
            Console.Write("Informe o ISBN do livro: ");
            int isbn = int.Parse(Console.ReadLine());

            Livro livro = biblioteca.Pesquisar(isbn);
            if (livro != null)
            {
                Exemplar exemplar = livro.Exemplares.FirstOrDefault(e => !e.Disponivel());
                if (exemplar != null && exemplar.Devolver())
                {
                    Console.WriteLine("Devolução registrada com sucesso!");
                }
                else
                {
                    Console.WriteLine("Nenhum exemplar emprestado encontrado para devolução.");
                }
            }
            else
            {
                Console.WriteLine("Livro não encontrado.");
            }
        }
    }
}
