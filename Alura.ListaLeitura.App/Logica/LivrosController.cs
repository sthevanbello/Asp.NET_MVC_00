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
    public class LivrosController : Controller
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

            
            html = html.Replace("#", "");
            return html;
        }

        public IActionResult ParaLer()
        {
            var repo = new LivroRepositorioCSV();
            ViewBag.Livros = repo.ParaLer.Livros;

            return View("/Views/Livros/lista.cshtml");

        }

        public IActionResult Lendo()
        {
            var repo = new LivroRepositorioCSV();
            ViewBag.Livros = repo.Lendo.Livros;

            return View("/Views/Livros/lista.cshtml");
        }

        public IActionResult Lidos()
        {
            var repo = new LivroRepositorioCSV();
            ViewBag.Livros = repo.Lidos.Livros;

            return View("/Views/Livros/lista.cshtml");
        }

        public string Teste()
        {
            return "Tudo funcionando";
        }
    }
}
