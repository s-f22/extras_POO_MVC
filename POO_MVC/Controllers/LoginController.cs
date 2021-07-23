using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POO_MVC.Models;

namespace POO_MVC.Controllers
{
    public class LoginController : Controller
    {
        protected static string login = null;
        protected static bool logado = false;

        public IActionResult Index()
        {
            ViewBag.Login = login;
            ViewBag.Logado = logado;
            return View();
        }



        public IActionResult Logar(IFormCollection form)
        {

            Participante pMetodos = new Participante();
            Musico mMetodos = new Musico();

            if ((form["Email"]).ToString().Contains("@") && (form["Email"]).ToString().Contains(".com"))
            {
                if (pMetodos.Logar((form["Email"]).ToString(), (form["Senha"]).ToString()))
                {
                    logado = true;
                    login = $"Login realizado com sucesso. Bem vindo!";
                }
                else
                {
                    logado = false;
                    login = $"Usuario ou senha inválido. Tente novamente";
                }
            }
            else
            {
                if (mMetodos.Logar((form["Email"]).ToString(), (form["Senha"]).ToString()))
                {
                    logado = true;
                    login = $"Login realizado com sucesso. Bem vindo!";
                }
                else
                {
                    logado = false;
                    login = $"Usuario ou senha inválido. Tente novamente";
                }
            }


            return LocalRedirect("~/Login");
        }
    }
}