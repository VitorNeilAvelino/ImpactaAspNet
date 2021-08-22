using AspNet.Capitulo02.Razor.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace AspNet.Capitulo02.Razor.Comentarios
{
    public class ComentarioAplicacao
    {
        private readonly string caminho = AppDomain.CurrentDomain.BaseDirectory +
            ConfigurationManager.AppSettings["caminhoArquivoComentario"];

        public void Incluir(string nome, string comentario)
        {
            File.AppendAllText(caminho, $"{nome};{comentario}" + Environment.NewLine);
        }

        public List<ComentarioViewModel> Selecionar()
        {
            var comentarios = new List<ComentarioViewModel>();

            foreach (var linha in File.ReadAllLines(caminho))
            {
                if (linha.Trim() == string.Empty)
                {
                    continue;
                }

                var propriedades = linha.Split(';');

                var comentario = new ComentarioViewModel();
                comentario.Nome = propriedades[0];
                comentario.Conteudo = propriedades[1];

                comentarios.Add(comentario);
            }

            return comentarios;
        }
    }
}