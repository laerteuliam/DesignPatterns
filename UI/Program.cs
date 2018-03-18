using CreationalLibrary.Factory.AbstractFactory;
using System;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            FluentBuilder();
            FacetedBuilder();
            AbstractFactory();
            Console.Read();
        }

        private static void AbstractFactory()
        {
            var maquinaDeBebidas = new MaquinaDeBebidas();
            var bebida = maquinaDeBebidas.PepararBebida();
            bebida.Consumir();
        }

        private static void FacetedBuilder()
        {
            Console.WriteLine("--- Faceted Builder ---");
            var pessoaBuilder = new CreationalLibrary.Builder.FacetedBuilder.PessoaBuilder();
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
            var pessoaBuilder = CreationalLibrary.Builder.FluentBuilder.Pessoa.Novo;

            var pessoa = pessoaBuilder
                .Chama("Laerte Uliam")
                .ResideEm("Jd. Jaraguá").Build();

            Console.WriteLine(pessoa.ToString());
        }
    }
}
