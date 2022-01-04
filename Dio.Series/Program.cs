using System;
namespace DIO.Series
{
    class program {
       
       static SerieRepositório repositório = new SerieRepositório();

        static void Main(string [] args)
    {
        string opcaoUsuario = ObterOpcaoUsuario();

        while (opcaoUsuario.ToUpper() != 'x')
        {
            switch (opcaoUsuario)
            {
                case '1':
                    listaSerie();
                    break;
                
                 case '2':
                    InserirSerie();
                    break;

                 case '3':
                    AtualizarSerie();
                    break;

                 case '4':
                    ExcluirSerie();
                    break;

                 case '5':
                    VisulizarSerie();
                    break;

                case 'C':
                    Console.Clear();
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();

            }

        }
        
           
        

        
    }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositório.lista();

            if (lista.count == 0)
            {
                Console.WriteLine("nenhumaa série cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("ID (0): - (1)", serie.retornaId(), serie.retornaTutulo());
            }

        }

         private static void ExcluiSeries()
        {
            Console.WriteLine("Digite o id da serie");
              int indicaSerie = int.Parse(Console.ReadLine());

              repositório.Exclui(indicaSerie);

        }

         private static void VisualizarSeries()
        {
            Console.WriteLine("Digite o id da serie");
              int indicaSerie = int.Parse(Console.ReadLine());

              var serie = repositório.RetornaPorId(indicaSerie);

             Console.WriteLine(serie);

        }
         private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série:");
             int indicaSerie = int.Parse(Console.ReadLine());
           
            foreach (int i in Enum.GetValues(typeof(Genero)))
             {
                 Console.WriteLine("(0): - (1)", i, Enum.GetName(typeof(Genero), i)); 
             }

             Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indicaSerie,
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);


            repositório.atualiza(indicaSerie, atualizaSerie);
            
            
        }
        private static void InserirSeries()
        {
            Console.WriteLine("Inserir nova Série");
             foreach (int i in Enum.GetValues(typeof(Genero)))
             {
                 Console.WriteLine("(0): - (1)", i, Enum.GetName(typeof(Genero), i)); 
             }
            
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositório.ProximoId(),
            genero: (Genero)entradaGenero,
            titulo: entradaTitulo,
            ano: entradaAno,
            descricao: entradaDescricao);


            repositório.Insere(novaSerie); 

        }
        private static string ObterOpcaoUsuario()
        {
           Console.WriteLine();
           Console.WriteLine("Dio Séries a seu Dispor !!!");
           Console.WriteLine("Informar a opção desejada: ");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir Nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("x- Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
