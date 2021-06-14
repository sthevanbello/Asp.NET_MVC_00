using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Alura.ListaLeitura.App.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    class LivrosLogica
    {

        public static Task ExibeDetalhes(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.FirstOrDefault(i => i.Id == id);
            return context.Response.WriteAsync(livro.Detalhes());
        }

        public static string CarregaPaginaHTML(string arquivo, IEnumerable<Livro> _repo)
        {
            var html = HtmlUtils.CarregaHTML(arquivo);

            foreach (var item in _repo)
            {
                html = html.Replace("#", $"<li>{item}</li>#");
            }
            html = html.Replace("#", "");
            return html;
        }

        public static Task LivrosParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            string html = CarregaPaginaHTML("paraler", _repo.ParaLer.Livros);

            return context.Response.WriteAsync(html);

            //return context.Response.WriteAsync(_repo.ParaLer.ToString());
        }

        public static Task LivrosLendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            string html = CarregaPaginaHTML("lendo", _repo.Lendo.Livros);

            return context.Response.WriteAsync(html);
        }

        public static Task LivrosLidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            string html = CarregaPaginaHTML("lidos", _repo.Lidos.Livros);

            return context.Response.WriteAsync(html);
        }
    }
}
