﻿using Marketplace.Mvc.Models;
using Marketplace.Repositorios.SqlServer.DbFirst;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Marketplace.Mvc.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteRepositorio clienteRepositorio = new ClienteRepositorio();

        // GET: Clientes
        public ActionResult Index()
        {
            return View(Mapear(clienteRepositorio.Selecionar()));
        }

        private List<ClienteViewModel> Mapear(List<Cliente> clientes)
        {
            var viewModel = new List<ClienteViewModel>();

            foreach (var cliente in clientes)
            {
                viewModel.Add(Mapear(cliente));
            }

            return viewModel;
        }

        private ClienteViewModel Mapear(Cliente cliente)
        {
            var viewModel = new ClienteViewModel();

            viewModel.Documento = cliente.Documento;
            viewModel.Email = cliente.Email;
            viewModel.Id = cliente.Id;
            viewModel.Nome = cliente.Nome;
            viewModel.Telefone = cliente.Telefone;
            viewModel.IdCartao = cliente.Cartoes?.FirstOrDefault(c => c.Cliente.Id == cliente.Id)?.Id;

            return viewModel;
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            return View(Mapear(clienteRepositorio.Selecionar(id)));
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            return View(Mapear(clienteRepositorio.Selecionar(id)));
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClienteViewModel viewModel)
        {
            try
            {
                if (id != viewModel.Id)
                {
                    ModelState.AddModelError("", "O id do Cliente especificado na URL não é o mesmo da requisição enviada ao servidor.");
                }

                if (!ModelState.IsValid)
                {
                    return View(viewModel);
                }

                clienteRepositorio.Atualizar(Mapear(viewModel));

                return RedirectToAction("Index");
            }
            catch
            {
                //Logar - log4net

                return View("Error");
            }
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Mapear(clienteRepositorio.Selecionar(id)));
        }

        // POST: Clientes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ClienteViewModel viewModel)
        {
            try
            {
                if (id != viewModel.Id)
                {
                    ModelState.AddModelError("", "O id do Cliente especificado na URL não é o mesmo da requisição enviada ao servidor.");
                }

                clienteRepositorio.Excluir(id);

                return RedirectToAction("Index");
            }
            catch
            {
                //Logar - log4net

                return View("Error");
            }
        }
    }
}