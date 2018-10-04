using System;

namespace CreationalLibrary.Prototype.Constructor
{
    public class Pessoa
    {
        public Pessoa(Pessoa outro)
        {
            Nome = outro.Nome;
            Endereco = outro.Endereco;
        }

        public Pessoa(string nome, Endereco endereco)
        {
            Nome = nome ?? throw new ArgumentNullException(paramName:nameof(nome));
            Endereco = endereco ?? throw new ArgumentNullException(paramName:nameof(endereco));
        }

        public string Nome { get; set; }
        public Endereco Endereco { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}, Endereço: {Endereco.Logradouro}, {Endereco.Numero}, {Endereco.Cidade} - {Endereco.Estado}";
        }
    }

    public class Endereco
    {
        public Endereco(Endereco outro)
        {
            Cidade = outro.Cidade;
            Estado = outro.Estado;
            Logradouro = outro.Logradouro;
            Numero = outro.Numero;
        }
        public Endereco(string cidade, string estado, string logradouro, string numero)
        {
            Cidade = cidade ?? throw new ArgumentNullException(paramName: nameof(cidade));
            Estado = estado ?? throw new ArgumentNullException(paramName: nameof(estado));
            Logradouro = logradouro?? throw new ArgumentNullException(paramName:nameof(logradouro));
            Numero = numero ?? throw new ArgumentNullException(paramName:nameof(numero));
        }

        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
    }
}
