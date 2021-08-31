using Marketplace.Mvc.Models;
using Marketplace.Repositorios.SqlServer.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketplace.Mvc.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteRepositorio clienteRepositorio = new ClienteRepositorio();

        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        public ActionResult Create(ClienteViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                clienteRepositorio.Inserir(Mapear(viewModel));

                return RedirectToAction("Index");
            }
            catch
            {
                //Logar - log4net

                return View("Error");
            }
        }

        private Cliente Mapear(ClienteViewModel viewModel)
        {
            var cliente = new Cliente();

            cliente.Documento = viewModel.Documento;
            cliente.Email = viewModel.Email;
            cliente.Id = viewModel.Id;
            cliente.Nome = viewModel.Nome;
            cliente.Telefone = viewModel.Telefone;

            return cliente;
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clientes/Edit/5
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

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clientes/Delete/5
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
