using LojaVirtual.Dominio.Repositorio;
using LojaVirtual.Web.Models;
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
        private CategoriaRepositorio _categoriaRepositorio;
        public int qtdProdutosPorPagina = 1;

        public ActionResult ListaProdutos(string categoria= null, int pagina = 1)
        {
            _produtoRepositorio = new ProdutoRepositorio();
            _categoriaRepositorio = new CategoriaRepositorio();

            ProdutosViewModel model = new Models.ProdutosViewModel();

            if (categoria == null)
            {
                model.Produtos = _produtoRepositorio.produtos
                                    .Where(p => p.CategoriaID != null)
                                    .OrderBy(p => p.Nome)
                                    .Skip((pagina - 1) * qtdProdutosPorPagina)
                                    .Take(qtdProdutosPorPagina);

                model.Paginacao = new Paginacao
                {
                    PaginaAtual = pagina,
                    QtdProdutosPorPagina = qtdProdutosPorPagina,
                    QtdProdutosTotal = _produtoRepositorio.produtos.Count()
                };

                model.CategoriaAtual = categoria;
            }
            else
            {
                var categorias = _categoriaRepositorio.categorias
                    .Where(c => c.Descricao == categoria);

                foreach (var item in categorias)
                {
                    model.Produtos = _produtoRepositorio.produtos
                                .Where(p => p.CategoriaID == item.CategoriaID)
                                .OrderBy(p => p.Nome)
                                .Skip((pagina - 1) * qtdProdutosPorPagina)
                                .Take(qtdProdutosPorPagina);

                    model.Paginacao = new Paginacao
                    {
                        PaginaAtual = pagina,
                        QtdProdutosPorPagina = qtdProdutosPorPagina,
                        QtdProdutosTotal = _produtoRepositorio.produtos.Count()
                    };

                    model.CategoriaAtual = categoria;
                };
            }

            return View(model);
        }
    }
}