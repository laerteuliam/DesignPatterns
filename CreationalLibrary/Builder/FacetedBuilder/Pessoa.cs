using System;

namespace CreationalLibrary.Builder.FacetedBuilder
{
    public class Pessoa
    {
        //Dados Pessoais
        public string Nome;

        //Endereço
        public string Endereco, Cidade, Pais;

        //Trabalho
        public string Empresa, Cargo;
        public decimal Salario;

        public override string ToString()
        {
            return $"Nome:{Nome}, Endereço:{Endereco}, Empresa:{Empresa}, Salário:{Salario}";
        }
    }

    public class PessoaBuilder //Facade
    {
        protected Pessoa pessoa = new Pessoa();
        public PessoaBuilder Chama(string nome)
        {
            this.pessoa.Nome = nome;
            return this;
        }
        public PessoaTrabalhoBuilder Trabalha => new PessoaTrabalhoBuilder(pessoa);
        public PessoaEnderecoBuilder Reside => new PessoaEnderecoBuilder(pessoa);
        public Pessoa Build() => this.pessoa;
    }

    public class PessoaTrabalhoBuilder : PessoaBuilder
    {
        public PessoaTrabalhoBuilder(Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        public PessoaTrabalhoBuilder Na(string empresa)
        {
            this.pessoa.Empresa = empresa;
            return this;
        }

        public PessoaTrabalhoBuilder Como(string cargo)
        {
            this.pessoa.Cargo = cargo;
            return this;
        }

        public PessoaTrabalhoBuilder Ganhando(decimal salario)
        {
            this.pessoa.Salario = salario;
            return this;
        }
    }

    public class PessoaEnderecoBuilder : PessoaBuilder
    {
        public PessoaEnderecoBuilder(Pessoa pessoa)
        {
            this.pessoa = pessoa;
        }

        public PessoaEnderecoBuilder NoEndereco(string endereco, string cidade, string pais)
        {
            this.pessoa.Endereco = endereco;
            this.pessoa.Cidade = endereco;
            this.pessoa.Pais = pais;
            return this;
        }


    }

}
