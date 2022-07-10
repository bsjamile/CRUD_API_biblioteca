using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WoMakersCode.Biblioteca.Core.Entities;

namespace WoMakersCode.Biblioteca.Infra.DataBase
{
    internal class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {

            builder.ToTable("livros");
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.Titulo)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
            builder.Property(p => p.QuantidadeDisponivel)
                .HasColumnType("INT")
                .IsRequired();
            builder.HasOne(fk => fk.Autor)
                .WithMany(fk => fk.livros)
                .HasForeignKey(fk => fk.IdAutor);
        }
    }
}
