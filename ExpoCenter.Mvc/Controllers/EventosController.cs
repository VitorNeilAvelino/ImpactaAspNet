using AutoMapper;
using ExpoCenter.Dominio.Entidades;
using ExpoCenter.Mvc.Models;
using ExpoCenter.Repositorios.SqlServer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ExpoCenter.Mvc.Controllers
{
    public class EventosController : ControllerBase
    {
        public EventosController(ExpoCenterDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }

        public ActionResult Index()
        {
            return View(Mapper.Map<List<EventoViewModel>>(DbContext.Eventos));
        }

        public ActionResult Details(int id)
        {
            return View(Mapper.Map<EventoViewModel>(DbContext.Eventos.SingleOrDefault(e => e.Id == id)));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventoViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ModelState);
                }

                DbContext.Eventos.Add(Mapper.Map<Evento>(viewModel));
                DbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Edit(int id)
        {
            return View(Mapper.Map<EventoViewModel>(DbContext.Eventos.SingleOrDefault(e => e.Id == id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventoViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ModelState);
                }

                DbContext.Entry(Mapper.Map<Evento>(viewModel)).State = EntityState.Modified;
                DbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult Delete(int id)
        {
            return View(Mapper.Map<EventoViewModel>(DbContext.Eventos.SingleOrDefault(e => e.Id == id)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var evento = DbContext.Eventos.SingleOrDefault(e => e.Id == id);

                if (evento != null)
                {
                    DbContext.Eventos.Remove(evento);
                    DbContext.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}