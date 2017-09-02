using System;
using System.Net;
using System.Web.Mvc;
using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Application.Services;
using EP.CursoMvc.Application.ViewModels;
using EP.CursoMvc.Infra.CrossCutting.MvcFilters;

namespace EP.CursoMvc.UI.Web.Controllers
{
    [RoutePrefix("admin/gestao-clientes")]
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [Route("listar-todos")]
        [ClaimsAuthorize("Cliente","LT")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterAtivos());
        }

        [Route("{id:guid}/detalhes")]
        [ClaimsAuthorize("Cliente", "VI")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }

            return View(clienteViewModel);
        }

        [Route("criar-novo")]
        [ClaimsAuthorize("Cliente", "IN")]
        public ActionResult Create()
        {
            return View();
        }

        [Route("criar-novo")]
        [ClaimsAuthorize("Cliente", "IN")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                clienteEnderecoViewModel = _clienteAppService.Adicionar(clienteEnderecoViewModel);

                if (!clienteEnderecoViewModel.Cliente.ValidationResult.IsValid)
                {
                    foreach (var error in clienteEnderecoViewModel.Cliente.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, error.Message);
                    }

                    return View(clienteEnderecoViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        [Route("{id:guid}/editar")]
        [ClaimsAuthorize("Cliente", "ED")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/editar")]
        [ClaimsAuthorize("Cliente", "ED")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/excluir")]
        [ClaimsAuthorize("Cliente", "EX")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [Route("{id:guid}/excluir")]
        [ClaimsAuthorize("Cliente", "EX")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
