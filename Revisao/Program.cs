using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            string opcao = Console.ReadLine();
            
            while(opcao.ToUpper() != "X"){
                switch(opcao){
                    case "1":
                        //TODO: Adicionar aluno
                        break;
                    case "2":
                        break;
                    case "3":
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine("Informe a opção desejada!");
                Console.WriteLine("1 - Inserir novo Aluno:");
                Console.WriteLine("2 - Listar alunos:");
                Console.WriteLine("3 - Calcular media geral:");
                Console.WriteLine("x - Sair:");

                opcao = Console.ReadLine();
            }
        }
    }
}
