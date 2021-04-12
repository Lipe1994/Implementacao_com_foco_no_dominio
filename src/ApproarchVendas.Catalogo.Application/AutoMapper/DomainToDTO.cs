using ApproarchVendas.Catalogo.Application.DTOs;
using ApproarchVendas.Catalogo.Domain;
using AutoMapper;

namespace ApproarchVendas.Catalogo.Application.AutoMapper
{
    public class DomainToDTO : Profile
    {
        public DomainToDTO()
        {
            CreateMap<Produto, ProdutoDTO>()
                    .ForMember(d => d.Altura, o => o.MapFrom(s => s.Dimensoes.Altura))
                    .ForMember(d => d.Largura, o => o.MapFrom(s => s.Dimensoes.Largura))
                    .ForMember(d => d.Profundidade, o => o.MapFrom(s => s.Dimensoes.Profundidade));

            CreateMap<Categoria, CategoriaDTO>();
        }
    }
}
