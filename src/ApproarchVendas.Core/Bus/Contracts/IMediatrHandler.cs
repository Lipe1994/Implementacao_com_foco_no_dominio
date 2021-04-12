using ApproachVendas.Core.Messages;
using System.Threading.Tasks;

namespace ApproachVendas.Core.Bus.Contracts
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}
