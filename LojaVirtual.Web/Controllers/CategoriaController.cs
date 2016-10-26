using LojaVirtual.Dominio.Repositorio;
using System.Web.Mvc;

namespace LojaVirtual.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaRepositorio _categoriaRepositorio;

        // GET: Categoria
        public ActionResult Index()
        {
            _categoriaRepositorio = new CategoriaRepositorio();
            var categorias = _categoriaRepositorio.categorias;

            return View(categorias);
        }
    }
}