using Alura.ListaLeitura.App.MVC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("{classe}/{metodo}", RoteamentoPadrao.TratamentoPadrao);

            var rotas = builder.Build();
            app.UseRouter(rotas);

        }
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddRouting();
        }

       
        #region Roteamento manual

        //public Task Roteamento(HttpContext context)
        //{
        //    var _repo = new LivroRepositorioCSV();
        //    var caminhosAtendidos = new Dictionary<string, RequestDelegate>
        //    {
        //        { "/Livros/ParaLer", LivrosParaLer },
        //        { "/Livros/Lendo", LivrosLendo },
        //        { "/Livros/Lidos", LivrosLidos }
        //    };

        //    if (caminhosAtendidos.ContainsKey(context.Request.Path))
        //    {
        //        var metodo = caminhosAtendidos[context.Request.Path];
        //        return metodo.Invoke(context);
        //    }

        //    context.Response.StatusCode = 404;
        //    return context.Response.WriteAsync("Caminho inexistente.");
        //}
        #endregion

        #region Roteamento pela rota do http
        //private Task NovoLivroParaLer(HttpContext context)
        //{
        //    Livro livro = new Livro();

        //    livro.Titulo = context.GetRouteValue("nome").ToString();
        //    livro.Autor = context.GetRouteValue("autor").ToString();
        //    var repo = new LivroRepositorioCSV();
        //    repo.Incluir(livro);

        //    return context.Response.WriteAsync("Livro adicionado com sucesso");
        //}
        #endregion


    }
}