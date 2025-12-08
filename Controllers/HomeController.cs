using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CronogramaSenac.Models;
using CronogramaSenac.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CronogramaSenac.Controllers;

public class HomeController : Controller
{
    Senac_cronogramaContext context = new Senac_cronogramaContext();

    public IActionResult Index()
    {
        var listaUcs = context.Ucs.Include(x => x.TurmaUcs).ThenInclude(x => x.Turma).ThenInclude(x => x.UsuarioTurmas).ThenInclude(x => x.Usuario).Where(uc => uc.TurmaUcs.Any(tuc => tuc.Turma.UsuarioTurmas.Any(ut => ut.Usuario.TipoUsuarioId == 4))).ToList();

        ViewBag.ListaUcs = listaUcs;
        
        var listaTurmas = context.Turmas
                    .OrderBy(t => t.Nome)
                    .ToList();

        ViewBag.ListaTurmas = listaTurmas;
        return View();
    }


    [Route("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }
}
