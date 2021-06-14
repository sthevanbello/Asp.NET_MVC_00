using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("Livros/ParaLer", LivrosParaLer);
            builder.MapRoute("Livros/Lendo", LivrosLendo);
            builder.MapRoute("Livros/Lidos", LivrosLidos);

            //builder.MapRoute("Cadastro/NovoLivro/{nome}/{autor}", NovoLivroParaLer);

            //Restrição para que o id seja sempre int e retorna erro 404 se não for
            builder.MapRoute("Livros/Detalhes/{id:int}", ExibeDetalhes);

            builder.MapRoute("Cadastro/NovoLivro", ExibeFormulario);
            builder.MapRoute("Cadastro/Incluir", ProcessaFormulario);

            var rotas = builder.Build();
            app.UseRouter(rotas);

            //app.Run(Roteamento);
        }
        public void ConfigureServices(IServiceCollection service)
        {
            service.AddRouting();
        }

        private Task ProcessaFormulario(HttpContext context)
        {
            Livro livro = new Livro();

            livro.Titulo = context.Request.Form["titulo"].First();
            livro.Autor = context.Request.Form["autor"].First();
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return context.Response.WriteAsync("Livro adicionado com sucesso");
        }

        private Task ExibeFormulario(HttpContext context)
        {
            var html = CarregaHTML("formulario");

            return context.Response.WriteAsync(html);
        }

        private string CarregaHTML(string v)
        {
            var nomeCompletoDoArquivo = $"D:/Developer/Alura/Asp.NET Core Uma webapp usando o padrão MVC/Alura.ListaLeitura.Aula2/Alura.ListaLeitura/{v}.cshtml";
            using (var html = File.OpenText(nomeCompletoDoArquivo))
            {
                return html.ReadToEnd();
            }
        }

        private string CarregaPaginaHTML(string arquivo, IEnumerable<Livro> _repo)
        {
            var html = CarregaHTML(arquivo);

            foreach (var item in _repo)
            {
                html = html.Replace("#", $"<li>{item}</li>#");
            }
            html = html.Replace("#", "");
            return html;
        }

        private Task ExibeDetalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.FirstOrDefault(i => i.Id == id);
            return context.Response.WriteAsync(livro.Detalhes());
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

        public Task LivrosParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            string html = CarregaPaginaHTML("paraler", _repo.ParaLer.Livros);

            return context.Response.WriteAsync(html);

            //return context.Response.WriteAsync(_repo.ParaLer.ToString());
        }

        

        public Task LivrosLendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            string html = CarregaPaginaHTML("lendo", _repo.Lendo.Livros);

            return context.Response.WriteAsync(html);
        }

        public Task LivrosLidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            string html = CarregaPaginaHTML("lidos", _repo.Lidos.Livros);

            return context.Response.WriteAsync(html);
        }
    }
}