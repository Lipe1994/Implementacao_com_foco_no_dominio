using ApproarchVendas.Catalogo.Domain.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApproarchVendas.Catalogo.Domain.Events
{
    class ProdutoEventHandler : INotificationHandler<ProdutoAbaixoDoEstoqueMinimoEvent>
    {
        private readonly IProdutoRepository produtoRepository;

        public ProdutoEventHandler(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public async Task Handle(ProdutoAbaixoDoEstoqueMinimoEvent notification, CancellationToken cancellationToken)
        {
            var produto = await produtoRepository.ObterPorId(notification.AggregateId);

            //faz algo, manda email
        }
    }
}
