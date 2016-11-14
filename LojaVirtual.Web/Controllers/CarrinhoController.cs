using LojaVirtual.Dominio.Entidades;
using LojaVirtual.Dominio.Repositorio;
using LojaVirtual.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutoRepositorio _ProdutosRepositorio;

        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
        {
            _ProdutosRepositorio = new ProdutoRepositorio();

            Produto produto = _ProdutosRepositorio.produtos.FirstOrDefault(p => p.ProdutoID == produtoId);

            if (produto != null)
            {
                ObterCarrinho().AdicionarItem(produto, 1);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        private CarrinhoRepositorio ObterCarrinho()
        {
            CarrinhoRepositorio carrinho = (CarrinhoRepositorio)Session["Carrinho"];

            if (carrinho == null)
            {
                carrinho = new CarrinhoRepositorio();
                Session["Carrinho"] = carrinho;
            }

            return carrinho;
        }

        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            _ProdutosRepositorio = new ProdutoRepositorio();

            Produto produto = _ProdutosRepositorio.produtos.FirstOrDefault(p => p.ProdutoID == produtoId);

            if (produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = returnUrl
            });
        }
    }
}