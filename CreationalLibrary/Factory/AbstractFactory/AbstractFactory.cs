using System;
using System.Collections.Generic;
using System.Text;

namespace CreationalLibrary.Factory.AbstractFactory
{
    public interface IBebida
    {
        void Consumir();
    }

    internal class Cafe : IBebida
    {
        public void Consumir()
        {
            Console.WriteLine("Café está delicioso.");
        }
    }

    internal class Cha : IBebida
    {
        public void Consumir()
        {
            Console.WriteLine("Chá está fervendo.");
        }
    }

    internal interface IBebidaFactory
    {
        IBebida Preparar(int quantidade);
    }

    internal class CafeFactory : IBebidaFactory
    {
        public IBebida Preparar(int quantidade)
        {
            Console.WriteLine("Esquentando a água...");
            Console.WriteLine("Coando o café...");
            return new Cafe();
        }
    }

    internal class ChaFactory : IBebidaFactory
    {
        public IBebida Preparar(int quantidade)
        {
            Console.WriteLine("Esquentando a aguá...");
            Console.WriteLine("Preparando o chá...");
            return new Cha();
        }
    }

    public class MaquinaDeBebidas
    {
        private List<Tuple<string, IBebidaFactory>> namedFactories = new List<Tuple<string, IBebidaFactory>>();

        public MaquinaDeBebidas()
        {
            foreach (var t in typeof(MaquinaDeBebidas).Assembly.GetTypes())
            {
                if (typeof(IBebidaFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    namedFactories.Add(
                        Tuple.Create(
                            t.Name.Replace("Factory", string.Empty),
                            (IBebidaFactory)Activator.CreateInstance(t)
                        ));
                }
            }
        }

        public IBebida PepararBebida()
        {
            Console.WriteLine("Bebidas disponíveis:");
            for (var index = 0; index < namedFactories.Count; index++)
            {
                var tuple = namedFactories[index];
                Console.WriteLine($"{index}: {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null
                    && int.TryParse(s, out int i) // c# 7
                    && i >= 0
                    && i < namedFactories.Count)
                {
                    Console.Write("Quantidade: ");
                    s = Console.ReadLine();
                    if (s != null
                        && int.TryParse(s, out int amount)
                        && amount > 0)
                    {
                        return namedFactories[i].Item2.Preparar(amount);
                    }
                }
                Console.WriteLine("Incorreto, tente novamente.");
            }
        }
    }

}
