using ApproarchVendas.Catalogo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApproachVendas.Catalogo.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.OwnsOne(p => p.Dimensoes, pd=>{

                pd.Property(p => p.Altura)
                    .HasColumnName("altura")
                    .IsRequired()
                    .HasColumnType("int");                
                
                pd.Property(p => p.Largura)
                    .HasColumnName("largura")
                    .IsRequired()
                    .HasColumnType("int");                
                
                pd.Property(p => p.Profundidade)
                    .HasColumnName("profundidade")
                    .IsRequired()
                    .HasColumnType("int");

            });

            builder.ToTable("produtos");
        }
    }
}
