using ApproarchVendas.Catalogo.Application.DTOs;
using ApproarchVendas.Catalogo.Domain;
using ApproarchVendas.Core.DomainObjects.ObjectValues;
using AutoMapper;

namespace ApproarchVendas.Catalogo.Application.AutoMapper
{
    public class DTOToDomain : Profile
    {
        public DTOToDomain()
        {
            CreateMap<ProdutoDTO, Produto>()
                .ConstructUsing(p => new Produto(p.CategoriaId, p.Nome, p.Descricao, p.Ativo,
                        p.Valor, p.DataCadastro,
                        p.Imagem, new Dimensoes(p.Altura, p.Largura, p.Profundidade)));

            CreateMap<CategoriaDTO, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));
        }
    }
}
