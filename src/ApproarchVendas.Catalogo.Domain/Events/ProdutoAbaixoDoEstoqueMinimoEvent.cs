using ApproachVendas.Core.DomainObjects;
using System;

namespace ApproarchVendas.Catalogo.Domain.Events
{
    public class ProdutoAbaixoDoEstoqueMinimoEvent : DomainEvent
    {
        public int QuantidadeRestante {get; private set;}
        public ProdutoAbaixoDoEstoqueMinimoEvent(Guid aggregateId) : base(aggregateId)
        {
        }


    }
}
