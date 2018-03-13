using System;
using CreationalLibrary.FluentBuilder;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var pessoa = Pessoa.Novo
                .Chama("Laerte Uliam")
                .ResideEm("Jd. Jaraguá").Build();

            Console.WriteLine(pessoa.ToString());
            Console.Read();
        }
    }
}
