using System;

namespace Novel
{
    class Program
    {
        static NovelRepositorio repositorio = new NovelRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarNovel();
                        break;
                    case "2":
                        InserirNovel();
                        break;
                    case "3":
                        AtualizarNovel();
                        break;
                    case "4":
                        ExcluirNovel();
                        break;
                    case "5":
                        VisualizarNovel();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();                        
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void VisualizarNovel()
        {
            Console.Write("Digite o id da série: ");
            int indiceNovel = int.Parse(Console.ReadLine());

            var novel = repositorio.RetornaPorId(indiceNovel);

            Console.WriteLine(novel);
        }

        private static void ExcluirNovel()
        {
            Console.Write("Digite o id da Novel: ");
            int indiceNovel = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceNovel);
        }

        private static void AtualizarNovel()
        {
            Console.Write("Digite o id da série: ");
            int indiceNovel = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero), i))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Titulo da Novel: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Sinopse da Novel: ");
            string entradaSinopse = Console.ReadLine();

            Console.Write("Digite o Autor da Novel: ");
            string entradaAutor = Console.ReadLine();

            LNovel atualizaNovel = new LNovel(id: indiceNovel,
                                        genero: (Genero)entradaGenero,
                                        ano: entradaAno,
                                        titulo: entradaTitulo,
                                        sinopse: entradaSinopse,
                                        autor: entradaAutor);

             repositorio.Atualiza(atualizaNovel);

        }

        private static void InserirNovel()
        {
            Console.WriteLine("Inserir nova novel");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da novel: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da novel: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a sinopse da novel: ");
            string entradaSinopse = Console.ReadLine();

            Console.Write("Digite o nome do autor da novel");
            string entradaAutor = Console.ReadLine();

            LNovel novaNovel = new LNovel(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        ano: entradaAno,
                                        titulo: entradaTitulo,
                                        sinopse: entradaSinopse,
                                        autor: entradaAutor);

            repositorio.Insere(novaNovel);                            
        }

        private static void ListarNovel()
        {
            Console.WriteLine("Listar novel");
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma novel cadastrada.");
            }

            foreach(var novel in lista)
            {
                var excluido = novel.retornoExcluido();
                
                Console.WriteLine("#ID {0}: - {1} - {2}", novel.retornaId(), novel.retornoTitulo(), (excluido ? "Excluido" : ""));
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("TeleNovel a seu dispor !!!");
            Console.WriteLine("Informe a opcao desejada");

            Console.WriteLine("1- Listar novel");
            Console.WriteLine("2- Inserir nova novel");
            Console.WriteLine("3- Atualizar novel");
            Console.WriteLine("4- Excluir novel");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
