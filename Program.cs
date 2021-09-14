using System;


namespace Dio.Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio repositorioF = new FilmeRepositorio();
        
        
        static void Main(string[] args)
        {
            string opcaoMenu = ObterOpcaoMenu();

            while(opcaoMenu.ToUpper() != "X")
            {
                switch(opcaoMenu)
                {
                    case "1":
                     string opcaoUsuario = ObterOpcaoUsuario();

                    while(opcaoUsuario.ToUpper() != "X")
                    {
                        switch(opcaoUsuario)
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

                            default :
                            throw new ArgumentOutOfRangeException();
                        }

                            opcaoUsuario = ObterOpcaoUsuario();
                    }

                        Console.WriteLine("\t Obrigado por utilizar nossos servicos.");
                        Console.ReadLine();   
                    
                        break;


                    case "2":
                    string opcaoFilme = ObterOpcaoFilme();

                    while(opcaoFilme.ToUpper() != "X")
                    {
                        switch(opcaoFilme)
                        {
                            case "1":
                            ListarFilmes();
                            break;
                    
                            case "2":
                            InserirFilmes();
                            break; 
                    
                            case "3":
                            AtualizarFilmes();
                            break; 
                    
                            case "4":
                            ExcluirFilmes();
                            break; 
                    
                            case "5":
                            VisualizarFilmes();
                            break; 
                    
                            case "C":
                            Console.Clear();
                            break; 

                            default :
                            throw new ArgumentOutOfRangeException();
                        }

                            opcaoFilme = ObterOpcaoFilme();
                    }

                        Console.WriteLine("\t Obrigado por utilizar nossos servicos.");
                        Console.ReadLine();   
                    
                        break;

                    case "C":
                    Console.Clear();
                    break;

                    default :
                    throw new ArgumentOutOfRangeException();   
                }

                opcaoMenu = ObterOpcaoMenu();
            }

            Console.WriteLine("\t Obrigado por utilizar nossos servicos.");
            Console.ReadLine(); 
            
        }

        
        //Metodo que captura o menu desejado pelo usuario
        private static string ObterOpcaoMenu()
        {
            Console.WriteLine("\n\t Dio Entreterimento a seu dispor!  \n");
            Console.WriteLine("\t Digite qual menu deseja acessar.");
            Console.WriteLine("\t  _____________________________");
            Console.WriteLine("\t |   1 - Menu de Series         |");
            Console.WriteLine("\t |   2 - Menu de Filmes         |");
            Console.WriteLine("\t |   C - Limpar Tela            |");
            Console.WriteLine("\t |   X - Sair                   |");
            Console.WriteLine("\t  ______________________________\n");
            
            string opcaoMenu = Console.ReadLine().ToUpper();            
            return opcaoMenu;
        }


       // -------------------------------------------------------------------------------------------------------------
       
       
        //Metodo para Visualizar as informacoes das Series
        private static void VisualizarSeries()
        {
            Console.WriteLine("\t Insira a ID da serie.\n");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
            Console.WriteLine();
            
        }


        //Metodo para excluir as Series
        private static void ExcluirSeries()
        {
            string confirmacao = "Concordo";
            string verifica;

            Console.WriteLine("\t Insira a ID da serie.\n");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t Voce deseja mesmo excluir essa serie? Digite 'Concordo' para excluir");
            Console.ResetColor();
            verifica = Console.ReadLine();
            Console.WriteLine();
            if(verifica == confirmacao)
            {
                repositorio.Exclui(indiceSerie);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t Serie excluida com exito");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t Mensagem de verificacao incorreta, tente novamente.");
                Console.ResetColor();
                
            }            
            
            Console.WriteLine();

        
        }


        //Metodo para Atualizar as Series
        private static void AtualizarSeries()
        {
            Console.WriteLine("\t Insira a ID da serie.");
            int indiceSerie = int.Parse(Console.ReadLine());
            Console.WriteLine();

            foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("\t |   {0} - {1} ", i, Enum.GetName(typeof(Genero), i));
        }
            Console.WriteLine("\t\n Digite o genero entre as opcoes acima \n");
            int entradaGenero = int.Parse(Console.ReadLine());
            

            Console.WriteLine("\t Digite o titulo da Serie \n");
            string entradaTitulo = Console.ReadLine();
            

            Console.WriteLine("\t Digite o Ano de inicio da Serie \n");
            int entradaAno = int.Parse(Console.ReadLine());
            

            Console.WriteLine("\t Digite a descricao da Serie \n");
            string entradaDescricao = Console.ReadLine();
            
            
            Serie atualizaSerie = new Serie( repositorio.ProximoId(),
                                                    genero: (Genero) entradaGenero,
                                                    titulo: entradaTitulo,
                                                    ano: entradaAno,
                                                    descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t Serie atualizada com exito\n");
            Console.ResetColor();


        }


        // Metodo para Listar as Series
        private static void ListarSeries()
        {
            Console.WriteLine("\t Listar Series\n ");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("\t Nenhuma Serie cadastrada.\n ");
                return;
            }
 
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("\t #ID {0}: - {1} - {2}", serie.retornaId(),serie.retornaTitulo(),(excluido ? "* Exluida *" : ""));
            }
            Console.WriteLine();
        }


        // Metodo para Inserir Series
        public static void InserirSeries()
        {
            Console.WriteLine("\t Insira uma nova serie \n");            

            foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("\t |   {0} - {1} ", i, Enum.GetName(typeof(Genero), i));            
            
        }

            
            Console.WriteLine("\t\n Digite o genero entre as opcoes acima \n");
            int entradaGenero = int.Parse(Console.ReadLine());
                       

            Console.WriteLine("\t Digite o titulo da Serie \n");
            string entradaTitulo = Console.ReadLine();            

            Console.WriteLine("\t Digite o Ano de inicio da Serie \n");
            int entradaAno = int.Parse(Console.ReadLine());            

            Console.WriteLine("\t Digite a descricao da Serie \n");
            string entradaDescricao = Console.ReadLine();            
            
            Serie novaSerie = new Serie( repositorio.ProximoId(),
                                                    genero: (Genero) entradaGenero,
                                                    titulo: entradaTitulo,
                                                    ano: entradaAno,
                                                    descricao: entradaDescricao);

            repositorio.Insere(novaSerie);


        }

        // -----------------------------------------------------------------------------------------------------------------

                
        // Metodo para Inserir Filmes
        public static void InserirFilmes()
        {
            Console.WriteLine("\t Insira um novo filme \n");            

            foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("\t|   {0} - {1}", i, Enum.GetName(typeof(Genero), i));            
            
        }

            Console.WriteLine("\t\n Digite o genero entre as opcoes acima \n");
            int entradaGenero = int.Parse(Console.ReadLine());            

            Console.WriteLine("\t Digite o titulo do Filme \n");
            string entradaTitulo = Console.ReadLine();           

            Console.WriteLine("\t Digite o Ano de lancamento do Filme \n");
            int entradaAno = int.Parse(Console.ReadLine());
            
            Console.WriteLine("\t Digite a descricao do Filme \n");
            string entradaDescricao = Console.ReadLine();
                        
            Filme novoFilme = new Filme( repositorioF.ProximoId(),
                                                    genero: (Genero) entradaGenero,
                                                    titulo: entradaTitulo,
                                                    ano: entradaAno,
                                                    descricao: entradaDescricao);

            repositorioF.Insere(novoFilme);


        }

        // Metodo para Listar os Filmes
        private static void ListarFilmes()
        {
            Console.WriteLine("\t Listar Filmes \n");

            var lista = repositorioF.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("\tNenhum Filme cadastrado. \n");
                return;
            }
 
            foreach(var filme in lista)
            {
                var excluido = filme.retornaExcluido();
                Console.WriteLine("\t #ID {0}: - {1} - {2} \n", filme.retornaId(),filme.retornaTitulo(),(excluido ? "* Exluido *" : ""));
            }
        }
       
       //Metodo para Atualizar os Filmes
        private static void AtualizarFilmes()
        {
            Console.WriteLine("\t Insira a ID do filme. \n");
            int indiceFilme = int.Parse(Console.ReadLine());            

            foreach (int i in Enum.GetValues(typeof(Genero)))
        {
            Console.WriteLine("\t |   {0} - {1} ", i, Enum.GetName(typeof(Genero), i));
        }
            Console.WriteLine("\t\n Digite o genero entre as opcoes acima \n");
            int entradaGenero = int.Parse(Console.ReadLine());            

            Console.WriteLine("\t Digite o titulo do Filme \n");
            string entradaTitulo = Console.ReadLine();            

            Console.WriteLine("\t Digite o Ano de lancamento do Filme \n");
            int entradaAno = int.Parse(Console.ReadLine());            

            Console.WriteLine("\t Digite a descricao do Filme \n");
            string entradaDescricao = Console.ReadLine();
                        
            Filme atualizaFilme = new Filme( repositorioF.ProximoId(),
                                                    genero: (Genero) entradaGenero,
                                                    titulo: entradaTitulo,
                                                    ano: entradaAno,
                                                    descricao: entradaDescricao);

            repositorioF.Atualiza(indiceFilme, atualizaFilme);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t Filme atualizado com exito\n");
            Console.ResetColor();


        }
            
        //Metodo para excluir os Filmes
        private static void ExcluirFilmes()
        {
            string confirmacao = "Concordo";
            string verifica;

            Console.WriteLine("\t Insira o ID do filme. \n");
            int indiceFilme = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tVoce deseja mesmo excluir esse filme? Digite 'Concordo' para excluir");
            Console.ResetColor();            
            verifica = Console.ReadLine();
            Console.WriteLine();
            if(verifica == confirmacao)
            {
                repositorioF.Exclui(indiceFilme);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\t Filme excluido com exito\n");
                Console.ResetColor();                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t Mensagem de verificacao incorreta, tente novamente.\n");
                Console.ResetColor();
                
            }
        }


        //Metodo para Visualizar as informacoes dos Filmes
        private static void VisualizarFilmes()
        {
            Console.WriteLine("\t Insira a ID da serie.\n");
            int indiceFilmes = int.Parse(Console.ReadLine());            

            var filme = repositorioF.RetornaPorId(indiceFilmes);

            Console.WriteLine(filme);
            Console.WriteLine();
            
        }

        // --------------------------------------------------------------------------------------------------------------------


        //Metodo que captura a resposta dos usuarios
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\n\t Dio Series a seu dispor!\n");            
            Console.WriteLine("\t Informe a opcao desejada  ");
            Console.WriteLine("\t _____________________________");

            Console.WriteLine("\t |   1 - Listar Series         |");
            Console.WriteLine("\t |   2 - Inserir nova Serie    |");
            Console.WriteLine("\t |   3 - Atualizar Series      |");
            Console.WriteLine("\t |   4 - Excluir Serie         |");
            Console.WriteLine("\t |   5 - Visualizar Serie      |");
            Console.WriteLine("\t |   C - Limpar Tela           |");
            Console.WriteLine("\t |   X - Sair                  |");
            Console.WriteLine("\t _____________________________\n");

            string opcaoUsuario = Console.ReadLine().ToUpper();            
            return opcaoUsuario;

        }

        private static string ObterOpcaoFilme()
        {
            Console.WriteLine("\n\t Dio Series a seu dispor!\n");
            Console.WriteLine("\t Informe a opcao desejada  ");
            Console.WriteLine("\t _____________________________");

            Console.WriteLine("\t |   1 - Listar Filmes            |");
            Console.WriteLine("\t |   2 - Inserir um novo Filme    |");
            Console.WriteLine("\t |   3 - Atualizar Filmes         |");
            Console.WriteLine("\t |   4 - Excluir Filme            |");
            Console.WriteLine("\t |   5 - Visualizar Filme         |");
            Console.WriteLine("\t |   C - Limpar Tela              |");
            Console.WriteLine("\t |   X - Sair                     |");
            Console.WriteLine("\t ________________________________ \n");

            string opcaoFilme = Console.ReadLine().ToUpper();            
            return opcaoFilme;

        }
    }
}
