using LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Dominio.Repositorio
{
    class CarrinhoRepositorio
    {
        private readonly List<Carrinho> _carrinho = new List<Carrinho>();
        
        //Adicionar Item
        public void AdicionarItem(Produto produto, int quantidade)
        {
            Carrinho carrinho = _carrinho.FirstOrDefault(c => c.Produto.ProdutoID == produto.ProdutoID);

            if (carrinho == null)
            {
                _carrinho.Add( new Carrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                carrinho.Quantidade += quantidade;
            }
        }

        //Remover Item
        public void RemoverItem(Produto produto)
        {
            _carrinho.RemoveAll(c => c.Produto.ProdutoID == produto.ProdutoID);
        }

        //Obter valor total
        public decimal ObterValorTotal()
        {
            return _carrinho.Sum(c => c.Produto.Preco * c.Quantidade);
        }

        //Limpar carrinho
        public void LimparCarrinho()
        {
            _carrinho.Clear();
        }

        //Itens carrinho
        public IEnumerable<Carrinho> ItensCarrinho
        {
            get { return _carrinho; }
        }
    }
}
