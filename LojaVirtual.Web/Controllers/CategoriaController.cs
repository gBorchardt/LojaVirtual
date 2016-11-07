using LojaVirtual.Dominio.Repositorio;
using System.Collections.Generic;
using System.Linq;
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

        public PartialViewResult Menu(string categoria = null)
        {
            ViewBag.CategoriaSelecionada = categoria;

            _categoriaRepositorio = new CategoriaRepositorio();

            var categorias = _categoriaRepositorio.categorias.OrderBy(c => c.Descricao);

            return PartialView(categorias);                  
        }
    }
}