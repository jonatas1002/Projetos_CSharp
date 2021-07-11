using System;

namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X"){
                switch (opcaoUsuario){
                    case "1":
                        ListaSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar o app :) !!");
            Console.ReadLine();
        }
        private static void VisualizarSerie(){
            int id = GetIdUsuario();
            Console.WriteLine();

            var serie = repositorio.RetornaPorId(id);

            Console.WriteLine(serie); 
        }
        private static void ExcluirSerie(){
            int id = GetIdUsuario();
            Console.WriteLine();

            repositorio.Exclui(id);
        }
        private static void ListaSeries(){
            var lista = repositorio.Lista();
            if(lista.Count == 0){
                Console.WriteLine("Nenhuma serie cadastrada!!");
                return;
            }
            foreach(var serie in lista){
                var excluido = serie.retornaExcluido();
                Console.WriteLine("# ID {0}: - {1}{2}", serie.retornaId(), serie.retornaTitulo(), (excluido? " - *Excluida*": ""));
            }
        }
        private static void InserirSerie(){
            Console.WriteLine("Inserir nova serie:");

            int genero, anoInicio;
            string titulo, descricao;
            InsereDadosSerie(out genero, out titulo, out anoInicio, out descricao);

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)genero, titulo: titulo, ano: anoInicio, descricao: descricao);
            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSeries()
        {
            int id = GetIdUsuario();
            Console.WriteLine();

            int genero, anoInicio;
            string titulo, descricao;
            InsereDadosSerie(out genero, out titulo, out anoInicio, out descricao);

            Serie serieAtualizada = new Serie(id: id, genero: (Genero)genero, titulo: titulo, ano: anoInicio, descricao: descricao);
            repositorio.Atualiza(id, serieAtualizada);
        }

        private static void InsereDadosSerie(out int genero, out string titulo, out int anoInicio, out string descricao)
        {
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero da série:");
            genero = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe o titulo da série:");
            titulo = Console.ReadLine();
            Console.WriteLine("Informe o ano de inicio da série:");
            anoInicio = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite uma descrição da série:");
            descricao = Console.ReadLine();
        }
        private static int GetIdUsuario(){
            Console.WriteLine("Digite o Id da serie:");
            return int.Parse(Console.ReadLine());
            
        }

        private static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Seu repositorio de series: ");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar series:");
            Console.WriteLine("2 - Inserir nova serie:");
            Console.WriteLine("3 - Atualizar serie:");
            Console.WriteLine("4 - Excluir serie:");
            Console.WriteLine("5 - Visualizar serie:");
            Console.WriteLine("C - Limpar tela:");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
