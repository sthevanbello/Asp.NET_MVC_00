using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Alura.ListaLeitura.App.Views;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroLogica
    {
        public static Task Incluir(HttpContext context)
        {
            Livro livro = new Livro();

            livro.Titulo = context.Request.Form["titulo"].First();
            livro.Autor = context.Request.Form["autor"].First();
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return context.Response.WriteAsync("Livro adicionado com sucesso");
        }
        public static Task ExibeFormulario(HttpContext context)
        {
            var html = HtmlUtils.CarregaHTML("formulario");

            return context.Response.WriteAsync(html);
        }
        
    }
}
