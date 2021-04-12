using ApproachVendas.Core.Bus.Contracts;
using ApproarchVendas.Catalogo.Domain.Contracts;
using ApproarchVendas.Catalogo.Domain.Events;
using System;
using System.Threading.Tasks;

namespace ApproarchVendas.Catalogo.Domain.Services
{
    public interface IEstoqueService
    {
        Task<bool> DebitarEstoque(Guid produtoId, int quantidade);
        Task<bool> ReporEstoque(Guid produtoId, int quantidade);
        void Dispose();
    }
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IMediatrHandler mediatrHandler;

        public EstoqueService(IProdutoRepository produtoRepository, IMediatrHandler mediatrHandler )
        {
            this.produtoRepository = produtoRepository;
            this.mediatrHandler = mediatrHandler;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            //TODO Parametrizar quantidade minima
            if (produto.QuantidadeEstoque < 10){
                await mediatrHandler.PublicarEvento(new ProdutoAbaixoDoEstoqueMinimoEvent(produtoId));
            }

            produtoRepository.Atualizar(produto);
            return await produtoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;
            produto.ReporEstoque(quantidade);

            produtoRepository.Atualizar(produto);
            return await produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            produtoRepository.Dispose();
        }
    }
}
