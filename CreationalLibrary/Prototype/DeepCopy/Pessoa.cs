using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CreationalLibrary.Prototype.DeepCopy
{
    public static class ExtensionMethods {
        public static T DeepCopy<T>(this T self)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);
            stream.Seek(0, SeekOrigin.Begin);
            var objCopied = formatter.Deserialize(stream);
            stream.Close();
            return (T)objCopied;
        }
    }

    [Serializable]
    public class Pessoa
    {
        public Pessoa(string nome, Endereco endereco)
        {
            Nome = nome ?? throw new ArgumentNullException(paramName: nameof(nome));
            Endereco = endereco ?? throw new ArgumentNullException(paramName: nameof(endereco));
        }

        public string Nome { get; set; }
        public Endereco Endereco { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}, Endereço: {Endereco.Logradouro}, {Endereco.Numero}, {Endereco.Cidade} - {Endereco.Estado}";
        }
    }

    [Serializable]
    public class Endereco
    {
        public Endereco(string cidade, string estado, string logradouro, string numero)
        {
            Cidade = cidade ?? throw new ArgumentNullException(paramName: nameof(cidade));
            Estado = estado ?? throw new ArgumentNullException(paramName: nameof(estado));
            Logradouro = logradouro ?? throw new ArgumentNullException(paramName: nameof(logradouro));
            Numero = numero ?? throw new ArgumentNullException(paramName: nameof(numero));
        }

        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
    }
}
