using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Dominio.Entidades
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public string Descricao { get; set; }
        public string CodigoExterno { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
