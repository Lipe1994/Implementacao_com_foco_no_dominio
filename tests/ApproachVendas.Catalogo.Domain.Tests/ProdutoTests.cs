using ApproarchVendas.Catalogo.Domain;
using ApproarchVendas.Core.DomainObjects.ObjectValues;
using ApproarchVendas.Core.Errors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ApproachVendas.Catalogo.Domain.Tests
{
    [TestClass]
    public class ProdutoTests
    {
        [TestMethod]
        public void Produto_Validar_NomeNaoPodeEstarVazio()
        {
            // Arrange && Act
            var ex = Assert.ThrowsException<DomainException>(()=> new Produto(Guid.NewGuid(), string.Empty, "Descricao", false, 100, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));

            //Assert
            Assert.AreEqual("O campo nome do produto n�o pode ser vazio", ex.Message);
        }
        
        [TestMethod]
        public void Produto_Validar_DescricaoNaoPodeEstarVazio()
        {
            // Arrange && Act
            var ex = Assert.ThrowsException<DomainException>(()=> new Produto(Guid.NewGuid(), "Nome", string.Empty, false, 100, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));

            //Assert
            Assert.AreEqual("O campo Descricao de produto n�o pode ser vazio", ex.Message);
        }
        
        [TestMethod]
        public void Produto_Validar_ValorDoProdutoNaoPodeSerMenorQue()
        {
            // Arrange && Act
            var ex = Assert.ThrowsException<DomainException>(()=> new Produto(Guid.NewGuid(), "Nome", "Descricao", false, 0, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));

            //Assert
            Assert.AreEqual("O campo Valor do produto n�o pode ser menor que 0.01", ex.Message);
        }
        
        [TestMethod]
        public void Produto_Validar_CategoriaNaoPodeEstarVazio()
        {
            // Arrange && Act
            var ex = Assert.ThrowsException<DomainException>(()=> new Produto(Guid.Empty, "Nome", "Descricao", false, 1, DateTime.Now, "Imagem", new Dimensoes(1, 1, 1)));

            //Assert
            Assert.AreEqual("O campo CategoriaId do produto n�o pode ser vazio", ex.Message);
        }
        
        [TestMethod]
        public void Produto_Validar_ImagemNaoPodeEstarVazio()
        {
            // Arrange && Act
            var ex = Assert.ThrowsException<DomainException>(()=> new Produto(Guid.NewGuid(), "Nome", "Descricao", false, 1, DateTime.Now, string.Empty, new Dimensoes(1, 1, 1)));

            //Assert
            Assert.AreEqual("O campo Imagem do produto n�o pode estar vazio", ex.Message);
        }
        
        [TestMethod]
        public void Produto_Validar_AlturaNaoPodeSerMenorQue()
        {
            // Arrange && Act
            var ex = Assert.ThrowsException<DomainException>(()=> new Produto(Guid.NewGuid(), "Nome", "Descricao", false, 1, DateTime.Now, string.Empty, new Dimensoes(0, 1, 1)));

            //Assert
            Assert.AreEqual("O camapo Altura n�o pode ser menor que 1", ex.Message);
        }
    }
}
