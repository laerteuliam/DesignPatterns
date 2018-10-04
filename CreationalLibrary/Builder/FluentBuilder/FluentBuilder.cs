namespace CreationalLibrary.Builder.FluentBuilder
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public class Builder : PessoaEnderecoBuilder<Builder> { }
        public static Builder Novo => new Builder();
        public override string ToString()
        {
            return $"Nome:{Nome}, Endereço:{Endereco}";
        }
    }

    public abstract class PessoaBuilder<SELF>
    where SELF : PessoaBuilder<SELF>
    {
        protected Pessoa pessoa = new Pessoa();
        public Pessoa Build()
        {
            return pessoa;
        }
    }

    public class PessoaDadosPessoaisBuilder<SELF> : PessoaBuilder<SELF>
        where SELF : PessoaDadosPessoaisBuilder<SELF>
    {
        public SELF Chama(string nome)
        {
            this.pessoa.Nome = nome;
            return (SELF)this;
        }
    }

    public class PessoaEnderecoBuilder<SELF> : PessoaDadosPessoaisBuilder<SELF>
        where SELF : PessoaEnderecoBuilder<SELF>
    {
        public SELF ResideEm(string endereco)
        {
            this.pessoa.Endereco = endereco;
            return (SELF)this;
        }
    }

    
}
