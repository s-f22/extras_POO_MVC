using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POO_MVC.Models;

namespace POO_MVC.Controllers
{
    public class HomeController : Controller
    {

        Musico acessoMetodos = new Musico();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form)
        {
            Participante novoP = new Participante();
            Musico novoM = new Musico();
            Random gerarId = new Random();

            
            if ( (form["NumeroDeMusico"]) != "")
            {
                novoM.setId( gerarId.Next(1, 100000).ToString() );
                novoM.Nome = (form["Nome"]);
                novoM.Email = (form["Email"]);
                novoM.setSenha( (form["Email"]) );
                novoM.setOMB( (form["NumeroDeMusico"]) );

                acessoMetodos.Criar(novoM);
            }
            else
            {
                novoP.setId( gerarId.Next(1, 100000).ToString() );
                novoP.Nome = (form["Nome"]);
                novoP.Email = (form["Email"]);
                novoP.setSenha( (form["Email"]) );

                acessoMetodos.Criar(novoP);
            }


            return LocalRedirect("~/Home");
        }


    }
}
