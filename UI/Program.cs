﻿using CreationalLibrary.Factory.AbstractFactory;
using CreationalLibrary.Prototype.DeepCopy;
using System;

namespace Creational.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //FluentBuilder();
            //FacetedBuilder();
            //AbstractFactory();
            //ConstructorPrototype();
            //DeepCopyPrototype();
            //SingletonDatabase();
            MonoState();
            Console.Read();
        }
        
        #region Factories

        private static void AbstractFactory()
        {
            var maquinaDeBebidas = new MaquinaDeBebidas();
            var bebida = maquinaDeBebidas.PepararBebida();
            bebida.Consumir();
        }

        #endregion

        #region Builders
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
        #endregion

        #region Prototypes
        public static void ConstructorPrototype()
        {
            var enderecoLaerte = new CreationalLibrary.Prototype.Constructor.Endereco("São Paulo", "SP", "Rua Dr Vila Nova", "xxx");
            var laerte = new CreationalLibrary.Prototype.Constructor.Pessoa("Laerte", enderecoLaerte);

            var ira = new CreationalLibrary.Prototype.Constructor.Pessoa(laerte);
            ira.Nome = "Ira";

            Console.WriteLine(laerte.ToString());
            Console.WriteLine(ira.ToString());
        }

        public static void DeepCopyPrototype()
        {
            var enderecoLaerte = new CreationalLibrary.Prototype.DeepCopy.Endereco("São Paulo", "SP", "Rua Dr Vila Nova", "xxx");
            var laerte = new CreationalLibrary.Prototype.DeepCopy.Pessoa("Laerte", enderecoLaerte);

            var ira = laerte.DeepCopy();
            ira.Nome = "Ira";

            Console.WriteLine(laerte.ToString());
            Console.WriteLine(ira.ToString());
        }
        #endregion

        #region Singleton
        private static void SingletonDatabase()
        {
            Console.WriteLine("Singleton Database");

            var db = CreationalLibrary.Singleton.SingletonDatabase.Instance;
            var db2 = CreationalLibrary.Singleton.SingletonDatabase.Instance;
            var db3 = CreationalLibrary.Singleton.SingletonDatabase.Instance;
            var count = CreationalLibrary.Singleton.SingletonDatabase.Count;

            Console.WriteLine($"Quantidade de Instâncias {count}");
        }

        private static void MonoState()
        {
            Console.WriteLine("MonoState");
            var ceo = new CreationalLibrary.Monostate.CEO();
            ceo.Name = "Laerte";
            ceo.Age = 34;
            var ceo2 = new CreationalLibrary.Monostate.CEO();

            Console.WriteLine(ceo.ToString());
            Console.WriteLine(ceo2.ToString());
        }
        #endregion


    }
}