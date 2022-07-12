using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WoMakersCode.Biblioteca.Core.Entities;

namespace WoMakersCode.Biblioteca.Infra.DataBase
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.Nome)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();
            builder.Property(p => p.Endereco)
                .HasColumnType("VARCHAR(250)")
                .IsRequired();
            builder.Property(p => p.Telefone)
                .HasColumnType("VARCHAR(15)");
        }
    }
}