using System.Collections.Generic;

namespace POO_MVC.Models
{
    public class Musico : Usuario
    {
        //private string NumeroDeMusico { get; set; }



        //---------------------------METODOS CONSTRUTORES----------------------------------------

        //  Metodo herdado da superclasse Base, que recebe como parametro a constante CAMINHO definida acima e cria automaticamente um arquivo csv, onde serão salvos os dados do usuarios
        public Musico()
        {
            CriarPastaEArquivo( this.getCAMINHO() );
        }



        public override bool Logar(string _omb, string _senha) // omb corresponde ao atributo NumeroDeMusico;
        {
            List<string> dadosCSV = this.LerTodasLinhasCSV( this.getCAMINHO() );

            string logado = dadosCSV.Find(x =>
           x.Split(";")[4] == _omb &&
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