using System;

namespace LojaVirtual.Web.Models
{
    public class Paginacao
    {
        public int QtdProdutosTotal { get; set; }

        public int QtdProdutosPorPagina { get; set; }

        public int PaginaAtual { get; set; }

        public int TotalPagina
        {
            get
            {
                return (int)Math.Ceiling((decimal)QtdProdutosTotal / QtdProdutosPorPagina);
            }
        }
    }
}