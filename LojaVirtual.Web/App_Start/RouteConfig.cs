using System.Web.Mvc;
using System.Web.Routing;

namespace LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // 1 - Todas categorias
            routes.MapRoute(
                null,
                "",
                new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null, pagina = 1 }
            );

            // 2 - PaginaX
            routes.MapRoute(
                null,
                "Pagina{pagina}",
                new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null },
                new { pagina = @"\d+" }
            );


            // 3 - Categoria'X'
            routes.MapRoute(
                null,
                "{categoria}",
                new { controller = "Vitrine", action = "ListaProdutos", pagina = 1 }
            );

            // 4 - PaginaX/CAtegoria'X'
            routes.MapRoute(
                null,
                "{categoria}/Pagina{pagina}",
                new { controller = "Vitrine", action = "ListaProdutos"},
                new { pagina = @"\d+" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Vitrine", action = "ListaProdutos", id = UrlParameter.Optional }
            );

            routes.MapRoute(null,"{controller}/{ action}");
        }
    }
}
