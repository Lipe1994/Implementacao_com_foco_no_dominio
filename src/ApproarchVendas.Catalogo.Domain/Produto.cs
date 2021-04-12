using ApproarchVendas.Core.Contracts;
using ApproarchVendas.Core.DomainObjects;
using ApproarchVendas.Core.DomainObjects.ObjectValues;
using ApproarchVendas.Core.Errors;
using ApproarchVendas.Core.Extensions;
using System;

namespace ApproarchVendas.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public Guid CategoriaId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Dimensoes Dimensoes { get; set; }
        public Categoria Categoria { get; private set; }

        public Produto(Guid categoriaId, string nome, string descricao, bool ativo, decimal valor, DateTime dataCadastro, string imagem, Dimensoes dimensoes)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;
            Dimensoes = dimensoes;

            Validar();
        }

        //add hooks seters
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
        public void AlterarCategoria(Categoria categoria) 
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }
        public void AlterarDescricao(string descricao) 
        {
            AssertionConcern.ValidarSeVazio(descricao, "O campo Descricao de produto não pode ser vazio");
            Descricao = descricao;
        }
        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if (!PossuiEstoque(quantidade)) throw new DomainException("Estoque insuficiente");

            QuantidadeEstoque -= quantidade;
        }
        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        //getHooks
        public bool PossuiEstoque(int quantidade) 
        {
            return QuantidadeEstoque >= quantidade;
        }

        //Validação
        public void Validar() 
        {
            AssertionConcern.ValidarSeVazio(Nome, "O campo nome do produto não pode ser vazio");
            AssertionConcern.ValidarSeVazio(Descricao, "O campo Descricao de produto não pode ser vazio");
            AssertionConcern.ValidarSeIgual(CategoriaId, Guid.Empty, "O campo CategoriaId do produto não pode ser vazio");
            AssertionConcern.ValidarSeMenorQue((long)Valor, 0.01, "O campo Valor do produto não pode ser menor que 0.01");
            AssertionConcern.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode estar vazio");
        }
    }
}
