using CreationalLibrary.FacetedBuilder;
using System;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            FluentBuilder();
            FacetedBuilder();
            Console.Read();
        }

        private static void FacetedBuilder()
        {
            Console.WriteLine("--- Faceted Builder ---");
            var pessoaBuilder = new PessoaBuilder();
            var pessoa = pessoaBuilder
                .Chama("João")
                .Trabalha
                    .Na("Microsoft")
                    .Como("Engenheiro de Software")
                    .Ganhando(10000)
                .Reside
                    .NoEndereco("Av Brasil", "Rio de Janeiro", "Brasil").Build();
            
            Console.WriteLine(pessoa.ToString());
        }

        private static void FluentBuilder()
        {
            Console.WriteLine("--- Fluent Builder ---");
            var pessoaBuilder = CreationalLibrary.FluentBuilder.Pessoa.Novo;

            var pessoa = pessoaBuilder
                .Chama("Laerte Uliam")
                .ResideEm("Jd. Jaraguá").Build();

            Console.WriteLine(pessoa.ToString());
        }
    }
}
