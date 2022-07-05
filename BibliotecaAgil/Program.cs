using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAgil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader read = new StreamReader("C:/Users/Tanjerina/Desktop/Projetos Agil/Questão 1/BibliotecaAgil/BibliotecaAgil/LivrosCadastrados.json");             
            String json = read.ReadToEnd();
            List<Livro> Prateleira = JsonConvert.DeserializeObject<List<Livro>>(json);
            int? exec = 100;
            while(exec != 0)
            {
                Console.Clear();
                Console.WriteLine("Qual opção você gostaria de realizar:" +
                    "\n1-Doar um livro" +
                    "\n2-Retirar um livro" +
                    "\n3-Devolver um livro" +
                    "\n4-Listar os livros" +
                    "\n0-Sair da execução");
                exec = int.Parse(Console.ReadLine());
                switch (exec)
                {
                    case 1:
                        doar(Prateleira);
                        read.Close();
                        enviarJson(Prateleira);
                        break;
                    case 2:
                        Console.Clear();
                        listar(Prateleira);
                        Console.WriteLine("Qual o id do livro que você quer retirar?");
                        int idLivro = int.Parse(Console.ReadLine());
                        retirar(Prateleira, idLivro);
                        read.Close();
                        enviarJson(Prateleira);
                        break;
                    case 3:
                        Console.Clear();
                        listar(Prateleira);
                        Console.WriteLine("Qual o id do livro que você quer devovler?");
                        idLivro = int.Parse(Console.ReadLine());
                        devolver(Prateleira, idLivro);
                        read.Close();
                        enviarJson(Prateleira);
                        break;
                    case 4:
                        Console.Clear();
                        listar(Prateleira);
                        Console.ReadKey();
                        break;
                    case 0:                        
                        read.Close();
                        enviarJson(Prateleira);

                        break;
                    default:                        
                        Console.WriteLine("Você precisa digitar uma ação");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void retirar(List<Livro> Prateleira, int id)
        {
            if (Prateleira[id-1].Status == false)
            {
                Console.WriteLine("Sinto muito, mas este livro já está emprestado a uma pessoa");
            }
            else
            {
                Console.WriteLine("Digite o nome da pessoa que está retirando o livro:");
                String name = Console.ReadLine();

                Prateleira[id-1].Status = false;
                Prateleira[id-1].Emprestado = name;
                listarPos(Prateleira, id-1);
            }
        }
        static void devolver(List<Livro> Prateleira, int id)
        {
            listarPos(Prateleira,id - 1);
            if(Prateleira[id-1].Status == true)
            {
                Console.WriteLine("Este livro não está emprestado");
            }
            else
            {
                Prateleira[id - 1].Status = true;
                Prateleira[id - 1].Emprestado = "";
                listarPos(Prateleira, id - 1);
            }
        }
        static void doar(List<Livro> Prateleira)
        {
            int id = int.Parse("0000"+(Prateleira.Count()+1));
            string titulo;
            string autor;
            int ano;
            bool status = true;
            string emprestado = "";
            Console.WriteLine("Digite o nome do livro: ");
            titulo = Console.ReadLine();
            Console.WriteLine("Digite o nome do autor: ");
            autor = Console.ReadLine();
            Console.WriteLine("Qual o ano de publicação? ");
            ano = int.Parse(Console.ReadLine());
            Prateleira.Add(new Livro(id, titulo, autor, ano, status, emprestado));
        }
        static void listar(List<Livro> Prateleira)
        {
            foreach (Livro livro in Prateleira)
            {
                Console.WriteLine(livro);
            }
        }
        static void listarPos(List<Livro> Prateleira, int id)
        {
            Console.WriteLine(Prateleira[id]);

        }
        static void enviarJson(List<Livro> Prateleira)
        {
            String jsonPrateleira;
            Livro[] livros = new Livro[Prateleira.Count()];
            for(int i = 0; i < Prateleira.Count(); i++)
            {
                livros[i] = Prateleira[i];
            }
            JsonSerializer inserir = new JsonSerializer();                      
                jsonPrateleira = JsonConvert.SerializeObject(livros);
                File.WriteAllText("C:/Users/Tanjerina/Desktop/Projetos Agil/Questão 1/BibliotecaAgil/BibliotecaAgil/LivrosCadastrados.json", jsonPrateleira);
        }
    }
}
