using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAgil
{
    internal class Livro
    {
        public int Id { get; set; }
        public String Titulo { get; set; }
        public String Autor { get; set; }
        public int Ano { get; set; }
        public bool Status { get; set; }
        public String Emprestado { get; set; }

        public Livro()
        {
        }
        public Livro(int id, string titulo, string autor, int ano, bool status, string emprestado)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Status = status;
            Emprestado = emprestado;
        }

        public override string ToString()
        {
            String stts = "Disponivel";
            if(Status == false)
            {
                stts = "Indisponivel";
            }
            return "Id: " + Id
                + "\nTítulo: " + Titulo
                + "\nAutor: " + Autor
                + "\nAno: " + Ano
                + "\nStatus: " + stts
                + "\nEmprestado para: " + Emprestado;
        }
    }
}
