using LojaVirtual.Dominio.Entidades;
using LojaVirtual.Dominio.Repositorio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        // Teste adicionar itens ao carrinho
        [TestMethod]
        public void AdicionarItensCarrinho()
        {
            // Arrange - criação dos produtos
            Produto produto01 = new Produto
            {
                ProdutoID = 1,
                Nome = "Teste01"
            };

            Produto produto02 = new Produto
            {
                ProdutoID = 2,
                Nome = "Teste02"
            };

            //Arrange - criação do carrinho
            CarrinhoRepositorio carrinho = new CarrinhoRepositorio();
            
            carrinho.AdicionarItem(produto01,2);

            carrinho.AdicionarItem(produto02,3);

            //Act
            Carrinho[] itens = carrinho.ItensCarrinho.ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto01);
            Assert.AreEqual(itens[1].Produto, produto02);
        }

        //Teste adicionar produto existente ao carrinho 
        [TestMethod]
        public void AdicionarItemExistenteCarrinho()
        {
            // Arrange - criação dos produtos
            Produto produto01 = new Produto
            {
                ProdutoID = 1,
                Nome = "Teste01"
            };

            Produto produto02 = new Produto
            {
                ProdutoID = 2,
                Nome = "Teste02"
            };

            Produto produto03 = new Produto
            {
                ProdutoID = 3,
                Nome = "Teste03"
            };

            //Arrange - criação do carrinho
            CarrinhoRepositorio carrinho = new CarrinhoRepositorio();

            carrinho.AdicionarItem(produto01, 1);

            carrinho.AdicionarItem(produto02, 2);

            carrinho.AdicionarItem(produto03, 2);

            carrinho.AdicionarItem(produto02, 10);

            //Act
            Carrinho[] itens = carrinho.ItensCarrinho.OrderBy(c => c.Produto.ProdutoID).ToArray();

            //Assert
            Assert.AreEqual(itens.Length, 3);
            Assert.AreEqual(itens[0].Quantidade, 1);
            Assert.AreEqual(itens[1].Quantidade, 12);
            Assert.AreEqual(itens[2].Quantidade, 2);
        }

        //Teste remover itens do carrinho 
        [TestMethod]
        public void RemoverItensCarrinho()
        {
            // Arrange - criação dos produtos
            Produto produto01 = new Produto
            {
                ProdutoID = 1,
                Nome = "Teste01"
            };

            Produto produto02 = new Produto
            {
                ProdutoID = 2,
                Nome = "Teste02"
            };

            Produto produto03 = new Produto
            {
                ProdutoID = 3,
                Nome = "Teste03"
            };

            //Arrange - criação do carrinho
            CarrinhoRepositorio carrinho = new CarrinhoRepositorio();

            carrinho.AdicionarItem(produto01, 1);

            carrinho.AdicionarItem(produto02, 2);

            carrinho.AdicionarItem(produto03, 2);

            carrinho.AdicionarItem(produto02, 10);

            //Act
            carrinho.RemoverItem(produto02);

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Where(c => c.Produto == produto02).Count(),0);
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 2);
        }

        //Teste calcular valor total do carrinho 
        [TestMethod]
        public void CalcularValorTotal()
        {
            // Arrange - criação dos produtos
            Produto produto01 = new Produto
            {
                ProdutoID = 1,
                Nome = "Teste01",
                Preco = 100M //Para decimaal colocar "M"
            };

            Produto produto02 = new Produto
            {
                ProdutoID = 2,
                Nome = "Teste02",
                Preco = 50M
            };

            //Arrange - criação do carrinho
            CarrinhoRepositorio carrinho = new CarrinhoRepositorio();

            carrinho.AdicionarItem(produto01, 1); //100

            carrinho.AdicionarItem(produto02, 1); //50

            carrinho.AdicionarItem(produto01, 3); //300 = TOTAL = 450

            //Act
            decimal resultado = carrinho.ObterValorTotal();

            //Assert
            Assert.AreEqual(resultado,450M);

        }

        //Limpar itens do carrinho 
        [TestMethod]
        public void LimpartItensCarrinho()
        {
            // Arrange - criação dos produtos
            Produto produto01 = new Produto
            {
                ProdutoID = 1,
                Nome = "Teste01",
                Preco = 100M
            };

            Produto produto02 = new Produto
            {
                ProdutoID = 2,
                Nome = "Teste02",
                Preco = 50M
            };

            //Arrange - criação do carrinho
            CarrinhoRepositorio carrinho = new CarrinhoRepositorio();

            carrinho.AdicionarItem(produto01, 1);

            carrinho.AdicionarItem(produto02, 1);

            //Act
            carrinho.LimparCarrinho();

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count(),0);

        }
    }
}
