namespace POO_MVC.Models
{
    public class Participante : Usuario
    {


        //---------------------------METODOS CONSTRUTORES----------------------------------------

        public Participante()
        {
            CriarPastaEArquivo( this.getCAMINHO() );
        }



        


        public string ConfirmarChegada()
        {

            return $"Confirmado em todos os dias.";
        }


        public string ConfirmarChegada(string _data)
        {

            return $"Presença confirmada em {_data}";
        }
        
    }
    
}