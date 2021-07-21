namespace POO_MVC.Models
{
    public class Participante : Usuario
    {


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