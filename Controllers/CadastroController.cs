

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

        [HttpPost]
        public IActionResult CadastrarUsuario(Usuario usuario)
        {
            //Armazenar o usuario 
            context.Add(usuario);
            //Registrar as alterações no banco de dados
            context.SaveChanges();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        [Route("CadastrarUC")]
        public IActionResult CadastrarUC(Uc uc, string TurmaId)
        {
            uc.Lancamento = false;

            //Armazenar o usuario 
            context.Add(uc);
            //Registrar as alterações no banco de dados
            context.SaveChanges();

            if (TurmaId != null && TurmaId.Count() > 0)
            {
                TurmaUc tmuc = new TurmaUc()
                {
                    UcId = uc.Id,
                    CargaHoraria = (int?)CalcularCargaHorariaTotal(uc.DataInicio, uc.DataFim, uc.HoraChegada, uc.HoraSaida),
                    TurmaId = int.Parse(TurmaId)
                };

                context.Add(tmuc);

                context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]

        [Route("CadastrarTurma")]
        public IActionResult CadastrarTurma(Turma turma, string UsuarioId)
        {
            //Armazenar a turma 
            context.Add(turma);

            //Registrar as alterações no banco de dados
            context.SaveChanges();

            if (UsuarioId != null && UsuarioId.Count() > 0)
            {
                UsuarioTurma us = new UsuarioTurma()
                {
                    TurmaId = turma.Id,
                    UsuarioId = int.Parse(UsuarioId)
                };

                context.Add(us);

                context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }

        private double CalcularCargaHorariaTotal(DateOnly? dataInicio, DateOnly? dataFim, TimeOnly? horaInicio, TimeOnly? horaFim)
        {
            // Verificação correta de null
            if (dataInicio is null || dataFim is null || horaInicio is null || horaFim is null)
                return 0;

            // Pega os valores já que não são nulos
            DateOnly inicio = dataInicio.Value;
            DateOnly fim = dataFim.Value;
            TimeOnly hInicio = horaInicio.Value;
            TimeOnly hFim = horaFim.Value;

            // Carga horária diária
            double horasPorDia = (hFim - hInicio).TotalHours;

            double totalHoras = 0;

            // Loop de datas
            for (DateOnly data = inicio; data <= fim; data = data.AddDays(1))
            {
                if (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
                    continue;

                totalHoras += horasPorDia;
            }

            return totalHoras;
        }

    }
}