using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
