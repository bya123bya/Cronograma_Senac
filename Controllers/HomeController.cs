using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CronogramaSenac.Models;
using CronogramaSenac.Contexts;
using Microsoft.EntityFrameworkCore;

namespace CronogramaSenac.Controllers;

public class HomeController : Controller
{
    Senac_cronogramaContext context = new Senac_cronogramaContext();

    public IActionResult Index()
    {
        var listaUcs = context.Ucs.Include(x => x.TurmaUcs).ThenInclude(x => x.Turma).ThenInclude(x => x.UsuarioTurmas).ThenInclude(x => x.Usuario).Where(uc => uc.TurmaUcs.Any(tuc => tuc.Turma.UsuarioTurmas.Any(ut => ut.Usuario.TipoUsuarioId == 4))).Select(x => x.Ucs).ToList();

        ViewBag.ListaUcs = listaUcs;

        return View();
    }


    [Route("privacy")]
    public IActionResult Privacy()
    {
        return View();
    }
}
