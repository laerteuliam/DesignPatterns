using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace CreationalLibrary.Singleton
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }
    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        private static int instanceCount;
        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() =>
        {
            instanceCount++;
            return new SingletonDatabase();
        }
        );
        public static IDatabase Instance => instance.Value;

        private SingletonDatabase()
        {
            Console.WriteLine("Initialiazing Database");
            var pathFile = Path.Combine(new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt");
            capitals = File.ReadAllLines(pathFile)
                    .Batch(2)
                    .ToDictionary(
                        list => list.ElementAt(0).Trim(),
                        list => int.Parse(list.ElementAt(1))
                    );
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
