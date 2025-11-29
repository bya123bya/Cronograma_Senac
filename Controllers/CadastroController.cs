

using System.Security.Claims;
using CronogramaSenac.Contexts;
using CronogramaSenac.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CronogramaSenac.Controllers
{
    [Route("[controller]")]
    public class CadastroController : Controller
    {
        Senac_cronogramaContext context = new Senac_cronogramaContext();

        public IActionResult Index()
        {
            //Forma de listar todos os items da tabela de (tipoUsuários)
            var listaTiposUsuarios = context.TipoUsuarios.ToList(); //.Include() - trago os dados das tabelas relacionadas. principalmente em tabelas de n pra n esse é op meio correto
            //Passar para a tela (em forma de memória) os dados das jogadores cadastradas
            ViewBag.listaTiposUsuarios = listaTiposUsuarios;

            return View();
        }

        [HttpPost("cadastrar")]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            //Armazenar o usuario 
            context.Add(usuario);
            //Registrar as alterações no banco de dados
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}