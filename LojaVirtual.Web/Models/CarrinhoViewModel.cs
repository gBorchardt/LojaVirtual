using LojaVirtual.Dominio.Entidades;
using LojaVirtual.Dominio.Repositorio;

namespace LojaVirtual.Web.Models
{
    public class CarrinhoViewModel
    {
        public CarrinhoRepositorio Carrinho{ get; set; }
        public string ReturnUrl { get; set; }
    }
}