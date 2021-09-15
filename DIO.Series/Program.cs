using System;
using DIO.Series.Enums;
using DIO.Series.Models;
using DIO.Series.Repositories;

namespace DIO.Series
{
    class Program
    {
        public static SerieRepository repository = new SerieRepository();

        static void Main(string[] args)
        {
            var option = GetUserOption();

            while (option.ToUpper() != "X")
            {
                switch (option)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSerie();
                        break;
                    case "3":
                        UpdateSerie();
                        break;
                    case "4":
                        DeleteSerie();
                        break;
                    case "5":
                        VisualizeSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                option = GetUserOption();
            }
        }

        public static void ListSeries()
        {
            Console.WriteLine("Listar Séries");

            var series = repository.FindAll();

            if (series.Count == 0)
            {
                Console.WriteLine("Nenuma série cadastrada!");
            }
            else
            {
                foreach (var serie in series)
                {
                    Console.WriteLine(serie);
                }
            }
        }

        public static void InsertSerie()
        {
            Console.WriteLine("Inserir nova série");

            // foreach (var i in Enum.GetValues((typeof(Genre))))
            // {
            //     Console.WriteLine($"{(int) i}-{Enum.GetName(typeof(Genre), i)}");
            // }

            // Console.Write("Digite o gênero entre as opções acima: ");
            // var genre = int.Parse(Console.ReadLine());

            // Console.Write("Digite o Título da série: ");
            // var title = Console.ReadLine();

            // Console.Write("Digite o ano de início da série: ");
            // var year = int.Parse(Console.ReadLine());

            // Console.Write("Digite a descrição da série: ");
            // var description = Console.ReadLine();

            // var serie = new Serie
            // {
            //     Genre = (Genre) genre,
            //     Title = title,
            //     Description = description,
            //     Year = year
            // };
            var serie = CreateSerie();

            repository.Create(serie);
        }

        public static void UpdateSerie()
        {
            Console.WriteLine("Atualizar Série");

            Console.Write("Digite o Id da série: ");
            var id = int.Parse(Console.ReadLine());

            //foreach (var i in Enum.GetValues((typeof(Genre))))
            //{
            //    Console.WriteLine($"{(int) i}-{Enum.GetName(typeof(Genre), i)}");
            //}

            //Console.Write("Digite o gênero entre as opções acima: ");
            //var genre = int.Parse(Console.ReadLine());

            //Console.Write("Digite o Título da série: ");
            //var title = Console.ReadLine();

            //Console.Write("Digite o ano de início da série: ");
            //var year = int.Parse(Console.ReadLine());

            //Console.Write("Digite a descrição da série: ");
            //var description = Console.ReadLine();

            //var serie = new Serie
            //{
            //    Genre = (Genre) genre,
            //    Title = title,
            //    Description = description,
            //    Year = year
            //};

            var serie = CreateSerie();

            repository.Update(id, serie);
        }

        public static void DeleteSerie()
        {
            Console.Write("Digite o Id da série: ");
            var id = int.Parse(Console.ReadLine());

            repository.Delete(id);
        }

        public static void VisualizeSerie()
        {
            Console.Write("Digite o Id da série: ");
            var id = int.Parse(Console.ReadLine());

            var serie = repository.Find(id);

            if (serie == null)
            {
                Console.WriteLine("Série não encontrada");
            }
            else
            {
                Console.WriteLine(serie);
            }
        }

        public static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine(":.:.:.: Dio Séries :.:.:.:");
            Console.WriteLine("Dio Séries ao seu dispor!!!");

            Console.WriteLine("1. Listar Séries");
            Console.WriteLine("2. Inserir Nova Série");
            Console.WriteLine("3. Atualizar Série");
            Console.WriteLine("4. Excluir Série");
            Console.WriteLine("5. Visualisar Séries");
            Console.WriteLine("C. Limpar Tela");
            Console.WriteLine("X. Sair");
            Console.WriteLine("::::::::::::::::::::::::::");

            var option = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return option;
        }

        private static Serie CreateSerie()
        {
            foreach (var i in Enum.GetValues((typeof(Genre))))
            {
                Console.WriteLine($"{(int) i}-{Enum.GetName(typeof(Genre), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            var genre = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da série: ");
            var title = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            var year = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            var description = Console.ReadLine();

            return new Serie
            {
                Genre = (Genre) genre,
                Title = title,
                Description = description,
                Year = year
            };
        }
    }
}
