using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WoMakersCode.Biblioteca.Core.Entities;

namespace WoMakersCode.Biblioteca.Infra.DataBase
{
    public class EmprestimoConfiguration 
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("emprestimos");
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.DataEmprestimo)
                .HasColumnType("DATETIME")
                .IsRequired();
            builder.Property(p => p.DataDevolucao)
                .HasColumnType("DATETIME")
                .IsRequired();
            /*
            
            public int IdUsuario { get; set; }
            public Usuario Usuario { get; set; }
            public int IdLivro { get; set; }
            public Livro Livro { get; set; }*/
        }
    }
}
