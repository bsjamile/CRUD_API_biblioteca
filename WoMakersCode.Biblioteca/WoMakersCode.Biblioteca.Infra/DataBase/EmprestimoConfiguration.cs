using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WoMakersCode.Biblioteca.Core.Entities;
namespace WoMakersCode.Biblioteca.Infra.DataBase
{
    public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("emprestimos");
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.DataEmprestimo)
                .HasColumnType("DATETIME")
                .IsRequired();
            builder.Property(p => p.DataDevolucao)
                .HasColumnType("DATETIME");
            builder.HasOne(fk => fk.Usuario)
                .WithMany(fk => fk.emprestimos)
                .HasForeignKey(fk => fk.IdUsuario);
            builder.HasOne(fk => fk.Livro)
                .WithMany(fk => fk.emprestimos)
                .HasForeignKey(fk => fk.IdLivro);
        }
    }
}
