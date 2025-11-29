using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CronogramaSenac.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CronogramaSenac.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        Senac_cronogramaContext context = new Senac_cronogramaContext();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("logar")]
        public IActionResult Logar(string email, string senha)
        {
            // Procurar um usuario com o email fornecido
            var usuario = context.Usuarios.FirstOrDefault(x => x.Email == email);

            if (usuario != null)
            {
                if (usuario.Senha == senha)
                {
                    return RedirectToAction("Index", "Home");
                }

                TempData["ErrorMessage"] = "Email ou senha, inválidos";
            }

            TempData["ErrorMessage"] = "Email não utilizado";

            return RedirectToAction("Index");
        }
    }
}