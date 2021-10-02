using Marketplace.Identity.Mvc.Models;
using Marketplace.Repositorios.Http;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Marketplace.Identity.Mvc.Controllers
{
    public class PagamentosController : Controller
    {
        private readonly PagamentoRepositorio pagamentoRepositorio = new PagamentoRepositorio("http://localhost:1075/api");

        public async Task<ActionResult> Index(int? idCartao)
        {
            if (!idCartao.HasValue) return null;

            TempData["idCartao"] = idCartao;

            return View(PagamentoIndexViewModel.Mapear(await pagamentoRepositorio.ObterPorCartao(idCartao.Value)));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PagamentoCreateViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }
                
                var pagamentoResponse = await pagamentoRepositorio.Post(PagamentoCreateViewModel.Mapear(viewModel));

                if (pagamentoResponse.Status != (int)StatusPagamento.PagamentoOK)
                {
                    ModelState.AddModelError("", pagamentoResponse.MensagemStatus);

                    return View(viewModel);
                }

                return RedirectToAction("Index", new { idCartao = TempData["idCartao"] });
            }
            catch (Exception ex)
            {
                // Logar(ex);
                return View("Error");
            }
        }
    }
}