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

    public class ConfigurableDatabase : IDatabase
    {
        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>
            {
                ["Mexico City"] = 20000,
                ["Salvador"] = 23000,
                ["Curitiba"] = 1000
            }[name];
        }
    }

    public class ConfigurableRecordFinder
    {
        private readonly IDatabase _database;

        public ConfigurableRecordFinder(IDatabase database)
        {
            _database = database ?? throw new ArgumentNullException(paramName: nameof(database));
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            names.ForEach(name =>
            {
                result += _database.GetPopulation(name);
            });
            return result;
        }

        public IDatabase Database => _database;
    }

    public class OrdinaryDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        private static Lazy<OrdinaryDatabase> instance = new Lazy<OrdinaryDatabase>(() =>
        {
            return new OrdinaryDatabase();
        }
        );
        public static IDatabase Instance => instance.Value;

        private OrdinaryDatabase()
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

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        private static int instanceCount;
        public static int Count => instanceCount;
        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() =>
        {
            return new SingletonDatabase();
        }
        );
        public static IDatabase Instance => instance.Value;

        private SingletonDatabase()
        {
            instanceCount++;
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
