using ExpoCenter.Dominio.Entidades;
using ExpoCenter.Dominio.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpoCenter.Mvc.Controllers
{
    public class PagamentosController : Controller
    {
        private readonly IPagamentoRepositorio pagamentoRepositorio;

        public PagamentosController(IPagamentoRepositorio pagamentoRepositorio)
        {
            this.pagamentoRepositorio = pagamentoRepositorio;
        }

        public async Task<ActionResult<List<Pagamento>>> Index()
        {
            return View(await pagamentoRepositorio.Get());
        }

        // GET: PagamentoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PagamentoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PagamentoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PagamentoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PagamentoController/Edit/5
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

        // GET: PagamentoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PagamentoController/Delete/5
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