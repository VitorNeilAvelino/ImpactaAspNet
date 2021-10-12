using AutoMapper;
using ExpoCenter.Dominio.Entidades;
using ExpoCenter.Mvc.Models;
using ExpoCenter.Repositorios.SqlServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ExpoCenter.Mvc.Controllers
{
    public class ParticipantesController : Controller
    {
        private readonly ExpoCenterDbContext dbContext;
        private readonly IMapper mapper;

        public ParticipantesController(ExpoCenterDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public ActionResult Index()
        {
            return View(mapper.Map<List<ParticipanteIndexViewModel>>(dbContext.Participantes));
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            var viewModel = new ParticipanteCreateViewModel();
            viewModel.Eventos = mapper.Map<List<EventoGridViewModel>>(dbContext.Eventos);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParticipanteCreateViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ModelState);
                }

                var participante = mapper.Map<Participante>(viewModel);

                participante.Eventos = new List<Evento>();

                foreach (var evento in viewModel.Eventos.Where(e => e.Selecionado))
                {
                    participante.Eventos.Add(dbContext.Eventos.Single(e => e.Id == evento.Id));
                }

                dbContext.Participantes.Add(participante);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            var participante = dbContext.Participantes.Find(id);

            if (participante == null)
            {
                return NotFound();
            }

            var viewModel = mapper.Map<ParticipanteCreateViewModel>(participante);

            viewModel.Eventos = mapper.Map<List<EventoGridViewModel>>(dbContext.Eventos);

            if (participante.Eventos != null)
            {
                foreach (var evento in participante.Eventos)
                {
                    viewModel.Eventos.Single(e => e.Id == evento.Id).Selecionado = true;
                }
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ParticipanteCreateViewModel viewModel)
        {
            try
            {
                throw new Exception("Teste");

                if (!ModelState.IsValid)
                {
                    return View(ModelState);
                }

                var participante = dbContext.Participantes.Find(viewModel.Id);

                if (participante == null)
                {
                    return NotFound();
                }

                dbContext.Entry(participante).CurrentValues.SetValues(viewModel);                

                foreach (var evento in viewModel.Eventos)
                {
                    if (evento.Selecionado)
                    {
                        if (participante.Eventos.Any(e => e.Id == evento.Id)) continue;

                        participante.Eventos.Add(dbContext.Eventos.Single(e => e.Id == evento.Id));
                    }
                    else
                    {
                        participante.Eventos.Remove(dbContext.Eventos.Single(e => e.Id == evento.Id));
                    }
                }

                dbContext.Update(participante);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException)
                {
                    switch (sqlException.Message)
                    {
                        case string mensagem when mensagem.Contains("IX_Participante_Cpf"):
                            ModelState.AddModelError("", $"O CPF {viewModel.Cpf} já está cadastrado.");
                            break;
                        case string mensagem when mensagem.Contains("IX_Participante_Email"):
                            ModelState.AddModelError("", $"O e-mail {viewModel.Email} já está cadastrado.");
                            break;
                    }

                    if (!ModelState.IsValid)
                    {
                        return View(viewModel);
                    }
                }

                throw;
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Exception = ex });
            }
        }

        // GET: ParticipantesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ParticipantesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}