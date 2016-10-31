using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using LojaVirtual.Web.Models;
using LojaVirtual.Web.HtmlHelpers;

namespace LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTestLoja
    {
        //Testando com AAA (Arrange, Act, Assert)

        //Arrange
        //Todo teste passa por uma preparação, seja de ambiente, variáveis, banco de dados, etc. 

        //Act
        //Todo teste passa por um momento onde estimulamos o sistema sendo testado (Systen Under Test - SUT).

        //Assert
        //Em seguida, verificamos se os resultados obtidos batem com os resultados esperados.

        [TestMethod]
        public void TestarPaginacao()
        {

            //Arrange
            HtmlHelper html = null;

            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 1,
                QtdProdutosTotal = 3,
                QtdProdutosPorPagina = 1
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);

            //Assert
            Assert.AreEqual(
                @"<a class=""btn btn-default btn-primary selected"" href=""Pagina1"">1</a>"
                + @"<a class=""btn btn-default"" href=""Pagina2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()
            );
        }
    }
}
