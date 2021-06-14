using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Alura.ListaLeitura.App.Views
{
    public class HtmlUtils
    {
        public static string CarregaHTML(string v)
        {
            var nomeCompletoDoArquivo = $"D:/Developer/Alura/Asp.NET Core Uma webapp usando o padrão MVC/Alura.ListaLeitura.Aula2/Alura.ListaLeitura/Alura.ListaLeitura.App/Views/{v}.cshtml";
            using (var html = File.OpenText(nomeCompletoDoArquivo))
            {
                return html.ReadToEnd();
            }
        }

    }
}
