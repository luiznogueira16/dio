using System;
namespace Novel
{
    public class LNovel : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Sinopse { get; set; }
        private int Ano { get; set; }
        private string Autor { get; set; }
        private bool Excluido { get; set; }

        public LNovel(int id, Genero genero, string titulo, string sinopse, int ano, string autor)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Sinopse = sinopse;
            this.Ano = ano;
            this.Autor = autor;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Sinopse + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano;
            retorno += "Autor: " + this.Autor + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornoTitulo()
        {
            return this.Titulo;
        }
        public bool retornoExcluido()
        {
            return this.Excluido;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public void Exclui()
        {
            this.Excluido = true;
        }
    }
}