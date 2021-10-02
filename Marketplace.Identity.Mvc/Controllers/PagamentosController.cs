using Marketplace.Identity.Mvc.Models;
using Marketplace.Repositorios.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Marketplace.Identity.Mvc.Controllers
{
    public class PagamentosController : Controller
    {
        private readonly PagamentoRepositorio pagamentoRepositorio = new PagamentoRepositorio("http://localhost:1075/api");

        // GET: Pagamentos
        public async Task<ActionResult> Index(int? idCartao)
        {
            return View(PagamentoViewModel.Mapear(await pagamentoRepositorio.ObterPorCartao(idCartao ?? 0)));
        }

        // GET: Pagamentos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pagamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pagamentos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pagamentos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pagamentos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pagamentos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pagamentos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}