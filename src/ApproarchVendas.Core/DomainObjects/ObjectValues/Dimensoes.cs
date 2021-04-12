using ApproarchVendas.Core.Extensions;

namespace ApproarchVendas.Core.DomainObjects.ObjectValues
{
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade) 
        {
            AssertionConcern.ValidarSeMenorQue(altura, 1, "O camapo Altura não pode ser menor que 1");
            AssertionConcern.ValidarSeMenorQue(largura, 1, "O camapo Largura não pode ser menor que 1");
            AssertionConcern.ValidarSeMenorQue(profundidade, 1, "O camapo profundidade não pode ser menor que 1");

            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        public string DescricaoFormatada() 
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }
    }
}
