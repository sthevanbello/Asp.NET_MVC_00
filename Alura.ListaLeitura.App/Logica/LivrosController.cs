using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Alura.ListaLeitura.App.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController
    {

        public string Detalhes(int id)
        {
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.FirstOrDefault(i => i.Id == id);

            return livro.Detalhes();
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

        public IActionResult ParaLer()
        {
            var html = new ViewResult { ViewName = "/Views/Livros/paraler.cshtml" };

            return html;

        }

        public IActionResult Lendo()
        {
            var html = new ViewResult{ ViewName = "Views/Livros/lendo.cshtml" };

            return html;
        }

        public IActionResult Lidos()
        {
            var html = new ViewResult { ViewName = "Views/Livros/lidos.cshtml" };

            return html;
        }

        public string Teste()
        {
            return "Tudo funcionando";
        }
    }
}
