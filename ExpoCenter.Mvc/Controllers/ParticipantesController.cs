﻿using AutoMapper;
using ExpoCenter.Dominio.Entidades;
using ExpoCenter.Mvc.Models;
using ExpoCenter.Repositorios.SqlServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        // GET: ParticipantesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ParticipantesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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