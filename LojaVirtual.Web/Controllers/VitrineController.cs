using LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutoRepositorio _produtoRepositorio;
        public int qtdProdutosPorPagina = 1;

        public ActionResult ListaProdutos(int pagina = 1)
        {
            _produtoRepositorio = new ProdutoRepositorio();
            var produtos = _produtoRepositorio.produtos
                .OrderBy(p => p.Nome)
                .Skip((pagina - 1 ) * qtdProdutosPorPagina)
                .Take(qtdProdutosPorPagina);

            return View(produtos);
        }
    }
}