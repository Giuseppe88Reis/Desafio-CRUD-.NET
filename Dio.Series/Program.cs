using System;
using Dio.Series.Classes;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            System.Console.WriteLine("Obrigado por usar este aplicativo! S2");
            Console.ReadLine();
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void ListarSeries()
        {
            System.Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                System.Console.WriteLine("Nenhuma Série Encontrada");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                System.Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "*Excluido*" : "");
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void InserirSeries()
        {
            System.Console.WriteLine("Inserir Nova Série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            System.Console.WriteLine();
            System.Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void AtualizarSeries()
        {
            Console.Write("Digite o Id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }

            System.Console.Write("Digite o Gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            System.Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            System.Console.Write("Digite o Gênero entre as opções acima: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                       genero: (Genero)entradaGenero,
                                       titulo: entradaTitulo,
                                       ano: entradaAno,
                                       descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void ExcluirSeries()
        {
            System.Console.Write("Digite o Id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static void VisualizarSeries()
        {
            Console.Write("Digite o Id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            System.Console.WriteLine(serie);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private static string ObterOpcaoUsuario()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Sistema de Séries (Plataforma de Testes)");
            System.Console.WriteLine("Informe a opção desejada");
            System.Console.WriteLine("1 - Listar Séries");
            System.Console.WriteLine("2 - Inserir Nova Série");
            System.Console.WriteLine("3 - Atualizar Série");
            System.Console.WriteLine("4 - Excluir Série");
            System.Console.WriteLine("5 - Visualizar Série");
            System.Console.WriteLine("C - Limpar Tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
