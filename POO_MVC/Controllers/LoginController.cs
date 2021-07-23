using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POO_MVC.Models;

namespace POO_MVC.Controllers
{
    public class LoginController : Controller
    {
        protected static string login = null;
        public IActionResult Index()
        {     
            ViewBag.Login = login;
            return View();
        }

        public IActionResult Logar(IFormCollection form)
        {

            Participante acessoMetodos = new Participante();


            if (acessoMetodos.Logar( ( form["Email"]).ToString(), (form["Senha"]).ToString() ) )
            {
                login = $"Login realizado com sucesso. Bem vindo!";
            }
            else
            {
                login = $"Usuario ou senha inválido. Tente novamente";
            }

            return LocalRedirect("~/Login");
        }
    }
}