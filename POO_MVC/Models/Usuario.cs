//---------------------------------------------------SUPERCLASSE-----------------------------------------------------

using System.Collections.Generic;
using System.IO;

namespace POO_MVC.Models
{
    public class Usuario : RockInSenaiBase
    {
        private string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        private string Senha { get; set; }
        private string NumeroDeMusico { get; set; }     // = null na classe Particpante; Só será instanciado na classe Musico



        //---------------------------CONSTANTES DA CLASSE-----------------------------------------

        private const string CAMINHO = "DataBase/Usuarios.csv";  //  Constante que define o local onde o arquivo csv será criado




        //---------------------------METODOS CONTRUTORES----------------------------------------

        //  Metodo herdado da superclasse Base, que recebe como parametro a constante CAMINHO definida acima e cria automaticamente um arquivo csv, onde serão salvos os dados do usuarios
        public Usuario()
        {
            CriarPastaEArquivo(CAMINHO);
        }




        //---------------------------METODOS DA CLASSE-----------------------------------------



        public string getCAMINHO()
        {
            return CAMINHO;
        }

        public void setId(string _Id)
        {
            this.Id = _Id;
        }

        public void setSenha(string _senha)
        {
            this.Senha = _senha;
        }

        public void setOMB(string _omb)
        {
            this.NumeroDeMusico = _omb;
        }


        //-----------------------------------------------------------------------------------------


        //Metodo auxiliar do metodo Criar (abaixo). Converte os atributos do usuario recebido como parametro em string, que será retornada utilizando caracter de separação especifico (no caso, ;)
        public string Preparar(Usuario aConverter)
        {

            if (aConverter.NumeroDeMusico != null)
            {
                return $"{aConverter.Id};{aConverter.Nome};{aConverter.Email};{aConverter.Senha};{aConverter.NumeroDeMusico}";
            }

            return $"{aConverter.Id};{aConverter.Nome};{aConverter.Email};{aConverter.Senha}";
        }



        //-----------------------------------------------------------------------------------------




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

            Usuario novo = new Usuario();

            string[] arrayDeLinhas = File.ReadAllLines(CAMINHO);

            foreach (var cadaLinha in arrayDeLinhas)
            {
                string[] atributosEmCadaLinha = cadaLinha.Split(";");

                // {aConverter.Id};{aConverter.Nome};{aConverter.Email};{aConverter.Senha};{aConverter.NumeroDeMusico}";

                novo.Id = atributosEmCadaLinha[0];
                novo.Nome = atributosEmCadaLinha[1];
                novo.Email = atributosEmCadaLinha[2];
                novo.Senha = atributosEmCadaLinha[3];
                novo.NumeroDeMusico = atributosEmCadaLinha[4];


                listaDeUsuarios.Add(novo);
            }

            return listaDeUsuarios;
        }




        //-----------------------------------------------------------------------------------------




        //  Para fazer qualquer alteração em um atributo da lista de objetos, devemos ler o arquivo csv, copiar seu conteudo completo em uma lista, indicar um parametro de referencia que identifique o objeto a ser removido da lista, adicionar o novo objeto com as alterações corretas e por fim salvar a nova lista atualizada no arquivo csv. Por isso, criamos os metodos de LER e REESCREVER na superclasse base e os herdamos nas classes onde serão utilizados, visto que o processo de alteração se repetirá em todas as classes
        public void Alterar(Usuario AlteracoesParaSalvar)
        {
            List<string> conteudoDoArquivoCSV = LerTodasLinhasCSV(CAMINHO);

            //Remove um determinado objeto da lista utilizando expressão lambda referenciada pelo Id do usuario para localiza-lo na lista
            conteudoDoArquivoCSV.RemoveAll(cadaAtributoNaLinha => cadaAtributoNaLinha.Split(";")[0] == AlteracoesParaSalvar.Id);

            //Adiciona o novo objeto com alterações à lista utilizando o metodo Preparar(), que antes o converte para string conforme exigencia do metodo Add
            conteudoDoArquivoCSV.Add(Preparar(AlteracoesParaSalvar));

            //Reescreve o csv utilizando a lista atualizada acima
            ReescreverCSV(CAMINHO, conteudoDoArquivoCSV);
        }



        //-----------------------------------------------------------------------------------------




        // Metodo para remover um usuario tendo por referencia seu Id. O metodo possui praticamente o mesmo funcionamento logico do Alterar() acima, porem sem adição de atualizações;
        public void Deletar(int idDoUsuarioADeletar)
        {
            List<string> conteudoDoArquivoCSV = LerTodasLinhasCSV(CAMINHO);

            //Remove um determinado objeto da lista utilizando expressão lambda referenciada pelo Id do usuario para localiza-lo na lista
            conteudoDoArquivoCSV.RemoveAll(cadaAtributoNaLinha => cadaAtributoNaLinha.Split(";")[0] == idDoUsuarioADeletar.ToString());


            //Reescreve o csv utilizando a lista atualizada acima, já sem o objeto removido
            ReescreverCSV(CAMINHO, conteudoDoArquivoCSV);
        }














        //------------------------------------------------------METODO LOGAR----------------------------------------------------------------

        public virtual bool Logar(string _email, string _senha)
        {
            List<string> dadosCSV = this.LerTodasLinhasCSV(CAMINHO);

            string logado = dadosCSV.Find(x =>
           x.Split(";")[2] == _email &&
           x.Split(";")[3] == _senha
            );

            if (logado != null)
            {
                return true;
            }

            return false;
        }


    }
}