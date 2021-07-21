using System;
using System.Collections.Generic;

namespace Logica
{
    class Program
    {

        public static int idade;
        public static string nome;
        public static bool cadastroEfetivado;
        public static string acompanhado;
        public static List<string> participantes = new List<string>();


        //---------------------------------------------MAIN-----------------------------------------------------------------

        static void Main(string[] args)
        {

            string continuar;
            string opcao;

            Console.WriteLine("\nBem vindo ao cadastro de participantes.\n");


            do
            {
                Console.WriteLine("\nInsira a opção desejada: \n\n1 - Cadastrar novo participante;\n2 - Listar participantes cadastrados;\n3 - Encerrar;");
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("\nInsira a opção desejada: \n\n1 - Cadastrar novo participante;\n2 - Listar participantes cadastrados;\n");

                        do
                        {

                            Console.Write("\nPor favor, insira o nome do participante: ");
                            nome = Console.ReadLine().ToUpper();

                            Console.Write($"Por favor, insira a idade de {nome}: ");
                            idade = int.Parse(Console.ReadLine());

                            if (idade < 18)
                            {
                                Console.Write($"\nPor favor, informe se {nome} estará:\n\n1 - Com acompanhante maior de 18 anos;\n2 - Sem acompanhante ");
                                acompanhado = Console.ReadLine();
                            }

                            cadastroEfetivado = CadastrarParticipante(idade, acompanhado);

                            if (cadastroEfetivado == true)
                            {
                                Console.WriteLine("\nCadastro efetivado com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("\nNão foi possível efetivar o seu cadastro. Menores devem estar acompanhados.");
                            }


                            Console.WriteLine("\nDeseja continuar cadastrando?\n1 - Sim;\n2 - Não");
                            continuar = Console.ReadLine();

                        } while (continuar != "2");

                        break;


                    case "2":
                        ListarParticipantes(participantes);

                        break;


                    case "3":
                        Console.WriteLine("Até logo!");

                        break;


                    default:
                        Console.WriteLine("Opção Inválida.");

                        break;
                }


            } while (opcao != "3");

        }



        //-----------------------------------------CADASTRAR PARTICIPANTE------------------------------------------------------------



        public static bool CadastrarParticipante(int _idade, string _acompanhado)
        {


            if (_idade >= 18 || _acompanhado == "1")
            {
                participantes.Add(nome);

                return true;
            }

            return false;
        }



        //----------------------------------------LISTAR PARTICIPANTES--------------------------------------------------------------



        public static void ListarParticipantes(List<string> _participantes)
        {

            if (_participantes.Count > 0)
            {
                int contador = 0;

                foreach (var item in _participantes)
                {
                    contador++;
                    Console.WriteLine($"Nome do {contador}º participante cadastrado: {item}");
                }
            }
            else

                Console.WriteLine("\nA lista ainda não possui nenhum cadastro.");

        }
    }
}
