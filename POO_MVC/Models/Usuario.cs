//---------------------------------------------------SUPERCLASSE ABSTRATA-----------------------------------------------------

using System.Collections.Generic;
using System.IO;

namespace POO_MVC.Models
{
    public abstract class Usuario : RockInSenaiBase
    {
        private string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        private string Senha { get; set; }
        private string NumeroDeMusico { get; set; }




        //---------------------------CONSTANTES DA CLASSE-----------------------------------------

        private const string CAMINHO = "DataBase/Usuario.csv";  //  Constante que define o local onde o arquivo csv será criado




        //---------------------------METODOS CONTRUTORES----------------------------------------

        //  Metodo herdado da superclasse Base, que recebe como parametro a constante CAMINHO definida acima e cria automaticamente um arquivo csv, onde serão salvos os dados do usuarios
        public Usuario()
        {
            CriarPastaEArquivo(CAMINHO);
        }











        //---------------------------METODOS DA CLASSE-----------------------------------------


        //Metodo auxiliar do metodo Criar (abaixo). Converte os atributos do usuario recebido como parametro em string, que será retornada utilizando caracter de separação especifico (no caso, ;)
        public string Preparar(Usuario aConverter)
        {
            
            return $"{aConverter.Id};{aConverter.Nome};{aConverter.Email};{aConverter.Senha};{aConverter.NumeroDeMusico}";
        }




        //Acrescenta (dados do)usuario ao arquivo csv;
        //Como este metodo recebe um objeto e as informações dos usuarios estão salvas em um arquivo do tipo csv, é necessário antes converter o csv para objeto. Só assim o metodo Criar() irá funcionar corretamente. Para isso, utilizamos o metodo PREPARAR, acima.
        //Em seguida, é necessário criar um array de string onde o objeto convertido em string atraves do metodo Preparar será armazenado.
        //Utilizando o método AppendAllLines, o array criado (e fornecido como parametro "linha") será acrescentado ao caminho, também informado como parametro
        public void Criar(Usuario _novo)
        {
            string[] linha = { Preparar(_novo) };

            File.AppendAllLines(CAMINHO, linha);
        }



        //-----------------------------------------------------------------------------------------



        //Ao contrário do método Criar, que converte objetos em dados para alimentar o arquivo csv, este faz a leitura do csv e converte seus dados (string) em objeto novamente;
        //O conteudo lido deve ser transformado em uma lista de objetos Usuario, que será retornada pelo método.
        public List<Usuario> LerTodosUsuarios()
        {
            List<Usuario> listaDeUsuarios = new List<Usuario>();

            string[] arrayDeLinhas = File.ReadAllLines(CAMINHO);

            foreach (var cadaLinha in arrayDeLinhas)
            {
                string[] atributosEmCadaLinha = cadaLinha.Split(";");

                // {aConverter.Id};{aConverter.Nome};{aConverter.Email};{aConverter.Senha};{aConverter.NumeroDeMusico}";

                Id = atributosEmCadaLinha[0];
                Nome = atributosEmCadaLinha[1];
                Email = atributosEmCadaLinha[2];
                Senha = atributosEmCadaLinha[3];
                NumeroDeMusico = atributosEmCadaLinha[4];
                

                //listaDeUsuarios.Add(cadaUsuarioDaLista);                  PAREI AQUI, DESCOMENTAR AQUI E 115
            }

            return listaDeUsuarios;
        }




        //-----------------------------------------------------------------------------------------




        //  Para fazer qualquer alteração em um atributo da lista de objetos, devemos ler o arquivo csv, copiar seu conteudo completo em uma lista, indicar um parametro de referencia que identifique o objeto a ser removido da lista, adicionar o novo objeto com as alterações corretas e por fim salvar a nova lista atualizada no arquivo csv. Por isso, criamos os metodos de LER e REESCREVER na superclasse base e os herdamos nas classes onde serão utilizados, visto que o processo de alteração se repetirá em todas as classes
        public void Alterar(Usuario usuarioJaContendoAlteracoesParaSalvar)
        {
            List<string> listaComConteudoDoArquivoCSV = LerTodasLinhasCSV(CAMINHO);

            //Remove um determinado objeto da lista utilizando expressão lambda referenciada pelo Id do usuario para localiza-lo na lista
    //DESCOMENTAR        listaComConteudoDoArquivoCSV.RemoveAll(cadaAtributoNaLinha => cadaAtributoNaLinha.Split(";")[0] == usuarioJaContendoAlteracoesParaSalvar.IdUsuario.ToString());

            //Adiciona o novo objeto com alterações à lista utilizando o metodo Preparar(), que antes o converte para string conforme exigencia do metodo Add
            listaComConteudoDoArquivoCSV.Add(Preparar(usuarioJaContendoAlteracoesParaSalvar));

            //Reescreve o csv utilizando a lista atualizada acima
            ReescreverCSV(CAMINHO, listaComConteudoDoArquivoCSV);
        }



        //-----------------------------------------------------------------------------------------




        // Metodo para remover um usuario tendo por referencia seu Id. O metodo possui praticamente o mesmo funcionamento logico do Alterar() acima, porem sem adição de atualizações;
        public void Deletar(int idDoUsuarioADeletar)
        {
            List<string> listaComConteudoDoArquivoCSV = LerTodasLinhasCSV(CAMINHO);

            //Remove um determinado objeto da lista utilizando expressão lambda referenciada pelo Id do usuario para localiza-lo na lista
            listaComConteudoDoArquivoCSV.RemoveAll(cadaAtributoNaLinha => cadaAtributoNaLinha.Split(";")[0] == idDoUsuarioADeletar.ToString());


            //Reescreve o csv utilizando a lista atualizada acima, já sem o objeto removido
            ReescreverCSV(CAMINHO, listaComConteudoDoArquivoCSV);
        }














        //------------------------------------------------------METODO LOGAR----------------------------------------------------------------

        public virtual bool Logar(string _email)
        {

            return false;
        }


    }
}