using ApproachVendas.Core.Bus.Contracts;
using ApproachVendas.Core.Messages;
using MediatR;
using System.Threading.Tasks;

namespace ApproachVendas.Core.Bus.Mediatr
{
    public class MediatrHandler : IMediatrHandler
    {
        private readonly IMediator mediator;

        public MediatrHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await mediator.Publish(evento);
        }
    }
}
