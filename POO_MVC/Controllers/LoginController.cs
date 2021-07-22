using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POO_MVC.Models;

namespace POO_MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Logar(IFormCollection form)
        {

            Participante acessoMetodos = new Participante();

            if (acessoMetodos.Logar((form["Email"]), (form["Senha"])))
            {
                ViewBag.Login = $"Login realizado com sucesso. Bem vindo!";
            }
            else
            {
                ViewBag.Login = $"Usuario ou senha inválido. Tente novamente";
            }

            return LocalRedirect("~/Login");
        }
    }
}