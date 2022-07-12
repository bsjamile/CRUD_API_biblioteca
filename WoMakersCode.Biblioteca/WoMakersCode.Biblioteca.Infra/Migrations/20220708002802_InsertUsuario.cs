using Microsoft.EntityFrameworkCore.Migrations;

namespace WoMakersCode.Biblioteca.Infra.Migrations
{
    public partial class InsertUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO usuarios(nome, endereco, telefone) values ('Jam', 'Rua z', '55505555');");
            migrationBuilder.Sql("INSERT INTO usuarios(nome, endereco, telefone) values ('Jess', 'Rua y', '5500045');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
