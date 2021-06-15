using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Alura.ListaLeitura.App.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {
        public string Incluir(Livro livro)
        {
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return "Livro adicionado com sucesso";
        }
        public IActionResult ExibeFormulario()
        {
            //var html = HtmlUtils.CarregaHTML("formulario");
            var html = new ViewResult();
            html.ViewName = "/views/cadastro/formulario.cshtml";
            
            return html;
        }

    }
}
