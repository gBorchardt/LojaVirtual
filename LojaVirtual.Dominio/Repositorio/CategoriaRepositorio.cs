using LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

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
