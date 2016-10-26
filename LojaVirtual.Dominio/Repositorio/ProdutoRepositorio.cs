using LojaVirtual.Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace LojaVirtual.Dominio.Repositorio
{
    public class ProdutoRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Produto> produtos
        {
            get { return _context.Produtos; }
        }
    }
}
