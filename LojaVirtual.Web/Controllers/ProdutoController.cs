using LojaVirtual.Dominio.Repositorio;
using System.Web.Mvc;

namespace LojaVirtual.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private ProdutoRepositorio _produtoRepositorio;

        // GET: Produto
        public ActionResult Index()
        {
            _produtoRepositorio = new ProdutoRepositorio();
            var produtos = _produtoRepositorio.produtos;

            return View(produtos);
        }
    }
}