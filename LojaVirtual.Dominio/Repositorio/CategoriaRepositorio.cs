using LojaVirtual.Dominio.Entidades;
using System.Collections.Generic;

namespace LojaVirtual.Dominio.Repositorio
{
    public class CategoriaRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Categoria> categorias
        {
            get { return _context.Categorias; }
        }
    }
}
